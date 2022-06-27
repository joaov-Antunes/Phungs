using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Generator;

namespace Phungs
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        Dao dao = new Dao();
        string bancoDados = "Phungs";
        string tabela = "CadastroCurso";

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                dao.Conecte(bancoDados, tabela);
                MessageBox.Show("Conectado");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelcer conexão com o banco de dados. Tente novamente masi tarde.");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nome = textBox1.Text;
            string tipo = textBox2.Text;
            string iniDate = textBox3.Text;
            string finalDate = textBox4.Text;
            dao.InsereCurso(nome, tipo, iniDate, finalDate);
        }
    }
}
