using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web;
using MySql.Data.MySqlClient;

namespace GeradorDeClasses
{
    public class Periferica
    {
        private string ColunaIdentificador;
        public string cColunaIdentificador
        {
            get { return ColunaIdentificador; }
            set { ColunaIdentificador = value; }
        }

        public List<string> BuscarColunasTabela(string conexao, string tabela)
        {
            try
            {


                List<string> lista = new List<string>();
                DataTable schemaTable;
                DataTable tbFK = new DataTable();
                bool usado = false;
                //SqlDataAdapter adp = new SqlDataAdapter(
                //Dictionary<string, Type> dic = new Dictionary<string, Type>();
                //Dictionary<int, Dictionary<string, Type>> dicPai = new Dictionary<int, Dictionary<string, Type>>();
                string sql = "select * from " + tabela + " LIMIT 1";
                string sql2 = @"select * from INFORMATION_SCHEMA.COLUMNS where table_name='" + tabela + "'";
                MySqlConnection conn = new MySqlConnection(conexao);
                MySqlCommand comand;
                MySqlCommand comandFK;
                conn.Open();
                comand = new MySqlCommand(sql, conn);
                comandFK = new MySqlCommand(sql2, conn);
                MySqlDataAdapter adpFK = new MySqlDataAdapter(comandFK);
                adpFK.Fill(tbFK);
                MySqlDataReader reader = comand.ExecuteReader();
                schemaTable = reader.GetSchemaTable();

                //For each field in the table...
                //foreach (DataRow myField in schemaTable.Rows)
                foreach (DataRow myField in tbFK.Rows)
                {
                    usado = false;
                    if (myField["COLUMN_KEY"].ToString().ToUpper() == "PRI")
                    //if (myField["IsKey"].ToString().ToUpper() == "true")
                    {
                        cColunaIdentificador = myField[3].ToString();
                        lista.Add("Identificador;" + TratarTipos(myField["DATA_TYPE"].ToString().Replace("System.", "")) + ";Identificador");
                        //lista.Add("Identificador;" + TratarTipos(myField["DataType"].ToString().Replace("System.", "")));
                    }
                    else
                    {
                        //if (tbFK != null && tbFK.Rows.Count > 0)
                        //    for (int i = 0; i < tbFK.Rows.Count; i++)
                        //    {
                        //if (myField[0].ToString() == tbFK.Rows[i]["tabpaicol"].ToString())
                        {
                            lista.Add(myField[3].ToString() + ";" + TratarTipos(myField["DATA_TYPE"].ToString().Replace("System.", "")) + ";" + RetiraLixoNomeColuna(myField["COLUMN_NAME"].ToString()));
                            usado = true;
                        }
                        //lista.Add(myField[0].ToString() + ";" + TratarTipos(myField["DataType"].ToString().Replace("System.", "")));
                        //}

                        //if (!usado)
                        //    //lista.Add(myField[0].ToString() + ";" + TratarTipos(myField["COLUMN_TYPE"].ToString().Replace("System.", "")));
                        //    lista.Add(myField[3].ToString() + ";" + TratarTipos(myField["DATA_TYPE"].ToString().Replace("System.", "")));
                    }
                }

                conn.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao montar dados." + Environment.NewLine +
                "Favor verificar dados informados nos campos da tela." + Environment.NewLine +
                "Erro: " + ex.Message.ToString() + Environment.NewLine +
                "Valide o nome da tabela, string de conexão, nome do projeto, etc." + Environment.NewLine +
                "Caso não encontre o erro, contate - Célio Franca - cfranca@attps.com.br.");
            }
        }

        public string RetiraLixoNomeTabela(string Tabela)
        {
            string TabelaAux = string.Empty;
            string TabelaAux2 = string.Empty;
            if (Tabela.IndexOf("_") != -1)
            {
                TabelaAux = Tabela.Substring(0, Tabela.IndexOf("_"));
                TabelaAux2 = Tabela.Substring(Tabela.IndexOf("_") + 1, Tabela.Length - TabelaAux.Length - 1);
                Tabela = String.Empty;
                if (TabelaAux == "tab")
                {
                    for (int i = 0; i < TabelaAux2.Length; i++)
                    {
                            if (i == 0)
                                Tabela = Tabela + TabelaAux2[i].ToString().ToUpper();
                            else
                                Tabela = Tabela + TabelaAux2[i].ToString();
                    }
                }

               
            }

            else
            {
                TabelaAux2 = Tabela;
                Tabela = String.Empty;
                for (int i = 0; i < TabelaAux.Length; i++)
                {
                    if (i == 0)
                        Tabela = Tabela + TabelaAux2[i].ToString().ToUpper();
                    else
                        Tabela = Tabela + TabelaAux2[i].ToString();
                }
            }
            return Tabela;
        }

        public string RetiraLixoNomeColuna(string Coluna)
        {
            string ColunaAux = string.Empty;
            string ColunaAux2 = string.Empty;
            if (Coluna.IndexOf("_") != -1)
            {
                ColunaAux = Coluna.Substring(0, Coluna.IndexOf("_"));
                ColunaAux2 = Coluna.Substring(Coluna.IndexOf("_") + 1, Coluna.Length - ColunaAux.Length - 1);
                Coluna = String.Empty;
                if (ColunaAux2 == "cd")
                {
                    ColunaAux = "Identificador" + ColunaAux;
                    for (int i = 0; i < ColunaAux.Length; i++)
                    {

                        if (ColunaAux2 == "cd")
                            if (i == 13)
                                Coluna = Coluna + ColunaAux[i].ToString().ToUpper();
                            else
                                Coluna = Coluna + ColunaAux[i].ToString();
                    }
                }
                
                else if (ColunaAux2 == "dt")
                {
                    ColunaAux = "Data" + ColunaAux;
                    for (int i = 0; i < ColunaAux.Length; i++)
                    {
                        if (ColunaAux2 == "dt")
                            if (i == 4)
                                Coluna = Coluna + ColunaAux[i].ToString().ToUpper();
                            else
                                Coluna = Coluna + ColunaAux[i].ToString();
                    }
                }

                else if (ColunaAux2 == "obs")
                {
                    ColunaAux = "Observacao" + ColunaAux;
                    for (int i = 0; i < ColunaAux.Length; i++)
                    {
                        if (i == 10)
                            Coluna = Coluna + ColunaAux[i].ToString().ToUpper();
                        else
                            Coluna = Coluna + ColunaAux[i].ToString();
                    }
                }

                else
                {
                    int index = ColunaAux.Length;
                    ColunaAux = ColunaAux + ColunaAux2;
                    for (int i = 0; i < ColunaAux.Length; i++)
                    {
                        if (i == 0 || i == index)
                            Coluna = Coluna + ColunaAux[i].ToString().ToUpper();
                        else
                            Coluna = Coluna + ColunaAux[i].ToString();
                    }
                }

            }

            else
            {
                ColunaAux = Coluna;
                Coluna = String.Empty;
                for (int i = 0; i < ColunaAux.Length; i++)
                {
                    if (i == 0)
                        Coluna = Coluna + ColunaAux[i].ToString().ToUpper();
                    else
                        Coluna = Coluna + ColunaAux[i].ToString();
                }
            }



            return Coluna;
        }

        public string TratarTipos(string tipo)
        {
            string numeros = "0123456789";

            for (int i = 0; i < numeros.Length; i++)
            {
                if (tipo.IndexOf(numeros[i].ToString()) != -1)
                    tipo = tipo.Replace(numeros[i].ToString(), "");
            }

            tipo = tipo.Trim();

            switch (tipo.ToUpper())
            {
                case "INT":
                    tipo = "int";
                    break;
                case "DATETIME":
                    tipo = "DateTime";
                    break;
                case "STRING":
                    tipo = "string";
                    break;
                case "VARCHAR":
                    tipo = "string";
                    break;
                case "CHAR":
                    tipo = "string";
                    break;
                case "DOUBLE":
                    tipo = "double";
                    break;
                case "BOOL":
                    tipo = "bool";
                    break;
                case "BYTE":
                    tipo = "byte";
                    break;
                case "DECIMAL":
                    tipo = "decimal";
                    break;
            }

            return tipo;
        }

        public string TratarTiposVoltaOriginal(string tipo)
        {
            //string numeros = "0123456789";

            //for (int i = 0; i < numeros.Length; i++)
            //{
            //    if (tipo.IndexOf(numeros[i].ToString()) != -1)
            //        tipo = tipo.Replace(numeros[i].ToString(), "");
            //}

            tipo = tipo.Trim();

            switch (tipo.ToUpper())
            {
                case "INT":
                    tipo = "Int32";
                    break;
                case "DATETIME":
                    tipo = "DateTime";
                    break;
                case "STRING":
                    tipo = "String";
                    break;
                case "DOUBLE":
                    tipo = "Double";
                    break;
                case "BOOL":
                    tipo = "Bool";
                    break;
                case "BYTE":
                    tipo = "Byte";
                    break;
                case "DECIMAL":
                    tipo = "Decimal";
                    break;
            }

            return tipo;
        }
        
        public string ColunaAux { get; set; }

        public string ColunaAux2 { get; set; }

        public DataTable BuscaTabelasBanco(string conexao, string pNomeBanco)
        {

            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(conexao);

                StringBuilder Comand_SQL = new StringBuilder();
                Comand_SQL.AppendLine("select table_name  from INFORMATION_SCHEMA.`TABLES` where table_schema = @pNomeBanco order by TABLE_NAME ");

                MySqlCommand com = new MySqlCommand(Comand_SQL.ToString(), Conexao);

                if (!String.IsNullOrEmpty(pNomeBanco))
                {
                    com.Parameters.Add(new MySqlParameter("@pNomeBanco", pNomeBanco));
                }


                Conexao.Open();
                dt.Load(com.ExecuteReader());
                com.ExecuteReader();
                Conexao.Close();
                return dt;
            }
            catch (Exception e)
            {
                
                throw e;
            }   
           
        }
    }
}
