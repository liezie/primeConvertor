namespace WindowsFormsApplication1.UI
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
            this.input = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(28, 28);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(142, 20);
            this.input.TabIndex = 0;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(28, 54);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(142, 23);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "Convert to basePrime";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.output.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.Location = new System.Drawing.Point(197, 28);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(305, 52);
            this.output.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 101);
            this.Controls.Add(this.output);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.input);
            this.Name = "Form1";
            this.Text = "Decimal to PrimeBase convertor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Label output;
    }
}

