using System;

namespace _01_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Campainha campainha = new Campainha();

            //ligação da action (OnCampainhaTocou) com o método (CampainhaTocou1/2)
            campainha.OnCampainhaTocou += CampainhaTocou1;
            campainha.OnCampainhaTocou += CampainhaTocou2;
            
            //Toda vez que o método tocar for chamado, os métodos que estão ligados com a action serão notificados
            //para ser notificado, o evento tem que acontecer depois da ligação entre o action com o método
            Console.WriteLine("A campainha será tocada");
            campainha.Tocar();
            
            //removendo o método de uma action
            campainha.OnCampainhaTocou -= CampainhaTocou1;

            //Quando o método tocar é chamado, a ação OnCampainhaTocou é chamada que por sua vez chama o método que foi atribuido a ela, no caso CampainhaTocou1
            Console.WriteLine("A campainha será tocada");
            campainha.OnCampainhaTocou += Acao;
            campainha.Tocar();


            //deixar o console aberto para leitura
            Console.ReadKey();
        }
        static void Acao()
        {
            Console.WriteLine("Você está me chamando porque eu estou ligado com a Oncampainha");
        }
        static void CampainhaTocou1()
        {
            Console.WriteLine("A campainha tocou(1)");
        }
        static void CampainhaTocou2()
        {
            Console.WriteLine("A campainha tocou(2)");
        }
    }
    class Campainha
    {
        //criando uma action que vai notificar
        public Action OnCampainhaTocou { get; set; }
        public void Tocar()
        {
            if (OnCampainhaTocou != null)
            {
                OnCampainhaTocou();

            }

        }
    }
}
