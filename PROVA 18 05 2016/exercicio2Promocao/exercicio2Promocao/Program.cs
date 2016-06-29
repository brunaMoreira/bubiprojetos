using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio2Promocao
{
	class Program
	{
		static void Main(string[] args)
		{
            //mmmmmm
			Console.WriteLine("Digite a quantidade de rotulos: ");
			int A = 0, B = 0, C = 0, D = 0, E = 0, Rotulo, qtdEnvelop = 0;
			int QtdRotulos = Convert.ToInt16(Console.ReadLine());
			Console.WriteLine("Digite os rotulos: ");

			for(int i =1; i<= QtdRotulos; i++)
			{
				Console.WriteLine();
				Rotulo = Convert.ToInt16(Console.ReadLine());
				if(Rotulo == 1)
				{
					A++;
				}
				if (Rotulo == 2)
				{
					B++;
				}
				if (Rotulo == 3)
				{
					C++;
				}
				if (Rotulo == 4)
				{
					D++;
				}
				if (Rotulo == 5)
				{
					E++;
				}
				
			}

			qtdEnvelop = A;

			if (qtdEnvelop > B)
			{
				qtdEnvelop = B;
			}

			if(qtdEnvelop > C)
			{
				qtdEnvelop = C;
            }

			if (qtdEnvelop > D)
			{
				qtdEnvelop = D;
			}

			if (qtdEnvelop > E)
			{
				qtdEnvelop = E;
			}

			Console.WriteLine("Você pode enviar " +qtdEnvelop + " envelopes");
			Console.ReadKey();
		}
	}
}
