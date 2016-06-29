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
            int[] final;
            String[] participantes;
            int pontuacaoMinima;
            int qtdParticipantes;
            int vencedor;

			Console.WriteLine("Digite a pontuação minima");
            pontuacaoMinima = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a quantidade de participantes");
            qtdParticipantes = int.Parse(Console.ReadLine());

            turno1 = new int[qtdParticipantes];
            turno2 = new int[qtdParticipantes];
            final = new int[qtdParticipantes];
            participantes = new String[qtdParticipantes];

            for (int i = 0; i < qtdParticipantes; i++)
            {
                Console.WriteLine("Digite o nome " + (i+1));
                participantes[i] = Console.ReadLine();

                Console.WriteLine("Digite a pontuação " + (i + 1) + " (Turno 1)");
                turno1[i] = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a pontuação " + (i + 1) + " (Turno 2)");
                turno2[i] = int.Parse(Console.ReadLine());
            }

            vencedor = -1;
            int pontosVencedor = 0;

            for (int i = 0; i < qtdParticipantes; i++)
            {
                final[i] = turno1[i] + turno2[i];
                if (final[i] > pontuacaoMinima && final[i] > pontosVencedor)
                {
                    vencedor = i;
                    pontosVencedor = final[i];
                }
            }


            if (vencedor > -1)
            {
                Console.WriteLine("O vencedor foi " + participantes[vencedor]);
            }
            else
            {
                Console.WriteLine("Não houve vencedores");
            }
              

		}
	}
}
