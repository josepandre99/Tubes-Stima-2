namespace PetakUmpet
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
            this.button_LoadFile = new System.Windows.Forms.Button();
            this.button_Check = new System.Windows.Forms.Button();
            this.openFileGraph = new System.Windows.Forms.OpenFileDialog();
            this.panel_DrawGraph = new System.Windows.Forms.Panel();
            this.textBox_InputQuery = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_LoadFile
            // 
            this.button_LoadFile.Location = new System.Drawing.Point(12, 22);
            this.button_LoadFile.Name = "button_LoadFile";
            this.button_LoadFile.Size = new System.Drawing.Size(75, 23);
            this.button_LoadFile.TabIndex = 0;
            this.button_LoadFile.Text = "Load File";
            this.button_LoadFile.UseVisualStyleBackColor = true;
            this.button_LoadFile.Click += new System.EventHandler(this.button_LoadFile_Click);
            // 
            // button_Check
            // 
            this.button_Check.Location = new System.Drawing.Point(377, 22);
            this.button_Check.Name = "button_Check";
            this.button_Check.Size = new System.Drawing.Size(75, 23);
            this.button_Check.TabIndex = 1;
            this.button_Check.Text = "Check";
            this.button_Check.UseVisualStyleBackColor = true;
            // 
            // openFileGraph
            // 
            this.openFileGraph.FileName = "openFileGraph";
            // 
            // panel_DrawGraph
            // 
            this.panel_DrawGraph.Location = new System.Drawing.Point(12, 62);
            this.panel_DrawGraph.Name = "panel_DrawGraph";
            this.panel_DrawGraph.Size = new System.Drawing.Size(440, 227);
            this.panel_DrawGraph.TabIndex = 2;
            // 
            // textBox_InputQuery
            // 
            this.textBox_InputQuery.Location = new System.Drawing.Point(271, 24);
            this.textBox_InputQuery.Name = "textBox_InputQuery";
            this.textBox_InputQuery.Size = new System.Drawing.Size(100, 20);
            this.textBox_InputQuery.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 301);
            this.Controls.Add(this.textBox_InputQuery);
            this.Controls.Add(this.panel_DrawGraph);
            this.Controls.Add(this.button_Check);
            this.Controls.Add(this.button_LoadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LoadFile;
        private System.Windows.Forms.Button button_Check;
        private System.Windows.Forms.OpenFileDialog openFileGraph;
        private System.Windows.Forms.Panel panel_DrawGraph;
        private System.Windows.Forms.TextBox textBox_InputQuery;
    }
}

