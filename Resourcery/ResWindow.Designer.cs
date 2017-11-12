namespace Resourcery
{
    partial class ResWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResWindow));
            this.resorceryMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandTreeResourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseTreeResourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resorceryStatusStrip = new System.Windows.Forms.StatusStrip();
            this.resorceryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.resTreeView = new System.Windows.Forms.TreeView();
            this.resDataDisplay = new System.Windows.Forms.Panel();
            this.resorceryOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.resorceryMenuStrip.SuspendLayout();
            this.resorceryStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // resorceryMenuStrip
            // 
            this.resorceryMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.resourceMenuItem,
            this.helpMenuItem});
            this.resorceryMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.resorceryMenuStrip.Name = "resorceryMenuStrip";
            this.resorceryMenuStrip.Size = new System.Drawing.Size(434, 24);
            this.resorceryMenuStrip.TabIndex = 0;
            this.resorceryMenuStrip.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.toolStripSeparator,
            this.exitFileMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "&File";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileMenuItem.Image")));
            this.openFileMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openFileMenuItem.Text = "&Open";
            this.openFileMenuItem.Click += new System.EventHandler(this.openFileMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // exitFileMenuItem
            // 
            this.exitFileMenuItem.Name = "exitFileMenuItem";
            this.exitFileMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitFileMenuItem.Text = "E&xit";
            this.exitFileMenuItem.Click += new System.EventHandler(this.exitFileMenuItem_Click);
            // 
            // resourceMenuItem
            // 
            this.resourceMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resourceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expandTreeResourceMenuItem,
            this.collapseTreeResourceMenuItem});
            this.resourceMenuItem.Name = "resourceMenuItem";
            this.resourceMenuItem.Size = new System.Drawing.Size(67, 20);
            this.resourceMenuItem.Text = "&Resource";
            // 
            // expandTreeResourceMenuItem
            // 
            this.expandTreeResourceMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.expandTreeResourceMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("expandTreeResourceMenuItem.Image")));
            this.expandTreeResourceMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.expandTreeResourceMenuItem.Name = "expandTreeResourceMenuItem";
            this.expandTreeResourceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.expandTreeResourceMenuItem.Size = new System.Drawing.Size(186, 22);
            this.expandTreeResourceMenuItem.Text = "&Expand Tree";
            this.expandTreeResourceMenuItem.Click += new System.EventHandler(this.expandTreeResourceMenuItem_Click);
            // 
            // collapseTreeResourceMenuItem
            // 
            this.collapseTreeResourceMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.collapseTreeResourceMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("collapseTreeResourceMenuItem.Image")));
            this.collapseTreeResourceMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.collapseTreeResourceMenuItem.Name = "collapseTreeResourceMenuItem";
            this.collapseTreeResourceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.collapseTreeResourceMenuItem.Size = new System.Drawing.Size(186, 22);
            this.collapseTreeResourceMenuItem.Text = "&Collapse Tree";
            this.collapseTreeResourceMenuItem.Click += new System.EventHandler(this.collapseTreeResourceMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutHelpMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "&Help";
            // 
            // aboutHelpMenuItem
            // 
            this.aboutHelpMenuItem.Name = "aboutHelpMenuItem";
            this.aboutHelpMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutHelpMenuItem.Text = "&About...";
            this.aboutHelpMenuItem.Click += new System.EventHandler(this.aboutHelpMenuItem_Click);
            // 
            // resorceryStatusStrip
            // 
            this.resorceryStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resorceryStatusLabel});
            this.resorceryStatusStrip.Location = new System.Drawing.Point(0, 389);
            this.resorceryStatusStrip.Name = "resorceryStatusStrip";
            this.resorceryStatusStrip.Size = new System.Drawing.Size(434, 22);
            this.resorceryStatusStrip.TabIndex = 1;
            this.resorceryStatusStrip.Text = "statusStrip1";
            // 
            // resorceryStatusLabel
            // 
            this.resorceryStatusLabel.Name = "resorceryStatusLabel";
            this.resorceryStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.resTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.resDataDisplay);
            this.splitContainer1.Size = new System.Drawing.Size(434, 365);
            this.splitContainer1.SplitterDistance = 144;
            this.splitContainer1.TabIndex = 2;
            // 
            // resTreeView
            // 
            this.resTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.resTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resTreeView.Location = new System.Drawing.Point(0, 0);
            this.resTreeView.Name = "resTreeView";
            this.resTreeView.Size = new System.Drawing.Size(144, 365);
            this.resTreeView.TabIndex = 0;
            // 
            // resDataDisplay
            // 
            this.resDataDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.resDataDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resDataDisplay.Location = new System.Drawing.Point(0, 0);
            this.resDataDisplay.Name = "resDataDisplay";
            this.resDataDisplay.Size = new System.Drawing.Size(286, 365);
            this.resDataDisplay.TabIndex = 0;
            // 
            // resorceryOpenFileDialog
            // 
            this.resorceryOpenFileDialog.FileName = "openFileDialog1";
            // 
            // ResWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.resorceryStatusStrip);
            this.Controls.Add(this.resorceryMenuStrip);
            this.MainMenuStrip = this.resorceryMenuStrip;
            this.Name = "ResWindow";
            this.Text = "Resourcery";
            this.resorceryMenuStrip.ResumeLayout(false);
            this.resorceryMenuStrip.PerformLayout();
            this.resorceryStatusStrip.ResumeLayout(false);
            this.resorceryStatusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip resorceryMenuStrip;
        private System.Windows.Forms.StatusStrip resorceryStatusStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView resTreeView;
        private System.Windows.Forms.Panel resDataDisplay;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandTreeResourceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseTreeResourceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHelpMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel resorceryStatusLabel;
        private System.Windows.Forms.OpenFileDialog resorceryOpenFileDialog;
    }
}

