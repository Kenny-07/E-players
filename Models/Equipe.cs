using System.Collections.Generic;
using System.IO;
using E_players.Interfaces;

namespace E_players.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        // ID - Identificador único

        public int IdEquipe { get; set; }
        
        public string Nome { get; set; }
        
        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public void Create(Equipe e)
        {
            string[] linhas = { Prepare(e) };
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int Id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            //Removemos a linha que tem o código que vai ser alterado

            linhas.RemoveAll(x => x.Split(";") [0] == Id.ToString() );

            //Reescreve o CSV com as alterações

            RewriterCSV(PATH , linhas);
        }
    
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            //Ler todas as linhas do CSV

            string[] linhas = File.ReadAllLines(PATH);
            //Percorrer as linhas e adicionar na lista de equipes cada objeto equipe

            foreach (var item in linhas)
            {

                //1 ; PainGaming ; Pain.jpg
                string[] linha = item.Split(";");

                //[0] = 1
                //[1] = PainGaming
                //[2] = Pain.jpg

                //Criamos o objeto equipe

                Equipe equipe = new Equipe();

                //Alimentamos o objeto equipe

                equipe.IdEquipe = int.Parse( linha[0] );
                equipe.Nome     = linha[1];
                equipe.Imagem   = linha[2];

                //Adcionamos a equipe na lista de equipes
                equipes.Add(equipe);

            }

            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            //Removemos a linha que tem o código que vai ser alterado

            linhas.RemoveAll(x => x.Split(";") [0] == e.IdEquipe.ToString() );

            //Adiciona a linha alterada no final do arquivo com o mesmo código

            linhas.Add( Prepare(e) );

            //Reescreve o CSV com as alterações

            RewriterCSV(PATH , linhas);
        }

    }
}