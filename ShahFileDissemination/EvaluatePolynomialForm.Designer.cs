namespace ShahFileDissemination
{
    partial class EvaluatePolynomialForm
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
            this.EvaluateTextBox = new System.Windows.Forms.TextBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PolyIndexTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maxIndexLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EvaluateTextBox
            // 
            this.EvaluateTextBox.Location = new System.Drawing.Point(107, 56);
            this.EvaluateTextBox.Name = "EvaluateTextBox";
            this.EvaluateTextBox.Size = new System.Drawing.Size(92, 20);
            this.EvaluateTextBox.TabIndex = 0;
            this.EvaluateTextBox.Text = "0";
            this.EvaluateTextBox.TextChanged += new System.EventHandler(this.EvaluateTextBox_TextChanged);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultTextBox.Location = new System.Drawing.Point(12, 97);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(550, 20);
            this.ResultTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Evaluate At: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Polynomial Index:";
            // 
            // PolyIndexTextBox
            // 
            this.PolyIndexTextBox.Location = new System.Drawing.Point(107, 30);
            this.PolyIndexTextBox.Name = "PolyIndexTextBox";
            this.PolyIndexTextBox.Size = new System.Drawing.Size(92, 20);
            this.PolyIndexTextBox.TabIndex = 4;
            this.PolyIndexTextBox.Text = "0";
            this.PolyIndexTextBox.TextChanged += new System.EventHandler(this.PolyIndexTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Max Index: ";
            // 
            // maxIndexLabel
            // 
            this.maxIndexLabel.AutoSize = true;
            this.maxIndexLabel.Location = new System.Drawing.Point(107, 9);
            this.maxIndexLabel.Name = "maxIndexLabel";
            this.maxIndexLabel.Size = new System.Drawing.Size(13, 13);
            this.maxIndexLabel.TabIndex = 7;
            this.maxIndexLabel.Text = "0";
            // 
            // EvaluatePolynomialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 129);
            this.Controls.Add(this.maxIndexLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PolyIndexTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.EvaluateTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EvaluatePolynomialForm";
            this.Text = "Evaluate Polynomial";
            this.Load += new System.EventHandler(this.EvaluatePolynomialForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EvaluateTextBox;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PolyIndexTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label maxIndexLabel;
    }
}