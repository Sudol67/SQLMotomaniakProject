namespace Biologiczne_Bazy_Danych_SQL
{
    partial class EdycjaKlienci
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
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(162, 223);
            maskedTextBox1.Margin = new Padding(3, 4, 3, 4);
            maskedTextBox1.Mask = "000000000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(214, 27);
            maskedTextBox1.TabIndex = 57;
            // 
            // button1
            // 
            button1.Location = new Point(162, 301);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(215, 63);
            button1.TabIndex = 56;
            button1.Text = "Zapisz nowe dane klienta";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(162, 184);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(214, 27);
            textBox3.TabIndex = 54;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(162, 145);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(214, 27);
            textBox2.TabIndex = 53;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 233);
            label6.Name = "label6";
            label6.Size = new Size(58, 20);
            label6.TabIndex = 51;
            label6.Text = "Telefon";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 195);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 50;
            label4.Text = "Adres";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 156);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 49;
            label3.Text = "Nazwisko";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 117);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 48;
            label2.Text = "Imię";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(378, 41);
            label1.TabIndex = 47;
            label1.Text = "Edytowanie rekordu klienta";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(162, 107);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(214, 27);
            textBox1.TabIndex = 46;
            // 
            // EdycjaKlienci
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 396);
            Controls.Add(maskedTextBox1);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EdycjaKlienci";
            Text = "Edycja rekordu klienta";
            Load += EdycjaKlienci_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox maskedTextBox1;
        private Button button1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
    }
}