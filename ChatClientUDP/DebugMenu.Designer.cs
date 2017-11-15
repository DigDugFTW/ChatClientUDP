namespace ChatClientUDP
{
    partial class DebugMenu
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
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.buttonClearTextArea = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDebug.Location = new System.Drawing.Point(13, 13);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ReadOnly = true;
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxDebug.Size = new System.Drawing.Size(310, 164);
            this.textBoxDebug.TabIndex = 0;
            this.textBoxDebug.WordWrap = false;
            // 
            // buttonClearTextArea
            // 
            this.buttonClearTextArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearTextArea.Location = new System.Drawing.Point(329, 11);
            this.buttonClearTextArea.Name = "buttonClearTextArea";
            this.buttonClearTextArea.Size = new System.Drawing.Size(75, 23);
            this.buttonClearTextArea.TabIndex = 1;
            this.buttonClearTextArea.Text = "Clear";
            this.buttonClearTextArea.UseVisualStyleBackColor = true;
            this.buttonClearTextArea.Click += new System.EventHandler(this.buttonClearTextArea_Click);
            // 
            // DebugMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 189);
            this.Controls.Add(this.buttonClearTextArea);
            this.Controls.Add(this.textBoxDebug);
            this.Name = "DebugMenu";
            this.Text = "DebugMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.Button buttonClearTextArea;
    }
}