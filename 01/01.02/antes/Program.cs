using System;
using System.Collections.Generic;

namespace _01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Campainha campainha = new Campainha();

                //o evento OnCampainhaTocou só pode ser associado a um método e não pode ser chamado
                //Toda vez que a campainha tocar todos os métodos que estão associados ao evento OnCampainhaTocou serão notificados
                campainha.OnCampainhaTocou += CampainhaTocou1;
                campainha.OnCampainhaTocou += CampainhaTocou2;
                Console.WriteLine("A campainha será tocada.");
                campainha.Tocar("101");

                campainha.OnCampainhaTocou -= CampainhaTocou1;


                Console.WriteLine("A campainha será tocada.");
                campainha.Tocar("202");
            }
            catch(AggregateException e)
            {
                foreach (var exc in e.InnerExceptions)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            catch (Exception e)
            {
                //exibindo a mensagem de exceção que foi declarada no método CampainhaTocou1
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();


        }

        //ESSES DOIS PARAMETROS object sender E EventArgs args SÃO OBRIGATÓRIOS
        //sender é a classe que dispara o evento, no caso a campainha
        static void CampainhaTocou1(object sender, Campainha.CampainhaEventArgs args)
        {
            Console.WriteLine("A campainha tocou no apartamento " + args.Apartamento + " .(1)");
            throw new Exception("Ocorreu um erro em CampainhaTocou1");

        }
        static void CampainhaTocou2(object sender, Campainha.CampainhaEventArgs args)
        {
            Console.WriteLine("A campainha tocou no apartamento " + args.Apartamento + " .(2)");
            throw new Exception("Ocorreu um erro em CampainhaTocou2");

        }
    }

    public class Campainha
    {
        //criando um evento com um argumento personalizado
        //agora o OnCampinhaTocou consegue transportar o argumento de evento
        //um evento só pode ser associado a um método e não pode ser chamado
        public event EventHandler<CampainhaEventArgs> OnCampainhaTocou;

        public void Tocar(string apartamento)
        {
            List<Exception> erros = new List<Exception>();
            //pegando os métodos que estão associados ao evento
            foreach (var manipulador in OnCampainhaTocou.GetInvocationList())
            {
                try
                {
                    //com o evento é necessário esses dois parametros
                    // a campainha é a classe que dispara o evento, e obtemos ela com o THIS
                    //Os dois códigos abaixo fazem a mesma coisa
                    //if (OnCampainhaTocou != null)
                    //{
                    //    //COM ESSE EVENTO OnCampainhaTocou É NECESSÁRIO PASSAR ESSES DOIS ARGUMENTOS -EventArgs-
                    //    // a campainha é a classe que dispara o evento, e obtemos ela com o THIS
                    //    OnCampainhaTocou(this, new CampainhaEventArgs(apartamento));
                    //}
                    manipulador.DynamicInvoke(this, new CampainhaEventArgs(apartamento));

                }
                catch (Exception e)
                {
                    erros.Add(e.InnerException);
                }
            }

            throw new AggregateException(erros);
        }

        //criando um argumento de evento personalizado
        public class CampainhaEventArgs : EventArgs
        {
            public CampainhaEventArgs(string apartamento)
            {
                Apartamento = apartamento;
            }

            public string Apartamento { get; }
        }
    }
}


