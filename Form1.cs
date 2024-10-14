using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3935_DeboraVieira_T01
{
    public partial class Form1 : Form
    {
       

            public Form1()
        {
            InitializeComponent();
        }
 
        private void txt_hr_partida_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_minuto_partida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_hr_duracao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_minuto_duracao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_hr_partida_Validating_1(object sender, CancelEventArgs e)
        {
            int hora_partida = int.Parse(txt_hr_partida.Text);
            if(hora_partida < 0 || hora_partida > 23){
                    MessageBox.Show("A hora informada deve ser entre 0 e 23","Erro!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_hr_duracao_Validating(object sender, CancelEventArgs e)
        {
            int hora_duracao = int.Parse(txt_hr_duracao.Text);
            if (hora_duracao < 0 || hora_duracao > 23)
            {
                MessageBox.Show("A hora informada deve ser entre 0 e 23.", "Erro!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_minuto_partida_Validating(object sender, CancelEventArgs e)
        {
            int minuto_partida = int.Parse(txt_minuto_partida.Text);
            if( minuto_partida <0 || minuto_partida > 59)
            {
                MessageBox.Show("O minuto informado deve ser entre 0 e 59.", "Erro!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_minuto_duracao_Validating(object sender, CancelEventArgs e)
        {
            int minuto_duracao = int.Parse(txt_minuto_duracao.Text);
            if (minuto_duracao < 0 || minuto_duracao > 59)
            {
                MessageBox.Show("O minuto informado deve ser entre 0 e 59.", "Erro!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            int hora_partida;
            int minutos_partida;
            int hora_duracao;
            int minuto_duracao;

            try { 
                 hora_partida = int.Parse(txt_hr_partida.Text);
                 minutos_partida = int.Parse(txt_minuto_partida.Text);
                 hora_duracao = int.Parse(txt_hr_duracao.Text);
                 minuto_duracao = int.Parse(txt_minuto_duracao.Text);
            }
            catch
            {
                 MessageBox.Show("Todos campos devem ser preenchidos!", "Erro!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int hora_chegada = hora_partida + hora_duracao;
            if (hora_chegada > 23)
            {
                hora_chegada = hora_chegada % 24;
            }

            int minutos_chegada = minutos_partida + minuto_duracao;
            if (minutos_chegada > 59)
            {
                int hora_adicional = minutos_chegada / 60;
                int resto_minutos = minutos_chegada % 60;
                hora_chegada += hora_adicional;
                minutos_chegada = resto_minutos;

            }
            string DiaChegada = hora_partida + hora_duracao > 23 ? "dia seguinte" : "mesmo dia";
            lbl_hr_chegada.Text = Convert.ToString(hora_chegada);
            lbl_minuto_chegada.Text = Convert.ToString(minutos_chegada);
            lbl_resultado.Text = "O seu voo chegará às " + lbl_hr_chegada.Text
                        + " horas e " + lbl_minuto_chegada.Text + " minutos do " + DiaChegada;
        }
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            txt_hr_partida.ResetText();
            txt_minuto_partida.ResetText();
            txt_hr_duracao.ResetText();
            txt_minuto_duracao.ResetText();
            lbl_hr_chegada.ResetText();
            lbl_minuto_chegada.ResetText();
            lbl_resultado.ResetText();
        }
    }
}
