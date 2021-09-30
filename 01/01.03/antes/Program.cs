using System;

namespace _01_03
{
    class Program
    {
        //criando um delegado 
        delegate int Operacao(int a, int b);
        static void Main(string[] args)
        {
            int a = 3;
            int b = 2;

            //new delegado(método);
            //com isso, é possível guardar um método dentro de uma variável
            //duas maneiras de instanciar um delegate: var operacao = new Operacao(Somar); ou ↓
            Operacao operacao = Somar;
            Console.WriteLine(operacao(a,b));

            operacao = new Operacao(Subtrair);
            Console.WriteLine(operacao(a,b));


            Console.ReadKey();
        }
        static int Somar(int a, int b)
        {
            Console.WriteLine($"A operação Somar foi chamada com a = {a} e b = {b} ");
            return a + b;
        }
        static int Subtrair(int a, int b)
        {
            Console.WriteLine($"A operação Subtrair foi chamada com a = {a} e b = {b} ");
            return a - b;
        }
    }
}