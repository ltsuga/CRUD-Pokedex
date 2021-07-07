using System.Collections.Generic;
using CRUD.Pokedex.Interfaces;

namespace CRUD.Pokedex
{
    public class PokRepositorio : IRepositorio<Pokemon>
    {
        private List<Pokemon> listaPokemon = new List<Pokemon>();

        public void Atualiza(int id, Pokemon entidade)
        {
            listaPokemon[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaPokemon[id].Excluir();
        }

        public void Insere(Pokemon entidade)
        {
            listaPokemon.Add(entidade);
        }

        public List<Pokemon> Lista()
        {
            return listaPokemon;
        }

        public int ProximoId()
        {
            return listaPokemon.Count;
        }

        public Pokemon RetornaPorId(int id)
        {
            return listaPokemon[id];
        }
    }
}