using Emu8086_IOGUI_Csharp.Interfaces;
using Emu8086_IOGUI_Csharp.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emu8086_IOGUI_Csharp
{
    internal partial class FormMain : Form
    {
        private readonly FormLogic formLogic;

        internal FormMain()
        {
            InitializeComponent();
            formLogic = new FormLogic(this);
        }





        #region Event Handlers
        //Top Row Clicks
        private void ButtonLoadIO_Click(object sender, EventArgs e) => formLogic.LoadIOFile();
        private void ButtonSetBg_Click(object sender, EventArgs e) => formLogic.SetBackground();
        private void ButtonSaveCfg_Click(object sender, EventArgs e) => formLogic.SaveConfiguration();
        private void ButtonLoadCfg_Click(object sender, EventArgs e) => formLogic.LoadConfiguration<EmulationRepository>();
        private void ButtonLoadDemo_Click(object sender, EventArgs e) => formLogic.LoadConfiguration<SimulationRepository>();

        //DataGridView Interaction
        private void DataGridViewPorts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) => formLogic.CellBeginEdit();
        private void DataGridViewPorts_CellEndEdit(object sender, DataGridViewCellEventArgs e) => formLogic.CellEndEdit(e);
        private void DataGridViewPorts_CellClick(object sender, DataGridViewCellEventArgs e) => formLogic.CellClick(e);

        //Timer Ticks
        private async void Timer_UpdatePorts(object sender, EventArgs e) => await formLogic.UpdateValuesAsync();
        #endregion





        #region Form Accessors
        //Form
        internal void SetTitle() => this.Text = "Emu8086 IO GUI - " + Settings.Filepath;

        //Controls
        internal Control GetVisual(string key) => Controls.Find(key, false).FirstOrDefault();
        internal IEnumerable<Control> GetVisuals() => Controls.OfType<Button>().Where(visual => visual.Name.StartsWith("visual"));
        internal bool VisualExists(string key) => Controls.ContainsKey(key);
        internal void AddVisual(Button newVisual) => Controls.Add(newVisual);
        internal void RemoveVisual(Button delVisual) => Controls.Remove(delVisual);

        //Filepicker Dialog
        internal DialogResult LoadFile(OpenFileDialog openFileDialog) => openFileDialog.ShowDialog();
        internal DialogResult LoadIOFile() => LoadFile(openFileDialogIO);
        internal DialogResult LoadBgFile() => LoadFile(openFileDialogBg);
        internal DialogResult LoadConfigFile() => LoadFile(openFileDialogLoad);
        internal DialogResult SaveConfigFile() => saveFileDialogSaveCfg.ShowDialog();
        

        //Filepicker Filename
        internal string GetFilename(OpenFileDialog openFileDialog) => openFileDialog.FileName;
        internal string GetIOFilename() => GetFilename(openFileDialogIO);
        internal string GetBgFilename() => GetFilename(openFileDialogBg);
        internal string GetLoadConfigFilename() => GetFilename(openFileDialogLoad);
        internal string GetSaveConfigFilename() => saveFileDialogSaveCfg.FileName;

        //Top Bar Misc
        internal void SetCurrentMode(string mode) => labelCurrentMode.Text = mode;
        internal void SetLegend(string legend) => labelInfo.Text = legend;

        //PictureBox
        internal void SetBackground() => pictureBoxBackground.ImageLocation = Settings.Background;
        internal void PushBackgroud() => pictureBoxBackground.SendToBack();

        //DataGridView
        internal void DGVClearDataSource() => dataGridViewPorts.DataSource = null;
        internal void DGVClearRows() => dataGridViewPorts.Rows.Clear();
        internal void DGVAddRow(params object[] values) => dataGridViewPorts.Rows.Add(values);
        internal void DGVEnableAdding() => dataGridViewPorts.AllowUserToAddRows = true;
        internal void DGVDisableAdding() => dataGridViewPorts.AllowUserToAddRows = false;
        internal DataGridViewRowCollection DGVGetRows() => dataGridViewPorts.Rows;
        internal int DGVGetRowsCount() => dataGridViewPorts.Rows.Count;
        internal int DGVGetColumnIndex(string columnName) => dataGridViewPorts.Columns[columnName].Index;
        internal object DGVGetCellValue(int x, int y) => dataGridViewPorts[x, y].Value;

        //Timer
        internal void EnableTimer() => timerUpdatePorts.Enabled = true;
        internal void DisableTimer() => timerUpdatePorts.Enabled = false;
        #endregion
    }
}
