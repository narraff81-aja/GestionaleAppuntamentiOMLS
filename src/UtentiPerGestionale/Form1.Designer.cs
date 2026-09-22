namespace UtentiPerGestionale
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
        private void InitializeComponent() {
            btnCaricaUtenti0 = new Button();
            btnCaricaUtenti1 = new Button();
            SuspendLayout();
            // 
            // btnCaricaUtenti0
            // 
            btnCaricaUtenti0.Location = new Point(44, 12);
            btnCaricaUtenti0.Name = "btnCaricaUtenti0";
            btnCaricaUtenti0.Size = new Size(104, 23);
            btnCaricaUtenti0.TabIndex = 0;
            btnCaricaUtenti0.Text = "Carica Utenti";
            btnCaricaUtenti0.UseVisualStyleBackColor = true;
            btnCaricaUtenti0.Click += btnCaricaUtenti0_Click;
            // 
            // btnCaricaUtenti1
            // 
            btnCaricaUtenti1.Location = new Point(44, 52);
            btnCaricaUtenti1.Name = "btnCaricaUtenti1";
            btnCaricaUtenti1.Size = new Size(104, 23);
            btnCaricaUtenti1.TabIndex = 1;
            btnCaricaUtenti1.Text = "Carica Utenti 1";
            btnCaricaUtenti1.UseVisualStyleBackColor = true;
            btnCaricaUtenti1.Click += btnCaricaUtenti1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(285, 128);
            Controls.Add(btnCaricaUtenti1);
            Controls.Add(btnCaricaUtenti0);
            Name = "Form1";
            Text = "Meschini - Tabella Utenti";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCaricaUtenti0;
        private Button btnCaricaUtenti1;
    }
}
