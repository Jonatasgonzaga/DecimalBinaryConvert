using System;
using System.Collections.Generic;
using System.Threading; 

namespace Conversor
{
    class Program
    {

        public decimal ConversorBinFracionado(int contagem, decimal fracionado, List<object> bdfrac)//contagem = (bdint.frac -1)
        {
           if (contagem + 1 == bdfrac.Count)  // caso 'contagem'+1 for igual a quantidade de casa no vetor 'bdfrac'...
            {
           fracionado = Convert.ToDecimal(bdfrac[contagem]); //'fracionado' recebe o valor da ultima casa de 'bdfrac' 

                return ConversorBinFracionado(contagem - 1, fracionado, bdfrac); // funcao é retornada com contagem-1 
                // e 'inteiro' e 'bdint' atualizados
            }

            else if (contagem >= 0) // caso 'contagem' for maior igual a zero
            {

            fracionado = Convert.ToDecimal(bdfrac[contagem]) + 2 * fracionado;// inteiro recebe o valor de 'bdint' mais inteiro*2;

                return ConversorBinFracionado(contagem - 1, fracionado, bdfrac); // funcao é retornada com contagem-1 
            }
            

            return fracionado / (Decimal)Math.Pow(2, bdfrac.Count);
        }

        public Decimal ConversorBinInteiro(int contagem,decimal inteiro, List<object> bdint) //contagem = (bdint.Count -1)
        {
            if (bdint.Count > 1) //(3) caso a quantidade de casas em bdint for maior que 1... 
            {    //[essa condição é para caso a parte decimal for igual a 0, porque, sendo assim, dbint.Count será 0}
            

                if (contagem + 1 == bdint.Count) // (3.1) caso 'contagem'+1 for igual a quantidade de casa no vetor 'bdint'...
                {
                    inteiro = Convert.ToDecimal(bdint[contagem]);
                    //inteiro recebe o valor da ultima casa de 'bdint' 
                    return ConversorBinInteiro(contagem - 1, inteiro, bdint); // funcao é retornada com contagem-1 
                    // e 'inteiro' e 'bdint' atualizados
                }

                else if (contagem >= 0) //(3.2) caso 'contagem' for maior igual a zero
                {

                    inteiro = Convert.ToDecimal(bdint[contagem]) + 2 * inteiro;// inteiro recebe o valor de 'bdint' mais inteiro*2;

                    return ConversorBinInteiro(contagem - 1, inteiro, bdint); // funcao é retornada com contagem-1 
                }
            }

            else inteiro = 0; 

            return inteiro;
            

        }

        public List<object> ConversorDecFracionado(decimal fracionado, List<object> bdfrac, int freio) //freio = mantissa    
        {
           
            if (freio > 0) // condição para finalizar loop; quando chegar no limite da mantissa
             {
                fracionado = fracionado * 2;
                if (fracionado >= 1) bdfrac.Add(1); else bdfrac.Add(0); //caso fracionado for maior/igual a um, adiciona-se '1',
                //senão, adiciona-se zero ao 'bdfrac';
                return ConversorDecFracionado(fracionado - Math.Truncate(fracionado), bdfrac, freio-1);
                //retornando função, com 'fracionado' menos sua parte inteira, bdfrac e freio menos um.
            }

            else
            { //quando chegar ao fim da mantissa, retorna-se 'bdfrac'
                return bdfrac;
            }
        }
        public List<object> ConversorDecInteiro(decimal inteiro, List<object> bdint)
        {
                if (inteiro >= 1) // condição para finalizar a função, quando a variável 'inteiro' for menor de '0';
                {
                
                    if (inteiro % 2 == 0)
                    { //quando o número for par, divide-se 'inteiro' e adiciona-se um zero ao vetor 'bdint'
                    inteiro = Math.Truncate(inteiro / 2); 
                    bdint.Add(0);
                    }

                    else
                    { //quando o 'inteiro' for ímpar, divide-se 'inteiro' e adiciona-se número um a 'bdint'
                    inteiro = Math.Truncate(inteiro / 2);
                    bdint.Add(1);
                    }
                    return ConversorDecInteiro(inteiro, bdint); //retornando função com valores de 'bdint' e 'inteiro' atualizados
                }

                else if (inteiro == 0 & bdint.Count == 0 ) //condição quando o converte zero para binário
                {
                bdint.Add(0);
                return bdint;
                }

                else //caso -- ou quando -- 'inteiro' for menor que 1, 'bdint' será revertido, fazendo que as últimas casas do 
                    //vetor sejam as primeiras sucessivamente. Por fim, 'bdint' é retornado como a resposta para conversão da parte inteira do número decimal.
                {
                bdint.Reverse();
                return bdint;
                }

            
        }


        static void Main(string[] args)
        {
            Program programa = new Program(); // Instância da Classe 'Program', para que eu possa 
            //utilizar as funções recursivas

            int freio = 7; // Ou mantissa, de 7 casas;


            decimal inteiro = 0, fracionado, resposta; // variáveis em decimal, para evitar arrendondamentos. 
            string escolha; // variável para receber a escolha do usuário, podendo ser 'a' para Conversão decimal para binário
            //, 'b' para conversão binário para decimal ou qualquer outra tecla -- ou conjunto de teclas -- para finalizar;

            var bdint = new List<object>(); //vetores dinâmicos, para seja possível guardar informações 

            var bdfrac = new List<object>(); //úteis para a conversão: tanto BIN-DEC quanto DEC-BIN.

            string binario; //variável útil para a conversão do BIN-DEC, pois, por ser tipo string, 
            //a mesma abre um leque de opções de comparações para o programador


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t Obs: Se for inserir numero fracionado, no lugar da vígula use o ponto!" +
                " Tecle ENTER para seguir");
            Console.ReadLine();
            Console.ResetColor();
            Console.Clear();
            Thread.Sleep(3000);
            Console.WriteLine("\t Conversor entre as bases decimal e binária do... ");
            Thread.Sleep(4000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine ("\t Paulo Vida Boa, é claro!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t #PraiaÉVida");
            Console.ResetColor();
            Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine("\t Escolha uma das opções a seguir...");
            Console.WriteLine();
            Console.WriteLine("Tecle a letra 'a' para converter de DEC para BIN");
            Console.WriteLine("Tecle a letra 'b' para converter de BIN para DEC");
            escolha = Console.ReadLine();
            Console.Clear();

            switch (escolha)
            {
                case "a":

                    Console.WriteLine("Digite um número decimal: ");
                    inteiro = Convert.ToDecimal(Console.ReadLine()); //recebendo o valor digitado pelo usuário;
                    fracionado = inteiro - Math.Truncate(inteiro); //caso for fracionado, a parte fracionada será atribuída a variável 'fracionado';
                    programa.ConversorDecInteiro(Math.Truncate(inteiro), bdint); //chamando a função recursiva para a conversão da parte inteira,
                    // com o adendo do Math.Truncate() para para fazer que o número fique inteiro sem arredondamentos;

                    Console.Write("Resposta:  "); 
                    foreach (var element in bdint) { Console.Write(element); } //imprimindo valores contidos em 'bdint'
                    
                    if (fracionado > 0)
                    {   // caso 'fracionado' for maior que zero, significa que há uma parte fracionada do número digitado pelo usuário.
                         programa.ConversorDecFracionado(fracionado, bdfrac, freio); Console.Write(","); // chamando função para calcular converter 
                        //parte fracionada em decimal para binário
                        foreach (var element in bdfrac) { Console.Write(element); } //imprimindo valores contidos em 'bdfrac'
                    }

                    Console.ReadLine();
                    Console.WriteLine("Tecle ENTER para encerrar");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Adeus :(");
                    Thread.Sleep(2000);


                    break;

                case "b":

                    Console.WriteLine("Digite um número em binário: ");
                    inteiro = Convert.ToDecimal(Console.ReadLine());
                    fracionado = inteiro - Math.Truncate(inteiro);
                    inteiro = Math.Truncate(inteiro);
                    //'inteiro' recebe valor digitado pelo usuário, separe-se de 'inteiro' parte fracionada, para ser atribuída para a 'fracionado' 
                    // e 'inteiro' é truncado para retirar sua parte fracionada -- caso tenha;

                    binario = inteiro.ToString(); //'binario' recebe 'inteiro' em forma de string
                    

                    while (binario.Length != 0) //(1) enquanto o tamanho de 'binario' for maior que 0...
                    {
                        if (binario.EndsWith("0")) //(1.1) se 'binario' terminar com "0"...
                        {
                            bdint.Add(0);
                            binario = binario.Remove(binario.Length-1); //adiciona-se um 0 ao 'bdint' 
                            //e último caractere de 'binario' é removido
                        }

                        else if (binario.EndsWith("1")) //(1.2) ou caso terminar com "1"...
                        {
                            bdint.Add(1);
                            binario = binario.Remove(binario.Length-1);//adiciona-se um 1 ao 'bdint' 
                            //e último caractere de 'binario' é removido
                        }

                    }

                    
                    binario = fracionado.ToString(); //binario recebe 'fracionado' em forma de string

                    while (binario.Length != 0) //(2) enquanto o tamanho de 'binario' for maior que 0...
                    {
                        if (binario.EndsWith("0")) //(2.1) se 'binario' terminar com "0"...
                        {
                            bdfrac.Add(0);
                            binario = binario.Remove(binario.Length-1);//adiciona-se um 0 ao 'bdint' 
                            //e último caractere de 'binario' é removido
                        }

                        else if (binario.EndsWith("1")) //(2.2) ou caso terminar com "1"...
                        {
                            bdfrac.Add(1);
                            binario = binario.Remove(binario.Length-1);//adiciona-se um 0 ao 'bdint' 
                            //e último caractere de 'binario' é removido

                        }

                        else if (binario.EndsWith("."))// caso 'binario' terminar com "." ...
                        {
                            
                            binario = binario.Remove(binario.Length - 1); //"." é removido

                        } 
                    }

                    if (bdfrac.Count > 0) //caso a quantidade de casas em bdfrac for maior que 0...
                        resposta = programa.ConversorBinInteiro(bdint.Count - 1, inteiro, bdint) + programa.ConversorBinFracionado(bdfrac.Count - 1, fracionado, bdfrac);
                    //resposta é a soma da função que converte a parte inteira de decimal para binário e função que converte a parte fracionada de decimal para binário;


                    else // caso contrário...
                        resposta = programa.ConversorBinInteiro(bdint.Count - 1, inteiro, bdint); 
                    //resposta é a função de conversão de decimal para binário, sem parte fracionada;

                    Console.WriteLine();
                    Console.WriteLine("Resultado: " + resposta);

                    Console.WriteLine();
                    Console.WriteLine("Tecle ENTER para encerrar");
                    Console.ReadLine();  
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Adeus :(");
                    Thread.Sleep(2000);
                  
                   


                    break;
                        

            }

        }
    }
}
