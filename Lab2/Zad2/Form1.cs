using System.Diagnostics;

namespace Zad2
{
    public partial class Form1 : Form
    {
        private string liczba = "";
        private string zapamietanaLiczba = "";
        private int operacja = 0;

        private int milisekundyNaInicjalizacje = 10;

        public Form1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); 
            InitializeComponent();
            stopwatch.Stop();

            if ((int)stopwatch.ElapsedMilliseconds > milisekundyNaInicjalizacje)
                EventLog.WriteEntry("Application", "Inicjalizacja aplikacji trwala zbyt dlugo", EventLogEntryType.Warning);
        }

        private void dodajLiczbe(object sender, EventArgs e)
        {
            liczba += (sender as Button).Text;
            textBox1.Text = liczba;
        }

        private void zapiszLiczby()
        {
            if (textBox1.Text == "")
            {
                operacja = 0;
                return;
            }

            zapamietanaLiczba = textBox1.Text;
            liczba = "";
            textBox1.Text = liczba;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            liczba = "";
            zapamietanaLiczba = "";
            textBox1.Text = liczba;
            operacja = 0;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            operacja = 1;
            zapiszLiczby();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            operacja = 2;
            zapiszLiczby();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            operacja = 3;
            zapiszLiczby();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            operacja = 4;
            zapiszLiczby();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (operacja == 0)
                return;

            double a = Convert.ToDouble(zapamietanaLiczba);
            double b = Convert.ToDouble(textBox1.Text);
            double wynik = 0;

            switch (operacja)
            {
                case 1:
                    wynik = a + b;
                    break;
                case 2:
                    wynik = a - b;
                    break;
                case 3:
                    wynik = a * b;
                    break;
                case 4:
                    wynik = a / b;
                    break;
            }

            textBox1.Text = wynik.ToString();
            liczba = wynik.ToString();
            operacja = 0;
        }
    }
}