using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace Siuntu_Grupes
{
    public partial class Form1 : Form
    {
        string TipeValue = "-1";
        string BusenaValue = "-1";
        string DataNuo;
        string DataIki;
        public static CredentialCache MyCash = new CredentialCache();
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            Uri uri = new Uri("http://bkisnew:83/Default.aspx");
            MyCash.Add(uri, "NTLM", new NetworkCredential("audriussi", "post*999"));
            

            dateTimePicker1.CustomFormat = "yyyy.MM.dd";
            dateTimePicker2.CustomFormat = "yyyy.MM.dd";
            DataNuo = dateTimePicker1.Value.ToShortDateString();
            DataIki = dateTimePicker2.Value.ToShortDateString();

            string[] tipe = new string[] { "Visi", "Lakštas K8", "Registruotos korespondencijos maišas",
                                           "Atskirasis daiktaraštis K9",
                                           "Bendrasis daiktaraštis K9",
                                           "Paprastos korespondencijos maišas",
                                           "Mišrus maišas",
                                           "Prenumeratos tara",
                                           "Neadresuotos reklamos tara"};

            string[] busena = new string[] { "Visos", "Neuždaryta", "Uždaryta",
                                           "Perduota", "Gauta", "Sutikrinta",
                                           "Dingusi", "Atmesta" };

            comboBox1.DataSource = tipe;
            comboBox2.DataSource = busena;
            comboBox1.SelectedIndex = 7;
            comboBox2.SelectedIndex = 2;
            dateTimePicker1.Value=DateTime.Parse("2020-05-01");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    TipeValue = "-1"; // Visi
                    break;
                case 1:
                    TipeValue = "1"; // Lakštas K8
                    break;
                case 2:
                    TipeValue = "2"; // Registruotos korespondencijos maišas
                    break;
                case 3:
                    TipeValue = "4"; // Atskirasis daiktaraštis K9
                    break;
                case 4:
                    TipeValue = "5"; // Bendrasis daiktaraštis K9
                    break;
                case 5:
                    TipeValue = "14"; // Paprastos korespondencijos maišas
                    break;
                case 6:
                    TipeValue = "15"; // Mišrus maišas
                    break;
                case 7:
                    TipeValue = "16"; // Prenumeratos tara
                    break;
                case 8:
                    TipeValue = "17"; // Neadresuotos reklamos tara
                    break;


            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    BusenaValue = "-1"; // Visos
                    break;
                case 1:
                    BusenaValue = "1"; // Neuždaryta
                    break;
                case 2:
                    BusenaValue = "2"; // Uždaryta
                    break;
                case 3:
                    BusenaValue = "3"; // Perduota
                    break;
                case 4:
                    BusenaValue = "4"; // Gauta
                    break;
                case 5:
                    BusenaValue = "5"; // Sutikrinta
                    break;
                case 6:
                    BusenaValue = "6"; // Dingusi
                    break;
                case 7:
                    BusenaValue = "7"; // Atmesta
                    break;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("TipeValue = "+TipeValue+"\n\rBusenaValue = " + BusenaValue+ "\n\rDataNuo = "+ DataNuo + "\n\rDataNuo = " + DataIki);
            Parse.HTML=Request.GetSiuntuGrupes(BusenaValue,TipeValue,DataNuo,DataIki);
            string[] AllUrlLink = Parse.GetAllID();
            dataGridView1.Columns.Add("SiuntosID", "Siuntos ID");
            DataGridViewRowCollection viewRowCollection = new DataGridViewRowCollection(dataGridView1);
            foreach (var item in AllUrlLink)
            {
                dataGridView1.Rows.Add(item);
                
            }
            Request.OpenGrupe(AllUrlLink);
            
           
        }

        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataNuo = dateTimePicker1.Value.ToShortDateString();
            DataIki = dateTimePicker2.Value.ToShortDateString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DataNuo = dateTimePicker1.Value.ToShortDateString();
            DataIki = dateTimePicker2.Value.ToShortDateString();
        }
    }
}