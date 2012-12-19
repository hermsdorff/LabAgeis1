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
    public class HorarioDAO 
    {
        #region Atributos

        private CriaConnectionString getConnection = new CriaConnectionString();
        private string ConnectionString = string.Empty;
        string StrCon;

        #endregion

        #region Construtor

        public HorarioDAO()
        {
            StrCon = getConnection.GetConnectionStringProd();
        }

        #endregion

        #region Metodos

        #region Seleção

        public DataTable Selecionar(HorarioDTO pHorarioDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDHORARIO,");
	            vSQLCommand.AppendLine(" HORARIO");

                vSQLCommand.AppendLine(" FROM HORARIO");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) idHorario ");
	            
                if (pHorarioDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idHorario = @idHorario ");
                    }
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pHorarioDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idHorario", pHorarioDTO.Identificador));
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

        public DataTable SelecionarPesquisar(HorarioDTO pHorarioDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDHORARIO,");
	            vSQLCommand.AppendLine(" HORARIO");

                vSQLCommand.AppendLine(" FROM HORARIO");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) idHorario ");
	            
                if (pHorarioDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idHorario = @idHorario ");
                    }
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pHorarioDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idHorario", pHorarioDTO.Identificador));
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

        public Boolean Insere(HorarioDTO pHorarioDTO)
        {
            try
            {
            MySqlConnection Conexao = new MySqlConnection(StrCon);
            StringBuilder vSQLCommand = new StringBuilder();
            vSQLCommand.AppendLine("INSERT INTO horario(");
	        vSQLCommand.AppendLine("HORARIO) values (");
            //com.Parameters.Add(new MySqlParameter("@idHorario", pDTO.Identificador));
            vSQLCommand.AppendLine(" @Horario)");
            MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
            //com.Parameters.Add(new MySqlParameter("@idHorario", pDTO.Identificador));
                                            
            com.Parameters.Add(new MySqlParameter("@Horario", pHorarioDTO.Horario)); 
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



        public Boolean Altera(HorarioDTO pHorarioDTO)
        {
            try
            {
                 DataTable dt = new DataTable();
                 MySqlConnection Conexao = new MySqlConnection(StrCon);
                 StringBuilder vSQLCommand = new StringBuilder();
                 vSQLCommand.AppendLine("UPDATE horario SET");
                 vSQLCommand.AppendLine("HORARIO = @HORARIO ");
	             vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                 if (pHorarioDTO.Identificador != default(int))
                       {
                          vSQLCommand.AppendLine("and idHorario = @idHorario ");
                       }
                
                 MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
                 com.Parameters.Add(new MySqlParameter("@idHorario", pHorarioDTO.Identificador));
                                            
                 com.Parameters.Add(new MySqlParameter("@Horario", pHorarioDTO.Horario)); 
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

        public Boolean Excluir(HorarioDTO pHorarioDTO)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);
                StringBuilder vSQLCommand = new StringBuilder();

                vSQLCommand.AppendLine("DELETE FROM horario");

                vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                if (pHorarioDTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine("and idHorario = @idHorario ");
                }
                
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                if (pHorarioDTO.Identificador != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idHorario", pHorarioDTO.Identificador));
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
