namespace ProjektAiSD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 150);
            button1.Name = "button1";
            button1.Size = new Size(234, 53);
            button1.TabIndex = 0;
            button1.Text = "Potasuj talię";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 245);
            button2.Name = "button2";
            button2.Size = new Size(234, 53);
            button2.TabIndex = 1;
            button2.Text = "Rozdaj karty graczom";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 340);
            button3.Name = "button3";
            button3.Size = new Size(234, 53);
            button3.TabIndex = 2;
            button3.Text = "Układy pokerowe";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(308, 340);
            button4.Name = "button4";
            button4.Size = new Size(409, 53);
            button4.TabIndex = 3;
            button4.Text = "Eksportuj do txt";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(12, 60);
            button5.Name = "button5";
            button5.Size = new Size(234, 53);
            button5.TabIndex = 4;
            button5.Text = "Utwórz talię";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(308, 120);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(409, 214);
            listBox1.TabIndex = 5;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(308, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 6;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(308, 42);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 7;
            label1.Text = "Liczba graczy";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private ListBox listBox1;
        private TextBox textBox1;
        private Label label1;
    }
}
