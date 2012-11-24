using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetSistema.Controller;
using NetSistema.DTO;
using System.Data.Sql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TestProjectNetSistemas
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ConversaoValorPacote()
        {
            PacotesCT pacoteCT = new PacotesCT();
            PacotesDTO pacotesDTO = new PacotesDTO();
            pacotesDTO.ValorPacote = Convert.ToDecimal("teste valor");
        }

        [TestMethod]
        [ExpectedException(typeof(MySqlException))]
        public void TesteQuantidadeDeCaracteres()
        {
            PacotesCT pacoteCT = new PacotesCT();
            PacotesDTO pacotesDTO = new PacotesDTO();
            pacotesDTO.DescPacote = "Descrição do Pacote de Teste";
            pacotesDTO.NomePacote = "Nome do Pacote de Teste Nome do Pacote de Teste Nome do Pacote de Teste Nome do Pacote de Teste";
            pacotesDTO.ValorPacote = Convert.ToDecimal("20");
            bool resultado = pacoteCT.Insere(pacotesDTO);
        }

        [TestMethod]
        public void InsercaoDePacoteValido()
        {
            PacotesCT pacoteCT = new PacotesCT();
            PacotesDTO pacotesDTO = new PacotesDTO();
            pacotesDTO.DescPacote = "Descrição do Pacote de Teste";
            pacotesDTO.NomePacote = "Nome do Pacote de Teste";
            pacotesDTO.ValorPacote = 20;
            bool resultado = pacoteCT.Insere(pacotesDTO);
            Assert.AreEqual(true, resultado);
        }



    }
}
