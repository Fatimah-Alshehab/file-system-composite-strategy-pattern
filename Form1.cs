using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Context app = new Context();

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(900, 600);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    FolderItem root = BuildFolderTree(dlg.SelectedPath);
                    root.Name = new DirectoryInfo(dlg.SelectedPath).Name;
                    app.SetRoot(root);
                    ShowFoldersArea(root);
                    app.Draw(panelVisual);
                }
            }
        }

        private FolderItem BuildFolderTree(string path)
        {
            FolderItem folder = new FolderItem();
            folder.Name = new DirectoryInfo(path).Name;

            foreach (var dir in Directory.GetDirectories(path))
            {
                folder.Add(BuildFolderTree(dir));
            }

            foreach (var file in Directory.GetFiles(path))
            {
                FileInfo fi = new FileInfo(file);
                folder.Add(new FileItem
                {
                    Name = fi.Name,
                    Size = fi.Length,
                    Extension = fi.Extension
                });
            }

            return folder;
        }

        private void ShowFoldersArea(FolderItem root)
        {
            panelFolders.Controls.Clear();

            TextBox box = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ScrollBars = ScrollBars.Both,
                WordWrap = false,
                ReadOnly = true,
                Font = new Font("Consolas", 10)
            };

            box.Text = PrintTree(root, 0);
            panelFolders.Controls.Add(box);
        }

        private string PrintTree(FileSystemItem item, int level)
        {
            string indent = new string(' ', level * 3);
            string result = indent + "- " + item.Name + "\r\n";

            foreach (var child in item.GetChildren())
            {
                result += PrintTree(child, level + 1);
            }

            return result;
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            app.SetVisual(new TreeVisual());
            app.Draw(panelVisual);
        }

        private void btnBarChart_Click(object sender, EventArgs e)
        {
            app.SetVisual(new BarChartVisual());
            app.Draw(panelVisual);
        }
    }
}