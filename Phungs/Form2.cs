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
    public partial class Form2 : Form
    {

        Dao dao = new Dao();
        string bancoDados = "Phungs";
        string tabela = "Cursos";

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                dao.Conecte(bancoDados, tabela);
                MessageBox.Show("Conectado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelcer conexão com o banco de dados. Tente novamente masi tarde.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string esportes = checkBox1.Text;
            string culinaria = checkBox2.Text;
            string games = checkBox3.Text;
            string informatica = checkBox4.Text;
            string economia = checkBox5.Text;
            string ecologia = checkBox6.Text;

            if (checkBox1.Checked == true)
            {
                dao.InserePrefs(esportes, culinaria, games, informatica, economia, ecologia);
            }
        }

    }
}
