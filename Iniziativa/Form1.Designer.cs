namespace Iniziativa
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button1 = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Recalc = new System.Windows.Forms.Button();
            this.Chiudi = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Chiudi)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(519, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(133, 139);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(270, 35);
            this.Next.TabIndex = 3;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Recalc
            // 
            this.Recalc.Location = new System.Drawing.Point(409, 139);
            this.Recalc.Name = "Recalc";
            this.Recalc.Size = new System.Drawing.Size(104, 35);
            this.Recalc.TabIndex = 4;
            this.Recalc.Text = "Reset Ini";
            this.Recalc.UseVisualStyleBackColor = true;
            this.Recalc.Click += new System.EventHandler(this.Recalc_Button);
            // 
            // Chiudi
            // 
            this.Chiudi.BackColor = System.Drawing.Color.Transparent;
            this.Chiudi.Location = new System.Drawing.Point(698, 82);
            this.Chiudi.Margin = new System.Windows.Forms.Padding(6);
            this.Chiudi.Name = "Chiudi";
            this.Chiudi.Size = new System.Drawing.Size(32, 54);
            this.Chiudi.TabIndex = 0;
            this.Chiudi.TabStop = false;
            this.Chiudi.Click += new System.EventHandler(this.CloseClick);
            this.Chiudi.MouseLeave += new System.EventHandler(this.CloseLeave);
            this.Chiudi.MouseHover += new System.EventHandler(this.CloseHover);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 1034);
            this.Controls.Add(this.Recalc);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Chiudi);
            this.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Main";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MMDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MMMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MMUp);
            ((System.ComponentModel.ISupportInitialize)(this.Chiudi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Chiudi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Recalc;
    }
}

