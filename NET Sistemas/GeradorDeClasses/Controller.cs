using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeradorDeClasses
{
    public class Controller
    {
        Periferica peri = new Periferica();
        public string GerarClasseCTs(string conexao, string tabela, string nomeProjeto)
        {
            //string[] item;// = new string[,];
            //string nomeColuna;
            //string tipoColuna;
            string classe = string.Empty;
            //List<string> list = peri.BuscarColunasTabela(conexao, tabela);
            string tabelaSemLixo = peri.RetiraLixoNomeTabela(tabela);
            string colunaIdentificador = peri.cColunaIdentificador;

            classe = @"using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using " + nomeProjeto + @".DTO;
using " + nomeProjeto + @".DAO;


namespace " + nomeProjeto + @".Controller
{
    public class " + tabelaSemLixo + @"CT 
    {
        #region Atributos

        public " + tabelaSemLixo + @"DAO " + tabelaSemLixo + @"DAO = new " + tabelaSemLixo + @"DAO();

        #endregion

        #region Metodos

        #region Seleção

        public DataTable Selecionar" + tabelaSemLixo + @"PorFiltro(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO)
        {
            try
            {     
                return " + tabelaSemLixo + @"DAO.Selecionar" + tabelaSemLixo + @"Pesquisar(p" + tabelaSemLixo + @"DTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
       public DataTable Selecionar" + tabelaSemLixo + @"PorFiltroPesquisar(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO)
        {
            try
            {     
                return " + tabelaSemLixo + @"DAO.Selecionar" + tabelaSemLixo + @"(p" + tabelaSemLixo + @"DTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region Inserção

        public Boolean Insere" + tabelaSemLixo + @"(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO)
        {
            try
            {     
                return " + tabelaSemLixo + @"DAO.Insere" + tabelaSemLixo + @"(p" + tabelaSemLixo + @"DTO);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion

        #region Atualização
    

        public Boolean Altera" + tabelaSemLixo + @"(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO)
        {
            try
            {     
                return " + tabelaSemLixo + @"DAO.Altera" + tabelaSemLixo + @"(p" + tabelaSemLixo + @"DTO);
            }
            catch (Exception e)
            {
                throw e;
            }
       }";

      
                
            classe = classe + @"   
                

        #endregion
        
        #region Exclusao
        
        public Boolean Excluir" + tabelaSemLixo + @"(" + tabelaSemLixo + @"DTO p" + tabelaSemLixo + @"DTO)
        {   
            try
            {     
                return " + tabelaSemLixo + @"DAO.Excluir" + tabelaSemLixo + @"(p" + tabelaSemLixo + @"DTO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #endregion
    }
}
";

            return classe;
        } 
    }
}
