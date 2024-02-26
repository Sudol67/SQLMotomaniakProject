namespace Biologiczne_Bazy_Danych_SQL
{
    partial class EdytSerwis
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
            checkBox1 = new CheckBox();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            richTextBox1 = new RichTextBox();
            label9 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(430, 317);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(112, 44);
            checkBox1.TabIndex = 51;
            checkBox1.Text = "Bez daty \r\nzakończenia";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(162, 317);
            dateTimePicker2.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(262, 27);
            dateTimePicker2.TabIndex = 50;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(162, 277);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(262, 27);
            dateTimePicker1.TabIndex = 49;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(162, 152);
            richTextBox1.Margin = new Padding(3, 4, 3, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(262, 69);
            richTextBox1.TabIndex = 48;
            richTextBox1.Text = "";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 352);
            label9.Name = "label9";
            label9.Size = new Size(267, 20);
            label9.TabIndex = 47;
            label9.Text = "* jeśli nieznana wartość, zostawić puste";
            // 
            // button1
            // 
            button1.Location = new Point(162, 376);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(262, 63);
            button1.TabIndex = 46;
            button1.Text = "Edytuj wpis serwisowy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(162, 231);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(262, 27);
            textBox3.TabIndex = 45;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 312);
            label6.Name = "label6";
            label6.Size = new Size(132, 20);
            label6.TabIndex = 44;
            label6.Text = "Data zakończenia*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 273);
            label5.Name = "label5";
            label5.Size = new Size(129, 20);
            label5.TabIndex = 43;
            label5.Text = "Data Rozpoczęcia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 235);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 42;
            label4.Text = "Koszt*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 156);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 41;
            label3.Text = "Opis";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 117);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 40;
            label2.Text = "ID Pojazdu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(437, 41);
            label1.TabIndex = 39;
            label1.Text = "Edytowanie wpisu serwisowego";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(162, 107);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(262, 27);
            textBox1.TabIndex = 38;
            // 
            // EdytSerwis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 457);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "EdytSerwis";
            Text = "Edyt rekord serwisowy";
            Load += EdytSerwis_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private RichTextBox richTextBox1;
        private Label label9;
        private Button button1;
        private TextBox textBox3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
    }
}