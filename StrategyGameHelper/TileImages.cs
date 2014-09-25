using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace StrategyGameHelper
{
    public class TileImage
    {
        public string Path { get; set; }
        public string Identifier { get; set; }
        public int TileSize { get; set; }
        public byte[] ImageHash { get; set; }
        [ScriptIgnore]
        public Bitmap Image { get; set; }
        public bool IsTileSource { get; set; }
        private Dictionary<int, Tile> TileData { get; set; }

        public TileImage()
        {
            IsTileSource = false;
            TileData = new Dictionary<int, Tile>();
            TileSize = 32;
        }
        public TileImage(string path, string identifier, bool isTileSource)
        {
            Path = path;
            Identifier = identifier;
            IsTileSource = isTileSource;
            TileData = new Dictionary<int, Tile>();
            TileSize = 32;
        }

        public void SetSelectionGroup(int index, TileSelectionGroups tsg)
        {
            if (TileData.ContainsKey(index)) { TileData[index].SelectionGroup = tsg; }
            else { TileData[index] = new Tile(index, tsg); }
        }
        public void AddAttribute(int index, TileAttributes ta)
        {
            if (TileData.ContainsKey(index)) { TileData[index].AddAttribute(ta); }
            else
            {
                var t = new Tile(index);
                t.AddAttribute(ta);
                TileData[index] = t;
            }
        }
        public void RemoveAttribute(int index, TileAttributes ta)
        {
            if (TileData.ContainsKey(index)) { TileData[index].RemoveAttribute(ta); }
        }
        public TileSelectionGroups GetSelectionGroup(int index)
        {
            return TileData.ContainsKey(index) ? TileData[index].SelectionGroup : TileSelectionGroups.None;
        }
        public void ClearSelectionGroup(int index)
        {
            if (TileData.ContainsKey(index)) { TileData[index].SelectionGroup = TileSelectionGroups.None; }
        }
        public List<Tile> GetTiles(Predicate<Tile> match)
        {
            return TileData.Values.ToList().FindAll(match);
        }
        public List<Tile> GetGroupedTiles(TileSelectionGroups tsg)
        {
            return TileData.Values.ToList().FindAll(t => t.SelectionGroup == tsg);
        }
        public void GroupAllTiles(TileSelectionGroups tsg)
        {
            for (int i = 0; i <= NumberOfTiles - 1; i++)
            {
                SetSelectionGroup(i, tsg);
            }
        }
        public bool IsAnyTileGrouped()
        {
            return TileData.Values.ToList().Exists(t => t.SelectionGroup != TileSelectionGroups.None);
        }
        public List<Tile> GetTiles()
        {
            return new List<Tile>(TileData.Values);
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
        public int NumberOfTiles
        {
            get { return ColumnsPerRow * RowsPerColumn; }
        }
    }
}
