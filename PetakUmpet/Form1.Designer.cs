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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_LoadFile
            // 
            this.button_LoadFile.Location = new System.Drawing.Point(28, 12);
            this.button_LoadFile.Name = "button_LoadFile";
            this.button_LoadFile.Size = new System.Drawing.Size(134, 72);
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
            this.button_loadQuery.Location = new System.Drawing.Point(441, 12);
            this.button_loadQuery.Name = "button_loadQuery";
            this.button_loadQuery.Size = new System.Drawing.Size(119, 72);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(566, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(123, 43);
            this.listBox1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(311, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 72);
            this.button3.TabIndex = 8;
            this.button3.Text = "Solve";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(168, 12);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(137, 43);
            this.listBox3.TabIndex = 10;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(566, 64);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(123, 17);
            this.listBox2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 571);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_nextQuery);
            this.Controls.Add(this.button_loadQuery);
            this.Controls.Add(this.panel_DrawGraph);
            this.Controls.Add(this.button_LoadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_LoadFile;
        private System.Windows.Forms.OpenFileDialog openFileGraph;
        private System.Windows.Forms.Panel panel_DrawGraph;
        private System.Windows.Forms.OpenFileDialog openFileQuery;
        private System.Windows.Forms.Button button_loadQuery;
        private System.Windows.Forms.Button button_nextQuery;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox2;
    }
}

