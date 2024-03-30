namespace Cube_Render
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            checkBox1 = new CheckBox();
            button1 = new Button();
            numericUpDown1 = new NumericUpDown();
            checkBox3 = new CheckBox();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            helpProvider1 = new HelpProvider();
            helpProvider2 = new HelpProvider();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(12, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(77, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Auto spin";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 37);
            button1.Name = "button1";
            button1.Size = new Size(77, 23);
            button1.TabIndex = 1;
            button1.Text = "Restart";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 66);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(77, 23);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(12, 110);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(53, 19);
            checkBox3.TabIndex = 4;
            checkBox3.Text = "Lines";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 92);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 5;
            label1.Text = "Speed";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(12, 135);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 204);
            textBox1.TabIndex = 7;
            textBox1.Text = "W = Up\r\nS = Down\r\nA = Left\r\nD = Right\r\n\r\nEsc = Exit\r\nEnter / Space = Auto spin ON/OFF\r\n\r\nArrow Up = Speed++\r\nArrow Down = Speed--\r\n\r\nR = Start position, Start speed";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(checkBox3);
            Controls.Add(numericUpDown1);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private CheckBox checkBox1;
        private Button button1;
        private NumericUpDown numericUpDown1;
        private CheckBox checkBox3;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private HelpProvider helpProvider1;
        private HelpProvider helpProvider2;
        private TextBox textBox1;
    }
}