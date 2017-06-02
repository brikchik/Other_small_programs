namespace TDD
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
            this.currentButton = new System.Windows.Forms.Button();
            this.currentBox = new System.Windows.Forms.TextBox();
            this.current_label = new System.Windows.Forms.Label();
            this.unitsList = new System.Windows.Forms.ListBox();
            this.readList = new System.Windows.Forms.ListBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.currentLablel = new System.Windows.Forms.Label();
            this.sensorList = new System.Windows.Forms.ListBox();
            this.sensorLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.dropButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.mul2 = new System.Windows.Forms.TextBox();
            this.multButton = new System.Windows.Forms.Button();
            this.mul = new System.Windows.Forms.TextBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // currentButton
            // 
            this.currentButton.Location = new System.Drawing.Point(7, 87);
            this.currentButton.Name = "currentButton";
            this.currentButton.Size = new System.Drawing.Size(107, 23);
            this.currentButton.TabIndex = 0;
            this.currentButton.Text = "Задать ток";
            this.currentButton.UseVisualStyleBackColor = true;
            this.currentButton.Click += new System.EventHandler(this.currentButton_Click);
            // 
            // currentBox
            // 
            this.currentBox.Location = new System.Drawing.Point(6, 57);
            this.currentBox.Name = "currentBox";
            this.currentBox.Size = new System.Drawing.Size(78, 20);
            this.currentBox.TabIndex = 1;
            this.currentBox.Text = "4";
            // 
            // current_label
            // 
            this.current_label.AutoSize = true;
            this.current_label.Location = new System.Drawing.Point(92, 60);
            this.current_label.Name = "current_label";
            this.current_label.Size = new System.Drawing.Size(22, 13);
            this.current_label.TabIndex = 2;
            this.current_label.Text = "мА";
            // 
            // unitsList
            // 
            this.unitsList.FormattingEnabled = true;
            this.unitsList.Items.AddRange(new object[] {
            "мм.рт.ст.",
            "МПа",
            "кПа",
            "кгс/кв.см"});
            this.unitsList.Location = new System.Drawing.Point(119, 12);
            this.unitsList.Name = "unitsList";
            this.unitsList.Size = new System.Drawing.Size(184, 56);
            this.unitsList.TabIndex = 8;
            this.unitsList.SelectedIndexChanged += new System.EventHandler(this.unitsList_SelectedIndexChanged);
            // 
            // readList
            // 
            this.readList.FormattingEnabled = true;
            this.readList.Items.AddRange(new object[] {
            "I=",
            "P=",
            "Pmin=",
            "Pmax="});
            this.readList.Location = new System.Drawing.Point(309, 12);
            this.readList.Name = "readList";
            this.readList.Size = new System.Drawing.Size(287, 56);
            this.readList.TabIndex = 10;
            // 
            // trackBar
            // 
            this.trackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBar.Location = new System.Drawing.Point(121, 74);
            this.trackBar.Maximum = 30;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(475, 45);
            this.trackBar.TabIndex = 11;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // currentLablel
            // 
            this.currentLablel.Location = new System.Drawing.Point(4, 9);
            this.currentLablel.Name = "currentLablel";
            this.currentLablel.Size = new System.Drawing.Size(109, 45);
            this.currentLablel.TabIndex = 12;
            this.currentLablel.Text = "Задайте значение тока числом или ползунком";
            // 
            // sensorList
            // 
            this.sensorList.FormattingEnabled = true;
            this.sensorList.Location = new System.Drawing.Point(8, 116);
            this.sensorList.Name = "sensorList";
            this.sensorList.Size = new System.Drawing.Size(101, 69);
            this.sensorList.TabIndex = 13;
            this.sensorList.Tag = "";
            this.sensorList.SelectedIndexChanged += new System.EventHandler(this.sensorList_SelectedIndexChanged);
            // 
            // sensorLabel
            // 
            this.sensorLabel.AutoSize = true;
            this.sensorLabel.Location = new System.Drawing.Point(5, 357);
            this.sensorLabel.Name = "sensorLabel";
            this.sensorLabel.Size = new System.Drawing.Size(0, 13);
            this.sensorLabel.TabIndex = 14;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(7, 191);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 23);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // dropButton
            // 
            this.dropButton.Location = new System.Drawing.Point(6, 220);
            this.dropButton.Name = "dropButton";
            this.dropButton.Size = new System.Drawing.Size(102, 23);
            this.dropButton.TabIndex = 16;
            this.dropButton.Text = "Удалить";
            this.dropButton.UseVisualStyleBackColor = true;
            this.dropButton.Click += new System.EventHandler(this.dropButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 39);
            this.button1.TabIndex = 17;
            this.button1.Text = "сравнить 1 и 2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "1 Сенсор";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "2 Сенсор";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "^";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.mul2);
            this.groupBox1.Controls.Add(this.multButton);
            this.groupBox1.Controls.Add(this.mul);
            this.groupBox1.Controls.Add(this.PictureBox1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(144, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 257);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Графики";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 35);
            this.button2.TabIndex = 23;
            this.button2.Text = "Масштаб";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // mul2
            // 
            this.mul2.Location = new System.Drawing.Point(7, 166);
            this.mul2.Name = "mul2";
            this.mul2.Size = new System.Drawing.Size(85, 20);
            this.mul2.TabIndex = 22;
            this.mul2.Text = "1";
            // 
            // multButton
            // 
            this.multButton.Location = new System.Drawing.Point(8, 81);
            this.multButton.Name = "multButton";
            this.multButton.Size = new System.Drawing.Size(86, 35);
            this.multButton.TabIndex = 3;
            this.multButton.Text = "Умножить функцию";
            this.multButton.UseVisualStyleBackColor = true;
            this.multButton.Click += new System.EventHandler(this.multButton_Click);
            // 
            // mul
            // 
            this.mul.Location = new System.Drawing.Point(8, 55);
            this.mul.Name = "mul";
            this.mul.Size = new System.Drawing.Size(85, 20);
            this.mul.TabIndex = 2;
            this.mul.Text = "1";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(98, 19);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(348, 235);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Sin график",
            "П_П_П график"});
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(86, 30);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 317);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(132, 35);
            this.button3.TabIndex = 22;
            this.button3.Text = "обновить графики";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_label,
            this.StatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(608, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status_label
            // 
            this.Status_label.Name = "Status_label";
            this.Status_label.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusLabel2
            // 
            this.StatusLabel2.Name = "StatusLabel2";
            this.StatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 124);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 36);
            this.button4.TabIndex = 24;
            this.button4.Text = "1/2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 379);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dropButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.sensorLabel);
            this.Controls.Add(this.sensorList);
            this.Controls.Add(this.currentLablel);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.readList);
            this.Controls.Add(this.unitsList);
            this.Controls.Add(this.current_label);
            this.Controls.Add(this.currentBox);
            this.Controls.Add(this.currentButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Токовый датчик давления";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button currentButton;
        private System.Windows.Forms.TextBox currentBox;
        private System.Windows.Forms.Label current_label;
        private System.Windows.Forms.ListBox unitsList;
        private System.Windows.Forms.ListBox readList;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label currentLablel;
        private System.Windows.Forms.ListBox sensorList;
        private System.Windows.Forms.Label sensorLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button dropButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Button multButton;
        private System.Windows.Forms.TextBox mul;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox mul2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status_label;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel2;
        private System.Windows.Forms.Button button4;
    }
}

