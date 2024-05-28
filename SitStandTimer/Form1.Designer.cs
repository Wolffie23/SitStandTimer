namespace SitStandTimer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.standNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.standLable = new System.Windows.Forms.Label();
            this.sitLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.standNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // standNumericUpDown
            // 
            this.standNumericUpDown.Location = new System.Drawing.Point(87, 27);
            this.standNumericUpDown.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.standNumericUpDown.Name = "standNumericUpDown";
            this.standNumericUpDown.Size = new System.Drawing.Size(65, 23);
            this.standNumericUpDown.TabIndex = 0;
            // 
            // sitNumericUpDown
            // 
            this.sitNumericUpDown.Location = new System.Drawing.Point(12, 27);
            this.sitNumericUpDown.Maximum = new decimal(new int[] {
            2000000,
            0,
            0,
            0});
            this.sitNumericUpDown.Name = "sitNumericUpDown";
            this.sitNumericUpDown.Size = new System.Drawing.Size(61, 23);
            this.sitNumericUpDown.TabIndex = 1;
            // 
            // standLable
            // 
            this.standLable.AutoSize = true;
            this.standLable.Location = new System.Drawing.Point(87, 9);
            this.standLable.Name = "standLable";
            this.standLable.Size = new System.Drawing.Size(37, 15);
            this.standLable.TabIndex = 2;
            this.standLable.Text = "Stand";
            // 
            // sitLabel
            // 
            this.sitLabel.AutoSize = true;
            this.sitLabel.Location = new System.Drawing.Point(12, 9);
            this.sitLabel.Name = "sitLabel";
            this.sitLabel.Size = new System.Drawing.Size(20, 15);
            this.sitLabel.TabIndex = 3;
            this.sitLabel.Text = "Sit";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 56);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(136, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save and Restart";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 85);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.sitLabel);
            this.Controls.Add(this.standLable);
            this.Controls.Add(this.sitNumericUpDown);
            this.Controls.Add(this.standNumericUpDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sit Stand Timer";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.standNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sitNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown standNumericUpDown;
        private NumericUpDown sitNumericUpDown;
        private Label standLable;
        private Label sitLabel;
        private NotifyIcon notifyIcon;
        private Button saveButton;
    }
}