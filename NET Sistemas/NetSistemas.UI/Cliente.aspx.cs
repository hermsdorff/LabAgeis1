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
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillClientes();
            }
        }

        public void FillClientes(){
            ClienteCT clienteCT = new ClienteCT();
            DataTable dtClientes = clienteCT.SelecionarPorFiltro(new ClienteDTO());
            grvClientes.DataSource = dtClientes;
            grvClientes.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            ClienteCT clienteCT = new ClienteCT();
            ClienteDTO clienteDTO = new ClienteDTO();
            clienteDTO.Nome = txtNome.Text;
            clienteDTO.TipoPessoa = ddlTipo.SelectedValue;
            clienteDTO.Cpjcnpj = txtCPFCNPJ.Text;
            clienteDTO.Logradouro = txtLogradouro.Text;
            clienteDTO.Complemento= txtComplemento.Text;
            clienteDTO.Bairro = txtLogradouro.Text;
            clienteDTO.Numero = txtNumero.Text;
            clienteDTO.Cep = txtCEP.Text;
            clienteDTO.Cidade = txtCidade.Text;
            clienteDTO.Uf = ddlEstado.SelectedValue;

            try
            {
                if (txtidcliente.Value == "")
                {
                    clienteCT.Insere(clienteDTO);
                }
                else if (txtidcliente.Value != "")
                {
                    clienteDTO.Identificador = Convert.ToInt32(txtidcliente.Value);
                    clienteCT.Altera(clienteDTO);
                }
                FillClientes();
                LimparCampos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aviso", "alert('Salvo com sucesso.');", true);
            }
            catch (Exception erro)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aviso", "alert('Erro: " + erro.Message + "');", true);
            }
            
        }

        public void LimparCampos()
        {
            txtidcliente.Value = "";
            txtNome.Text = "";
            ddlTipo.SelectedIndex = 0;
            txtCPFCNPJ.Text = "";
            txtLogradouro.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtNumero.Text = "";
            txtCEP.Text = "";
            txtCidade.Text = "";
            ddlEstado.SelectedIndex = 0;
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        protected void grvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {
                ClienteCT clienteCT = new ClienteCT();
                ClienteDTO clienteDTO = new ClienteDTO();
                clienteDTO.Identificador = Convert.ToInt32(e.CommandArgument);
                DataTable dtCliente = clienteCT.SelecionarPorFiltro(clienteDTO);

                if (dtCliente.Rows.Count > 0)
                {
                    DataRow drCliente = dtCliente.Rows[0];
                    txtidcliente.Value = drCliente["IDCLIENTE"].ToString();
                    txtNome.Text = drCliente["NOME"].ToString();
                    ddlTipo.SelectedValue = drCliente["TIPOPESSOA"].ToString();
                    txtCPFCNPJ.Text = drCliente["CPJCNPJ"].ToString();
                    txtLogradouro.Text = drCliente["LOGRADOURO"].ToString();
                    txtComplemento.Text = drCliente["COMPLEMENTO"].ToString();
                    txtBairro.Text = drCliente["BAIRRO"].ToString();
                    txtNumero.Text = drCliente["NUMERO"].ToString();
                    txtCEP.Text = drCliente["CEP"].ToString();
                    txtCidade.Text = drCliente["CIDADE"].ToString();
                    ddlEstado.SelectedValue = drCliente["UF"].ToString();
                }
            }
            else if (e.CommandName == "excluir")
            {
                ClienteCT clienteCT = new ClienteCT();
                ClienteDTO clienteDTO = new ClienteDTO();
                clienteDTO.Identificador = Convert.ToInt32(e.CommandArgument);

                try
                {
                    clienteCT.Excluir(clienteDTO);
                    FillClientes();
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
