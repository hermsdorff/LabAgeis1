using System; 
using System.Collections.Generic;
using System.Text;


namespace NetSistema.DTO
{
    public class HorarioDTO 
    {
        #region Atributos

        private int cIdentificador;
        public int Identificador
        {
            get { return cIdentificador; }
            set { cIdentificador= value; }
        }

        private string cHorario;
        public string Horario
        {
            get { return cHorario; }
            set { cHorario= value; }
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
                            