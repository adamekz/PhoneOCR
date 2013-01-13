namespace ocrtestclient
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
            this.label1 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenButton = new System.Windows.Forms.Button();
            this.FileBox = new System.Windows.Forms.TextBox();
            this.response = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Address:";
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(63, 40);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(118, 20);
            this.address.TabIndex = 2;
            this.address.Text = "127.0.0.1";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(13, 66);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(168, 23);
            this.send.TabIndex = 3;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(137, 10);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(43, 23);
            this.OpenButton.TabIndex = 5;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // FileBox
            // 
            this.FileBox.Location = new System.Drawing.Point(13, 13);
            this.FileBox.Name = "FileBox";
            this.FileBox.Size = new System.Drawing.Size(118, 20);
            this.FileBox.TabIndex = 6;
            // 
            // response
            // 
            this.response.Location = new System.Drawing.Point(15, 96);
            this.response.Name = "response";
            this.response.Size = new System.Drawing.Size(165, 174);
            this.response.TabIndex = 7;
            this.response.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 282);
            this.Controls.Add(this.response);
            this.Controls.Add(this.FileBox);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.send);
            this.Controls.Add(this.address);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "OCR Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.TextBox FileBox;
        private System.Windows.Forms.RichTextBox response;
    }
}

