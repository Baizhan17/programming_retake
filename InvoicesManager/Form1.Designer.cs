namespace InvoicesManager
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
            button1 = new Button();
            txtFilePath = new TextBox();
            txtFileContent = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(30, 143);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(143, 145);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(210, 27);
            txtFilePath.TabIndex = 1;
            // 
            // txtFileContent
            // 
            txtFileContent.Location = new Point(380, 78);
            txtFileContent.Name = "txtFileContent";
            txtFileContent.Size = new Size(372, 256);
            txtFileContent.TabIndex = 2;
            txtFileContent.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtFileContent);
            Controls.Add(txtFilePath);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtFilePath;
        private RichTextBox txtFileContent;
    }
}