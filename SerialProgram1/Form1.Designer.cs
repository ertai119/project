﻿namespace SerialProgram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
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
            this.buttonViewer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RecvTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxStartTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxTarget = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.SendTextBox = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxData_Time = new System.Windows.Forms.TextBox();
            this.textBoxData_Temperature = new System.Windows.Forms.TextBox();
            this.textBoxData_pH = new System.Windows.Forms.TextBox();
            this.textBoxData_Salt = new System.Windows.Forms.TextBox();
            this.textBoxData_Oxygen = new System.Windows.Forms.TextBox();
            this.textBoxData_Volt = new System.Windows.Forms.TextBox();
            this.textBoxData_Amp = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chartAmp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOxgen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.lblMsg.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmp)).BeginInit();
            this.SuspendLayout();
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
            // chartVolt
            // 
            this.chartVolt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartVolt.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartVolt.Legends.Add(legend1);
            this.chartVolt.Location = new System.Drawing.Point(775, 12);
            this.chartVolt.Name = "chartVolt";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Chocolate;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "음극전위";
            this.chartVolt.Series.Add(series1);
            this.chartVolt.Size = new System.Drawing.Size(628, 498);
            this.chartVolt.TabIndex = 23;
            this.chartVolt.Text = "음극전위";
            // 
            // chartOxgen
            // 
            this.chartOxgen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartOxgen.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartOxgen.Legends.Add(legend2);
            this.chartOxgen.Location = new System.Drawing.Point(775, 12);
            this.chartOxgen.Name = "chartOxgen";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Green;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "용존산소량";
            this.chartOxgen.Series.Add(series2);
            this.chartOxgen.Size = new System.Drawing.Size(628, 498);
            this.chartOxgen.TabIndex = 22;
            this.chartOxgen.Text = "염도";
            // 
            // chartSalt
            // 
            this.chartSalt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chartSalt.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chartSalt.Legends.Add(legend3);
            this.chartSalt.Location = new System.Drawing.Point(775, 12);
            this.chartSalt.Name = "chartSalt";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "염도";
            this.chartSalt.Series.Add(series3);
            this.chartSalt.Size = new System.Drawing.Size(628, 498);
            this.chartSalt.TabIndex = 21;
            this.chartSalt.Text = "염도";
            // 
            // chartPH
            // 
            this.chartPH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chartPH.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chartPH.Legends.Add(legend4);
            this.chartPH.Location = new System.Drawing.Point(775, 12);
            this.chartPH.Name = "chartPH";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Orange;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "PH";
            this.chartPH.Series.Add(series4);
            this.chartPH.Size = new System.Drawing.Size(628, 498);
            this.chartPH.TabIndex = 20;
            this.chartPH.Text = "PH";
            // 
            // chartTemperature
            // 
            this.chartTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea5);
            legend5.Enabled = false;
            legend5.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend5);
            this.chartTemperature.Location = new System.Drawing.Point(775, 12);
            this.chartTemperature.Name = "chartTemperature";
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Cyan;
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "온도";
            this.chartTemperature.Series.Add(series5);
            this.chartTemperature.Size = new System.Drawing.Size(628, 498);
            this.chartTemperature.TabIndex = 19;
            this.chartTemperature.Text = "온도";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.radioButtonVolt);
            this.groupBox1.Controls.Add(this.radioButtonOxgen);
            this.groupBox1.Controls.Add(this.radioButtonSalt);
            this.groupBox1.Controls.Add(this.radioButtonPH);
            this.groupBox1.Controls.Add(this.radioButtonTemperature);
            this.groupBox1.Controls.Add(this.radioButtonAmp);
            this.groupBox1.Location = new System.Drawing.Point(775, 525);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 48);
            this.groupBox1.TabIndex = 18;
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
            this.radioButtonAmp.Text = "양극전류";
            this.radioButtonAmp.UseVisualStyleBackColor = true;
            this.radioButtonAmp.CheckedChanged += new System.EventHandler(this.radioButtonAmp_CheckedChanged);
            // 
            // buttonViewer
            // 
            this.buttonViewer.Location = new System.Drawing.Point(502, 5);
            this.buttonViewer.Name = "buttonViewer";
            this.buttonViewer.Size = new System.Drawing.Size(113, 103);
            this.buttonViewer.TabIndex = 17;
            this.buttonViewer.Text = "뷰어열기";
            this.buttonViewer.UseVisualStyleBackColor = true;
            this.buttonViewer.Click += new System.EventHandler(this.buttonViewer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column7});
            this.dataGridView1.Location = new System.Drawing.Point(2, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(743, 385);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.TabStop = false;
            // 
            // RecvTextBox
            // 
            this.RecvTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RecvTextBox.Enabled = false;
            this.RecvTextBox.Location = new System.Drawing.Point(335, 510);
            this.RecvTextBox.Multiline = true;
            this.RecvTextBox.Name = "RecvTextBox";
            this.RecvTextBox.ReadOnly = true;
            this.RecvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RecvTextBox.Size = new System.Drawing.Size(402, 69);
            this.RecvTextBox.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxStartTime);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.textBoxTarget);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxDelay);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateTimeEnd);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.buttonViewer);
            this.panel1.Location = new System.Drawing.Point(2, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 111);
            this.panel1.TabIndex = 13;
            // 
            // textBoxStartTime
            // 
            this.textBoxStartTime.Enabled = false;
            this.textBoxStartTime.Location = new System.Drawing.Point(292, 86);
            this.textBoxStartTime.MaxLength = 255;
            this.textBoxStartTime.Name = "textBoxStartTime";
            this.textBoxStartTime.Size = new System.Drawing.Size(162, 21);
            this.textBoxStartTime.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(198, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 23;
            this.label12.Text = "시작일시";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // textBoxTarget
            // 
            this.textBoxTarget.Location = new System.Drawing.Point(292, 12);
            this.textBoxTarget.MaxLength = 255;
            this.textBoxTarget.Name = "textBoxTarget";
            this.textBoxTarget.Size = new System.Drawing.Size(142, 21);
            this.textBoxTarget.TabIndex = 1;
            this.textBoxTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTarget_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "저장화일이름";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(292, 37);
            this.textBoxDelay.MaxLength = 3;
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(34, 21);
            this.textBoxDelay.TabIndex = 2;
            this.textBoxDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDelay_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "종료일시";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(291, 61);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(200, 21);
            this.dateTimeEnd.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "저장 간격(분)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 103);
            this.button1.TabIndex = 0;
            this.button1.Text = "포트 설정";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonPortSetting_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(176, 100);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Not Connected";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // SendTextBox
            // 
            this.SendTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SendTextBox.Enabled = false;
            this.SendTextBox.Location = new System.Drawing.Point(6, 513);
            this.SendTextBox.Multiline = true;
            this.SendTextBox.Name = "SendTextBox";
            this.SendTextBox.ReadOnly = true;
            this.SendTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SendTextBox.Size = new System.Drawing.Size(304, 66);
            this.SendTextBox.TabIndex = 14;
            // 
            // lblMsg
            // 
            this.lblMsg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.lblMsg.Location = new System.Drawing.Point(0, 585);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(1417, 22);
            this.lblMsg.TabIndex = 25;
            this.lblMsg.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // textBoxData_Time
            // 
            this.textBoxData_Time.Enabled = false;
            this.textBoxData_Time.Location = new System.Drawing.Point(8, 161);
            this.textBoxData_Time.MaxLength = 255;
            this.textBoxData_Time.Name = "textBoxData_Time";
            this.textBoxData_Time.Size = new System.Drawing.Size(165, 21);
            this.textBoxData_Time.TabIndex = 23;
            this.textBoxData_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxData_Temperature
            // 
            this.textBoxData_Temperature.Enabled = false;
            this.textBoxData_Temperature.Location = new System.Drawing.Point(180, 161);
            this.textBoxData_Temperature.MaxLength = 255;
            this.textBoxData_Temperature.Name = "textBoxData_Temperature";
            this.textBoxData_Temperature.Size = new System.Drawing.Size(70, 21);
            this.textBoxData_Temperature.TabIndex = 26;
            this.textBoxData_Temperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxData_pH
            // 
            this.textBoxData_pH.Enabled = false;
            this.textBoxData_pH.Location = new System.Drawing.Point(263, 161);
            this.textBoxData_pH.MaxLength = 255;
            this.textBoxData_pH.Name = "textBoxData_pH";
            this.textBoxData_pH.Size = new System.Drawing.Size(72, 21);
            this.textBoxData_pH.TabIndex = 27;
            this.textBoxData_pH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxData_Salt
            // 
            this.textBoxData_Salt.Enabled = false;
            this.textBoxData_Salt.Location = new System.Drawing.Point(349, 161);
            this.textBoxData_Salt.MaxLength = 255;
            this.textBoxData_Salt.Name = "textBoxData_Salt";
            this.textBoxData_Salt.Size = new System.Drawing.Size(79, 21);
            this.textBoxData_Salt.TabIndex = 28;
            this.textBoxData_Salt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxData_Oxygen
            // 
            this.textBoxData_Oxygen.Enabled = false;
            this.textBoxData_Oxygen.Location = new System.Drawing.Point(450, 161);
            this.textBoxData_Oxygen.MaxLength = 255;
            this.textBoxData_Oxygen.Name = "textBoxData_Oxygen";
            this.textBoxData_Oxygen.Size = new System.Drawing.Size(78, 21);
            this.textBoxData_Oxygen.TabIndex = 29;
            this.textBoxData_Oxygen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxData_Volt
            // 
            this.textBoxData_Volt.Enabled = false;
            this.textBoxData_Volt.Location = new System.Drawing.Point(553, 161);
            this.textBoxData_Volt.MaxLength = 255;
            this.textBoxData_Volt.Name = "textBoxData_Volt";
            this.textBoxData_Volt.Size = new System.Drawing.Size(79, 21);
            this.textBoxData_Volt.TabIndex = 30;
            this.textBoxData_Volt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxData_Amp
            // 
            this.textBoxData_Amp.Enabled = false;
            this.textBoxData_Amp.Location = new System.Drawing.Point(649, 161);
            this.textBoxData_Amp.MaxLength = 255;
            this.textBoxData_Amp.Name = "textBoxData_Amp";
            this.textBoxData_Amp.Size = new System.Drawing.Size(88, 21);
            this.textBoxData_Amp.TabIndex = 31;
            this.textBoxData_Amp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(2, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(743, 63);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "현재 데이터";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "온도(℃)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(276, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 12);
            this.label10.TabIndex = 5;
            this.label10.Text = "pH농도";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(647, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "양극전류(A/m2)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "용존 산소량(ppm)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(548, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "음극 전위(mV)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "염도(ppt)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "시간";
            // 
            // chartAmp
            // 
            this.chartAmp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea6.Name = "ChartArea1";
            this.chartAmp.ChartAreas.Add(chartArea6);
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.chartAmp.Legends.Add(legend6);
            this.chartAmp.Location = new System.Drawing.Point(775, 12);
            this.chartAmp.Name = "chartAmp";
            series6.BorderWidth = 3;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Blue;
            series6.IsVisibleInLegend = false;
            series6.Legend = "Legend1";
            series6.Name = "음극전위";
            this.chartAmp.Series.Add(series6);
            this.chartAmp.Size = new System.Drawing.Size(628, 498);
            this.chartAmp.TabIndex = 33;
            this.chartAmp.Text = "양극전류";
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.FillWeight = 142.132F;
            this.Column1.HeaderText = "기록시간";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.FillWeight = 92.97803F;
            this.Column4.HeaderText = "온도(℃)";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.FillWeight = 92.97803F;
            this.Column5.HeaderText = "pH농도";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.FillWeight = 92.97803F;
            this.Column2.HeaderText = "염도(ppt)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column3.FillWeight = 92.97803F;
            this.Column3.HeaderText = "용존 산소량(ppm)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column6.FillWeight = 92.97803F;
            this.Column6.HeaderText = "음극전위(mV)";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column7.FillWeight = 92.97803F;
            this.Column7.HeaderText = "양극전류(A/m2)";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1417, 607);
            this.Controls.Add(this.chartAmp);
            this.Controls.Add(this.textBoxData_Amp);
            this.Controls.Add(this.textBoxData_Volt);
            this.Controls.Add(this.textBoxData_Oxygen);
            this.Controls.Add(this.textBoxData_Salt);
            this.Controls.Add(this.textBoxData_pH);
            this.Controls.Add(this.textBoxData_Temperature);
            this.Controls.Add(this.textBoxData_Time);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.chartVolt);
            this.Controls.Add(this.chartOxgen);
            this.Controls.Add(this.chartSalt);
            this.Controls.Add(this.chartPH);
            this.Controls.Add(this.chartTemperature);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RecvTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SendTextBox);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartVolt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOxgen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.lblMsg.ResumeLayout(false);
            this.lblMsg.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVolt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOxgen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPH;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperature;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonVolt;
        private System.Windows.Forms.RadioButton radioButtonOxgen;
        private System.Windows.Forms.RadioButton radioButtonSalt;
        private System.Windows.Forms.RadioButton radioButtonPH;
        private System.Windows.Forms.RadioButton radioButtonTemperature;
        private System.Windows.Forms.RadioButton radioButtonAmp;
        private System.Windows.Forms.Button buttonViewer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox RecvTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox SendTextBox;
        private System.Windows.Forms.StatusStrip lblMsg;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxData_Time;
        private System.Windows.Forms.TextBox textBoxData_Temperature;
        private System.Windows.Forms.TextBox textBoxData_pH;
        private System.Windows.Forms.TextBox textBoxData_Salt;
        private System.Windows.Forms.TextBox textBoxData_Oxygen;
        private System.Windows.Forms.TextBox textBoxData_Volt;
        private System.Windows.Forms.TextBox textBoxData_Amp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxStartTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}

