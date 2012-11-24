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
            clienteDTO.Bairro = txtLogradouro.Text;
            clienteDTO.Numero = txtNumero.Text;
            clienteDTO.Cep = txtCEP.Text;
            clienteDTO.Cidade = txtCidade.Text;
            clienteDTO.Uf = ddlEstado.SelectedValue;

            try
            {
                clienteCT.Insere(clienteDTO);
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

        protected void grvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editar")
            {

            }
            else if (e.CommandName == "excluir")
            {
                ClienteCT clienteCT = new ClienteCT();
                ClienteDTO clienteDTO = new ClienteDTO();
                clienteDTO.Identificador = Convert.ToInt32(e.CommandArgument);
                DataTable dtCliente = clienteCT.SelecionarPorFiltro(clienteDTO);

                if (dtCliente.Rows.Count > 0)
                {
                    DataRow drCliente = dtCliente.Rows[0];
                    clienteDTO.Identificador = Convert.ToInt32(drCliente["IDCLIENTE"].ToString());
                    txtNome.Text = drCliente["NOME"].ToString();
                    ddlTipo.SelectedValue = drCliente["TIPOCLIENTE"].ToString();
                    txtCPFCNPJ.Text = drCliente["CPFCNPJ"].ToString();
                    txtLogradouro.Text = drCliente["LOGRADOURO"].ToString();
                    txtBairro.Text = drCliente["BAIRRO"].ToString();
                    txtNumero.Text = drCliente["NUMERO"].ToString();
                    txtCEP.Text = drCliente["CEP"].ToString();
                    txtCidade.Text = drCliente["CIDADE"].ToString();
                    ddlEstado.SelectedValue = drCliente["UF"].ToString();
                }
            }
        }

    }
}
