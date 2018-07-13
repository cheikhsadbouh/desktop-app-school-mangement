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
    public partial class professeurs : UserControl
    {
        public professeurs()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try {
               professeurBindingSource1.EndEdit();
              
               professeurTableAdapter.Update(this.gestionecoleDataSet1.professeur);
                MetroFramework.MetroMessageBox.Show(this, "saves secucess", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {

               MetroFramework.MetroMessageBox.Show(this, "eroooorr", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           Cursor.Current = Cursors.Default;
        }

      

        private void professeurs_Load(object sender, EventArgs e)
        {
           this.professeurTableAdapter.Fill(this.gestionecoleDataSet1.professeur);
        }

        private void metroGrid1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete) {

                if (MetroFramework.MetroMessageBox.Show(this, "eroooorr", "message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    professeurBindingSource1.RemoveCurrent();

            }

        }
    }
}
