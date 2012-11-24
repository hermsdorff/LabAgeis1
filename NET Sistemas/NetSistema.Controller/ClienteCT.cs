using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NetSistema.DTO;
using NetSistema.DAO;


namespace NetSistema.Controller
{
    public class ClienteCT 
    {
        #region Atributos

        public ClienteDAO DAO = new ClienteDAO();

        #endregion

        #region Metodos

        #region Seleção

        public DataTable SelecionarPorFiltro(ClienteDTO pClienteDTO)
        {
            try
            {     
                return DAO.SelecionarPesquisar(pClienteDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
       public DataTable SelecionarPorFiltroPesquisar(ClienteDTO pClienteDTO)
        {
            try
            {     
                return DAO.Selecionar(pClienteDTO);
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
                return DAO.Insere(pClienteDTO);
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
                return DAO.Altera(pClienteDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
       }   
                

        #endregion
        
        #region Exclusao
        
        public Boolean Excluir(ClienteDTO pClienteDTO)
        {   
            try
            {     
                return DAO.Excluir(pClienteDTO);
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
