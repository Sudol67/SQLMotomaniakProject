namespace Biologiczne_Bazy_Danych_SQL
{
    partial class EdycjaPrac
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
            label5 = new Label();
            textBox4 = new TextBox();
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
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 311);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 45;
            label5.Text = "Hasło";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(162, 300);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(214, 27);
            textBox4.TabIndex = 44;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(162, 223);
            maskedTextBox1.Margin = new Padding(3, 4, 3, 4);
            maskedTextBox1.Mask = "000000000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(214, 27);
            maskedTextBox1.TabIndex = 43;
            // 
            // button1
            // 
            button1.Location = new Point(162, 376);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(215, 63);
            button1.TabIndex = 42;
            button1.Text = "Zapisz nowe dane pracownika";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(162, 261);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(214, 27);
            textBox6.TabIndex = 41;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(162, 184);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(214, 27);
            textBox3.TabIndex = 40;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(162, 145);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 27);
            textBox2.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 272);
            label7.Name = "label7";
            label7.Size = new Size(84, 20);
            label7.TabIndex = 38;
            label7.Text = "Stanowisko";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 233);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 37;
            label6.Text = "Telefon";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 195);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 36;
            label4.Text = "Adres";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 156);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 35;
            label3.Text = "Nazwisko";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 117);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 34;
            label2.Text = "Imię";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(442, 41);
            label1.TabIndex = 33;
            label1.Text = "Edytowanie rekordu pracownika";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(162, 107);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 27);
            textBox1.TabIndex = 32;
            // 
            // EdycjaPrac
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 457);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "EdycjaPrac";
            Text = "Edycja rekordu pracownika";
            Load += EdycjaPrac_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private TextBox textBox4;
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
    }
}