using System;
using System.Collections.Generic;
using System.IO;

namespace Arquivos02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pastaOrigem = @"C:\Users\fesco\OneDrive\Área de Trabalho\Lara\#C\ex_arqv\sumario_prod.CSV";

            string pastaDestino = @"C:\Users\fesco\OneDrive\Área de Trabalho\Lara\#C\ex_arqv\sumario_prod2.CSV";


            try
            {
                string[] lines = File.ReadAllLines(pastaOrigem);
                List<string> novasLinhas = new List<string>();

                foreach (var item in lines)
                {
                    var colunas = item.Split(';');

                    novasLinhas.Add(MontarLinhaNova(colunas));
                }

                File.WriteAllLines(pastaDestino, novasLinhas);
            }

            catch (IOException e)
            {
                Console.WriteLine("ERROR ! " + e.Message);
                throw;
            }

            Console.ReadLine();

        }

        
        public static string MontarLinhaNova(string[] colunas)
        {
            string nomeProduto = colunas[0];

            double preco = Convert.ToDouble(colunas[1]);

            int quantidade = Convert.ToInt32(colunas[2]);

            double total = preco * quantidade;

            string linhaNova = nomeProduto + ";" + total;

            return linhaNova;
        }
    }
}
