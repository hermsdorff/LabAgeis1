using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NetSistema.DTO;
using NetSistema.DAO;


namespace NetSistema.Controller
{
    public class AgendamentoCT 
    {
        #region Atributos

        public AgendamentoDAO AgendamentoDAO = new AgendamentoDAO();

        #endregion

        #region Metodos

        #region Seleção

        public DataTable SelecionarPorFiltro(AgendamentoDTO pAgendamentoDTO)
        {
            try
            {
                return AgendamentoDAO.SelecionarPesquisar(pAgendamentoDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable SelecionarPorFiltroPesquisar(AgendamentoDTO pAgendamentoDTO)
        {
            try
            {
                return AgendamentoDAO.Selecionar(pAgendamentoDTO);
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
                return AgendamentoDAO.SelecionarHorarios(pDt, pIdHorario);
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
                return AgendamentoDAO.SelecionarQtdFuncionarios();
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
                return AgendamentoDAO.Insere(pAgendamentoDTO);
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
                return AgendamentoDAO.Altera(pAgendamentoDTO);
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
                return AgendamentoDAO.Excluir(pAgendamentoDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #endregion
    }
}
