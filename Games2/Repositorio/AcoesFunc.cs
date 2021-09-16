using Games2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Games2.Repositorio
{
    public class AcoesFunc
    {
        Conexao con = new Conexao();
        MySqlCommand cmdFunc = new MySqlCommand();

        public void CadastrarFuncionario(Funcionario func)
        {
            string data_sistema = Convert.ToDateTime(func.funcDataNasc).ToString("yyyy-MM-dd");
            MySqlCommand cmdFunc = new MySqlCommand("insert into Funcionario value(@func_Cod,@func_Nome,@func_CPF,@func_RG,@func_DataNasc,@func_Endereco,@func_Cell,@func_Email,@func_Cargo)", con.ConectarBD());
            cmdFunc.Parameters.Add("func_Cod", MySqlDbType.VarChar).Value = func.funcCod;
            cmdFunc.Parameters.Add("func_Nome", MySqlDbType.VarChar).Value = func.funcNome;
            cmdFunc.Parameters.Add("func_CPF", MySqlDbType.VarChar).Value = func.funcCPF;
            cmdFunc.Parameters.Add("func_RG", MySqlDbType.VarChar).Value = func.funcRG;
            cmdFunc.Parameters.Add("func_DataNasc", MySqlDbType.DateTime).Value = data_sistema;
            cmdFunc.Parameters.Add("func_Endereco", MySqlDbType.VarChar).Value = func.funcEndereco;
            cmdFunc.Parameters.Add("func_Cell", MySqlDbType.VarChar).Value = func.funcCell;
            cmdFunc.Parameters.Add("func_Email", MySqlDbType.VarChar).Value = func.funcEmail;
            cmdFunc.Parameters.Add("func_Cargo", MySqlDbType.VarChar).Value = func.funcCargo;
            cmdFunc.ExecuteNonQuery();
            con.DesconectarBD();
        }

        public Funcionario ListarCodFuncionario(int cod)
        {
            var comandoFunc = String.Format("select * from Funcionario where func_Cod = {0}", cod);
            MySqlCommand cmdFunc = new MySqlCommand(comandoFunc, con.ConectarBD());
            var DadosCodFunc = cmdFunc.ExecuteReader();
            return ListarCodFunc(DadosCodFunc).FirstOrDefault();
        }

        public List<Funcionario> ListarCodFunc(MySqlDataReader dtFunc)
        {
            var AltAlFunc = new List<Funcionario>();
            while (dtFunc.Read())
            {
                var AlTempFunc = new Funcionario()
                {
                    funcCod = Int64.Parse(dtFunc["func_Cod"].ToString()),
                    funcNome = dtFunc["func_Nome"].ToString(),
                    funcCPF = dtFunc["func_CPF"].ToString(),
                    funcRG = dtFunc["func_RG"].ToString(),
                    funcDataNasc = DateTime.Parse(dtFunc["func_DataNasc"].ToString()),
                    funcEndereco = dtFunc["func_Endereco"].ToString(),
                    funcCell = dtFunc["func_Cell"].ToString(),
                    funcEmail = dtFunc["func_Email"].ToString(),
                    funcCargo = dtFunc["func_Cargo"].ToString(),


                };
                AltAlFunc.Add(AlTempFunc);
            }
            dtFunc.Close();
            return AltAlFunc;
        }

        public List<Funcionario> ListarFuncionario()
        {
            MySqlCommand cmdFunc = new MySqlCommand("select * from Funcionario", con.ConectarBD());
            var DadosFuncionario = cmdFunc.ExecuteReader();
            return ListarTodosFuncionario(DadosFuncionario);
        }

        public List<Funcionario> ListarTodosFuncionario(MySqlDataReader dtFunc)
        {
            var TodosFuncionario = new List<Funcionario>();
            while (dtFunc.Read())
            {
                var FuncTemp = new Funcionario()
                {
                    funcCod = int.Parse(dtFunc["func_Cod"].ToString()),
                    funcNome = dtFunc["func_Nome"].ToString(),
                    funcCPF = dtFunc["func_CPF"].ToString(),
                    funcRG = dtFunc["func_RG"].ToString(),
                    funcDataNasc = DateTime.Parse(dtFunc["func_DataNasc"].ToString()),
                    funcEndereco = dtFunc["func_Endereco"].ToString(),
                    funcCell = dtFunc["func_Cell"].ToString(),
                    funcEmail = dtFunc["func_Email"].ToString(),
                    funcCargo = dtFunc["func_Cargo"].ToString(),
                };
                TodosFuncionario.Add(FuncTemp);

            }
            dtFunc.Close();
            return TodosFuncionario;
        }
    }
}