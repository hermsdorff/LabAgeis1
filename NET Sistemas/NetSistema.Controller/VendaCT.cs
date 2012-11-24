using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NetSistema.DTO;
using NetSistema.DAO;


namespace NetSistema.Controller
{
    public class VendaCT
    {
        #region Atributos

        public VendaDAO DAO = new VendaDAO();

        #endregion

        #region Metodos

        #region Seleção

        public DataTable SelecionarPorFiltro(VendaDTO pVendaDTO)
        {
            try
            {     
                return DAO.SelecionarPesquisar(pVendaDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
       public DataTable SelecionarPorFiltroPesquisar(VendaDTO pVendaDTO)
        {
            try
            {     
                return DAO.Selecionar(pVendaDTO);
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
                return DAO.Insere(pVendaDTO);
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
                return DAO.Altera(pVendaDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
       }   
                

        #endregion
        
        #region Exclusao
        
        public Boolean Excluir(VendaDTO pVendaDTO)
        {   
            try
            {     
                return DAO.Excluir(pVendaDTO);
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
