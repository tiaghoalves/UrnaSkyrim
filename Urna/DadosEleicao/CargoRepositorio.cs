using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DadosEleicao
{
    public class CargoRepositorio
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["URNA"].ConnectionString;

        public void Cadastrar(Cargo cargo)
        {
            if (BuscarPorNome(cargo.Nome) == false)
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    IDbCommand comando = connection.CreateCommand();

                    comando.CommandText = "INSERT INTO Cargo VALUES (@nome, @situacao)";

                    IDbDataParameter nome = comando.CreateParameter();
                    nome.ParameterName = "nome";
                    nome.Value = cargo.Nome;
                    IDbDataParameter param = comando.CreateParameter();
                    param.ParameterName = "situacao";
                    param.Value = cargo.Situacao.ToString().ToUpper();
                    connection.Open();
                    comando.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else
            {
                Console.WriteLine("Nome inserido já existe");
            }
       }


        public bool BuscarPorNome(string nome)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IDbCommand comando = connection.CreateCommand();

                comando.CommandText = "SELECT * FROM Cargo";

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();

                IDataReader reader = comando.ExecuteReader();
                if(reader["Nome"].Equals(nome))
                {
                    return false;
                }else{
                    return true;
                }

            }
        }

        public void Editar(Cargo cargo)
        {
            using (TransactionScope transacao = new TransactionScope())
            using (IDbConnection conection = new SqlConnection(connectionString))
            {
                IDbCommand comando = conection.CreateCommand();
                comando.CommandText = "UPDATE Cargo SET Nome = @nome , Situacao = @situacao WHERE IDCargo = @idcargo";
                comando.AddParameter("nome", cargo.Nome);
                comando.AddParameter("situacao", cargo.Situacao.ToString().ToUpper());

                conection.Open();
                comando.ExecuteNonQuery();
                transacao.Complete();

                conection.Close();

            }
        }
    }
}
