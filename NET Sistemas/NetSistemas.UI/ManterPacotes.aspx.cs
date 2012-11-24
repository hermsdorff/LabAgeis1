using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetSistema.Controller;
using NetSistema.DTO;

namespace NET_Sistemas
{
    public partial class ManterPacotes : System.Web.UI.Page
    {

        #region Atributos
        PacotesCT pacoteCT = new PacotesCT();
        PacotesDTO pacoteDTO = new PacotesDTO();

        #endregion

        #region Metodos da Classe

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!CriteriosValidos())
            {
                return;
            }
            
            try
            {
                pacoteDTO.NomePacote = txtNome.Text;
                pacoteDTO.DescPacote = txtDescricao.Text;
                pacoteDTO.ValorPacote = Convert.ToDecimal(txtValor.Text);

                if (pacoteCT.Insere(pacoteDTO))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Pacote Inserido com Sucesso!!!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Erro ao Inserir o Pacote:\n"+ex.Message+"')", true);
            }



        }

        #endregion

        #region Metodos

        public bool CriteriosValidos()
        {
            if (String.IsNullOrEmpty(txtNome.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Informe o NOME do Pacote!!')", true);
                txtNome.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtDescricao.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Informe a DESCRIÇÃO do Pacote!!!')", true);
                txtDescricao.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtValor.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Informe o VALOR do Pacote!!!')", true);
                txtValor.Focus();
                return false;
            }
            else
                if (!String.IsNullOrEmpty(txtValor.Text))
                {
                    try
                    {
                        Convert.ToDecimal(txtValor.Text);
                    }
                    catch (Exception)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Informe um valor Correto para o Pacote!!!')", true);
                        return false;
                    }    
                    
                    
                }

            return true;
        }

        #endregion

    }
}