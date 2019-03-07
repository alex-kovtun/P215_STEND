namespace P215Test
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonChooseAll = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonSurvey = new System.Windows.Forms.Button();
            this.buttonVideo = new System.Windows.Forms.Button();
            this.labelSpeedText = new System.Windows.Forms.Label();
            this.radioButtonSpeed100 = new System.Windows.Forms.RadioButton();
            this.radioButtonSpeed10 = new System.Windows.Forms.RadioButton();
            this.groupBoxPorts = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBoxPorts.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChooseAll
            // 
            this.buttonChooseAll.Location = new System.Drawing.Point(13, 13);
            this.buttonChooseAll.Name = "buttonChooseAll";
            this.buttonChooseAll.Size = new System.Drawing.Size(153, 27);
            this.buttonChooseAll.TabIndex = 0;
            this.buttonChooseAll.Text = "Выбрать все";
            this.buttonChooseAll.UseVisualStyleBackColor = true;
            this.buttonChooseAll.Click += new System.EventHandler(this.ButtonChooseAll_Click);
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(185, 13);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(154, 27);
            this.buttonRemoveAll.TabIndex = 1;
            this.buttonRemoveAll.Text = "Убрать все";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.ButtonRemoveAll_Click);
            // 
            // buttonSurvey
            // 
            this.buttonSurvey.Location = new System.Drawing.Point(591, 13);
            this.buttonSurvey.Name = "buttonSurvey";
            this.buttonSurvey.Size = new System.Drawing.Size(154, 46);
            this.buttonSurvey.TabIndex = 2;
            this.buttonSurvey.Text = "ОПРОС";
            this.buttonSurvey.UseVisualStyleBackColor = true;
            this.buttonSurvey.Click += new System.EventHandler(this.ButtonSurvey_Click);
            // 
            // buttonVideo
            // 
            this.buttonVideo.Location = new System.Drawing.Point(753, 13);
            this.buttonVideo.Name = "buttonVideo";
            this.buttonVideo.Size = new System.Drawing.Size(156, 46);
            this.buttonVideo.TabIndex = 3;
            this.buttonVideo.Text = "ВИДЕО";
            this.buttonVideo.UseVisualStyleBackColor = true;
            this.buttonVideo.Click += new System.EventHandler(this.ButtonVideo_Click);
            // 
            // labelSpeedText
            // 
            this.labelSpeedText.AutoSize = true;
            this.labelSpeedText.Location = new System.Drawing.Point(390, 13);
            this.labelSpeedText.Name = "labelSpeedText";
            this.labelSpeedText.Size = new System.Drawing.Size(145, 13);
            this.labelSpeedText.TabIndex = 4;
            this.labelSpeedText.Text = "Скорость передачи данных";
            // 
            // radioButtonSpeed100
            // 
            this.radioButtonSpeed100.AutoSize = true;
            this.radioButtonSpeed100.Location = new System.Drawing.Point(393, 30);
            this.radioButtonSpeed100.Name = "radioButtonSpeed100";
            this.radioButtonSpeed100.Size = new System.Drawing.Size(83, 17);
            this.radioButtonSpeed100.TabIndex = 5;
            this.radioButtonSpeed100.TabStop = true;
            this.radioButtonSpeed100.Text = "100 Мбит/с";
            this.radioButtonSpeed100.UseVisualStyleBackColor = true;
            this.radioButtonSpeed100.CheckedChanged += new System.EventHandler(this.RadioButtonSpeed_CheckedChanged);
            // 
            // radioButtonSpeed10
            // 
            this.radioButtonSpeed10.AutoSize = true;
            this.radioButtonSpeed10.Location = new System.Drawing.Point(393, 53);
            this.radioButtonSpeed10.Name = "radioButtonSpeed10";
            this.radioButtonSpeed10.Size = new System.Drawing.Size(77, 17);
            this.radioButtonSpeed10.TabIndex = 6;
            this.radioButtonSpeed10.TabStop = true;
            this.radioButtonSpeed10.Text = "10 Мбит/с";
            this.radioButtonSpeed10.UseVisualStyleBackColor = true;
            this.radioButtonSpeed10.CheckedChanged += new System.EventHandler(this.RadioButtonSpeed_CheckedChanged);
            // 
            // groupBoxPorts
            // 
            this.groupBoxPorts.Controls.Add(this.label16);
            this.groupBoxPorts.Controls.Add(this.label15);
            this.groupBoxPorts.Controls.Add(this.label14);
            this.groupBoxPorts.Controls.Add(this.label13);
            this.groupBoxPorts.Controls.Add(this.label12);
            this.groupBoxPorts.Controls.Add(this.label11);
            this.groupBoxPorts.Controls.Add(this.label10);
            this.groupBoxPorts.Controls.Add(this.label9);
            this.groupBoxPorts.Controls.Add(this.label8);
            this.groupBoxPorts.Controls.Add(this.label7);
            this.groupBoxPorts.Controls.Add(this.label6);
            this.groupBoxPorts.Controls.Add(this.label5);
            this.groupBoxPorts.Controls.Add(this.label4);
            this.groupBoxPorts.Controls.Add(this.label3);
            this.groupBoxPorts.Controls.Add(this.label2);
            this.groupBoxPorts.Controls.Add(this.label1);
            this.groupBoxPorts.Controls.Add(this.checkBox16);
            this.groupBoxPorts.Controls.Add(this.checkBox15);
            this.groupBoxPorts.Controls.Add(this.checkBox12);
            this.groupBoxPorts.Controls.Add(this.checkBox11);
            this.groupBoxPorts.Controls.Add(this.checkBox14);
            this.groupBoxPorts.Controls.Add(this.checkBox10);
            this.groupBoxPorts.Controls.Add(this.checkBox13);
            this.groupBoxPorts.Controls.Add(this.checkBox9);
            this.groupBoxPorts.Controls.Add(this.checkBox7);
            this.groupBoxPorts.Controls.Add(this.checkBox8);
            this.groupBoxPorts.Controls.Add(this.checkBox6);
            this.groupBoxPorts.Controls.Add(this.checkBox5);
            this.groupBoxPorts.Controls.Add(this.checkBox4);
            this.groupBoxPorts.Controls.Add(this.checkBox3);
            this.groupBoxPorts.Controls.Add(this.checkBox2);
            this.groupBoxPorts.Controls.Add(this.checkBox1);
            this.groupBoxPorts.Location = new System.Drawing.Point(13, 76);
            this.groupBoxPorts.Name = "groupBoxPorts";
            this.groupBoxPorts.Size = new System.Drawing.Size(907, 292);
            this.groupBoxPorts.TabIndex = 7;
            this.groupBoxPorts.TabStop = false;
            this.groupBoxPorts.Text = "Порты";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label16.Location = new System.Drawing.Point(734, 240);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 31);
            this.label16.TabIndex = 31;
            this.label16.Text = "label16";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label15.Location = new System.Drawing.Point(734, 170);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 31);
            this.label15.TabIndex = 30;
            this.label15.Text = "label15";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label14.Location = new System.Drawing.Point(734, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 31);
            this.label14.TabIndex = 29;
            this.label14.Text = "label14";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label13.Location = new System.Drawing.Point(734, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 31);
            this.label13.TabIndex = 28;
            this.label13.Text = "label13";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label12.Location = new System.Drawing.Point(513, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 31);
            this.label12.TabIndex = 27;
            this.label12.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label11.Location = new System.Drawing.Point(513, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 31);
            this.label11.TabIndex = 26;
            this.label11.Text = "label11";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label10.Location = new System.Drawing.Point(513, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 31);
            this.label10.TabIndex = 25;
            this.label10.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label9.Location = new System.Drawing.Point(513, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 31);
            this.label9.TabIndex = 24;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label8.Location = new System.Drawing.Point(281, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 31);
            this.label8.TabIndex = 23;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label7.Location = new System.Drawing.Point(281, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 31);
            this.label7.TabIndex = 22;
            this.label7.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label6.Location = new System.Drawing.Point(281, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 31);
            this.label6.TabIndex = 21;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label5.Location = new System.Drawing.Point(281, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 31);
            this.label5.TabIndex = 20;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(60, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 31);
            this.label4.TabIndex = 19;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(59, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 18;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(60, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 31);
            this.label2.TabIndex = 17;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(60, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox16.Location = new System.Drawing.Point(684, 245);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(55, 29);
            this.checkBox16.TabIndex = 16;
            this.checkBox16.Text = "16";
            this.checkBox16.UseVisualStyleBackColor = true;
            this.checkBox16.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox15.Location = new System.Drawing.Point(684, 175);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(55, 29);
            this.checkBox15.TabIndex = 15;
            this.checkBox15.Text = "15";
            this.checkBox15.UseVisualStyleBackColor = true;
            this.checkBox15.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox12.Location = new System.Drawing.Point(464, 245);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(55, 29);
            this.checkBox12.TabIndex = 12;
            this.checkBox12.Text = "12";
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox11.Location = new System.Drawing.Point(464, 175);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(55, 29);
            this.checkBox11.TabIndex = 11;
            this.checkBox11.Text = "11";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox14
            // 
            this.checkBox14.AutoSize = true;
            this.checkBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox14.Location = new System.Drawing.Point(684, 105);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(55, 29);
            this.checkBox14.TabIndex = 14;
            this.checkBox14.Text = "14";
            this.checkBox14.UseVisualStyleBackColor = true;
            this.checkBox14.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox10.Location = new System.Drawing.Point(464, 105);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(55, 29);
            this.checkBox10.TabIndex = 10;
            this.checkBox10.Text = "10";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox13
            // 
            this.checkBox13.AutoSize = true;
            this.checkBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox13.Location = new System.Drawing.Point(684, 35);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(55, 29);
            this.checkBox13.TabIndex = 13;
            this.checkBox13.Text = "13";
            this.checkBox13.UseVisualStyleBackColor = true;
            this.checkBox13.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox9.Location = new System.Drawing.Point(464, 35);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(43, 29);
            this.checkBox9.TabIndex = 8;
            this.checkBox9.Text = "9";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox7.Location = new System.Drawing.Point(244, 175);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(43, 29);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.Text = "7";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox8.Location = new System.Drawing.Point(244, 245);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(43, 29);
            this.checkBox8.TabIndex = 8;
            this.checkBox8.Text = "8";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox6.Location = new System.Drawing.Point(244, 105);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(43, 29);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "6";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox5.Location = new System.Drawing.Point(244, 35);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(43, 29);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "5";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox4.Location = new System.Drawing.Point(24, 245);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(43, 29);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox3.Location = new System.Drawing.Point(24, 175);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(43, 29);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox2.Location = new System.Drawing.Point(24, 105);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(43, 29);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.checkBox1.Location = new System.Drawing.Point(24, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(43, 29);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_Progress);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_Completed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 385);
            this.Controls.Add(this.groupBoxPorts);
            this.Controls.Add(this.radioButtonSpeed10);
            this.Controls.Add(this.radioButtonSpeed100);
            this.Controls.Add(this.labelSpeedText);
            this.Controls.Add(this.buttonVideo);
            this.Controls.Add(this.buttonSurvey);
            this.Controls.Add(this.buttonRemoveAll);
            this.Controls.Add(this.buttonChooseAll);
            this.Name = "Form1";
            this.Text = "Тест портов коммутатора Р215";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxPorts.ResumeLayout(false);
            this.groupBoxPorts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChooseAll;
        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.Button buttonSurvey;
        private System.Windows.Forms.Button buttonVideo;
        private System.Windows.Forms.Label labelSpeedText;
        private System.Windows.Forms.RadioButton radioButtonSpeed100;
        private System.Windows.Forms.RadioButton radioButtonSpeed10;
        private System.Windows.Forms.GroupBox groupBoxPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Timer timer;
    }
}

