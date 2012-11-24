using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetSistema.DTO;
using NetSistema.Controller;
using System.Data;

namespace NET_Sistemas
{
    public partial class Venda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillClientes();
                FillPacotes();
            }
        }

        public void FillClientes(){
            ClienteCT clienteCT = new ClienteCT();
            DataTable dtClientes = clienteCT.SelecionarPorFiltro(new ClienteDTO());
            ddlCliente.DataSource = dtClientes;
            ddlCliente.DataValueField = "IDCLIENTE";
            ddlCliente.DataTextField = "NOME";
            ddlCliente.DataBind();
        }

        public void FillPacotes()
        {
            PacotesCT pacotesCT = new PacotesCT();
            DataTable dtPacotes = pacotesCT.SelecionarPorFiltro(new PacotesDTO());
            ddlPacote.DataSource = dtPacotes;
            ddlPacote.DataValueField = "IDPACOTES";
            ddlPacote.DataTextField = "NOMEPACOTE";
            ddlPacote.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            VendaDTO vendaDTO = new VendaDTO();
            vendaDTO.IdCliente = Convert.ToInt32(ddlCliente.SelectedValue);
            vendaDTO.IdPacote = Convert.ToInt32(ddlPacote.SelectedValue);
            vendaDTO.DataVencimentoFatura = Convert.ToDateTime(txtVencimento.Text);
            vendaDTO.Status = ddlStatus.SelectedValue.Substring(0,1);
            vendaDTO.Observacao = txtVencimento.Text;

            PacotesCT pacoteCT = new PacotesCT();
            PacotesDTO pacoteDTO = new PacotesDTO();
            pacoteDTO.Identificador = vendaDTO.IdPacote;
            DataTable dtPacotes = pacoteCT.SelecionarPorFiltro(pacoteDTO);

            vendaDTO.ValorVenda = Convert.ToDecimal(dtPacotes.Rows[0]["VALORPACOTE"]);

            VendaCT vendaCT = new VendaCT();

            try
            {
                vendaCT.Insere(vendaDTO);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aviso", "Salvo com sucesso.", true);
            }
            catch (Exception erro)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aviso", "Erro: " + erro.Message, true);
            }
            
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {

        }

    }
}
