using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class TreeVisual : Visual
    {
        private FolderItem _root;

        public void Visualize(FolderItem root, Panel panel)
        {
            _root = root;
            panel.AutoScroll = true;
            panel.Paint -= Panel_Paint;
            panel.Paint += Panel_Paint;
            int estimatedHeight = _root.Count() * 50;
            panel.AutoScrollMinSize = new Size(0, estimatedHeight);
            panel.Invalidate();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            if (_root == null) return;
            var panel = sender as Panel;
            var g = e.Graphics;
            g.Clear(Color.White);
            var scrollOffset = panel.AutoScrollPosition;
            g.TranslateTransform(scrollOffset.X, scrollOffset.Y);
            int y = 20;
            int baseX = 40;
            DrawNode(g, _root, level: 0, baseX: baseX, ref y, out _);
        }

        private void DrawNode(Graphics g, FileSystemItem item, int level, int baseX, ref int y, out Rectangle rect)
        {
            int width = 180;
            int height = 28;
            int vSpace = 15;
            int indent = 40;
            int x = baseX + level * indent;
            rect = new Rectangle(x, y, width, height);
            Brush brush = (item is FolderItem) ? Brushes.LightBlue : Brushes.LightYellow;
            g.FillRectangle(brush, rect);
            g.DrawRectangle(Pens.Black, rect);
            string label = item.Name;
            double size = item.GetSize() / (1024.0 * 1024.0);
            label += $" ({size:0.##} MB)";
            g.DrawString(label, SystemFonts.DefaultFont, Brushes.Black, rect.X + 4, rect.Y + 6);
            int parentX = rect.Left + 10;
            int parentBottomY = rect.Bottom;
            y += height + vSpace;

            if (item is FolderItem folderItem && folderItem.Children.Count > 0)
            {
                foreach (var child in folderItem.Children)
                {
                    Rectangle childRect;
                    DrawNode(g, child, level + 1, baseX, ref y, out childRect);
                    int childX = childRect.Left;
                    int childCenterY = childRect.Top + childRect.Height / 2;
                    g.DrawLine(Pens.Black, parentX, parentBottomY, parentX, childCenterY);
                    g.DrawLine(Pens.Black, parentX, childCenterY, childX, childCenterY);
                }
            }
        }
    }
}