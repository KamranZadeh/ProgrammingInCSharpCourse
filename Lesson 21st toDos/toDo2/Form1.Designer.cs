
namespace toDo2
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
            this.buttonCatch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCatch
            // 
            this.buttonCatch.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCatch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCatch.Location = new System.Drawing.Point(330, 191);
            this.buttonCatch.Name = "buttonCatch";
            this.buttonCatch.Size = new System.Drawing.Size(121, 38);
            this.buttonCatch.TabIndex = 0;
            this.buttonCatch.Text = "Catch me if you can";
            this.buttonCatch.UseVisualStyleBackColor = false;
            this.buttonCatch.Click += new System.EventHandler(this.buttonCatch_Click);
            this.buttonCatch.MouseEnter += new System.EventHandler(this.buttonCatch_MouseEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.buttonCatch);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "Form1";
            this.Text = "Catch me game";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCatch;
    }
}

