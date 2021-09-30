using System;

namespace _01_04
{
    class Program
    {
        //os parametros do delegate precisam coincidir com os parametros da função;
        delegate int Operacao(int a, int b);
        static void Main(string[] args)
        {
            //criando um função anonima  com delegate
            //parametros(x,y) (expressão lambda)=> {return valor de retorno}
            //Operacao operacao = (x, y) => { return x + y; };
            Operacao operacao = (x, y) => x + y;
            Console.WriteLine(operacao(3, 2));

            //delegado de função, que sempre retorna um valor
            //pe = parametro de entrada
            //ps = valor de saída
            //Func<pe,pe,ps>
            Func<int, int, int> somar = (x, y) => x + y;
            Console.WriteLine(somar(3,2));

            //delegado de ação
            //criando uma ação com o lambda
            //mensagem é o parametro
            //action não retorna nenhum valor
            Action<string> imprimirMensagem = (mensagem) => { Console.WriteLine(mensagem); };

            imprimirMensagem("Olá, alura!");



            var numeros = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("Números divisíveis por 3");

            //Delegado predicate especializado em retornar bool
            //Assim só precisa passar o parametro de entrada

            Predicate<int> divisivelPor3 = (numero) => numero % 3 == 0;

            //.FindAll(array que foi criado, predicate);
            var disiveis = Array.FindAll(numeros, divisivelPor3);

            foreach (var numero in disiveis)
            {
                Console.WriteLine(numero);
            }
       
        }
    }
}