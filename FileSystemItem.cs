using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class FileSystemItem
    {
        public string Name { get; set; }
        public abstract double GetSize();
        public abstract int Count();
        public virtual IEnumerable <FileSystemItem> GetChildren() => Enumerable.Empty<FileSystemItem>();
    }
}
