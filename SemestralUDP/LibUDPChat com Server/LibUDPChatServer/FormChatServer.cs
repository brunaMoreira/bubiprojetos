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

namespace LibUDPChatServer {
	public partial class FormChatServer : Form {
		private UDPSocket socket;
		private Dictionary<string, string> userIp;
		private Dictionary<string, int> userPort;

		public FormChatServer() {
			InitializeComponent();

			userIp = new Dictionary<string, string>();
			userPort = new Dictionary<string, int>();

			// Inicia o servidor local na porta 6200
			socket = new UDPSocket(MensagemRecebida, 6200);
		}

		private void MensagemRecebida(byte[] buffer, int size, string ip, int port) {
			// Converte o array de bytes para uma string, utilizando
			// a codificação UTF-8
			string[] mensagemRecebida = Encoding.UTF8.GetString(buffer, 0, size).Split('\u0004');

			if (mensagemRecebida.Length == 2)
			{
				string tipo = mensagemRecebida[0];
				string userFazendoLogin = mensagemRecebida[1];

				if (tipo != "L")
				{
					return;
				}

				userIp[userFazendoLogin] = ip;
				userPort[userFazendoLogin] = port;
			}
			else if (mensagemRecebida.Length == 4)
			{
				string tipo = mensagemRecebida[0];
				string userOrigem = mensagemRecebida[1];
				string userDestino = mensagemRecebida[2];
				string mensagem = mensagemRecebida[3];

				if (tipo != "M")
				{
					return;
				}

				string ipDestino;
				int portDestino;

				if (userIp.ContainsKey(userOrigem) == false)
				{
					// O usuário enviando a mensagem ainda não fez login!
					return;
				}

				if (userIp.TryGetValue(userDestino, out ipDestino) == false)
				{
					// O usuário destino ainda não fez login!
					return;
				}

				if (userPort.TryGetValue(userDestino, out portDestino) == false)
				{
					// O usuário destino ainda não fez login!?!?!? Mas como?!?!?!
					return;
				}

				socket.Send("M\u0004" + userOrigem + "\u0004" + mensagem, ipDestino, portDestino);
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
