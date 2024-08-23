using System;
using System.Windows;

namespace WPF_TEST_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Berechnen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double jahresgewinn = Convert.ToDouble(JahresgewinnTextBox.Text);
                double aktienkapital = Convert.ToDouble(AktienkapitalTextBox.Text);
                double gesetzlicheReserven = Convert.ToDouble(GesetzlicheReservenTextBox.Text);
                double gewinnVortrag = Convert.ToDouble(GewinnVortragTextBox.Text);
                double dividende = Convert.ToDouble(DividendeTextBox.Text);

                double ersteReserve = jahresgewinn * 0.05;
                double zweiteReserve = 0;

                if (dividende > 0.05 * aktienkapital)
                {
                    zweiteReserve = (dividende - (0.05 * aktienkapital)) * 0.1;
                }

                double ausschüttungsbetrag = dividende;
                double gewinnVortragNeu = (jahresgewinn - ersteReserve - zweiteReserve - ausschüttungsbetrag) + gewinnVortrag;

                if (ausschüttungsbetrag > (jahresgewinn - ersteReserve - gesetzlicheReserven))
                {
                    BemerkungTextBox1.Text = "Dividende ist zu hoch!";
                    return;
                }

                ErsteReserveTextBlock.Text = ersteReserve.ToString("C");
                DividendenAusschüttungTextBlock.Text = ausschüttungsbetrag.ToString("C");
                GewinnVortragTextBlockResult.Text = gewinnVortragNeu.ToString("C");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler: " + ex.Message);
            }
        }
    }
}
