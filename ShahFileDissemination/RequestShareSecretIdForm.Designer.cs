namespace ShahFileDissemination
{
    partial class RequestShareSecretIdForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.SecretIdComboBox = new System.Windows.Forms.ComboBox();
            this.RequestBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Secret Id:";
            // 
            // SecretIdComboBox
            // 
            this.SecretIdComboBox.FormattingEnabled = true;
            this.SecretIdComboBox.Location = new System.Drawing.Point(71, 14);
            this.SecretIdComboBox.Name = "SecretIdComboBox";
            this.SecretIdComboBox.Size = new System.Drawing.Size(142, 21);
            this.SecretIdComboBox.TabIndex = 2;
            // 
            // RequestBtn
            // 
            this.RequestBtn.Location = new System.Drawing.Point(219, 12);
            this.RequestBtn.Name = "RequestBtn";
            this.RequestBtn.Size = new System.Drawing.Size(75, 23);
            this.RequestBtn.TabIndex = 3;
            this.RequestBtn.Text = "Request";
            this.RequestBtn.UseVisualStyleBackColor = true;
            this.RequestBtn.Click += new System.EventHandler(this.RequestBtn_Click);
            // 
            // RequestShareSecretIdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 51);
            this.Controls.Add(this.RequestBtn);
            this.Controls.Add(this.SecretIdComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RequestShareSecretIdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Request Secret Share";
            this.Load += new System.EventHandler(this.RequestShareSecretIdForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SecretIdComboBox;
        private System.Windows.Forms.Button RequestBtn;
    }
}