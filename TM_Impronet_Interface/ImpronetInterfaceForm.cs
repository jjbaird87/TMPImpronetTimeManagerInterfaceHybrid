using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TM_Impronet_Interface.Classes;
using TM_Impronet_Interface.Engines;
using TM_Impronet_Interface.Export_Classes;
using TM_Impronet_Interface.Properties;

namespace TM_Impronet_Interface
{
    public partial class ImpronetInterfaceForm : Form
    {
        private int _seconds = -1;
        private BackgroundWorker _bgWorker = new BackgroundWorker();
        private readonly SyncEngine _syncEngine;

        public ImpronetInterfaceForm()
        {
            InitializeComponent();

            tabctrlMappings.Appearance = TabAppearance.FlatButtons;
            tabctrlMappings.ItemSize = new Size(0, 1);
            tabctrlMappings.SizeMode = TabSizeMode.Fixed;
            treeDepMappings.CheckBoxes = true;

            //Setup Engines
            _syncEngine = new SyncEngine(new TimeSpan(0, 0,
                Settings.Default.SyncInterval == 0 ? 400 : Settings.Default.SyncInterval));
            _syncEngine.BackgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            _syncEngine.OnSecondsHandler += SyncEngineOnOnSecondsHandler;            
            if (Settings.Default.SyncEnabled)
            {
                _syncEngine.StartEngine();
            }

            txtOutputPath.Text = Settings.Default.SaveFile;
            txtFbDatabasePath.Text = Settings.Default.FirebirdDatabasePath;
            txtSqlConnectionString.Text = Settings.Default.SQLConnectionString;
            txtTmpDatabasePath.Text = Settings.Default.TMPDatabaseLocation;
            txtRunnerExe.Text = Settings.Default.Runner;
            chkEnableTimer.Checked = Settings.Default.TimerEnabled;
            chkSyncTimerEnabled.Checked = Settings.Default.SyncTimerEnabled;
            txtInterval.Text = Settings.Default.Interval.ToString();
            chkSynEmployees.Checked = Settings.Default.SyncEnabled;
            txtDepMappingAccessControlCode.Text = Settings.Default.DepAccessControlCode;
            txtDepMappingTimeAndAttendanceCode.Text = Settings.Default.DepTimeAndAttendanceCode;
            chkSyncAccessControlDevices.Checked = Settings.Default.SyncAccessControl;
            txtSyncInterval.Text = Settings.Default.SyncInterval.ToString();
            chkEnableEmail.Checked = Settings.Default.EnableEmail;
            txtSmtpHost.Text = Settings.Default.SmtpHost;
            txtUsername.Text = Settings.Default.Username;
            txtEmailAddress.Text = Settings.Default.EmailAddress;
            txtSmtpPort.Text = Settings.Default.SmtpPort.ToString();
            txtPassword.Text = Settings.Default.Password;
            chkSSL.Checked = Settings.Default.SSL;
            txtToEmailAddress1.Text = Settings.Default.ToEmailAddress;
            chkAlwaysSync.Checked = Settings.Default.SyncAllDepartments;
            chkChangeEmployeeNumber.Checked = Settings.Default.UpdateEmployeeNumber;
            chkEnableIntegrityExport.Checked = Settings.Default.EnableIntegrityExport;
            chkEnableTmpExport.Checked = Settings.Default.EnableTmpExport;
            txtIntegrityExport.Text = Settings.Default.IntegrityExportLocation;
            txtNetworkLocation.Text = Settings.Default.TmpNetworkLocation;
            chkCalc0.Checked = Settings.Default.Calc0;
            chkCalc1.Checked = Settings.Default.Calc1;
            chkCalc2.Checked = Settings.Default.Calc2;
            chkCalc3.Checked = Settings.Default.Calc3;
            chkCalc4.Checked = Settings.Default.Calc4;
            chkEnableExcelExport.Checked = Settings.Default.EnableExcelExport;
            txtEbExcelLocation.Text = Settings.Default.EbExcelExportLocation;
            txtOutputPath.Text = Settings.Default.TmpExportLocation;

            chkRunExeAuto.Checked = Settings.Default.RunExeAfterExportEnabledAuto;
            txtRunnerExe.Text = Settings.Default.ExeDirectoryAuto;

            txtExePath.Text = Settings.Default.ExeDirectoryRun;
            chkRunnerTmp.Checked = Settings.Default.RunExeAfterExportEnabled;


            if (Settings.Default.MappingConfig == 0)
                radUseStandardMapping.Checked = true;
            else
                radUseDepartmentMapping.Checked = true;

            if (Settings.Default.UseSql)
                radSql.Checked = true;
            else
            {
                radFirebird.Checked = true;
            }

            if (chkEnableTimer.Checked)
            {
                _seconds = txtInterval.Text == "" ? 300 : Convert.ToInt32(txtInterval.Text);
                tmrSeconds.Start();
            }
           
            radDuplicateMonths.Checked = Settings.Default.DuplicateMonths;
            radDuplicateWeeks.Checked = !Settings.Default.DuplicateMonths;

            //tabOverview.TabPages.Remove(tabpgEngine);
            tabCtrlEngines.TabPages.Remove(tabpgExportRunner);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            InvokeUI(() => 
            { 
            var progress = (ProgressEventArgs)e.UserState;
            toolStripProgressBar1.Maximum = progress.TotalRecords;
            toolStripProgressBar1.Value = progress.Progress;
            if (!string.IsNullOrEmpty(progress.Status))
                toolStripStatusLabel1.Text = progress.Status;
            });
        }

        private void SyncEngineOnOnSecondsHandler(object o, EventArgs eventArgs)
        {
            InvokeUI(() =>
            {
                var time = (Engine.EngineProgressEventArgs) eventArgs;
                lblSyncCountDown.Text = time.Status == "" ? $"{time.CurrentSeconds} second(s)" :time.Status;
            });
        }

        private void InvokeUI(Action a)
        {
            BeginInvoke(new MethodInvoker(a));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                var improDataAccess = new ImproDataAccess();
                improDataAccess.TestConnection();
                MessageBox.Show("Connection Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_bgWorker != null && _bgWorker.IsBusy)
            {
                MessageBox.Show("An operation is already in progress", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (tabCtrlExport.SelectedTab == tabpgTmpExport)
                    StartTmpExport();
                if (tabCtrlExport.SelectedTab == tabpgIntegrityExport)
                    StartIntegrityExport();
                if (tabCtrlExport.SelectedTab == tabpgExcelExport)
                    StartExcelExport();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    $"An error has occured: {exception.Message}{Environment.NewLine}{Environment.NewLine}{exception}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class TmpExportParams
        {
            public TmpExportParams(DateTime startDate, DateTime endDate)
            {
                StartDate = startDate;
                EndDate = endDate;
            }

            public DateTime StartDate { get; }
            public DateTime EndDate { get; }
        }

        private void StartTmpExport()
        {
            _bgWorker = new BackgroundWorker {WorkerReportsProgress = true};
            TmpExport.OnProgressHandler += (sender, args) => { _bgWorker.ReportProgress(0, args); };
            _bgWorker.DoWork += (sender, args) =>
            {
                _syncEngine.Authorized = false;
                var parameters = (TmpExportParams) args.Argument;
                TmpExport.Export(parameters.StartDate, parameters.EndDate, false);
            };
            _bgWorker.ProgressChanged += (sender, args) =>
            {
                var progress = (ProgressEventArgs) args.UserState;
                toolStripProgressBar1.Maximum = progress.TotalRecords;
                toolStripProgressBar1.Value = progress.Progress;
                if (!string.IsNullOrEmpty(progress.Status))
                    toolStripStatusLabel1.Text = progress.Status;
            };
            _bgWorker.RunWorkerCompleted += (sender, args) =>
            {
                _syncEngine.Authorized = true;
                if (args.Error != null)
                {
                    ShowError(args.Error);
                    return;
                }
                MessageBox.Show("TMP Export completed successfully", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                if (chkRunnerTmp.Checked)
                    RunExe(txtExePath.Text);
            };
            _bgWorker.RunWorkerAsync(new TmpExportParams(dtFromDate.Value, dtToDate.Value));
        }

        private class IntegrityExportParams
        {
            public IntegrityExportParams(DateTime startDate, DateTime endDate)
            {
                StartDate = startDate;
                EndDate = endDate;
                EnableFilters = false;
            }

            public IntegrityExportParams(DateTime startDate, DateTime endDate, string costCenterFrom,
                string costCenterTo)
            {
                StartDate = startDate;
                EndDate = endDate;
                EnableFilters = true;
                CostCenterFrom = costCenterFrom;
                CostCenterTo = costCenterTo;
            }

            public DateTime StartDate { get; }
            public DateTime EndDate { get; }
            public bool EnableFilters { get; }
            public string CostCenterFrom { get; }
            public string CostCenterTo { get; }
        }

        private void StartIntegrityExport()
        {
            _bgWorker = new BackgroundWorker {WorkerReportsProgress = true};

            IntegrityExport.OnProgressHandler += (sender, args) =>
            {
                _bgWorker.ReportProgress(0, args);
            };
            _bgWorker.DoWork += (sender, args) =>
            {
                _syncEngine.Authorized = false;
                var parameters = (IntegrityExportParams) args.Argument;
                IntegrityExport.ExportIntegrity(parameters.StartDate, parameters.EndDate, parameters.EnableFilters,
                    parameters.CostCenterFrom, parameters.CostCenterTo);
            };
            _bgWorker.ProgressChanged += (sender, args) =>
            {
                var progress = (ProgressEventArgs) args.UserState;
                toolStripProgressBar1.Maximum = progress.TotalRecords;
                toolStripProgressBar1.Value = progress.Progress;
                if (!string.IsNullOrEmpty(progress.Status))
                    toolStripStatusLabel1.Text = progress.Status;
            };
            _bgWorker.RunWorkerCompleted += (sender, args) =>
            {
                _syncEngine.Authorized = true;
                if (args.Error != null)
                {
                    ShowError(args.Error);
                    return;
                }
                MessageBox.Show("Integrity Export completed successfully", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };
            //Run worker
            if (!chkEnableFilters.Checked)
                _bgWorker.RunWorkerAsync(new IntegrityExportParams(dtIntegrityStart.Value, dtIntegrityEnd.Value));
            else
            {
                var ccFrom = ((ComboBoxItemDepartment) cmbccFrom.SelectedItem).ItemObject.Id;
                var ccTo = ((ComboBoxItemDepartment) cmbccTo.SelectedItem).ItemObject.Id;
                _bgWorker.RunWorkerAsync(
                    new IntegrityExportParams(dtIntegrityStart.Value, dtIntegrityEnd.Value, ccFrom, ccTo));
            }
        }

        private class ExcelReportParams
        {
            public ExcelReportParams(DateTime startDate, DateTime endDate)
            {
                StartDate = startDate;
                EndDate = endDate;
                EnableFilters = false;
            }

            public ExcelReportParams(DateTime startDate, DateTime endDate, string costCenterFrom,
                string costCenterTo)
            {
                StartDate = startDate;
                EndDate = endDate;
                EnableFilters = true;
                CostCenterFrom = costCenterFrom;
                CostCenterTo = costCenterTo;
            }

            public DateTime StartDate { get; }
            public DateTime EndDate { get; }
            public bool EnableFilters { get; }
            public string CostCenterFrom { get; }
            public string CostCenterTo { get; }
        }

        private void StartExcelExport()
        {
            _bgWorker = new BackgroundWorker {WorkerReportsProgress = true};
            ExcelExport.OnProgressHandler += ExcelExport_OnProgressHandler;
            _bgWorker.DoWork += (sender, args) =>
            {
                _syncEngine.Authorized = false;
                var parameters = (ExcelReportParams) args.Argument;
                ExcelExport.Export(parameters.StartDate, parameters.EndDate, parameters.EnableFilters,
                    parameters.CostCenterFrom, parameters.CostCenterTo);
            };
            _bgWorker.ProgressChanged += (sender, args) =>
            {
                var progress = (ProgressEventArgs) args.UserState;
                toolStripProgressBar1.Maximum = progress.TotalRecords;
                toolStripProgressBar1.Value = progress.Progress;
                if (!string.IsNullOrEmpty(progress.Status))
                    toolStripStatusLabel1.Text = progress.Status;
            };
            _bgWorker.RunWorkerCompleted += (sender, args) =>
            {
                _syncEngine.Authorized = true;
                if (args.Error != null)
                {
                    ShowError(args.Error);
                    return;
                }
                MessageBox.Show("Excel Export completed successfully", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };
            //Run worker
            if (!chkExcelFilterEnable.Checked)
                _bgWorker.RunWorkerAsync(new ExcelReportParams(dtEbExcelFrom.Value, dtEbExcelTo.Value));
            else
            {
                var ccFrom = ((ComboBoxItemDepartment)cmbExcelBranchFrom.SelectedItem).ItemObject.Id;
                var ccTo = ((ComboBoxItemDepartment)cmbExcelBranchTo.SelectedItem).ItemObject.Id;
                _bgWorker.RunWorkerAsync(
                    new ExcelReportParams(dtEbExcelFrom.Value, dtEbExcelTo.Value, ccFrom, ccTo));
            }
            
        }

        private void ExcelExport_OnProgressHandler(object sender, EventArgs e)
        {
            _bgWorker.ReportProgress(0, e);
        }

        private static void ShowError(Exception exception)
        {
            MessageBox.Show($"{exception.Message}{Environment.NewLine}{Environment.NewLine}{exception}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LoadRefreshMappings()
        {
            try
            {
                //Read Current Mappings
                var improDataAccess = new ImproDataAccess();
                var full = Settings.Default.Mappings;
                var singleMappings = full.Split(',');

                var dsTerminalMapping = new DataSet();
                dsTerminalMapping.Tables.Add();
                dsTerminalMapping.Tables[0].Columns.Add("TERM_SLA");
                dsTerminalMapping.Tables[0].Columns.Add("TERM_NAME");
                dsTerminalMapping.Tables[0].Columns.Add("MAPPING");

                var terminals = improDataAccess.GetImproTerminals();
                foreach (var terminal in terminals)
                {
                    var sFound = singleMappings.FirstOrDefault(i => i.Contains(terminal.Id));
                    if (sFound == null)
                    {
                        dsTerminalMapping.Tables[0].Rows.Add(terminal.Id, terminal.Name, "");
                        continue;
                    }
                    if (sFound != "")
                    {
                        dsTerminalMapping.Tables[0]
                            .Rows.Add(terminal.Id, terminal.Name,
                                sFound.Split(';')[1]);
                    }
                }

                gridMappings.DataSource = dsTerminalMapping.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var toSave = new DataSet();
            toSave.Tables.Add(((DataTable) gridMappings.DataSource).Copy());

            var lstMappings = (from DataRow dr in toSave.Tables[0].Rows
                where dr["MAPPING"].ToString() != ""
                select $"{dr["TERM_SLA"]};{dr["MAPPING"]},").ToList();

            var sToSave = lstMappings.Aggregate("", (current, s) => current + s);

            Settings.Default.Mappings = sToSave;
            Settings.Default.Save();

            MessageBox.Show(@"Saved!");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRefreshMappings();
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog
            {
                FileName = "IMPRONET.fdb",
                Filter = @"dat Files (*.fdb)|*.fdb|All files (*.*)|*.*",
                AddExtension = true
            };
            if (openDlg.ShowDialog() != DialogResult.OK)
                return;

            txtFbDatabasePath.Text = openDlg.FileName;
            Settings.Default.FirebirdDatabasePath = txtFbDatabasePath.Text;
            Settings.Default.Save();
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            var saveDlg = new SaveFileDialog
            {
                FileName = "Clocks.dat",
                Filter = @"dat Files (*.dat)|*.dat|All files (*.*)|*.*",
                AddExtension = true
            };
            if (saveDlg.ShowDialog() != DialogResult.OK)
                return;

            txtOutputPath.Text = saveDlg.FileName;
            Settings.Default.TmpExportLocation = txtOutputPath.Text;
            Settings.Default.Save();
        }

        private void txtOutputPath_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.SaveFile = txtOutputPath.Text;
            Settings.Default.Save();
        }

        private void txtDatabasePath_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.FirebirdDatabasePath = txtFbDatabasePath.Text;
            Settings.Default.Save();
        }

        private void RunExe(string exeDir)
        {
            if (exeDir != "")
            {
                System.Diagnostics.Process.Start(exeDir);
            }
        }

        private void chkEnableTimer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableTimer.Checked)
            {
                _seconds = Convert.ToInt32(txtInterval.Text);
                tmrSeconds.Start();
            }
            else
                tmrSeconds.Stop();

            Settings.Default.TimerEnabled = chkEnableTimer.Checked;
            Settings.Default.Save();
        }

        private void txtInterval_TextChanged(object sender, EventArgs e)
        {
            if (txtInterval.Text == "") return;
            Settings.Default.Interval = Convert.ToInt32(txtInterval.Text);
            Settings.Default.Save();
        }        

        private void tmrSeconds_Tick(object sender, EventArgs e)
        {
            lblCountdown.Text = $"{_seconds} second(s)";
            if (_seconds == 0)
            {
                tmrSeconds.Stop();

                dtFromDate.Value = GetLowestDT(DateTime.Now);
                dtToDate.Value = GetHighestDt(DateTime.Now);

                //Process(GetLowestDT(DateTime.Now), GetHighestDt(DateTime.Now), GetConnectionObject(),
                //GetCommandObject());
                _seconds = Convert.ToInt32(txtInterval.Text);

                tmrSeconds.Start();
            }
            else if (_seconds < 0)
                _seconds = Convert.ToInt32(txtInterval.Text);
            else
                _seconds--;
        }

        private DateTime GetLowestDT(DateTime dateTimeCurrent)
        {
            return new DateTime(
                dateTimeCurrent.Year,
                dateTimeCurrent.Month,
                dateTimeCurrent.Day,
                0,
                0,
                0);
        }

        private void radFirebird_CheckedChanged(object sender, EventArgs e)
        {
            if (radFirebird.Checked)
            {
                txtFbDatabasePath.Enabled = true;
                btnBrowseFbDatabase.Enabled = true;
                Settings.Default.UseSql = false;
                Settings.Default.Save();
            }
            else
            {
                txtFbDatabasePath.Enabled = false;
                btnBrowseFbDatabase.Enabled = false;
            }
        }

        private void radSql_CheckedChanged(object sender, EventArgs e)
        {
            txtSqlConnectionString.Enabled = radSql.Checked;

            if (!radSql.Checked) return;

            Settings.Default.UseSql = true;
            Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog
            {
                FileName = "TIMEMANAGERPLATINUM.GDB",
                Filter = @"dat Files (*.gdb)|*.gdb|All files (*.*)|*.*",
                AddExtension = true
            };
            if (openDlg.ShowDialog() != DialogResult.OK)
                return;

            txtTmpDatabasePath.Text = openDlg.FileName;
            Settings.Default.TMPDatabaseLocation = txtTmpDatabasePath.Text;
            Settings.Default.Save();
        }

        private void btnRefreshDepartments_Click(object sender, EventArgs e)
        {
            var improDataAccess = new ImproDataAccess();
            var departments = improDataAccess.GetDepartments();

            if (departments == null)
                return;

            var selectedItems = Settings.Default.SelectedDepartments ?? new StringCollection();
            foreach (var department in departments)
            {
                chkDepartments.Items.Add(department,
                    selectedItems.Contains(department.Id) ? CheckState.Checked : CheckState.Unchecked);
            }
        }

        private void SaveDepartments()
        {
            var items = chkDepartments.CheckedItems;
            if (items.Count == 0)
                return;

            var collection = new StringCollection();
            foreach (var dept in from object item in items select ((Department) item).Id)
            {
                collection.Add(dept);
            }
            Settings.Default.SelectedDepartments = collection;
            Settings.Default.Save();
        }

        private void chkSynEmployees_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SyncEnabled = chkSynEmployees.Checked;
            Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var tmpDataAccess = new TmpDataAccess();
                tmpDataAccess.TestConnection();
                MessageBox.Show("Connection Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection Failed: {ex.Message}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " - " + Application.ProductVersion;
            var nextMonth = DateTime.Now;
            nextMonth = nextMonth.AddMonths(1);

            dtDuplicateScheduleStartDate.Value = new DateTime(nextMonth.Year, nextMonth.Month, 1);
        }

        private void txtSqlConnectionString_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.SQLConnectionString = txtSqlConnectionString.Text;
            Settings.Default.Save();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < chkDepartments.Items.Count; i++)
            {
                chkDepartments.SetItemChecked(i, true);
            }
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            chkDepartments.ClearSelected();
        }

        private void radUseStandardMapping_CheckedChanged(object sender, EventArgs e)
        {
            if (!radUseStandardMapping.Checked) return;
            tabctrlMappings.SelectedTab = tabpgStandardMapping;
            Settings.Default.MappingConfig = 0;
            Settings.Default.Save();
        }

        private void radUseDepartmentMapping_CheckedChanged(object sender, EventArgs e)
        {
            if (!radUseDepartmentMapping.Checked) return;
            tabctrlMappings.SelectedTab = tabpgDepartmentMapping;
            Settings.Default.MappingConfig = 1;
            Settings.Default.Save();
        }

        private void txtDepMappingTimeAndAttendanceCode_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.DepTimeAndAttendanceCode = txtDepMappingTimeAndAttendanceCode.Text;
            Settings.Default.Save();
        }

        private void txtDepMappingAccessControlCode_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.DepAccessControlCode = txtDepMappingAccessControlCode.Text;
            Settings.Default.Save();
        }

        private void btnDepFetchMappings_Click(object sender, EventArgs e)
        {
            var improDataAccess = new ImproDataAccess();
            treeDepMappings.Nodes.Clear();
            var departments = improDataAccess.GetDepartments();
            var terminals = improDataAccess.GetImproTerminals();
            var enumerable = terminals as Terminal[] ?? terminals.ToArray();
            var mappings = new List<DepartmentMapping>();
            if (File.Exists("DepartmentMappings.mxl"))
                mappings = DeSerializeObject<DepartmentMappings>("DepartmentMappings.mxl").DepartmentMappingses;
            foreach (var department in departments)
            {
                var node = treeDepMappings.Nodes.Add(department.Id, department.Name);
                node.Tag = department.Id;
                var departmentMapping = mappings.FindAll(i => i.Department.Id == department.Id);
                foreach (var terminal in enumerable)
                {
                    var node2 = node.Nodes.Add(terminal.Id, terminal.Name);
                    node2.Tag = terminal.Id;
                    if (departmentMapping.Count > 0)
                    {
                        if (departmentMapping[0].Terminals.FindAll(i => i.Id == terminal.Id).Count > 0)
                            node2.Checked = true;
                    }
                }
            }
        }

        private void btnDepMappingsSelectAll_Click(object sender, EventArgs e)
        {
            //TreeView - myTreeview;
            treeDepMappings.BeginUpdate();
            //Loop through all the nodes of tree
            foreach (TreeNode node in treeDepMappings.Nodes)
            {
                //If node has child nodes
                if (node.Nodes.Count <= 0) continue;

                //Check all the child nodes.
                node.Checked = true;
                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = true;
                }
            }
            treeDepMappings.EndUpdate();
        }

        private void btnDepMappingsDeselectAll_Click(object sender, EventArgs e)
        {
            //TreeView - myTreeview;
            treeDepMappings.BeginUpdate();
            //Loop through all the nodes of tree
            foreach (TreeNode node in treeDepMappings.Nodes)
            {
                //If node has child nodes
                if (node.Nodes.Count <= 0) continue;

                //Check all the child nodes.
                node.Checked = false;
                foreach (TreeNode childNode in node.Nodes)
                {
                    childNode.Checked = false;
                }
            }
            treeDepMappings.EndUpdate();
        }

        private void treeDepMappings_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
        }

        private static void CheckTreeViewNode(TreeNode node, bool isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;

                if (item.Nodes.Count > 0)
                {
                    CheckTreeViewNode(item, isChecked);
                }
            }
        }

        private void btnDepMappingsSave_Click(object sender, EventArgs e)
        {
            var mappings = new DepartmentMappings {DepartmentMappingses = new List<DepartmentMapping>()};
            foreach (TreeNode node in treeDepMappings.Nodes)
            {
                //If node has child nodes
                if (node.Nodes.Count <= 0) continue;

                //Check all the child nodes.
                var mapping = new DepartmentMapping
                {
                    Department = new Department {Id = node.Tag.ToString(), Name = node.Text},
                    Terminals = new List<Terminal>()
                };
                foreach (TreeNode childNode in node.Nodes)
                {
                    if (childNode.Checked)
                        mapping.Terminals.Add(new Terminal {Id = childNode.Tag.ToString(), Name = childNode.Text});
                }
                if (mapping.Terminals.Count > 0)
                    mappings.DepartmentMappingses.Add(mapping);
                if (mappings.DepartmentMappingses.Count > 0)
                {
                    SerializeObject(mappings, "DepartmentMappings.mxl");
                }
            }
            MessageBox.Show(@"Mappings saved!");
        }

        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null)
            {
                return;
            }

            try
            {
                var xmlDocument = new XmlDocument();
                var serializer = new XmlSerializer(serializableObject.GetType());
                using (var stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return default(T);
            }

            var objectOut = default(T);

            try
            {
                var xmlDocument = new XmlDocument();
                if (!File.Exists(fileName))
                    return objectOut;
                xmlDocument.Load(fileName);
                var xmlString = xmlDocument.OuterXml;

                using (var read = new StringReader(xmlString))
                {
                    var outType = typeof(T);

                    var serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T) serializer.Deserialize(reader);
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return objectOut;
        }

        private void chkSyncAccessControlDevices_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SyncAccessControl = chkSyncAccessControlDevices.Checked;
            Settings.Default.Save();
        }

        private void txtSyncInterval_TextChanged(object sender, EventArgs e)
        {
            if (txtSyncInterval.Text == "") return;
            Settings.Default.SyncInterval = Convert.ToInt32(txtSyncInterval.Text);
            Settings.Default.Save();
            _syncEngine.ChangeInterval(new TimeSpan(0, 0, Settings.Default.SyncInterval));
        }

        private void chkSyncTimerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSyncTimerEnabled.Checked)
            {
                _syncEngine.StartEngine();
            }
            else
            {
                _syncEngine.StopEngine();
            }

            Settings.Default.SyncTimerEnabled = chkSyncTimerEnabled.Checked;
            Settings.Default.Save();
        }

        private void txtSmtpHost_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.SmtpHost = txtSmtpHost.Text;
            Settings.Default.Save();
        }

        private void txtSmtpPort_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.SmtpPort = Convert.ToInt16(txtSmtpPort.Text);
            Settings.Default.Save();
        }

        private void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.EmailAddress = txtEmailAddress.Text;
            Settings.Default.Save();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.Username = txtUsername.Text;
            Settings.Default.Save();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.Password = txtPassword.Text;
            Settings.Default.Save();
        }

        private void chkSSL_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SSL = chkSSL.Checked;
            Settings.Default.Save();
        }

        private void chkEnableEmail_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.EnableEmail = chkEnableEmail.Checked;
            Settings.Default.Save();
        }

        private void txtToEmailAddress_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ToEmailAddress = txtToEmailAddress1.Text;
            Settings.Default.Save();
        }

        private void btnTestEmail_Click(object sender, EventArgs e)
        {
            try
            {
                EmailSending.Send_Email(new List<string> {txtToEmailAddress1.Text}, txtEmailAddress.Text,
                    "TMP Exporter Test Email", "Test Email");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null
                    ? $"{ex.Message}"
                    : $"{ex.Message} - {ex.InnerException.Message}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SyncAllDepartments = chkAlwaysSync.Checked;
            Settings.Default.Save();
        }

        private void CheckForDuplicateRosterDate(RosterDate rosterDate, string rosterCode)
        {
            var rosters = cmbRosters.Items.Cast<Roster>().ToList().Where(i => i.Code == rosterCode);
            if (rosters.Any(roster => roster.RosterDates.Any(rosterDate.CheckIfOverlap)))
            {
                throw new Exception("An overlapping Roster date has been found. Please correct this before continuing");
            }
        }

        private void btnGetRosters_Click(object sender, EventArgs e)
        {
            var tmpDataAccess = new TmpDataAccess();
            cmbRosters.Items.Clear();
            var rosters = tmpDataAccess.GetTmpRosters();
            var enumerable = rosters as Roster[] ?? rosters.ToArray();
            for (var i = 0; i < enumerable.Length; i++)
            {
                tmpDataAccess.GetTmpRosterDates(ref enumerable[i]);
                cmbRosters.Items.Add(enumerable[i]);
            }

            if (cmbRosters.Items.Count <= 0) return;
            cmbRosters.SelectedIndex = 0;
            if (cmbRosterStartMonth.Items.Count > 0)
            {
                cmbRosterStartMonth.SelectedIndex = 0;
            }
        }

        private void cmbRosters_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRosterStartMonth.Items.Clear();
            var roster = (Roster) cmbRosters.SelectedItem;
            foreach (var rosterDate in roster.RosterDates)
            {
                cmbRosterStartMonth.Items.Add(rosterDate);
            }

            if (cmbRosterStartMonth.Items.Count > 0)
                cmbRosterStartMonth.SelectedIndex = 0;
        }

        private void btnDuplicateRoster_Click(object sender, EventArgs e)
        {
            try
            {
                var tmpDataAccess = new TmpDataAccess();
                if (cmbRosters.SelectedIndex == -1)
                {
                    MessageBox.Show(@"Please select a roster");
                    return;
                }
                if (cmbRosterStartMonth.SelectedIndex == -1)
                {
                    MessageBox.Show(@"Please select a roster date");
                    return;
                }

                var roster = (Roster) cmbRosters.SelectedItem;
                var rosterDate = (RosterDate) cmbRosterStartMonth.SelectedItem;


                var periods = numScheduleMonths.Value;
                if (radDuplicateMonths.Checked)
                {
                    for (var i = 0; i < periods; i++)
                    {
                        var startDate = dtDuplicateScheduleStartDate.Value;
                        if (i > 0)
                        {
                            var tempDate = startDate.AddMonths(i);
                            startDate = new DateTime(tempDate.Year, tempDate.Month, 1);
                        }
                        var monthSchedule = rosterDate.CreateMonthSchedule(startDate);
                        CheckForDuplicateRosterDate(monthSchedule, roster.Code);

                        tmpDataAccess.CreateTmpRosterDate(monthSchedule);
                    }
                }
                else
                {
                    var startDate = dtDuplicateScheduleStartDate.Value;
                    var monthSchedule = rosterDate.CreateWeekSchedule(startDate, (short) periods);
                    CheckForDuplicateRosterDate(monthSchedule, roster.Code);
                    tmpDataAccess.CreateTmpRosterDate(monthSchedule);
                }

                MessageBox.Show(@"Success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radDuplicateMonths_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DuplicateMonths = radDuplicateMonths.Checked;
            Settings.Default.Save();
        }

        private void radDuplicateWeeks_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DuplicateMonths = !radDuplicateWeeks.Checked;
            Settings.Default.Save();
        }

        private void chkChangeEmployeeNumber_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.UpdateEmployeeNumber = chkChangeEmployeeNumber.Checked;
            Settings.Default.Save();
        }

        private void txtToEmailAddress2_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ToEmailAddress2 = txtToEmailAddress2.Text;
            Settings.Default.Save();
        }

        private void txtToEmailAddress3_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ToEmailAddress3 = txtToEmailAddress3.Text;
            Settings.Default.Save();
        }

        private void txtToEmailAddress4_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ToEmailAddress4 = txtToEmailAddress4.Text;
            Settings.Default.Save();
        }

        private void txtToEmailAddress5_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ToEmailAddress5 = txtToEmailAddress5.Text;
            Settings.Default.Save();
        }

        private void txtToEmailAddress6_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ToEmailAddress6 = txtToEmailAddress6.Text;
            Settings.Default.Save();
        }

        private void txtIntegrityExport_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.IntegrityExportLocation = txtIntegrityExport.Text;
            Settings.Default.Save();
        }

        private void txtNetworkLocation_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.TmpNetworkLocation = txtNetworkLocation.Text;
            Settings.Default.Save();
        }

        private void chkCalc0_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Calc0 = chkCalc0.Checked;
            Settings.Default.Save();
        }

        private void chkCalc1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Calc1 = chkCalc1.Checked;
            Settings.Default.Save();
        }

        private void chkCalc2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Calc2 = chkCalc2.Checked;
            Settings.Default.Save();
        }

        private void chkCalc3_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Calc3 = chkCalc3.Checked;
            Settings.Default.Save();
        }

        private void chkCalc4_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Calc4 = chkCalc4.Checked;
            Settings.Default.Save();
        }

        private void btnBrowseIntegrity_Click(object sender, EventArgs e)
        {
            var openDlg = new SaveFileDialog
            {
                FileName = "Payroll.txt",
                Filter = @"txt Files (*.txt)|*.txt|All files (*.*)|*.*",
                AddExtension = true
            };
            if (openDlg.ShowDialog() != DialogResult.OK)
                return;

            txtIntegrityExport.Text = openDlg.FileName;
            Settings.Default.IntegrityExportLocation = openDlg.FileName;
            Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadDepartments(cmbccFrom, cmbccTo);
        }

        private static void LoadDepartments(ComboBox deptFrom, ComboBox deptTo)
        {
            try
            {
                if (Settings.Default.TMPDatabaseLocation == "")
                    return;

                var da = new TmpDataAccess();
                var deps = da.GetDepartments();
                foreach (var department in deps)
                {
                    deptFrom.Items.Add(new ComboBoxItemDepartment
                    {
                        ItemObject = department
                    });
                    deptTo.Items.Add(new ComboBoxItemDepartment
                    {
                        ItemObject = department
                    });
                }

                if (deptFrom.Items.Count > 0)
                    deptFrom.SelectedIndex = 0;

                if (deptTo.Items.Count > 0)
                    deptTo.SelectedIndex = deptTo.Items.Count - 1;
            }
            catch
            {
                //do nothing                
            }
        }

        private void chkEnableExcelExport_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.EnableExcelExport = chkEnableExcelExport.Checked;
            Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            txtEbExcelLocation.Text = folderBrowserDialog.SelectedPath;
            Settings.Default.EbExcelExportLocation = folderBrowserDialog.SelectedPath;
            Settings.Default.Save();
        }

        private void chkEnableIntegrityExport_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.EnableIntegrityExport = chkEnableIntegrityExport.Checked;
            Settings.Default.Save();
        }

        private void chkEnableTmpExport_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.EnableTmpExport = chkEnableTmpExport.Checked;
            Settings.Default.Save();
        }

        private void chkEnableFilters_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableFilters.Checked)
                LoadDepartments(cmbccFrom, cmbccTo);
        }

        private void tabpgTmpExport_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            Settings.Default.RunExeAfterExportEnabledAuto = chkRunExeAuto.Checked;
            Settings.Default.Save();
        }

        private void txtRunnerExe_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ExeDirectoryAuto = txtRunnerExe.Text;
            Settings.Default.Save();
        }

        private void btnBrowseExe_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog
            {
                Filter = @"exe Files (*.exe)|*.exe|All files (*.*)|*.*",
                AddExtension = true
            };
            if (openDlg.ShowDialog() != DialogResult.OK)
                return;

            txtRunnerExe.Text = openDlg.FileName;
        }

        private void chkRunnerTmp_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.RunExeAfterExportEnabled = chkRunnerTmp.Checked;
            Settings.Default.Save();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.ExeDirectoryRun = txtExePath.Text;
            Settings.Default.Save();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog
            {
                Filter = @"exe Files (*.exe)|*.exe|All files (*.*)|*.*",
                AddExtension = true
            };
            if (openDlg.ShowDialog() != DialogResult.OK)
                return;

            txtExePath.Text = openDlg.FileName;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            if (_bgWorker != null && _bgWorker.IsBusy)
            {
                MessageBox.Show("An operation is already in progress", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            Sync();
        }

        private void Sync()
        {
            _bgWorker = new BackgroundWorker {WorkerReportsProgress = true};

            SyncImpro.OnProgressHandler += (sender, args) =>
            {
                _bgWorker.ReportProgress(0, args);
            };
            _bgWorker.DoWork += (sender, args) =>
            {
                _syncEngine.Authorized = false;
                SaveDepartments();
                SyncImpro.StartSync();
            };
            _bgWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            _bgWorker.RunWorkerCompleted += (sender, args) =>
            {
                _syncEngine.Authorized = true;
                if (args.Error != null)
                {
                    ShowError(args.Error);
                    return;
                }
                MessageBox.Show("Sync completed successfully", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };
            //Run worker
            _bgWorker.RunWorkerAsync();
        }

        private static DateTime GetHighestDt(DateTime dateTimeCurrent)
        {
            return new DateTime(
                dateTimeCurrent.Year,
                dateTimeCurrent.Month,
                dateTimeCurrent.Day,
                23,
                59,
                59);
        }

        private void chkExcelFilterEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcelFilterEnable.Checked)
                LoadDepartments(cmbExcelBranchFrom, cmbExcelBranchTo);
        }
    }
}
