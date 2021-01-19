using System.Collections.Generic;
using E_players.Models;

namespace E_players.Interfaces
{
    public interface IEquipe
    {
        //CRUD

        void Create(Equipe e);
    
        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int Id);

    }
}