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
    public class FuncionarioDAO 
    {
        #region Atributos

        private CriaConnectionString getConnection = new CriaConnectionString();
        private string ConnectionString = string.Empty;
        string StrCon;

        #endregion

        #region Construtor

        public FuncionarioDAO()
        {
            StrCon = getConnection.GetConnectionStringProd();
        }

        #endregion

        #region Metodos

        #region Seleção

        public DataTable Selecionar(FuncionarioDTO pFuncionarioDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDFUNCIONARIO,");
	            vSQLCommand.AppendLine(" NOME");

                vSQLCommand.AppendLine(" FROM FUNCIONARIO");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) idFuncionario ");
	            
                if (pFuncionarioDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idFuncionario = @idFuncionario ");
                    }
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pFuncionarioDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idFuncionario", pFuncionarioDTO.Identificador));
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

        public DataTable SelecionarPesquisar(FuncionarioDTO pFuncionarioDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDFUNCIONARIO,");
	            vSQLCommand.AppendLine(" NOME");

                vSQLCommand.AppendLine(" FROM FUNCIONARIO");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) idFuncionario ");
	            
                if (pFuncionarioDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idFuncionario = @idFuncionario ");
                    }
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pFuncionarioDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idFuncionario", pFuncionarioDTO.Identificador));
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

        public Boolean Insere(FuncionarioDTO pFuncionarioDTO)
        {
            try
            {
            MySqlConnection Conexao = new MySqlConnection(StrCon);
            StringBuilder vSQLCommand = new StringBuilder();
            vSQLCommand.AppendLine("INSERT INTO funcionario(");
	        vSQLCommand.AppendLine("NOME) values (");
            //com.Parameters.Add(new MySqlParameter("@idFuncionario", pDTO.Identificador));
            vSQLCommand.AppendLine(" @Nome)");
            MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
            //com.Parameters.Add(new MySqlParameter("@idFuncionario", pDTO.Identificador));
                                            
            com.Parameters.Add(new MySqlParameter("@Nome", pFuncionarioDTO.Nome)); 
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



        public Boolean Altera(FuncionarioDTO pFuncionarioDTO)
        {
            try
            {
                 DataTable dt = new DataTable();
                 MySqlConnection Conexao = new MySqlConnection(StrCon);
                 StringBuilder vSQLCommand = new StringBuilder();
                 vSQLCommand.AppendLine("UPDATE funcionario SET");
                 vSQLCommand.AppendLine("NOME = @NOME ");
	             vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                 if (pFuncionarioDTO.Identificador != default(int))
                       {
                          vSQLCommand.AppendLine("and idFuncionario = @idFuncionario ");
                       }
                
                 MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
                 com.Parameters.Add(new MySqlParameter("@idFuncionario", pFuncionarioDTO.Identificador));
                                            
                 com.Parameters.Add(new MySqlParameter("@Nome", pFuncionarioDTO.Nome)); 
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

        public Boolean Excluir(FuncionarioDTO pFuncionarioDTO)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);
                StringBuilder vSQLCommand = new StringBuilder();

                vSQLCommand.AppendLine("DELETE FROM funcionario");

                vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                if (pFuncionarioDTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine("and idFuncionario = @idFuncionario ");
                }
                
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                if (pFuncionarioDTO.Identificador != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idFuncionario", pFuncionarioDTO.Identificador));
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
