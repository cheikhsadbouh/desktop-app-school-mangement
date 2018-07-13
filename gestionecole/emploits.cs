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
    public partial class emploits : MetroFramework.Controls.MetroUserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1K7UMT7\SQLEXPRESS;Initial Catalog=gestionecole;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        public emploits()
        {
            InitializeComponent();
        }

        private void emploits_Load(object sender, EventArgs e)
        {
            //
           // metroGridc
            System.Data.DataTable dt = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT horaire.horaire,professeur.nom,matier.nom_matier,seance.jours,seance.id_sale FROM seance INNER JOIN horaire  on horaire.id_horaire = seance.id_horaire INNER JOIN professeur  on professeur.id_prof = seance.id_prof INNER JOIN matier on matier.id_matier = seance.id_matier WHERE matier.id_section = '2'", con);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            con.Close();
            ad.Fill(dt);
            metroGridc.DataSource = dt;
            metroGridc.DataMember = dt.TableName;

            //metroGridD


            System.Data.DataTable dtd = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT horaire.horaire,professeur.nom,matier.nom_matier,seance.jours,seance.id_sale FROM seance INNER JOIN horaire  on horaire.id_horaire = seance.id_horaire INNER JOIN professeur  on professeur.id_prof = seance.id_prof INNER JOIN matier on matier.id_matier = seance.id_matier WHERE matier.id_section = '1'", con);

            SqlDataAdapter add = new SqlDataAdapter(cmd);
            con.Close();
            add.Fill(dtd);
            metroGridD.DataSource = dtd;
            metroGridD.DataMember = dtd.TableName;

            // metroGridA
            System.Data.DataTable dtA = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT horaire.horaire,professeur.nom,matier.nom_matier,seance.jours,seance.id_sale FROM seance INNER JOIN horaire  on horaire.id_horaire = seance.id_horaire INNER JOIN professeur  on professeur.id_prof = seance.id_prof INNER JOIN matier on matier.id_matier = seance.id_matier WHERE matier.id_section = '3'", con);

            SqlDataAdapter adA = new SqlDataAdapter(cmd);
            con.Close();
            adA.Fill(dtA);
            metroGridA.DataSource = dtA;
            metroGridA.DataMember = dtA.TableName;

            // metroGridO

            System.Data.DataTable dto = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT horaire.horaire,professeur.nom,matier.nom_matier,seance.jours,seance.id_sale FROM seance INNER JOIN horaire  on horaire.id_horaire = seance.id_horaire INNER JOIN professeur  on professeur.id_prof = seance.id_prof INNER JOIN matier on matier.id_matier = seance.id_matier WHERE matier.id_section = '4'", con);

            SqlDataAdapter ado = new SqlDataAdapter(cmd);
            con.Close();
            ado.Fill(dto);
            metroGridO.DataSource = dto;
            metroGridO.DataMember = dto.TableName;
        }

        
    }
}
