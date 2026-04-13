using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace WindowsFormsApp1
{
    public class FolderItem : FileSystemItem
    {
        public List<FileSystemItem> Children { get; } = new List<FileSystemItem>();
        public override IEnumerable<FileSystemItem> GetChildren() => Children;
        public void Add (FileSystemItem item)
        {
            Children.Add(item);
        }

        public override double GetSize()
        {
            double total = 0;
            foreach (FileSystemItem item in Children)
                total += item.GetSize();
            return total;
        }
        public override int Count()
        {
            int total = 1;
            foreach (FileSystemItem item in Children)
                total += item.Count();
            return total;
        }
    }
}
