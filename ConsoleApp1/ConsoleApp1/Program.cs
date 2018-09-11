using System;
using System.Collections.Generic;
using System.Threading; 

namespace Conversor
{
    class Program
    {

        public decimal ConversorBinFracionado(int contagem, decimal fracionado, List<object> bdfrac)
        {
            if (bdfrac.Count > 1)
            {

                if (contagem + 1 == bdfrac.Count)
                {
                    fracionado = Convert.ToDecimal(bdfrac[contagem]);

                    return ConversorBinFracionado(contagem - 1, fracionado, bdfrac);
                }

                else if (contagem >= 0)
                {

                    fracionado = Convert.ToDecimal(bdfrac[contagem]) + 2 * fracionado;

                    return ConversorBinFracionado(contagem - 1, fracionado, bdfrac);
                }

            }

            else fracionado = Convert.ToDecimal(bdfrac[contagem]);
            
            return fracionado / (Decimal)Math.Pow(2, bdfrac.Count);
        }

        public Decimal ConversorBinInteiro(int contagem,decimal inteiro, List<object> bdint)
        {
            if (bdint.Count > 1)
            {

                if (contagem + 1 == bdint.Count)
                {
                    inteiro = Convert.ToDecimal(bdint[contagem]);

                    return ConversorBinInteiro(contagem - 1, inteiro, bdint);
                }

                else if (contagem >= 0)
                {

                    inteiro = Convert.ToDecimal(bdint[contagem]) + 2 * inteiro;

                    return ConversorBinInteiro(contagem - 1, inteiro, bdint);
                }
            }

            else inteiro = Convert.ToDecimal(bdint[contagem]);

            return inteiro;
            

        }

        public List<object> ConversorDecFracionado(decimal fracionado, List<object> bdfrac, int freio)
        {
            

            if (fracionado > 0 & freio > 0)
             {
                fracionado = fracionado * 2;
                if (fracionado >= 1) bdfrac.Add(1); else bdfrac.Add(0);
                return ConversorDecFracionado(fracionado - Math.Truncate(fracionado), bdfrac, freio-1);
            }

            else
            {
                return bdfrac;
            }
        }
        public List<object> ConversorDecInteiro(decimal inteiro, List<object> bdint)
        {
                if (inteiro >= 1)
                {
                
                    if (inteiro % 2 == 0)
                    {
                    inteiro = Math.Truncate(inteiro / 2);
                    bdint.Add(0);
                    }
                     else
                     {
                    inteiro = Math.Truncate(inteiro / 2);
                    bdint.Add(1); }
                    return ConversorDecInteiro(inteiro, bdint);
                }

                else if (inteiro == 0 & bdint.Count == 0 )
                {
                bdint.Add(0);
                return bdint;
                }

                else 
                {
                bdint.Reverse();
                return bdint;
                }

            
        }


        static void Main(string[] args)
        {
            Program programa = new Program();
            int freio = 7;
            decimal inteiro = 0, fracionado, resposta;
            string escolha;
            var bdint = new List<object>();
            var bdfrac = new List<object>();
            string binario;
            
            

            Console.WriteLine("Conversor entre DEC e BIN");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Escolha uma das opções a seguir...");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("Tecle a letra 'a' para converter de DEC para BIN");
            Console.WriteLine("Tecle a letra 'b' para converter de BIN para DEC");
            escolha = Console.ReadLine();
            Console.Clear();

            switch (escolha)
            {
                case "a":

                    Console.WriteLine("Digite um número decimal: ");
                    inteiro = Convert.ToDecimal(Console.ReadLine());
                    fracionado = inteiro - Math.Truncate(inteiro);
                    programa.ConversorDecInteiro(Math.Truncate(inteiro), bdint);
                    Console.Write("Resposta:  ");
                    foreach (var element in bdint) { Console.Write(element); }
                    
                    if (fracionado > 0)
                    {
                        programa.ConversorDecFracionado(fracionado, bdfrac, freio); Console.Write(",");
                        foreach (var element in bdfrac) { Console.Write(element); }
                    }

                    
                    Console.WriteLine();
                    Console.WriteLine("Tecle ENTER para encerrar");
                    Console.ReadLine();
                    
                    break;

                case "b":

                    Console.WriteLine("Digite um número em binário: ");
                    inteiro = Convert.ToDecimal(Console.ReadLine());
                    fracionado = inteiro - Math.Truncate(inteiro);
                    inteiro = Math.Truncate(inteiro - fracionado);

                    binario = inteiro.ToString();
                    

                    while (binario.Length != 0)
                    {
                        if (binario.EndsWith("0"))
                        {
                            bdint.Add(0);
                            binario = binario.Remove(binario.Length-1);
                        }

                        else if (binario.EndsWith("1"))
                        {
                            bdint.Add(1);
                            binario = binario.Remove(binario.Length-1);
                        }

                    }

                    
                    binario = fracionado.ToString();

                    while (!binario.Equals("0"))
                    {
                        if (binario.EndsWith("0"))
                        {
                            bdfrac.Add(0);
                            binario = binario.Remove(binario.Length-1);
                        }

                        else if (binario.EndsWith("1"))
                        {
                            bdfrac.Add(1);
                            binario = binario.Remove(binario.Length-1);
                        }

                        else if (binario.EndsWith("."))
                        {
                            
                            binario = binario.Remove(binario.Length - 1);

                        }
                    }

                    if (bdfrac.Count > 0)
                        resposta = programa.ConversorBinInteiro(bdint.Count - 1, inteiro, bdint) + programa.ConversorBinFracionado(bdfrac.Count - 1, fracionado, bdfrac);
                    else
                        resposta = programa.ConversorBinInteiro(bdint.Count - 1, inteiro, bdint);

                    Console.WriteLine("Resultado: " + resposta);

                    Console.ReadLine();
                    
                    
                    break;
                        

            }

        }
    }
}
