using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace StrategyGameHelper
{
    public partial class Main : Form
    {
        private bool _EnableGrid;
        private bool _FillEmptyTiles;
        private PictureBox[] _PictureBoxes;
        private TileAttributes _LastAttributeChanged;

        public Main()
        {
            InitializeComponent();

            //Source panel.
            Point pt = new Point(tbcMain.Location.X + 15, tbcMain.Location.Y + 32);
            pnlTileSource.Parent = this;
            pnlTileSource.Location = pt;
            pnlTileSource.BringToFront();
            pnlTileSource.Hide();

            //Selected tiles panel.
            pt = new Point(tbcMain.Width - 25 - pnlSelectedTiles.Width, tbcMain.Location.Y + 32);
            pnlSelectedTiles.Parent = this;
            pnlSelectedTiles.Location = pt;
            pnlSelectedTiles.BringToFront();
            pnlSelectedTiles.Hide();
            pnlSelectedTiles.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            TileHandler.Initialize();

            //Add the columns.
            lstvTileSource.Columns.Add("Path", -2, HorizontalAlignment.Left);
            lstvTileAttributes.Columns.Add("Attribute", -2, HorizontalAlignment.Left);
            ReloadSourcePanel();

            var img = TileHandler.GetTileImage(TileTab.Source).Image;
            pctbMain.Image = img;
            pctbMain.Width = img.Width;
            pctbMain.Height = img.Height;

            pctbTileTest.Image = TileHandler.GetTileImage(TileTab.Randomized).Image;
            pctbSelectedTile.Image = TileHandler.GetTileImage(TileTab.RuleTest).Image;

            _PictureBoxes = new PictureBox[3];
            _PictureBoxes[0] = pctbMain;
            _PictureBoxes[1] = pctbTileTest;
            _PictureBoxes[2] = pctbSelectedTile;
        }

        private void ReloadSourcePanel()
        {
            lstvTileSource.Items.Clear();

            foreach (var ti in TileHandler.SourceImages.FindAll(item => item.IsTileSource))
            {
                //If this item has already been added, just update it. Otherwise create it.
                ListViewItem lstvItem = lstvTileSource.Items.Count != 0 ? lstvTileSource.Items.Cast<ListViewItem>().FirstOrDefault(x => x.Tag == ti) : null;
                if (lstvItem == null)
                {
                    //Add an item.
                    lstvItem = new ListViewItem(ti.Path, 0);
                    lstvItem.Tag = ti;

                    //The data.
                    //lstvItem.SubItems.Add(item.ResourceItem.ResourceData.LastName);

                    //Add the item row to the list view.
                    lstvTileSource.Items.Add(lstvItem);
                }
                else
                {
                    //Just update what's neccessary.
                    //lstvItem.SubItems[5].Text = item.Location.ToString();
                }
            }
        }
        private void ReloadSelectedTilesPanel()
        {
            lstvTileAttributes.Items.Clear();

            foreach (var ta in TileHandler.GetAttributeCountOfSelectedTiles())
            {
                if (ta.Value == 0) { continue; }

                //If this item has already been added, just update it. Otherwise create it.
                ListViewItem lstvItem = lstvTileAttributes.Items.Count != 0 ? lstvTileAttributes.Items.Cast<ListViewItem>().FirstOrDefault(x => (TileAttributes)x.Tag == ta.Key) : null;
                if (lstvItem == null)
                {
                    //Add an item.
                    lstvItem = new ListViewItem(ta.Key.ToString() + " (" + ta.Value + "/" + TileHandler.SelectedTiles.Count + ")", 0);
                    lstvItem.Tag = ta.Key;

                    //The data.
                    //lstvItem.SubItems.Add(item.ResourceItem.ResourceData.LastName);

                    //Add the item row to the list view.
                    lstvTileAttributes.Items.Add(lstvItem);
                }
                else
                {
                    //Just update what's neccessary.
                    //lstvItem.SubItems[5].Text = item.Location.ToString();
                }
            }

            cmbTileAttribute.Items.Clear();
            cmbTileAttribute.Items.AddRange(Enum.GetValues(typeof(TileAttributes)).OfType<object>().ToArray());
        }

        private void OnMainPaint(object sender, PaintEventArgs e)
        {
            if (!_EnableGrid) { return; }

            var tileSize = TileHandler.GetTileImage((TileTab)tbcMain.SelectedIndex).TileSize;
            var pctb = (PictureBox)tbcMain.SelectedTab.Controls[0];
            var ti = TileHandler.GetTileImage((TileTab)tbcMain.SelectedIndex);

            var xStart = pctb.Width / 2 - TileHandler.GetWidth((TileTab)tbcMain.SelectedIndex) / 2;
            var yStart = pctb.Height / 2 - TileHandler.GetHeight((TileTab)tbcMain.SelectedIndex) / 2;

            Graphics g = e.Graphics;
            int xCount = ti.Image.Width / tileSize + 1;
            int yCount = ti.Image.Height / tileSize + 1;
            Pen p = new Pen(Color.Black);
            Brush red = new SolidBrush(Color.FromArgb(50, 255, 10, 10));
            Brush blue = new SolidBrush(Color.FromArgb(50, 10, 10, 255));
            Brush green = new SolidBrush(Color.FromArgb(50, 10, 255, 10));
            Brush gray = new SolidBrush(Color.FromArgb(100, 10, 10, 10));

            //Draw grid.
            for (int y = 0; y < yCount; y++) { g.DrawLine(p, xStart, yStart + y * tileSize, xStart + (xCount - 1) * tileSize, yStart + y * tileSize); }
            for (int x = 0; x < xCount; x++) { g.DrawLine(p, xStart + x * tileSize, yStart, xStart + x * tileSize, yStart + (yCount - 1) * tileSize); }

            //Draw cell groups.
            foreach (var t in ti.GetTiles())
            {
                var x = xStart + (t.Index % ti.ColumnsPerRow) * ti.TileSize;
                var y = yStart + (t.Index / ti.ColumnsPerRow) * ti.TileSize;

                if (t.SelectionGroup == TileSelectionGroups.Blue) { g.FillRectangle(blue, x, y, tileSize, tileSize); }
                else if (t.SelectionGroup == TileSelectionGroups.Green) { g.FillRectangle(green, x, y, tileSize, tileSize); }
                else if (t.SelectionGroup == TileSelectionGroups.Red) { g.FillRectangle(red, x, y, tileSize, tileSize); }

                if (TileHandler.SelectedTiles.Contains(t.Index)) { g.FillRectangle(gray, x, y, tileSize, tileSize); }
            }

            //Draw cell selections.
            foreach (var t in TileHandler.SelectedTiles)
            {
                var x = xStart + (t % ti.ColumnsPerRow) * ti.TileSize;
                var y = yStart + (t / ti.ColumnsPerRow) * ti.TileSize;

                if (TileHandler.SelectedTiles.Contains(t)) { g.FillRectangle(gray, x, y, tileSize, tileSize); }
            }
        }
        private void btnGrid_Click(object sender, EventArgs e)
        {
            _EnableGrid = !_EnableGrid;
            pctbMain.Invalidate();
            pctbTileTest.Invalidate();
            pctbSelectedTile.Invalidate();
        }
        private void OnPctbClick(object sender, MouseEventArgs e)
        {
            var pctb = (PictureBox)tbcMain.SelectedTab.Controls[0];
            var ti = TileHandler.GetTileImage((TileTab)tbcMain.SelectedIndex);
            var tileSize = ti.TileSize;
            var xStart = pctb.Width / 2 - TileHandler.GetWidth((TileTab)tbcMain.SelectedIndex) / 2;
            var yStart = pctb.Height / 2 - TileHandler.GetHeight((TileTab)tbcMain.SelectedIndex) / 2;
            int xPos = (e.X - xStart) / tileSize;
            int yPos = (e.Y - yStart) / tileSize;

            TileHandler.SelectTile(xPos, yPos, (TileTab)tbcMain.SelectedIndex, e.Clicks);

            lblSelectedTile.Text = "Selected Tile: " + TileHandler.SelectedTile;
            //Init the selected tile neighbor test.
            pctb.Invalidate();
            ReloadSelectedTilesPanel();
        }
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            TileHandler.SaveConfiguration();
        }
        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            TileHandler.LoadConfiguration();
            pctbMain.Invalidate();
        }
        private void btnRandTiles_Click(object sender, EventArgs e)
        {
            _FillEmptyTiles = ckbFillEmptyTiles.Checked;
            if (bgwRandomizeMap.IsBusy != true) { bgwRandomizeMap.RunWorkerAsync(); }
        }
        private void btnRule_Click(object sender, EventArgs e)
        {
            TileHandler.CreateRule((TileTab)tbcMain.SelectedIndex);
        }
        private void btnDefaultRules_Click(object sender, EventArgs e)
        {
            TileHandler.CreateDefaultRules();
        }
        private void bgwRandomizeMap_DoWork(object sender, DoWorkEventArgs e)
        {
            TileHandler.RandomizeMap((BackgroundWorker)sender, _FillEmptyTiles);
        }
        private void bgwRandomizeMap_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbarMain.Value = e.ProgressPercentage;
        }
        private void bgwRandomizeMap_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgbarMain.Value = 0;
            TileHandler.DrawTiles(pctbTileTest, TileTab.Randomized);
            tbcMain.SelectedIndex = 1;
        }
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            var pctb = (PictureBox)tbcMain.SelectedTab.Controls[0];
            var ti = TileHandler.GetTileImage((TileTab)tbcMain.SelectedIndex);

            if (TileHandler.SelectedTiles.Count != ti.NumberOfTiles) { TileHandler.SelectAll((TileTab)tbcMain.SelectedIndex); }
            else { TileHandler.DeselectAll((TileTab)tbcMain.SelectedIndex); }

            ReloadSelectedTilesPanel();
            pctb.Invalidate();
        }
        private void pctbMain_MouseMove(object sender, MouseEventArgs e)
        {
            var pctb = _PictureBoxes[tbcMain.SelectedIndex];
            var grid = (TileTab)tbcMain.SelectedIndex == TileTab.Randomized ? TileHandler.RandomizedMap : TileHandler.RuleTestMap;
            var xStart = pctb.Image.Width / 2 - TileHandler.GetWidth((TileTab)tbcMain.SelectedIndex) / 2;
            var yStart = pctb.Image.Height / 2 - TileHandler.GetHeight((TileTab)tbcMain.SelectedIndex) / 2;
            int xPos = (e.X - xStart) / TileHandler.TileSize;
            int yPos = (e.Y - yStart) / TileHandler.TileSize;

            if (tbcMain.SelectedIndex != 0 && (xPos >= grid.GetLength(0) || yPos >= grid.GetLength(1))) { return; }

            if (tbcMain.SelectedIndex == 0) { stlblTileId.Text = (TileHandler.GetTileIndex(xPos, yPos, (TileTab)tbcMain.SelectedIndex)).ToString(); }
            else { stlblTileId.Text = grid[xPos, yPos].ToString(); }
        }
        private void btnRefreshRuleTest_Click(object sender, EventArgs e)
        {
            TileHandler.RefreshTileRuleTest();
            TileHandler.DrawTiles(pctbSelectedTile, (TileTab)tbcMain.SelectedIndex);
        }
        private void btnToggleSourcePanel_Click(object sender, EventArgs e)
        {
            if (pnlTileSource.Visible) { pnlTileSource.Hide(); }
            else { pnlTileSource.Show(); }
        }
        private void btnToggleSelectedPanel_Click(object sender, EventArgs e)
        {
            if (pnlSelectedTiles.Visible) { pnlSelectedTiles.Hide(); }
            else { pnlSelectedTiles.Show(); ReloadSelectedTilesPanel(); }
        }
        private void lstvTileSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvTileSource.SelectedItems.Count == 0) { return; }
            TileHandler.SelectedSource = TileHandler.SourceImages.IndexOf(lstvTileSource.SelectedItems[0].Tag as TileImage);
            _PictureBoxes[0].Image = TileHandler.GetTileImage(TileTab.Source).Image;
        }
        private void bgwGuessRules_DoWork(object sender, DoWorkEventArgs e)
        {
            TileHandler.CreateRulesFromColorMatch((BackgroundWorker)sender);
        }
        private void bgwGuessRules_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbarMain.Value = e.ProgressPercentage;
        }
        private void bgwGuessRules_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgbarMain.Value = 0;
        }
        private void btnGuessRules_Click(object sender, EventArgs e)
        {
            if (bgwGuessRules.IsBusy != true) { bgwGuessRules.RunWorkerAsync(); }
        }
        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'q':
                    {
                        TileHandler.DisallowAllAroundSelected((TileTab)tbcMain.SelectedIndex);
                        _PictureBoxes[tbcMain.SelectedIndex].Invalidate();
                        break;
                    }
                case 'w':
                    {
                        _EnableGrid = !_EnableGrid;
                        pctbMain.Invalidate();
                        pctbTileTest.Invalidate();
                        pctbSelectedTile.Invalidate();
                        break;
                    }
                case 'e':
                    {
                        if (bgwDisallowGroups.IsBusy != true) { bgwDisallowGroups.RunWorkerAsync(tbcMain.SelectedIndex); }
                        break;
                    }
                case 'r':
                    {
                        TileHandler.DisallowEverythingNotAttributed((TileTab)tbcMain.SelectedIndex);
                        pctbMain.Invalidate();
                        pctbTileTest.Invalidate();
                        pctbSelectedTile.Invalidate();
                        break;
                    }
            }
        }
        private void loadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TileHandler.LoadConfiguration();
            pctbMain.Invalidate();
        }
        private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TileHandler.SaveConfiguration();
        }
        private void disallowContactBetweenSelectedGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bgwDisallowGroups.IsBusy != true) { bgwDisallowGroups.RunWorkerAsync(tbcMain.SelectedIndex); }
        }
        private void disallowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TileHandler.DisallowEverythingNotAttributed((TileTab)tbcMain.SelectedIndex);
            pctbMain.Invalidate();
            pctbTileTest.Invalidate();
            pctbSelectedTile.Invalidate();
        }
        private void bgwDisallowGroups_DoWork(object sender, DoWorkEventArgs e)
        {
            TileHandler.CreateRulesFromDisallowAllBetweenGroups((TileTab)e.Argument, (BackgroundWorker)sender);
        }
        private void bgwDisallowGroups_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbarMain.Value = e.ProgressPercentage;
        }
        private void bgwDisallowGroups_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgbarMain.Value = 0;
        }
        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            TileHandler.AddAttributeToSelectedTiles(_LastAttributeChanged);
            ReloadSelectedTilesPanel();
        }
        private void btnRemoveAttribute_Click(object sender, EventArgs e)
        {
            if (lstvTileAttributes.SelectedItems.Count == 0) { return; }
            TileHandler.RemoveAttributeFromSelectedTiles((TileAttributes)lstvTileAttributes.SelectedItems[0].Tag);
            ReloadSelectedTilesPanel();
        }
        private void cmbTileAttribute_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LastAttributeChanged = (TileAttributes)cmbTileAttribute.SelectedItem;
        }
        private void ctxitemDeselectFromAttribute_Click(object sender, EventArgs e)
        {
            if (lstvTileAttributes.SelectedItems.Count == 0) { return; }
            TileHandler.DeselectFromAttribute((TileAttributes)lstvTileAttributes.SelectedItems[0].Tag);
            ReloadSelectedTilesPanel();
            pctbMain.Invalidate();
            pctbTileTest.Invalidate();
            pctbSelectedTile.Invalidate();
        }
        private void ctxitemSelectFromAttribute_Click(object sender, EventArgs e)
        {
            if (lstvTileAttributes.SelectedItems.Count == 0) { return; }
            TileHandler.SelectFromAttribute((TileAttributes)lstvTileAttributes.SelectedItems[0].Tag);
            ReloadSelectedTilesPanel();
            pctbMain.Invalidate();
            pctbTileTest.Invalidate();
            pctbSelectedTile.Invalidate();
        }
    }
}
