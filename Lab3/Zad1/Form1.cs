using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Zad1
{
    public partial class Form1 : Form
    {
        private SymmetricAlgorithm algorytm;

        public Form1()
        {
            InitializeComponent();
            cbAlgorithmType.SelectedIndex = 0;
            WybierzAlgorytm();
        }

        private void WybierzAlgorytm()
        {
            switch (cbAlgorithmType.SelectedItem.ToString())
            {
                case "AES":
                    algorytm = new AesCryptoServiceProvider();
                    break;
                case "DES":
                    algorytm = new DESCryptoServiceProvider();
                    break;
                case "RC2":
                    algorytm = new RC2CryptoServiceProvider();
                    break;
                case "Rijndael":
                    algorytm = new RijndaelManaged();
                    break;
                case "TripleDES":
                    algorytm = new TripleDESCryptoServiceProvider();
                    break;
                default:
                    algorytm = new AesCryptoServiceProvider();
                    break;
            }
        }

        private void CbAlgorithmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            WybierzAlgorytm();
        }

        private void ButtonGenerateKeyAndIV_Click(object sender, EventArgs e)
        {
            algorytm.GenerateKey();
            algorytm.GenerateIV();
            textBoxKey.Text = ByteArrayToHexString(algorytm.Key);
            textBoxIV.Text = ByteArrayToHexString(algorytm.IV);
        }

        private void ButtonEcrypt_Click(object sender, EventArgs e)
        {
            byte[] plaintextBytes = Encoding.ASCII.GetBytes(textBoxASCII.Text);
            ICryptoTransform encryptor = algorytm.CreateEncryptor();
            byte[] cipherBytes = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);
            textBoxEncodedASCI.Text = Encoding.ASCII.GetString(cipherBytes);
            textBoxEncodedHEX.Text = ByteArrayToHexString(cipherBytes);
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            byte[] cipherBytes = ConvertHexStringToByteArray(textBoxEncodedHEX.Text);
            ICryptoTransform decryptor = algorytm.CreateDecryptor();
            byte[] plaintextBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            textBoxASCII.Text = Encoding.ASCII.GetString(plaintextBytes);
            textBoxHEX.Text = ByteArrayToHexString(plaintextBytes);
        }

        private void ButtonEncryptTime_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ButtonEcrypt_Click(sender, e);
            stopwatch.Stop();
            labelEncryptTime.Text = $"Time - encryption: {stopwatch.ElapsedMilliseconds} ms";
        }

        private void ButtonDecryptTime_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ButtonDecrypt_Click(sender, e);
            stopwatch.Stop();
            labelDecryptTime.Text = $"Time - decryption: {stopwatch.ElapsedMilliseconds} ms";
        }

        private void TextBoxASCII_TextChanged(object sender, EventArgs e)
        {
            textBoxHEX.Text = ByteArrayToHexString(Encoding.ASCII.GetBytes(textBoxASCII.Text));
        }

        private string ByteArrayToHexString(byte[] byteArray)
        {
            StringBuilder hex = new StringBuilder(byteArray.Length * 2);

            foreach (byte b in byteArray)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }

        private byte[] ConvertHexStringToByteArray(string hexString)
        {
            int length = hexString.Length;
            byte[] byteArray = new byte[length / 2];

            for (int i = 0; i < length; i += 2)
                byteArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);

            return byteArray;
        }
    }
}
