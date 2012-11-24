using System; 
using System.Collections.Generic;
using System.Text;


namespace NetSistema.DTO
{
    public class PacotesDTO 
    {
        #region Atributos

        private int cIdentificador;
        public int Identificador
        {
            get { return cIdentificador; }
            set { cIdentificador= value; }
        }

        private string cNomePacote;
        public string NomePacote
        {
            get { return cNomePacote; }
            set { cNomePacote= value; }
        }

        private string cDescPacote;
        public string DescPacote
        {
            get { return cDescPacote; }
            set { cDescPacote= value; }
        }

        private decimal cValorPacote;
        public decimal ValorPacote
        {
            get { if (cValorPacote == null )
                        return new decimal();else
                        return cValorPacote; }                                    
            set { cValorPacote= value; }
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
                            