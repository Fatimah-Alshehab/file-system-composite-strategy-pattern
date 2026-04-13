using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class BarChartVisual : Visual
    {
        private List<FileSystemItem> _allItems;
        private double _totalSize;

        public void Visualize(FolderItem root, Panel panel)
        {
            _allItems = GetAllItems(root);
            _totalSize = _allItems.Sum(i => i.GetSize());
            panel.AutoScroll = true;
            panel.Paint -= Panel_Paint;
            panel.Paint += Panel_Paint;
            int estimatedHeight = _allItems.Count * 50;
            panel.AutoScrollMinSize = new Size(1200, estimatedHeight);
            panel.Invalidate();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            if (_allItems == null) return;
            var panel = sender as Panel;
            var g = e.Graphics;
            g.Clear(Color.White);
            var scrollOffset = panel.AutoScrollPosition;
            g.TranslateTransform(scrollOffset.X, scrollOffset.Y);

            int y = 20;
            int barHeight = 30;
            int spacing = 15;
            int maxBarWidth = 600;

            foreach (var item in _allItems.OrderByDescending(i => i.GetSize()))
            {
                double sizeMB = item.GetSize() / (1024.0 * 1024.0);
                float ratio = (_totalSize > 0) ? (float)(item.GetSize() / _totalSize) : 0;
                int barWidth = (int)(maxBarWidth * ratio * 1.5);
                if (barWidth < 20) barWidth = 20;
                Brush brush = (item is FolderItem) ? Brushes.SteelBlue : Brushes.Peru;
                Rectangle rect = new Rectangle(40, y, barWidth, barHeight);
                g.FillRectangle(brush, rect);
                g.DrawRectangle(Pens.Black, rect);
                string label = $"({sizeMB:0.##} MB) {item.Name}";
                g.DrawString(label, SystemFonts.DefaultFont, Brushes.Black, 40 + barWidth + 10, y + 6);
                y += barHeight + spacing;
            }
        }

        private List<FileSystemItem> GetAllItems(FolderItem root)
        {
            var list = new List<FileSystemItem>();
            foreach (var item in root.GetChildren())
            {
                list.Add(item);
                if (item is FolderItem folder)
                {
                    list.AddRange(GetAllItems(folder));
                }
            }
            return list;
        }
    }
}