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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // currentButton
            // 
            this.currentButton.Location = new System.Drawing.Point(12, 40);
            this.currentButton.Name = "currentButton";
            this.currentButton.Size = new System.Drawing.Size(101, 23);
            this.currentButton.TabIndex = 0;
            this.currentButton.Text = "Задать ток";
            this.currentButton.UseVisualStyleBackColor = true;
            this.currentButton.Click += new System.EventHandler(this.currentButton_Click);
            // 
            // currentBox
            // 
            this.currentBox.Location = new System.Drawing.Point(13, 14);
            this.currentBox.Name = "currentBox";
            this.currentBox.Size = new System.Drawing.Size(72, 20);
            this.currentBox.TabIndex = 1;
            // 
            // current_label
            // 
            this.current_label.AutoSize = true;
            this.current_label.Location = new System.Drawing.Point(91, 17);
            this.current_label.Name = "current_label";
            this.current_label.Size = new System.Drawing.Size(22, 13);
            this.current_label.TabIndex = 2;
            this.current_label.Text = "мА";
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Location = new System.Drawing.Point(12, 91);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(74, 13);
            this.successLabel.TabIndex = 3;
            this.successLabel.Text = "Ток не задан";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ток не задан";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(185, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Задать ток";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 339);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.current_label);
            this.Controls.Add(this.currentBox);
            this.Controls.Add(this.currentButton);
            this.Name = "Form1";
            this.Text = "Токовый датчик давления";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button currentButton;
        private System.Windows.Forms.TextBox currentBox;
        private System.Windows.Forms.Label current_label;
        private System.Windows.Forms.Label successLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

