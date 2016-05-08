namespace Payload
{
    partial class LockForm
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
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelSubtitle = new System.Windows.Forms.Label();
            this.LabelInstruction = new System.Windows.Forms.Label();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTitle.ForeColor = System.Drawing.Color.Red;
            this.LabelTitle.Location = new System.Drawing.Point(13, 13);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(329, 37);
            this.LabelTitle.TabIndex = 0;
            this.LabelTitle.Text = "How very unfortunate.";
            // 
            // LabelSubtitle
            // 
            this.LabelSubtitle.AutoSize = true;
            this.LabelSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSubtitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelSubtitle.Location = new System.Drawing.Point(14, 50);
            this.LabelSubtitle.Name = "LabelSubtitle";
            this.LabelSubtitle.Size = new System.Drawing.Size(308, 31);
            this.LabelSubtitle.TabIndex = 1;
            this.LabelSubtitle.Text = "Isn\'t this terribly absurd?";
            // 
            // LabelInstruction
            // 
            this.LabelInstruction.AutoSize = true;
            this.LabelInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInstruction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LabelInstruction.Location = new System.Drawing.Point(17, 92);
            this.LabelInstruction.Name = "LabelInstruction";
            this.LabelInstruction.Size = new System.Drawing.Size(321, 13);
            this.LabelInstruction.TabIndex = 2;
            this.LabelInstruction.Text = "If you know the password, though, you can ascend from darkness.";
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(20, 110);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(249, 20);
            this.TextBoxPassword.TabIndex = 3;
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.Location = new System.Drawing.Point(275, 108);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(74, 23);
            this.ButtonSubmit.TabIndex = 4;
            this.ButtonSubmit.Text = "Ascend";
            this.ButtonSubmit.UseVisualStyleBackColor = true;
            this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // LockForm
            // 
            this.AcceptButton = this.ButtonSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 150);
            this.Controls.Add(this.ButtonSubmit);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.LabelInstruction);
            this.Controls.Add(this.LabelSubtitle);
            this.Controls.Add(this.LabelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniquity.";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelSubtitle;
        private System.Windows.Forms.Label LabelInstruction;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.Button ButtonSubmit;
    }
}