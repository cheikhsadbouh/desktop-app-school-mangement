using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace gestionecole
{
    public partial class payments : MetroFramework.Controls.MetroUserControl
    {
        Formrecu p;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1K7UMT7\SQLEXPRESS;Initial Catalog=gestionecole;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        public payments()
        {
            InitializeComponent();
        }

        private void payments_Load(object sender, EventArgs e)
        {

            con.Open();

            cmd = new SqlCommand("select id_etudiant from etudiant ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                metroComboBox1.Items.Add(dr["id_etudiant"].ToString()); 
            }
           
            con.Close();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            //metroComboBox1.Text
            //  metroComboBox2.text
            string s = metroComboBox3.Text.ToString();
            string c = metroComboBox2.Text.ToString();
            string t = metroComboBox1.Text.ToString();
            cmd = new SqlCommand("insert into frais  (type_frais,montant_frais,id_etudiant) values ('"+c+"','"+s+"','"+t+ "');SELECT CAST(scope_identity() AS int)", con);

            int newid = (int)cmd.ExecuteScalar();

            con.Close();

            ////-------------------///
            con.Open();
            cmd = new SqlCommand(" insert into recu (date_recu,id_frais) values ('"+metroDateTime1.Text+ "','"+newid+ "');SELECT CAST(scope_identity() AS int)", con);

            int rid = (int)cmd.ExecuteScalar();
            con.Close();

            p = new Formrecu();
            
            p.metroLabel1.Text = t;
            p.metroLabel2.Text = c;
            p.metroLabel3.Text = s;
            p.metroLink5.Text = rid.ToString();
            p.metroLabel4.Text = metroDateTime1.Text;
           

            MetroFramework.MetroMessageBox.Show(this, "payments realise avec success", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            


        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            p.Show();
          //  MetroFramework.MetroMessageBox.Show(this, "payments realise avec success", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
