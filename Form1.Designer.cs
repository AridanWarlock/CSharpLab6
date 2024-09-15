namespace CSharpLab6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            nuPogodi1 = new NuPogodi();
            SuspendLayout();
            // 
            // nuPogodi1
            // 
            nuPogodi1.BackgroundImage = (Image)resources.GetObject("nuPogodi1.BackgroundImage");
            nuPogodi1.Location = new Point(3, 12);
            nuPogodi1.Name = "nuPogodi1";
            nuPogodi1.Size = new Size(1024, 620);
            nuPogodi1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 616);
            Controls.Add(nuPogodi1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private NuPogodi nuPogodi1;
    }
}
