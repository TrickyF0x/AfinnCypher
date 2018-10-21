namespace AfinnCypher
{
    partial class MainForm
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
            this.in_richTextBox = new System.Windows.Forms.RichTextBox();
            this.encrypt_button = new System.Windows.Forms.Button();
            this.out_richTextBox = new System.Windows.Forms.RichTextBox();
            this.decrypt_button = new System.Windows.Forms.Button();
            this.textBox_a = new System.Windows.Forms.TextBox();
            this.textBox_b = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clear_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // in_richTextBox
            // 
            this.in_richTextBox.Location = new System.Drawing.Point(12, 116);
            this.in_richTextBox.Name = "in_richTextBox";
            this.in_richTextBox.Size = new System.Drawing.Size(436, 225);
            this.in_richTextBox.TabIndex = 0;
            this.in_richTextBox.Text = "";
            // 
            // encrypt_button
            // 
            this.encrypt_button.Location = new System.Drawing.Point(454, 116);
            this.encrypt_button.Name = "encrypt_button";
            this.encrypt_button.Size = new System.Drawing.Size(120, 29);
            this.encrypt_button.TabIndex = 1;
            this.encrypt_button.Text = "Зашифровать";
            this.encrypt_button.UseVisualStyleBackColor = true;
            this.encrypt_button.Click += new System.EventHandler(this.encrypt_button_Click);
            // 
            // out_richTextBox
            // 
            this.out_richTextBox.Location = new System.Drawing.Point(580, 116);
            this.out_richTextBox.Name = "out_richTextBox";
            this.out_richTextBox.ReadOnly = true;
            this.out_richTextBox.Size = new System.Drawing.Size(436, 225);
            this.out_richTextBox.TabIndex = 2;
            this.out_richTextBox.Text = "";
            // 
            // decrypt_button
            // 
            this.decrypt_button.Location = new System.Drawing.Point(454, 160);
            this.decrypt_button.Name = "decrypt_button";
            this.decrypt_button.Size = new System.Drawing.Size(120, 29);
            this.decrypt_button.TabIndex = 3;
            this.decrypt_button.Text = "Расшифровать";
            this.decrypt_button.UseVisualStyleBackColor = true;
            // 
            // textBox_a
            // 
            this.textBox_a.Location = new System.Drawing.Point(46, 12);
            this.textBox_a.Name = "textBox_a";
            this.textBox_a.Size = new System.Drawing.Size(100, 22);
            this.textBox_a.TabIndex = 4;
            this.textBox_a.TextChanged += new System.EventHandler(this.textBox_a_TextChanged);
            // 
            // textBox_b
            // 
            this.textBox_b.Location = new System.Drawing.Point(46, 56);
            this.textBox_b.Name = "textBox_b";
            this.textBox_b.Size = new System.Drawing.Size(100, 22);
            this.textBox_b.TabIndex = 5;
            this.textBox_b.TextChanged += new System.EventHandler(this.textBox_b_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "b";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ввод";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(593, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Вывод";
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(454, 301);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(120, 41);
            this.clear_button.TabIndex = 10;
            this.clear_button.Text = "Очистить";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AfinnCypher.Properties.Resources.afiny;
            this.ClientSize = new System.Drawing.Size(1033, 354);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_b);
            this.Controls.Add(this.textBox_a);
            this.Controls.Add(this.decrypt_button);
            this.Controls.Add(this.out_richTextBox);
            this.Controls.Add(this.encrypt_button);
            this.Controls.Add(this.in_richTextBox);
            this.Name = "MainForm";
            this.Text = "Афинный шифр";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox in_richTextBox;
        private System.Windows.Forms.Button encrypt_button;
        private System.Windows.Forms.RichTextBox out_richTextBox;
        private System.Windows.Forms.Button decrypt_button;
        private System.Windows.Forms.TextBox textBox_a;
        private System.Windows.Forms.TextBox textBox_b;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clear_button;
    }
}

