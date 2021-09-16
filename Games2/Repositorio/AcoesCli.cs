using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Games2.Models;
using MySql.Data.MySqlClient;

namespace Games2.Repositorio
{
    public class AcoesCli
    {
        Conexao con = new Conexao();
        MySqlCommand cmdCli = new MySqlCommand();

        public void CadastrarCliente(Cliente client)
        {
            string data_sistema = Convert.ToDateTime(client.cliDataNasc).ToString("yyyy-MM-dd");
            MySqlCommand cmdCli = new MySqlCommand("insert into Cliente values(@cli_Cod,@cli_Nome,@cli_CPF,@cli_DataNasc,@cli_Email,@cli_Cell,@cli_Endereco)", con.ConectarBD());
            cmdCli.Parameters.Add("@cli_Cod", MySqlDbType.VarChar).Value = client.cliCod;
            cmdCli.Parameters.Add("@cli_Nome", MySqlDbType.VarChar).Value = client.cliNome;
            cmdCli.Parameters.Add("@cli_CPF", MySqlDbType.VarChar).Value = client.cliCPF;
            cmdCli.Parameters.Add("@cli_DataNasc", MySqlDbType.DateTime).Value = data_sistema;
            cmdCli.Parameters.Add("@cli_Email", MySqlDbType.VarChar).Value = client.cliEmail;
            cmdCli.Parameters.Add("@cli_Cell", MySqlDbType.VarChar).Value = client.cliCell;
            cmdCli.Parameters.Add("@cli_Endereco", MySqlDbType.VarChar).Value = client.cliEndereco;
            cmdCli.ExecuteNonQuery();
            con.DesconectarBD();
        }

        public Cliente ListarCodCliente(int cod)
        {
            var comandoCli = String.Format("select * from Cliente where cli_Cod = {0}", cod);
            MySqlCommand cmdCli = new MySqlCommand(comandoCli, con.ConectarBD());
            var DadosCodCli = cmdCli.ExecuteReader();
            return ListarCodCli(DadosCodCli).FirstOrDefault();
        }

        public List<Cliente> ListarCodCli(MySqlDataReader dtCli)
        {
            var AltAlCli = new List<Cliente>();
            while (dtCli.Read())
            {
                var AlTempCli = new Cliente()
                {
                    cliCod = Int64.Parse(dtCli["cli_Cod"].ToString()),
                    cliNome = dtCli["cli_Nome"].ToString(),
                    cliCPF = dtCli["cli_CPF"].ToString(),
                    cliDataNasc = DateTime.Parse(dtCli["cli_DataNasc"].ToString()),
                    cliEmail = dtCli["cli_Email"].ToString(),
                    cliCell = dtCli["cli_Cell"].ToString(),
                    cliEndereco = dtCli["cli_Endereco"].ToString()

                };
                AltAlCli.Add(AlTempCli);
            }
            dtCli.Close();
            return AltAlCli;
        }

        public List<Cliente> ListarCliente()
        {
            MySqlCommand cmdCli = new MySqlCommand("Select * from Cliente", con.ConectarBD());
            var DadosCliente = cmdCli.ExecuteReader();
            return ListarTodosCliente(DadosCliente);
        }

        public List<Cliente> ListarTodosCliente(MySqlDataReader dtCli)
        {
            var TodosCli = new List<Cliente>();
            while (dtCli.Read())
            {
                var CliTemp = new Cliente()
                {
                    cliCod = Int64.Parse(dtCli["cli_Cod"].ToString()),
                    cliNome = dtCli["cli_Nome"].ToString(),
                    cliCPF = dtCli["cli_CPF"].ToString(),
                    cliDataNasc = DateTime.Parse(dtCli["cli_DataNasc"].ToString()),
                    cliEmail = dtCli["cli_Email"].ToString(),
                    cliCell = dtCli["cli_Cell"].ToString(),
                    cliEndereco = dtCli["cli_Endereco"].ToString()

                };
                TodosCli.Add(CliTemp);
            }
            dtCli.Close();
            return TodosCli;
        }

    }
}