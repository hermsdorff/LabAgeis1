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
                FillPedidos();
                SetBoundsDate();
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

        public void FillPedidos()
        {
            VendaCT vendaCT = new VendaCT();
            DataTable dtVendas = vendaCT.SelecionarPorFiltro(new VendaDTO());
            grvPedidos.DataSource = dtVendas;
            grvPedidos.DataBind();
        }

        private void SetBoundsDate()
        {
            this.RangeValidator1.MinimumValue = DateTime.Today.AddDays(1).ToString("dd/MM/yyyy");
            this.RangeValidator1.MaximumValue = DateTime.Today.AddYears(1).ToString("dd/MM/yyyy");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            VendaDTO vendaDTO = new VendaDTO();
            vendaDTO.IdCliente = Convert.ToInt32(ddlCliente.SelectedValue);
            vendaDTO.IdPacote = Convert.ToInt32(ddlPacote.SelectedValue);
            vendaDTO.DataVencimentoFatura = ValidarData();
            vendaDTO.Status = ddlStatus.SelectedValue.Substring(0,1);
            vendaDTO.Observacao = txtObservacao.Text;

            PacotesCT pacoteCT = new PacotesCT();
            PacotesDTO pacoteDTO = new PacotesDTO();
            pacoteDTO.Identificador = vendaDTO.IdPacote;
            DataTable dtPacotes = pacoteCT.SelecionarPorFiltro(pacoteDTO);

            vendaDTO.ValorVenda = Convert.ToDecimal(dtPacotes.Rows[0]["VALORPACOTE"]);

            VendaCT vendaCT = new VendaCT();

            try
            {
                vendaCT.Insere(vendaDTO);
                LimparCampos();
                FillPedidos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aviso", "alert('Salvo com sucesso.');", true);
            }
            catch (Exception erro)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aviso", "alert('Erro: " + erro.Message + "');", true);
            }
            
        }

        private DateTime ValidarData()
        {
            DateTime dataVencimento = new DateTime();
            try
            { 
                dataVencimento = Convert.ToDateTime(txtVencimento.Text);
            }
            catch (FormatException ex)
            { 
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aviso", "alert('Data Inválida, selecione outra data!');", true);
            }

            return dataVencimento;
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void LimparCampos()
        {

        }

        protected void grvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {
                VendaCT vendaCT = new VendaCT();
                VendaDTO vendaDTO = new VendaDTO();
                vendaDTO.Identificador = Convert.ToInt32(e.CommandArgument);
                DataTable dtVenda = vendaCT.SelecionarPorFiltro(vendaDTO);

                if (dtVenda.Rows.Count > 0)
                {
                    DataRow drVenda = dtVenda.Rows[0];
                    this.HiddenFieldCliente.Value = drVenda["IDVENDA"].ToString();
                    this.ddlCliente.SelectedValue = drVenda["IDCLIENTE"].ToString();
                    this.ddlPacote.SelectedValue = drVenda["IDPACOTE"].ToString();
                    this.txtVencimento.Text = drVenda["DATAVENDA"].ToString();
                    this.txtObservacao.Text = drVenda["OBSERVACAO"].ToString();
                    this.ddlStatus.SelectedValue = drVenda["STATUS"].ToString();
                }
            }
            else if (e.CommandName == "excluir")
            {
                VendaCT vendaCT = new VendaCT();
                VendaDTO vendaDTO = new VendaDTO();
                vendaDTO.Identificador = Convert.ToInt32(e.CommandArgument);

                try
                {
                    vendaCT.Excluir(vendaDTO);
                    FillPedidos();
                    LimparCampos();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aviso", "alert('Excluido com sucesso.');", true);
                }
                catch (Exception erro)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aviso", "alert('Erro: " + erro.Message + "');", true);
                }

            }
        }



    }
}
