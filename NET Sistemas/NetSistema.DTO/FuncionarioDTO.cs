using System; 
using System.Collections.Generic;
using System.Text;


namespace NetSistema.DTO
{
    public class FuncionarioDTO 
    {
        #region Atributos

        private int cIdentificador;
        public int Identificador
        {
            get { return cIdentificador; }
            set { cIdentificador= value; }
        }

        private string cNome;
        public string Nome
        {
            get { return cNome; }
            set { cNome= value; }
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
                            