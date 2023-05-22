namespace production
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
            lblTemperature = new Label();
            lblUtilization = new Label();
            lblFanSpeed = new Label();
            btnConfirmPresence = new Button();
            SuspendLayout();
            // 
            // lblTemperature
            // 
            lblTemperature.AutoSize = true;
            lblTemperature.Location = new Point(176, 35);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(78, 32);
            lblTemperature.TabIndex = 0;
            lblTemperature.Text = "label1";
            // 
            // lblUtilization
            // 
            lblUtilization.AutoSize = true;
            lblUtilization.Location = new Point(178, 89);
            lblUtilization.Name = "lblUtilization";
            lblUtilization.Size = new Size(78, 32);
            lblUtilization.TabIndex = 1;
            lblUtilization.Text = "label2";
            // 
            // lblFanSpeed
            // 
            lblFanSpeed.AutoSize = true;
            lblFanSpeed.Location = new Point(178, 137);
            lblFanSpeed.Name = "lblFanSpeed";
            lblFanSpeed.Size = new Size(78, 32);
            lblFanSpeed.TabIndex = 2;
            lblFanSpeed.Text = "label3";
            // 
            // btnConfirmPresence
            // 
            btnConfirmPresence.Location = new Point(364, 202);
            btnConfirmPresence.Name = "btnConfirmPresence";
            btnConfirmPresence.Size = new Size(150, 46);
            btnConfirmPresence.TabIndex = 3;
            btnConfirmPresence.Text = "button1";
            btnConfirmPresence.UseVisualStyleBackColor = true;
            btnConfirmPresence.Click += btnConfirmPresence_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConfirmPresence);
            Controls.Add(lblFanSpeed);
            Controls.Add(lblUtilization);
            Controls.Add(lblTemperature);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTemperature;
        private Label lblUtilization;
        private Label lblFanSpeed;
        private Button btnConfirmPresence;
    }
}