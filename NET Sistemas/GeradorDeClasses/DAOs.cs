using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeradorDeClasses
{
    public class DAOs
    {
        Periferica peri = new Periferica();
        public string GerarClasseDAOs(string conexao, string tabela, string nomeProjeto)
        {
            string[] item;// = new string[,];
            string nomeColuna;
            string tipoColuna;
            string classe = string.Empty;
            List<string> list = peri.BuscarColunasTabela(conexao, tabela);
            string tabelaSemLixo = peri.RetiraLixoNomeTabela(tabela);
            string colunaIdentificador = peri.cColunaIdentificador;

            classe = @"using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using " + nomeProjeto + @".DTO;
using " + nomeProjeto + @".Exceptions;
using AttPsFw.Utils.Exceptions;// dll da framework da att


namespace " + nomeProjeto + @".DAO
{
    public class " + tabelaSemLixo + @"DAO 
    {
        #region Atributos

        private CriaConnectionString getConnection = new CriaConnectionString();
        private string ConnectionString = string.Empty;
        string StrCon;

        #endregion

        #region Construtor

        public " + tabelaSemLixo + @"DAO()
        {
            StrCon = getConnection.GetConnectionStringProd();
        }

        #endregion

        #region Metodos

        #region Seleção

        public DataTable Selecionar" + tabelaSemLixo + @"(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine("" SELECT                    "");
";
            for (int i = 0; i < list.Count; i++)
            {
                item = list[i].ToString().Split(';');
                nomeColuna = item[0].ToString();
                tipoColuna = item[1].ToString();

                if (nomeColuna.ToUpper() == "IDENTIFICADOR")
                    nomeColuna = colunaIdentificador;

                if (i + 1 < list.Count)
                    classe = classe + @"
	            vSQLCommand.AppendLine("" " + nomeColuna.ToUpper() + ",\");";
                else
                    classe = classe + @"
	            vSQLCommand.AppendLine("" " + nomeColuna.ToUpper() + "\");";
            }

            classe = classe + @"

                vSQLCommand.AppendLine("" FROM " + tabela.ToUpper() + @""");";

            classe = classe + @"
     
                vSQLCommand.AppendFormat("" WHERE (1=1) " + colunaIdentificador + " \");";

                // Recupera dados
            for (int i = 0; i < list.Count; i++)
            {
                item = list[i].ToString().Split(';');
                nomeColuna = item[0].ToString();
                tipoColuna = item[1].ToString();

                if (nomeColuna.ToUpper() == "IDENTIFICADOR")
                    nomeColuna = colunaIdentificador;

                if (i + 1 < list.Count)

                    if (tipoColuna == "Int32" || tipoColuna == "int")
                    {
                        classe = classe + @"
	            
                if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(int))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" = @" + nomeColuna + @" "");
                    }";
                    }

                    else if (tipoColuna == "DateTime" || tipoColuna == "dateTime")
                    {
                        classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(DateTime))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" = @" + nomeColuna + @" "");
                    }";
                    }

                    else if (tipoColuna == "String" || tipoColuna == "string")
                    {
                        classe = classe + @"
	            if (!String.IsNullOrEmpty(p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" = @" + nomeColuna + @" "");
                    }";
                    }

                    else if (tipoColuna == "Double" || tipoColuna == "double")
                    {
                        classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(double))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" = @" + nomeColuna + @" "");
                    }";
                    }

                    else if (tipoColuna == "float" || tipoColuna == "Float")
                    {
                        classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(float))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" = @" + nomeColuna + @" "");
                    }";
                    }
            }
                
                    classe = classe + @"
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);";


                    for (int i = 0; i < list.Count; i++)
                    {
                        item = list[i].ToString().Split(';');
                        nomeColuna = item[0].ToString();
                        tipoColuna = item[1].ToString();

                        if (nomeColuna.ToUpper() == "IDENTIFICADOR")
                            nomeColuna = colunaIdentificador;

                        if (i + 1 < list.Count)

                            if (tipoColuna == "Int32" || tipoColuna == "int")
                            {
                                classe = classe + @"

	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));
                    }";
                            }

                            else if (tipoColuna == "DateTime" || tipoColuna == "dateTime")
                            {
                                classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(DateTime))
                    {
                        com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));
                    }";
                            }

                            else if (tipoColuna == "String" || tipoColuna == "string")
                            {
                                classe = classe + @"
	            if (!String.IsNullOrEmpty(p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"))
                    {
                         com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));
                    }";
                            }

                            else if (tipoColuna == "Double" || tipoColuna == "double")
                            {
                                classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(double))
                    {
                         com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));
                    }";
                            }

                            else if (tipoColuna == "float" || tipoColuna == "Float")
                            {
                                classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(float))
                    {
                         com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));
                    }";
                            }
                    }

classe = classe + @"     
                       
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
    
        public DataTable Selecionar" + tabelaSemLixo + @"Pesquisar(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine("" SELECT                    "");
";
for (int i = 0; i < list.Count; i++)
{
    item = list[i].ToString().Split(';');
    nomeColuna = item[0].ToString();
    tipoColuna = item[1].ToString();

    if (nomeColuna.ToUpper() == "IDENTIFICADOR")
        nomeColuna = colunaIdentificador;

    if (i + 1 < list.Count)
        classe = classe + @"
	            vSQLCommand.AppendLine("" " + nomeColuna.ToUpper() + ",\");";
    else
        classe = classe + @"
	            vSQLCommand.AppendLine("" " + nomeColuna.ToUpper() + "\");";
}

classe = classe + @"

                vSQLCommand.AppendLine("" FROM " + tabela.ToUpper() + @""");";

classe = classe + @"
     
                vSQLCommand.AppendFormat("" WHERE (1=1) " + colunaIdentificador + " \");";

// Recupera dados
for (int i = 0; i < list.Count; i++)
{
    item = list[i].ToString().Split(';');
    nomeColuna = item[0].ToString();
    tipoColuna = item[1].ToString();

    if (nomeColuna.ToUpper() == "IDENTIFICADOR")
        nomeColuna = colunaIdentificador;

    if (i + 1 < list.Count)

        if (tipoColuna == "Int32" || tipoColuna == "int")
        {
            classe = classe + @"
	            
                if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(int))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" = @" + nomeColuna + @" "");
                    }";
        }

        else if (tipoColuna == "DateTime" || tipoColuna == "dateTime")
        {
            classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(DateTime))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" = @" + nomeColuna + @" "");
                    }";
        }

        else if (tipoColuna == "String" || tipoColuna == "string")
        {
            classe = classe + @"
	            if (!String.IsNullOrEmpty(p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" like @" + nomeColuna + @" "");
                    }";
        }

        else if (tipoColuna == "Double" || tipoColuna == "double")
        {
            classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(double))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" = @" + nomeColuna + @" "");
                    }";
        }

        else if (tipoColuna == "float" || tipoColuna == "Float")
        {
            classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(float))
                    {
                        vSQLCommand.AppendLine(""and " + nomeColuna + @" = @" + nomeColuna + @" "");
                    }";
        }
}

classe = classe + @"
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);";


for (int i = 0; i < list.Count; i++)
{
    item = list[i].ToString().Split(';');
    nomeColuna = item[0].ToString();
    tipoColuna = item[1].ToString();

    if (nomeColuna.ToUpper() == "IDENTIFICADOR")
        nomeColuna = colunaIdentificador;

    if (i + 1 < list.Count)

        if (tipoColuna == "Int32" || tipoColuna == "int")
        {
            classe = classe + @"

	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));
                    }";
        }

        else if (tipoColuna == "DateTime" || tipoColuna == "dateTime")
        {
            classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(DateTime))
                    {
                        com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));
                    }";
        }

        else if (tipoColuna == "String" || tipoColuna == "string")
        {
            classe = classe + @"
	            if (!String.IsNullOrEmpty(p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"))
                    {
                         com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", ""%"" + p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @" + ""%""));
                    }";
        }

        else if (tipoColuna == "Double" || tipoColuna == "double")
        {
            classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(double))
                    {
                         com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));
                    }";
        }

        else if (tipoColuna == "float" || tipoColuna == "Float")
        {
            classe = classe + @"
	            if (p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"!= default(float))
                    {
                         com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));
                    }";
        }
}

classe = classe + @"     
                       
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

        #endregion

        #region Inserção

        public Boolean Insere" + tabelaSemLixo + @"(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO)
        {
            try
            {
            MySqlConnection Conexao = new MySqlConnection(StrCon);
            StringBuilder vSQLCommand = new StringBuilder();
            vSQLCommand.AppendLine(""INSERT INTO " + tabela + @"("");";
            for (int i = 0; i < list.Count; i++)
            {
                item = list[i].ToString().Split(';');
                nomeColuna = item[0].ToString();
                tipoColuna = item[1].ToString();

                if (nomeColuna.ToUpper() == "IDENTIFICADOR")
                    nomeColuna = colunaIdentificador;

                else if (i + 1 < list.Count)
                {

                    if (nomeColuna.ToUpper() != "IDENTIFICADOR")
                        classe = classe + @"
	        vSQLCommand.AppendLine(""" + nomeColuna.ToUpper() + ",\");";                            

                }
                else
                {
                    if (nomeColuna.ToUpper() != "IDENTIFICADOR")
                        classe = classe + @"
	        vSQLCommand.AppendLine(""" + nomeColuna.ToUpper() + ") values (\");";
                    else
                        classe = classe + @"
            vSQLCommand.AppendLine("") values (";

                    for (int x = 0; x < list.Count; x++)
                    {
                        item = list[x].ToString().Split(';');
                        nomeColuna = item[0].ToString();
                        tipoColuna = item[1].ToString();
                        //classe = classe + "{" + x + "},";
                        //if (x + 1 == list.Count)
                        //    classe = classe + "{" + x + "})  \");";
                        if (item[2].ToString().ToUpper() == "IDENTIFICADOR")
                        {
                            classe = classe + @"
            //com.Parameters.Add(new MySqlParameter(""@" + colunaIdentificador + @""", p" + tabelaSemLixo + @"DTO.Identificador));";
                        }
                        else
                        {
                            if (x + 1 < list.Count)
                                classe = classe + @"
            vSQLCommand.AppendLine("" @" + nomeColuna + ",\");";
                            else if (x + 1 == list.Count)
                                classe = classe + @"
            vSQLCommand.AppendLine("" @" + nomeColuna + ")\");";
                        }

                    }


                }

            }
                
            classe = classe + @"
            MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);";

            for (int x = 0; x < list.Count; x++)
            {
                item = list[x].ToString().Split(';');
                nomeColuna = item[0].ToString();
                tipoColuna = item[1].ToString();
                //na acrescenta a coluna identificador
                if (item[2].ToString().ToUpper() == "IDENTIFICADOR")
                {
                    classe = classe + @"
            //com.Parameters.Add(new MySqlParameter(""@" + colunaIdentificador + @""", p" + tabelaSemLixo + @"DTO.Identificador));";
                }
                else
                {
                    //classe = classe + "{" + x + "}) where " + colunaIdentificador + " = {" + x + "}\");";
                    classe = classe + @"
                                            
            com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));";

                    //else
                    //    classe = classe + "{" + x + "},";
                }
            }

            classe = classe + @" 
            Conexao.Open();
            //dt.Load(com.ExecuteReader());
            com.ExecuteReader();
            Conexao.Close();

            return true;
        }
        catch (Exception e)
        {

            throw e;
        }
    }


        #endregion

        #region Atualização

        

        public Boolean Altera" + tabelaSemLixo + @"(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO)
        {
            try
            {
                 DataTable dt = new DataTable();
                 MySqlConnection Conexao = new MySqlConnection(StrCon);
                 StringBuilder vSQLCommand = new StringBuilder();
                 vSQLCommand.AppendLine(""UPDATE " + tabela + @" SET"");";
               for (int i = 0; i < list.Count; i++)
               {
                   item = list[i].ToString().Split(';');
                   nomeColuna = item[0].ToString();
                   tipoColuna = item[1].ToString();

                   if (nomeColuna.ToUpper() == "IDENTIFICADOR")
                       nomeColuna = colunaIdentificador;

                   else if (nomeColuna.ToUpper() != "IDENTIFICADOR")
                   {
                       if (i + 1 < list.Count)
                           classe = classe + @"
                 vSQLCommand.AppendLine(""" + nomeColuna.ToUpper() + " = @" + nomeColuna.ToUpper() + ", \");";
                       else if (i + 1 == list.Count)
                           classe = classe + @"
                 vSQLCommand.AppendLine(""" + nomeColuna.ToUpper() + " = @" + nomeColuna.ToUpper() + " \");";
                        if (i + 2 > list.Count)
                          {
                           classe = classe + @"
	             vSQLCommand.AppendLine("" WHERE 1 = 1 "");

                 if (p" + tabelaSemLixo + @"DTO.Identificador != default(int))
                       {
                          vSQLCommand.AppendLine(""and " + colunaIdentificador + @" = @" + colunaIdentificador + @" "");
                       }
                
                 MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);";

                                for (int x = 0; x < list.Count; x++)
                                {
                                    item = list[x].ToString().Split(';');
                                    nomeColuna = item[0].ToString();
                                    tipoColuna = item[1].ToString();
                                    //na acrescenta a coluna identificador
                                    if (item[2].ToString().ToUpper() == "IDENTIFICADOR")
                                    {
                                        classe = classe + @"
                 com.Parameters.Add(new MySqlParameter(""@" + colunaIdentificador + @""", p" + tabelaSemLixo + @"DTO.Identificador));";
                                    }
                                    else
                                    {
                                        //classe = classe + "{" + x + "}) where " + colunaIdentificador + " = {" + x + "}\");";
                                        classe = classe + @"
                                            
                 com.Parameters.Add(new MySqlParameter(""@" + nomeColuna + @""", p" + tabelaSemLixo + @"DTO." + item[2].ToString() + @"));";
                                        
                                        //else
                                        //    classe = classe + "{" + x + "},";
                                    }
                                }

                                classe = classe + @" 
                    Conexao.Open();
                    //dt.Load(com.ExecuteReader());
                    com.ExecuteReader();
                    Conexao.Close();

                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }";

                            }
                        }

                    }
      
                
            classe = classe + @"   
                

        #endregion
        
        #region Exclusao
        
        public Boolean Excluir" + tabelaSemLixo + @"(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO )
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);
                StringBuilder vSQLCommand = new StringBuilder();

                vSQLCommand.AppendLine(""DELETE FROM " + tabela + @""");

                vSQLCommand.AppendLine("" WHERE 1 = 1 "");

                if (p" + tabelaSemLixo + @"DTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine(""and " + colunaIdentificador + @" = @" + colunaIdentificador + @" "");
                }
                
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                if (p" + tabelaSemLixo + @"DTO.Identificador != default(int))
                {
                    com.Parameters.Add(new MySqlParameter(""@" + colunaIdentificador + @""", p" + tabelaSemLixo + @"DTO.Identificador));
                }
                Conexao.Open();
                //dt.Load(com.ExecuteReader());
                com.ExecuteReader();
                Conexao.Close();

                return true;
            
            }
            catch (DataAccessException ex)
            {
                // Verifica se ocorreu erro de constraint
                if (ex.InnerException is SqlException)
                {
                    if (((SqlException)ex.InnerException).Number == 547)
                        throw new RegistroEmUso();
                    else
                        throw;
                }
                else
                    throw;
            }
            catch (Exception e)
            {
                int pos = 0;
                pos = e.Message.ToString().IndexOf(""Cannot delete or update a parent row: a foreign key constraint fails ("");
                if (pos > 0)
                {
                    throw new RegistroEmUso();
                }
                else
                throw new DataAccessException(""Ocorreu um erro ao excluir o Cliente."", DataAccessExceptionLocation.DAO, e);
            }
        }
        #endregion

        #endregion
    }
}
";

            return classe;
        } 
    }
}
