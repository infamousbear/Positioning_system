namespace Position
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.X1_text = new System.Windows.Forms.TextBox();
            this.Y1_text = new System.Windows.Forms.TextBox();
            this.R1_text = new System.Windows.Forms.TextBox();
            this.X2_text = new System.Windows.Forms.TextBox();
            this.Y2_text = new System.Windows.Forms.TextBox();
            this.R2_text = new System.Windows.Forms.TextBox();
            this.X3_text = new System.Windows.Forms.TextBox();
            this.Y3_text = new System.Windows.Forms.TextBox();
            this.R3_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Wykres = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.Disconnect_bt = new System.Windows.Forms.Button();
            this.Connect_bt = new System.Windows.Forms.Button();
            this.Host_TXT = new System.Windows.Forms.TextBox();
            this.Port_TXT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Receiving_text = new System.Windows.Forms.TextBox();
            this.Start_Measure = new System.Windows.Forms.Button();
            this.Stop_Measure = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Interval_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.X_CALIB = new System.Windows.Forms.TextBox();
            this.Y_CALIB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Clear_Chart = new System.Windows.Forms.Button();
            this.Error_Period = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Interval_X_txt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Interval_Y_txt = new System.Windows.Forms.TextBox();
            this.Trilateration = new System.Windows.Forms.CheckBox();
            this.Anchor_measurement = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Max_val_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Avg_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Mov_std_avg = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Wykres)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(322, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // X1_text
            // 
            this.X1_text.Location = new System.Drawing.Point(93, 70);
            this.X1_text.Name = "X1_text";
            this.X1_text.Size = new System.Drawing.Size(67, 22);
            this.X1_text.TabIndex = 3;
            this.X1_text.Text = "0";
            // 
            // Y1_text
            // 
            this.Y1_text.Location = new System.Drawing.Point(93, 101);
            this.Y1_text.Name = "Y1_text";
            this.Y1_text.Size = new System.Drawing.Size(67, 22);
            this.Y1_text.TabIndex = 3;
            this.Y1_text.Text = "0";
            // 
            // R1_text
            // 
            this.R1_text.Location = new System.Drawing.Point(93, 131);
            this.R1_text.Name = "R1_text";
            this.R1_text.Size = new System.Drawing.Size(67, 22);
            this.R1_text.TabIndex = 3;
            this.R1_text.Text = "7000";
            // 
            // X2_text
            // 
            this.X2_text.Location = new System.Drawing.Point(169, 70);
            this.X2_text.Name = "X2_text";
            this.X2_text.Size = new System.Drawing.Size(67, 22);
            this.X2_text.TabIndex = 3;
            this.X2_text.Text = "1500";
            // 
            // Y2_text
            // 
            this.Y2_text.Location = new System.Drawing.Point(169, 101);
            this.Y2_text.Name = "Y2_text";
            this.Y2_text.Size = new System.Drawing.Size(67, 22);
            this.Y2_text.TabIndex = 3;
            this.Y2_text.Text = "0";
            // 
            // R2_text
            // 
            this.R2_text.Location = new System.Drawing.Point(169, 131);
            this.R2_text.Name = "R2_text";
            this.R2_text.Size = new System.Drawing.Size(67, 22);
            this.R2_text.TabIndex = 3;
            this.R2_text.Text = "3500";
            // 
            // X3_text
            // 
            this.X3_text.Location = new System.Drawing.Point(245, 70);
            this.X3_text.Name = "X3_text";
            this.X3_text.Size = new System.Drawing.Size(67, 22);
            this.X3_text.TabIndex = 3;
            this.X3_text.Text = "550";
            // 
            // Y3_text
            // 
            this.Y3_text.Location = new System.Drawing.Point(245, 101);
            this.Y3_text.Name = "Y3_text";
            this.Y3_text.Size = new System.Drawing.Size(67, 22);
            this.Y3_text.TabIndex = 3;
            this.Y3_text.Text = "3000";
            // 
            // R3_text
            // 
            this.R3_text.Location = new System.Drawing.Point(245, 131);
            this.R3_text.Name = "R3_text";
            this.R3_text.Size = new System.Drawing.Size(67, 22);
            this.R3_text.TabIndex = 3;
            this.R3_text.Text = "6000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "xi";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "yi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "ri";
            // 
            // Wykres
            // 
            this.Wykres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Wykres.BackColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.AxisX2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.Wykres.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.LightGray;
            legend1.Name = "Legend1";
            legend1.TitleBackColor = System.Drawing.Color.LightGray;
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Wykres.Legends.Add(legend1);
            this.Wykres.Location = new System.Drawing.Point(426, 15);
            this.Wykres.Name = "Wykres";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            series1.Legend = "Legend1";
            series1.Name = "Obliczenia";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.MarkerSize = 10;
            series2.Name = "Kotwica";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series3.MarkerSize = 8;
            series3.Name = "Pozycja";
            this.Wykres.Series.Add(series1);
            this.Wykres.Series.Add(series2);
            this.Wykres.Series.Add(series3);
            this.Wykres.Size = new System.Drawing.Size(784, 530);
            this.Wykres.TabIndex = 5;
            this.Wykres.Text = "chart1";
            this.Wykres.Click += new System.EventHandler(this.chart1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(322, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Random";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Disconnect_bt
            // 
            this.Disconnect_bt.Location = new System.Drawing.Point(322, 58);
            this.Disconnect_bt.Name = "Disconnect_bt";
            this.Disconnect_bt.Size = new System.Drawing.Size(98, 29);
            this.Disconnect_bt.TabIndex = 7;
            this.Disconnect_bt.Text = "Disconnect";
            this.Disconnect_bt.UseVisualStyleBackColor = true;
            this.Disconnect_bt.Click += new System.EventHandler(this.Disconnect_bt_Click);
            // 
            // Connect_bt
            // 
            this.Connect_bt.Location = new System.Drawing.Point(322, 15);
            this.Connect_bt.Name = "Connect_bt";
            this.Connect_bt.Size = new System.Drawing.Size(98, 37);
            this.Connect_bt.TabIndex = 8;
            this.Connect_bt.Text = "Connect";
            this.Connect_bt.UseVisualStyleBackColor = true;
            this.Connect_bt.Click += new System.EventHandler(this.Connect_bt_Click);
            // 
            // Host_TXT
            // 
            this.Host_TXT.Location = new System.Drawing.Point(93, 12);
            this.Host_TXT.Name = "Host_TXT";
            this.Host_TXT.Size = new System.Drawing.Size(219, 22);
            this.Host_TXT.TabIndex = 9;
            this.Host_TXT.Text = "192.168.0.101";
            // 
            // Port_TXT
            // 
            this.Port_TXT.Location = new System.Drawing.Point(93, 42);
            this.Port_TXT.Name = "Port_TXT";
            this.Port_TXT.Size = new System.Drawing.Size(219, 22);
            this.Port_TXT.TabIndex = 10;
            this.Port_TXT.Text = "80";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(51, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Host";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Port";
            // 
            // Receiving_text
            // 
            this.Receiving_text.Location = new System.Drawing.Point(93, 163);
            this.Receiving_text.Name = "Receiving_text";
            this.Receiving_text.Size = new System.Drawing.Size(326, 22);
            this.Receiving_text.TabIndex = 13;
            // 
            // Start_Measure
            // 
            this.Start_Measure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Start_Measure.Location = new System.Drawing.Point(183, 217);
            this.Start_Measure.Name = "Start_Measure";
            this.Start_Measure.Size = new System.Drawing.Size(115, 29);
            this.Start_Measure.TabIndex = 14;
            this.Start_Measure.Text = "Start Measure";
            this.Start_Measure.UseVisualStyleBackColor = true;
            this.Start_Measure.Click += new System.EventHandler(this.Start_Measure_Click);
            // 
            // Stop_Measure
            // 
            this.Stop_Measure.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Stop_Measure.Location = new System.Drawing.Point(304, 217);
            this.Stop_Measure.Name = "Stop_Measure";
            this.Stop_Measure.Size = new System.Drawing.Size(115, 29);
            this.Stop_Measure.TabIndex = 15;
            this.Stop_Measure.Text = "Stop Measure";
            this.Stop_Measure.UseVisualStyleBackColor = true;
            this.Stop_Measure.Click += new System.EventHandler(this.Stop_Measure_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Interval_txt
            // 
            this.Interval_txt.Location = new System.Drawing.Point(93, 220);
            this.Interval_txt.Name = "Interval_txt";
            this.Interval_txt.Size = new System.Drawing.Size(79, 22);
            this.Interval_txt.TabIndex = 16;
            this.Interval_txt.Text = "250";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Czas";
            // 
            // X_CALIB
            // 
            this.X_CALIB.Location = new System.Drawing.Point(93, 248);
            this.X_CALIB.Name = "X_CALIB";
            this.X_CALIB.Size = new System.Drawing.Size(79, 22);
            this.X_CALIB.TabIndex = 18;
            this.X_CALIB.Text = "200";
            // 
            // Y_CALIB
            // 
            this.Y_CALIB.Location = new System.Drawing.Point(93, 276);
            this.Y_CALIB.Name = "Y_CALIB";
            this.Y_CALIB.Size = new System.Drawing.Size(79, 22);
            this.Y_CALIB.TabIndex = 19;
            this.Y_CALIB.Text = "200";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "X_calib";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Y_calib";
            // 
            // Clear_Chart
            // 
            this.Clear_Chart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Clear_Chart.Location = new System.Drawing.Point(183, 252);
            this.Clear_Chart.Name = "Clear_Chart";
            this.Clear_Chart.Size = new System.Drawing.Size(236, 29);
            this.Clear_Chart.TabIndex = 22;
            this.Clear_Chart.Text = "Clear Chart";
            this.Clear_Chart.UseVisualStyleBackColor = true;
            this.Clear_Chart.Click += new System.EventHandler(this.Clear_Chart_Click);
            // 
            // Error_Period
            // 
            this.Error_Period.Location = new System.Drawing.Point(93, 304);
            this.Error_Period.Name = "Error_Period";
            this.Error_Period.Size = new System.Drawing.Size(79, 22);
            this.Error_Period.TabIndex = 23;
            this.Error_Period.Text = "1000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 307);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Error_period";
            // 
            // Interval_X_txt
            // 
            this.Interval_X_txt.Location = new System.Drawing.Point(93, 332);
            this.Interval_X_txt.Name = "Interval_X_txt";
            this.Interval_X_txt.Size = new System.Drawing.Size(79, 22);
            this.Interval_X_txt.TabIndex = 25;
            this.Interval_X_txt.Text = "300";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 335);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "Interval X:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 363);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Interval Y:";
            // 
            // Interval_Y_txt
            // 
            this.Interval_Y_txt.Location = new System.Drawing.Point(93, 360);
            this.Interval_Y_txt.Name = "Interval_Y_txt";
            this.Interval_Y_txt.Size = new System.Drawing.Size(79, 22);
            this.Interval_Y_txt.TabIndex = 27;
            this.Interval_Y_txt.Text = "300";
            // 
            // Trilateration
            // 
            this.Trilateration.AutoSize = true;
            this.Trilateration.Location = new System.Drawing.Point(183, 289);
            this.Trilateration.Name = "Trilateration";
            this.Trilateration.Size = new System.Drawing.Size(148, 20);
            this.Trilateration.TabIndex = 28;
            this.Trilateration.Text = "Trilateracja ON/OFF";
            this.Trilateration.UseVisualStyleBackColor = true;
            // 
            // Anchor_measurement
            // 
            this.Anchor_measurement.AutoSize = true;
            this.Anchor_measurement.Location = new System.Drawing.Point(183, 317);
            this.Anchor_measurement.Name = "Anchor_measurement";
            this.Anchor_measurement.Size = new System.Drawing.Size(167, 20);
            this.Anchor_measurement.TabIndex = 29;
            this.Anchor_measurement.Text = "Tryb Pomiaru Anchor_1";
            this.Anchor_measurement.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(326, 22);
            this.textBox1.TabIndex = 30;
            // 
            // Max_val_txt
            // 
            this.Max_val_txt.Location = new System.Drawing.Point(93, 389);
            this.Max_val_txt.Name = "Max_val_txt";
            this.Max_val_txt.Size = new System.Drawing.Size(79, 22);
            this.Max_val_txt.TabIndex = 31;
            this.Max_val_txt.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Max Value";
            // 
            // Avg_txt
            // 
            this.Avg_txt.Location = new System.Drawing.Point(93, 418);
            this.Avg_txt.Name = "Avg_txt";
            this.Avg_txt.Size = new System.Drawing.Size(79, 22);
            this.Avg_txt.TabIndex = 33;
            this.Avg_txt.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "Avg n";
            // 
            // Mov_std_avg
            // 
            this.Mov_std_avg.AutoSize = true;
            this.Mov_std_avg.Location = new System.Drawing.Point(183, 343);
            this.Mov_std_avg.Name = "Mov_std_avg";
            this.Mov_std_avg.Size = new System.Drawing.Size(184, 20);
            this.Mov_std_avg.TabIndex = 35;
            this.Mov_std_avg.Text = "Moving Avg/Standard Avg";
            this.Mov_std_avg.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1222, 557);
            this.Controls.Add(this.Mov_std_avg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Avg_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Max_val_txt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Host_TXT);
            this.Controls.Add(this.Disconnect_bt);
            this.Controls.Add(this.Connect_bt);
            this.Controls.Add(this.Anchor_measurement);
            this.Controls.Add(this.Port_TXT);
            this.Controls.Add(this.Trilateration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Interval_Y_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Interval_X_txt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Error_Period);
            this.Controls.Add(this.Clear_Chart);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Y_CALIB);
            this.Controls.Add(this.X_CALIB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Interval_txt);
            this.Controls.Add(this.Stop_Measure);
            this.Controls.Add(this.Start_Measure);
            this.Controls.Add(this.Receiving_text);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Wykres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.R3_text);
            this.Controls.Add(this.R2_text);
            this.Controls.Add(this.R1_text);
            this.Controls.Add(this.Y3_text);
            this.Controls.Add(this.X3_text);
            this.Controls.Add(this.Y2_text);
            this.Controls.Add(this.X2_text);
            this.Controls.Add(this.Y1_text);
            this.Controls.Add(this.X1_text);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Positioning_system_alpha";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Wykres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox X1_text;
        private System.Windows.Forms.TextBox Y1_text;
        private System.Windows.Forms.TextBox R1_text;
        private System.Windows.Forms.TextBox X2_text;
        private System.Windows.Forms.TextBox Y2_text;
        private System.Windows.Forms.TextBox R2_text;
        private System.Windows.Forms.TextBox X3_text;
        private System.Windows.Forms.TextBox Y3_text;
        private System.Windows.Forms.TextBox R3_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart Wykres;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Disconnect_bt;
        private System.Windows.Forms.Button Connect_bt;
        private System.Windows.Forms.TextBox Host_TXT;
        private System.Windows.Forms.TextBox Port_TXT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Receiving_text;
        private System.Windows.Forms.Button Start_Measure;
        private System.Windows.Forms.Button Stop_Measure;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox Interval_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox X_CALIB;
        private System.Windows.Forms.TextBox Y_CALIB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Clear_Chart;
        private System.Windows.Forms.TextBox Error_Period;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Interval_X_txt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Interval_Y_txt;
        private System.Windows.Forms.CheckBox Trilateration;
        private System.Windows.Forms.CheckBox Anchor_measurement;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox Max_val_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Avg_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox Mov_std_avg;
    }
}

