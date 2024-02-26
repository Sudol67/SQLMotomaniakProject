namespace Biologiczne_Bazy_Danych_SQL
{
    partial class EdycjaPoj
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
            label1 = new Label();
            button1 = new Button();
            textBox6 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(390, 41);
            label1.TabIndex = 2;
            label1.Text = "Edytowanie danych pojazdu";
            // 
            // button1
            // 
            button1.Location = new Point(155, 357);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(266, 63);
            button1.TabIndex = 27;
            button1.Text = "Zapisz dane pojazdu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(155, 288);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(266, 27);
            textBox6.TabIndex = 26;
            textBox6.KeyPress += textBox6_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(155, 204);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(266, 27);
            textBox4.TabIndex = 25;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(155, 165);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(266, 27);
            textBox3.TabIndex = 24;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(155, 127);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(266, 27);
            textBox2.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(7, 292);
            label7.Name = "label7";
            label7.Size = new Size(88, 20);
            label7.TabIndex = 22;
            label7.Text = "Cena Kupna";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 253);
            label6.Name = "label6";
            label6.Size = new Size(129, 20);
            label6.TabIndex = 21;
            label6.Text = "Data dostarczenia";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 215);
            label5.Name = "label5";
            label5.Size = new Size(44, 20);
            label5.TabIndex = 20;
            label5.Text = "Silnik";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 176);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 19;
            label4.Text = "Kolor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 137);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 18;
            label3.Text = "Model";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 99);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 17;
            label2.Text = "Marka";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(155, 88);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(266, 27);
            textBox1.TabIndex = 16;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(155, 247);
            dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(266, 27);
            dateTimePicker1.TabIndex = 37;
            // 
            // EdycjaPoj
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 443);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(textBox6);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EdycjaPoj";
            Text = "Edycja rekordu pojazdu";
            Load += EdycjaPoj_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox textBox6;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
    }
}