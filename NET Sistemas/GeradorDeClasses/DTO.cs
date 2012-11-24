using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeradorDeClasses
{
    public class DTO
    {
        Periferica peri = new Periferica();
        public string GerarClasseDTO(string conexao, string tabela, string nomeProjeto)
        {
            string[] item;// = new string[,];
            string tabelaClasse = peri.RetiraLixoNomeTabela(tabela);
            List<string> list = peri.BuscarColunasTabela(conexao, tabela);

            string classe = @"using System; 
using System.Collections.Generic;
using System.Text;


namespace " + nomeProjeto + @".DTO
{
    public class " + tabelaClasse + @"DTO 
    {
        #region Atributos";


            for (int i = 0; i < list.Count; i++)
            {
                item = list[i].ToString().Split(';');
                item[1] = peri.TratarTipos(item[1].ToString());
                switch (item[1].ToString().ToUpper())
                {
                    case "DATETIME":
                        classe = classe + @"

        private DateTime c" + item[2].ToString() + @";
        public DateTime " + item[2].ToString() + @"
        {
            get { return c" + item[2].ToString() + @"; }
            set { c" + item[2].ToString() + @"= value; }
        }";
                        break;
                    case "INT":
                        classe = classe + @"

        private int c" + item[2].ToString() + @";
        public int " + item[2].ToString() + @"
        {
            get { return c" + item[2].ToString() + @"; }
            set { c" + item[2].ToString() + @"= value; }
        }";
                        break;
                    case "STRING":
                        classe = classe + @"

        private string c" + item[2].ToString() + @";
        public string " + item[2].ToString() + @"
        {
            get { return c" + item[2].ToString() + @"; }
            set { c" + item[2].ToString() + @"= value; }
        }";
                        break;
                    case "DOUBLE":
                        classe = classe + @"

        private double c" + item[2].ToString() + @";
        public double " + item[2].ToString() + @"
        {
            get { return c" + item[2].ToString() + @"; }
            set { c" + item[2].ToString() + @"= value; }
        }";
                        break;
                    case "BYTE":
                        classe = classe + @"

        private byte c" + item[2].ToString() + @";
        public byte " + item[2].ToString() + @"
        {
            get { return c" + item[2].ToString() + @"; }
            set { c" + item[2].ToString() + @"= value; Modificada = true; }
        }";
                        break;
                    default:
                        classe = classe + @"

        private " + item[1].ToString() + " c" + item[2].ToString() + @";
        public " + item[1].ToString() + " " + item[2].ToString() + @"
        {
            get { if (c" + item[2].ToString() + @" == null )
                        return new " + item[1].ToString() + "();" +
                 @"else
                        return c" + item[2].ToString() + @"; }                                    
            set { c" + item[2].ToString() + @"= value; }
        }";
                        break;

                }
            }

            classe = classe + @" 
        
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
                            ";

            return classe;
        }
    }
}
