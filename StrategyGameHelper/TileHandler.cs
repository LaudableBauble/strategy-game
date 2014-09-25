using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace StrategyGameHelper
{
    public enum TileTab
    {
        Source, Randomized, RuleTest
    }
    public static class TileHandler
    {
        public static List<TileImage> SourceImages { get; set; }
        private static TileImage _RandomizedMapImage;
        private static TileImage _RuleTestMapImage;
        public static int[,] RandomizedMap;
        public static int[,] RuleTestMap;
        private static Dictionary<int, List<TileRule>> _TileRules;
        private static bool _CanMultiSelect;
        private static Bitmap _Blank;

        public static int SelectedSource { get; set; }
        public static int SelectedTile { get; set; }
        public static List<int> SelectedTiles { get; private set; }
        public static Random Random { get; set; }
        public static int TileSize { get { return SourceImages[SelectedSource].TileSize; } }

        public static void Initialize()
        {
            Random = new Random();

            _Blank = Helper.LoadImage(@"assets\blank.jpg");

            SourceImages = new List<TileImage>();
            SourceImages.Add(new TileImage(@"assets\smalltiletestmap.png", "a", true));
            SourceImages.Add(new TileImage(@"assets\tilestestmap2.png", "b", true));
            SourceImages[0].Load();
            SourceImages[1].Load();

            _RandomizedMapImage = new TileImage();
            _RandomizedMapImage.Image = new Bitmap(SourceImages[0].Image.Width, SourceImages[0].Image.Height);
            _RuleTestMapImage = new TileImage();
            _RuleTestMapImage.Image = new Bitmap(3 * SourceImages[0].TileSize, 3 * SourceImages[0].TileSize);

            RandomizedMap = new int[SourceImages[0].Image.Width / SourceImages[0].TileSize, SourceImages[0].Image.Height / SourceImages[0].TileSize];
            RuleTestMap = new int[3, 3];

            _TileRules = new Dictionary<int, List<TileRule>>();

            SelectedSource = 0;
            SelectedTiles = new List<int>();
            _CanMultiSelect = true;
        }
        public static void SaveConfiguration()
        {
            var config = new Config()
            {
                SourceImages = SourceImages.FindAll(item => item.IsTileSource),
                TileRules = GetRules()
            };
            var content = new JavaScriptSerializer().Serialize(config);

            Helper.SaveFile(@"assets\config", content);
        }
        public static void LoadConfiguration()
        {
            string content = Helper.LoadFile(@"assets\config");
            var config = new JavaScriptSerializer().Deserialize<Config>(content);

            SourceImages.RemoveAll(item => item.IsTileSource);
            SourceImages.AddRange(config.SourceImages);
            foreach (var r in config.TileRules) { AddRule(r); }

            SourceImages.FindAll(item => item.IsTileSource).ForEach(item => item.Load());
        }

        public static void SelectTile(int xPos, int yPos, TileTab tab, int clicks)
        {
            var ti = TileHandler.GetTileImage(tab);
            var tileSize = ti.TileSize;
            int originalIndex = TileHandler.GetTileIndex(xPos, yPos, tab);
            int index = ti.ColumnsPerRow * yPos + xPos;

            if (xPos >= ti.Image.Width / tileSize || yPos >= ti.Image.Height / tileSize) { return; }

            if (clicks == 1)
            {
                if (SelectedTiles.Contains(index)) { SelectedTiles.Remove(index); }
                else { SelectedTiles.Add(index); }
            }
            else
            {
                switch (tab)
                {
                    case TileTab.Source: { TileHandler.SelectedTile = originalIndex; break; }
                    case TileTab.Randomized: { TileHandler.SelectedTile = RandomizedMap[xPos, yPos]; break; }
                    case TileTab.RuleTest: { TileHandler.SelectedTile = RuleTestMap[xPos, yPos]; break; }
                }
            }
        }
        public static void SelectAll(TileTab tab)
        {
            DeselectAll(tab);
            for (int i = 0; i <= GetTileImage(tab).NumberOfTiles - 1; i++) { SelectedTiles.Add(i); }
        }
        public static void DeselectAll(TileTab tab)
        {
            SelectedTiles.Clear();
        }
        public static void SelectFromAttribute(TileAttributes ta)
        {
            if (SelectedTiles.Count == 0) { return; }
            var tiles = GetSelectedTiles().Where(t => t.Attributes.Contains(ta));
            SelectedTiles = tiles.Select(t => t.Index).ToList();
        }
        public static void DeselectFromAttribute(TileAttributes ta)
        {
            if (SelectedTiles.Count == 0) { return; }
            var tiles = GetSelectedTiles().Where(t => !t.Attributes.Contains(ta));
            SelectedTiles = tiles.Select(t => t.Index).ToList();
        }
        public static void AddAttributeToSelectedTiles(TileAttributes ta)
        {
            foreach (var i in SelectedTiles) { SourceImages[SelectedSource].AddAttribute(i, ta); }
        }
        public static void RemoveAttributeFromSelectedTiles(TileAttributes ta)
        {
            foreach (var i in SelectedTiles) { SourceImages[SelectedSource].RemoveAttribute(i, ta); }
        }
        public static List<TileAttributes> GetCommonAttributesOfSelectedTiles()
        {
            if (SelectedTiles.Count == 0) { return new List<TileAttributes>(); }
            var tiles = GetSelectedTiles();
            if (SelectedTiles.Count != tiles.Count) { return new List<TileAttributes>(); }
            var attributes = Enum.GetValues(typeof(TileAttributes)).OfType<TileAttributes>().ToList();
            return attributes.Where(ta => tiles.Count > 0 && tiles.All(t => t.Attributes.Contains(ta))).ToList();
        }
        public static Dictionary<TileAttributes, int> GetAttributeCountOfSelectedTiles()
        {
            if (SelectedTiles.Count == 0) { return new Dictionary<TileAttributes, int>(); }
            var tiles = GetSelectedTiles();

            var count = new Dictionary<TileAttributes, int>();
            foreach (var a in Enum.GetValues(typeof(TileAttributes)).OfType<TileAttributes>().ToList()) { count.Add(a, 0); }
            foreach (var t in tiles) { foreach (var ta in t.Attributes) { count[ta]++; } }
            return count;
        }
        public static void GroupSelectedTiles(TileTab tab, TileSelectionGroups tsg)
        {
            var ti = TileHandler.GetTileImage(tab);
            foreach (var i in SelectedTiles) { ti.SetSelectionGroup(i, tsg); }
        }
        public static void DisallowAllAroundSelected(TileTab tab)
        {
            var ti = GetTileImage(tab);
            foreach (var t in ti.GetTiles(t => t.SelectionGroup != TileSelectionGroups.None))
            {
                //West.
                ti.SetSelectionGroup(t.Index - 1, TileSelectionGroups.Red);
                //East.
                ti.SetSelectionGroup(t.Index + 1, TileSelectionGroups.Red);
                //North.
                ti.SetSelectionGroup(t.Index - ti.ColumnsPerRow, TileSelectionGroups.Red);
                //South.
                ti.SetSelectionGroup(t.Index + ti.ColumnsPerRow, TileSelectionGroups.Red);
            }
        }
        public static void DisallowEverythingNotAttributed(TileTab tab)
        {
            var ti = GetTileImage(tab);
            for (int i = 0; i < ti.NumberOfTiles; i++)
            {
                if (!ti.GetTiles().Exists(item => i == item.Index))
                {
                    ti.SetSelectionGroup(i, TileSelectionGroups.Red);
                }
            }
        }
        public static void DrawTiles(PictureBox pctb, TileTab tab)
        {
            var img = new Bitmap(pctb.Image);
            var graphics = Graphics.FromImage(img);
            graphics.Clear(Color.White);
            var tileSize = TileHandler.TileSize;
            var grid = tab == TileTab.Randomized ? RandomizedMap : RuleTestMap;

            for (int x = 0; x <= grid.GetLength(0) - 1; x++)
            {
                for (int y = 0; y <= grid.GetLength(1) - 1; y++)
                {
                    int srcX = grid[x, y] % TileHandler.GetTileImage(TileTab.Source).ColumnsPerRow;
                    int srcY = (grid[x, y] - srcX) / TileHandler.GetTileImage(TileTab.Source).ColumnsPerRow;
                    var dest = new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize);
                    var src = new Rectangle(srcX * tileSize, srcY * tileSize, tileSize, tileSize);

                    if (grid[x, y] == -1) { graphics.DrawImage(_Blank, dest.X, dest.Y); }
                    else { graphics.DrawImage(SourceImages[SelectedSource].Image, dest, src, GraphicsUnit.Pixel); }
                }
            }

            pctb.Image = img;
        }

        public static void AddRule(TileRule rule)
        {
            if (rule == null) { return; }

            if (!_TileRules.ContainsKey(rule.Base)) { _TileRules[rule.Base] = new List<TileRule>(); }
            if (!_TileRules.ContainsKey(rule.Neighbor)) { _TileRules[rule.Neighbor] = new List<TileRule>(); }
            if (!_TileRules[rule.Base].Contains(rule)) { _TileRules[rule.Base].Add(rule); }
            if (!_TileRules[rule.Neighbor].Contains(rule)) { _TileRules[rule.Neighbor].Add(rule.Flip()); }
        }
        public static void CreateRule(TileTab tab)
        {
            var ti = GetTileImage(tab);

            //Blue is selected tile, green allowed neighbors, red disallowed neighbors.
            foreach (var t in ti.GetTiles())
            {
                var index = GetTileIndex(t.Index, tab);
                var west = t.Index - 1;
                var east = t.Index + 1;
                var north = t.Index - ti.ColumnsPerRow;
                var south = t.Index + ti.ColumnsPerRow;
                var rt = RuleType.None;

                //West.
                if (ti.GetSelectionGroup(west) == TileSelectionGroups.Green || ti.GetSelectionGroup(west) == TileSelectionGroups.Red)
                {
                    rt = ti.GetSelectionGroup(west) == TileSelectionGroups.Green ? RuleType.Allowed : RuleType.Disallowed;
                    AddRule(new TileRule(index, GetTileIndex(west, tab), Direction.West, ti.Identifier, rt));
                }
                //East.
                if (ti.GetSelectionGroup(east) == TileSelectionGroups.Green || ti.GetSelectionGroup(east) == TileSelectionGroups.Red)
                {
                    rt = ti.GetSelectionGroup(east) == TileSelectionGroups.Green ? RuleType.Allowed : RuleType.Disallowed;
                    AddRule(new TileRule(index, GetTileIndex(east, tab), Direction.East, ti.Identifier, rt));
                }
                //North.
                if (ti.GetSelectionGroup(north) == TileSelectionGroups.Green || ti.GetSelectionGroup(north) == TileSelectionGroups.Red)
                {
                    rt = ti.GetSelectionGroup(north) == TileSelectionGroups.Green ? RuleType.Allowed : RuleType.Disallowed;
                    AddRule(new TileRule(index, GetTileIndex(north, tab), Direction.North, ti.Identifier, rt));
                }
                //South.
                if (ti.GetSelectionGroup(south) == TileSelectionGroups.Green || ti.GetSelectionGroup(south) == TileSelectionGroups.Red)
                {
                    rt = ti.GetSelectionGroup(south) == TileSelectionGroups.Green ? RuleType.Allowed : RuleType.Disallowed;
                    AddRule(new TileRule(index, GetTileIndex(south, tab), Direction.South, ti.Identifier, rt));
                }
            }
        }
        public static void CreateDefaultRules()
        {
            var ti = SourceImages[SelectedSource];
            var width = ti.Image.Width / ti.TileSize;
            var height = ti.Image.Height / ti.TileSize;

            for (int x = 0; x <= width - 1; x++)
            {
                for (int y = 0; y <= height - 1; y++)
                {
                    int index = GetTileIndex(x, y, TileTab.Source);

                    //West.
                    if (x > 0) { AddRule(new TileRule(index, index - 1, Direction.West, ti.Identifier, RuleType.Allowed)); }
                    //East.
                    if (x < width - 1) { AddRule(new TileRule(index, index + 1, Direction.East, ti.Identifier, RuleType.Allowed)); }
                    //North.
                    if (y > 0) { AddRule(new TileRule(index, index - width, Direction.North, ti.Identifier, RuleType.Allowed)); }
                    //South.
                    if (y < height - 1) { AddRule(new TileRule(index, index + width, Direction.South, ti.Identifier, RuleType.Allowed)); }
                }
            }
        }
        public static void CreateRulesFromDisallowAllBetweenGroups(TileTab tab, BackgroundWorker worker)
        {
            var ti = GetTileImage(tab);
            var group1 = ti.GetTiles();
            var group2 = ti.GetTiles(t => t.SelectionGroup == TileSelectionGroups.Green);
            var group3 = ti.GetTiles(t => t.SelectionGroup == TileSelectionGroups.Red);
            int max = group1.Count + group2.Count;
            float count = 0;

            foreach (var t1 in group1)
            {
                int index1 = GetTileIndex(t1.Index, tab);
                worker.ReportProgress((int)(100 * (count++ / max)));

                foreach (var t2 in group2)
                {
                    int index2 = GetTileIndex(t2.Index, tab);

                    //West.
                    AddRule(new TileRule(index1, index2, Direction.West, ti.Identifier, RuleType.Disallowed));
                    //East.
                    AddRule(new TileRule(index1, index2, Direction.East, ti.Identifier, RuleType.Disallowed));
                    //North.
                    AddRule(new TileRule(index1, index2, Direction.North, ti.Identifier, RuleType.Disallowed));
                    //South.
                    AddRule(new TileRule(index1, index2, Direction.South, ti.Identifier, RuleType.Disallowed));
                }
                foreach (var t3 in group3)
                {
                    int index3 = GetTileIndex(t3.Index, tab);

                    //West.
                    AddRule(new TileRule(index1, index3, Direction.West, ti.Identifier, RuleType.Disallowed));
                    //East.
                    AddRule(new TileRule(index1, index3, Direction.East, ti.Identifier, RuleType.Disallowed));
                    //North.
                    AddRule(new TileRule(index1, index3, Direction.North, ti.Identifier, RuleType.Disallowed));
                    //South.
                    AddRule(new TileRule(index1, index3, Direction.South, ti.Identifier, RuleType.Disallowed));
                }
            }
            foreach (var t2 in group2)
            {
                int index2 = GetTileIndex(t2.Index, tab);
                worker.ReportProgress((int)(100 * (count++ / max)));

                foreach (var t3 in group3)
                {
                    int index3 = GetTileIndex(t3.Index, tab);

                    //West.
                    AddRule(new TileRule(index2, index3, Direction.West, ti.Identifier, RuleType.Disallowed));
                    //East.
                    AddRule(new TileRule(index2, index3, Direction.East, ti.Identifier, RuleType.Disallowed));
                    //North.
                    AddRule(new TileRule(index2, index3, Direction.North, ti.Identifier, RuleType.Disallowed));
                    //South.
                    AddRule(new TileRule(index2, index3, Direction.South, ti.Identifier, RuleType.Disallowed));
                }
            }
        }
        public static void CreateRulesFromColorMatch(BackgroundWorker worker)
        {
            var ti = SourceImages[SelectedSource];
            var width = ti.Image.Width / ti.TileSize;
            var height = ti.Image.Height / ti.TileSize;
            var lockImg = new LockBitmap(new Bitmap(ti.Image));
            lockImg.LockBits();

            float max = width * height;
            for (int iMain = 0; iMain < width * height; iMain++)
            {
                for (int iNeighbor = 0; iNeighbor < width * height; iNeighbor++)
                {
                    //West.
                    if (Helper.IsValidNeighbors(iMain, iNeighbor, Direction.West, lockImg, ti))
                    {
                        AddRule(new TileRule(iMain, iNeighbor, Direction.West, ti.Identifier, RuleType.Allowed));
                    }
                    //East.
                    if (Helper.IsValidNeighbors(iMain, iNeighbor, Direction.East, lockImg, ti))
                    {
                        AddRule(new TileRule(iMain, iNeighbor, Direction.East, ti.Identifier, RuleType.Allowed));
                    }
                    //North.
                    if (Helper.IsValidNeighbors(iMain, iNeighbor, Direction.North, lockImg, ti))
                    {
                        AddRule(new TileRule(iMain, iNeighbor, Direction.North, ti.Identifier, RuleType.Allowed));
                    }
                    //South.
                    if (Helper.IsValidNeighbors(iMain, iNeighbor, Direction.South, lockImg, ti))
                    {
                        AddRule(new TileRule(iMain, iNeighbor, Direction.South, ti.Identifier, RuleType.Allowed));
                    }
                }

                worker.ReportProgress((int)(100 * (iMain / max)));
            }

            lockImg.UnlockBits();
        }

        public static void RefreshTileRuleTest()
        {
            //Get all selected tiles.
            var tiles = SourceImages[SelectedSource].GetTiles().Select(t => t.Index).Distinct().ToList();

            //Get neighbor tiles that have not had a rule created for them yet.
            var n = tiles.Except(PossibleNeighbors(SelectedTile, Direction.North, tiles, RuleType.Allowed)).ToList();
            n = tiles.Except(PossibleNeighbors(SelectedTile, Direction.North, tiles, RuleType.Disallowed)).ToList();
            var s = tiles.Except(PossibleNeighbors(SelectedTile, Direction.South, tiles, RuleType.Allowed)).ToList();
            s = tiles.Except(PossibleNeighbors(SelectedTile, Direction.South, tiles, RuleType.Disallowed)).ToList();
            var e = tiles.Except(PossibleNeighbors(SelectedTile, Direction.East, tiles, RuleType.Allowed)).ToList();
            e = tiles.Except(PossibleNeighbors(SelectedTile, Direction.East, tiles, RuleType.Disallowed)).ToList();
            var w = tiles.Except(PossibleNeighbors(SelectedTile, Direction.West, tiles, RuleType.Allowed)).ToList();
            w = tiles.Except(PossibleNeighbors(SelectedTile, Direction.West, tiles, RuleType.Disallowed)).ToList();

            RuleTestMap[1, 1] = SelectedTile;
            RuleTestMap[1, 0] = n.Count > 0 ? n[Random.Next(n.Count())] : -1;
            RuleTestMap[1, 2] = s.Count > 0 ? s[Random.Next(s.Count())] : -1;
            RuleTestMap[2, 1] = e.Count > 0 ? e[Random.Next(e.Count())] : -1;
            RuleTestMap[0, 1] = w.Count > 0 ? w[Random.Next(w.Count())] : -1;

            RuleTestMap[0, 0] = tiles.Count > 0 ? tiles[Random.Next(tiles.Count())] : -1;
            RuleTestMap[0, 2] = tiles.Count > 0 ? tiles[Random.Next(tiles.Count())] : -1;
            RuleTestMap[2, 0] = tiles.Count > 0 ? tiles[Random.Next(tiles.Count())] : -1;
            RuleTestMap[2, 2] = tiles.Count > 0 ? tiles[Random.Next(tiles.Count())] : -1;
        }
        public static void RandomizeMap(BackgroundWorker worker, bool fillEmptyTiles)
        {
            //Clear the map.
            for (int x = 0; x < RandomizedMap.GetLength(0); x++)
            {
                for (int y = 0; y < RandomizedMap.GetLength(1); y++)
                {
                    RandomizedMap[x, y] = -1;
                }
            }

            //Get the selected tiles.
            var tiles = new List<int>();
            foreach (var t in SourceImages[SelectedSource].GetTiles())
            {
                if (t.SelectionGroup != TileSelectionGroups.None) { tiles.Add(t.Index); }
            }
            tiles.Distinct();

            if (tiles.Count == 0) { return; }

            //Randomize the map by using the selected tiles.
            int max = RandomizedMap.GetLength(0) * RandomizedMap.GetLength(1);
            for (int y = 0; y <= RandomizedMap.GetLength(1) - 1; y++)
            {
                for (int x = 0; x <= RandomizedMap.GetLength(0) - 1; x++)
                {
                    RandomizedMap[x, y] = RandomTile(x, y, tiles, fillEmptyTiles);
                    worker.ReportProgress(100 * (RandomizedMap.GetLength(0) * y + x) / max);
                }
            }
        }
        private static int RandomTile(int x, int y, List<int> tiles, bool fillEmptyTiles)
        {
            //Get all allowed neighbors to this tile's neighbors.
            var n = PossibleNeighbors(y == 0 ? -1 : RandomizedMap[x, y - 1], Direction.South, tiles, RuleType.Allowed);
            var e = PossibleNeighbors((x + 1) == RandomizedMap.GetLength(0) ? -1 : RandomizedMap[x + 1, y], Direction.West, tiles, RuleType.Allowed);
            var s = PossibleNeighbors((y + 1) == RandomizedMap.GetLength(1) ? -1 : RandomizedMap[x, y + 1], Direction.North, tiles, RuleType.Allowed);
            var w = PossibleNeighbors(x == 0 ? -1 : RandomizedMap[x - 1, y], Direction.East, tiles, RuleType.Allowed);

            //Keep only the neighbors they have in common.
            var possibilities = n.Intersect(e).Intersect(s).Intersect(w).ToList();

            if (possibilities.Count == 0)
            {
                if (fillEmptyTiles)
                {
                    //Get all disallowed neighbors to this tile's neighbors.
                    n = PossibleNeighbors(y == 0 ? -1 : RandomizedMap[x, y - 1], Direction.South, tiles, RuleType.Disallowed);
                    e = PossibleNeighbors((x + 1) == RandomizedMap.GetLength(0) ? -1 : RandomizedMap[x + 1, y], Direction.West, tiles, RuleType.Disallowed);
                    s = PossibleNeighbors((y + 1) == RandomizedMap.GetLength(1) ? -1 : RandomizedMap[x, y + 1], Direction.North, tiles, RuleType.Disallowed);
                    w = PossibleNeighbors(x == 0 ? -1 : RandomizedMap[x - 1, y], Direction.East, tiles, RuleType.Disallowed);

                    //Keep all disallowed neighbors.
                    var all = n.Union(e).Union(s).Union(w).ToList();
                    tiles.ForEach(i => { if (!all.Contains(i)) { possibilities.Add(i); } });
                }

                if (possibilities.Count == 0) { possibilities.Add(-1); }
            }

            return possibilities[Random.Next(possibilities.Count)];
        }
        private static List<int> PossibleNeighbors(int tile, Direction dir, List<int> tiles, RuleType rt)
        {
            var possible = new List<int>();
            if (tile == -1)
            {
                if (rt == RuleType.Allowed) { possible.AddRange(tiles); }
            }
            else
            {
                if (_TileRules.ContainsKey(tile))
                {
                    foreach (var rule in _TileRules[tile])
                    {
                        //Skip rule if rule type doesn't match.
                        if (rule.Type != rt) { continue; }

                        var neighborMatch = -1;
                        if (rule.Base == tile && rule.Direction == dir) { neighborMatch = rule.Neighbor; }
                        else if (rule.Neighbor == tile && rule.Direction == TileRule.ReverseDirection(dir)) { neighborMatch = rule.Base; }
                        if (neighborMatch > -1 && tiles.Contains(neighborMatch)) { possible.Add(neighborMatch); }
                    }
                }
            }
            return possible;
        }

        public static TileImage GetTileImage(TileTab tab)
        {
            switch (tab)
            {
                case TileTab.Source: { return SourceImages[SelectedSource]; }
                case TileTab.Randomized: { return _RandomizedMapImage; }
                case TileTab.RuleTest: { return _RuleTestMapImage; }
                default: { return SourceImages[SelectedSource]; }
            }
        }
        /// <summary>
        /// The 'true' index of a tile is based on its location in the source image,
        /// so we need to convert from one tab's coordinate system to the source tab's.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int GetTileIndex(int x, int y, TileTab tab)
        {
            switch (tab)
            {
                case TileTab.Source: return SourceImages[SelectedSource].Image.Width / SourceImages[SelectedSource].TileSize * y + x;
                case TileTab.Randomized: return RandomizedMap[x, y];
                case TileTab.RuleTest: return RuleTestMap[x, y];
                default: goto case 0;
            }
        }
        public static int GetTileIndex(int index, TileTab tab)
        {
            var ti = GetTileImage(tab);
            int x = index % ti.ColumnsPerRow;
            int y = index / ti.ColumnsPerRow;

            return GetTileIndex(x, y, tab);
        }
        public static List<TileRule> GetRules()
        {
            var rules = new List<TileRule>();
            _TileRules.Values.ToList().ForEach(list => list.ForEach(item => { if (!rules.Contains(item)) { rules.Add(item); } }));
            return rules;
        }
        public static int GetWidth(TileTab tab)
        {
            return GetTileImage(tab).Image.Width;
        }
        public static int GetHeight(TileTab tab)
        {
            return GetTileImage(tab).Image.Height;
        }
        public static List<Tile> GetSelectedTiles()
        {
            return SourceImages[SelectedSource].GetTiles().Where(t => SelectedTiles.Contains(t.Index)).ToList();
        }
    }
}
