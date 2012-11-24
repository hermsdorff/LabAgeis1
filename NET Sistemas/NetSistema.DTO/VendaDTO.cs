using System; 
using System.Collections.Generic;
using System.Text;


namespace NetSistema.DTO
{
    public class VendaDTO 
    {
        #region Atributos

        private int cIdentificador;
        public int Identificador
        {
            get { return cIdentificador; }
            set { cIdentificador= value; }
        }

        private int cIdCliente;
        public int IdCliente
        {
            get { return cIdCliente; }
            set { cIdCliente= value; }
        }

        private int cIdPacote;
        public int IdPacote
        {
            get { return cIdPacote; }
            set { cIdPacote= value; }
        }

        private DateTime cDataVenda;
        public DateTime DataVenda
        {
            get { return cDataVenda; }
            set { cDataVenda= value; }
        }

        private DateTime cDataVencimentoFatura;
        public DateTime DataVencimentoFatura
        {
            get { return cDataVencimentoFatura; }
            set { cDataVencimentoFatura= value; }
        }

        private decimal cValorVenda;
        public decimal ValorVenda
        {
            get { if (cValorVenda == null )
                        return new decimal();else
                        return cValorVenda; }                                    
            set { cValorVenda= value; }
        }

        private string cStatus;
        public string Status
        {
            get { return cStatus; }
            set { cStatus= value; }
        }

        private string cObservacao;
        public string Observacao
        {
            get { return cObservacao; }
            set { cObservacao= value; }
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
                            