
using Emu8086_IOGUI_Csharp;
using System;
using System.Windows.Forms;

namespace Emu8086_IOGUI_Csharp
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonLoadIO = new System.Windows.Forms.Button();
            this.buttonLoadCfg = new System.Windows.Forms.Button();
            this.buttonSaveCfg = new System.Windows.Forms.Button();
            this.buttonSetBg = new System.Windows.Forms.Button();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            this.dataGridViewPorts = new System.Windows.Forms.DataGridView();
            this.PortID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortSet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PortReset = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialogIO = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogLoad = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSave = new System.Windows.Forms.OpenFileDialog();
            this.timerUpdatePorts = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogBg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSaveCfg = new System.Windows.Forms.SaveFileDialog();
            this.buttonLoadDemo = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelCurrentMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPorts)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadIO
            // 
            this.buttonLoadIO.Location = new System.Drawing.Point(6, 6);
            this.buttonLoadIO.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonLoadIO.Name = "buttonLoadIO";
            this.buttonLoadIO.Size = new System.Drawing.Size(81, 22);
            this.buttonLoadIO.TabIndex = 0;
            this.buttonLoadIO.Text = "Load IO File";
            this.buttonLoadIO.UseVisualStyleBackColor = true;
            this.buttonLoadIO.Click += new System.EventHandler(this.ButtonLoadIO_Click);
            // 
            // buttonLoadCfg
            // 
            this.buttonLoadCfg.Location = new System.Drawing.Point(330, 6);
            this.buttonLoadCfg.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonLoadCfg.Name = "buttonLoadCfg";
            this.buttonLoadCfg.Size = new System.Drawing.Size(123, 22);
            this.buttonLoadCfg.TabIndex = 1;
            this.buttonLoadCfg.Text = "Load Configuration";
            this.buttonLoadCfg.UseVisualStyleBackColor = true;
            this.buttonLoadCfg.Click += new System.EventHandler(this.ButtonLoadCfg_Click);
            // 
            // buttonSaveCfg
            // 
            this.buttonSaveCfg.Location = new System.Drawing.Point(203, 6);
            this.buttonSaveCfg.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSaveCfg.Name = "buttonSaveCfg";
            this.buttonSaveCfg.Size = new System.Drawing.Size(123, 22);
            this.buttonSaveCfg.TabIndex = 2;
            this.buttonSaveCfg.Text = "Save Configuration";
            this.buttonSaveCfg.UseVisualStyleBackColor = true;
            this.buttonSaveCfg.Click += new System.EventHandler(this.ButtonSaveCfg_Click);
            // 
            // buttonSetBg
            // 
            this.buttonSetBg.Location = new System.Drawing.Point(91, 6);
            this.buttonSetBg.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSetBg.Name = "buttonSetBg";
            this.buttonSetBg.Size = new System.Drawing.Size(108, 22);
            this.buttonSetBg.TabIndex = 4;
            this.buttonSetBg.Text = "Set Background";
            this.buttonSetBg.UseVisualStyleBackColor = true;
            this.buttonSetBg.Click += new System.EventHandler(this.ButtonSetBg_Click);
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBackground.Location = new System.Drawing.Point(6, 31);
            this.pictureBoxBackground.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(405, 320);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackground.TabIndex = 7;
            this.pictureBoxBackground.TabStop = false;
            // 
            // dataGridViewPorts
            // 
            this.dataGridViewPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPorts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PortID,
            this.PortValue,
            this.PortX,
            this.PortY,
            this.PortSet,
            this.PortReset,
            this.PortName});
            this.dataGridViewPorts.Location = new System.Drawing.Point(419, 31);
            this.dataGridViewPorts.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridViewPorts.Name = "dataGridViewPorts";
            this.dataGridViewPorts.RowHeadersWidth = 82;
            this.dataGridViewPorts.RowTemplate.Height = 41;
            this.dataGridViewPorts.Size = new System.Drawing.Size(578, 319);
            this.dataGridViewPorts.TabIndex = 8;
            this.dataGridViewPorts.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridViewPorts_CellBeginEdit);
            this.dataGridViewPorts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPorts_CellClick);
            this.dataGridViewPorts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPorts_CellEndEdit);
            // 
            // PortID
            // 
            this.PortID.HeaderText = "PortID";
            this.PortID.MinimumWidth = 10;
            this.PortID.Name = "PortID";
            this.PortID.Width = 64;
            // 
            // PortValue
            // 
            this.PortValue.HeaderText = "Value";
            this.PortValue.MinimumWidth = 10;
            this.PortValue.Name = "PortValue";
            this.PortValue.ReadOnly = true;
            this.PortValue.Width = 128;
            // 
            // PortX
            // 
            this.PortX.HeaderText = "X";
            this.PortX.MinimumWidth = 10;
            this.PortX.Name = "PortX";
            this.PortX.Width = 64;
            // 
            // PortY
            // 
            this.PortY.HeaderText = "Y";
            this.PortY.MinimumWidth = 10;
            this.PortY.Name = "PortY";
            this.PortY.Width = 64;
            // 
            // PortSet
            // 
            this.PortSet.HeaderText = "S";
            this.PortSet.MinimumWidth = 10;
            this.PortSet.Name = "PortSet";
            this.PortSet.Width = 24;
            // 
            // PortReset
            // 
            this.PortReset.HeaderText = "R";
            this.PortReset.MinimumWidth = 10;
            this.PortReset.Name = "PortReset";
            this.PortReset.Width = 24;
            // 
            // PortName
            // 
            this.PortName.HeaderText = "Name";
            this.PortName.MinimumWidth = 10;
            this.PortName.Name = "PortName";
            this.PortName.Width = 120;
            // 
            // openFileDialogIO
            // 
            this.openFileDialogIO.FileName = "emu8086";
            this.openFileDialogIO.Filter = "io (*.io)|*.io";
            // 
            // openFileDialogLoad
            // 
            this.openFileDialogLoad.FileName = "openFileDialog1";
            // 
            // openFileDialogSave
            // 
            this.openFileDialogSave.FileName = "openFileDialogSave";
            // 
            // timerUpdatePorts
            // 
            this.timerUpdatePorts.Enabled = true;
            this.timerUpdatePorts.Tick += new System.EventHandler(this.Timer_UpdatePorts);
            // 
            // openFileDialogBg
            // 
            this.openFileDialogBg.Filter = "png (*.png)|*.png";
            // 
            // buttonLoadDemo
            // 
            this.buttonLoadDemo.Location = new System.Drawing.Point(457, 6);
            this.buttonLoadDemo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonLoadDemo.Name = "buttonLoadDemo";
            this.buttonLoadDemo.Size = new System.Drawing.Size(79, 22);
            this.buttonLoadDemo.TabIndex = 9;
            this.buttonLoadDemo.Text = "Load Demo";
            this.buttonLoadDemo.UseVisualStyleBackColor = true;
            this.buttonLoadDemo.Click += new System.EventHandler(this.ButtonLoadDemo_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelInfo.Location = new System.Drawing.Point(695, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 15);
            this.labelInfo.TabIndex = 10;
            // 
            // labelCurrentMode
            // 
            this.labelCurrentMode.AutoSize = true;
            this.labelCurrentMode.Location = new System.Drawing.Point(541, 9);
            this.labelCurrentMode.Name = "labelCurrentMode";
            this.labelCurrentMode.Size = new System.Drawing.Size(0, 15);
            this.labelCurrentMode.TabIndex = 11;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 361);
            this.Controls.Add(this.labelCurrentMode);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonLoadDemo);
            this.Controls.Add(this.dataGridViewPorts);
            this.Controls.Add(this.pictureBoxBackground);
            this.Controls.Add(this.buttonSetBg);
            this.Controls.Add(this.buttonSaveCfg);
            this.Controls.Add(this.buttonLoadCfg);
            this.Controls.Add(this.buttonLoadIO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "Emu8086 IO GUI";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPorts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadIO;
        private System.Windows.Forms.Button buttonLoadCfg;
        private System.Windows.Forms.Button buttonSaveCfg;
        private System.Windows.Forms.Button buttonSetBg;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
        private System.Windows.Forms.DataGridView dataGridViewPorts;
        private System.Windows.Forms.OpenFileDialog openFileDialogIO;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialogSave;
        private System.Windows.Forms.Timer timerUpdatePorts;
        private OpenFileDialog openFileDialogBg;
        private SaveFileDialog saveFileDialogSaveCfg;
        private DataGridViewTextBoxColumn PortID;
        private DataGridViewTextBoxColumn PortValue;
        private DataGridViewTextBoxColumn PortX;
        private DataGridViewTextBoxColumn PortY;
        private DataGridViewButtonColumn PortSet;
        private DataGridViewButtonColumn PortReset;
        private DataGridViewTextBoxColumn PortName;
        private Button buttonLoadDemo;
        private Label labelInfo;
        private Label labelCurrentMode;
    }
}

