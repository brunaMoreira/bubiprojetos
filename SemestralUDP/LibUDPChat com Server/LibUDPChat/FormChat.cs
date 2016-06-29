using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

// **********************************************
// Não se esqueça de importar nossa biblioteca
// tanto aqui, como nas "References" do projeto!
// **********************************************
using LibUDP;

namespace LibUDPChat {
	public partial class FormChat : Form {
		private UDPSocket socket;

		public FormChat() {
			InitializeComponent();

			// Inicia o soquete em qualquer porta
			socket = new UDPSocket(MensagemRecebida);
		}

		private void MensagemRecebida(byte[] buffer, int size, string ip, int port) {
			// Converte o array de bytes para uma string, utilizando
			// a codificação UTF-8
			string[] mensagemRecebida = Encoding.UTF8.GetString(buffer, 0, size).Split('\u0004');

			if (mensagemRecebida.Length == 3)
			{
				string tipo = mensagemRecebida[0];
				string userOrigem = mensagemRecebida[1];
				string mensagem = mensagemRecebida[2];

				if (tipo != "M")
				{
					return;
				}

				// Acrescenta a mensagem recebida ao histórico
				txtHistorico.Text = "Mensagem de " + userOrigem + ": " +
					mensagem +
					Environment.NewLine +
					Environment.NewLine +
					txtHistorico.Text;
			}
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			// Só envia o login se realmente tiver um ;)
			if (txtUser.Text != "")
			{
				socket.Send("L\u0004" + txtUser.Text, txtIP.Text, 6200);
			}
		}

		private void btnEnviar_Click(object sender, EventArgs e) {
			// Só envia a mensagem se realmente tiver uma ;)
			if (txtMensagem.Text != "" && txtUserDestino.Text != "") {
				socket.Send("M\u0004" + txtUser.Text + "\u0004" + txtUserDestino.Text + "\u0004" + txtMensagem.Text, txtIP.Text, 6200);
				txtMensagem.Text = "";
			}
		}

		protected override void OnFormClosed(FormClosedEventArgs e) {
			base.OnFormClosed(e);

			// Termina o servidor quando fechar a janela
			socket.Close();
			socket.Dispose();
		}
	}
}
