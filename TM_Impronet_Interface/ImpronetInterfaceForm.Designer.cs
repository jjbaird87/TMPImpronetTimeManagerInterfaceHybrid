namespace TM_Impronet_Interface
{
    partial class ImpronetInterfaceForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnBrowseFbDatabase = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFbDatabasePath = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.chkEnableTimer = new System.Windows.Forms.CheckBox();
            this.tmrSeconds = new System.Windows.Forms.Timer(this.components);
            this.tabOverview = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtNetworkLocation = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtTmpDatabasePath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radFirebird = new System.Windows.Forms.RadioButton();
            this.txtSqlConnectionString = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.radSql = new System.Windows.Forms.RadioButton();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabCtrlExport = new System.Windows.Forms.TabControl();
            this.tabpgTmpExport = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.txtExePath = new System.Windows.Forms.TextBox();
            this.chkRunnerTmp = new System.Windows.Forms.CheckBox();
            this.chkEnableTmpExport = new System.Windows.Forms.CheckBox();
            this.radUseDepartmentMapping = new System.Windows.Forms.RadioButton();
            this.radUseStandardMapping = new System.Windows.Forms.RadioButton();
            this.tabctrlMappings = new System.Windows.Forms.TabControl();
            this.tabpgStandardMapping = new System.Windows.Forms.TabPage();
            this.btnFetchReaders = new System.Windows.Forms.Button();
            this.gridMappings = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabpgDepartmentMapping = new System.Windows.Forms.TabPage();
            this.btnDepMappingsDeselectAll = new System.Windows.Forms.Button();
            this.btnDepMappingsSelectAll = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.treeDepMappings = new System.Windows.Forms.TreeView();
            this.btnDepFetchMappings = new System.Windows.Forms.Button();
            this.btnDepMappingsRefresh = new System.Windows.Forms.Button();
            this.btnDepMappingsSave = new System.Windows.Forms.Button();
            this.txtDepMappingAccessControlCode = new System.Windows.Forms.TextBox();
            this.txtDepMappingTimeAndAttendanceCode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabpgIntegrityExport = new System.Windows.Forms.TabPage();
            this.chkEnableIntegrityExport = new System.Windows.Forms.CheckBox();
            this.grpIntegrityFilters = new System.Windows.Forms.GroupBox();
            this.btnRefreshFilterIntegrity = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.cmbccTo = new System.Windows.Forms.ComboBox();
            this.cmbccFrom = new System.Windows.Forms.ComboBox();
            this.chkEnableFilters = new System.Windows.Forms.CheckBox();
            this.btnBrowseIntegrity = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.txtIntegrityExport = new System.Windows.Forms.TextBox();
            this.dtIntegrityEnd = new System.Windows.Forms.DateTimePicker();
            this.dtIntegrityStart = new System.Windows.Forms.DateTimePicker();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.chkCalc1 = new System.Windows.Forms.CheckBox();
            this.chkCalc2 = new System.Windows.Forms.CheckBox();
            this.chkCalc3 = new System.Windows.Forms.CheckBox();
            this.chkCalc4 = new System.Windows.Forms.CheckBox();
            this.chkCalc0 = new System.Windows.Forms.CheckBox();
            this.tabpgExcelExport = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbExcelBranchTo = new System.Windows.Forms.ComboBox();
            this.cmbExcelBranchFrom = new System.Windows.Forms.ComboBox();
            this.chkExcelFilterEnable = new System.Windows.Forms.CheckBox();
            this.chkEnableExcelExport = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.txtEbExcelLocation = new System.Windows.Forms.TextBox();
            this.dtEbExcelTo = new System.Windows.Forms.DateTimePicker();
            this.dtEbExcelFrom = new System.Windows.Forms.DateTimePicker();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.btnSync = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.chkChangeEmployeeNumber = new System.Windows.Forms.CheckBox();
            this.chkAlwaysSync = new System.Windows.Forms.CheckBox();
            this.chkSyncAccessControlDevices = new System.Windows.Forms.CheckBox();
            this.chkSynEmployees = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnDeselctAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnRefreshDepartments = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.chkDepartments = new System.Windows.Forms.CheckedListBox();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.txtToEmailAddress6 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txtToEmailAddress2 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtToEmailAddress3 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtToEmailAddress4 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtToEmailAddress5 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnTestEmail = new System.Windows.Forms.Button();
            this.txtToEmailAddress1 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtSmtpPort = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtSmtpHost = new System.Windows.Forms.TextBox();
            this.chkEnableEmail = new System.Windows.Forms.CheckBox();
            this.chkSSL = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.radDuplicateWeeks = new System.Windows.Forms.RadioButton();
            this.radDuplicateMonths = new System.Windows.Forms.RadioButton();
            this.label29 = new System.Windows.Forms.Label();
            this.dtDuplicateScheduleStartDate = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.numScheduleMonths = new System.Windows.Forms.NumericUpDown();
            this.btnDuplicateRoster = new System.Windows.Forms.Button();
            this.btnGetRosters = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbRosterStartMonth = new System.Windows.Forms.ComboBox();
            this.cmbRosters = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tabpgEngine = new System.Windows.Forms.TabPage();
            this.tabCtrlEngines = new System.Windows.Forms.TabControl();
            this.tabpgExportRunner = new System.Windows.Forms.TabPage();
            this.chkRunExeAuto = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBrowseExe = new System.Windows.Forms.Button();
            this.txtRunnerExe = new System.Windows.Forms.TextBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabpgSyncEngine = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSyncCountDown = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSyncInterval = new System.Windows.Forms.TextBox();
            this.chkSyncTimerEnabled = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabCtrlExport.SuspendLayout();
            this.tabpgTmpExport.SuspendLayout();
            this.tabctrlMappings.SuspendLayout();
            this.tabpgStandardMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMappings)).BeginInit();
            this.tabpgDepartmentMapping.SuspendLayout();
            this.tabpgIntegrityExport.SuspendLayout();
            this.grpIntegrityFilters.SuspendLayout();
            this.tabpgExcelExport.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScheduleMonths)).BeginInit();
            this.tabpgEngine.SuspendLayout();
            this.tabCtrlEngines.SuspendLayout();
            this.tabpgExportRunner.SuspendLayout();
            this.tabpgSyncEngine.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(11, 81);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(111, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Test Connection";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnBrowseFbDatabase
            // 
            this.btnBrowseFbDatabase.Enabled = false;
            this.btnBrowseFbDatabase.Location = new System.Drawing.Point(438, 55);
            this.btnBrowseFbDatabase.Name = "btnBrowseFbDatabase";
            this.btnBrowseFbDatabase.Size = new System.Drawing.Size(28, 20);
            this.btnBrowseFbDatabase.TabIndex = 8;
            this.btnBrowseFbDatabase.Text = "...";
            this.btnBrowseFbDatabase.UseVisualStyleBackColor = true;
            this.btnBrowseFbDatabase.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Database Path:";
            // 
            // txtFbDatabasePath
            // 
            this.txtFbDatabasePath.Enabled = false;
            this.txtFbDatabasePath.Location = new System.Drawing.Point(11, 55);
            this.txtFbDatabasePath.Name = "txtFbDatabasePath";
            this.txtFbDatabasePath.Size = new System.Drawing.Size(421, 20);
            this.txtFbDatabasePath.TabIndex = 6;
            this.txtFbDatabasePath.TextChanged += new System.EventHandler(this.txtDatabasePath_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(96, 23);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Start Export";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 530);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1036, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Countdown:";
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(7, 367);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(194, 39);
            this.lblCountdown.TabIndex = 14;
            this.lblCountdown.Text = "0 second(s)";
            // 
            // chkEnableTimer
            // 
            this.chkEnableTimer.AutoSize = true;
            this.chkEnableTimer.Location = new System.Drawing.Point(13, 16);
            this.chkEnableTimer.Name = "chkEnableTimer";
            this.chkEnableTimer.Size = new System.Drawing.Size(65, 17);
            this.chkEnableTimer.TabIndex = 13;
            this.chkEnableTimer.Text = "Enabled";
            this.chkEnableTimer.UseVisualStyleBackColor = true;
            this.chkEnableTimer.CheckedChanged += new System.EventHandler(this.chkEnableTimer_CheckedChanged);
            // 
            // tmrSeconds
            // 
            this.tmrSeconds.Interval = 1000;
            this.tmrSeconds.Tick += new System.EventHandler(this.tmrSeconds_Tick);
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.Add(this.tabPage4);
            this.tabOverview.Controls.Add(this.tabPage7);
            this.tabOverview.Controls.Add(this.tabPage8);
            this.tabOverview.Controls.Add(this.tabPage6);
            this.tabOverview.Controls.Add(this.tabpgEngine);
            this.tabOverview.Location = new System.Drawing.Point(12, 12);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.SelectedIndex = 0;
            this.tabOverview.Size = new System.Drawing.Size(1016, 515);
            this.tabOverview.TabIndex = 21;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1008, 489);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Database Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.txtNetworkLocation);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.txtTmpDatabasePath);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(6, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(990, 147);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Manager Platinum Database";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(8, 69);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(87, 13);
            this.label43.TabIndex = 14;
            this.label43.Text = "Network location";
            // 
            // txtNetworkLocation
            // 
            this.txtNetworkLocation.Location = new System.Drawing.Point(8, 85);
            this.txtNetworkLocation.Name = "txtNetworkLocation";
            this.txtNetworkLocation.Size = new System.Drawing.Size(790, 20);
            this.txtNetworkLocation.TabIndex = 13;
            this.txtNetworkLocation.TextChanged += new System.EventHandler(this.txtNetworkLocation_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Test Connection";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtTmpDatabasePath
            // 
            this.txtTmpDatabasePath.Location = new System.Drawing.Point(8, 46);
            this.txtTmpDatabasePath.Name = "txtTmpDatabasePath";
            this.txtTmpDatabasePath.Size = new System.Drawing.Size(790, 20);
            this.txtTmpDatabasePath.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(804, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 20);
            this.button2.TabIndex = 11;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Database Path:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radFirebird);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtSqlConnectionString);
            this.groupBox1.Controls.Add(this.txtFbDatabasePath);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnBrowseFbDatabase);
            this.groupBox1.Controls.Add(this.radSql);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(996, 116);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impro Database";
            // 
            // radFirebird
            // 
            this.radFirebird.AutoSize = true;
            this.radFirebird.Location = new System.Drawing.Point(9, 19);
            this.radFirebird.Name = "radFirebird";
            this.radFirebird.Size = new System.Drawing.Size(108, 17);
            this.radFirebird.TabIndex = 12;
            this.radFirebird.Text = "Firebird Database";
            this.radFirebird.UseVisualStyleBackColor = true;
            this.radFirebird.CheckedChanged += new System.EventHandler(this.radFirebird_CheckedChanged);
            // 
            // txtSqlConnectionString
            // 
            this.txtSqlConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSqlConnectionString.Enabled = false;
            this.txtSqlConnectionString.Location = new System.Drawing.Point(548, 55);
            this.txtSqlConnectionString.Name = "txtSqlConnectionString";
            this.txtSqlConnectionString.Size = new System.Drawing.Size(442, 20);
            this.txtSqlConnectionString.TabIndex = 15;
            this.txtSqlConnectionString.TextChanged += new System.EventHandler(this.txtSqlConnectionString_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(545, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "SQL Connection String:";
            // 
            // radSql
            // 
            this.radSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radSql.AutoSize = true;
            this.radSql.Location = new System.Drawing.Point(548, 15);
            this.radSql.Name = "radSql";
            this.radSql.Size = new System.Drawing.Size(95, 17);
            this.radSql.TabIndex = 13;
            this.radSql.Text = "SQL Database";
            this.radSql.UseVisualStyleBackColor = true;
            this.radSql.CheckedChanged += new System.EventHandler(this.radSql_CheckedChanged);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tabCtrlExport);
            this.tabPage7.Controls.Add(this.btnStart);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1008, 489);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Export Tools";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabCtrlExport
            // 
            this.tabCtrlExport.Controls.Add(this.tabpgTmpExport);
            this.tabCtrlExport.Controls.Add(this.tabpgIntegrityExport);
            this.tabCtrlExport.Controls.Add(this.tabpgExcelExport);
            this.tabCtrlExport.Location = new System.Drawing.Point(6, 39);
            this.tabCtrlExport.Name = "tabCtrlExport";
            this.tabCtrlExport.SelectedIndex = 0;
            this.tabCtrlExport.Size = new System.Drawing.Size(994, 444);
            this.tabCtrlExport.TabIndex = 17;
            // 
            // tabpgTmpExport
            // 
            this.tabpgTmpExport.Controls.Add(this.label5);
            this.tabpgTmpExport.Controls.Add(this.button6);
            this.tabpgTmpExport.Controls.Add(this.txtExePath);
            this.tabpgTmpExport.Controls.Add(this.chkRunnerTmp);
            this.tabpgTmpExport.Controls.Add(this.chkEnableTmpExport);
            this.tabpgTmpExport.Controls.Add(this.radUseDepartmentMapping);
            this.tabpgTmpExport.Controls.Add(this.radUseStandardMapping);
            this.tabpgTmpExport.Controls.Add(this.tabctrlMappings);
            this.tabpgTmpExport.Controls.Add(this.btnBrowseOutput);
            this.tabpgTmpExport.Controls.Add(this.label4);
            this.tabpgTmpExport.Controls.Add(this.txtOutputPath);
            this.tabpgTmpExport.Controls.Add(this.label2);
            this.tabpgTmpExport.Controls.Add(this.dtToDate);
            this.tabpgTmpExport.Controls.Add(this.dtFromDate);
            this.tabpgTmpExport.Controls.Add(this.label1);
            this.tabpgTmpExport.Location = new System.Drawing.Point(4, 22);
            this.tabpgTmpExport.Name = "tabpgTmpExport";
            this.tabpgTmpExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgTmpExport.Size = new System.Drawing.Size(986, 418);
            this.tabpgTmpExport.TabIndex = 0;
            this.tabpgTmpExport.Text = "Impro TMP Export";
            this.tabpgTmpExport.UseVisualStyleBackColor = true;
            this.tabpgTmpExport.Click += new System.EventHandler(this.tabpgTmpExport_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Exe Path:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(282, 257);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(28, 20);
            this.button6.TabIndex = 51;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtExePath
            // 
            this.txtExePath.Location = new System.Drawing.Point(9, 257);
            this.txtExePath.Name = "txtExePath";
            this.txtExePath.Size = new System.Drawing.Size(267, 20);
            this.txtExePath.TabIndex = 49;
            this.txtExePath.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // chkRunnerTmp
            // 
            this.chkRunnerTmp.AutoSize = true;
            this.chkRunnerTmp.Location = new System.Drawing.Point(9, 203);
            this.chkRunnerTmp.Name = "chkRunnerTmp";
            this.chkRunnerTmp.Size = new System.Drawing.Size(125, 17);
            this.chkRunnerTmp.TabIndex = 48;
            this.chkRunnerTmp.Text = "Run Exe After Export";
            this.chkRunnerTmp.UseVisualStyleBackColor = true;
            this.chkRunnerTmp.CheckedChanged += new System.EventHandler(this.chkRunnerTmp_CheckedChanged);
            // 
            // chkEnableTmpExport
            // 
            this.chkEnableTmpExport.AutoSize = true;
            this.chkEnableTmpExport.Location = new System.Drawing.Point(9, 17);
            this.chkEnableTmpExport.Name = "chkEnableTmpExport";
            this.chkEnableTmpExport.Size = new System.Drawing.Size(65, 17);
            this.chkEnableTmpExport.TabIndex = 47;
            this.chkEnableTmpExport.Text = "Enabled";
            this.chkEnableTmpExport.UseVisualStyleBackColor = true;
            this.chkEnableTmpExport.CheckedChanged += new System.EventHandler(this.chkEnableTmpExport_CheckedChanged);
            // 
            // radUseDepartmentMapping
            // 
            this.radUseDepartmentMapping.AutoSize = true;
            this.radUseDepartmentMapping.Location = new System.Drawing.Point(450, 6);
            this.radUseDepartmentMapping.Name = "radUseDepartmentMapping";
            this.radUseDepartmentMapping.Size = new System.Drawing.Size(124, 17);
            this.radUseDepartmentMapping.TabIndex = 46;
            this.radUseDepartmentMapping.TabStop = true;
            this.radUseDepartmentMapping.Text = "Department Mapping";
            this.radUseDepartmentMapping.UseVisualStyleBackColor = true;
            this.radUseDepartmentMapping.CheckedChanged += new System.EventHandler(this.radUseDepartmentMapping_CheckedChanged);
            // 
            // radUseStandardMapping
            // 
            this.radUseStandardMapping.AutoSize = true;
            this.radUseStandardMapping.Location = new System.Drawing.Point(327, 6);
            this.radUseStandardMapping.Name = "radUseStandardMapping";
            this.radUseStandardMapping.Size = new System.Drawing.Size(112, 17);
            this.radUseStandardMapping.TabIndex = 45;
            this.radUseStandardMapping.TabStop = true;
            this.radUseStandardMapping.Text = "Standard Mapping";
            this.radUseStandardMapping.UseVisualStyleBackColor = true;
            this.radUseStandardMapping.CheckedChanged += new System.EventHandler(this.radUseStandardMapping_CheckedChanged);
            // 
            // tabctrlMappings
            // 
            this.tabctrlMappings.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabctrlMappings.Controls.Add(this.tabpgStandardMapping);
            this.tabctrlMappings.Controls.Add(this.tabpgDepartmentMapping);
            this.tabctrlMappings.Location = new System.Drawing.Point(327, 29);
            this.tabctrlMappings.Name = "tabctrlMappings";
            this.tabctrlMappings.SelectedIndex = 0;
            this.tabctrlMappings.Size = new System.Drawing.Size(651, 383);
            this.tabctrlMappings.TabIndex = 44;
            // 
            // tabpgStandardMapping
            // 
            this.tabpgStandardMapping.Controls.Add(this.btnFetchReaders);
            this.tabpgStandardMapping.Controls.Add(this.gridMappings);
            this.tabpgStandardMapping.Controls.Add(this.btnSave);
            this.tabpgStandardMapping.Controls.Add(this.btnRefresh);
            this.tabpgStandardMapping.Location = new System.Drawing.Point(4, 25);
            this.tabpgStandardMapping.Name = "tabpgStandardMapping";
            this.tabpgStandardMapping.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgStandardMapping.Size = new System.Drawing.Size(643, 354);
            this.tabpgStandardMapping.TabIndex = 0;
            this.tabpgStandardMapping.Text = "tabPage6";
            this.tabpgStandardMapping.UseVisualStyleBackColor = true;
            // 
            // btnFetchReaders
            // 
            this.btnFetchReaders.Location = new System.Drawing.Point(6, 6);
            this.btnFetchReaders.Name = "btnFetchReaders";
            this.btnFetchReaders.Size = new System.Drawing.Size(75, 23);
            this.btnFetchReaders.TabIndex = 12;
            this.btnFetchReaders.Text = "Fetch";
            this.btnFetchReaders.UseVisualStyleBackColor = true;
            this.btnFetchReaders.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridMappings
            // 
            this.gridMappings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMappings.Location = new System.Drawing.Point(6, 35);
            this.gridMappings.Name = "gridMappings";
            this.gridMappings.Size = new System.Drawing.Size(631, 313);
            this.gridMappings.TabIndex = 20;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(87, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(168, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabpgDepartmentMapping
            // 
            this.tabpgDepartmentMapping.Controls.Add(this.btnDepMappingsDeselectAll);
            this.tabpgDepartmentMapping.Controls.Add(this.btnDepMappingsSelectAll);
            this.tabpgDepartmentMapping.Controls.Add(this.label17);
            this.tabpgDepartmentMapping.Controls.Add(this.treeDepMappings);
            this.tabpgDepartmentMapping.Controls.Add(this.btnDepFetchMappings);
            this.tabpgDepartmentMapping.Controls.Add(this.btnDepMappingsRefresh);
            this.tabpgDepartmentMapping.Controls.Add(this.btnDepMappingsSave);
            this.tabpgDepartmentMapping.Controls.Add(this.txtDepMappingAccessControlCode);
            this.tabpgDepartmentMapping.Controls.Add(this.txtDepMappingTimeAndAttendanceCode);
            this.tabpgDepartmentMapping.Controls.Add(this.label16);
            this.tabpgDepartmentMapping.Controls.Add(this.label15);
            this.tabpgDepartmentMapping.Location = new System.Drawing.Point(4, 25);
            this.tabpgDepartmentMapping.Name = "tabpgDepartmentMapping";
            this.tabpgDepartmentMapping.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgDepartmentMapping.Size = new System.Drawing.Size(643, 354);
            this.tabpgDepartmentMapping.TabIndex = 1;
            this.tabpgDepartmentMapping.Text = "tabPage7";
            this.tabpgDepartmentMapping.UseVisualStyleBackColor = true;
            // 
            // btnDepMappingsDeselectAll
            // 
            this.btnDepMappingsDeselectAll.Location = new System.Drawing.Point(522, 65);
            this.btnDepMappingsDeselectAll.Name = "btnDepMappingsDeselectAll";
            this.btnDepMappingsDeselectAll.Size = new System.Drawing.Size(111, 23);
            this.btnDepMappingsDeselectAll.TabIndex = 10;
            this.btnDepMappingsDeselectAll.Text = "Deselect All";
            this.btnDepMappingsDeselectAll.UseVisualStyleBackColor = true;
            this.btnDepMappingsDeselectAll.Click += new System.EventHandler(this.btnDepMappingsDeselectAll_Click);
            // 
            // btnDepMappingsSelectAll
            // 
            this.btnDepMappingsSelectAll.Location = new System.Drawing.Point(412, 65);
            this.btnDepMappingsSelectAll.Name = "btnDepMappingsSelectAll";
            this.btnDepMappingsSelectAll.Size = new System.Drawing.Size(102, 23);
            this.btnDepMappingsSelectAll.TabIndex = 9;
            this.btnDepMappingsSelectAll.Text = "Select All";
            this.btnDepMappingsSelectAll.UseVisualStyleBackColor = true;
            this.btnDepMappingsSelectAll.Click += new System.EventHandler(this.btnDepMappingsSelectAll_Click);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 55);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(323, 31);
            this.label17.TabIndex = 8;
            this.label17.Text = "Select the time and attendance devices per department: (Unselected devices are tr" +
    "eated as access control devices)";
            // 
            // treeDepMappings
            // 
            this.treeDepMappings.Location = new System.Drawing.Point(6, 92);
            this.treeDepMappings.Name = "treeDepMappings";
            this.treeDepMappings.Size = new System.Drawing.Size(627, 256);
            this.treeDepMappings.TabIndex = 7;
            this.treeDepMappings.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeDepMappings_AfterCheck);
            // 
            // btnDepFetchMappings
            // 
            this.btnDepFetchMappings.Location = new System.Drawing.Point(6, 11);
            this.btnDepFetchMappings.Name = "btnDepFetchMappings";
            this.btnDepFetchMappings.Size = new System.Drawing.Size(101, 23);
            this.btnDepFetchMappings.TabIndex = 6;
            this.btnDepFetchMappings.Text = "Fetch Mappings";
            this.btnDepFetchMappings.UseVisualStyleBackColor = true;
            this.btnDepFetchMappings.Click += new System.EventHandler(this.btnDepFetchMappings_Click);
            // 
            // btnDepMappingsRefresh
            // 
            this.btnDepMappingsRefresh.Location = new System.Drawing.Point(220, 11);
            this.btnDepMappingsRefresh.Name = "btnDepMappingsRefresh";
            this.btnDepMappingsRefresh.Size = new System.Drawing.Size(101, 23);
            this.btnDepMappingsRefresh.TabIndex = 5;
            this.btnDepMappingsRefresh.Text = "Refresh";
            this.btnDepMappingsRefresh.UseVisualStyleBackColor = true;
            // 
            // btnDepMappingsSave
            // 
            this.btnDepMappingsSave.Location = new System.Drawing.Point(113, 11);
            this.btnDepMappingsSave.Name = "btnDepMappingsSave";
            this.btnDepMappingsSave.Size = new System.Drawing.Size(101, 23);
            this.btnDepMappingsSave.TabIndex = 4;
            this.btnDepMappingsSave.Text = "Save";
            this.btnDepMappingsSave.UseVisualStyleBackColor = true;
            this.btnDepMappingsSave.Click += new System.EventHandler(this.btnDepMappingsSave_Click);
            // 
            // txtDepMappingAccessControlCode
            // 
            this.txtDepMappingAccessControlCode.Location = new System.Drawing.Point(517, 39);
            this.txtDepMappingAccessControlCode.Name = "txtDepMappingAccessControlCode";
            this.txtDepMappingAccessControlCode.Size = new System.Drawing.Size(116, 20);
            this.txtDepMappingAccessControlCode.TabIndex = 3;
            this.txtDepMappingAccessControlCode.TextChanged += new System.EventHandler(this.txtDepMappingAccessControlCode_TextChanged);
            // 
            // txtDepMappingTimeAndAttendanceCode
            // 
            this.txtDepMappingTimeAndAttendanceCode.Location = new System.Drawing.Point(517, 13);
            this.txtDepMappingTimeAndAttendanceCode.Name = "txtDepMappingTimeAndAttendanceCode";
            this.txtDepMappingTimeAndAttendanceCode.Size = new System.Drawing.Size(116, 20);
            this.txtDepMappingTimeAndAttendanceCode.TabIndex = 2;
            this.txtDepMappingTimeAndAttendanceCode.TextChanged += new System.EventHandler(this.txtDepMappingTimeAndAttendanceCode_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(368, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(146, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Access Control Device Code:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(339, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(175, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Time and Attendance device Code:";
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(282, 163);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(28, 21);
            this.btnBrowseOutput.TabIndex = 43;
            this.btnBrowseOutput.Text = "...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "*.dat Output Path:";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(9, 164);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(267, 20);
            this.txtOutputPath.TabIndex = 41;
            this.txtOutputPath.TextChanged += new System.EventHandler(this.txtOutputPath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "To Date:";
            // 
            // dtToDate
            // 
            this.dtToDate.Location = new System.Drawing.Point(9, 114);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(209, 20);
            this.dtToDate.TabIndex = 33;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Location = new System.Drawing.Point(9, 70);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(209, 20);
            this.dtFromDate.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "From Date:";
            // 
            // tabpgIntegrityExport
            // 
            this.tabpgIntegrityExport.Controls.Add(this.chkEnableIntegrityExport);
            this.tabpgIntegrityExport.Controls.Add(this.grpIntegrityFilters);
            this.tabpgIntegrityExport.Controls.Add(this.btnBrowseIntegrity);
            this.tabpgIntegrityExport.Controls.Add(this.label40);
            this.tabpgIntegrityExport.Controls.Add(this.txtIntegrityExport);
            this.tabpgIntegrityExport.Controls.Add(this.dtIntegrityEnd);
            this.tabpgIntegrityExport.Controls.Add(this.dtIntegrityStart);
            this.tabpgIntegrityExport.Controls.Add(this.label41);
            this.tabpgIntegrityExport.Controls.Add(this.label42);
            this.tabpgIntegrityExport.Controls.Add(this.label37);
            this.tabpgIntegrityExport.Controls.Add(this.chkCalc1);
            this.tabpgIntegrityExport.Controls.Add(this.chkCalc2);
            this.tabpgIntegrityExport.Controls.Add(this.chkCalc3);
            this.tabpgIntegrityExport.Controls.Add(this.chkCalc4);
            this.tabpgIntegrityExport.Controls.Add(this.chkCalc0);
            this.tabpgIntegrityExport.Location = new System.Drawing.Point(4, 22);
            this.tabpgIntegrityExport.Name = "tabpgIntegrityExport";
            this.tabpgIntegrityExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgIntegrityExport.Size = new System.Drawing.Size(986, 418);
            this.tabpgIntegrityExport.TabIndex = 3;
            this.tabpgIntegrityExport.Text = "Integrity Export";
            this.tabpgIntegrityExport.UseVisualStyleBackColor = true;
            // 
            // chkEnableIntegrityExport
            // 
            this.chkEnableIntegrityExport.AutoSize = true;
            this.chkEnableIntegrityExport.Location = new System.Drawing.Point(11, 16);
            this.chkEnableIntegrityExport.Name = "chkEnableIntegrityExport";
            this.chkEnableIntegrityExport.Size = new System.Drawing.Size(65, 17);
            this.chkEnableIntegrityExport.TabIndex = 48;
            this.chkEnableIntegrityExport.Text = "Enabled";
            this.chkEnableIntegrityExport.UseVisualStyleBackColor = true;
            this.chkEnableIntegrityExport.CheckedChanged += new System.EventHandler(this.chkEnableIntegrityExport_CheckedChanged);
            // 
            // grpIntegrityFilters
            // 
            this.grpIntegrityFilters.Controls.Add(this.btnRefreshFilterIntegrity);
            this.grpIntegrityFilters.Controls.Add(this.label38);
            this.grpIntegrityFilters.Controls.Add(this.label39);
            this.grpIntegrityFilters.Controls.Add(this.cmbccTo);
            this.grpIntegrityFilters.Controls.Add(this.cmbccFrom);
            this.grpIntegrityFilters.Controls.Add(this.chkEnableFilters);
            this.grpIntegrityFilters.Location = new System.Drawing.Point(11, 156);
            this.grpIntegrityFilters.Name = "grpIntegrityFilters";
            this.grpIntegrityFilters.Size = new System.Drawing.Size(354, 138);
            this.grpIntegrityFilters.TabIndex = 27;
            this.grpIntegrityFilters.TabStop = false;
            this.grpIntegrityFilters.Text = "Filters";
            // 
            // btnRefreshFilterIntegrity
            // 
            this.btnRefreshFilterIntegrity.Location = new System.Drawing.Point(273, 15);
            this.btnRefreshFilterIntegrity.Name = "btnRefreshFilterIntegrity";
            this.btnRefreshFilterIntegrity.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshFilterIntegrity.TabIndex = 5;
            this.btnRefreshFilterIntegrity.Text = "Refresh";
            this.btnRefreshFilterIntegrity.UseVisualStyleBackColor = true;
            this.btnRefreshFilterIntegrity.Click += new System.EventHandler(this.button4_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(7, 87);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(60, 13);
            this.label38.TabIndex = 4;
            this.label38.Text = "Branch To:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(7, 43);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(70, 13);
            this.label39.TabIndex = 3;
            this.label39.Text = "Branch From:";
            // 
            // cmbccTo
            // 
            this.cmbccTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbccTo.FormattingEnabled = true;
            this.cmbccTo.Location = new System.Drawing.Point(6, 102);
            this.cmbccTo.Name = "cmbccTo";
            this.cmbccTo.Size = new System.Drawing.Size(342, 21);
            this.cmbccTo.TabIndex = 2;
            // 
            // cmbccFrom
            // 
            this.cmbccFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbccFrom.FormattingEnabled = true;
            this.cmbccFrom.Location = new System.Drawing.Point(6, 63);
            this.cmbccFrom.Name = "cmbccFrom";
            this.cmbccFrom.Size = new System.Drawing.Size(342, 21);
            this.cmbccFrom.TabIndex = 1;
            // 
            // chkEnableFilters
            // 
            this.chkEnableFilters.AutoSize = true;
            this.chkEnableFilters.Location = new System.Drawing.Point(6, 19);
            this.chkEnableFilters.Name = "chkEnableFilters";
            this.chkEnableFilters.Size = new System.Drawing.Size(89, 17);
            this.chkEnableFilters.TabIndex = 0;
            this.chkEnableFilters.Text = "Enable Filters";
            this.chkEnableFilters.UseVisualStyleBackColor = true;
            this.chkEnableFilters.CheckedChanged += new System.EventHandler(this.chkEnableFilters_CheckedChanged);
            // 
            // btnBrowseIntegrity
            // 
            this.btnBrowseIntegrity.Location = new System.Drawing.Point(335, 64);
            this.btnBrowseIntegrity.Name = "btnBrowseIntegrity";
            this.btnBrowseIntegrity.Size = new System.Drawing.Size(30, 20);
            this.btnBrowseIntegrity.TabIndex = 26;
            this.btnBrowseIntegrity.Text = "...";
            this.btnBrowseIntegrity.UseVisualStyleBackColor = true;
            this.btnBrowseIntegrity.Click += new System.EventHandler(this.btnBrowseIntegrity_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(8, 48);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(84, 13);
            this.label40.TabIndex = 25;
            this.label40.Text = "Export Location:";
            // 
            // txtIntegrityExport
            // 
            this.txtIntegrityExport.Location = new System.Drawing.Point(11, 64);
            this.txtIntegrityExport.Name = "txtIntegrityExport";
            this.txtIntegrityExport.Size = new System.Drawing.Size(318, 20);
            this.txtIntegrityExport.TabIndex = 24;
            this.txtIntegrityExport.TextChanged += new System.EventHandler(this.txtIntegrityExport_TextChanged);
            // 
            // dtIntegrityEnd
            // 
            this.dtIntegrityEnd.Location = new System.Drawing.Point(73, 118);
            this.dtIntegrityEnd.Name = "dtIntegrityEnd";
            this.dtIntegrityEnd.Size = new System.Drawing.Size(292, 20);
            this.dtIntegrityEnd.TabIndex = 23;
            // 
            // dtIntegrityStart
            // 
            this.dtIntegrityStart.Location = new System.Drawing.Point(73, 92);
            this.dtIntegrityStart.Name = "dtIntegrityStart";
            this.dtIntegrityStart.Size = new System.Drawing.Size(292, 20);
            this.dtIntegrityStart.TabIndex = 22;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(8, 124);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(49, 13);
            this.label41.TabIndex = 21;
            this.label41.Text = "To Date:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(8, 98);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(59, 13);
            this.label42.TabIndex = 20;
            this.label42.Text = "From Date:";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(643, 19);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(171, 17);
            this.label37.TabIndex = 19;
            this.label37.Text = "Integrity Export Fields:";
            // 
            // chkCalc1
            // 
            this.chkCalc1.AutoSize = true;
            this.chkCalc1.Location = new System.Drawing.Point(646, 71);
            this.chkCalc1.Name = "chkCalc1";
            this.chkCalc1.Size = new System.Drawing.Size(107, 17);
            this.chkCalc1.TabIndex = 18;
            this.chkCalc1.Text = "Calc 1 (Overtime)";
            this.chkCalc1.UseVisualStyleBackColor = true;
            this.chkCalc1.CheckedChanged += new System.EventHandler(this.chkCalc1_CheckedChanged);
            // 
            // chkCalc2
            // 
            this.chkCalc2.AutoSize = true;
            this.chkCalc2.Location = new System.Drawing.Point(646, 94);
            this.chkCalc2.Name = "chkCalc2";
            this.chkCalc2.Size = new System.Drawing.Size(99, 17);
            this.chkCalc2.TabIndex = 17;
            this.chkCalc2.Text = "Calc 2 (Double)";
            this.chkCalc2.UseVisualStyleBackColor = true;
            this.chkCalc2.CheckedChanged += new System.EventHandler(this.chkCalc2_CheckedChanged);
            // 
            // chkCalc3
            // 
            this.chkCalc3.AutoSize = true;
            this.chkCalc3.Location = new System.Drawing.Point(646, 117);
            this.chkCalc3.Name = "chkCalc3";
            this.chkCalc3.Size = new System.Drawing.Size(91, 17);
            this.chkCalc3.TabIndex = 16;
            this.chkCalc3.Text = "Calc 3 (Other)";
            this.chkCalc3.UseVisualStyleBackColor = true;
            this.chkCalc3.CheckedChanged += new System.EventHandler(this.chkCalc3_CheckedChanged);
            // 
            // chkCalc4
            // 
            this.chkCalc4.AutoSize = true;
            this.chkCalc4.Location = new System.Drawing.Point(646, 140);
            this.chkCalc4.Name = "chkCalc4";
            this.chkCalc4.Size = new System.Drawing.Size(91, 17);
            this.chkCalc4.TabIndex = 15;
            this.chkCalc4.Text = "Calc 4 (Other)";
            this.chkCalc4.UseVisualStyleBackColor = true;
            this.chkCalc4.CheckedChanged += new System.EventHandler(this.chkCalc4_CheckedChanged);
            // 
            // chkCalc0
            // 
            this.chkCalc0.AutoSize = true;
            this.chkCalc0.Location = new System.Drawing.Point(646, 48);
            this.chkCalc0.Name = "chkCalc0";
            this.chkCalc0.Size = new System.Drawing.Size(124, 17);
            this.chkCalc0.TabIndex = 14;
            this.chkCalc0.Text = "Calc 0 (Normal Time)";
            this.chkCalc0.UseVisualStyleBackColor = true;
            this.chkCalc0.CheckedChanged += new System.EventHandler(this.chkCalc0_CheckedChanged);
            // 
            // tabpgExcelExport
            // 
            this.tabpgExcelExport.Controls.Add(this.groupBox3);
            this.tabpgExcelExport.Controls.Add(this.chkEnableExcelExport);
            this.tabpgExcelExport.Controls.Add(this.button5);
            this.tabpgExcelExport.Controls.Add(this.label44);
            this.tabpgExcelExport.Controls.Add(this.txtEbExcelLocation);
            this.tabpgExcelExport.Controls.Add(this.dtEbExcelTo);
            this.tabpgExcelExport.Controls.Add(this.dtEbExcelFrom);
            this.tabpgExcelExport.Controls.Add(this.label45);
            this.tabpgExcelExport.Controls.Add(this.label46);
            this.tabpgExcelExport.Location = new System.Drawing.Point(4, 22);
            this.tabpgExcelExport.Name = "tabpgExcelExport";
            this.tabpgExcelExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgExcelExport.Size = new System.Drawing.Size(986, 418);
            this.tabpgExcelExport.TabIndex = 4;
            this.tabpgExcelExport.Text = "Excel Export";
            this.tabpgExcelExport.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.cmbExcelBranchTo);
            this.groupBox3.Controls.Add(this.cmbExcelBranchFrom);
            this.groupBox3.Controls.Add(this.chkExcelFilterEnable);
            this.groupBox3.Location = new System.Drawing.Point(11, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(419, 138);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filters";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(338, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Branch To:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(7, 43);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(70, 13);
            this.label33.TabIndex = 3;
            this.label33.Text = "Branch From:";
            // 
            // cmbExcelBranchTo
            // 
            this.cmbExcelBranchTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExcelBranchTo.FormattingEnabled = true;
            this.cmbExcelBranchTo.Location = new System.Drawing.Point(6, 102);
            this.cmbExcelBranchTo.Name = "cmbExcelBranchTo";
            this.cmbExcelBranchTo.Size = new System.Drawing.Size(407, 21);
            this.cmbExcelBranchTo.TabIndex = 2;
            // 
            // cmbExcelBranchFrom
            // 
            this.cmbExcelBranchFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExcelBranchFrom.FormattingEnabled = true;
            this.cmbExcelBranchFrom.Location = new System.Drawing.Point(6, 63);
            this.cmbExcelBranchFrom.Name = "cmbExcelBranchFrom";
            this.cmbExcelBranchFrom.Size = new System.Drawing.Size(407, 21);
            this.cmbExcelBranchFrom.TabIndex = 1;
            // 
            // chkExcelFilterEnable
            // 
            this.chkExcelFilterEnable.AutoSize = true;
            this.chkExcelFilterEnable.Location = new System.Drawing.Point(6, 19);
            this.chkExcelFilterEnable.Name = "chkExcelFilterEnable";
            this.chkExcelFilterEnable.Size = new System.Drawing.Size(89, 17);
            this.chkExcelFilterEnable.TabIndex = 0;
            this.chkExcelFilterEnable.Text = "Enable Filters";
            this.chkExcelFilterEnable.UseVisualStyleBackColor = true;
            this.chkExcelFilterEnable.CheckedChanged += new System.EventHandler(this.chkExcelFilterEnable_CheckedChanged);
            // 
            // chkEnableExcelExport
            // 
            this.chkEnableExcelExport.AutoSize = true;
            this.chkEnableExcelExport.Location = new System.Drawing.Point(11, 13);
            this.chkEnableExcelExport.Name = "chkEnableExcelExport";
            this.chkEnableExcelExport.Size = new System.Drawing.Size(65, 17);
            this.chkEnableExcelExport.TabIndex = 49;
            this.chkEnableExcelExport.Text = "Enabled";
            this.chkEnableExcelExport.UseVisualStyleBackColor = true;
            this.chkEnableExcelExport.CheckedChanged += new System.EventHandler(this.chkEnableExcelExport_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(400, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 20);
            this.button5.TabIndex = 36;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(8, 41);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(84, 13);
            this.label44.TabIndex = 35;
            this.label44.Text = "Export Location:";
            // 
            // txtEbExcelLocation
            // 
            this.txtEbExcelLocation.Location = new System.Drawing.Point(11, 57);
            this.txtEbExcelLocation.Name = "txtEbExcelLocation";
            this.txtEbExcelLocation.Size = new System.Drawing.Size(383, 20);
            this.txtEbExcelLocation.TabIndex = 34;
            // 
            // dtEbExcelTo
            // 
            this.dtEbExcelTo.Location = new System.Drawing.Point(73, 109);
            this.dtEbExcelTo.Name = "dtEbExcelTo";
            this.dtEbExcelTo.Size = new System.Drawing.Size(212, 20);
            this.dtEbExcelTo.TabIndex = 32;
            // 
            // dtEbExcelFrom
            // 
            this.dtEbExcelFrom.Location = new System.Drawing.Point(73, 83);
            this.dtEbExcelFrom.Name = "dtEbExcelFrom";
            this.dtEbExcelFrom.Size = new System.Drawing.Size(212, 20);
            this.dtEbExcelFrom.TabIndex = 31;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(8, 115);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(49, 13);
            this.label45.TabIndex = 30;
            this.label45.Text = "To Date:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(8, 89);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 13);
            this.label46.TabIndex = 29;
            this.label46.Text = "From Date:";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.btnSync);
            this.tabPage8.Controls.Add(this.tabControl2);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1008, 489);
            this.tabPage8.TabIndex = 8;
            this.tabPage8.Text = "Sync Tool";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(6, 6);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(101, 23);
            this.btnSync.TabIndex = 18;
            this.btnSync.Text = "Synchronize now";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage14);
            this.tabControl2.Location = new System.Drawing.Point(6, 35);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(996, 448);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.chkChangeEmployeeNumber);
            this.tabPage10.Controls.Add(this.chkAlwaysSync);
            this.tabPage10.Controls.Add(this.chkSyncAccessControlDevices);
            this.tabPage10.Controls.Add(this.chkSynEmployees);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(988, 422);
            this.tabPage10.TabIndex = 0;
            this.tabPage10.Text = "Settings";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // chkChangeEmployeeNumber
            // 
            this.chkChangeEmployeeNumber.AutoSize = true;
            this.chkChangeEmployeeNumber.Location = new System.Drawing.Point(17, 44);
            this.chkChangeEmployeeNumber.Name = "chkChangeEmployeeNumber";
            this.chkChangeEmployeeNumber.Size = new System.Drawing.Size(326, 17);
            this.chkChangeEmployeeNumber.TabIndex = 25;
            this.chkChangeEmployeeNumber.Text = "Change Employee Number across TMP when changed in Impro";
            this.chkChangeEmployeeNumber.UseVisualStyleBackColor = true;
            this.chkChangeEmployeeNumber.CheckedChanged += new System.EventHandler(this.chkChangeEmployeeNumber_CheckedChanged);
            // 
            // chkAlwaysSync
            // 
            this.chkAlwaysSync.AutoSize = true;
            this.chkAlwaysSync.Location = new System.Drawing.Point(17, 67);
            this.chkAlwaysSync.Name = "chkAlwaysSync";
            this.chkAlwaysSync.Size = new System.Drawing.Size(444, 17);
            this.chkAlwaysSync.TabIndex = 23;
            this.chkAlwaysSync.Text = "Always Sync ALL companies and departments (Departments to Sync Tab will be ignore" +
    "d)";
            this.chkAlwaysSync.UseVisualStyleBackColor = true;
            this.chkAlwaysSync.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkSyncAccessControlDevices
            // 
            this.chkSyncAccessControlDevices.AutoSize = true;
            this.chkSyncAccessControlDevices.Location = new System.Drawing.Point(17, 90);
            this.chkSyncAccessControlDevices.Name = "chkSyncAccessControlDevices";
            this.chkSyncAccessControlDevices.Size = new System.Drawing.Size(164, 17);
            this.chkSyncAccessControlDevices.TabIndex = 22;
            this.chkSyncAccessControlDevices.Text = "Sync Access Control devices";
            this.chkSyncAccessControlDevices.UseVisualStyleBackColor = true;
            this.chkSyncAccessControlDevices.CheckedChanged += new System.EventHandler(this.chkSyncAccessControlDevices_CheckedChanged);
            // 
            // chkSynEmployees
            // 
            this.chkSynEmployees.AutoSize = true;
            this.chkSynEmployees.Location = new System.Drawing.Point(17, 21);
            this.chkSynEmployees.Name = "chkSynEmployees";
            this.chkSynEmployees.Size = new System.Drawing.Size(174, 17);
            this.chkSynEmployees.TabIndex = 21;
            this.chkSynEmployees.Text = "Sync TMP database with Impro";
            this.chkSynEmployees.UseVisualStyleBackColor = true;
            this.chkSynEmployees.CheckedChanged += new System.EventHandler(this.chkSynEmployees_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnDeselctAll);
            this.tabPage3.Controls.Add(this.btnSelectAll);
            this.tabPage3.Controls.Add(this.btnRefreshDepartments);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.chkDepartments);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(988, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Departments to Sync";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnDeselctAll
            // 
            this.btnDeselctAll.Location = new System.Drawing.Point(103, 52);
            this.btnDeselctAll.Name = "btnDeselctAll";
            this.btnDeselctAll.Size = new System.Drawing.Size(91, 23);
            this.btnDeselctAll.TabIndex = 10;
            this.btnDeselctAll.Text = "Deselect All";
            this.btnDeselctAll.UseVisualStyleBackColor = true;
            this.btnDeselctAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(10, 52);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(87, 23);
            this.btnSelectAll.TabIndex = 9;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnRefreshDepartments
            // 
            this.btnRefreshDepartments.Location = new System.Drawing.Point(10, 10);
            this.btnRefreshDepartments.Name = "btnRefreshDepartments";
            this.btnRefreshDepartments.Size = new System.Drawing.Size(87, 23);
            this.btnRefreshDepartments.TabIndex = 8;
            this.btnRefreshDepartments.Text = "Refresh";
            this.btnRefreshDepartments.UseVisualStyleBackColor = true;
            this.btnRefreshDepartments.Click += new System.EventHandler(this.btnRefreshDepartments_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(280, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Please select the departments that you would like to sync:";
            // 
            // chkDepartments
            // 
            this.chkDepartments.FormattingEnabled = true;
            this.chkDepartments.Location = new System.Drawing.Point(10, 77);
            this.chkDepartments.Name = "chkDepartments";
            this.chkDepartments.Size = new System.Drawing.Size(972, 334);
            this.chkDepartments.TabIndex = 6;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.txtToEmailAddress6);
            this.tabPage14.Controls.Add(this.label36);
            this.tabPage14.Controls.Add(this.txtToEmailAddress2);
            this.tabPage14.Controls.Add(this.label32);
            this.tabPage14.Controls.Add(this.txtToEmailAddress3);
            this.tabPage14.Controls.Add(this.label31);
            this.tabPage14.Controls.Add(this.txtToEmailAddress4);
            this.tabPage14.Controls.Add(this.label30);
            this.tabPage14.Controls.Add(this.txtToEmailAddress5);
            this.tabPage14.Controls.Add(this.label28);
            this.tabPage14.Controls.Add(this.btnTestEmail);
            this.tabPage14.Controls.Add(this.txtToEmailAddress1);
            this.tabPage14.Controls.Add(this.label23);
            this.tabPage14.Controls.Add(this.txtEmailAddress);
            this.tabPage14.Controls.Add(this.txtUsername);
            this.tabPage14.Controls.Add(this.txtSmtpPort);
            this.tabPage14.Controls.Add(this.txtPassword);
            this.tabPage14.Controls.Add(this.txtSmtpHost);
            this.tabPage14.Controls.Add(this.chkEnableEmail);
            this.tabPage14.Controls.Add(this.chkSSL);
            this.tabPage14.Controls.Add(this.label22);
            this.tabPage14.Controls.Add(this.label21);
            this.tabPage14.Controls.Add(this.label20);
            this.tabPage14.Controls.Add(this.label19);
            this.tabPage14.Controls.Add(this.label18);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Size = new System.Drawing.Size(988, 422);
            this.tabPage14.TabIndex = 3;
            this.tabPage14.Text = "Email Options";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // txtToEmailAddress6
            // 
            this.txtToEmailAddress6.Location = new System.Drawing.Point(721, 179);
            this.txtToEmailAddress6.Name = "txtToEmailAddress6";
            this.txtToEmailAddress6.Size = new System.Drawing.Size(247, 20);
            this.txtToEmailAddress6.TabIndex = 39;
            this.txtToEmailAddress6.TextChanged += new System.EventHandler(this.txtToEmailAddress6_TextChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(588, 182);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(101, 13);
            this.label36.TabIndex = 38;
            this.label36.Text = "To Email Address 6:";
            // 
            // txtToEmailAddress2
            // 
            this.txtToEmailAddress2.Location = new System.Drawing.Point(721, 75);
            this.txtToEmailAddress2.Name = "txtToEmailAddress2";
            this.txtToEmailAddress2.Size = new System.Drawing.Size(247, 20);
            this.txtToEmailAddress2.TabIndex = 37;
            this.txtToEmailAddress2.TextChanged += new System.EventHandler(this.txtToEmailAddress2_TextChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(588, 78);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(101, 13);
            this.label32.TabIndex = 36;
            this.label32.Text = "To Email Address 2:";
            // 
            // txtToEmailAddress3
            // 
            this.txtToEmailAddress3.Location = new System.Drawing.Point(721, 101);
            this.txtToEmailAddress3.Name = "txtToEmailAddress3";
            this.txtToEmailAddress3.Size = new System.Drawing.Size(247, 20);
            this.txtToEmailAddress3.TabIndex = 35;
            this.txtToEmailAddress3.TextChanged += new System.EventHandler(this.txtToEmailAddress3_TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(588, 104);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(101, 13);
            this.label31.TabIndex = 34;
            this.label31.Text = "To Email Address 3:";
            // 
            // txtToEmailAddress4
            // 
            this.txtToEmailAddress4.Location = new System.Drawing.Point(721, 127);
            this.txtToEmailAddress4.Name = "txtToEmailAddress4";
            this.txtToEmailAddress4.Size = new System.Drawing.Size(247, 20);
            this.txtToEmailAddress4.TabIndex = 33;
            this.txtToEmailAddress4.TextChanged += new System.EventHandler(this.txtToEmailAddress4_TextChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(588, 130);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(101, 13);
            this.label30.TabIndex = 32;
            this.label30.Text = "To Email Address 4:";
            // 
            // txtToEmailAddress5
            // 
            this.txtToEmailAddress5.Location = new System.Drawing.Point(721, 153);
            this.txtToEmailAddress5.Name = "txtToEmailAddress5";
            this.txtToEmailAddress5.Size = new System.Drawing.Size(247, 20);
            this.txtToEmailAddress5.TabIndex = 31;
            this.txtToEmailAddress5.TextChanged += new System.EventHandler(this.txtToEmailAddress5_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(588, 156);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(101, 13);
            this.label28.TabIndex = 30;
            this.label28.Text = "To Email Address 5:";
            // 
            // btnTestEmail
            // 
            this.btnTestEmail.Location = new System.Drawing.Point(15, 211);
            this.btnTestEmail.Name = "btnTestEmail";
            this.btnTestEmail.Size = new System.Drawing.Size(160, 23);
            this.btnTestEmail.TabIndex = 29;
            this.btnTestEmail.Text = "Send Test Email (Email 1 Only)";
            this.btnTestEmail.UseVisualStyleBackColor = true;
            this.btnTestEmail.Click += new System.EventHandler(this.btnTestEmail_Click);
            // 
            // txtToEmailAddress1
            // 
            this.txtToEmailAddress1.Location = new System.Drawing.Point(721, 49);
            this.txtToEmailAddress1.Name = "txtToEmailAddress1";
            this.txtToEmailAddress1.Size = new System.Drawing.Size(247, 20);
            this.txtToEmailAddress1.TabIndex = 28;
            this.txtToEmailAddress1.TextChanged += new System.EventHandler(this.txtToEmailAddress_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(588, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 13);
            this.label23.TabIndex = 27;
            this.label23.Text = "To Email Address 1:";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(145, 104);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(247, 20);
            this.txtEmailAddress.TabIndex = 26;
            this.txtEmailAddress.TextChanged += new System.EventHandler(this.txtEmailAddress_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(145, 130);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(247, 20);
            this.txtUsername.TabIndex = 25;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtSmtpPort
            // 
            this.txtSmtpPort.Location = new System.Drawing.Point(145, 75);
            this.txtSmtpPort.Name = "txtSmtpPort";
            this.txtSmtpPort.Size = new System.Drawing.Size(247, 20);
            this.txtSmtpPort.TabIndex = 24;
            this.txtSmtpPort.Text = "0";
            this.txtSmtpPort.TextChanged += new System.EventHandler(this.txtSmtpPort_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(145, 158);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(247, 20);
            this.txtPassword.TabIndex = 23;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtSmtpHost
            // 
            this.txtSmtpHost.Location = new System.Drawing.Point(145, 49);
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(247, 20);
            this.txtSmtpHost.TabIndex = 22;
            this.txtSmtpHost.TextChanged += new System.EventHandler(this.txtSmtpHost_TextChanged);
            // 
            // chkEnableEmail
            // 
            this.chkEnableEmail.AutoSize = true;
            this.chkEnableEmail.Location = new System.Drawing.Point(15, 14);
            this.chkEnableEmail.Name = "chkEnableEmail";
            this.chkEnableEmail.Size = new System.Drawing.Size(409, 17);
            this.chkEnableEmail.TabIndex = 21;
            this.chkEnableEmail.Text = "Enable E-mail (E-mail will sent when new users are created in the Impro database)" +
    "";
            this.chkEnableEmail.UseVisualStyleBackColor = true;
            this.chkEnableEmail.CheckedChanged += new System.EventHandler(this.chkEnableEmail_CheckedChanged);
            // 
            // chkSSL
            // 
            this.chkSSL.AutoSize = true;
            this.chkSSL.Location = new System.Drawing.Point(15, 188);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.Size = new System.Drawing.Size(71, 17);
            this.chkSSL.TabIndex = 20;
            this.chkSSL.Text = "TLS/SSL";
            this.chkSSL.UseVisualStyleBackColor = true;
            this.chkSSL.CheckedChanged += new System.EventHandler(this.chkSSL_CheckedChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 107);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(106, 13);
            this.label22.TabIndex = 19;
            this.label22.Text = "From E-Mail Address:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 133);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 18;
            this.label21.Text = "Username:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 161);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 17;
            this.label20.Text = "Password:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 78);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 13);
            this.label19.TabIndex = 16;
            this.label19.Text = "SMTP Port:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 15;
            this.label18.Text = "SMTP Host:";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.radDuplicateWeeks);
            this.tabPage6.Controls.Add(this.radDuplicateMonths);
            this.tabPage6.Controls.Add(this.label29);
            this.tabPage6.Controls.Add(this.dtDuplicateScheduleStartDate);
            this.tabPage6.Controls.Add(this.label27);
            this.tabPage6.Controls.Add(this.numScheduleMonths);
            this.tabPage6.Controls.Add(this.btnDuplicateRoster);
            this.tabPage6.Controls.Add(this.btnGetRosters);
            this.tabPage6.Controls.Add(this.label26);
            this.tabPage6.Controls.Add(this.label25);
            this.tabPage6.Controls.Add(this.cmbRosterStartMonth);
            this.tabPage6.Controls.Add(this.cmbRosters);
            this.tabPage6.Controls.Add(this.label24);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1008, 489);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Roster Duplication Tool";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // radDuplicateWeeks
            // 
            this.radDuplicateWeeks.AutoSize = true;
            this.radDuplicateWeeks.Location = new System.Drawing.Point(248, 205);
            this.radDuplicateWeeks.Name = "radDuplicateWeeks";
            this.radDuplicateWeeks.Size = new System.Drawing.Size(65, 17);
            this.radDuplicateWeeks.TabIndex = 13;
            this.radDuplicateWeeks.Text = "Week(s)";
            this.radDuplicateWeeks.UseVisualStyleBackColor = true;
            this.radDuplicateWeeks.CheckedChanged += new System.EventHandler(this.radDuplicateWeeks_CheckedChanged);
            // 
            // radDuplicateMonths
            // 
            this.radDuplicateMonths.AutoSize = true;
            this.radDuplicateMonths.Checked = true;
            this.radDuplicateMonths.Location = new System.Drawing.Point(248, 182);
            this.radDuplicateMonths.Name = "radDuplicateMonths";
            this.radDuplicateMonths.Size = new System.Drawing.Size(66, 17);
            this.radDuplicateMonths.TabIndex = 12;
            this.radDuplicateMonths.TabStop = true;
            this.radDuplicateMonths.Text = "Month(s)";
            this.radDuplicateMonths.UseVisualStyleBackColor = true;
            this.radDuplicateMonths.CheckedChanged += new System.EventHandler(this.radDuplicateMonths_CheckedChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 160);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(58, 13);
            this.label29.TabIndex = 11;
            this.label29.Text = "Start Date:";
            // 
            // dtDuplicateScheduleStartDate
            // 
            this.dtDuplicateScheduleStartDate.Location = new System.Drawing.Point(121, 154);
            this.dtDuplicateScheduleStartDate.Name = "dtDuplicateScheduleStartDate";
            this.dtDuplicateScheduleStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtDuplicateScheduleStartDate.TabIndex = 10;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(9, 181);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(101, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "Duplicate Roster for";
            // 
            // numScheduleMonths
            // 
            this.numScheduleMonths.Location = new System.Drawing.Point(121, 180);
            this.numScheduleMonths.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numScheduleMonths.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numScheduleMonths.Name = "numScheduleMonths";
            this.numScheduleMonths.Size = new System.Drawing.Size(120, 20);
            this.numScheduleMonths.TabIndex = 7;
            this.numScheduleMonths.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnDuplicateRoster
            // 
            this.btnDuplicateRoster.Location = new System.Drawing.Point(9, 228);
            this.btnDuplicateRoster.Name = "btnDuplicateRoster";
            this.btnDuplicateRoster.Size = new System.Drawing.Size(127, 23);
            this.btnDuplicateRoster.TabIndex = 6;
            this.btnDuplicateRoster.Text = "Duplicate Rosters";
            this.btnDuplicateRoster.UseVisualStyleBackColor = true;
            this.btnDuplicateRoster.Click += new System.EventHandler(this.btnDuplicateRoster_Click);
            // 
            // btnGetRosters
            // 
            this.btnGetRosters.Location = new System.Drawing.Point(9, 22);
            this.btnGetRosters.Name = "btnGetRosters";
            this.btnGetRosters.Size = new System.Drawing.Size(117, 23);
            this.btnGetRosters.TabIndex = 5;
            this.btnGetRosters.Text = "Get Rosters";
            this.btnGetRosters.UseVisualStyleBackColor = true;
            this.btnGetRosters.Click += new System.EventHandler(this.btnGetRosters_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(356, 77);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(125, 13);
            this.label26.TabIndex = 4;
            this.label26.Text = "Roster Start Date (Days):";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 77);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 13);
            this.label25.TabIndex = 3;
            this.label25.Text = "Roster Name:";
            // 
            // cmbRosterStartMonth
            // 
            this.cmbRosterStartMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRosterStartMonth.FormattingEnabled = true;
            this.cmbRosterStartMonth.Location = new System.Drawing.Point(359, 98);
            this.cmbRosterStartMonth.Name = "cmbRosterStartMonth";
            this.cmbRosterStartMonth.Size = new System.Drawing.Size(207, 21);
            this.cmbRosterStartMonth.TabIndex = 2;
            // 
            // cmbRosters
            // 
            this.cmbRosters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRosters.FormattingEnabled = true;
            this.cmbRosters.Location = new System.Drawing.Point(9, 98);
            this.cmbRosters.Name = "cmbRosters";
            this.cmbRosters.Size = new System.Drawing.Size(343, 21);
            this.cmbRosters.TabIndex = 1;
            this.cmbRosters.SelectedIndexChanged += new System.EventHandler(this.cmbRosters_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 57);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(218, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "Select a roster name and month to duplicate:";
            // 
            // tabpgEngine
            // 
            this.tabpgEngine.Controls.Add(this.tabCtrlEngines);
            this.tabpgEngine.Location = new System.Drawing.Point(4, 22);
            this.tabpgEngine.Name = "tabpgEngine";
            this.tabpgEngine.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgEngine.Size = new System.Drawing.Size(1008, 489);
            this.tabpgEngine.TabIndex = 4;
            this.tabpgEngine.Text = "Engine Settings";
            this.tabpgEngine.UseVisualStyleBackColor = true;
            // 
            // tabCtrlEngines
            // 
            this.tabCtrlEngines.Controls.Add(this.tabpgExportRunner);
            this.tabCtrlEngines.Controls.Add(this.tabpgSyncEngine);
            this.tabCtrlEngines.Location = new System.Drawing.Point(6, 12);
            this.tabCtrlEngines.Name = "tabCtrlEngines";
            this.tabCtrlEngines.SelectedIndex = 0;
            this.tabCtrlEngines.Size = new System.Drawing.Size(996, 444);
            this.tabCtrlEngines.TabIndex = 23;
            // 
            // tabpgExportRunner
            // 
            this.tabpgExportRunner.Controls.Add(this.chkRunExeAuto);
            this.tabpgExportRunner.Controls.Add(this.label7);
            this.tabpgExportRunner.Controls.Add(this.btnBrowseExe);
            this.tabpgExportRunner.Controls.Add(this.txtRunnerExe);
            this.tabpgExportRunner.Controls.Add(this.chkEnableTimer);
            this.tabpgExportRunner.Controls.Add(this.txtInterval);
            this.tabpgExportRunner.Controls.Add(this.label9);
            this.tabpgExportRunner.Controls.Add(this.label8);
            this.tabpgExportRunner.Controls.Add(this.lblCountdown);
            this.tabpgExportRunner.Location = new System.Drawing.Point(4, 22);
            this.tabpgExportRunner.Name = "tabpgExportRunner";
            this.tabpgExportRunner.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgExportRunner.Size = new System.Drawing.Size(988, 418);
            this.tabpgExportRunner.TabIndex = 0;
            this.tabpgExportRunner.Text = "Export Engine";
            this.tabpgExportRunner.UseVisualStyleBackColor = true;
            // 
            // chkRunExeAuto
            // 
            this.chkRunExeAuto.AutoSize = true;
            this.chkRunExeAuto.Location = new System.Drawing.Point(13, 75);
            this.chkRunExeAuto.Name = "chkRunExeAuto";
            this.chkRunExeAuto.Size = new System.Drawing.Size(123, 17);
            this.chkRunExeAuto.TabIndex = 21;
            this.chkRunExeAuto.Text = "Run exe after Export";
            this.chkRunExeAuto.UseVisualStyleBackColor = true;
            this.chkRunExeAuto.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Exe Path:";
            // 
            // btnBrowseExe
            // 
            this.btnBrowseExe.Location = new System.Drawing.Point(780, 104);
            this.btnBrowseExe.Name = "btnBrowseExe";
            this.btnBrowseExe.Size = new System.Drawing.Size(28, 20);
            this.btnBrowseExe.TabIndex = 20;
            this.btnBrowseExe.Text = "...";
            this.btnBrowseExe.UseVisualStyleBackColor = true;
            this.btnBrowseExe.Click += new System.EventHandler(this.btnBrowseExe_Click);
            // 
            // txtRunnerExe
            // 
            this.txtRunnerExe.Location = new System.Drawing.Point(146, 105);
            this.txtRunnerExe.Name = "txtRunnerExe";
            this.txtRunnerExe.Size = new System.Drawing.Size(628, 20);
            this.txtRunnerExe.TabIndex = 18;
            this.txtRunnerExe.TextChanged += new System.EventHandler(this.txtRunnerExe_TextChanged);
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(141, 42);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(84, 20);
            this.txtInterval.TabIndex = 16;
            this.txtInterval.Text = "30";
            this.txtInterval.TextChanged += new System.EventHandler(this.txtInterval_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Export Interval (seconds)";
            // 
            // tabpgSyncEngine
            // 
            this.tabpgSyncEngine.Controls.Add(this.label14);
            this.tabpgSyncEngine.Controls.Add(this.lblSyncCountDown);
            this.tabpgSyncEngine.Controls.Add(this.label13);
            this.tabpgSyncEngine.Controls.Add(this.txtSyncInterval);
            this.tabpgSyncEngine.Controls.Add(this.chkSyncTimerEnabled);
            this.tabpgSyncEngine.Location = new System.Drawing.Point(4, 22);
            this.tabpgSyncEngine.Name = "tabpgSyncEngine";
            this.tabpgSyncEngine.Padding = new System.Windows.Forms.Padding(3);
            this.tabpgSyncEngine.Size = new System.Drawing.Size(988, 418);
            this.tabpgSyncEngine.TabIndex = 2;
            this.tabpgSyncEngine.Text = "Sync Engine";
            this.tabpgSyncEngine.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 336);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "Countdown:";
            // 
            // lblSyncCountDown
            // 
            this.lblSyncCountDown.AutoSize = true;
            this.lblSyncCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyncCountDown.Location = new System.Drawing.Point(12, 368);
            this.lblSyncCountDown.Name = "lblSyncCountDown";
            this.lblSyncCountDown.Size = new System.Drawing.Size(194, 39);
            this.lblSyncCountDown.TabIndex = 24;
            this.lblSyncCountDown.Text = "0 second(s)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Synchronization Interval (seconds)";
            // 
            // txtSyncInterval
            // 
            this.txtSyncInterval.Location = new System.Drawing.Point(197, 49);
            this.txtSyncInterval.Name = "txtSyncInterval";
            this.txtSyncInterval.Size = new System.Drawing.Size(80, 20);
            this.txtSyncInterval.TabIndex = 22;
            this.txtSyncInterval.Text = "30";
            this.txtSyncInterval.TextChanged += new System.EventHandler(this.txtSyncInterval_TextChanged);
            // 
            // chkSyncTimerEnabled
            // 
            this.chkSyncTimerEnabled.AutoSize = true;
            this.chkSyncTimerEnabled.Location = new System.Drawing.Point(16, 16);
            this.chkSyncTimerEnabled.Name = "chkSyncTimerEnabled";
            this.chkSyncTimerEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkSyncTimerEnabled.TabIndex = 21;
            this.chkSyncTimerEnabled.Text = "Enabled";
            this.chkSyncTimerEnabled.UseVisualStyleBackColor = true;
            this.chkSyncTimerEnabled.CheckedChanged += new System.EventHandler(this.chkSyncTimerEnabled_CheckedChanged);
            // 
            // ImpronetInterfaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 552);
            this.Controls.Add(this.tabOverview);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ImpronetInterfaceForm";
            this.ShowIcon = false;
            this.Text = "Time Manager Platinum Inteface Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabOverview.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabCtrlExport.ResumeLayout(false);
            this.tabpgTmpExport.ResumeLayout(false);
            this.tabpgTmpExport.PerformLayout();
            this.tabctrlMappings.ResumeLayout(false);
            this.tabpgStandardMapping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMappings)).EndInit();
            this.tabpgDepartmentMapping.ResumeLayout(false);
            this.tabpgDepartmentMapping.PerformLayout();
            this.tabpgIntegrityExport.ResumeLayout(false);
            this.tabpgIntegrityExport.PerformLayout();
            this.grpIntegrityFilters.ResumeLayout(false);
            this.grpIntegrityFilters.PerformLayout();
            this.tabpgExcelExport.ResumeLayout(false);
            this.tabpgExcelExport.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScheduleMonths)).EndInit();
            this.tabpgEngine.ResumeLayout(false);
            this.tabCtrlEngines.ResumeLayout(false);
            this.tabpgExportRunner.ResumeLayout(false);
            this.tabpgExportRunner.PerformLayout();
            this.tabpgSyncEngine.ResumeLayout(false);
            this.tabpgSyncEngine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnBrowseFbDatabase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFbDatabasePath;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Timer tmrSeconds;
        private System.Windows.Forms.CheckBox chkEnableTimer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.TabControl tabOverview;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTmpDatabasePath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radFirebird;
        private System.Windows.Forms.TextBox txtSqlConnectionString;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton radSql;
        private System.Windows.Forms.TabPage tabpgEngine;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnGetRosters;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmbRosterStartMonth;
        private System.Windows.Forms.ComboBox cmbRosters;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.NumericUpDown numScheduleMonths;
        private System.Windows.Forms.Button btnDuplicateRoster;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtDuplicateScheduleStartDate;
        private System.Windows.Forms.RadioButton radDuplicateWeeks;
        private System.Windows.Forms.RadioButton radDuplicateMonths;
        private System.Windows.Forms.TabControl tabCtrlEngines;
        private System.Windows.Forms.TabPage tabpgExportRunner;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabpgSyncEngine;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.CheckBox chkChangeEmployeeNumber;
        private System.Windows.Forms.CheckBox chkAlwaysSync;
        private System.Windows.Forms.CheckBox chkSyncAccessControlDevices;
        private System.Windows.Forms.CheckBox chkSynEmployees;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnDeselctAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnRefreshDepartments;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckedListBox chkDepartments;
        private System.Windows.Forms.TabControl tabCtrlExport;
        private System.Windows.Forms.TabPage tabpgTmpExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.TextBox txtToEmailAddress2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtToEmailAddress3;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtToEmailAddress4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtToEmailAddress5;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnTestEmail;
        private System.Windows.Forms.TextBox txtToEmailAddress1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtSmtpPort;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtSmtpHost;
        private System.Windows.Forms.CheckBox chkEnableEmail;
        private System.Windows.Forms.CheckBox chkSSL;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSyncCountDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSyncInterval;
        private System.Windows.Forms.CheckBox chkSyncTimerEnabled;
        private System.Windows.Forms.TextBox txtToEmailAddress6;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckBox chkEnableTmpExport;
        private System.Windows.Forms.RadioButton radUseDepartmentMapping;
        private System.Windows.Forms.RadioButton radUseStandardMapping;
        private System.Windows.Forms.TabControl tabctrlMappings;
        private System.Windows.Forms.TabPage tabpgStandardMapping;
        private System.Windows.Forms.Button btnFetchReaders;
        private System.Windows.Forms.DataGridView gridMappings;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabPage tabpgDepartmentMapping;
        private System.Windows.Forms.Button btnDepMappingsDeselectAll;
        private System.Windows.Forms.Button btnDepMappingsSelectAll;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TreeView treeDepMappings;
        private System.Windows.Forms.Button btnDepFetchMappings;
        private System.Windows.Forms.Button btnDepMappingsRefresh;
        private System.Windows.Forms.Button btnDepMappingsSave;
        private System.Windows.Forms.TextBox txtDepMappingAccessControlCode;
        private System.Windows.Forms.TextBox txtDepMappingTimeAndAttendanceCode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabpgIntegrityExport;
        private System.Windows.Forms.CheckBox chkEnableIntegrityExport;
        private System.Windows.Forms.GroupBox grpIntegrityFilters;
        private System.Windows.Forms.Button btnRefreshFilterIntegrity;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox cmbccTo;
        private System.Windows.Forms.ComboBox cmbccFrom;
        private System.Windows.Forms.CheckBox chkEnableFilters;
        private System.Windows.Forms.Button btnBrowseIntegrity;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtIntegrityExport;
        private System.Windows.Forms.DateTimePicker dtIntegrityEnd;
        private System.Windows.Forms.DateTimePicker dtIntegrityStart;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.CheckBox chkCalc1;
        private System.Windows.Forms.CheckBox chkCalc2;
        private System.Windows.Forms.CheckBox chkCalc3;
        private System.Windows.Forms.CheckBox chkCalc4;
        private System.Windows.Forms.CheckBox chkCalc0;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtNetworkLocation;
        private System.Windows.Forms.TabPage tabpgExcelExport;
        private System.Windows.Forms.CheckBox chkEnableExcelExport;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtEbExcelLocation;
        private System.Windows.Forms.DateTimePicker dtEbExcelTo;
        private System.Windows.Forms.DateTimePicker dtEbExcelFrom;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.CheckBox chkRunnerTmp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtExePath;
        private System.Windows.Forms.CheckBox chkRunExeAuto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBrowseExe;
        private System.Windows.Forms.TextBox txtRunnerExe;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cmbExcelBranchTo;
        private System.Windows.Forms.ComboBox cmbExcelBranchFrom;
        private System.Windows.Forms.CheckBox chkExcelFilterEnable;
    }
}

