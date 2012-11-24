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
    public class ClienteDAO 
    {
        #region Atributos

        private CriaConnectionString getConnection = new CriaConnectionString();
        private string ConnectionString = string.Empty;
        string StrCon;

        #endregion

        #region Construtor

        public ClienteDAO()
        {
            StrCon = getConnection.GetConnectionStringProd();
        }

        #endregion

        #region Metodos

        #region Seleção

        public DataTable Selecionar(ClienteDTO pClienteDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDCLIENTE,");
	            vSQLCommand.AppendLine(" NOME,");
	            vSQLCommand.AppendLine(" LOGRADOURO,");
	            vSQLCommand.AppendLine(" NUMERO,");
	            vSQLCommand.AppendLine(" COMPLEMENTO,");
	            vSQLCommand.AppendLine(" BAIRRO,");
	            vSQLCommand.AppendLine(" CIDADE,");
	            vSQLCommand.AppendLine(" UF,");
	            vSQLCommand.AppendLine(" CEP,");
	            vSQLCommand.AppendLine(" TELEFONE,");
	            vSQLCommand.AppendLine(" CPJCNPJ,");
	            vSQLCommand.AppendLine(" TIPOPESSOA");

                vSQLCommand.AppendLine(" FROM CLIENTE");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) ");
	            
                if (pClienteDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idCliente = @idCliente ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Nome))
                    {
                        vSQLCommand.AppendLine("and Nome = @Nome ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Logradouro))
                    {
                        vSQLCommand.AppendLine("and Logradouro = @Logradouro ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Numero))
                    {
                        vSQLCommand.AppendLine("and numero = @numero ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Complemento))
                    {
                        vSQLCommand.AppendLine("and complemento = @complemento ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Bairro))
                    {
                        vSQLCommand.AppendLine("and bairro = @bairro ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cidade))
                    {
                        vSQLCommand.AppendLine("and cidade = @cidade ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Uf))
                    {
                        vSQLCommand.AppendLine("and uf = @uf ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cep))
                    {
                        vSQLCommand.AppendLine("and cep = @cep ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Telefone))
                    {
                        vSQLCommand.AppendLine("and telefone = @telefone ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cpjcnpj))
                    {
                        vSQLCommand.AppendLine("and cpjcnpj = @cpjcnpj ");
                    }
	            
               
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pClienteDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idCliente", pClienteDTO.Identificador));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Nome))
                    {
                         com.Parameters.Add(new MySqlParameter("@Nome", pClienteDTO.Nome));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Logradouro))
                    {
                         com.Parameters.Add(new MySqlParameter("@Logradouro", pClienteDTO.Logradouro));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Numero))
                    {
                         com.Parameters.Add(new MySqlParameter("@numero", pClienteDTO.Numero));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Complemento))
                    {
                         com.Parameters.Add(new MySqlParameter("@complemento", pClienteDTO.Complemento));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Bairro))
                    {
                         com.Parameters.Add(new MySqlParameter("@bairro", pClienteDTO.Bairro));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cidade))
                    {
                         com.Parameters.Add(new MySqlParameter("@cidade", pClienteDTO.Cidade));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Uf))
                    {
                         com.Parameters.Add(new MySqlParameter("@uf", pClienteDTO.Uf));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cep))
                    {
                         com.Parameters.Add(new MySqlParameter("@cep", pClienteDTO.Cep));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Telefone))
                    {
                         com.Parameters.Add(new MySqlParameter("@telefone", pClienteDTO.Telefone));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cpjcnpj))
                    {
                         com.Parameters.Add(new MySqlParameter("@cpjcnpj", pClienteDTO.Cpjcnpj));
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
    
        public DataTable SelecionarPesquisar(ClienteDTO pClienteDTO)
        {
            try
            {     
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();           
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

	            vSQLCommand.AppendLine(" IDCLIENTE,");
	            vSQLCommand.AppendLine(" NOME,");
	            vSQLCommand.AppendLine(" LOGRADOURO,");
	            vSQLCommand.AppendLine(" NUMERO,");
	            vSQLCommand.AppendLine(" COMPLEMENTO,");
	            vSQLCommand.AppendLine(" BAIRRO,");
	            vSQLCommand.AppendLine(" CIDADE,");
	            vSQLCommand.AppendLine(" UF,");
	            vSQLCommand.AppendLine(" CEP,");
	            vSQLCommand.AppendLine(" TELEFONE,");
	            vSQLCommand.AppendLine(" CPJCNPJ,");
	            vSQLCommand.AppendLine(" TIPOPESSOA");

                vSQLCommand.AppendLine(" FROM CLIENTE");
     
                vSQLCommand.AppendFormat(" WHERE (1=1) ");
	            
                if (pClienteDTO.Identificador!= default(int))
                    {
                        vSQLCommand.AppendLine("and idCliente = @idCliente ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Nome))
                    {
                        vSQLCommand.AppendLine("and Nome like @Nome ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Logradouro))
                    {
                        vSQLCommand.AppendLine("and Logradouro like @Logradouro ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Numero))
                    {
                        vSQLCommand.AppendLine("and numero like @numero ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Complemento))
                    {
                        vSQLCommand.AppendLine("and complemento like @complemento ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Bairro))
                    {
                        vSQLCommand.AppendLine("and bairro like @bairro ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cidade))
                    {
                        vSQLCommand.AppendLine("and cidade like @cidade ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Uf))
                    {
                        vSQLCommand.AppendLine("and uf like @uf ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cep))
                    {
                        vSQLCommand.AppendLine("and cep like @cep ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Telefone))
                    {
                        vSQLCommand.AppendLine("and telefone like @telefone ");
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cpjcnpj))
                    {
                        vSQLCommand.AppendLine("and cpjcnpj like @cpjcnpj ");
                    }
	         
	             
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

	            if (pClienteDTO.Identificador!= default(int))
                    {
                        com.Parameters.Add(new MySqlParameter("@idCliente", pClienteDTO.Identificador));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Nome))
                    {
                         com.Parameters.Add(new MySqlParameter("@Nome", "%" + pClienteDTO.Nome + "%"));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Logradouro))
                    {
                         com.Parameters.Add(new MySqlParameter("@Logradouro", "%" + pClienteDTO.Logradouro + "%"));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Numero))
                    {
                         com.Parameters.Add(new MySqlParameter("@numero", "%" + pClienteDTO.Numero + "%"));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Complemento))
                    {
                         com.Parameters.Add(new MySqlParameter("@complemento", "%" + pClienteDTO.Complemento + "%"));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Bairro))
                    {
                         com.Parameters.Add(new MySqlParameter("@bairro", "%" + pClienteDTO.Bairro + "%"));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cidade))
                    {
                         com.Parameters.Add(new MySqlParameter("@cidade", "%" + pClienteDTO.Cidade + "%"));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Uf))
                    {
                         com.Parameters.Add(new MySqlParameter("@uf", "%" + pClienteDTO.Uf + "%"));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cep))
                    {
                         com.Parameters.Add(new MySqlParameter("@cep", "%" + pClienteDTO.Cep + "%"));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Telefone))
                    {
                         com.Parameters.Add(new MySqlParameter("@telefone", "%" + pClienteDTO.Telefone + "%"));
                    }
	            if (!String.IsNullOrEmpty(pClienteDTO.Cpjcnpj))
                    {
                         com.Parameters.Add(new MySqlParameter("@cpjcnpj", "%" + pClienteDTO.Cpjcnpj + "%"));
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

        public Boolean Insere(ClienteDTO pClienteDTO)
        {
            try
            {
            MySqlConnection Conexao = new MySqlConnection(StrCon);
            StringBuilder vSQLCommand = new StringBuilder();
            vSQLCommand.AppendLine("INSERT INTO cliente(");
	        vSQLCommand.AppendLine("NOME,");
	        vSQLCommand.AppendLine("LOGRADOURO,");
	        vSQLCommand.AppendLine("NUMERO,");
	        vSQLCommand.AppendLine("COMPLEMENTO,");
	        vSQLCommand.AppendLine("BAIRRO,");
	        vSQLCommand.AppendLine("CIDADE,");
	        vSQLCommand.AppendLine("UF,");
	        vSQLCommand.AppendLine("CEP,");
	        vSQLCommand.AppendLine("TELEFONE,");
	        vSQLCommand.AppendLine("CPJCNPJ,");
	        vSQLCommand.AppendLine("TIPOPESSOA) values (");
            //com.Parameters.Add(new MySqlParameter("@idCliente", pClienteDTO.Identificador));
            vSQLCommand.AppendLine(" @Nome,");
            vSQLCommand.AppendLine(" @Logradouro,");
            vSQLCommand.AppendLine(" @numero,");
            vSQLCommand.AppendLine(" @complemento,");
            vSQLCommand.AppendLine(" @bairro,");
            vSQLCommand.AppendLine(" @cidade,");
            vSQLCommand.AppendLine(" @uf,");
            vSQLCommand.AppendLine(" @cep,");
            vSQLCommand.AppendLine(" @telefone,");
            vSQLCommand.AppendLine(" @cpjcnpj,");
            vSQLCommand.AppendLine(" @TipoPessoa)");
            MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
            //com.Parameters.Add(new MySqlParameter("@idCliente", pClienteDTO.Identificador));
                                            
            com.Parameters.Add(new MySqlParameter("@Nome", pClienteDTO.Nome));
                                            
            com.Parameters.Add(new MySqlParameter("@Logradouro", pClienteDTO.Logradouro));
                                            
            com.Parameters.Add(new MySqlParameter("@numero", pClienteDTO.Numero));
                                            
            com.Parameters.Add(new MySqlParameter("@complemento", pClienteDTO.Complemento));
                                            
            com.Parameters.Add(new MySqlParameter("@bairro", pClienteDTO.Bairro));
                                            
            com.Parameters.Add(new MySqlParameter("@cidade", pClienteDTO.Cidade));
                                            
            com.Parameters.Add(new MySqlParameter("@uf", pClienteDTO.Uf));
                                            
            com.Parameters.Add(new MySqlParameter("@cep", pClienteDTO.Cep));
                                            
            com.Parameters.Add(new MySqlParameter("@telefone", pClienteDTO.Telefone));
                                            
            com.Parameters.Add(new MySqlParameter("@cpjcnpj", pClienteDTO.Cpjcnpj));
                                            
            com.Parameters.Add(new MySqlParameter("@TipoPessoa", pClienteDTO.TipoPessoa)); 
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

        

        public Boolean Altera(ClienteDTO pClienteDTO)
        {
            try
            {
                 DataTable dt = new DataTable();
                 MySqlConnection Conexao = new MySqlConnection(StrCon);
                 StringBuilder vSQLCommand = new StringBuilder();
                 vSQLCommand.AppendLine("UPDATE cliente SET");
                 vSQLCommand.AppendLine("NOME = @NOME, ");
                 vSQLCommand.AppendLine("LOGRADOURO = @LOGRADOURO, ");
                 vSQLCommand.AppendLine("NUMERO = @NUMERO, ");
                 vSQLCommand.AppendLine("COMPLEMENTO = @COMPLEMENTO, ");
                 vSQLCommand.AppendLine("BAIRRO = @BAIRRO, ");
                 vSQLCommand.AppendLine("CIDADE = @CIDADE, ");
                 vSQLCommand.AppendLine("UF = @UF, ");
                 vSQLCommand.AppendLine("CEP = @CEP, ");
                 vSQLCommand.AppendLine("TELEFONE = @TELEFONE, ");
                 vSQLCommand.AppendLine("CPJCNPJ = @CPJCNPJ, ");
                 vSQLCommand.AppendLine("TIPOPESSOA = @TIPOPESSOA ");
	             vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                 if (pClienteDTO.Identificador != default(int))
                       {
                          vSQLCommand.AppendLine("and idCliente = @idCliente ");
                       }
                
                 MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
                 com.Parameters.Add(new MySqlParameter("@idCliente", pClienteDTO.Identificador));
                                            
                 com.Parameters.Add(new MySqlParameter("@Nome", pClienteDTO.Nome));
                                            
                 com.Parameters.Add(new MySqlParameter("@Logradouro", pClienteDTO.Logradouro));
                                            
                 com.Parameters.Add(new MySqlParameter("@numero", pClienteDTO.Numero));
                                            
                 com.Parameters.Add(new MySqlParameter("@complemento", pClienteDTO.Complemento));
                                            
                 com.Parameters.Add(new MySqlParameter("@bairro", pClienteDTO.Bairro));
                                            
                 com.Parameters.Add(new MySqlParameter("@cidade", pClienteDTO.Cidade));
                                            
                 com.Parameters.Add(new MySqlParameter("@uf", pClienteDTO.Uf));
                                            
                 com.Parameters.Add(new MySqlParameter("@cep", pClienteDTO.Cep));
                                            
                 com.Parameters.Add(new MySqlParameter("@telefone", pClienteDTO.Telefone));
                                            
                 com.Parameters.Add(new MySqlParameter("@cpjcnpj", pClienteDTO.Cpjcnpj));
                                            
                 com.Parameters.Add(new MySqlParameter("@TipoPessoa", pClienteDTO.TipoPessoa)); 
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
        
        public Boolean Excluir(ClienteDTO pClienteDTO )
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);
                StringBuilder vSQLCommand = new StringBuilder();

                vSQLCommand.AppendLine("DELETE FROM cliente");

                vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                if (pClienteDTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine("and idCliente = @idCliente ");
                }
                
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                if (pClienteDTO.Identificador != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idCliente", pClienteDTO.Identificador));
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
