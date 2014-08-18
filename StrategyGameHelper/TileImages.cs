using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace StrategyGameHelper
{
    public enum TileAttribute
    {
        None, Selected, AllowedNeighbor, DisallowedNeighbor
    }

    public struct Tile
    {
        /// <summary>
        /// Local index.
        /// </summary>
        public int Index;
        public TileAttribute Attribute;

        public Tile(int index, TileAttribute ta)
        {
            Index = index;
            Attribute = ta;
        }
    }

    public class TileImage
    {
        public string Path { get; set; }
        public string Identifier { get; set; }
        public int TileSize { get; set; }
        public byte[] ImageHash { get; set; }
        [ScriptIgnore]
        public Bitmap Image { get; set; }
        public bool IsTileSource { get; set; }
        private List<Tile> TileAttributes { get; set; }

        public TileImage()
        {
            IsTileSource = false;
            TileAttributes = new List<Tile>();
            TileSize = 32;
        }
        public TileImage(string path, string identifier, bool isTileSource)
        {
            Path = path;
            Identifier = identifier;
            IsTileSource = isTileSource;
            TileAttributes = new List<Tile>();
            TileSize = 32;
        }

        public void AddTile(Tile ta)
        {
            TileAttributes.RemoveAll(t => t.Index == ta.Index);
            TileAttributes.Add(ta);
        }
        public TileAttribute GetTileAttribute(int index)
        {
            return TileAttributes.Find(t => t.Index == index).Attribute;
        }
        public void ClearTile(int index)
        {
            TileAttributes.RemoveAll(item => item.Index == index);
        }
        public List<Tile> GetSelectedTiles()
        {
            return TileAttributes.FindAll(t => t.Attribute == TileAttribute.Selected);
        }
        public List<Tile> GetAllowedNeighborTiles()
        {
            return TileAttributes.FindAll(t => t.Attribute == TileAttribute.AllowedNeighbor);
        }
        public List<Tile> GetDisallowedNeighborTiles()
        {
            return TileAttributes.FindAll(t => t.Attribute == TileAttribute.DisallowedNeighbor);
        }
        public void SelectAllTiles()
        {
            for (int i = 0; i <= NumberOfIndeces - 1; i++)
            {
                AddTile(new Tile(i, TileAttribute.Selected));
            }
        }
        public void DeselectAllTiles()
        {
            TileAttributes.RemoveAll(t => t.Attribute == TileAttribute.Selected);
        }
        public bool IsAnyTileSelected()
        {
            return TileAttributes.Exists(t => t.Attribute == TileAttribute.Selected);
        }
        public List<Tile> GetTiles()
        {
            return new List<Tile>(TileAttributes);
        }
        public void Load()
        {
            Image = Helper.LoadImage(Path);
            var hash = Helper.GetImageHash(Image);
            if (ImageHash != null && !hash.ToList().SequenceEqual(ImageHash.ToList()))
            {
                throw new Exception("Image hash does not match.");
            }
            ImageHash = hash;
        }
        public int ColumnsPerRow
        {
            get { return Image.Width / TileSize; }
        }
        public int RowsPerColumn
        {
            get { return Image.Height / TileSize; }
        }
        public int NumberOfIndeces
        {
            get { return ColumnsPerRow * RowsPerColumn; }
        }
    }
}
