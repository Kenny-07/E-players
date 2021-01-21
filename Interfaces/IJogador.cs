using E_players.Models;
using System.Collections.Generic;

namespace E_players.Interfaces
{
    public interface IJogador
    {
        void Create(Jogador j);

        List<Jogador> ReadAll();

        void Update(Jogador j);

        void Delete(int id);
    }
}