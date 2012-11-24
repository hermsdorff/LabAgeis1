using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NetSistema.DTO;
using NetSistema.DAO;


namespace NetSistema.Controller
{
    public class PacotesCT 
    {
        #region Atributos

        public PacotesDAO DAO = new PacotesDAO();
       
        #endregion

        #region Metodos

        #region Seleção

        public DataTable SelecionarPorFiltro(PacotesDTO pPacotesDTO)
        {
            try
            {     
                return DAO.SelecionarPesquisar(pPacotesDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
       public DataTable SelecionarPorFiltroPesquisar(PacotesDTO pPacotesDTO)
        {
            try
            {     
                return DAO.Selecionar(pPacotesDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Inserção

        public Boolean Insere(PacotesDTO pPacotesDTO)
        {
            try
            {     
                return DAO.Insere(pPacotesDTO);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion

        #region Atualização
    

        public Boolean Altera(PacotesDTO pPacotesDTO)
        {
            try
            {     
                return DAO.Altera(pPacotesDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
       }   
                

        #endregion
        
        #region Exclusao
        
        public Boolean Excluir(PacotesDTO pPacotesDTO)
        {   
            try
            {     
                return DAO.Excluir(pPacotesDTO);
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
