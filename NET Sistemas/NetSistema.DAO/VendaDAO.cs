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
    public class VendaDAO 
    {
        #region Atributos

        private CriaConnectionString getConnection = new CriaConnectionString();
        private string ConnectionString = string.Empty;
        string StrCon;

        #endregion

        #region Construtor

        public VendaDAO()
        {
            StrCon = getConnection.GetConnectionStringProd();
        }

        #endregion

        #region Metodos

        #region Seleção

        public DataTable Selecionar(VendaDTO pVendaDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDVENDA,");
	            vSQLCommand.AppendLine(" IDCLIENTE,");
	            vSQLCommand.AppendLine(" IDPACOTE,");
	            vSQLCommand.AppendLine(" DATAVENDA,");
	            vSQLCommand.AppendLine(" DATAVENCIMENTOFATURA,");
	            vSQLCommand.AppendLine(" VALORVENDA,");
	            vSQLCommand.AppendLine(" STATUS,");
	            vSQLCommand.AppendLine(" OBSERVACAO");

                vSQLCommand.AppendLine(" FROM VENDA");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) ");
	            
                if (pVendaDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idVenda = @idVenda ");
                    }
	            
                if (pVendaDTO.IdCliente!= default(int))
                    {
                        vSQLCommand.AppendLine("and idCliente = @idCliente ");
                    }
	            
                if (pVendaDTO.IdPacote!= default(int))
                    {
                        vSQLCommand.AppendLine("and idPacote = @idPacote ");
                    }
	            if (pVendaDTO.DataVenda!= default(DateTime))
                    {
                        vSQLCommand.AppendLine("and DataVenda = @DataVenda ");
                    }
	            if (pVendaDTO.DataVencimentoFatura!= default(DateTime))
                    {
                        vSQLCommand.AppendLine("and DataVencimentoFatura = @DataVencimentoFatura ");
                    }
	            if (!String.IsNullOrEmpty(pVendaDTO.Status))
                    {
                        vSQLCommand.AppendLine("and Status = @Status ");
                    }
	            if (!String.IsNullOrEmpty(pVendaDTO.Observacao))
                    {
                        vSQLCommand.AppendLine("and Observacao = @Observacao ");
                    }
	            
               
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pVendaDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idVenda", pVendaDTO.Identificador));
                    }

	            if (pVendaDTO.IdCliente!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idCliente", pVendaDTO.IdCliente));
                    }

	            if (pVendaDTO.IdPacote!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idPacote", pVendaDTO.IdPacote));
                    }
	            if (pVendaDTO.DataVenda!= default(DateTime))
                    {
                        com.Parameters.Add(new MySqlParameter("@DataVenda", pVendaDTO.DataVenda));
                    }
	            if (pVendaDTO.DataVencimentoFatura!= default(DateTime))
                    {
                        com.Parameters.Add(new MySqlParameter("@DataVencimentoFatura", pVendaDTO.DataVencimentoFatura));
                    }
	            if (!String.IsNullOrEmpty(pVendaDTO.Status))
                    {
                         com.Parameters.Add(new MySqlParameter("@Status", pVendaDTO.Status));
                    }
	            if (!String.IsNullOrEmpty(pVendaDTO.Observacao))
                    {
                         com.Parameters.Add(new MySqlParameter("@Observacao", pVendaDTO.Observacao));
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
    
        public DataTable SelecionarPesquisar(VendaDTO pVendaDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDVENDA,");
	            vSQLCommand.AppendLine(" VENDA.IDCLIENTE,");
	            vSQLCommand.AppendLine(" VENDA.IDPACOTE,");
	            vSQLCommand.AppendLine(" DATAVENDA,");
	            vSQLCommand.AppendLine(" DATAVENCIMENTOFATURA,");
	            vSQLCommand.AppendLine(" VALORVENDA,");
	            vSQLCommand.AppendLine(" STATUS,");
	            vSQLCommand.AppendLine(" OBSERVACAO,");
                vSQLCommand.AppendLine(" CLIENTE.NOME AS NOMECLIENTE,");
                vSQLCommand.AppendLine(" PACOTES.NOMEPACOTE");

                vSQLCommand.AppendLine(" FROM VENDA ");

                vSQLCommand.AppendLine(" INNER JOIN CLIENTE ON CLIENTE.IDCLIENTE = VENDA.IDCLIENTE ");
                vSQLCommand.AppendLine(" INNER JOIN PACOTES ON PACOTES.IDPACOTES = VENDA.IDPACOTE ");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) ");
	            
                if (pVendaDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idVenda = @idVenda ");
                    }
	            
                if (pVendaDTO.IdCliente!= default(int))
                    {
                        vSQLCommand.AppendLine("and idCliente = @idCliente ");
                    }
	            
                if (pVendaDTO.IdPacote!= default(int))
                    {
                        vSQLCommand.AppendLine("and idPacote = @idPacote ");
                    }
	            if (pVendaDTO.DataVenda!= default(DateTime))
                    {
                        vSQLCommand.AppendLine("and DataVenda = @DataVenda ");
                    }
	            if (pVendaDTO.DataVencimentoFatura!= default(DateTime))
                    {
                        vSQLCommand.AppendLine("and DataVencimentoFatura = @DataVencimentoFatura ");
                    }
	            if (!String.IsNullOrEmpty(pVendaDTO.Status))
                    {
                        vSQLCommand.AppendLine("and Status like @Status ");
                    }
	            if (!String.IsNullOrEmpty(pVendaDTO.Observacao))
                    {
                        vSQLCommand.AppendLine("and Observacao like @Observacao ");
                    }
	            
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pVendaDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idVenda", pVendaDTO.Identificador));
                    }

	            if (pVendaDTO.IdCliente!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idCliente", pVendaDTO.IdCliente));
                    }

	            if (pVendaDTO.IdPacote!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idPacote", pVendaDTO.IdPacote));
                    }
	            if (pVendaDTO.DataVenda!= default(DateTime))
                    {
                        com.Parameters.Add(new MySqlParameter("@DataVenda", pVendaDTO.DataVenda));
                    }
	            if (pVendaDTO.DataVencimentoFatura!= default(DateTime))
                    {
                        com.Parameters.Add(new MySqlParameter("@DataVencimentoFatura", pVendaDTO.DataVencimentoFatura));
                    }
	            if (!String.IsNullOrEmpty(pVendaDTO.Status))
                    {
                         com.Parameters.Add(new MySqlParameter("@Status", "%" + pVendaDTO.Status + "%"));
                    }
	            if (!String.IsNullOrEmpty(pVendaDTO.Observacao))
                    {
                         com.Parameters.Add(new MySqlParameter("@Observacao", "%" + pVendaDTO.Observacao + "%"));
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

        public Boolean Insere(VendaDTO pVendaDTO)
        {
            try
            {
            MySqlConnection Conexao = new MySqlConnection(StrCon);
            StringBuilder vSQLCommand = new StringBuilder();
            vSQLCommand.AppendLine("INSERT INTO venda(");
	        vSQLCommand.AppendLine("IDCLIENTE,");
	        vSQLCommand.AppendLine("IDPACOTE,");
	        vSQLCommand.AppendLine("DATAVENDA,");
	        vSQLCommand.AppendLine("DATAVENCIMENTOFATURA,");
	        vSQLCommand.AppendLine("VALORVENDA,");
	        vSQLCommand.AppendLine("STATUS,");     
	        vSQLCommand.AppendLine("OBSERVACAO) values (");
            //com.Parameters.Add(new MySqlParameter("@idVenda", pVendaDTO.Identificador));
            vSQLCommand.AppendLine(" @idCliente,");
            vSQLCommand.AppendLine(" @idPacote,");
            vSQLCommand.AppendLine(" @DataVenda,");
            vSQLCommand.AppendLine(" @DataVencimentoFatura,");
            vSQLCommand.AppendLine(" @ValorVenda,");
            vSQLCommand.AppendLine(" @Status,");          
            vSQLCommand.AppendLine(" @Observacao)");
            MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
            //com.Parameters.Add(new MySqlParameter("@idVenda", pVendaDTO.Identificador));
                                            
            com.Parameters.Add(new MySqlParameter("@idCliente", pVendaDTO.IdCliente));
                                            
            com.Parameters.Add(new MySqlParameter("@idPacote", pVendaDTO.IdPacote));
                                            
            com.Parameters.Add(new MySqlParameter("@DataVenda", pVendaDTO.DataVenda));
                                            
            com.Parameters.Add(new MySqlParameter("@DataVencimentoFatura", pVendaDTO.DataVencimentoFatura));
                                            
            com.Parameters.Add(new MySqlParameter("@ValorVenda", pVendaDTO.ValorVenda));
                                            
            com.Parameters.Add(new MySqlParameter("@Status", pVendaDTO.Status));
                                            
            com.Parameters.Add(new MySqlParameter("@Observacao", pVendaDTO.Observacao));
          
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

        

        public Boolean Altera(VendaDTO pVendaDTO)
        {
            try
            {
                 DataTable dt = new DataTable();
                 MySqlConnection Conexao = new MySqlConnection(StrCon);
                 StringBuilder vSQLCommand = new StringBuilder();
                 vSQLCommand.AppendLine("UPDATE venda SET");
                 vSQLCommand.AppendLine("IDCLIENTE = @IDCLIENTE, ");
                 vSQLCommand.AppendLine("IDPACOTE = @IDPACOTE, ");
                 vSQLCommand.AppendLine("DATAVENDA = @DATAVENDA, ");
                 vSQLCommand.AppendLine("DATAVENCIMENTOFATURA = @DATAVENCIMENTOFATURA, ");
                 vSQLCommand.AppendLine("VALORVENDA = @VALORVENDA, ");
                 vSQLCommand.AppendLine("STATUS = @STATUS, ");
                 vSQLCommand.AppendLine("OBSERVACAO = @OBSERVACAO ");
	             vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                 if (pVendaDTO.Identificador != default(int))
                       {
                          vSQLCommand.AppendLine("and idVenda = @idVenda ");
                       }
                
                 MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
                 com.Parameters.Add(new MySqlParameter("@idVenda", pVendaDTO.Identificador));
                                            
                 com.Parameters.Add(new MySqlParameter("@idCliente", pVendaDTO.IdCliente));
                                            
                 com.Parameters.Add(new MySqlParameter("@idPacote", pVendaDTO.IdPacote));
                                            
                 com.Parameters.Add(new MySqlParameter("@DataVenda", pVendaDTO.DataVenda));
                                            
                 com.Parameters.Add(new MySqlParameter("@DataVencimentoFatura", pVendaDTO.DataVencimentoFatura));
                                            
                 com.Parameters.Add(new MySqlParameter("@ValorVenda", pVendaDTO.ValorVenda));
                                            
                 com.Parameters.Add(new MySqlParameter("@Status", pVendaDTO.Status));
                                            
                 com.Parameters.Add(new MySqlParameter("@Observacao", pVendaDTO.Observacao));

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
        
        public Boolean Excluir(VendaDTO pVendaDTO )
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);
                StringBuilder vSQLCommand = new StringBuilder();

                vSQLCommand.AppendLine("DELETE FROM venda");

                vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                if (pVendaDTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine("and idVenda = @idVenda ");
                }
                
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                if (pVendaDTO.Identificador != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idVenda", pVendaDTO.Identificador));
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
