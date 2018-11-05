using System;
using System.Windows.Forms;

namespace TestingGraph.UserControls
{
    public partial class StartPanel : UserControl
    {
        public StartPanel()
        {
            InitializeComponent();
        }

        private void SmezButton_Click(object sender, EventArgs e)
        {
           var parent = this.Controls.Owner.Parent.Parent;
            if (parent is Form2 form)
            {
                form.AddChild(ETypeControls.eAdjacencyMatrixInput);
            }
        }
    }
}
