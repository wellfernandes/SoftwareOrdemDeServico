﻿using System;
using Controller;
using System.Windows.Forms;

namespace View.Pessoas
{
    public partial class Frm_PessoaFisica : Form
    {
        public Frm_PessoaFisica()
        {
            InitializeComponent();
        }

        private void Btm_Salvar_Click(object sender, EventArgs e)
        {
            if (Txt_DataNacimento.Text != "  /  /")//Verifica se algo foi digitado na data de nascimento da pessoa.
            {
                Model.Pessoa_e_Usuario.Fisica PessoaFBase = new Model.Pessoa_e_Usuario.Fisica();
                ControllerFisica controllerPF = new ControllerFisica();

                PessoaFBase.Nome = Txt_Nome.Text;
                PessoaFBase.Endereco = Txt_Endereco.Text;
                PessoaFBase.Email = Txt_Email.Text;
                PessoaFBase.Situacao = Txt_Situacao.Text;
                PessoaFBase.SiglaEstado = Txt_Estado.Text;
                PessoaFBase.Cidade = Txt_Cidade.Text;
                PessoaFBase.Bairro = Txt_Bairro.Text;
                PessoaFBase.Cep = Txt_Cep.Text;
                PessoaFBase.Observacoes = Txt_Observacoes.Text;

                //Parte de Pessoa Física
                PessoaFBase.CPF = Txt_CPF.Text;
                PessoaFBase.Celular = Txt_Celular.Text;
                PessoaFBase.Sexo = Txt_Sexo.Text;
                PessoaFBase.DataDeNascimento = DateTime.Parse(Txt_DataNacimento.Text);

                //A função Save() Retona uma string infomando sobre o que ocorreu.
                string saida = controllerPF.Save(PessoaFBase.Nome, PessoaFBase.Endereco, PessoaFBase.Email, PessoaFBase.Situacao, PessoaFBase.SiglaEstado, PessoaFBase.Cidade, PessoaFBase.Bairro, PessoaFBase.Cep, PessoaFBase.Observacoes, PessoaFBase.CPF, PessoaFBase.Celular, PessoaFBase.Sexo, PessoaFBase.DataDeNascimento);

                MessageBox.Show(saida, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Txt_Bairro.Clear();
                Txt_Cep.Clear();
                Txt_Cidade.Clear();
                Txt_CPF.Clear();
                Txt_Celular.Clear();
                Txt_Endereco.Clear();
                Txt_Nome.Clear();
                Txt_Observacoes.Clear();
                Txt_DataNacimento.Clear();
                Txt_Situacao.Clear();
                Txt_Email.Clear();
            }
            else
            {
                MessageBox.Show("Data de nascimento inválida","Erro",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
    }
}
