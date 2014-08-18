namespace StrategyGameHelper
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGrid = new System.Windows.Forms.Button();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabTileSource = new System.Windows.Forms.TabPage();
            this.pnlTileSource = new System.Windows.Forms.Panel();
            this.grpbTileSource = new System.Windows.Forms.GroupBox();
            this.lstvTileSource = new System.Windows.Forms.ListView();
            this.pctbMain = new System.Windows.Forms.PictureBox();
            this.tabRandomizedMap = new System.Windows.Forms.TabPage();
            this.pctbTileTest = new System.Windows.Forms.PictureBox();
            this.tabSelectedTile = new System.Windows.Forms.TabPage();
            this.pctbSelectedTile = new System.Windows.Forms.PictureBox();
            this.btnRandTiles = new System.Windows.Forms.Button();
            this.btnRule = new System.Windows.Forms.Button();
            this.btnDefaultRules = new System.Windows.Forms.Button();
            this.bgwRandomizeMap = new System.ComponentModel.BackgroundWorker();
            this.stspMain = new System.Windows.Forms.StatusStrip();
            this.pgbarMain = new System.Windows.Forms.ToolStripProgressBar();
            this.stlblTileId = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lblSelectedTile = new System.Windows.Forms.Label();
            this.ckbFillEmptyTiles = new System.Windows.Forms.CheckBox();
            this.btnRefreshRuleTest = new System.Windows.Forms.Button();
            this.btnToggleSourcePanel = new System.Windows.Forms.Button();
            this.bgwGuessRules = new System.ComponentModel.BackgroundWorker();
            this.btnGuessRules = new System.Windows.Forms.Button();
            this.ckbFlipButtons = new System.Windows.Forms.CheckBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disallowContactBetweenSelectedGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disallowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwDisallowGroups = new System.ComponentModel.BackgroundWorker();
            this.tbcMain.SuspendLayout();
            this.tabTileSource.SuspendLayout();
            this.pnlTileSource.SuspendLayout();
            this.grpbTileSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbMain)).BeginInit();
            this.tabRandomizedMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbTileTest)).BeginInit();
            this.tabSelectedTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbSelectedTile)).BeginInit();
            this.stspMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrid
            // 
            this.btnGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGrid.Location = new System.Drawing.Point(112, 694);
            this.btnGrid.Name = "btnGrid";
            this.btnGrid.Size = new System.Drawing.Size(75, 23);
            this.btnGrid.TabIndex = 1;
            this.btnGrid.Text = "Toggle Grid";
            this.btnGrid.UseVisualStyleBackColor = true;
            this.btnGrid.Click += new System.EventHandler(this.btnGrid_Click);
            // 
            // tbcMain
            // 
            this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMain.Controls.Add(this.tabTileSource);
            this.tbcMain.Controls.Add(this.tabRandomizedMap);
            this.tbcMain.Controls.Add(this.tabSelectedTile);
            this.tbcMain.Location = new System.Drawing.Point(2, 27);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1208, 665);
            this.tbcMain.TabIndex = 2;
            // 
            // tabTileSource
            // 
            this.tabTileSource.AutoScroll = true;
            this.tabTileSource.Controls.Add(this.pnlTileSource);
            this.tabTileSource.Controls.Add(this.pctbMain);
            this.tabTileSource.Location = new System.Drawing.Point(4, 22);
            this.tabTileSource.Name = "tabTileSource";
            this.tabTileSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabTileSource.Size = new System.Drawing.Size(1200, 639);
            this.tabTileSource.TabIndex = 1;
            this.tabTileSource.Text = "Tile Source";
            this.tabTileSource.UseVisualStyleBackColor = true;
            // 
            // pnlTileSource
            // 
            this.pnlTileSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTileSource.Controls.Add(this.grpbTileSource);
            this.pnlTileSource.Location = new System.Drawing.Point(6, 6);
            this.pnlTileSource.Name = "pnlTileSource";
            this.pnlTileSource.Size = new System.Drawing.Size(219, 499);
            this.pnlTileSource.TabIndex = 2;
            // 
            // grpbTileSource
            // 
            this.grpbTileSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbTileSource.Controls.Add(this.lstvTileSource);
            this.grpbTileSource.Location = new System.Drawing.Point(3, 3);
            this.grpbTileSource.Name = "grpbTileSource";
            this.grpbTileSource.Size = new System.Drawing.Size(211, 491);
            this.grpbTileSource.TabIndex = 0;
            this.grpbTileSource.TabStop = false;
            this.grpbTileSource.Text = "Source Images";
            // 
            // lstvTileSource
            // 
            this.lstvTileSource.GridLines = true;
            this.lstvTileSource.Location = new System.Drawing.Point(6, 19);
            this.lstvTileSource.Name = "lstvTileSource";
            this.lstvTileSource.Size = new System.Drawing.Size(199, 466);
            this.lstvTileSource.TabIndex = 0;
            this.lstvTileSource.UseCompatibleStateImageBehavior = false;
            this.lstvTileSource.View = System.Windows.Forms.View.Details;
            this.lstvTileSource.SelectedIndexChanged += new System.EventHandler(this.lstvTileSource_SelectedIndexChanged);
            // 
            // pctbMain
            // 
            this.pctbMain.Location = new System.Drawing.Point(3, 3);
            this.pctbMain.Name = "pctbMain";
            this.pctbMain.Size = new System.Drawing.Size(764, 513);
            this.pctbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctbMain.TabIndex = 1;
            this.pctbMain.TabStop = false;
            this.pctbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMainPaint);
            this.pctbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnPctbClick);
            this.pctbMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnPctbClick);
            this.pctbMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctbMain_MouseMove);
            // 
            // tabRandomizedMap
            // 
            this.tabRandomizedMap.AutoScroll = true;
            this.tabRandomizedMap.Controls.Add(this.pctbTileTest);
            this.tabRandomizedMap.Location = new System.Drawing.Point(4, 22);
            this.tabRandomizedMap.Name = "tabRandomizedMap";
            this.tabRandomizedMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabRandomizedMap.Size = new System.Drawing.Size(1200, 639);
            this.tabRandomizedMap.TabIndex = 0;
            this.tabRandomizedMap.Text = "Randomized Map";
            this.tabRandomizedMap.UseVisualStyleBackColor = true;
            // 
            // pctbTileTest
            // 
            this.pctbTileTest.Location = new System.Drawing.Point(3, 3);
            this.pctbTileTest.Name = "pctbTileTest";
            this.pctbTileTest.Size = new System.Drawing.Size(1050, 658);
            this.pctbTileTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pctbTileTest.TabIndex = 0;
            this.pctbTileTest.TabStop = false;
            this.pctbTileTest.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMainPaint);
            this.pctbTileTest.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnPctbClick);
            this.pctbTileTest.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnPctbClick);
            this.pctbTileTest.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctbMain_MouseMove);
            // 
            // tabSelectedTile
            // 
            this.tabSelectedTile.Controls.Add(this.pctbSelectedTile);
            this.tabSelectedTile.Location = new System.Drawing.Point(4, 22);
            this.tabSelectedTile.Name = "tabSelectedTile";
            this.tabSelectedTile.Size = new System.Drawing.Size(1200, 639);
            this.tabSelectedTile.TabIndex = 2;
            this.tabSelectedTile.Text = "Selected Tile";
            this.tabSelectedTile.UseVisualStyleBackColor = true;
            // 
            // pctbSelectedTile
            // 
            this.pctbSelectedTile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctbSelectedTile.Location = new System.Drawing.Point(3, 3);
            this.pctbSelectedTile.Name = "pctbSelectedTile";
            this.pctbSelectedTile.Size = new System.Drawing.Size(1050, 658);
            this.pctbSelectedTile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctbSelectedTile.TabIndex = 1;
            this.pctbSelectedTile.TabStop = false;
            this.pctbSelectedTile.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMainPaint);
            this.pctbSelectedTile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnPctbClick);
            this.pctbSelectedTile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnPctbClick);
            this.pctbSelectedTile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctbMain_MouseMove);
            // 
            // btnRandTiles
            // 
            this.btnRandTiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRandTiles.Location = new System.Drawing.Point(303, 694);
            this.btnRandTiles.Name = "btnRandTiles";
            this.btnRandTiles.Size = new System.Drawing.Size(75, 23);
            this.btnRandTiles.TabIndex = 4;
            this.btnRandTiles.Text = "Randomize";
            this.btnRandTiles.UseVisualStyleBackColor = true;
            this.btnRandTiles.Click += new System.EventHandler(this.btnRandTiles_Click);
            // 
            // btnRule
            // 
            this.btnRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRule.Location = new System.Drawing.Point(835, 694);
            this.btnRule.Name = "btnRule";
            this.btnRule.Size = new System.Drawing.Size(75, 23);
            this.btnRule.TabIndex = 5;
            this.btnRule.Text = "Create Rule";
            this.btnRule.UseVisualStyleBackColor = true;
            this.btnRule.Click += new System.EventHandler(this.btnRule_Click);
            // 
            // btnDefaultRules
            // 
            this.btnDefaultRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefaultRules.Location = new System.Drawing.Point(1127, 694);
            this.btnDefaultRules.Name = "btnDefaultRules";
            this.btnDefaultRules.Size = new System.Drawing.Size(79, 23);
            this.btnDefaultRules.TabIndex = 7;
            this.btnDefaultRules.Text = "Default Rules";
            this.btnDefaultRules.UseVisualStyleBackColor = true;
            this.btnDefaultRules.Click += new System.EventHandler(this.btnDefaultRules_Click);
            // 
            // bgwRandomizeMap
            // 
            this.bgwRandomizeMap.WorkerReportsProgress = true;
            this.bgwRandomizeMap.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRandomizeMap_DoWork);
            this.bgwRandomizeMap.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwRandomizeMap_ProgressChanged);
            this.bgwRandomizeMap.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRandomizeMap_RunWorkerCompleted);
            // 
            // stspMain
            // 
            this.stspMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgbarMain,
            this.stlblTileId});
            this.stspMain.Location = new System.Drawing.Point(0, 720);
            this.stspMain.Name = "stspMain";
            this.stspMain.Size = new System.Drawing.Size(1208, 22);
            this.stspMain.TabIndex = 8;
            this.stspMain.Text = "statusStrip1";
            // 
            // pgbarMain
            // 
            this.pgbarMain.Name = "pgbarMain";
            this.pgbarMain.Size = new System.Drawing.Size(100, 16);
            // 
            // stlblTileId
            // 
            this.stlblTileId.Name = "stlblTileId";
            this.stlblTileId.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(193, 694);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 9;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lblSelectedTile
            // 
            this.lblSelectedTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedTile.Location = new System.Drawing.Point(1059, 725);
            this.lblSelectedTile.Name = "lblSelectedTile";
            this.lblSelectedTile.Size = new System.Drawing.Size(137, 13);
            this.lblSelectedTile.TabIndex = 0;
            this.lblSelectedTile.Text = "Selected Tile:";
            // 
            // ckbFillEmptyTiles
            // 
            this.ckbFillEmptyTiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckbFillEmptyTiles.AutoSize = true;
            this.ckbFillEmptyTiles.Location = new System.Drawing.Point(384, 698);
            this.ckbFillEmptyTiles.Name = "ckbFillEmptyTiles";
            this.ckbFillEmptyTiles.Size = new System.Drawing.Size(96, 17);
            this.ckbFillEmptyTiles.TabIndex = 10;
            this.ckbFillEmptyTiles.Text = "Fill empty tiles?";
            this.ckbFillEmptyTiles.UseVisualStyleBackColor = true;
            // 
            // btnRefreshRuleTest
            // 
            this.btnRefreshRuleTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshRuleTest.Location = new System.Drawing.Point(727, 694);
            this.btnRefreshRuleTest.Name = "btnRefreshRuleTest";
            this.btnRefreshRuleTest.Size = new System.Drawing.Size(102, 23);
            this.btnRefreshRuleTest.TabIndex = 11;
            this.btnRefreshRuleTest.Text = "Refresh Rule Test";
            this.btnRefreshRuleTest.UseVisualStyleBackColor = true;
            this.btnRefreshRuleTest.Click += new System.EventHandler(this.btnRefreshRuleTest_Click);
            // 
            // btnToggleSourcePanel
            // 
            this.btnToggleSourcePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToggleSourcePanel.Location = new System.Drawing.Point(6, 694);
            this.btnToggleSourcePanel.Name = "btnToggleSourcePanel";
            this.btnToggleSourcePanel.Size = new System.Drawing.Size(78, 23);
            this.btnToggleSourcePanel.TabIndex = 12;
            this.btnToggleSourcePanel.Text = "Toggle Panel";
            this.btnToggleSourcePanel.UseVisualStyleBackColor = true;
            this.btnToggleSourcePanel.Click += new System.EventHandler(this.btnToggleSourcePanel_Click);
            // 
            // bgwGuessRules
            // 
            this.bgwGuessRules.WorkerReportsProgress = true;
            this.bgwGuessRules.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGuessRules_DoWork);
            this.bgwGuessRules.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwGuessRules_ProgressChanged);
            this.bgwGuessRules.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGuessRules_RunWorkerCompleted);
            // 
            // btnGuessRules
            // 
            this.btnGuessRules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuessRules.Location = new System.Drawing.Point(1042, 694);
            this.btnGuessRules.Name = "btnGuessRules";
            this.btnGuessRules.Size = new System.Drawing.Size(79, 23);
            this.btnGuessRules.TabIndex = 13;
            this.btnGuessRules.Text = "Guess Rules";
            this.btnGuessRules.UseVisualStyleBackColor = true;
            this.btnGuessRules.Click += new System.EventHandler(this.btnGuessRules_Click);
            // 
            // ckbFlipButtons
            // 
            this.ckbFlipButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbFlipButtons.AutoSize = true;
            this.ckbFlipButtons.Location = new System.Drawing.Point(916, 698);
            this.ckbFlipButtons.Name = "ckbFlipButtons";
            this.ckbFlipButtons.Size = new System.Drawing.Size(104, 17);
            this.ckbFlipButtons.TabIndex = 14;
            this.ckbFlipButtons.Text = "Flip Right Button";
            this.ckbFlipButtons.UseVisualStyleBackColor = true;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.rulesToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1208, 24);
            this.mnuMain.TabIndex = 15;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadConfigurationToolStripMenuItem,
            this.saveConfigurationToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadConfigurationToolStripMenuItem
            // 
            this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.loadConfigurationToolStripMenuItem.Text = "Load Configuration";
            this.loadConfigurationToolStripMenuItem.Click += new System.EventHandler(this.loadConfigurationToolStripMenuItem_Click);
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveConfigurationToolStripMenuItem.Text = "Save Configuration";
            this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disallowToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disallowContactBetweenSelectedGroupsToolStripMenuItem});
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.rulesToolStripMenuItem.Text = "Rules";
            // 
            // disallowContactBetweenSelectedGroupsToolStripMenuItem
            // 
            this.disallowContactBetweenSelectedGroupsToolStripMenuItem.Name = "disallowContactBetweenSelectedGroupsToolStripMenuItem";
            this.disallowContactBetweenSelectedGroupsToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.disallowContactBetweenSelectedGroupsToolStripMenuItem.Text = "Disallow contact between selected groups (e)";
            this.disallowContactBetweenSelectedGroupsToolStripMenuItem.Click += new System.EventHandler(this.disallowContactBetweenSelectedGroupsToolStripMenuItem_Click);
            // 
            // disallowToolStripMenuItem
            // 
            this.disallowToolStripMenuItem.Name = "disallowToolStripMenuItem";
            this.disallowToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.disallowToolStripMenuItem.Text = "Disallow \"blank\" tiles (r)";
            this.disallowToolStripMenuItem.Click += new System.EventHandler(this.disallowToolStripMenuItem_Click);
            // 
            // bgwDisallowGroups
            // 
            this.bgwDisallowGroups.WorkerReportsProgress = true;
            this.bgwDisallowGroups.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDisallowGroups_DoWork);
            this.bgwDisallowGroups.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDisallowGroups_ProgressChanged);
            this.bgwDisallowGroups.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDisallowGroups_RunWorkerCompleted);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 742);
            this.Controls.Add(this.ckbFlipButtons);
            this.Controls.Add(this.btnGuessRules);
            this.Controls.Add(this.btnToggleSourcePanel);
            this.Controls.Add(this.btnRefreshRuleTest);
            this.Controls.Add(this.ckbFillEmptyTiles);
            this.Controls.Add(this.lblSelectedTile);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.stspMain);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.btnDefaultRules);
            this.Controls.Add(this.btnRule);
            this.Controls.Add(this.btnRandTiles);
            this.Controls.Add(this.btnGrid);
            this.Controls.Add(this.tbcMain);
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "Strategy Game Helper";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Main_KeyPress);
            this.tbcMain.ResumeLayout(false);
            this.tabTileSource.ResumeLayout(false);
            this.tabTileSource.PerformLayout();
            this.pnlTileSource.ResumeLayout(false);
            this.grpbTileSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctbMain)).EndInit();
            this.tabRandomizedMap.ResumeLayout(false);
            this.tabRandomizedMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbTileTest)).EndInit();
            this.tabSelectedTile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctbSelectedTile)).EndInit();
            this.stspMain.ResumeLayout(false);
            this.stspMain.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnGrid;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabRandomizedMap;
        private System.Windows.Forms.TabPage tabTileSource;
        private System.Windows.Forms.PictureBox pctbMain;
        private System.Windows.Forms.PictureBox pctbTileTest;
        private System.Windows.Forms.Button btnRandTiles;
        private System.Windows.Forms.Button btnRule;
        private System.Windows.Forms.Button btnDefaultRules;
        private System.ComponentModel.BackgroundWorker bgwRandomizeMap;
        private System.Windows.Forms.StatusStrip stspMain;
        private System.Windows.Forms.ToolStripProgressBar pgbarMain;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.TabPage tabSelectedTile;
        private System.Windows.Forms.Label lblSelectedTile;
        private System.Windows.Forms.PictureBox pctbSelectedTile;
        private System.Windows.Forms.CheckBox ckbFillEmptyTiles;
        private System.Windows.Forms.ToolStripStatusLabel stlblTileId;
        private System.Windows.Forms.Button btnRefreshRuleTest;
        private System.Windows.Forms.Panel pnlTileSource;
        private System.Windows.Forms.Button btnToggleSourcePanel;
        private System.Windows.Forms.GroupBox grpbTileSource;
        private System.Windows.Forms.ListView lstvTileSource;
        private System.ComponentModel.BackgroundWorker bgwGuessRules;
        private System.Windows.Forms.Button btnGuessRules;
        private System.Windows.Forms.CheckBox ckbFlipButtons;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disallowContactBetweenSelectedGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disallowToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgwDisallowGroups;
    }
}

