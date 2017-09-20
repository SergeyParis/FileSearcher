using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FileSearcher.Forms
{
    partial class MainForm
    {
        private const int PANEL_CHECKBOX_PADDING_X = 100;
        private const int PANEL_CHECKBOX_PADDING_Y = 10;
        private const int PANEL_CHECKBOX_COUNT_IN_ROW = 3;

        private const int PANEL_CHECKBOX_LOGICDRIVES_SIZE_X = 80;
        private const int PANEL_CHECKBOX_LOGICDRIVES_SIZE_Y = 21;
        private const int PANEL_CHECKBOX_CUSTOMFOLDERS_SIZE_X = 290;
        private const int PANEL_CHECKBOX_CUSTOMFOLDERS_SIZE_Y = 21;

        private const int PANEL_CHECKBOX_LOGICDRIVES_POSSITION_X = 10;
        private const int PANEL_CHECKBOX_LOGICDRIVES_POSSITION_Y = 12;
        private const int PANEL_CHECKBOX_CUSTOMFOLDERS_POSSITION_X = 0;
        private const int PANEL_CHECKBOX_CUSTOMFOLDERS_POSSITION_Y = 12;

        private readonly List<bool> _stateCheckBoxesLogicDrives = new List<bool>();
        private readonly List<bool> _stateCheckBoxesCustomFolders = new List<bool>();
        private readonly List<CustumFolder> _listOfFolders = new List<CustumFolder>();

        private int _nextPossitionCustomFolderY = PANEL_CHECKBOX_CUSTOMFOLDERS_POSSITION_Y;

        private void SettingPanelCheckBox()
        {
            ChangeEnablePanels(true);
            CreateCheckBoxesDrives(PANEL_CHECKBOX_LOGICDRIVES_POSSITION_X, PANEL_CHECKBOX_LOGICDRIVES_POSSITION_Y);
        }

        private void ChangeEnablePanels(bool enabled)
        {
            this.pnlLogicDrives.Enabled = enabled;
            this.pnlChooseFolders.Enabled = !enabled;

            this.btnAddFolder.Enabled = !enabled;
            this.btnRemoveFolder.Enabled = !enabled;
        }
        private void CreateCheckBoxesDrives(int locationX, int locationY)
        {
            int countCurrentCheckBox = 0;

            int currentX = locationX;
            int currentY = locationY;

            foreach (string drive in this._logicalDrives)
            {
                CheckBox current = new CheckBox()
                {
                    Visible = true,
                    Width = PANEL_CHECKBOX_LOGICDRIVES_SIZE_X,
                    Height = PANEL_CHECKBOX_LOGICDRIVES_SIZE_Y,
                    Text = drive,
                    Location = new Point(currentX, currentY),
                    Checked = true
                };

                pnlLogicDrives.Controls.Add(current);
                countCurrentCheckBox++;

                if (countCurrentCheckBox % PANEL_CHECKBOX_COUNT_IN_ROW == 0)
                {
                    currentX = locationX;
                    currentY += PANEL_CHECKBOX_PADDING_Y + PANEL_CHECKBOX_LOGICDRIVES_SIZE_Y;
                }
                else
                    currentX += PANEL_CHECKBOX_PADDING_X;
            }
        }
        private void AddFolder()
        {
            CustumFolder custumFolder = new CustumFolder()
            {
                Checked = true,
                Location = new Point(PANEL_CHECKBOX_CUSTOMFOLDERS_POSSITION_X,
                    _nextPossitionCustomFolderY)
            };
            custumFolder.ChangeDirectoryBrowserDialog();

            _listOfFolders.Add(custumFolder);

            this.pnlChooseFolders.Controls.Add(custumFolder);

            _nextPossitionCustomFolderY +=
                PANEL_CHECKBOX_CUSTOMFOLDERS_SIZE_Y + PANEL_CHECKBOX_PADDING_Y;
        }
        private void RemoveFolder()
        {
            if (this._listOfFolders.Count == 0)
                return;

            CustumFolder remove = this._listOfFolders[this._listOfFolders.Count - 1];
            this._listOfFolders.RemoveAt(this._listOfFolders.Count - 1);

            _nextPossitionCustomFolderY -=
                PANEL_CHECKBOX_CUSTOMFOLDERS_SIZE_Y + PANEL_CHECKBOX_PADDING_Y;

            remove.Dispose();
        }

        private void rBtnLogicDrives_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rBtnLogicDrives.Checked)
            {
                ChangeEnablePanels(true);

                int i = 0;
                if (this._stateCheckBoxesLogicDrives.Count > 0)
                    foreach (Control control in this.pnlLogicDrives.Controls)
                        if (control is CheckBox checkBox)
                            checkBox.Checked = _stateCheckBoxesLogicDrives[i++];

                _stateCheckBoxesCustomFolders.Clear();
                foreach (CustumFolder folderCustum in _listOfFolders)
                {
                    _stateCheckBoxesCustomFolders.Add(folderCustum.Checked);
                    folderCustum.Checked = false;
                }

                this._typePathesSearching = TypePathesSearching.LogicDrives;
            }
            else
            {
                ChangeEnablePanels(false);

                if (this._stateCheckBoxesCustomFolders.Count > 0)
                    for (int i = 0; i < _stateCheckBoxesCustomFolders.Count; i++)
                        _listOfFolders[i].Checked = _stateCheckBoxesCustomFolders[i];


                _stateCheckBoxesLogicDrives.Clear();
                foreach (Control control in this.pnlLogicDrives.Controls)
                    if (control is CheckBox checkBox)
                    {
                        _stateCheckBoxesLogicDrives.Add(checkBox.Checked);
                        checkBox.Checked = false;
                    }

                this._typePathesSearching = TypePathesSearching.CustomFolders;
            }
        }
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            AddFolder();
        }
        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            RemoveFolder();
        }

        private sealed class CustumFolder : Control
        {
            private readonly Color _colorEdit = Color.AliceBlue;
            private readonly Color _colorSuccess = Color.Cornsilk;
            private readonly Color _colorError = Color.LightPink;

            private CheckBox _checkBox;
            private TextBox _txbxPath;
            private Button _btnChangeFolder;
            private bool _validate;

            public bool Checked
            {
                get => this._checkBox.Checked;
                set => this._checkBox.Checked = value;
            }
            public new string Text
            {
                get => this._txbxPath.Text;
                set => this._txbxPath.Text = value;
            }

            public CustumFolder()
            {
                this.Size = new Size(PANEL_CHECKBOX_CUSTOMFOLDERS_SIZE_X, PANEL_CHECKBOX_CUSTOMFOLDERS_SIZE_Y);

                CreateControls();
                AddControls();
            }

            public void ChangeDirectoryBrowserDialog()
            {
                ChooseDirectory();
            }
            public new void Dispose()
            {
                this._checkBox.Dispose();
                this._txbxPath.Dispose();
                this._btnChangeFolder.Dispose();

                base.Dispose();
            }

            private void CreateControls()
            {
                this._checkBox = new CheckBox()
                {
                    Location = new Point(10, 0),
                    Width = 15,
                    Checked = true
                };

                this._txbxPath = new TextBox()
                {
                    Location = new Point(30, 1),
                    Width = 225,
                    BackColor = _colorSuccess,
                    ReadOnly = false
                };

                this._btnChangeFolder = new Button()
                {
                    Location = new Point(255, 0),
                    Width = 30,
                    Height = 22,
                    Text = "..."
                };

                this._btnChangeFolder.Click += _btnChangeFolder_Click;
                this._btnChangeFolder.LostFocus += _btnChangeFolder_LostFocus;

                this._txbxPath.Click += _txbxPath_Click;
                this._txbxPath.LostFocus += _txbxPath_LostFocus;
                this._txbxPath.TextChanged += _txbxPath_TextChanged;

                this._checkBox.CheckedChanged += _checkBox_CheckedChanged;
                this._checkBox.LostFocus += _chechBox_LostFocus;
            }

            private void AddControls()
            {
                this.Controls.Add(_checkBox);
                this.Controls.Add(_txbxPath);
                this.Controls.Add(_btnChangeFolder);
            }
            private void ChooseDirectory()
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                    this._txbxPath.Text = dialog.SelectedPath;

                BackgroundColorValidation();
            }
            private void BackgroundColorValidation()
            {
                if (FileSearcher.Helpers.FileSystemInfo.CheckExistFolder(this._txbxPath.Text))
                {
                    this._validate = true;
                    this._txbxPath.BackColor = _colorSuccess;
                }
                else
                {
                    this._validate = false;
                    this._txbxPath.BackColor = _colorError;
                }

                if (!this._txbxPath.Focused && this._validate == false)
                    this.Checked = false;
            }

            private void _btnChangeFolder_Click(object sender, EventArgs e)
            {
                ChooseDirectory();
            }
            private void _btnChangeFolder_LostFocus(object sender, EventArgs e)
            {
                BackgroundColorValidation();
            }

            private void _txbxPath_Click(object sender, EventArgs e)
            {
                this._txbxPath.ReadOnly = false;
                BackgroundColorValidation();
            }
            private void _txbxPath_LostFocus(object sender, EventArgs e)
            {
                this._txbxPath.ReadOnly = true;
                BackgroundColorValidation();
            }
            private void _txbxPath_TextChanged(object sender, EventArgs e)
            {
                BackgroundColorValidation();
            }

            private void _checkBox_CheckedChanged(object sender, EventArgs e)
            {
                if (this._checkBox.Checked)
                {
                    this._txbxPath.Enabled = true;
                    this._btnChangeFolder.Enabled = true;
                }
                else
                {
                    this._txbxPath.Enabled = false;
                    this._btnChangeFolder.Enabled = false;
                }
            }
            private void _chechBox_LostFocus(object sender, EventArgs e)
            {
                BackgroundColorValidation();
            }
        }
    }
}
