namespace Zad1
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
            boxDzielna = new TextBox();
            label1 = new Label();
            label2 = new Label();
            boxDzielnik = new TextBox();
            label3 = new Label();
            boxWynik = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // boxDzielna
            // 
            boxDzielna.Location = new Point(12, 25);
            boxDzielna.Name = "boxDzielna";
            boxDzielna.Size = new Size(100, 23);
            boxDzielna.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 7);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Dzielna";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 7);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 3;
            label2.Text = "Dzielnik";
            // 
            // boxDzielnik
            // 
            boxDzielnik.Location = new Point(118, 25);
            boxDzielnik.Name = "boxDzielnik";
            boxDzielnik.Size = new Size(100, 23);
            boxDzielnik.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(251, 7);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 5;
            label3.Text = "Wynik";
            // 
            // boxWynik
            // 
            boxWynik.Location = new Point(224, 25);
            boxWynik.Name = "boxWynik";
            boxWynik.Size = new Size(100, 23);
            boxWynik.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(330, 25);
            button1.Name = "button1";
            button1.Size = new Size(108, 23);
            button1.TabIndex = 6;
            button1.Text = "Dziel";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 56);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(boxWynik);
            Controls.Add(label2);
            Controls.Add(boxDzielnik);
            Controls.Add(label1);
            Controls.Add(boxDzielna);
            Name = "Form1";
            Text = "Dzielenie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox boxDzielna;
        private Label label1;
        private Label label2;
        private TextBox boxDzielnik;
        private Label label3;
        private TextBox boxWynik;
        private Button button1;
    }
}