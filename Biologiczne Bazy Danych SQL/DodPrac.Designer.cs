namespace Biologiczne_Bazy_Danych_SQL
{
    partial class DodPrac
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
            maskedTextBox1 = new MaskedTextBox();
            button1 = new Button();
            textBox6 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox4 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(142, 167);
            maskedTextBox1.Mask = "000000000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(188, 23);
            maskedTextBox1.TabIndex = 29;
            // 
            // button1
            // 
            button1.Location = new Point(142, 282);
            button1.Name = "button1";
            button1.Size = new Size(188, 47);
            button1.TabIndex = 28;
            button1.Text = "Dodaj nowego pracownika";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(142, 196);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(188, 23);
            textBox6.TabIndex = 27;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(142, 138);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(188, 23);
            textBox3.TabIndex = 25;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(142, 109);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(188, 23);
            textBox2.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 204);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 23;
            label7.Text = "Stanowisko";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 175);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 22;
            label6.Text = "Telefon";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 146);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 20;
            label4.Text = "Adres";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 19;
            label3.Text = "Nazwisko";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 18;
            label2.Text = "Imię";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(353, 32);
            label1.TabIndex = 17;
            label1.Text = "Dodawanie nowego pracownika";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(142, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(188, 23);
            textBox1.TabIndex = 16;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(142, 225);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(188, 23);
            textBox4.TabIndex = 30;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 233);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 31;
            label5.Text = "Hasło";
            // 
            // DodPrac
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 343);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(maskedTextBox1);
            Controls.Add(button1);
            Controls.Add(textBox6);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "DodPrac";
            Text = "Dodawanie Pracownika";
            Load += DodPrac_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaskedTextBox maskedTextBox1;
        private Button button1;
        private TextBox textBox6;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label7;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox4;
        private Label label5;
    }
}