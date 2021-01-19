using System;

namespace E_players.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }        
        public int Jogador1 { get; set; }
        public int Jogador2 { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioTermino { get; set; }
    }
}