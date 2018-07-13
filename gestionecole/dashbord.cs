using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionecole
{
    public partial class dashbord : MetroFramework.Controls.MetroUserControl
    {
        public dashbord()
        {
            InitializeComponent();
            
          
            
        }

        private void dashbord_Load(object sender, EventArgs e)
        {
            mainf.Instance.Link.Visible = false;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (!mainf.Instance.Containers.Controls.ContainsKey("etudiant")) {
                etudiant ed = new etudiant();
                ed.Dock = DockStyle.Fill;
                mainf.Instance.Containers.Controls.Add(ed);

            }
          
            mainf.Instance.Containers.Controls["etudiant"].BringToFront();
            mainf.Instance.Link.Visible = true;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            if (!mainf.Instance.Containers.Controls.ContainsKey("professeurs"))
            {
                professeurs pro = new professeurs();
                pro.Dock = DockStyle.Fill;
                mainf.Instance.Containers.Controls.Add(pro);

            }

            mainf.Instance.Containers.Controls["professeurs"].BringToFront();
            mainf.Instance.Link.Visible = true;

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            if (!mainf.Instance.Containers.Controls.ContainsKey("emploits"))
            {
                emploits ed = new emploits();
                ed.Dock = DockStyle.Fill;
                mainf.Instance.Containers.Controls.Add(ed);

            }

            mainf.Instance.Containers.Controls["emploits"].BringToFront();
            mainf.Instance.Link.Visible = true;
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            if (!mainf.Instance.Containers.Controls.ContainsKey("devoir"))
            {
                devoir ed = new devoir();
                ed.Dock = DockStyle.Fill;
                mainf.Instance.Containers.Controls.Add(ed);

            }

            mainf.Instance.Containers.Controls["devoir"].BringToFront();
            mainf.Instance.Link.Visible = true;
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            if (!mainf.Instance.Containers.Controls.ContainsKey("exam"))
            {
                exam ed = new exam();
                ed.Dock = DockStyle.Fill;
                mainf.Instance.Containers.Controls.Add(ed);

            }

            mainf.Instance.Containers.Controls["exam"].BringToFront();
            mainf.Instance.Link.Visible = true;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if (!mainf.Instance.Containers.Controls.ContainsKey("payments"))
            {
                payments ed = new payments();
                ed.Dock = DockStyle.Fill;
                mainf.Instance.Containers.Controls.Add(ed);

            }

            mainf.Instance.Containers.Controls["payments"].BringToFront();
            mainf.Instance.Link.Visible = true;
        }
    }
}
