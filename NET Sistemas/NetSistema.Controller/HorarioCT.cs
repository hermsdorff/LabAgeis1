using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NetSistema.DTO;
using NetSistema.DAO;


namespace NetSistema.Controller
{
    public class HorarioCT 
    {
        #region Atributos

        public HorarioDAO HorarioDAO = new HorarioDAO();

        #endregion

        #region Metodos

        #region Seleção

        public DataTable SelecionarPorFiltro(HorarioDTO pHorarioDTO)
        {
            try
            {
                return HorarioDAO.SelecionarPesquisar(pHorarioDTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable SelecionarPorFiltroPesquisar(HorarioDTO pHorarioDTO)
        {
            try
            {
                return HorarioDAO.Selecionar(pHorarioDTO);
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
                return HorarioDAO.Insere(pHorarioDTO);
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
                return HorarioDAO.Altera(pHorarioDTO);
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
                return HorarioDAO.Excluir(pHorarioDTO);
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
