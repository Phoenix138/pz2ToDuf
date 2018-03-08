namespace PoserToDazShapesExporter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonConvertPZ2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConvertPZ2
            // 
            this.buttonConvertPZ2.Location = new System.Drawing.Point(12, 12);
            this.buttonConvertPZ2.Name = "buttonConvertPZ2";
            this.buttonConvertPZ2.Size = new System.Drawing.Size(197, 42);
            this.buttonConvertPZ2.TabIndex = 0;
            this.buttonConvertPZ2.Text = "Convert pz2 To Duf";
            this.buttonConvertPZ2.UseVisualStyleBackColor = true;
            this.buttonConvertPZ2.Click += new System.EventHandler(this.OnClickConvertPZ2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(460, 135);
            this.Controls.Add(this.buttonConvertPZ2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Export Poser To Daz Studio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConvertPZ2;
    }
}

