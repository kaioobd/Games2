using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Games2.Repositorio
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("Server=localhost;Database=Gamesdb;user=root;pwd=123456");

        public static string msg;

        public MySqlConnection ConectarBD()
        {
            try
            {
                cn.Open();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao conectar" + erro.Message;
            }
            return cn;
        }

        public MySqlConnection DesconectarBD()
        {
            try
            {
                cn.Close();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao desconectar" + erro.Message;
            }
            return cn;
        }
    }
}