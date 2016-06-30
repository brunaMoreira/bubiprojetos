using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibUDP;

namespace ServidorLibUDP
{
	public partial class Form1 : Form
	{
		private UDPSocket socket;

		public Form1()
		{
			InitializeComponent();
			socket = new UDPSocket(MensagemRecebida, 103);
		}

		private void MensagemRecebida(byte[] buffer, int size, string ip, int port)
		{
			//provaanterior
			int soma = 0;
			double media;

			//percorre o vetor para somar os campos, pega a soma dos campos e adquiri a media. 

			for (int i = 0; i < 10; i++)
			{
				soma = soma + Convert.ToInt16(buffer[i]);
			}

			media = soma / 10;

			//percorre novamente o vetor para identificar o que são menores que a média. 

			for (int i= 0; i < 10; i++)
			{
				if (Convert.ToInt16(buffer[i]) < media)
				{
					buffer[i] = Convert.ToByte("0");
				}
			}



			socket.Send(buffer, ip, 6200);
		}

		private void Form1_Load(object sender, EventArgs e)
		{







		}
	}
}
