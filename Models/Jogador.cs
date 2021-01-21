using System.Collections.Generic;
using System.IO;
using E_players.Interfaces;
namespace E_players.Models
{
    public class Jogador : EplayersBase , IJogador
    {
        public int IdJogador { get; set; }
        
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int IdEquipe { get; set; }

        private const string PATH = "Database/Jogador.csv";

        public Jogador()
        {
            CreateFolderAndFile(PATH);
        }

        public string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador};{j.Nome};{j.IdEquipe};{j.Email};{j.Senha}";
        }

        public void Create(Jogador j)
        {
            string[] linhas = { PrepararLinha(j) };
            File.AppendAllLines(PATH, linhas);
        }

        public List<Jogador> ReadAll()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                
                string[] linha = item.Split(";");

                Jogador jogador = new Jogador();
                jogador.IdJogador    = int.Parse(linha[0]);
                jogador.Nome         = linha[1];
                jogador.IdEquipe     = int.Parse(linha[2]);
                jogador.Email        = linha[3];
                jogador.Senha        = linha[4];

                jogadores.Add(jogador);

            }

            return jogadores;

        }

        public void Update(Jogador j)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll( x => x.Split( ";" )[0] == j.IdJogador.ToString() );
            linhas.Add( PrepararLinha(j) );
            RewriterCSV(PATH, linhas);
        }

        public void Delete(int IdJogador)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);

            linhas.RemoveAll( x => x.Split( ";" )[0] == IdJogador.ToString() );

            RewriterCSV(PATH, linhas);
        }
    }
}