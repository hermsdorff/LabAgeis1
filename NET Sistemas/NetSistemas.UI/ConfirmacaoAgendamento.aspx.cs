using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NetSistema.Controller;
using NetSistema.DTO;
using System.Globalization;

namespace NET_Sistemas
{
    public partial class ConfirmacaoAgendamento : System.Web.UI.Page
    {
        String PaginaDeAgendamento = "SelecionarAgendamento.aspx";
        String data = "";
        String idHorario = "";
        String idVenda = "";
        public static string[] formatos = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "" };

        protected void Page_Load(object sender, EventArgs e)
        {
            data = Request.QueryString["data"];
            idHorario = Request.QueryString["idHorario"];
            idVenda = Request.QueryString["idVenda"];
            if (data == null || idHorario == null || idVenda == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Dados para agendamento incompletos!'); window.location.href='"+PaginaDeAgendamento+"';", true);
            }
            else
            {
                AgendamentoCT agendamentoCT = new AgendamentoCT();
                DataTable dtFuncionariosDisponiveis = agendamentoCT.SelecionarPorFiltroDataHorario(data, idHorario);
                if (dtFuncionariosDisponiveis.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Funcionário indisponível para agendamento!'); window.location.href='" + PaginaDeAgendamento + "';", true);
                }
                else
                {
                    ddlFuncionario.DataSource = dtFuncionariosDisponiveis;
                    ddlFuncionario.DataValueField = "idFuncionario";
                    ddlFuncionario.DataTextField = "nome";
                    ddlFuncionario.DataBind();
                    HorarioCT horarioCT = new HorarioCT();
                    HorarioDTO horarioDTO = new HorarioDTO();
                    horarioDTO.Identificador = Convert.ToInt32(idHorario);
                    DataTable dtHorario = horarioCT.SelecionarPorFiltro(horarioDTO);
                    if (dtHorario.Rows.Count > 0)
                    {
                        txtHorario.Text = FormataHorario(dtHorario.Rows[0]["horario"].ToString());
                    }
                    txtData.Text = data;
                }
            }

        }

        private string FormataHorario(string p)
        {
            String texto = p;
            if (p.Length == 1 || p.Length == 2)
                texto += ":00 - " + (Convert.ToInt32(p) + 1) + ":59";
            return texto;
        }

        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            AgendamentoDTO agendamentoDTO = new AgendamentoDTO();
            AgendamentoCT agendamentoCT = new AgendamentoCT();

            try
            {
                agendamentoDTO.IdVenda = Convert.ToInt32(idVenda);
                agendamentoDTO.IdFuncionario = Convert.ToInt32(ddlFuncionario.SelectedValue);
                agendamentoDTO.IdHorario = Convert.ToInt32(idHorario);
                if (valida(0, data))
                {
                    agendamentoDTO.DataAgendamento = Convert.ToDateTime(data);
                    if (agendamentoCT.Insere(agendamentoDTO))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Agendamento incluído!'); window.location.href='" + PaginaDeAgendamento + "';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Erro ao incluir agendamento. Verifique a data informada!'); window.location.href='" + PaginaDeAgendamento + "';", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('Erro ao incluir agendamento. Verifique os dados informados!');", true);
            }
        }
   
        private bool valida(int index, string data)
        {
            if (ConfirmacaoAgendamento.formatos[index].Equals(string.Empty))
                return false;
            try
            {
                DateTime dt = DateTime.ParseExact(data, ConfirmacaoAgendamento.formatos[index], CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception e)
            {
                return valida(index + 1, data);
            }
        }
    }
}