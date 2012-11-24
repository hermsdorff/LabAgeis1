using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using NetSistema.DTO;
//using NetSistema.Exceptions;
using AttPsFw.Utils.Exceptions;// dll da framework da att


namespace NetSistema.DAO
{
    public class PacotesDAO 
    {
        #region Atributos

        private CriaConnectionString getConnection = new CriaConnectionString();
        private string ConnectionString = string.Empty;
        string StrCon;

        #endregion

        #region Construtor

        public PacotesDAO()
        {
            StrCon = getConnection.GetConnectionStringProd();
        }

        #endregion

        #region Metodos

        #region Seleção

        public DataTable Selecionar(PacotesDTO pPacoteDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDPACOTES,");
	            vSQLCommand.AppendLine(" NOMEPACOTE,");
	            vSQLCommand.AppendLine(" DESCPACOTE,");
	            vSQLCommand.AppendLine(" VALORPACOTE ");


                vSQLCommand.AppendLine(" FROM PACOTES");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) ");
	            
                if (pPacoteDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idPacotes = @idPacotes ");
                    }
	            if (!String.IsNullOrEmpty(pPacoteDTO.NomePacote))
                    {
                        vSQLCommand.AppendLine("and NomePacote = @NomePacote ");
                    }
	            if (!String.IsNullOrEmpty(pPacoteDTO.DescPacote))
                    {
                        vSQLCommand.AppendLine("and DescPacote = @DescPacote ");
                    }
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pPacoteDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idPacotes", pPacoteDTO.Identificador));
                    }
	            if (!String.IsNullOrEmpty(pPacoteDTO.NomePacote))
                    {
                         com.Parameters.Add(new MySqlParameter("@NomePacote", pPacoteDTO.NomePacote));
                    }
	            if (!String.IsNullOrEmpty(pPacoteDTO.DescPacote))
                    {
                         com.Parameters.Add(new MySqlParameter("@DescPacote", pPacoteDTO.DescPacote));
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
    
        public DataTable SelecionarPesquisar(PacotesDTO pPacoteDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDPACOTES,");
	            vSQLCommand.AppendLine(" NOMEPACOTE,");
	            vSQLCommand.AppendLine(" DESCPACOTE,");
	            vSQLCommand.AppendLine(" VALORPACOTE");

                vSQLCommand.AppendLine(" FROM PACOTES");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) ");
	            
                if (pPacoteDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idPacotes = @idPacotes ");
                    }
	            if (!String.IsNullOrEmpty(pPacoteDTO.NomePacote))
                    {
                        vSQLCommand.AppendLine("and NomePacote like @NomePacote ");
                    }
	            if (!String.IsNullOrEmpty(pPacoteDTO.DescPacote))
                    {
                        vSQLCommand.AppendLine("and DescPacote like @DescPacote ");
                    }
	           
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pPacoteDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idPacotes", pPacoteDTO.Identificador));
                    }
	            if (!String.IsNullOrEmpty(pPacoteDTO.NomePacote))
                    {
                         com.Parameters.Add(new MySqlParameter("@NomePacote", "%" + pPacoteDTO.NomePacote + "%"));
                    }
	            if (!String.IsNullOrEmpty(pPacoteDTO.DescPacote))
                    {
                         com.Parameters.Add(new MySqlParameter("@DescPacote", "%" + pPacoteDTO.DescPacote + "%"));
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

        #endregion

        #region Inserção

        public Boolean Insere(PacotesDTO pPacoteDTO)
        {
            try
            {
            MySqlConnection Conexao = new MySqlConnection(StrCon);
            StringBuilder vSQLCommand = new StringBuilder();
            vSQLCommand.AppendLine("INSERT INTO pacotes(");
	        vSQLCommand.AppendLine("NOMEPACOTE,");
	        vSQLCommand.AppendLine("DESCPACOTE,");
	        vSQLCommand.AppendLine("VALORPACOTE) values (");
            //com.Parameters.Add(new MySqlParameter("@idPacotes", pPacoteDTO.Identificador));
            vSQLCommand.AppendLine(" @NomePacote,");
            vSQLCommand.AppendLine(" @DescPacote,");
            vSQLCommand.AppendLine(" @ValorPacote)");
            MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
            //com.Parameters.Add(new MySqlParameter("@idPacotes", pPacoteDTO.Identificador));
                                            
            com.Parameters.Add(new MySqlParameter("@NomePacote", pPacoteDTO.NomePacote));
                                            
            com.Parameters.Add(new MySqlParameter("@DescPacote", pPacoteDTO.DescPacote));
                                            
            com.Parameters.Add(new MySqlParameter("@ValorPacote", pPacoteDTO.ValorPacote));
            
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

        

        public Boolean Altera(PacotesDTO pPacoteDTO)
        {
            try
            {
                 DataTable dt = new DataTable();
                 MySqlConnection Conexao = new MySqlConnection(StrCon);
                 StringBuilder vSQLCommand = new StringBuilder();
                 vSQLCommand.AppendLine("UPDATE pacotes SET");
                 vSQLCommand.AppendLine("NOMEPACOTE = @NOMEPACOTE, ");
                 vSQLCommand.AppendLine("DESCPACOTE = @DESCPACOTE, ");
                 vSQLCommand.AppendLine("VALORPACOTE = @VALORPACOTE ");
	             vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                 if (pPacoteDTO.Identificador != default(int))
                       {
                          vSQLCommand.AppendLine("and idPacotes = @idPacotes ");
                       }
                
                 MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
                 
                com.Parameters.Add(new MySqlParameter("@idPacotes", pPacoteDTO.Identificador));
                                            
                 com.Parameters.Add(new MySqlParameter("@NomePacote", pPacoteDTO.NomePacote));
                                            
                 com.Parameters.Add(new MySqlParameter("@DescPacote", pPacoteDTO.DescPacote));
                                            
                 com.Parameters.Add(new MySqlParameter("@ValorPacote", pPacoteDTO.ValorPacote));

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
        
        #region Exclusao
        
        public Boolean Excluir(PacotesDTO pPacoteDTO )
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);
                StringBuilder vSQLCommand = new StringBuilder();

                vSQLCommand.AppendLine("DELETE FROM pacotes");

                vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                if (pPacoteDTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine("and idPacotes = @idPacotes ");
                }
                
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                if (pPacoteDTO.Identificador != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idPacotes", pPacoteDTO.Identificador));
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
                        //throw new RegistroEmUso();
                        throw new Exception();
                    else
                        throw;
                }
                else
                    throw;
            }
            catch (Exception e)
            {
                int pos = 0;
                pos = e.Message.ToString().IndexOf("Cannot delete or update a parent row: a foreign key constraint fails (");
                if (pos > 0)
                {
                    //throw new RegistroEmUso();
                    throw new Exception();
                }
                else
                throw new DataAccessException("Ocorreu um erro ao excluir o Cliente.", DataAccessExceptionLocation.DAO, e);
            }
        }
        #endregion

        #endregion
    }
}
