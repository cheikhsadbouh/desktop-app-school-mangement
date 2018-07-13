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
    public partial class exam : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1K7UMT7\SQLEXPRESS;Initial Catalog=gestionecole;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;


        public exam()
        {
            InitializeComponent();
        }

        private void exam_Load(object sender, EventArgs e)
        {
            
           // metroGridec
            System.Data.DataTable dt = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT note.id_etudiant,matier.nom_matier,note.note_ex,note.id_sem FROM note INNER JOIN matier on matier.id_matier = note.id_matier WHERE matier.id_section = '2'", con);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            con.Close();
            ad.Fill(dt);
            metroGridec.DataSource = dt;
            metroGridec.DataMember = dt.TableName;


            
           // metroGrided
            System.Data.DataTable dtd = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT note.id_etudiant,matier.nom_matier,note.note_ex,note.id_sem FROM note INNER JOIN matier on matier.id_matier = note.id_matier WHERE matier.id_section = '1'", con);

            SqlDataAdapter add = new SqlDataAdapter(cmd);
            con.Close();
            add.Fill(dtd);
            metroGrided.DataSource = dtd;
            metroGrided.DataMember = dtd.TableName;


            //  metroGridea

            System.Data.DataTable dta = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT note.id_etudiant,matier.nom_matier,note.note_ex,note.id_sem FROM note INNER JOIN matier on matier.id_matier = note.id_matier WHERE matier.id_section = '3'", con);

            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            con.Close();
            ada.Fill(dta);
            metroGridea.DataSource = dta;
            metroGridea.DataMember = dta.TableName;


            // metroGrideo

            System.Data.DataTable dto = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT note.id_etudiant,matier.nom_matier,note.note_ex,note.id_sem FROM note INNER JOIN matier on matier.id_matier = note.id_matier WHERE matier.id_section = '4'", con);

            SqlDataAdapter ado = new SqlDataAdapter(cmd);
            con.Close();
            ado.Fill(dto);
            metroGrideo.DataSource = dto;
            metroGrideo.DataMember = dto.TableName;


        }
    }
}
