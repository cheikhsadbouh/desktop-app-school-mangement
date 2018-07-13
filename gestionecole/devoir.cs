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
    public partial class devoir : MetroFramework.Controls.MetroUserControl
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1K7UMT7\SQLEXPRESS;Initial Catalog=gestionecole;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        public devoir()
        {
            InitializeComponent();
        }

        private void devoir_Load(object sender, EventArgs e)
        {

            //metroGriddc

            System.Data.DataTable dt = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT note.id_etudiant,matier.nom_matier,note.note_cc,note.id_sem FROM note INNER JOIN matier on matier.id_matier = note.id_matier WHERE matier.id_section = '2'", con);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            con.Close();
            ad.Fill(dt);
            metroGriddc.DataSource = dt;
            metroGriddc.DataMember = dt.TableName;

            // metroGriddd
            System.Data.DataTable dtd = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT note.id_etudiant,matier.nom_matier,note.note_cc,note.id_sem FROM note INNER JOIN matier on matier.id_matier = note.id_matier WHERE matier.id_section = '1'", con);

            SqlDataAdapter add = new SqlDataAdapter(cmd);
            con.Close();
            add.Fill(dtd);
            metroGriddd.DataSource = dtd;
            metroGriddd.DataMember = dtd.TableName;


            //   metroGridda
            System.Data.DataTable dta = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT note.id_etudiant,matier.nom_matier,note.note_cc,note.id_sem FROM note INNER JOIN matier on matier.id_matier = note.id_matier WHERE matier.id_section = '3'", con);

            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            con.Close();
            ada.Fill(dta);
            metroGridda.DataSource = dta;
            metroGridda.DataMember = dta.TableName;

            //  metroGriddo
            System.Data.DataTable dto = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT note.id_etudiant,matier.nom_matier,note.note_cc,note.id_sem FROM note INNER JOIN matier on matier.id_matier = note.id_matier WHERE matier.id_section = '4'", con);

            SqlDataAdapter ado = new SqlDataAdapter(cmd);
            con.Close();
            ado.Fill(dto);
            metroGriddo.DataSource = dto;
            metroGriddo.DataMember = dto.TableName;

        }
    }
}
