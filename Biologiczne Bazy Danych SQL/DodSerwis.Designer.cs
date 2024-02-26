namespace Biologiczne_Bazy_Danych_SQL
{
    partial class DodSerwis
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
            button1 = new Button();
            textBox3 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            label9 = new Label();
            richTextBox1 = new RichTextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(142, 282);
            button1.Name = "button1";
            button1.Size = new Size(188, 47);
            button1.TabIndex = 28;
            button1.Text = "Dodaj wpis serwisowy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(142, 173);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(188, 23);
            textBox3.TabIndex = 25;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 234);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 22;
            label6.Text = "Data zakończenia*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 205);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 21;
            label5.Text = "Data Rozpoczęcia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 176);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 20;
            label4.Text = "Koszt*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 19;
            label3.Text = "Opis";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 88);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 18;
            label2.Text = "ID Pojazdu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(344, 32);
            label1.TabIndex = 17;
            label1.Text = "Dodawanie wpisu serwisowego";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(142, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(188, 23);
            textBox1.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 264);
            label9.Name = "label9";
            label9.Size = new Size(212, 15);
            label9.TabIndex = 32;
            label9.Text = "* jeśli nieznana wartość, zostawić puste";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(142, 114);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(188, 53);
            richTextBox1.TabIndex = 34;
            richTextBox1.Text = "";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(142, 208);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 35;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(142, 238);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 36;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(348, 238);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(70, 19);
            checkBox1.TabIndex = 37;
            checkBox1.Text = "Bez daty";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // DodSerwis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 347);
            Controls.Add(checkBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(richTextBox1);
            Controls.Add(label9);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "DodSerwis";
            Text = "Dodaj do serwisu";
            Load += DodSerwis_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox textBox3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private Label label9;
        private RichTextBox richTextBox1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private CheckBox checkBox1;
    }
}