using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelFolders;
        private System.Windows.Forms.Panel panelVisual;
        private System.Windows.Forms.Button buttonBrowse;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelFolders = new System.Windows.Forms.Panel();
            this.panelVisual = new System.Windows.Forms.Panel();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.btnTree = new System.Windows.Forms.Button();
            this.btnBarChart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelFolders
            // 
            this.panelFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFolders.Location = new System.Drawing.Point(18, 78);
            this.panelFolders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelFolders.Name = "panelFolders";
            this.panelFolders.Size = new System.Drawing.Size(538, 571);
            this.panelFolders.TabIndex = 0;
            // 
            // panelVisual
            // 
            this.panelVisual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVisual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVisual.Location = new System.Drawing.Point(587, 78);
            this.panelVisual.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelVisual.Name = "panelVisual";
            this.panelVisual.Size = new System.Drawing.Size(830, 571);
            this.panelVisual.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBrowse.Location = new System.Drawing.Point(18, 668);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(180, 47);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // btnTree
            // 
            this.btnTree.Location = new System.Drawing.Point(587, 12);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(177, 43);
            this.btnTree.TabIndex = 3;
            this.btnTree.Text = "Tree";
            this.btnTree.UseVisualStyleBackColor = true;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // btnBarChart
            // 
            this.btnBarChart.Location = new System.Drawing.Point(788, 12);
            this.btnBarChart.Name = "btnBarChart";
            this.btnBarChart.Size = new System.Drawing.Size(177, 43);
            this.btnBarChart.TabIndex = 4;
            this.btnBarChart.Text = "BarChart";
            this.btnBarChart.UseVisualStyleBackColor = true;
            this.btnBarChart.Click += new System.EventHandler(this.btnBarChart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 729);
            this.Controls.Add(this.btnBarChart);
            this.Controls.Add(this.btnTree);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.panelVisual);
            this.Controls.Add(this.panelFolders);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Folder Size Visualizer";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnTree;
        private Button btnBarChart;
    }
}