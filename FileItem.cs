using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class FileItem : FileSystemItem
    {
        public double Size { get; set; }
        public string Extension { get; set; }
        public override double GetSize()
        {
            return Size;
        }
        public override int Count()
        {
            return 1;
        }
    }
}
