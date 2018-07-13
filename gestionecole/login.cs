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
    public partial class login : MetroFramework.Forms.MetroForm
    {


       public   static login _sign;

        public static login Sign
        {

            get
            {

                if (_sign == null)
                {
                    _sign = new login();
                   
                }
                return _sign;
            }
        }


        public login()
        {
            InitializeComponent();
            materialSingleLineTextField1.Text = "";
            materialSingleLineTextField2.Text = "";
        }

        private void login_Load(object sender, EventArgs e)
        {

            
            _sign = this;
            materialSingleLineTextField1.Focus();

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(materialSingleLineTextField1.Text)) {
                MetroFramework.MetroMessageBox.Show(this, " please  enter your username ! ", "message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                materialSingleLineTextField1.Focus();

            }
            else if (String.IsNullOrEmpty(materialSingleLineTextField2.Text)) {
                MetroFramework.MetroMessageBox.Show(this, " please  enter  your password !", "message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                materialSingleLineTextField2.Focus();

         
            }
            ///
            if (materialSingleLineTextField1.Text!="" && materialSingleLineTextField2.Text !="") {
                if (materialSingleLineTextField1.Text.Equals("school") && materialSingleLineTextField2.Text.Equals("12345"))
                {

                    this.Hide();

                    mainf f = new mainf();
                    f.ShowDialog();

                }
                else {
                    MetroFramework.MetroMessageBox.Show(this, " your user name or password is incorrect  !", "message", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);


                }
            }//iflkbir
        }
    }
}
