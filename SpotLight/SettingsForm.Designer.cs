﻿namespace SpotLight
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.GamePathLabel = new System.Windows.Forms.Label();
            this.GamePathTextBox = new System.Windows.Forms.TextBox();
            this.GamePathButton = new System.Windows.Forms.Button();
            this.RebuildDatabaseButton = new System.Windows.Forms.Button();
            this.ObjectParameterGroupBox = new System.Windows.Forms.GroupBox();
            this.DescriptionInfoLabel = new System.Windows.Forms.Label();
            this.ClearDescriptionsButton = new System.Windows.Forms.Button();
            this.DatabaseInfoLabel = new System.Windows.Forms.Label();
            this.RenderingGroupBox = new System.Windows.Forms.GroupBox();
            this.RenderSkyboxesCheckBox = new System.Windows.Forms.CheckBox();
            this.PlayerLabel = new System.Windows.Forms.Label();
            this.PlayerComboBox = new System.Windows.Forms.ComboBox();
            this.RenderAreaCheckBox = new System.Windows.Forms.CheckBox();
            this.LoadingAndSavingGroupBox = new System.Windows.Forms.GroupBox();
            this.UniqueIDsCheckBox = new System.Windows.Forms.CheckBox();
            this.ResetSpotlightButton = new System.Windows.Forms.Button();
            this.IDEditingCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ObjectParameterGroupBox.SuspendLayout();
            this.RenderingGroupBox.SuspendLayout();
            this.LoadingAndSavingGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GamePathLabel
            // 
            this.GamePathLabel.AutoSize = true;
            this.GamePathLabel.Location = new System.Drawing.Point(12, 15);
            this.GamePathLabel.Name = "GamePathLabel";
            this.GamePathLabel.Size = new System.Drawing.Size(83, 13);
            this.GamePathLabel.TabIndex = 0;
            this.GamePathLabel.Text = "Game Directory:";
            // 
            // GamePathTextBox
            // 
            this.GamePathTextBox.Location = new System.Drawing.Point(101, 12);
            this.GamePathTextBox.Name = "GamePathTextBox";
            this.GamePathTextBox.Size = new System.Drawing.Size(336, 20);
            this.GamePathTextBox.TabIndex = 1;
            this.GamePathTextBox.Text = "3DW/Content";
            this.GamePathTextBox.TextChanged += new System.EventHandler(this.GamePathTextBox_TextChanged);
            // 
            // GamePathButton
            // 
            this.GamePathButton.Location = new System.Drawing.Point(443, 12);
            this.GamePathButton.Name = "GamePathButton";
            this.GamePathButton.Size = new System.Drawing.Size(35, 20);
            this.GamePathButton.TabIndex = 2;
            this.GamePathButton.Text = "· · ·";
            this.GamePathButton.UseVisualStyleBackColor = true;
            this.GamePathButton.Click += new System.EventHandler(this.GamePathButton_Click);
            // 
            // RebuildDatabaseButton
            // 
            this.RebuildDatabaseButton.Location = new System.Drawing.Point(6, 19);
            this.RebuildDatabaseButton.Name = "RebuildDatabaseButton";
            this.RebuildDatabaseButton.Size = new System.Drawing.Size(108, 23);
            this.RebuildDatabaseButton.TabIndex = 3;
            this.RebuildDatabaseButton.Text = "Rebuild Database";
            this.RebuildDatabaseButton.UseVisualStyleBackColor = true;
            this.RebuildDatabaseButton.Click += new System.EventHandler(this.RebuildDatabaseButton_Click);
            // 
            // ObjectParameterGroupBox
            // 
            this.ObjectParameterGroupBox.Controls.Add(this.DescriptionInfoLabel);
            this.ObjectParameterGroupBox.Controls.Add(this.ClearDescriptionsButton);
            this.ObjectParameterGroupBox.Controls.Add(this.DatabaseInfoLabel);
            this.ObjectParameterGroupBox.Controls.Add(this.RebuildDatabaseButton);
            this.ObjectParameterGroupBox.Location = new System.Drawing.Point(12, 38);
            this.ObjectParameterGroupBox.Name = "ObjectParameterGroupBox";
            this.ObjectParameterGroupBox.Size = new System.Drawing.Size(466, 78);
            this.ObjectParameterGroupBox.TabIndex = 4;
            this.ObjectParameterGroupBox.TabStop = false;
            this.ObjectParameterGroupBox.Text = "Databases";
            // 
            // DescriptionInfoLabel
            // 
            this.DescriptionInfoLabel.AutoSize = true;
            this.DescriptionInfoLabel.Location = new System.Drawing.Point(120, 53);
            this.DescriptionInfoLabel.Name = "DescriptionInfoLabel";
            this.DescriptionInfoLabel.Size = new System.Drawing.Size(341, 13);
            this.DescriptionInfoLabel.TabIndex = 6;
            this.DescriptionInfoLabel.Text = "Descriptions Last Edited on: [DATABASEGENDATE].    Version: [VER]";
            // 
            // ClearDescriptionsButton
            // 
            this.ClearDescriptionsButton.Location = new System.Drawing.Point(6, 48);
            this.ClearDescriptionsButton.Name = "ClearDescriptionsButton";
            this.ClearDescriptionsButton.Size = new System.Drawing.Size(108, 23);
            this.ClearDescriptionsButton.TabIndex = 5;
            this.ClearDescriptionsButton.Text = "Clear Descriptions";
            this.ClearDescriptionsButton.UseVisualStyleBackColor = true;
            this.ClearDescriptionsButton.Click += new System.EventHandler(this.ClearDescriptionsButton_Click);
            // 
            // DatabaseInfoLabel
            // 
            this.DatabaseInfoLabel.AutoSize = true;
            this.DatabaseInfoLabel.Location = new System.Drawing.Point(120, 24);
            this.DatabaseInfoLabel.Name = "DatabaseInfoLabel";
            this.DatabaseInfoLabel.Size = new System.Drawing.Size(319, 13);
            this.DatabaseInfoLabel.TabIndex = 4;
            this.DatabaseInfoLabel.Text = "Database Last Built on: [DATABASEGENDATE].    Version: [VER]";
            // 
            // RenderingGroupBox
            // 
            this.RenderingGroupBox.Controls.Add(this.RenderSkyboxesCheckBox);
            this.RenderingGroupBox.Controls.Add(this.PlayerLabel);
            this.RenderingGroupBox.Controls.Add(this.PlayerComboBox);
            this.RenderingGroupBox.Controls.Add(this.RenderAreaCheckBox);
            this.RenderingGroupBox.Location = new System.Drawing.Point(12, 122);
            this.RenderingGroupBox.Name = "RenderingGroupBox";
            this.RenderingGroupBox.Size = new System.Drawing.Size(466, 75);
            this.RenderingGroupBox.TabIndex = 5;
            this.RenderingGroupBox.TabStop = false;
            this.RenderingGroupBox.Text = "Rendering";
            // 
            // RenderSkyboxesCheckBox
            // 
            this.RenderSkyboxesCheckBox.AutoSize = true;
            this.RenderSkyboxesCheckBox.Checked = true;
            this.RenderSkyboxesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RenderSkyboxesCheckBox.Location = new System.Drawing.Point(103, 19);
            this.RenderSkyboxesCheckBox.Name = "RenderSkyboxesCheckBox";
            this.RenderSkyboxesCheckBox.Size = new System.Drawing.Size(110, 17);
            this.RenderSkyboxesCheckBox.TabIndex = 3;
            this.RenderSkyboxesCheckBox.Text = "Render Skyboxes";
            this.RenderSkyboxesCheckBox.UseVisualStyleBackColor = true;
            this.RenderSkyboxesCheckBox.CheckedChanged += new System.EventHandler(this.RenderSkyboxesCheckBox_CheckedChanged);
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Location = new System.Drawing.Point(6, 45);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(39, 13);
            this.PlayerLabel.TabIndex = 2;
            this.PlayerLabel.Text = "Player:";
            // 
            // PlayerComboBox
            // 
            this.PlayerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayerComboBox.FormattingEnabled = true;
            this.PlayerComboBox.Items.AddRange(new object[] {
            "None",
            "Mario",
            "Luigi",
            "Peach",
            "Toad",
            "Rosalina"});
            this.PlayerComboBox.Location = new System.Drawing.Point(51, 42);
            this.PlayerComboBox.Name = "PlayerComboBox";
            this.PlayerComboBox.Size = new System.Drawing.Size(65, 21);
            this.PlayerComboBox.TabIndex = 1;
            this.PlayerComboBox.SelectedIndexChanged += new System.EventHandler(this.PlayerComboBox_SelectedIndexChanged);
            // 
            // RenderAreaCheckBox
            // 
            this.RenderAreaCheckBox.AutoSize = true;
            this.RenderAreaCheckBox.Checked = true;
            this.RenderAreaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RenderAreaCheckBox.Location = new System.Drawing.Point(6, 19);
            this.RenderAreaCheckBox.Name = "RenderAreaCheckBox";
            this.RenderAreaCheckBox.Size = new System.Drawing.Size(91, 17);
            this.RenderAreaCheckBox.TabIndex = 0;
            this.RenderAreaCheckBox.Text = "Render Areas";
            this.RenderAreaCheckBox.UseVisualStyleBackColor = true;
            this.RenderAreaCheckBox.CheckedChanged += new System.EventHandler(this.RenderAreaCheckBox_CheckedChanged);
            // 
            // LoadingAndSavingGroupBox
            // 
            this.LoadingAndSavingGroupBox.Controls.Add(this.UniqueIDsCheckBox);
            this.LoadingAndSavingGroupBox.Location = new System.Drawing.Point(12, 203);
            this.LoadingAndSavingGroupBox.Name = "LoadingAndSavingGroupBox";
            this.LoadingAndSavingGroupBox.Size = new System.Drawing.Size(466, 57);
            this.LoadingAndSavingGroupBox.TabIndex = 6;
            this.LoadingAndSavingGroupBox.TabStop = false;
            this.LoadingAndSavingGroupBox.Text = "Loading and Saving";
            // 
            // UniqueIDsCheckBox
            // 
            this.UniqueIDsCheckBox.AutoSize = true;
            this.UniqueIDsCheckBox.Location = new System.Drawing.Point(9, 19);
            this.UniqueIDsCheckBox.Name = "UniqueIDsCheckBox";
            this.UniqueIDsCheckBox.Size = new System.Drawing.Size(428, 17);
            this.UniqueIDsCheckBox.TabIndex = 0;
            this.UniqueIDsCheckBox.Text = "Only load unique ObjectIDs (disable if objects disappear when loading a custom le" +
    "vel)";
            this.UniqueIDsCheckBox.UseVisualStyleBackColor = true;
            this.UniqueIDsCheckBox.CheckedChanged += new System.EventHandler(this.UniqueIDsCheckBox_CheckedChanged);
            // 
            // ResetSpotlightButton
            // 
            this.ResetSpotlightButton.BackColor = System.Drawing.Color.DarkRed;
            this.ResetSpotlightButton.ForeColor = System.Drawing.Color.Silver;
            this.ResetSpotlightButton.Location = new System.Drawing.Point(369, 34);
            this.ResetSpotlightButton.Name = "ResetSpotlightButton";
            this.ResetSpotlightButton.Size = new System.Drawing.Size(91, 23);
            this.ResetSpotlightButton.TabIndex = 7;
            this.ResetSpotlightButton.Text = "Reset Spotlight";
            this.ResetSpotlightButton.UseVisualStyleBackColor = false;
            this.ResetSpotlightButton.Click += new System.EventHandler(this.ResetSpotlightButton_Click);
            // 
            // IDEditingCheckBox
            // 
            this.IDEditingCheckBox.AutoSize = true;
            this.IDEditingCheckBox.Location = new System.Drawing.Point(9, 19);
            this.IDEditingCheckBox.Name = "IDEditingCheckBox";
            this.IDEditingCheckBox.Size = new System.Drawing.Size(108, 17);
            this.IDEditingCheckBox.TabIndex = 8;
            this.IDEditingCheckBox.Text = "Enable ID Editing";
            this.IDEditingCheckBox.UseVisualStyleBackColor = true;
            this.IDEditingCheckBox.CheckedChanged += new System.EventHandler(this.IDEditingCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IDEditingCheckBox);
            this.groupBox1.Controls.Add(this.ResetSpotlightButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 57);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Miscellaneous";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 413);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LoadingAndSavingGroupBox);
            this.Controls.Add(this.RenderingGroupBox);
            this.Controls.Add(this.ObjectParameterGroupBox);
            this.Controls.Add(this.GamePathButton);
            this.Controls.Add(this.GamePathTextBox);
            this.Controls.Add(this.GamePathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Spotlight - Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.ObjectParameterGroupBox.ResumeLayout(false);
            this.ObjectParameterGroupBox.PerformLayout();
            this.RenderingGroupBox.ResumeLayout(false);
            this.RenderingGroupBox.PerformLayout();
            this.LoadingAndSavingGroupBox.ResumeLayout(false);
            this.LoadingAndSavingGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GamePathLabel;
        private System.Windows.Forms.TextBox GamePathTextBox;
        private System.Windows.Forms.Button GamePathButton;
        private System.Windows.Forms.Button RebuildDatabaseButton;
        private System.Windows.Forms.GroupBox ObjectParameterGroupBox;
        private System.Windows.Forms.Label DatabaseInfoLabel;
        private System.Windows.Forms.Label DescriptionInfoLabel;
        private System.Windows.Forms.Button ClearDescriptionsButton;
        private System.Windows.Forms.GroupBox RenderingGroupBox;
        private System.Windows.Forms.CheckBox RenderAreaCheckBox;
        private System.Windows.Forms.Label PlayerLabel;
        private System.Windows.Forms.ComboBox PlayerComboBox;
        private System.Windows.Forms.CheckBox RenderSkyboxesCheckBox;
        private System.Windows.Forms.GroupBox LoadingAndSavingGroupBox;
        private System.Windows.Forms.CheckBox UniqueIDsCheckBox;
        private System.Windows.Forms.Button ResetSpotlightButton;
        private System.Windows.Forms.CheckBox IDEditingCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}