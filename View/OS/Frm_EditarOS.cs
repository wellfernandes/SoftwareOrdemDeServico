﻿using System;
using Controller;
using System.Windows.Forms;
using Model.Ordem_de_Servico;

namespace View.OS
{
    public partial class Frm_EditarOS : Form
    {
        public Frm_EditarOS(int idTecnico)
        {
            IDTecnico = idTecnico;

            InitializeComponent();
        }

        //TODO:Arrumar o botão de salvar OS editada que não esta funcionando.

        private int IDTecnico;
        private int IDChamado;

        private void Frm_EditarOS_Load(object sender, EventArgs e)
        {
            Txt_Cliente.Items.Clear();
            Txt_IDPesquisa.Items.Clear();
            Txt_DataEntrada.Text = DateTime.Now.ToString("dd-MM-yy");

            System.Data.DataTable Tabela = new System.Data.DataTable();

            Tabela = ControllerPessoa.CarregarListaDeNomes();

            foreach (System.Data.DataRow r in Tabela.Rows)
            {
                foreach (System.Data.DataColumn c in Tabela.Columns)
                {
                    Txt_Cliente.Items.Add(r[c].ToString());
                }
            }

            System.Data.DataTable TabelaOS = new System.Data.DataTable();

            TabelaOS = ControllerOrdemServico.CarregarListaDeIds();

            foreach (System.Data.DataRow r in TabelaOS.Rows)
            {
                foreach (System.Data.DataColumn c in TabelaOS.Columns)
                {
                    Txt_IDPesquisa.Items.Add(r[c].ToString());
                }
            }

        }

        private void Btm_Pesquisa_Click(object sender, EventArgs e)
        {
            OrdemServico OrdemDeServico = new OrdemServico();

            //Verificado se a ordem de serviço que foi procurada existe e se existir retornar a Ordem de serviço base.
            if (!String.IsNullOrEmpty(Txt_IDPesquisa.Text))
            {
                OrdemDeServico = ControllerOrdemServico.Carregar(Convert.ToInt32(Txt_IDPesquisa.Text));

                IDChamado = OrdemDeServico.ID;
                Txt_Situacao.Text = OrdemDeServico.Situacao;
                Txt_Defeito.Text = OrdemDeServico.Defeito;
                Txt_Descricao.Text = OrdemDeServico.Descricao;
                Txt_Observacoes.Text = OrdemDeServico.Observacao;
                Txt_Nserie.Text = OrdemDeServico.NumeroSerie;
                Txt_Equipamento.Text = OrdemDeServico.Equipamento;
                Txt_DataEntrada.Text = OrdemDeServico.dataEntradaServico;
                Txt_Descricao.Text = OrdemDeServico.Descricao;
                //Criar função para retornar nome atravez do ID do cliente Txt_Cliente.Text = 

            }
            else
            {
                MessageBox.Show("Escolha uma ordem de serviço!", "Informações", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            string Retorno = ControllerOrdemServico.Editar(PreencherOS());

            MessageBox.Show(String.Format("{0}", Retorno), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MessageBox.Show("Deseja imprimir o arquivo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ControllerOrdemServico.CreatPDF(PreencherOS());
            }


            Txt_DataEntrada.Clear();
            Txt_Defeito.Clear();
            Txt_Descricao.Clear();
            Txt_Equipamento.Clear();
            Txt_Nserie.Clear();
            Txt_Observacoes.Clear();
        }
    }
}