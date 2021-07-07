using System;

namespace CRUD.Pokedex
{
    public class Pokemon : EntidadeBase
    {
        private string Nome {get;set;}
        private int NumeroDex {get;set;}
        private double Altura {get;set;}
        private double Peso {get;set;}
        private Tipo Tipo {get;set;}
        private bool Excluido {get;set;}

            public Pokemon(int id,string nome, int numeroDex, double altura, double peso,  Tipo tipo) 
        {
                this.Id = id;
                this.Nome = nome;
                this.NumeroDex = numeroDex;
                this.Altura = altura;
                this.Peso = peso;
                this.Tipo = tipo;
                this.Excluido = false;
               
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Numero na Dex: "+ this.NumeroDex + Environment.NewLine;
            retorno += "Altura: " + this.Altura + Environment.NewLine;
            retorno += "Peso: " + this.Peso + Environment.NewLine;
            retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
        
   }
}