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
            this.openFileGraph = new System.Windows.Forms.OpenFileDialog();
            this.panel_DrawGraph = new System.Windows.Forms.Panel();
            this.openFileQuery = new System.Windows.Forms.OpenFileDialog();
            this.button_loadQuery = new System.Windows.Forms.Button();
            this.button_nextQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_LoadFile
            // 
            this.button_LoadFile.Location = new System.Drawing.Point(28, 12);
            this.button_LoadFile.Name = "button_LoadFile";
            this.button_LoadFile.Size = new System.Drawing.Size(301, 72);
            this.button_LoadFile.TabIndex = 0;
            this.button_LoadFile.Text = "Load File";
            this.button_LoadFile.UseVisualStyleBackColor = true;
            this.button_LoadFile.Click += new System.EventHandler(this.button_LoadFile_Click);
            // 
            // openFileGraph
            // 
            this.openFileGraph.FileName = "openFileGraph";
            // 
            // panel_DrawGraph
            // 
            this.panel_DrawGraph.Location = new System.Drawing.Point(28, 90);
            this.panel_DrawGraph.Name = "panel_DrawGraph";
            this.panel_DrawGraph.Size = new System.Drawing.Size(782, 469);
            this.panel_DrawGraph.TabIndex = 2;
            // 
            // openFileQuery
            // 
            this.openFileQuery.FileName = "openFileQuery";
            // 
            // button_loadQuery
            // 
            this.button_loadQuery.Location = new System.Drawing.Point(505, 12);
            this.button_loadQuery.Name = "button_loadQuery";
            this.button_loadQuery.Size = new System.Drawing.Size(184, 72);
            this.button_loadQuery.TabIndex = 4;
            this.button_loadQuery.Text = "Load Query";
            this.button_loadQuery.UseVisualStyleBackColor = true;
            this.button_loadQuery.Click += new System.EventHandler(this.button_loadQuery_Click);
            // 
            // button_nextQuery
            // 
            this.button_nextQuery.Location = new System.Drawing.Point(695, 12);
            this.button_nextQuery.Name = "button_nextQuery";
            this.button_nextQuery.Size = new System.Drawing.Size(115, 72);
            this.button_nextQuery.TabIndex = 5;
            this.button_nextQuery.Text = "Next Query";
            this.button_nextQuery.UseVisualStyleBackColor = true;
            this.button_nextQuery.Click += new System.EventHandler(this.button_nextQuery_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 571);
            this.Controls.Add(this.button_nextQuery);
            this.Controls.Add(this.button_loadQuery);
            this.Controls.Add(this.panel_DrawGraph);
            this.Controls.Add(this.button_LoadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_LoadFile;
        private System.Windows.Forms.OpenFileDialog openFileGraph;
        private System.Windows.Forms.Panel panel_DrawGraph;
        private System.Windows.Forms.OpenFileDialog openFileQuery;
        private System.Windows.Forms.Button button_loadQuery;
        private System.Windows.Forms.Button button_nextQuery;
    }
}

