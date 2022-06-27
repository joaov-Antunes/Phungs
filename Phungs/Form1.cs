using Data_Generator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phungs
{

    public partial class Form1 : Form
    {

        Dao dao = new Dao();
        string bancoDados = "Phungs";
        string tabela = "Aluno";

        Form form = new Form2();
        Form3 form3 = new Form3();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Maculino");
            comboBox1.Items.Add("Feminino");

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
            string sexo = comboBox1.Text;
            string idade = textBox3.Text;
            string email = textBox2.Text;
            dao.Insere(nome, sexo, idade, email);
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                form.Show();
            } else {
                MessageBox.Show("Preencha os campos antes de prosseguir.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form.Hide();
            form3.Show();
        }
    }
}