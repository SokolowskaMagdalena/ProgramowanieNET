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
            cbAlgorithmType = new ComboBox();
            buttonGenerateKeyAndIV = new Button();
            textBoxKey = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBoxIV = new TextBox();
            buttonEcrypt = new Button();
            label3 = new Label();
            textBoxHEX = new TextBox();
            label4 = new Label();
            textBoxASCII = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBoxEncodedHEX = new TextBox();
            label8 = new Label();
            textBoxEncodedASCI = new TextBox();
            buttonDecrypt = new Button();
            buttonEncryptTime = new Button();
            buttonDecryptTime = new Button();
            labelEncryptTime = new Label();
            labelDecryptTime = new Label();
            SuspendLayout();
            // 
            // cbAlgorithmType
            // 
            cbAlgorithmType.FormattingEnabled = true;
            cbAlgorithmType.Items.AddRange(new object[] { "AES", "DES", "RC2", "Rijndael", "TripleDES" });
            cbAlgorithmType.Location = new Point(12, 26);
            cbAlgorithmType.Name = "cbAlgorithmType";
            cbAlgorithmType.Size = new Size(134, 23);
            cbAlgorithmType.TabIndex = 0;
            cbAlgorithmType.SelectedIndexChanged += CbAlgorithmType_SelectedIndexChanged;
            // 
            // buttonGenerateKeyAndIV
            // 
            buttonGenerateKeyAndIV.Location = new Point(12, 71);
            buttonGenerateKeyAndIV.Name = "buttonGenerateKeyAndIV";
            buttonGenerateKeyAndIV.Size = new Size(134, 30);
            buttonGenerateKeyAndIV.TabIndex = 1;
            buttonGenerateKeyAndIV.Text = "Generate Key and IV";
            buttonGenerateKeyAndIV.UseVisualStyleBackColor = true;
            buttonGenerateKeyAndIV.Click += ButtonGenerateKeyAndIV_Click;
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(208, 26);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(260, 23);
            textBoxKey.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(208, 8);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 3;
            label1.Text = "Key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(208, 58);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 5;
            label2.Text = "IV";
            // 
            // textBoxIV
            // 
            textBoxIV.Location = new Point(208, 76);
            textBoxIV.Name = "textBoxIV";
            textBoxIV.Size = new Size(260, 23);
            textBoxIV.TabIndex = 4;
            // 
            // buttonEcrypt
            // 
            buttonEcrypt.Location = new Point(12, 129);
            buttonEcrypt.Name = "buttonEcrypt";
            buttonEcrypt.Size = new Size(134, 30);
            buttonEcrypt.TabIndex = 6;
            buttonEcrypt.Text = "Encrypt";
            buttonEcrypt.UseVisualStyleBackColor = true;
            buttonEcrypt.Click += ButtonEcrypt_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 132);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 10;
            label3.Text = "ASCII";
            // 
            // textBoxHEX
            // 
            textBoxHEX.Location = new Point(208, 158);
            textBoxHEX.Name = "textBoxHEX";
            textBoxHEX.Size = new Size(260, 23);
            textBoxHEX.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(208, 111);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 8;
            label4.Text = "Plain Text";
            // 
            // textBoxASCII
            // 
            textBoxASCII.Location = new Point(208, 129);
            textBoxASCII.Name = "textBoxASCII";
            textBoxASCII.Size = new Size(260, 23);
            textBoxASCII.TabIndex = 7;
            textBoxASCII.TextChanged += TextBoxASCII_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(167, 161);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 11;
            label5.Text = "HEX";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(167, 245);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 16;
            label6.Text = "HEX";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(167, 216);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 15;
            label7.Text = "ASCII";
            // 
            // textBoxEncodedHEX
            // 
            textBoxEncodedHEX.Location = new Point(208, 242);
            textBoxEncodedHEX.Name = "textBoxEncodedHEX";
            textBoxEncodedHEX.Size = new Size(260, 23);
            textBoxEncodedHEX.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(208, 195);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 13;
            label8.Text = "Cipher Text";
            // 
            // textBoxEncodedASCI
            // 
            textBoxEncodedASCI.Location = new Point(208, 213);
            textBoxEncodedASCI.Name = "textBoxEncodedASCI";
            textBoxEncodedASCI.Size = new Size(260, 23);
            textBoxEncodedASCI.TabIndex = 12;
            // 
            // buttonDecrypt
            // 
            buttonDecrypt.Location = new Point(12, 213);
            buttonDecrypt.Name = "buttonDecrypt";
            buttonDecrypt.Size = new Size(134, 30);
            buttonDecrypt.TabIndex = 17;
            buttonDecrypt.Text = "Decrypt";
            buttonDecrypt.UseVisualStyleBackColor = true;
            buttonDecrypt.Click += ButtonDecrypt_Click;
            // 
            // buttonEncryptTime
            // 
            buttonEncryptTime.Location = new Point(12, 292);
            buttonEncryptTime.Name = "buttonEncryptTime";
            buttonEncryptTime.Size = new Size(134, 30);
            buttonEncryptTime.TabIndex = 18;
            buttonEncryptTime.Text = "Get Encrypt Time";
            buttonEncryptTime.UseVisualStyleBackColor = true;
            buttonEncryptTime.Click += ButtonEncryptTime_Click;
            // 
            // buttonDecryptTime
            // 
            buttonDecryptTime.Location = new Point(12, 328);
            buttonDecryptTime.Name = "buttonDecryptTime";
            buttonDecryptTime.Size = new Size(134, 30);
            buttonDecryptTime.TabIndex = 19;
            buttonDecryptTime.Text = "Get Decrypt Time";
            buttonDecryptTime.UseVisualStyleBackColor = true;
            buttonDecryptTime.Click += ButtonDecryptTime_Click;
            // 
            // labelEncryptTime
            // 
            labelEncryptTime.AutoSize = true;
            labelEncryptTime.Location = new Point(208, 300);
            labelEncryptTime.Name = "labelEncryptTime";
            labelEncryptTime.Size = new Size(101, 15);
            labelEncryptTime.TabIndex = 20;
            labelEncryptTime.Text = "Time - encryption";
            // 
            // labelDecryptTime
            // 
            labelDecryptTime.AutoSize = true;
            labelDecryptTime.Location = new Point(208, 336);
            labelDecryptTime.Name = "labelDecryptTime";
            labelDecryptTime.Size = new Size(101, 15);
            labelDecryptTime.TabIndex = 21;
            labelDecryptTime.Text = "Time - decryption";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 376);
            Controls.Add(labelDecryptTime);
            Controls.Add(labelEncryptTime);
            Controls.Add(buttonDecryptTime);
            Controls.Add(buttonEncryptTime);
            Controls.Add(buttonDecrypt);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(textBoxEncodedHEX);
            Controls.Add(label8);
            Controls.Add(textBoxEncodedASCI);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(textBoxHEX);
            Controls.Add(label4);
            Controls.Add(textBoxASCII);
            Controls.Add(buttonEcrypt);
            Controls.Add(label2);
            Controls.Add(textBoxIV);
            Controls.Add(label1);
            Controls.Add(textBoxKey);
            Controls.Add(buttonGenerateKeyAndIV);
            Controls.Add(cbAlgorithmType);
            Name = "Form1";
            Text = "Encryption";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbAlgorithmType;
        private Button buttonGenerateKeyAndIV;
        private TextBox textBoxKey;
        private Label label1;
        private Label label2;
        private TextBox textBoxIV;
        private Button buttonEcrypt;
        private Label label3;
        private TextBox textBoxHEX;
        private Label label4;
        private TextBox textBoxASCII;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBoxEncodedHEX;
        private Label label8;
        private TextBox textBoxEncodedASCI;
        private Button buttonDecrypt;
        private Button buttonEncryptTime;
        private Button buttonDecryptTime;
        private Label labelEncryptTime;
        private Label labelDecryptTime;
    }
}
