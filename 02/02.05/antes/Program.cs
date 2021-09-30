using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace _02_05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Consulta com XML
            string xml =
            "<Filmes>" +
                "<Filme>" +
                    "<Diretor>Quentin Tarantino</Diretor>" +
                    "<Titulo>Pulp Fiction</Titulo>" +
                    "<Minutos>154</Minutos>" +
                "</Filme>" +
                "<Filme>" +
                    "<Diretor>James Cameron</Diretor>" +
                    "<Titulo>Avatar</Titulo>" +
                    "<Minutos>162</Minutos>" +
                "</Filme>" +
            "</Filmes>";

            //XmlDocument documento = new XmlDocument();
            //documento.LoadXml(xml);

            //convertendo a string para xml
            XDocument documento = XDocument.Parse(xml);

            //consultando  os filhos/descendants de f, no caso a tag Filme
            IEnumerable<XElement> consulta = from f in documento.Descendants("Filme") select f;
            foreach (var item in consulta)
            {
                //pegando o elemento de dentro da tags do xml
                Console.WriteLine((string)item.Element("Diretor"));
                Console.WriteLine((string)item.Element("Titulo"));
            }

            Console.WriteLine();

            Console.WriteLine("-------consulta com filtro--------");
            IEnumerable<XElement> consulta2 = 
                from f in documento.Descendants("Filme")
                where (string)f.Element("Diretor") == "James Cameron"                          
                select f;
            
            foreach (var item in consulta2)
            {
                Console.WriteLine(item.Element("Diretor").FirstNode);
                Console.WriteLine(item.Element("Titulo").FirstNode);
            }

            Console.WriteLine();

            Console.WriteLine("-------consulta com filtro e com método--------");
            //para acessar um elemento é necessário o .Elemente("elemento")
            IEnumerable<XElement> consulta3 =
                documento.Descendants("Filme").Where(elemento => (string)elemento.Element("Diretor") == "James Cameron");
                

            foreach (var item in consulta3)
            {
                Console.WriteLine(item.Element("Diretor").FirstNode);
                Console.WriteLine(item.Element("Titulo").FirstNode);
            }

            Console.WriteLine();

            Console.WriteLine("---Adicionando o elemento genero ao XML---");
            XElement pulpFiction
                = consulta.Where(filme => 
                (string)filme.Element("Titulo") == "Pulp Fiction")
                .SingleOrDefault();
            if (pulpFiction != null)
            {
                //adicionando um elemento dentro do elemento filme
                pulpFiction.Add(new XElement("Genero", "Drama"));
            }
            
            XElement avatar
                = consulta.Where(filme =>
                    (string)filme.Element("Titulo") == "Avatar").Single();

            avatar.Add(new XElement("Genero", "Ficção Científica"));
            foreach (var item in consulta)
            {
                Console.WriteLine();
                Console.WriteLine("Diretor: " + item.Element("Diretor").FirstNode);
                Console.WriteLine("Titulo: " + item.Element("Titulo").FirstNode);
                Console.WriteLine("Genero: "+(string)item.Element("Genero"));
            }


            Console.ReadKey();
        }
    }
}
