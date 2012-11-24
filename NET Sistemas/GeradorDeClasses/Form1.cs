using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using XCoolForm;
//using XCoolFormTest;

namespace GeradorDeClasses
{
    public partial class Form1 : Form
    {
        //private XmlThemeLoader xtl = new XmlThemeLoader();
        string nomeArquivoEntidade = string.Empty;
        string nomeArquivoDAO = string.Empty;
        string nomeArquivoMAPPER = string.Empty;
        string nomeArquivoCONSTANTESDB = string.Empty;
        string nomeArquivoDTO = string.Empty;
        string nomeArquivoCT = string.Empty;
        string ColunaIdentificador = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRowView itemChecked in ddlTabelas.CheckedItems)
                {
                    CriarClasses(txtNomeProjeto.Text, txtCaminhoProjeto.Text, txtConn.Text, itemChecked.Row.ItemArray.GetValue(0).ToString());
                }

                MessageBox.Show("Classes criadas com sucesso com Sucesso!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    MessageBox.Show("Erro ao Criar Classes:\nVeja: " + ex.InnerException);
                }

                else
                {
                    MessageBox.Show("Erro ao Criar Classes:\nVeja: " + ex.Message);
                }
            }
        }


        public void CriarClasses(string pNomeProjeto, string pCaminhoProjeto, string pConexao, string pTabela)
        {
            try
            {
                Periferica peri = new Periferica();
                //Entidade ent = new Entidade();
                //Constantes constantes = new Constantes();
                DTO dto = new DTO();
                DAOs daos = new DAOs();
                Controller controller = new Controller();
                //Mapper mappers = new Mapper();
                List<string> listLocalSalv = new List<string>();
                string retDTO = String.Empty;
                string retDAO = String.Empty;
                string retCT = String.Empty;

                string nomeProjeto = pNomeProjeto != string.Empty ? pNomeProjeto : comboBox1.SelectedItem.ToString();
                //nomeProjeto = nomeProjeto;

                //string retEnt = ent.GerarClasseEntidade(pConexao, pTabela, nomeProjeto);
                //string retConstantes = constantes.GerarClasseConstantesDB(pConexao, pTabela, nomeProjeto);
                if (cbDTO.Checked == true)
                {
                    retDTO = dto.GerarClasseDTO(pConexao, pTabela, nomeProjeto);
                }

                if (cbDAO.Checked == true)
                {
                    retDAO = daos.GerarClasseDAOs(pConexao, pTabela, nomeProjeto);
                }

                if (cbController.Checked == true)
                {
                    retCT = controller.GerarClasseCTs(pConexao, pTabela, nomeProjeto);
                }

                //string retMAPPER = mappers.GerarClasseConstantesDB(pConexao, pTabela, nomeProjeto);
                string path = string.Empty;

                //nomeArquivoEntidade = peri.RetiraLixoNomeTabela(pTabela) + "Entidade.cs";
                nomeArquivoDAO = peri.RetiraLixoNomeTabela(pTabela) + "DAO.cs";
                nomeArquivoDTO = peri.RetiraLixoNomeTabela(pTabela) + "DTO.cs";
                nomeArquivoCT = peri.RetiraLixoNomeTabela(pTabela) + "CT.cs";
                //nomeArquivoMAPPER = peri.RetiraLixoNomeTabela(pTabela) + "Mapper.cs";

                if (!Directory.Exists(pCaminhoProjeto))
                    Directory.CreateDirectory("D:\\GeradorClasses");

                if (pCaminhoProjeto == "D:\\GeradorClasses" || pCaminhoProjeto == string.Empty)
                {
                    path = "D:\\GeradorClasses\\";
                }
                else
                {
                    path = pCaminhoProjeto + "\\";
                }

                //if (File.Exists(path + nomeProjeto + ".Entidades\\" + nomeArquivoEntidade))
                //    nomeArquivoEntidade = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + nomeArquivoEntidade + "Entidade.cs";

                if (File.Exists(path + nomeProjeto + ".DAO\\" + nomeArquivoDAO))
                    nomeArquivoDAO = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + pTabela + "DAO.cs";

                if (File.Exists(path + nomeProjeto + ".DTO\\" + nomeArquivoDTO))
                    nomeArquivoDTO = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + pTabela + "DTO.cs";

                if (File.Exists(path + nomeProjeto + ".Controller\\" + nomeArquivoCT))
                    nomeArquivoCT = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + pTabela + "CT.cs";



                StreamWriter stre;

                if (Directory.Exists(path + nomeProjeto + ".DAO\\"))
                {
                    stre = new StreamWriter(path + nomeProjeto + ".DAO\\" + nomeArquivoDAO);
                    listLocalSalv.Add(path + nomeProjeto + ".DAO\\" + nomeArquivoDAO);
                }
                else
                {
                    stre = new StreamWriter(path + nomeArquivoDAO);
                    listLocalSalv.Add(path + nomeProjeto + ".DAO\\" + nomeArquivoDAO);
                }

                if (cbDAO.Checked == true)
                {

                    stre.Write(retDAO);
                }

                stre.Close();


                if (Directory.Exists(path + nomeProjeto + ".DTO\\"))
                {
                    stre = new StreamWriter(path + nomeProjeto + ".DTO\\" + nomeArquivoDTO);
                    listLocalSalv.Add(path + nomeProjeto + ".DTO\\" + nomeArquivoDTO);
                }
                else
                {
                    stre = new StreamWriter(path + nomeArquivoDTO);
                    listLocalSalv.Add(path + nomeArquivoDTO);
                }


                if (cbDTO.Checked == true)
                {

                    stre.Write(retDTO);
                }

                stre.Close();


                if (Directory.Exists(path + nomeProjeto + ".Controller\\"))
                {
                    stre = new StreamWriter(path + nomeProjeto + ".Controller\\" + nomeArquivoCT);
                    listLocalSalv.Add(path + nomeProjeto + ".Controller\\" + nomeArquivoCT);
                }
                else
                {
                    stre = new StreamWriter(path + nomeArquivoDAO);
                    listLocalSalv.Add(path + nomeProjeto + ".Controller\\" + nomeArquivoCT);
                }

                if (cbController.Checked == true)
                {

                    stre.Write(retCT);
                }


                stre.Close();


                //if (Directory.Exists(path + nomeProjeto + ".Mappers\\"))
                //{
                //    stre = new StreamWriter(path + nomeProjeto + ".Mappers\\" + nomeArquivoMAPPER);
                //    listLocalSalv.Add(path + nomeProjeto + ".Mappers\\" + nomeArquivoMAPPER);
                //}
                //else
                //{
                //    stre = new StreamWriter(path + nomeArquivoMAPPER);
                //    listLocalSalv.Add(path + nomeArquivoMAPPER);
                //}

                //stre.Write(retMAPPER);

                //stre.Close();

                //if (Directory.Exists(path + nomeProjeto + ".DAOs\\"))
                //{
                //    stre = new StreamWriter(path + nomeProjeto + ".DAOs\\" + nomeArquivoDAO);
                //    listLocalSalv.Add(path + nomeProjeto + ".DAOs\\" + nomeArquivoDAO);
                //}
                //else
                //{
                //    stre = new StreamWriter(path + nomeArquivoDAO);
                //    listLocalSalv.Add(path + nomeArquivoDAO);
                //}

                //stre.Write(retDAO);

                //stre.Close();

                string msg = string.Empty;


                for (int i = 0; i < listLocalSalv.Count; i++)
                {
                    msg += Environment.NewLine + listLocalSalv[i].ToString();
                }

                //MsgBox msgB = new MsgBox(listLocalSalv, false, string.Empty);
                //msgB.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Selecione a pasta \"Versão do projeto\"(01.17.000) do projeto";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCaminhoProjeto.Text = folderBrowserDialog1.SelectedPath;
                txtCaminhoProjeto.Text = folderBrowserDialog1.SelectedPath;
            }
            else
                txtCaminhoProjeto.Text = "D:\\GeradorClasses";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Periferica peri = new Periferica();
            ddlTabelas.DataSource = peri.BuscaTabelasBanco(txtConn.Text, txtBanco.Text);
            ddlTabelas.DisplayMember = "table_name";
            ddlTabelas.ValueMember = "table_name";
            //if (ddlTabelas.Items.Count > 0)
            //{
            //     MessageBox.Show("Banco de Dados Inexiste ou não possui tabelas!\nCheque a string de conexão e\ou o Nome do Banco de Dados", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
    }
}
