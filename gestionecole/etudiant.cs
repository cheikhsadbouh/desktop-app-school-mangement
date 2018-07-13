using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace gestionecole
{
    public partial class etudiant : MetroFramework.Controls.MetroUserControl
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1K7UMT7\SQLEXPRESS;Initial Catalog=gestionecole;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        SqlDataReader rd;
        SqlParameter picture;
       int globalid;

        public etudiant()
        {
            InitializeComponent();
        }

        private void etudiant_Load(object sender, EventArgs e)
        {
            // metroGrid2 //a
            System.Data.DataTable dt = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT id_etudiant,nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre  FROM etudiant where id_section='3' ", con);
           
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            con.Close();
            ad.Fill(dt);
            metroGrid2.DataSource = dt;
            metroGrid2.DataMember = dt.TableName;

            //metroGrid1 //d
            System.Data.DataTable dt1 = new System.Data.DataTable();
            con.Open();

            cmd = new SqlCommand("SELECT id_etudiant,nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre  FROM etudiant  where id_section='1'", con);
         
            SqlDataAdapter ad1 = new SqlDataAdapter(cmd);
            con.Close();
            ad1.Fill(dt1);
            metroGrid1.DataSource = dt1;
            metroGrid1.DataMember = dt1.TableName;
            //metroGrid3 //c
            System.Data.DataTable dt3 = new System.Data.DataTable();
            con.Open();
            cmd = new SqlCommand("SELECT id_etudiant,nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre  FROM etudiant where id_section='2' ", con);

            SqlDataAdapter ad3 = new SqlDataAdapter(cmd);
            con.Close();
            ad3.Fill(dt3);
            metroGrid3.DataSource = dt3;
            metroGrid3.DataMember = dt3.TableName;

            //metroGrid4 //o
            System.Data.DataTable dt4 = new System.Data.DataTable();
            con.Open();
            cmd = new SqlCommand("SELECT id_etudiant,nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre  FROM etudiant  where id_section='4'", con);

            SqlDataAdapter ad4 = new SqlDataAdapter(cmd);
            con.Close();
            ad4.Fill(dt4);
            metroGrid4.DataSource = dt4;
            metroGrid4.DataMember = dt4.TableName;

        }




        private void open()
        {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.InitialDirectory = "C:/picture";
                f.Filter = "ALL Files|*.*|JPEGS|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";

                f.FilterIndex = 2;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(f.FileName);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                    metroLabel1.Text = f.SafeFileName.ToString();

                }

            }
            catch
            {
            }
        }
        private void open2() {
            try
            {
                OpenFileDialog f = new OpenFileDialog();
                f.InitialDirectory = "C:/picture";
                f.Filter = "ALL Files|*.*|JPEGS|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";

                f.FilterIndex = 2;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(f.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                    

                }

            }
            catch
            {
            }



        }

        private void save()
        {
            if (pictureBox2.Image != null)
            {
               
                MemoryStream ms = new MemoryStream();


                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                byte[] a = ms.GetBuffer();
                ms.Close();
            //  cmd.Parameters.Clear();
           
                string gendre;
                if (r1male.Checked)
                {
                    gendre = "male";
                }
                else
                {
                    gendre = "femelle";
                }

                
               
                con.Open();

                if (metroComboBox1.Text.ToString()=="sectionD") {
                    cmd = new SqlCommand("insert into  etudiant (nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre,img,id_section) values ('" + nom.Text + "','" + tel.Text + "','" + nas.Text + "','" + datens.Text + "','" + lieu.Text + "','" + gendre + "',@picture,'1')", con);
                    cmd.Parameters.AddWithValue("@picture", a);
                }
                if (metroComboBox1.Text.ToString() == "sectionC")
                {
                    cmd = new SqlCommand("insert into  etudiant (nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre,img,id_section) values ('" + nom.Text + "','" + tel.Text + "','" + nas.Text + "','" + datens.Text + "','" + lieu.Text + "','" + gendre + "',@picture,'2')", con);
                    cmd.Parameters.AddWithValue("@picture", a);
                }
                if (metroComboBox1.Text.ToString() == "sectionA")
                {
                    cmd = new SqlCommand("insert into  etudiant (nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre,img,id_section) values ('" + nom.Text + "','" + tel.Text + "','" + nas.Text + "','" + datens.Text + "','" + lieu.Text + "','" + gendre + "',@picture,'3')", con);
                    cmd.Parameters.AddWithValue("@picture", a);
                }
                if (metroComboBox1.Text.ToString() == "sectionO")
                {
                    cmd = new SqlCommand("insert into  etudiant (nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre,img,id_section) values ('" + nom.Text + "','" + tel.Text + "','" + nas.Text + "','" + datens.Text + "','" + lieu.Text + "','" + gendre + "',@picture,'4')", con);
                    cmd.Parameters.AddWithValue("@picture", a);
                }


                cmd.ExecuteScalar();
                //;SELECT CAST(scope_identity() AS int) int newid = (int)cmd.ExecuteScalar();
                con.Close();
               
                metroLabel1.Text = "";
                pictureBox2.Image = null;
                nom.Text = "";
                tel.Text = "";
                nas.Text = "";
                lieu.Text = "";
               
               
                MetroFramework.MetroMessageBox.Show(this, "etudiant creer avec success", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }

        }









        private void metroGrid2_CellClick_1(object sender, DataGridViewCellEventArgs e)

        {
            //a
            String id = metroGrid2.Rows[e.RowIndex].Cells["id_etudiant"].Value.ToString();
            globalid =int.Parse(metroGrid2.Rows[e.RowIndex].Cells["id_etudiant"].Value.ToString());

            con.Open();

            cmd = new SqlCommand("select nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre from etudiant where id_etudiant='" + id + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                materialSingleLineTextField5.Text = dr["nom"].ToString();
                materialSingleLineTextField3.Text = dr["tel"].ToString();
                materialSingleLineTextField2.Text = dr["numero_nas"].ToString();
                materialSingleLineTextField1.Text = dr["lieu_de_naiss"].ToString();
                //metroDateTime2.Value.Add(TimeSpan.Parse(dr["date_naissance"].ToString()));
                string gendre = dr["gendre"].ToString();
                if (gendre != "femelle") {
                    materialRadioButton4.Checked = true;
                } else {
                    materialRadioButton3.Checked = true;

                }

            }
            con.Close();

              

               con.Open();
               // SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand
               //   ("select img from etudiant where id_etudiant='" + id + "'", con));
               cmd.CommandText = "select img from etudiant where id_etudiant='" + id + "'";
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               SqlCommandBuilder cbd = new SqlCommandBuilder(da);
               System.Data.DataSet ds = new System.Data.DataSet();
               da.Fill(ds);
               con.Close();


                   Byte[] ap = (Byte[])(ds.Tables[0].Rows[0]["img"]);

               MemoryStream ms = new MemoryStream(ap);
                   pictureBox1.Image = Image.FromStream(ms);
                   pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                   pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                   ms.Close();


               


        }

        private void materialFlatButton1_Click_1(object sender, EventArgs e)
        {
            save();
            this.etudiant_Load(sender, e);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            open();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            //importupdate
            
            open2();
        }

        private void update_Click(object sender, EventArgs e)
        {

         
            string nom = materialSingleLineTextField5.Text;
            string tel = materialSingleLineTextField3.Text;
            string numero_nas = materialSingleLineTextField2.Text;
            string lieu_de_naiss = materialSingleLineTextField1.Text;
            string daten = metroDateTime2.Text;
            string gendre = null;
            if (materialRadioButton4.Checked == true) {
                gendre = "male";
            } else {
                gendre = "femelle";
            }
           

            if (pictureBox1.Image != null)
            {

               MemoryStream ms = new MemoryStream();


                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
               byte[] a = ms.GetBuffer();
                ms.Close();
                  cmd.Parameters.Clear();



                //(nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre,img)

                con.Open();
                cmd = new SqlCommand("update etudiant set nom='"+nom+"',tel='"+tel+"',numero_nas='"+numero_nas+"',date_naissance='"+daten+"',lieu_de_naiss='"+lieu_de_naiss+"',gendre='"+gendre+ "' , img=@picture where id_etudiant=" + globalid+";",con);
               
               /* cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@tel", tel);
                cmd.Parameters.AddWithValue("@numnass", numero_nas);
                cmd.Parameters.AddWithValue("@date", daten);
                cmd.Parameters.AddWithValue("@lieu", lieu_de_naiss);
                cmd.Parameters.AddWithValue("@gendre", gendre);
                cmd.Parameters.AddWithValue("@id",globalid);*/
                 cmd.Parameters.AddWithValue("@picture", a);
              cmd.ExecuteNonQuery();
                //cmd.ExecuteScalar();
                //cmd.ExecuteReader();
                con.Close();
                
              //  pictureBox1.Image = null;
                MetroFramework.MetroMessageBox.Show(this, " update etudiant avec success", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.etudiant_Load(sender, e);
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("delete from etudiant where  id_etudiant='"+globalid+"' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MetroFramework.MetroMessageBox.Show(this, " delete etudiant avec success", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.etudiant_Load(sender, e);

        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //d
            String id = metroGrid1.Rows[e.RowIndex].Cells["id_etudiant"].Value.ToString();
            globalid = int.Parse(metroGrid1.Rows[e.RowIndex].Cells["id_etudiant"].Value.ToString());

            con.Open();

            cmd = new SqlCommand("select nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre from etudiant where id_etudiant='" + id + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                materialSingleLineTextField5.Text = dr["nom"].ToString();
                materialSingleLineTextField3.Text = dr["tel"].ToString();
                materialSingleLineTextField2.Text = dr["numero_nas"].ToString();
                materialSingleLineTextField1.Text = dr["lieu_de_naiss"].ToString();
                //metroDateTime2.Value.Add(TimeSpan.Parse(dr["date_naissance"].ToString()));
                string gendre = dr["gendre"].ToString();
                if (gendre != "femelle")
                {
                    materialRadioButton4.Checked = true;
                }
                else
                {
                    materialRadioButton3.Checked = true;

                }

            }
            con.Close();



            con.Open();
            // SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand
            //   ("select img from etudiant where id_etudiant='" + id + "'", con));
            cmd.CommandText = "select img from etudiant where id_etudiant='" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            con.Close();


            Byte[] ap = (Byte[])(ds.Tables[0].Rows[0]["img"]);

            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            ms.Close();

        }

        private void metroGrid3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //c
            String id = metroGrid3.Rows[e.RowIndex].Cells["id_etudiant"].Value.ToString();
            globalid = int.Parse(metroGrid3.Rows[e.RowIndex].Cells["id_etudiant"].Value.ToString());

            con.Open();

            cmd = new SqlCommand("select nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre from etudiant where id_etudiant='" + id + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                materialSingleLineTextField5.Text = dr["nom"].ToString();
                materialSingleLineTextField3.Text = dr["tel"].ToString();
                materialSingleLineTextField2.Text = dr["numero_nas"].ToString();
                materialSingleLineTextField1.Text = dr["lieu_de_naiss"].ToString();
                //metroDateTime2.Value.Add(TimeSpan.Parse(dr["date_naissance"].ToString()));
                string gendre = dr["gendre"].ToString();
                if (gendre != "femelle")
                {
                    materialRadioButton4.Checked = true;
                }
                else
                {
                    materialRadioButton3.Checked = true;

                }

            }
            con.Close();



            con.Open();
            // SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand
            //   ("select img from etudiant where id_etudiant='" + id + "'", con));
            cmd.CommandText = "select img from etudiant where id_etudiant='" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            con.Close();


            Byte[] ap = (Byte[])(ds.Tables[0].Rows[0]["img"]);

            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            ms.Close();

        }

        private void metroGrid4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //o
            String id = metroGrid4.Rows[e.RowIndex].Cells["id_etudiant"].Value.ToString();
            globalid = int.Parse(metroGrid4.Rows[e.RowIndex].Cells["id_etudiant"].Value.ToString());

            con.Open();

            cmd = new SqlCommand("select nom,tel,numero_nas,date_naissance,lieu_de_naiss,gendre from etudiant where id_etudiant='" + id + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                materialSingleLineTextField5.Text = dr["nom"].ToString();
                materialSingleLineTextField3.Text = dr["tel"].ToString();
                materialSingleLineTextField2.Text = dr["numero_nas"].ToString();
                materialSingleLineTextField1.Text = dr["lieu_de_naiss"].ToString();
                //metroDateTime2.Value.Add(TimeSpan.Parse(dr["date_naissance"].ToString()));
                string gendre = dr["gendre"].ToString();
                if (gendre != "femelle")
                {
                    materialRadioButton4.Checked = true;
                }
                else
                {
                    materialRadioButton3.Checked = true;

                }

            }
            con.Close();



            con.Open();
            // SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand
            //   ("select img from etudiant where id_etudiant='" + id + "'", con));
            cmd.CommandText = "select img from etudiant where id_etudiant='" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cbd = new SqlCommandBuilder(da);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);
            con.Close();


            Byte[] ap = (Byte[])(ds.Tables[0].Rows[0]["img"]);

            MemoryStream ms = new MemoryStream(ap);
            pictureBox1.Image = Image.FromStream(ms);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            ms.Close();

        }
    }

    
}
