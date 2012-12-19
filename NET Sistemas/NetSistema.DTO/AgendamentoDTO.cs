using System; 
using System.Collections.Generic;
using System.Text;


namespace NetSistema.DTO
{
    public class AgendamentoDTO 
    {
        #region Atributos

        private int cIdentificador;
        public int Identificador
        {
            get { return cIdentificador; }
            set { cIdentificador= value; }
        }

        private int cIdVenda;
        public int IdVenda
        {
            get { return cIdVenda; }
            set { cIdVenda= value; }
        }

        private int cIdFuncionario;
        public int IdFuncionario
        {
            get { return cIdFuncionario; }
            set { cIdFuncionario= value; }
        }

        private DateTime cDataAgendamento;
        public DateTime DataAgendamento
        {
            get { return cDataAgendamento; }
            set { cDataAgendamento= value; }
        }

        private int cIdHorario;
        public int IdHorario
        {
            get { return cIdHorario; }
            set { cIdHorario= value; }
        } 
        
        public string cUsuarioInclusao;
        public string UsuarioInclusao
        {
            get { return cUsuarioInclusao; }
            set { cUsuarioInclusao = value; }
        }


        public string cUsuarioAlteracao;
        public string UsuarioAlteracao
        {
            get { return cUsuarioAlteracao; }
            set { cUsuarioAlteracao = value; }
        }


        #endregion

    }
}
                            