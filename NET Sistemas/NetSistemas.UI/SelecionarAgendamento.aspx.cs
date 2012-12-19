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
    public partial class SelecionarAgendamento : System.Web.UI.Page
    {
        AgendamentoCT agendamentoCT = new AgendamentoCT();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.TxtData.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                FillClientes();
            }
        }

        public void FillClientes()
        {
            DataTable DataDisponiveis = new DataTable();
            DataDisponiveis.Columns.Add("IdHorario",typeof(int)) ;
            DataDisponiveis.Columns.Add("HorarioDesc", typeof(string));

            #region idHorario 1
            //se existe mais de um agendamento para aqula data e pra aquele idHorario 1
            if (agendamentoCT.SelecionarHorarios(Convert.ToDateTime(TxtData.Text), 1) > 0)
            {
                //pego a quantidade de horarios que existe na tabela agendamento e comparo com a qtd de funcionario que tem  
                int qtdHorarios = agendamentoCT.SelecionarHorarios(Convert.ToDateTime(TxtData.Text), 1);

                if (agendamentoCT.SelecionarQtdFuncionarios() < qtdHorarios)
                {
                    DataDisponiveis.Rows.Add();
                    DataDisponiveis.Rows[DataDisponiveis.Rows.Count - 1]["IdHorario"] = 1;
                    DataDisponiveis.Rows[DataDisponiveis.Rows.Count - 1]["HorarioDesc"] = "08:00 a 09:59";
                }
            }
            else
            {
                DataDisponiveis.Rows.Add();
                DataDisponiveis.Rows[DataDisponiveis.Rows.Count - 1]["IdHorario"] = 1;
                DataDisponiveis.Rows[DataDisponiveis.Rows.Count - 1]["HorarioDesc"] = "08:00 a 09:59";

            }

            #endregion

            // dar continuidade com o id 2 3 e 4 e depois addcionar o datatable no grid e passar o idvenda a dataagendamento e o idHoario que vira do grid para a tela do Diego

            agendamentoCT = new AgendamentoCT();
            DataTable dtAgendamento = agendamentoCT.SelecionarPorFiltro(new AgendamentoDTO());
            GridView1.DataSource = dtAgendamento;
            GridView1.DataBind();
        }

        protected void BtnMais_Click(object sender, EventArgs e)
        {
            MudarData(next: true);
        }

        protected void BtnMenos_Click(object sender, EventArgs e)
        {
            MudarData(next: false);
        }

        private void MudarData(bool next)
        { 
            DateTime data = Convert.ToDateTime(this.TxtData.Text);
            if (next)
                data = data.AddDays(1);
            else
                data = data.AddDays(-1);

            this.TxtData.Text = data.ToString("dd/MM/yyyy");
        }

    }
}