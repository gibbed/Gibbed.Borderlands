namespace Gibbed.Borderlands.SaveEdit
{
    partial class Editor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label experienceLabel;
            System.Windows.Forms.Label levelLabel;
            System.Windows.Forms.Label moneyLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label classLabel;
            System.Windows.Forms.Label backpackSizeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.newBerserkerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSirenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newHunterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.mainTabs = new System.Windows.Forms.TabControl();
            this.characterTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.backpackSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.playerSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.classNameComboBox = new System.Windows.Forms.ComboBox();
            this.levelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.moneyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.experienceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.weaponsTab = new System.Windows.Forms.TabPage();
            this.itemsTab = new System.Windows.Forms.TabPage();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            experienceLabel = new System.Windows.Forms.Label();
            levelLabel = new System.Windows.Forms.Label();
            moneyLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            classLabel = new System.Windows.Forms.Label();
            backpackSizeLabel = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.mainTabs.SuspendLayout();
            this.characterTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backpackSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.experienceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // experienceLabel
            // 
            experienceLabel.AutoSize = true;
            experienceLabel.Dock = System.Windows.Forms.DockStyle.Right;
            experienceLabel.Location = new System.Drawing.Point(22, 79);
            experienceLabel.Name = "experienceLabel";
            experienceLabel.Size = new System.Drawing.Size(63, 26);
            experienceLabel.TabIndex = 0;
            experienceLabel.Text = "Experience:";
            experienceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Dock = System.Windows.Forms.DockStyle.Right;
            levelLabel.Location = new System.Drawing.Point(49, 53);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new System.Drawing.Size(36, 26);
            levelLabel.TabIndex = 2;
            levelLabel.Text = "Level:";
            levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // moneyLabel
            // 
            moneyLabel.AutoSize = true;
            moneyLabel.Dock = System.Windows.Forms.DockStyle.Right;
            moneyLabel.Location = new System.Drawing.Point(43, 105);
            moneyLabel.Name = "moneyLabel";
            moneyLabel.Size = new System.Drawing.Size(42, 26);
            moneyLabel.TabIndex = 4;
            moneyLabel.Text = "Money:";
            moneyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Dock = System.Windows.Forms.DockStyle.Right;
            nameLabel.Location = new System.Drawing.Point(47, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 26);
            nameLabel.TabIndex = 6;
            nameLabel.Text = "Name:";
            nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // classLabel
            // 
            classLabel.AutoSize = true;
            classLabel.Dock = System.Windows.Forms.DockStyle.Right;
            classLabel.Location = new System.Drawing.Point(50, 26);
            classLabel.Name = "classLabel";
            classLabel.Size = new System.Drawing.Size(35, 27);
            classLabel.TabIndex = 8;
            classLabel.Text = "Class:";
            classLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // backpackSizeLabel
            // 
            backpackSizeLabel.AutoSize = true;
            backpackSizeLabel.Dock = System.Windows.Forms.DockStyle.Right;
            backpackSizeLabel.Location = new System.Drawing.Point(3, 131);
            backpackSizeLabel.Name = "backpackSizeLabel";
            backpackSizeLabel.Size = new System.Drawing.Size(82, 26);
            backpackSizeLabel.TabIndex = 10;
            backpackSizeLabel.Text = "Backpack Size:";
            backpackSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.saveButton,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(624, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBerserkerMenuItem,
            this.newSirenMenuItem,
            this.newHunterMenuItem,
            this.toolStripMenuItem2});
            this.newButton.Image = global::Gibbed.Borderlands.SaveEdit.Properties.Resources.New;
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(29, 22);
            this.newButton.Text = "New";
            // 
            // newBerserkerMenuItem
            // 
            this.newBerserkerMenuItem.Name = "newBerserkerMenuItem";
            this.newBerserkerMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newBerserkerMenuItem.Text = "New &Brick";
            this.newBerserkerMenuItem.Click += new System.EventHandler(this.OnNewBerserker);
            // 
            // newSirenMenuItem
            // 
            this.newSirenMenuItem.Enabled = false;
            this.newSirenMenuItem.Name = "newSirenMenuItem";
            this.newSirenMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newSirenMenuItem.Text = "New &Lilith";
            // 
            // newHunterMenuItem
            // 
            this.newHunterMenuItem.Enabled = false;
            this.newHunterMenuItem.Name = "newHunterMenuItem";
            this.newHunterMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newHunterMenuItem.Text = "New &Mordecai";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem2.Text = "New &Roland";
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = global::Gibbed.Borderlands.SaveEdit.Properties.Resources.Open;
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(23, 22);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.OnOpen);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = global::Gibbed.Borderlands.SaveEdit.Properties.Resources.Save;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.OnSave);
            // 
            // mainTabs
            // 
            this.mainTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabs.Controls.Add(this.characterTab);
            this.mainTabs.Controls.Add(this.weaponsTab);
            this.mainTabs.Controls.Add(this.itemsTab);
            this.mainTabs.Location = new System.Drawing.Point(12, 28);
            this.mainTabs.Name = "mainTabs";
            this.mainTabs.SelectedIndex = 0;
            this.mainTabs.Size = new System.Drawing.Size(600, 241);
            this.mainTabs.TabIndex = 1;
            // 
            // characterTab
            // 
            this.characterTab.AutoScroll = true;
            this.characterTab.Controls.Add(this.tableLayoutPanel1);
            this.characterTab.Location = new System.Drawing.Point(4, 22);
            this.characterTab.Name = "characterTab";
            this.characterTab.Padding = new System.Windows.Forms.Padding(3);
            this.characterTab.Size = new System.Drawing.Size(592, 215);
            this.characterTab.TabIndex = 0;
            this.characterTab.Text = "Character";
            this.characterTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(backpackSizeLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.backpackSizeNumericUpDown, 1, 5);
            this.tableLayoutPanel1.Controls.Add(nameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.classNameComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(classLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(levelLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.levelNumericUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(moneyLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(experienceLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.moneyNumericUpDown, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.experienceNumericUpDown, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(586, 209);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // backpackSizeNumericUpDown
            // 
            this.backpackSizeNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerSource, "BackpackSize", true));
            this.backpackSizeNumericUpDown.Location = new System.Drawing.Point(91, 134);
            this.backpackSizeNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.backpackSizeNumericUpDown.Name = "backpackSizeNumericUpDown";
            this.backpackSizeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.backpackSizeNumericUpDown.TabIndex = 11;
            // 
            // playerSource
            // 
            this.playerSource.DataSource = typeof(Gibbed.Borderlands.FileFormats.Player);
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(91, 3);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(121, 20);
            this.nameTextBox.TabIndex = 7;
            // 
            // classNameComboBox
            // 
            this.classNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.playerSource, "ClassName", true));
            this.classNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classNameComboBox.Items.AddRange(new object[] {
            "Berserker",
            "Hunter",
            "Siren",
            "Soldier"});
            this.classNameComboBox.Location = new System.Drawing.Point(91, 29);
            this.classNameComboBox.Name = "classNameComboBox";
            this.classNameComboBox.Size = new System.Drawing.Size(121, 21);
            this.classNameComboBox.Sorted = true;
            this.classNameComboBox.TabIndex = 9;
            // 
            // levelNumericUpDown
            // 
            this.levelNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerSource, "Level", true));
            this.levelNumericUpDown.Location = new System.Drawing.Point(91, 56);
            this.levelNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.levelNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.levelNumericUpDown.Name = "levelNumericUpDown";
            this.levelNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.levelNumericUpDown.TabIndex = 3;
            this.levelNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // moneyNumericUpDown
            // 
            this.moneyNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerSource, "Money", true));
            this.moneyNumericUpDown.Location = new System.Drawing.Point(91, 108);
            this.moneyNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.moneyNumericUpDown.Name = "moneyNumericUpDown";
            this.moneyNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.moneyNumericUpDown.TabIndex = 5;
            // 
            // experienceNumericUpDown
            // 
            this.experienceNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.playerSource, "Experience", true));
            this.experienceNumericUpDown.Location = new System.Drawing.Point(91, 82);
            this.experienceNumericUpDown.Maximum = new decimal(new int[] {
            -1000000,
            999999,
            0,
            393216});
            this.experienceNumericUpDown.Name = "experienceNumericUpDown";
            this.experienceNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.experienceNumericUpDown.TabIndex = 1;
            // 
            // weaponsTab
            // 
            this.weaponsTab.Location = new System.Drawing.Point(4, 22);
            this.weaponsTab.Name = "weaponsTab";
            this.weaponsTab.Padding = new System.Windows.Forms.Padding(3);
            this.weaponsTab.Size = new System.Drawing.Size(592, 215);
            this.weaponsTab.TabIndex = 1;
            this.weaponsTab.Text = "Weapons";
            this.weaponsTab.UseVisualStyleBackColor = true;
            // 
            // itemsTab
            // 
            this.itemsTab.Location = new System.Drawing.Point(4, 22);
            this.itemsTab.Name = "itemsTab";
            this.itemsTab.Padding = new System.Windows.Forms.Padding(3);
            this.itemsTab.Size = new System.Drawing.Size(592, 215);
            this.itemsTab.TabIndex = 2;
            this.itemsTab.Text = "Items";
            this.itemsTab.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "sav";
            this.openFileDialog.Filter = "Borderlands Saves (*.sav)|*.sav|All Files (*.*)|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Borderlands Saves (*.sav)|*.sav|All Files (*.*)|*.*";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 281);
            this.Controls.Add(this.mainTabs);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Editor";
            this.Text = "Gibbed\'s Borderlands Save Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.mainTabs.ResumeLayout(false);
            this.characterTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backpackSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.levelNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.experienceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton newButton;
        private System.Windows.Forms.ToolStripMenuItem newBerserkerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSirenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newHunterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TabControl mainTabs;
        private System.Windows.Forms.TabPage characterTab;
        private System.Windows.Forms.TabPage weaponsTab;
        private System.Windows.Forms.BindingSource playerSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown experienceNumericUpDown;
        private System.Windows.Forms.NumericUpDown levelNumericUpDown;
        private System.Windows.Forms.NumericUpDown moneyNumericUpDown;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox classNameComboBox;
        private System.Windows.Forms.TabPage itemsTab;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.NumericUpDown backpackSizeNumericUpDown;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

