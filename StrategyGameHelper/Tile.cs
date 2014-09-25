using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGameHelper
{
    public enum TileSelectionGroups
    {
        None, Blue, Green, Red
    }
    public enum TileAttributes
    {
        Forest, Sea, Desert
    }

    public class Tile
    {
        /// <summary>
        /// Local index.
        /// </summary>
        public int Index;
        public TileSelectionGroups SelectionGroup;
        public List<TileAttributes> Attributes;

        public Tile(int index)
        {
            Index = index;
            SelectionGroup = TileSelectionGroups.None;
            Attributes = new List<TileAttributes>();
        }
        public Tile(int index, TileSelectionGroups tsg)
        {
            Index = index;
            SelectionGroup = tsg;
            Attributes = new List<TileAttributes>();
        }

        public void AddAttribute(TileAttributes ta)
        {
            if (!Attributes.Contains(ta)) { Attributes.Add(ta); }
        }
        public void RemoveAttribute(TileAttributes ta)
        {
            if (Attributes.Contains(ta)) { Attributes.Remove(ta); }
        }
    }
}
