using System; 
using System.Collections.Generic;
using System.Text;


namespace NetSistema.DTO
{
    public class ClienteDTO 
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

        private string cLogradouro;
        public string Logradouro
        {
            get { return cLogradouro; }
            set { cLogradouro= value; }
        }

        private string cNumero;
        public string Numero
        {
            get { return cNumero; }
            set { cNumero= value; }
        }

        private string cComplemento;
        public string Complemento
        {
            get { return cComplemento; }
            set { cComplemento= value; }
        }

        private string cBairro;
        public string Bairro
        {
            get { return cBairro; }
            set { cBairro= value; }
        }

        private string cCidade;
        public string Cidade
        {
            get { return cCidade; }
            set { cCidade= value; }
        }

        private string cUf;
        public string Uf
        {
            get { return cUf; }
            set { cUf= value; }
        }

        private string cCep;
        public string Cep
        {
            get { return cCep; }
            set { cCep= value; }
        }

        private string cTelefone;
        public string Telefone
        {
            get { return cTelefone; }
            set { cTelefone= value; }
        }

        private string cCpjcnpj;
        public string Cpjcnpj
        {
            get { return cCpjcnpj; }
            set { cCpjcnpj= value; }
        }

        private string cTipoPessoa;
        public string TipoPessoa
        {
            get { return cTipoPessoa; }
            set { cTipoPessoa = value; }
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
                            