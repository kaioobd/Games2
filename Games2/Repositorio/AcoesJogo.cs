using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Games2.Models;


namespace Games2.Repositorio
{
    public class AcoesJogo
    {
        Conexao con = new Conexao();
        MySqlCommand cmdJogo = new MySqlCommand();

        public void CadastrarJogo(Jogo jogo)
        {
            MySqlCommand cmdJogo = new MySqlCommand("insert into Jogo values(@jogo_Cod,@jogo_Nome,@jogo_Versao,@jogo_Dev,@jogo_Genero,@jogo_FaixaEtaria,@jogo_Plataf,@jogo_AnoLanc,@jogo_Sinopse)", con.ConectarBD());
            cmdJogo.Parameters.Add("jogo_Cod", MySqlDbType.VarChar).Value = jogo.jogoCod;
            cmdJogo.Parameters.Add("jogo_Nome", MySqlDbType.VarChar).Value = jogo.jogoNome;
            cmdJogo.Parameters.Add("jogo_Versao", MySqlDbType.VarChar).Value = jogo.jogoVersao;
            cmdJogo.Parameters.Add("jogo_Dev", MySqlDbType.VarChar).Value = jogo.jogoDev;
            cmdJogo.Parameters.Add("jogo_Genero", MySqlDbType.VarChar).Value = jogo.jogoGenero;
            cmdJogo.Parameters.Add("jogo_FaixaEtaria", MySqlDbType.VarChar).Value = jogo.jogoFaixaEtaria;
            cmdJogo.Parameters.Add("jogo_Plataf", MySqlDbType.VarChar).Value = jogo.jogoPlataf;
            cmdJogo.Parameters.Add("jogo_AnoLanc", MySqlDbType.VarChar).Value = jogo.jogoAnoLanc;
            cmdJogo.Parameters.Add("Jogo_Sinopse", MySqlDbType.VarChar).Value = jogo.jogoSinopse;
            cmdJogo.ExecuteNonQuery();
            con.DesconectarBD();
        }

        public Jogo ListarCodFuncionario(int cod)
        {
            var comandoJogo = String.Format("select * from Jogo where jogo_Cod = {0}", cod);
            MySqlCommand cmdJogo = new MySqlCommand(comandoJogo, con.ConectarBD());
            var DadosCodJogo = cmdJogo.ExecuteReader();
            return ListarCodJoguinho(DadosCodJogo).FirstOrDefault();
        }

        public List<Jogo> ListarCodJoguinho(MySqlDataReader dtJogo)
        {
            var AltAlJogo = new List<Jogo>();
            while (dtJogo.Read())
            {
                var AlTempJogo = new Jogo()
                {
                    jogoCod = Int64.Parse(dtJogo["func_Cod"].ToString()),
                    jogoNome = dtJogo["jogo_Nome"].ToString(),
                    jogoVersao = dtJogo["jogo_Versao"].ToString(),
                    jogoDev = dtJogo["jogo_Dev"].ToString(),
                    jogoGenero = dtJogo["jogo_Genero"].ToString(),
                    jogoFaixaEtaria = dtJogo["jogo_FaixaEtaria"].ToString(),
                    jogoPlataf = dtJogo["jogo_Plataf"].ToString(),
                    jogoAnoLanc = Int64.Parse(dtJogo["jogo_AnoLanc"].ToString()),
                    jogoSinopse = dtJogo["jogo_Sinopse"].ToString()
                };
                AltAlJogo.Add(AlTempJogo);
            }
            dtJogo.Close();
            return AltAlJogo;
        }

        public List<Jogo> ListarJogo()
        {
            MySqlCommand cmdJogo = new MySqlCommand("select * from Jogo", con.ConectarBD());
            var DadosJogo = cmdJogo.ExecuteReader();
            return ListarTodosJogo(DadosJogo);
        }

        public List<Jogo> ListarTodosJogo(MySqlDataReader dtJogo)
        {
            var TodosJogo = new List<Jogo>();
            while(dtJogo.Read())
            {
                var JogoTemp = new Jogo()
                {
                    jogoCod = Int64.Parse(dtJogo["jogo_Cod"].ToString()),
                    jogoNome = dtJogo["jogo_Nome"].ToString(),
                    jogoVersao = dtJogo["jogo_Versao"].ToString(),
                    jogoDev = dtJogo["jogo_Dev"].ToString(),
                    jogoGenero = dtJogo["jogo_Genero"].ToString(),
                    jogoFaixaEtaria = dtJogo["jogo_FaixaEtaria"].ToString(),
                    jogoPlataf = dtJogo["jogo_Plataf"].ToString(),
                    jogoAnoLanc = Int64.Parse(dtJogo["jogo_AnoLanc"].ToString()),
                    jogoSinopse = dtJogo["jogo_Sinopse"].ToString()
                };
                TodosJogo.Add(JogoTemp);
            }
            dtJogo.Close();
            return TodosJogo;
        }


    }
}