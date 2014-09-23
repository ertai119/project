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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea19 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend19 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea20 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend20 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea21 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend21 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea22 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend22 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea23 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend23 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea24 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend24 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
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
            this.buttonViewer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecvTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxTarget = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.SendTextBox = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.StatusStrip();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOxgen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.lblMsg.SuspendLayout();
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
            // chartAmp
            // 
            this.chartAmp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea19.Name = "ChartArea1";
            this.chartAmp.ChartAreas.Add(chartArea19);
            legend19.Name = "Legend1";
            this.chartAmp.Legends.Add(legend19);
            this.chartAmp.Location = new System.Drawing.Point(775, 12);
            this.chartAmp.Name = "chartAmp";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series19.Legend = "Legend1";
            series19.Name = "양극전류";
            this.chartAmp.Series.Add(series19);
            this.chartAmp.Size = new System.Drawing.Size(628, 498);
            this.chartAmp.TabIndex = 24;
            this.chartAmp.Text = "양극전류";
            // 
            // chartVolt
            // 
            this.chartVolt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea20.Name = "ChartArea1";
            this.chartVolt.ChartAreas.Add(chartArea20);
            legend20.Name = "Legend1";
            this.chartVolt.Legends.Add(legend20);
            this.chartVolt.Location = new System.Drawing.Point(775, 12);
            this.chartVolt.Name = "chartVolt";
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series20.Legend = "Legend1";
            series20.Name = "음극전위";
            this.chartVolt.Series.Add(series20);
            this.chartVolt.Size = new System.Drawing.Size(628, 498);
            this.chartVolt.TabIndex = 23;
            this.chartVolt.Text = "음극전위";
            // 
            // chartOxgen
            // 
            this.chartOxgen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea21.Name = "ChartArea1";
            this.chartOxgen.ChartAreas.Add(chartArea21);
            legend21.Name = "Legend1";
            this.chartOxgen.Legends.Add(legend21);
            this.chartOxgen.Location = new System.Drawing.Point(775, 12);
            this.chartOxgen.Name = "chartOxgen";
            series21.ChartArea = "ChartArea1";
            series21.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series21.Legend = "Legend1";
            series21.Name = "용존산소량";
            this.chartOxgen.Series.Add(series21);
            this.chartOxgen.Size = new System.Drawing.Size(628, 498);
            this.chartOxgen.TabIndex = 22;
            this.chartOxgen.Text = "염도";
            // 
            // chartSalt
            // 
            this.chartSalt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea22.Name = "ChartArea1";
            this.chartSalt.ChartAreas.Add(chartArea22);
            legend22.Name = "Legend1";
            this.chartSalt.Legends.Add(legend22);
            this.chartSalt.Location = new System.Drawing.Point(775, 12);
            this.chartSalt.Name = "chartSalt";
            series22.ChartArea = "ChartArea1";
            series22.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series22.Legend = "Legend1";
            series22.Name = "염도";
            this.chartSalt.Series.Add(series22);
            this.chartSalt.Size = new System.Drawing.Size(628, 498);
            this.chartSalt.TabIndex = 21;
            this.chartSalt.Text = "염도";
            // 
            // chartPH
            // 
            this.chartPH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea23.Name = "ChartArea1";
            this.chartPH.ChartAreas.Add(chartArea23);
            legend23.Name = "Legend1";
            this.chartPH.Legends.Add(legend23);
            this.chartPH.Location = new System.Drawing.Point(775, 12);
            this.chartPH.Name = "chartPH";
            series23.ChartArea = "ChartArea1";
            series23.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series23.Legend = "Legend1";
            series23.Name = "PH";
            this.chartPH.Series.Add(series23);
            this.chartPH.Size = new System.Drawing.Size(628, 498);
            this.chartPH.TabIndex = 20;
            this.chartPH.Text = "PH";
            // 
            // chartTemperature
            // 
            this.chartTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea24.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea24);
            legend24.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend24);
            this.chartTemperature.Location = new System.Drawing.Point(775, 12);
            this.chartTemperature.Name = "chartTemperature";
            series24.ChartArea = "ChartArea1";
            series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series24.Legend = "Legend1";
            series24.Name = "온도";
            this.chartTemperature.Series.Add(series24);
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
            this.radioButtonVolt.TabStop = true;
            this.radioButtonVolt.Text = "음극전위";
            this.radioButtonVolt.UseVisualStyleBackColor = true;
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
            // 
            // buttonViewer
            // 
            this.buttonViewer.Location = new System.Drawing.Point(458, 17);
            this.buttonViewer.Name = "buttonViewer";
            this.buttonViewer.Size = new System.Drawing.Size(100, 70);
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
            this.dataGridView1.Location = new System.Drawing.Point(2, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(743, 397);
            this.dataGridView1.TabIndex = 16;
            // 
            // Column1
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column1.HeaderText = "기록시간";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column4.HeaderText = "온도";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle24;
            this.Column5.HeaderText = "pH농도";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle25;
            this.Column2.HeaderText = "염도";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle26;
            this.Column3.HeaderText = "용존 산소량";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle27;
            this.Column6.HeaderText = "음극전위";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle28;
            this.Column7.HeaderText = "양극전류";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RecvTextBox
            // 
            this.RecvTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RecvTextBox.Location = new System.Drawing.Point(341, 516);
            this.RecvTextBox.Multiline = true;
            this.RecvTextBox.Name = "RecvTextBox";
            this.RecvTextBox.ReadOnly = true;
            this.RecvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.RecvTextBox.Size = new System.Drawing.Size(402, 69);
            this.RecvTextBox.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxEnd);
            this.panel1.Controls.Add(this.textBoxTarget);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxDelay);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(2, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 89);
            this.panel1.TabIndex = 13;
            // 
            // textBoxTarget
            // 
            this.textBoxTarget.Enabled = false;
            this.textBoxTarget.Location = new System.Drawing.Point(285, 16);
            this.textBoxTarget.MaxLength = 3;
            this.textBoxTarget.Name = "textBoxTarget";
            this.textBoxTarget.Size = new System.Drawing.Size(142, 21);
            this.textBoxTarget.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "테스터 대상";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Enabled = false;
            this.textBoxDelay.Location = new System.Drawing.Point(285, 41);
            this.textBoxDelay.MaxLength = 3;
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(34, 21);
            this.textBoxDelay.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "종료일시";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "데이터 주기(분)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(176, 76);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Not Connected";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // SendTextBox
            // 
            this.SendTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // textBoxEnd
            // 
            this.textBoxEnd.Enabled = false;
            this.textBoxEnd.Location = new System.Drawing.Point(285, 63);
            this.textBoxEnd.MaxLength = 3;
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.Size = new System.Drawing.Size(142, 21);
            this.textBoxEnd.TabIndex = 14;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1417, 607);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.chartAmp);
            this.Controls.Add(this.chartVolt);
            this.Controls.Add(this.chartOxgen);
            this.Controls.Add(this.chartSalt);
            this.Controls.Add(this.chartPH);
            this.Controls.Add(this.chartTemperature);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonViewer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RecvTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SendTextBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICCP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chartAmp)).EndInit();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAmp;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.TextBox RecvTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox SendTextBox;
        private System.Windows.Forms.StatusStrip lblMsg;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

