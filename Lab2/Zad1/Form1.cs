using System.Diagnostics;

namespace Zad1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double dzielna = Convert.ToDouble(boxDzielna.Text);
                double dzielnik = Convert.ToDouble(boxDzielnik.Text);

                if (dzielnik == 0)
                    throw new DivideByZeroException();

                double wynik = dzielna / dzielnik;
                boxWynik.Text = wynik.ToString();
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case DivideByZeroException:
                        MessageBox.Show("Nie mo¿na dzieliæ przez zero");
                        EventLog.WriteEntry("Application", "Wyst¹pi³ b³¹d: dzielenie przez zero", EventLogEntryType.Error);
                        break;
                    case FormatException:
                        MessageBox.Show("Podano nieprawid³owe dane");
                        EventLog.WriteEntry("Application", "Wyst¹pi³ b³¹d: nieprawid³owe dane", EventLogEntryType.Error);
                        break;
                    default:
                        MessageBox.Show("Wyst¹pi³ nieznany b³¹d");
                        EventLog.WriteEntry("Application", "Wyst¹pi³ b³¹d: nieznany", EventLogEntryType.Error);
                        break;
                }
            }
        }
    }
}