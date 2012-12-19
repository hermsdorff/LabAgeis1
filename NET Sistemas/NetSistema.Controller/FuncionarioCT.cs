using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NetSistema.DTO;
using NetSistema.DAO;


namespace NetSistema.Controller
{
    public class FuncionarioCT 
    {
        #region Atributos

        public FuncionarioDAO DAO = new FuncionarioDAO();

        #endregion

        #region Metodos

        #region Seleção

        public DataTable SelecionarPorFiltro(FuncionarioDTO pFuncionarioDTO)
        {
            try
            {
                return DAO.SelecionarPesquisar(pFuncionarioDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable SelecionarPorFiltroPesquisar(FuncionarioDTO pFuncionarioDTO)
        {
            try
            {
                return DAO.Selecionar(pFuncionarioDTO);
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
                return DAO.Insere(pFuncionarioDTO);
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
                return DAO.Altera(pFuncionarioDTO);
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
                return DAO.Excluir(pFuncionarioDTO);
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
