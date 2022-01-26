using Emu8086_IOGUI_Csharp.Interfaces;
using Emu8086_IOGUI_Csharp.Repositories;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emu8086_IOGUI_Csharp
{
    internal class FormLogic
    {
        IModeRepository modeRepository;

        readonly FormMain formMain;

        internal FormLogic(FormMain formMain)
        {
            this.formMain = formMain;
            modeRepository = new EmulationRepository();
        }





        #region Logic called directly from Event Handlers
        internal void LoadIOFile()
        {
            formMain.LoadIOFile();
            Settings.Filepath = formMain.GetIOFilename();
            formMain.SetTitle();
        }

        internal void SetBackground()
        {
            formMain.LoadBgFile();
            Settings.Background = formMain.GetBgFilename();
            formMain.SetBackground();
        }

        internal void SaveConfiguration()
        {
            bool IsSaveFileChosen = formMain.SaveConfigFile() == DialogResult.OK;
            if (IsSaveFileChosen)
            {
                SerializeConfigFile();
            }
        }

        internal void LoadConfiguration<T>() where T : class, IModeRepository, new()
        {
            formMain.DisableTimer();
            formMain.LoadConfigFile();
            try
            {
                DeserializeConfigFile();
                this.modeRepository = new T();
                DrawVisuals();
            }
            catch { };
            formMain.EnableTimer();
        }

        internal void CellBeginEdit()
        {
            formMain.DisableTimer();
        }

        internal void CellClick(DataGridViewCellEventArgs e)
        {
            bool isEmiterOutOfBounds = e.RowIndex < 0;
            bool isEmiterColumnPortSet = e.ColumnIndex == formMain.DGVGetColumnIndex("PortSet");
            bool isEmiterColumnPortReset = e.ColumnIndex == formMain.DGVGetColumnIndex("PortReset");

            if (isEmiterOutOfBounds)
                return;

            else if (isEmiterColumnPortSet)
                SetPin(e, 1);

            else if (isEmiterColumnPortReset)
                SetPin(e, 0);

            else
                return;
        }

        internal void CellEndEdit(DataGridViewCellEventArgs e)
        {
            bool isEmiterColumnPortX = e.ColumnIndex == formMain.DGVGetColumnIndex("PortX");
            bool isEmiterColumnPortY = e.ColumnIndex == formMain.DGVGetColumnIndex("PortY");
            bool isEmiterColumnEitherPortCoord = isEmiterColumnPortX || isEmiterColumnPortY;

            if (isEmiterColumnEitherPortCoord)
            {
                object portXValue = formMain.DGVGetCellValue(2, e.RowIndex);
                object portYValue = formMain.DGVGetCellValue(3, e.RowIndex);
                bool areBothCoordinantsProvided = portXValue != null && portYValue != null;

                if (areBothCoordinantsProvided)
                {
                    int visualX = Convert.ToInt32(portXValue);
                    int visualY = Convert.ToInt32(portYValue);
                    string visualName = "visual" + e.RowIndex;
                    CreateOrUpdateVisual(visualX, visualY, visualName);
                }
            }

            formMain.EnableTimer();
        }

        internal async Task UpdateValuesAsync()
        {
            formMain.SetCurrentMode(modeRepository.GetModeName());
            formMain.SetLegend(modeRepository.GetLegend());

            bool IsDGVPopulated = formMain.DGVGetRowsCount() > 1;
            bool IsFilepathSet = Settings.Filepath != null;
            bool IsThereAnythingToUpdateWith = IsDGVPopulated && IsFilepathSet;

            if (IsThereAnythingToUpdateWith)
            {
                foreach (DataGridViewRow row in formMain.DGVGetRows())
                {
                    try
                    {
                        row.Cells["PortValue"].Value = GetPortValueAsPaddedString(row.Cells["PortID"].Value);
                        UpdateVisualColour(row);
                    }
                    catch { };
                }
            }
        }
        #endregion





        #region Helper methods
        //Configs
        private void SerializeConfigFile()
        {
            formMain.DGVDisableAdding();
            FileStream fcreate = File.Open(formMain.GetSaveConfigFilename(), FileMode.Create);
            using (StreamWriter sw = new StreamWriter(fcreate))
            {
                sw.WriteLine(Settings.Filepath);
                sw.WriteLine(Settings.Background);
                foreach (DataGridViewRow row in formMain.DGVGetRows())
                {
                    sw.WriteLine(Convert.ToString(row.Cells["PortID"].Value) +
                        "," + Convert.ToString(row.Cells["PortX"].Value) +
                        "," + Convert.ToString(row.Cells["PortY"].Value) +
                        "," + Convert.ToString(row.Cells["PortName"].Value));
                }
            }
            formMain.DGVEnableAdding();
        }

        private void DeserializeConfigFile()
        {
            using StreamReader sr = new StreamReader(formMain.GetLoadConfigFilename());
            ClearDataGridView();
            string line;
            int whichLine = 1;
            while ((line = sr.ReadLine()) != null)
            {
                if (whichLine == 1)
                {
                    Settings.Filepath = line;
                    formMain.SetTitle();
                }
                else if (whichLine == 2)
                {
                    Settings.Background = line;
                    formMain.SetBackground();
                }
                else
                {
                    string[] rowParts = line.Split(",");
                    formMain.DGVAddRow(rowParts[0], "", rowParts[1], rowParts[2], "", "", rowParts[3]);
                }
                whichLine++;
            }
        }

        //Input/Output
        private void SetPin(DataGridViewCellEventArgs e, short pin)
        {
            string rowString = Convert.ToString(formMain.DGVGetCellValue(0, e.RowIndex));
            if (rowString != "" && Settings.Filepath != null)
            {
                int portID = Convert.ToInt32(rowString, 16);
                modeRepository.WRITE_IO_WORD(portID, pin);
            }
        }

        private int GetPortValue(object portId)
        {
            string portIdAsString = Convert.ToString(portId);
            int portIdAsHex = Convert.ToInt32(portIdAsString, 16);
            int portValue = modeRepository.READ_IO_WORD(portIdAsHex);
            return portValue;
        }

        private string GetPortValueAsString(object portId)
        {
            string portValueAsString = GetPortValue(portId).ToString();
            return portValueAsString;
        }

        private string GetPortValueAsPaddedString(object portId)
        {
            string portValueAsPaddedString = Convert.ToString(GetPortValue(portId), 2).PadLeft(16, '0');
            return portValueAsPaddedString;
        }


        //Rendering
        private void DrawVisuals()
        {
            formMain.DGVDisableAdding();
            foreach (DataGridViewRow row in formMain.DGVGetRows())
            {
                int visualX = Convert.ToInt32(row.Cells["PortX"].Value);
                int visualY = Convert.ToInt32(row.Cells["PortY"].Value);
                string visualName = "visual" + row.Index;
                CreateOrUpdateVisual(visualX, visualY, visualName);
            }
            formMain.DGVEnableAdding();
        }

        private void CreateOrUpdateVisual(int visualX, int visualY, string visualName)
        {
            if (!formMain.VisualExists(visualName))
            {
                Button newVisual = new System.Windows.Forms.Button
                {
                    Location = new System.Drawing.Point(visualX, visualY),
                    Name = visualName,
                    Size = new System.Drawing.Size(24, 24),
                    Text = "V",
                    UseVisualStyleBackColor = true
                };
                formMain.AddVisual(newVisual);
                formMain.PushBackgroud();
            }
            else
            {
                Control foundVisual = formMain.GetVisual(visualName);
                foundVisual.Location = new System.Drawing.Point(visualX, visualY);
            }
        }

        private void UpdateVisualColour(DataGridViewRow row)
        {
            string visualName = "visual" + row.Index;
            Control foundVisual = formMain.GetVisual(visualName);
            if (foundVisual != null)
            {
                foundVisual.Text = GetPortValueAsString(row.Cells["PortID"].Value);
                switch (GetPortValue(row.Cells["PortID"].Value))
                {
                    case 0:
                        foundVisual.BackColor = System.Drawing.Color.Lime;
                        break;
                    case 1:
                        foundVisual.BackColor = System.Drawing.Color.Red;
                        break;
                    case 2:
                        foundVisual.BackColor = System.Drawing.Color.Yellow;
                        break;
                    case 3:
                        foundVisual.BackColor = System.Drawing.Color.Orange;
                        break;
                }
            }
        }

        private void ClearDataGridView()
        {
            formMain.DGVClearDataSource();
            formMain.DGVClearRows();
            DisposeVisuals();
            DisposeVisuals();
        }

        private void DisposeVisuals()
        {
            System.Collections.Generic.IEnumerable<Control> visuals = formMain.GetVisuals();
            foreach (Button visual in visuals)
            {
                formMain.RemoveVisual(visual);
                visual.Dispose();
            }
        }
        #endregion
    }
}