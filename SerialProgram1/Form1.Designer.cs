namespace SerialProgram
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend17 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend18 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblPortDesc = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTimer = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SendTextBox = new System.Windows.Forms.TextBox();
            this.RecvTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartAmp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartVolt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartOxgen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSalt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPH = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonVolt = new System.Windows.Forms.RadioButton();
            this.radioButtonOxgen = new System.Windows.Forms.RadioButton();
            this.radioButtonSalt = new System.Windows.Forms.RadioButton();
            this.radioButtonPH = new System.Windows.Forms.RadioButton();
            this.radioButtonTemperature = new System.Windows.Forms.RadioButton();
            this.radioButtonAmp = new System.Windows.Forms.RadioButton();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.buttonViewer = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOxgen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPortDesc,
            this.toolStripSeparator1,
            this.btnOpenClose,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1417, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblPortDesc
            // 
            this.lblPortDesc.Name = "lblPortDesc";
            this.lblPortDesc.Size = new System.Drawing.Size(68, 22);
            this.lblPortDesc.Text = "lblPortDesc";
            this.lblPortDesc.Click += new System.EventHandler(this.lblPortDesc_Click);
            this.lblPortDesc.MouseLeave += new System.EventHandler(this.MessageNone);
            this.lblPortDesc.MouseHover += new System.EventHandler(this.lblPortDesc_MouseHover);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Checked = true;
            this.btnOpenClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnOpenClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(87, 22);
            this.btnOpenClose.Text = "통신포트 열기";
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "받은 데이터(Rx)";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 560);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(668, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMsg
            // 
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(161, 17);
            this.lblMsg.Text = "Com port testing program....";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateTimePickerEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxTimer);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 89);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "종료일시";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(247, 44);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerEnd.TabIndex = 7;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "데이터 주기";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // comboBoxTimer
            // 
            this.comboBoxTimer.FormattingEnabled = true;
            this.comboBoxTimer.Items.AddRange(new object[] {
            "30분",
            "1시간",
            "Test용"});
            this.comboBoxTimer.Location = new System.Drawing.Point(326, 18);
            this.comboBoxTimer.Name = "comboBoxTimer";
            this.comboBoxTimer.Size = new System.Drawing.Size(121, 20);
            this.comboBoxTimer.TabIndex = 2;
            this.comboBoxTimer.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimer_SelectedIndexChanged);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(6, 8);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(176, 76);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Not Connected";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // SendTextBox
            // 
            this.SendTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendTextBox.Location = new System.Drawing.Point(3, 457);
            this.SendTextBox.Multiline = true;
            this.SendTextBox.Name = "SendTextBox";
            this.SendTextBox.ReadOnly = true;
            this.SendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SendTextBox.Size = new System.Drawing.Size(404, 101);
            this.SendTextBox.TabIndex = 1;
            // 
            // RecvTextBox
            // 
            this.RecvTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecvTextBox.Location = new System.Drawing.Point(411, 457);
            this.RecvTextBox.Multiline = true;
            this.RecvTextBox.Name = "RecvTextBox";
            this.RecvTextBox.ReadOnly = true;
            this.RecvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RecvTextBox.Size = new System.Drawing.Size(327, 101);
            this.RecvTextBox.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonViewer);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSaveToFile);
            this.splitContainer1.Panel1.Controls.Add(this.RecvTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.SendTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartAmp);
            this.splitContainer1.Panel2.Controls.Add(this.chartVolt);
            this.splitContainer1.Panel2.Controls.Add(this.chartOxgen);
            this.splitContainer1.Panel2.Controls.Add(this.chartSalt);
            this.splitContainer1.Panel2.Controls.Add(this.chartPH);
            this.splitContainer1.Panel2.Controls.Add(this.chartTemperature);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1417, 582);
            this.splitContainer1.SplitterDistance = 745;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(0, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(743, 344);
            this.dataGridView1.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "기록시간";
            this.Column1.Name = "Column1";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "온도";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "pH농도";
            this.Column5.Name = "Column5";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "염도";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "용존 산소량";
            this.Column3.Name = "Column3";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "음극전위";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "양극전류";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // chartAmp
            // 
            chartArea13.Name = "ChartArea1";
            this.chartAmp.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chartAmp.Legends.Add(legend13);
            this.chartAmp.Location = new System.Drawing.Point(0, 0);
            this.chartAmp.Name = "chartAmp";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Legend = "Legend1";
            series13.Name = "양극전류";
            this.chartAmp.Series.Add(series13);
            this.chartAmp.Size = new System.Drawing.Size(628, 498);
            this.chartAmp.TabIndex = 12;
            this.chartAmp.Text = "양극전류";
            // 
            // chartVolt
            // 
            chartArea14.Name = "ChartArea1";
            this.chartVolt.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chartVolt.Legends.Add(legend14);
            this.chartVolt.Location = new System.Drawing.Point(0, 0);
            this.chartVolt.Name = "chartVolt";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Legend = "Legend1";
            series14.Name = "음극전위";
            this.chartVolt.Series.Add(series14);
            this.chartVolt.Size = new System.Drawing.Size(628, 498);
            this.chartVolt.TabIndex = 11;
            this.chartVolt.Text = "음극전위";
            // 
            // chartOxgen
            // 
            chartArea15.Name = "ChartArea1";
            this.chartOxgen.ChartAreas.Add(chartArea15);
            legend15.Name = "Legend1";
            this.chartOxgen.Legends.Add(legend15);
            this.chartOxgen.Location = new System.Drawing.Point(0, 0);
            this.chartOxgen.Name = "chartOxgen";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Legend = "Legend1";
            series15.Name = "용존산소량";
            this.chartOxgen.Series.Add(series15);
            this.chartOxgen.Size = new System.Drawing.Size(628, 498);
            this.chartOxgen.TabIndex = 10;
            this.chartOxgen.Text = "염도";
            // 
            // chartSalt
            // 
            chartArea16.Name = "ChartArea1";
            this.chartSalt.ChartAreas.Add(chartArea16);
            legend16.Name = "Legend1";
            this.chartSalt.Legends.Add(legend16);
            this.chartSalt.Location = new System.Drawing.Point(0, 0);
            this.chartSalt.Name = "chartSalt";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Legend = "Legend1";
            series16.Name = "염도";
            this.chartSalt.Series.Add(series16);
            this.chartSalt.Size = new System.Drawing.Size(628, 498);
            this.chartSalt.TabIndex = 9;
            this.chartSalt.Text = "염도";
            // 
            // chartPH
            // 
            chartArea17.Name = "ChartArea1";
            this.chartPH.ChartAreas.Add(chartArea17);
            legend17.Name = "Legend1";
            this.chartPH.Legends.Add(legend17);
            this.chartPH.Location = new System.Drawing.Point(0, 0);
            this.chartPH.Name = "chartPH";
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.Legend = "Legend1";
            series17.Name = "PH";
            this.chartPH.Series.Add(series17);
            this.chartPH.Size = new System.Drawing.Size(628, 498);
            this.chartPH.TabIndex = 8;
            this.chartPH.Text = "PH";
            // 
            // chartTemperature
            // 
            chartArea18.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea18);
            legend18.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend18);
            this.chartTemperature.Location = new System.Drawing.Point(0, 0);
            this.chartTemperature.Name = "chartTemperature";
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series18.Legend = "Legend1";
            series18.Name = "온도";
            this.chartTemperature.Series.Add(series18);
            this.chartTemperature.Size = new System.Drawing.Size(628, 498);
            this.chartTemperature.TabIndex = 7;
            this.chartTemperature.Text = "온도";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonVolt);
            this.groupBox1.Controls.Add(this.radioButtonOxgen);
            this.groupBox1.Controls.Add(this.radioButtonSalt);
            this.groupBox1.Controls.Add(this.radioButtonPH);
            this.groupBox1.Controls.Add(this.radioButtonTemperature);
            this.groupBox1.Controls.Add(this.radioButtonAmp);
            this.groupBox1.Location = new System.Drawing.Point(6, 507);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 48);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "데이터";
            // 
            // radioButtonVolt
            // 
            this.radioButtonVolt.AutoSize = true;
            this.radioButtonVolt.Location = new System.Drawing.Point(281, 20);
            this.radioButtonVolt.Name = "radioButtonVolt";
            this.radioButtonVolt.Size = new System.Drawing.Size(71, 16);
            this.radioButtonVolt.TabIndex = 11;
            this.radioButtonVolt.TabStop = true;
            this.radioButtonVolt.Text = "음극전위";
            this.radioButtonVolt.UseVisualStyleBackColor = true;
            this.radioButtonVolt.CheckedChanged += new System.EventHandler(this.radioButtonVolt_CheckedChanged);
            // 
            // radioButtonOxgen
            // 
            this.radioButtonOxgen.AutoSize = true;
            this.radioButtonOxgen.Location = new System.Drawing.Point(188, 20);
            this.radioButtonOxgen.Name = "radioButtonOxgen";
            this.radioButtonOxgen.Size = new System.Drawing.Size(87, 16);
            this.radioButtonOxgen.TabIndex = 10;
            this.radioButtonOxgen.TabStop = true;
            this.radioButtonOxgen.Text = "용존 산소량";
            this.radioButtonOxgen.UseVisualStyleBackColor = true;
            this.radioButtonOxgen.CheckedChanged += new System.EventHandler(this.radioButtonOxgen_CheckedChanged);
            // 
            // radioButtonSalt
            // 
            this.radioButtonSalt.AutoSize = true;
            this.radioButtonSalt.Location = new System.Drawing.Point(135, 20);
            this.radioButtonSalt.Name = "radioButtonSalt";
            this.radioButtonSalt.Size = new System.Drawing.Size(47, 16);
            this.radioButtonSalt.TabIndex = 9;
            this.radioButtonSalt.TabStop = true;
            this.radioButtonSalt.Text = "염도";
            this.radioButtonSalt.UseVisualStyleBackColor = true;
            this.radioButtonSalt.CheckedChanged += new System.EventHandler(this.radioButtonSalt_CheckedChanged);
            // 
            // radioButtonPH
            // 
            this.radioButtonPH.AutoSize = true;
            this.radioButtonPH.Location = new System.Drawing.Point(67, 20);
            this.radioButtonPH.Name = "radioButtonPH";
            this.radioButtonPH.Size = new System.Drawing.Size(62, 16);
            this.radioButtonPH.TabIndex = 8;
            this.radioButtonPH.TabStop = true;
            this.radioButtonPH.Text = "pH농도";
            this.radioButtonPH.UseVisualStyleBackColor = true;
            this.radioButtonPH.CheckedChanged += new System.EventHandler(this.radioButtonPH_CheckedChanged);
            // 
            // radioButtonTemperature
            // 
            this.radioButtonTemperature.AutoSize = true;
            this.radioButtonTemperature.Location = new System.Drawing.Point(6, 20);
            this.radioButtonTemperature.Name = "radioButtonTemperature";
            this.radioButtonTemperature.Size = new System.Drawing.Size(47, 16);
            this.radioButtonTemperature.TabIndex = 7;
            this.radioButtonTemperature.TabStop = true;
            this.radioButtonTemperature.Text = "온도";
            this.radioButtonTemperature.UseVisualStyleBackColor = true;
            this.radioButtonTemperature.CheckedChanged += new System.EventHandler(this.radioButtonTemperature_CheckedChanged);
            // 
            // radioButtonAmp
            // 
            this.radioButtonAmp.AutoSize = true;
            this.radioButtonAmp.Location = new System.Drawing.Point(358, 20);
            this.radioButtonAmp.Name = "radioButtonAmp";
            this.radioButtonAmp.Size = new System.Drawing.Size(71, 16);
            this.radioButtonAmp.TabIndex = 6;
            this.radioButtonAmp.TabStop = true;
            this.radioButtonAmp.Text = "양극전류";
            this.radioButtonAmp.UseVisualStyleBackColor = true;
            this.radioButtonAmp.CheckedChanged += new System.EventHandler(this.radioButtonAmp_CheckedChanged);
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(498, 17);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(100, 70);
            this.buttonSaveToFile.TabIndex = 3;
            this.buttonSaveToFile.Text = "데이터저장";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveFile_Click);
            // 
            // buttonViewer
            // 
            this.buttonViewer.Location = new System.Drawing.Point(604, 17);
            this.buttonViewer.Name = "buttonViewer";
            this.buttonViewer.Size = new System.Drawing.Size(100, 70);
            this.buttonViewer.TabIndex = 5;
            this.buttonViewer.Text = "뷰어열기";
            this.buttonViewer.UseVisualStyleBackColor = true;
            this.buttonViewer.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 607);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICCP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOxgen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblPortDesc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnOpenClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox SendTextBox;
        private System.Windows.Forms.TextBox RecvTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonPH;
        private System.Windows.Forms.RadioButton radioButtonTemperature;
        private System.Windows.Forms.RadioButton radioButtonAmp;
        private System.Windows.Forms.Button buttonViewer;
        private System.Windows.Forms.ComboBox comboBoxTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperature;
        private System.Windows.Forms.RadioButton radioButtonVolt;
        private System.Windows.Forms.RadioButton radioButtonOxgen;
        private System.Windows.Forms.RadioButton radioButtonSalt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAmp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVolt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOxgen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPH;
    }
}

