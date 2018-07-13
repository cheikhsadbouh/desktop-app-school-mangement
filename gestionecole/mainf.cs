using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionecole
{
    public partial class mainf : MetroFramework.Forms.MetroForm
    {
        

        public mainf()
        {
            InitializeComponent();
           
        }
         static mainf _instance;

        public static mainf Instance
        {
            get
            {

                if (_instance == null)
                {

                    _instance = new mainf();

                }

                return _instance;


            }

        }
        
        public  MetroFramework.Controls.MetroPanel Containers
        {
            get { return mpanel; }
            set { mpanel = value; }
        }



        public MetroFramework.Controls.MetroLink Link
        {
            get { return blink; }
            set { blink = value; }
        }

        private void mainf_Load(object sender, EventArgs e)
        {
            blink.Visible = false;
           
            _instance = this;
            dashbord d = new dashbord();
            d.Dock = DockStyle.Fill;
            mpanel.Controls.Add(d);
           
        }

        private void blink_Click(object sender, EventArgs e)
        {
            mpanel.Controls["dashbord"].BringToFront();
            blink.Visible = false;
            
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
           
            this.Close();
            login.Sign.Show();
            
        }
    }
}
