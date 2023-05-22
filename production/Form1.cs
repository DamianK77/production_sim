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
        private int operatorConfirmationInterval = 30; // czas w sekundach do potwierdzenia obecno�ci operatora
        private int operatorConfirmationCounter = 0;
        private bool operatorPresent = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicjalizacja timer�w
            diagnosticTimer = new System.Timers.Timer(5000); // co 5 sekund
            diagnosticTimer.Elapsed += DiagnosticTimerElapsed;
            diagnosticTimer.AutoReset = true;

            operatorTimer = new System.Timers.Timer(1000); // co 1 sekund�
            operatorTimer.Elapsed += OperatorTimerElapsed;
            operatorTimer.AutoReset = true;

            // Uruchomienie timer�w
            diagnosticTimer.Start();
            operatorTimer.Start();
        }

        private void DiagnosticTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Symulacja parametr�w procesu produkcyjnego

            // Losowe warto�ci parametr�w
            Random random = new Random();
            double cpuTemperature = random.Next(30, 80); // temperatura procesora w stopniach Celsiusza
            double cpuUtilization = random.NextDouble() * 100; // wykorzystanie procesora w procentach
            int fanSpeed = random.Next(1000, 5000); // pr�dko�� obrotowa wentylator�w w RPM

            // Symulacja awarii
            bool temperatureExceededThreshold = cpuTemperature > 70;
            bool cpuUtilizationExceededThreshold = cpuUtilization > 90;

            // Obs�uga awarii
            if (temperatureExceededThreshold)
            {
                // W��cz dodatkowy wentylator
                ShowMessage("Przekroczono temperatur� obudowy silnika. W��czono dodatkowy wentylator.");
            }

            if (cpuUtilizationExceededThreshold)
            {
                // Zwolnij tempo pracy linii produkcyjnej
                ShowMessage("Przekroczono maksymalne wykorzystanie procesora. Zwolniono tempo pracy linii produkcyjnej.");
            }

            // Aktualizacja interfejsu u�ytkownika
            UpdateDiagnosticValues(cpuTemperature, cpuUtilization, fanSpeed);
        }

        private void OperatorTimerElapsed(object sender, ElapsedEventArgs e)
        {
            operatorConfirmationCounter++;

            // Sprawdzenie obecno�ci operatora
            if (operatorConfirmationCounter >= operatorConfirmationInterval)
            {
                operatorPresent = false;
                ShowMessage("Brak potwierdzenia obecno�ci operatora. Alarm!");
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
            // Wy�wietlanie komunikatu
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
            // Aktualizacja warto�ci na interfejsie u�ytkownika
            if (InvokeRequired)
            {
                Invoke(new Action<double, double, int>(UpdateDiagnosticValues), cpuTemperature, cpuUtilization, fanSpeed);
            }
            else
            {
                lblTemperature.Text = $"{cpuTemperature}�C";
                lblUtilization.Text = $"{cpuUtilization}%";
                lblFanSpeed.Text = $"{fanSpeed} RPM";
            }
        }

        private void btnConfirmPresence_Click_1(object sender, EventArgs e)
        {
            // Potwierdzenie obecno�ci operatora
            operatorConfirmationCounter = 0;
            operatorPresent = true;
            ShowMessage("Potwierdzono obecno�� operatora.");
        }
    }
}