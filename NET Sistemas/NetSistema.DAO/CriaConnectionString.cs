using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace NetSistema.DAO
{
    public class CriaConnectionString
    {
        private string Servidor = string.Empty;
        private string Banco = string.Empty;
        private string Usuario = string.Empty;
        private string Senha = string.Empty;
        private string ConnectionString = string.Empty;

        public CriaConnectionString()
        {
            Servidor = System.Configuration.ConfigurationSettings.AppSettings["pServidorBD"];
            Usuario = System.Configuration.ConfigurationSettings.AppSettings["pUsuarioBd"];
            Senha = System.Configuration.ConfigurationSettings.AppSettings["pSenhaBd"];
        }

        /// <summary>
        ///     Método que cria a String de Coneção do Banco de Dados de Produção
        /// </summary>
        /// <returns>ConnectionString do BD de Produção</returns>
        //public string GetConnectionStringProd(int Id_Empresa)
        //{
        //    Banco = getBancoProducao(Id_Empresa);
        //    ConnectionString = "Data Source=" + Servidor + ";Initial Catalog=" + Banco + ";User ID=" + Usuario + ";Password=" + Senha;
        //    return ConnectionString;
        //}
        /// <summary>
        ///     Método que cria a String de Coneção do Banco de Dados de Produção
        /// </summary>
        /// <returns>ConnectionString do BD de Produção</returns>
        public string GetConnectionStringProd()
        {
            Banco = System.Configuration.ConfigurationSettings.AppSettings["pNomeBdProducao"];
            ConnectionString = "server =" + Servidor + "; user id = " + Usuario + "; password = " + Senha + "; database =" + Banco + ";";
            //ConnectionString = "Data Source=" + Servidor + ";Initial Catalog=" + Banco + ";User ID=" + Usuario + ";Password=" + Senha;
            return ConnectionString;
        }
    }
}

