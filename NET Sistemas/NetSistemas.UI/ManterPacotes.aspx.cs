using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetSistema.Controller;
using NetSistema.DTO;
using System.Data;

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
            if (!Page.IsPostBack)
            {
                FillClientes();
            }
        }

        public void FillClientes()
        {
            pacoteCT = new PacotesCT();
            DataTable dtPacote = pacoteCT.SelecionarPorFiltro(new PacotesDTO());
            grvPacote.DataSource = dtPacote;
            grvPacote.DataBind();
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

                if (!String.IsNullOrEmpty(txtIdPacote.Value))
                {
                    pacoteDTO.Identificador = Convert.ToInt32(txtIdPacote.Value);
                    if (pacoteCT.Altera(pacoteDTO))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Pacote Alterado com Sucesso!!!')", true);
                        Response.Redirect("~/ManterPacotes.aspx");
                    }
                }

                else if (pacoteCT.Insere(pacoteDTO))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Pacote Inserido com Sucesso!!!')", true);
                    Response.Redirect("~/ManterPacotes.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Erro ao Inserir o Pacote:\n"+ex.Message+"')", true);
            }



        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }


        protected void grvPacote_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {
                pacoteCT = new PacotesCT();
                pacoteDTO = new PacotesDTO();
                txtIdPacote.Value = e.CommandArgument.ToString();
                DataTable dtPacotes = pacoteCT.SelecionarPorFiltro(pacoteDTO);

                if (dtPacotes.Rows.Count > 0)
                {
                    DataRow drCliente = dtPacotes.Rows[0];
                    pacoteDTO.Identificador = Convert.ToInt32(drCliente["IDPACOTES"].ToString());
                    txtNome.Text = drCliente["NOMEPACOTE"].ToString();
                    txtDescricao.Text = drCliente["DESCPACOTE"].ToString();
                    txtValor.Text = drCliente["VALORPACOTE"].ToString();

                }
            }
            else if (e.CommandName == "excluir")
            {   
                pacoteCT = new PacotesCT();
                pacoteDTO = new PacotesDTO();
                pacoteDTO.Identificador = Convert.ToInt32(e.CommandArgument);

                try
                {

                    if (pacoteCT.Excluir(pacoteDTO))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Pacote Excluido com Sucesso!!!')", true);
                        Response.Redirect("~/ManterPacotes.aspx");
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Aviso", "alert('Erro ao Excluir o Pacote:\n" + ex.Message + "')", true);
                }

                
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