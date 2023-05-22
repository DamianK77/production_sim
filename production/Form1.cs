using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;

namespace production
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer diagnosticTimer;
        private System.Timers.Timer operatorTimer;
        private int operatorConfirmationInterval = 30; // czas w sekundach do potwierdzenia obecnoœci operatora
        private int operatorConfirmationCounter = 0;
        private bool operatorPresent = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicjalizacja timerów
            diagnosticTimer = new System.Timers.Timer(5000); // co 5 sekund
            diagnosticTimer.Elapsed += DiagnosticTimerElapsed;
            diagnosticTimer.AutoReset = true;

            operatorTimer = new System.Timers.Timer(1000); // co 1 sekundê
            operatorTimer.Elapsed += OperatorTimerElapsed;
            operatorTimer.AutoReset = true;

            // Uruchomienie timerów
            diagnosticTimer.Start();
            operatorTimer.Start();
        }

        private void DiagnosticTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Symulacja parametrów procesu produkcyjnego

            // Losowe wartoœci parametrów
            Random random = new Random();
            double cpuTemperature = random.Next(30, 80); // temperatura procesora w stopniach Celsiusza
            double cpuUtilization = random.NextDouble() * 100; // wykorzystanie procesora w procentach
            int fanSpeed = random.Next(1000, 5000); // prêdkoœæ obrotowa wentylatorów w RPM

            // Symulacja awarii
            bool temperatureExceededThreshold = cpuTemperature > 70;
            bool cpuUtilizationExceededThreshold = cpuUtilization > 90;

            // Obs³uga awarii
            if (temperatureExceededThreshold)
            {
                // W³¹cz dodatkowy wentylator
                ShowMessage("Przekroczono temperaturê obudowy silnika. W³¹czono dodatkowy wentylator.");
            }

            if (cpuUtilizationExceededThreshold)
            {
                // Zwolnij tempo pracy linii produkcyjnej
                ShowMessage("Przekroczono maksymalne wykorzystanie procesora. Zwolniono tempo pracy linii produkcyjnej.");
            }

            // Aktualizacja interfejsu u¿ytkownika
            UpdateDiagnosticValues(cpuTemperature, cpuUtilization, fanSpeed);
        }

        private void OperatorTimerElapsed(object sender, ElapsedEventArgs e)
        {
            operatorConfirmationCounter++;

            // Sprawdzenie obecnoœci operatora
            if (operatorConfirmationCounter >= operatorConfirmationInterval)
            {
                operatorPresent = false;
                ShowMessage("Brak potwierdzenia obecnoœci operatora. Alarm!");
                LogoutOperator();
            }
        }

        private void btnConfirmPresence_Click(object sender, EventArgs e)
        {
            
        }

        private void LogoutOperator()
        {
            // Wylogowanie operatora
            operatorConfirmationCounter = 0;
            operatorPresent = false;
            ShowMessage("Operator wylogowany.");
        }

        private void ShowMessage(string message)
        {
            // Wyœwietlanie komunikatu
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowMessage), message);
            }
            else
            {
                MessageBox.Show(message, "Komunikat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateDiagnosticValues(double cpuTemperature, double cpuUtilization, int fanSpeed)
        {
            // Aktualizacja wartoœci na interfejsie u¿ytkownika
            if (InvokeRequired)
            {
                Invoke(new Action<double, double, int>(UpdateDiagnosticValues), cpuTemperature, cpuUtilization, fanSpeed);
            }
            else
            {
                lblTemperature.Text = $"{cpuTemperature}°C";
                lblUtilization.Text = $"{cpuUtilization}%";
                lblFanSpeed.Text = $"{fanSpeed} RPM";
            }
        }

        private void btnConfirmPresence_Click_1(object sender, EventArgs e)
        {
            // Potwierdzenie obecnoœci operatora
            operatorConfirmationCounter = 0;
            operatorPresent = true;
            ShowMessage("Potwierdzono obecnoœæ operatora.");
        }
    }
}