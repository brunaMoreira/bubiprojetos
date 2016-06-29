using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralAlgoritmos
{
	class Program
	{
		static void Main(string[] args)
		{

			//
			//competição com apuração de pontos
			//
			//competição divida em 2 turnos com pontuacao minima

			//SE competidor (x) fizer MAIS pontos (pontuaçãofinal) nao atingir a pontuacao minima ENTAO nao há vencedores. 

			// A pontuacaofinal igual == à soma das pontuações dos 2 turnos. 

			//programa deve pedir que o usuario fornecça a pontuacaminima e qtdparticipantes, os nomes e as pontuações (dos 2 turnos)

			//exibir nome vencedor ou msg de erro caso nao atingir pontuacaominima. 
            int[] turno1;
            int[] turno2;
            String[] participantes;
            int pontuacaoMinima;
            int qtdParticipantes;

			Console.WriteLine("Digite a pontuação minima");
            pontuacaoMinima = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a quantidade de participantes");
            qtdParticipantes = int.Parse(Console.ReadLine());

            turno1 = new int[qtdParticipantes];
            turno2 = new int[qtdParticipantes];
            participantes = new String[qtdParticipantes];


			Console.WriteLine("Digite o nome 1 ");
			Console.WriteLine("Digite a pontuação 1 (turno 1)");
			Console.WriteLine("Digite a pontuação 1 (turno 2)");

			Console.WriteLine("Digite o nome 2 ");
			Console.WriteLine("Digite a pontuação 2 (turno 1)");
			Console.WriteLine("Digite a pontuação 2 (turno 2)");

			Console.WriteLine("O vencedor foi");

			Console.WriteLine("Não houve vencedores");



		}
	}
}
