using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Context
    {
        public FolderItem Root { get; private set; }
        public Visual CurrentVisual { get; private set; }
        public void SetRoot(FolderItem root)
        {
            Root = root;
        }
        public void SetVisual(Visual visual)
        {
            CurrentVisual = visual;
        }
        public void Draw(Panel panel)
        {
            if (Root == null || CurrentVisual == null)
                return;

            CurrentVisual.Visualize(Root, panel);
        }
    }
}