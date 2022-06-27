using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;



namespace Data_Generator
{
    public class Campos
    {
        public int id;
        public string nome;
        public string ender;
        public decimal sal;
    }

    public class Dao
    {
        public Dao()
        {
        }



        public Campos campos = new Campos();



        public MySqlConnection minhaConexao;



        public string usuarioBd = "root";
        public string senhaBD = "Jv410551";
        public string servidor = "localhost";
        string bancoDados;
        string tabela;



        public void Conecte(string BancoDados, string Tabela)
        {
            bancoDados = BancoDados;
            tabela = Tabela;
            minhaConexao = new MySqlConnection("server=" + servidor + "; database=" + bancoDados +
            "; uid=" + usuarioBd + "; password=" + senhaBD);
        }
        void Abrir()
        {
            minhaConexao.Open();
        }
        void Fechar()
        {
            minhaConexao.Close();
        }
        public void PreenchaTabela(System.Windows.Forms.DataGridView dataGridView)
        {
            Abrir();



            MySqlDataAdapter meuAdapter = new MySqlDataAdapter("Select * from " + tabela, minhaConexao);
            System.Data.DataSet dataSet = new System.Data.DataSet();
            dataSet.Clear();
            meuAdapter.Fill(dataSet, tabela);
            dataGridView.DataSource = dataSet;
            dataGridView.DataMember = tabela;



            Fechar();
        }
        public void Insere(string nome, string sexo, string idade, string email)
        {
            Abrir();



            MySqlCommand comando = new MySqlCommand("insert into " + tabela
            + "(Nome, Sexo, Idade, Email) values(@nome, @sexo, @idade, @email)", minhaConexao);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@sexo", sexo);
            comando.Parameters.AddWithValue("@idade", idade);
            comando.Parameters.AddWithValue("@email", email);
            comando.ExecuteNonQuery();

            Fechar();
        }

        public void InsereCurso(string nome, string tipo, string iniDate, string finalDate)
        {
            Abrir();



            MySqlCommand comando = new MySqlCommand("insert into " + tabela
            + "(NomeCurso, Tipo, DataDeInicio, DataDeTermino) values(@nome, @tipo, @inicio, @final)", minhaConexao);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@inicio", iniDate);
            comando.Parameters.AddWithValue("@final", finalDate);
            comando.ExecuteNonQuery();

            Fechar();
        }


        public void InserePrefs(string esportes, string culinaria, string games, string informatica, string economia, string ecologia)
        {
            Abrir();

            MySqlCommand comando = new MySqlCommand("insert into " + tabela
            + "(Esportes, Culinaria, Games, Informatica, Economia, Ecologia) values(@esportes, @culinaria, @games, @informatica, @economia, @ecologia)", minhaConexao);
            comando.Parameters.AddWithValue("@esportes", esportes);
            comando.Parameters.AddWithValue("@culinaria", culinaria);
            comando.Parameters.AddWithValue("@games", games);
            comando.Parameters.AddWithValue("@informatica", informatica);
            comando.Parameters.AddWithValue("@economia", economia);
            comando.Parameters.AddWithValue("@ecologia", ecologia);
            comando.ExecuteNonQuery();

            Fechar();
        }
    }

}