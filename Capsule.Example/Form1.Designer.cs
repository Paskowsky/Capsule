namespace Capsule.Example
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
            this.exportPubButton = new System.Windows.Forms.Button();
            this.exportPrivButton = new System.Windows.Forms.Button();
            this.keyBox = new System.Windows.Forms.GroupBox();
            this.importPubButton = new System.Windows.Forms.Button();
            this.importPrivButton = new System.Windows.Forms.Button();
            this.fileBox = new System.Windows.Forms.GroupBox();
            this.verifyDecryptVerifyButton = new System.Windows.Forms.Button();
            this.signEncryptSignButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.verifyButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.signButton = new System.Windows.Forms.Button();
            this.keyBox.SuspendLayout();
            this.fileBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportPubButton
            // 
            this.exportPubButton.Location = new System.Drawing.Point(6, 19);
            this.exportPubButton.Name = "exportPubButton";
            this.exportPubButton.Size = new System.Drawing.Size(100, 50);
            this.exportPubButton.TabIndex = 2;
            this.exportPubButton.Text = "Export \r\nPublic Key...";
            this.exportPubButton.UseVisualStyleBackColor = true;
            this.exportPubButton.Click += new System.EventHandler(this.exportPubButton_Click);
            // 
            // exportPrivButton
            // 
            this.exportPrivButton.Location = new System.Drawing.Point(112, 19);
            this.exportPrivButton.Name = "exportPrivButton";
            this.exportPrivButton.Size = new System.Drawing.Size(100, 50);
            this.exportPrivButton.TabIndex = 3;
            this.exportPrivButton.Text = "Export \r\nPrivate Key...";
            this.exportPrivButton.UseVisualStyleBackColor = true;
            this.exportPrivButton.Click += new System.EventHandler(this.exportPrivButton_Click);
            // 
            // keyBox
            // 
            this.keyBox.Controls.Add(this.importPubButton);
            this.keyBox.Controls.Add(this.importPrivButton);
            this.keyBox.Controls.Add(this.exportPubButton);
            this.keyBox.Controls.Add(this.exportPrivButton);
            this.keyBox.Location = new System.Drawing.Point(12, 12);
            this.keyBox.Name = "keyBox";
            this.keyBox.Size = new System.Drawing.Size(434, 76);
            this.keyBox.TabIndex = 4;
            this.keyBox.TabStop = false;
            this.keyBox.Text = "Keys";
            // 
            // importPubButton
            // 
            this.importPubButton.Location = new System.Drawing.Point(218, 19);
            this.importPubButton.Name = "importPubButton";
            this.importPubButton.Size = new System.Drawing.Size(100, 50);
            this.importPubButton.TabIndex = 4;
            this.importPubButton.Text = "Import \r\nPublic Key...";
            this.importPubButton.UseVisualStyleBackColor = true;
            this.importPubButton.Click += new System.EventHandler(this.importPubButton_Click);
            // 
            // importPrivButton
            // 
            this.importPrivButton.Location = new System.Drawing.Point(324, 19);
            this.importPrivButton.Name = "importPrivButton";
            this.importPrivButton.Size = new System.Drawing.Size(100, 50);
            this.importPrivButton.TabIndex = 5;
            this.importPrivButton.Text = "Import \r\nPrivate Key...";
            this.importPrivButton.UseVisualStyleBackColor = true;
            this.importPrivButton.Click += new System.EventHandler(this.importPrivButton_Click);
            // 
            // fileBox
            // 
            this.fileBox.Controls.Add(this.verifyDecryptVerifyButton);
            this.fileBox.Controls.Add(this.signEncryptSignButton);
            this.fileBox.Controls.Add(this.decryptButton);
            this.fileBox.Controls.Add(this.verifyButton);
            this.fileBox.Controls.Add(this.encryptButton);
            this.fileBox.Controls.Add(this.signButton);
            this.fileBox.Location = new System.Drawing.Point(12, 94);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(434, 132);
            this.fileBox.TabIndex = 5;
            this.fileBox.TabStop = false;
            this.fileBox.Text = "File";
            // 
            // verifyDecryptVerifyButton
            // 
            this.verifyDecryptVerifyButton.Location = new System.Drawing.Point(218, 75);
            this.verifyDecryptVerifyButton.Name = "verifyDecryptVerifyButton";
            this.verifyDecryptVerifyButton.Size = new System.Drawing.Size(206, 50);
            this.verifyDecryptVerifyButton.TabIndex = 11;
            this.verifyDecryptVerifyButton.Text = "Verify Decrypt Verify";
            this.verifyDecryptVerifyButton.UseVisualStyleBackColor = true;
            this.verifyDecryptVerifyButton.Click += new System.EventHandler(this.verifyDecryptVerifyButton_Click);
            // 
            // signEncryptSignButton
            // 
            this.signEncryptSignButton.Location = new System.Drawing.Point(6, 75);
            this.signEncryptSignButton.Name = "signEncryptSignButton";
            this.signEncryptSignButton.Size = new System.Drawing.Size(206, 50);
            this.signEncryptSignButton.TabIndex = 10;
            this.signEncryptSignButton.Text = "Sign Encrypt Sign";
            this.signEncryptSignButton.UseVisualStyleBackColor = true;
            this.signEncryptSignButton.Click += new System.EventHandler(this.signEncryptSignButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(218, 19);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(100, 50);
            this.decryptButton.TabIndex = 8;
            this.decryptButton.Text = "Decrypt File...";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // verifyButton
            // 
            this.verifyButton.Location = new System.Drawing.Point(324, 19);
            this.verifyButton.Name = "verifyButton";
            this.verifyButton.Size = new System.Drawing.Size(100, 50);
            this.verifyButton.TabIndex = 9;
            this.verifyButton.Text = "Verify File...";
            this.verifyButton.UseVisualStyleBackColor = true;
            this.verifyButton.Click += new System.EventHandler(this.verifyButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(6, 19);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(100, 50);
            this.encryptButton.TabIndex = 6;
            this.encryptButton.Text = "Encrypt File...";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // signButton
            // 
            this.signButton.Location = new System.Drawing.Point(112, 19);
            this.signButton.Name = "signButton";
            this.signButton.Size = new System.Drawing.Size(100, 50);
            this.signButton.TabIndex = 7;
            this.signButton.Text = "Sign File...";
            this.signButton.UseVisualStyleBackColor = true;
            this.signButton.Click += new System.EventHandler(this.signButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 235);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.keyBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Capsule Example";
            this.keyBox.ResumeLayout(false);
            this.fileBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exportPubButton;
        private System.Windows.Forms.Button exportPrivButton;
        private System.Windows.Forms.GroupBox keyBox;
        private System.Windows.Forms.Button importPubButton;
        private System.Windows.Forms.Button importPrivButton;
        private System.Windows.Forms.GroupBox fileBox;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button verifyButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button signButton;
        private System.Windows.Forms.Button verifyDecryptVerifyButton;
        private System.Windows.Forms.Button signEncryptSignButton;
    }
}

