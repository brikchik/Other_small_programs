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
            this.successLabel = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.unitsList = new System.Windows.Forms.ListBox();
            this.readList = new System.Windows.Forms.ListBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.currentLablel = new System.Windows.Forms.Label();
            this.sensorList = new System.Windows.Forms.ListBox();
            this.sensorLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.dropButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
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
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Location = new System.Drawing.Point(10, 292);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(74, 13);
            this.successLabel.TabIndex = 3;
            this.successLabel.Text = "Ток не задан";
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(120, 74);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(476, 36);
            this.readButton.TabIndex = 4;
            this.readButton.Text = "Считать значения";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.button1_Click);
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
            this.trackBar.Location = new System.Drawing.Point(12, 116);
            this.trackBar.Maximum = 30;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(583, 45);
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
            this.sensorList.Location = new System.Drawing.Point(13, 157);
            this.sensorList.Name = "sensorList";
            this.sensorList.Size = new System.Drawing.Size(101, 69);
            this.sensorList.TabIndex = 13;
            this.sensorList.Tag = "";
            this.sensorList.SelectedIndexChanged += new System.EventHandler(this.sensorList_SelectedIndexChanged);
            // 
            // sensorLabel
            // 
            this.sensorLabel.AutoSize = true;
            this.sensorLabel.Location = new System.Drawing.Point(12, 317);
            this.sensorLabel.Name = "sensorLabel";
            this.sensorLabel.Size = new System.Drawing.Size(0, 13);
            this.sensorLabel.TabIndex = 14;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 232);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 23);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // dropButton
            // 
            this.dropButton.Location = new System.Drawing.Point(12, 262);
            this.dropButton.Name = "dropButton";
            this.dropButton.Size = new System.Drawing.Size(102, 23);
            this.dropButton.TabIndex = 16;
            this.dropButton.Text = "Удалить";
            this.dropButton.UseVisualStyleBackColor = true;
            this.dropButton.Click += new System.EventHandler(this.dropButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 339);
            this.Controls.Add(this.dropButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.sensorLabel);
            this.Controls.Add(this.sensorList);
            this.Controls.Add(this.currentLablel);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.readList);
            this.Controls.Add(this.unitsList);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.current_label);
            this.Controls.Add(this.currentBox);
            this.Controls.Add(this.currentButton);
            this.Name = "Form1";
            this.Text = "Токовый датчик давления";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button currentButton;
        private System.Windows.Forms.TextBox currentBox;
        private System.Windows.Forms.Label current_label;
        private System.Windows.Forms.Label successLabel;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.ListBox unitsList;
        private System.Windows.Forms.ListBox readList;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label currentLablel;
        private System.Windows.Forms.ListBox sensorList;
        private System.Windows.Forms.Label sensorLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button dropButton;
    }
}

