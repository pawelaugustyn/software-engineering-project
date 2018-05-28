using MetroFramework.Forms;

namespace ScrumIt.Forms
{
    public partial class ManageProject : MetroForm
    {
        private int _pojectId;

        public ManageProject(int projectId)
        {
            _pojectId = projectId;
            InitializeComponent();
        }
    }
}
