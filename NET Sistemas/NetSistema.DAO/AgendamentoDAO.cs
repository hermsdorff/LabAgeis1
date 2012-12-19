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
    public class AgendamentoDAO
    {
        #region Atributos

        private CriaConnectionString getConnection = new CriaConnectionString();
        private string ConnectionString = string.Empty;
        string StrCon;

        #endregion

        #region Construtor

        public AgendamentoDAO()
        {
            StrCon = getConnection.GetConnectionStringProd();
        }

        #endregion

        #region Metodos

        #region Seleção

        public DataTable Selecionar(AgendamentoDTO pAgendamentoDTO)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

                vSQLCommand.AppendLine(" IDAGENDAMENTO,");
                vSQLCommand.AppendLine(" IDVENDA,");
                vSQLCommand.AppendLine(" IDFUNCIONARIO,");
                vSQLCommand.AppendLine(" DATAAGENDAMENTO,");
                vSQLCommand.AppendLine(" IDHORARIO");

                vSQLCommand.AppendLine(" FROM AGENDAMENTO");

                vSQLCommand.AppendFormat(" WHERE (1=1) idAgendamento ");

                if (pAgendamentoDTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine("and idAgendamento = @idAgendamento ");
                }

                if (pAgendamentoDTO.IdVenda != default(int))
                {
                    vSQLCommand.AppendLine("and idVenda = @idVenda ");
                }

                if (pAgendamentoDTO.IdFuncionario != default(int))
                {
                    vSQLCommand.AppendLine("and idFuncionario = @idFuncionario ");
                }
                if (pAgendamentoDTO.DataAgendamento != default(DateTime))
                {
                    vSQLCommand.AppendLine("and DataAgendamento = @DataAgendamento ");
                }

                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                if (pAgendamentoDTO.Identificador != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idAgendamento", pAgendamentoDTO.Identificador));
                }

                if (pAgendamentoDTO.IdVenda != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idVenda", pAgendamentoDTO.IdVenda));
                }

                if (pAgendamentoDTO.IdFuncionario != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idFuncionario", pAgendamentoDTO.IdFuncionario));
                }
                if (pAgendamentoDTO.DataAgendamento != default(DateTime))
                {
                    com.Parameters.Add(new MySqlParameter("@DataAgendamento", pAgendamentoDTO.DataAgendamento));
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

        public DataTable SelecionarPesquisar(AgendamentoDTO pAgendamentoDTO)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT                    ");

                vSQLCommand.AppendLine(" IDAGENDAMENTO,");
                vSQLCommand.AppendLine(" IDVENDA,");
                vSQLCommand.AppendLine(" IDFUNCIONARIO,");
                vSQLCommand.AppendLine(" DATAAGENDAMENTO,");
                vSQLCommand.AppendLine(" IDHORARIO");

                vSQLCommand.AppendLine(" FROM AGENDAMENTO");

                vSQLCommand.AppendFormat(" WHERE (1=1) ");

                if (pAgendamentoDTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine("and idAgendamento = @idAgendamento ");
                }

                if (pAgendamentoDTO.IdVenda != default(int))
                {
                    vSQLCommand.AppendLine("and idVenda = @idVenda ");
                }

                if (pAgendamentoDTO.IdFuncionario != default(int))
                {
                    vSQLCommand.AppendLine("and idFuncionario = @idFuncionario ");
                }
                if (pAgendamentoDTO.DataAgendamento != default(DateTime))
                {
                    vSQLCommand.AppendLine("and DataAgendamento = @DataAgendamento ");
                }

                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                if (pAgendamentoDTO.Identificador != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idAgendamento", pAgendamentoDTO.Identificador));
                }

                if (pAgendamentoDTO.IdVenda != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idVenda", pAgendamentoDTO.IdVenda));
                }

                if (pAgendamentoDTO.IdFuncionario != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idFuncionario", pAgendamentoDTO.IdFuncionario));
                }
                if (pAgendamentoDTO.DataAgendamento != default(DateTime))
                {
                    com.Parameters.Add(new MySqlParameter("@DataAgendamento", pAgendamentoDTO.DataAgendamento));
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



        public int SelecionarHorarios(DateTime pDt, int pIdHorario)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();
                vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine(" SELECT  count(idAgendamento)  from agendamento where idhoario = @idhorario and dataagendamento = @dtagendamento  ");


                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                com.Parameters.Add(new MySqlParameter("@idhorario", pIdHorario));

                com.Parameters.Add(new MySqlParameter("@dtagendamento", pDt));

                Conexao.Open();
                dt.Load(com.ExecuteReader());
                com.ExecuteReader();
                Conexao.Close();

                return dt.Rows.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int SelecionarQtdFuncionarios()
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);

                StringBuilder vSQLCommand = new StringBuilder();
                vSQLCommand = new StringBuilder();
                //vSQLCommand.AppendLine(" SELECT  count(idfuncionario) from funcionario where idhoario = @idhorario and dtagendamento = @dtagendamento SELECT  count(funcionario.idfuncionario) from funcionario "+
                //                            " where funcionario.idfuncionario not in (select agendamento.idFuncionario from agendamento where dataagendamento = @dtagendamento and idhorario = @idhorario) ");

                vSQLCommand.AppendLine(" SELECT  count(idfuncionario) from funcionario ");


                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);


                //com.Parameters.Add(new MySqlParameter("@idhorario", pIdHorario));

                //com.Parameters.Add(new MySqlParameter("@dtagendamento", pDt));


                Conexao.Open();
                dt.Load(com.ExecuteReader());
                com.ExecuteReader();
                Conexao.Close();

                return dt.Rows.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        #endregion

        #region Inserção

        public Boolean Insere(AgendamentoDTO pAgendamentoDTO)
        {
            try
            {
                MySqlConnection Conexao = new MySqlConnection(StrCon);
                StringBuilder vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine("INSERT INTO agendamento(");
                vSQLCommand.AppendLine("IDVENDA,");
                vSQLCommand.AppendLine("IDFUNCIONARIO,");
                vSQLCommand.AppendLine("DATAAGENDAMENTO,");
                vSQLCommand.AppendLine("IDHORARIO) values (");
                //com.Parameters.Add(new MySqlParameter("@idAgendamento", pDTO.Identificador));
                vSQLCommand.AppendLine(" @idVenda,");
                vSQLCommand.AppendLine(" @idFuncionario,");
                vSQLCommand.AppendLine(" @DataAgendamento,");
                vSQLCommand.AppendLine(" @idHorario)");
                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
                //com.Parameters.Add(new MySqlParameter("@idAgendamento", pDTO.Identificador));

                com.Parameters.Add(new MySqlParameter("@idVenda", pAgendamentoDTO.IdVenda));

                com.Parameters.Add(new MySqlParameter("@idFuncionario", pAgendamentoDTO.IdFuncionario));

                com.Parameters.Add(new MySqlParameter("@DataAgendamento", pAgendamentoDTO.DataAgendamento));

                com.Parameters.Add(new MySqlParameter("@idHorario", pAgendamentoDTO.IdHorario));
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



        public Boolean Altera(AgendamentoDTO pAgendamentoDTO)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);
                StringBuilder vSQLCommand = new StringBuilder();
                vSQLCommand.AppendLine("UPDATE agendamento SET");
                vSQLCommand.AppendLine("IDVENDA = @IDVENDA, ");
                vSQLCommand.AppendLine("IDFUNCIONARIO = @IDFUNCIONARIO, ");
                vSQLCommand.AppendLine("DATAAGENDAMENTO = @DATAAGENDAMENTO, ");
                vSQLCommand.AppendLine("IDHORARIO = @IDHORARIO ");
                vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                if (pAgendamentoDTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine("and idAgendamento = @idAgendamento ");
                }

                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);
                com.Parameters.Add(new MySqlParameter("@idAgendamento", pAgendamentoDTO.Identificador));

                com.Parameters.Add(new MySqlParameter("@idVenda", pAgendamentoDTO.IdVenda));

                com.Parameters.Add(new MySqlParameter("@idFuncionario", pAgendamentoDTO.IdFuncionario));

                com.Parameters.Add(new MySqlParameter("@DataAgendamento", pAgendamentoDTO.DataAgendamento));

                com.Parameters.Add(new MySqlParameter("@idHorario", pAgendamentoDTO.IdHorario));
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

        public Boolean Excluir(AgendamentoDTO pAgendamentoDTO)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlConnection Conexao = new MySqlConnection(StrCon);
                StringBuilder vSQLCommand = new StringBuilder();

                vSQLCommand.AppendLine("DELETE FROM agendamento");

                vSQLCommand.AppendLine(" WHERE 1 = 1 ");

                if (pAgendamentoDTO.Identificador != default(int))
                {
                    vSQLCommand.AppendLine("and idAgendamento = @idAgendamento ");
                }

                MySqlCommand com = new MySqlCommand(vSQLCommand.ToString(), Conexao);

                if (pAgendamentoDTO.Identificador != default(int))
                {
                    com.Parameters.Add(new MySqlParameter("@idAgendamento", pAgendamentoDTO.Identificador));
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
