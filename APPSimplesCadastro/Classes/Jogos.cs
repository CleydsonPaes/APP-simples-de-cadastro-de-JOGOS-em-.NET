using System;
using APPSimplesCadastro.Enum;

namespace APPSimplesCadastro.Classes
{
    public class Jogos: IDBase
    {
        private string Nome {get; set;}
        private string Descricao {get; set;}
        private string Desenvolvedora {get; set;}
        private int Ano {get; set;}
        private Genero Genero {get; set;} 
        private bool SinglePlay {get; set;} 
        private bool MultPlayer {get; set;}  

        private bool Deletado {get; set;}  


    //Construtor
        public Jogos (int id, Genero genero, string nome, string descricao,string dev,int ano, bool single, bool mult)  
        {
            this.id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Desenvolvedora = dev;
            this.Ano = ano;
            this.Genero = genero;
            this.SinglePlay = single;
            this.MultPlayer = mult;
            this.Deletado = false;
        }


    //ToString
        public override string ToString()
    {
        string texto = "";
        texto += "Genero: " + this.Genero + Environment.NewLine;
        texto += "Nome: " + this.Nome + Environment.NewLine;
        texto += "Desenvolvedora: " + this.Nome + Environment.NewLine;
        texto += "Ano: " + this.Ano + Environment.NewLine;

        if(this.SinglePlay == true)
        {
            texto += "SinglePlayer: Sim"+ Environment.NewLine; 
        }
        else
        {
            texto += "SinglePlayer: Não"+ Environment.NewLine;
        }

        if(this.MultPlayer == true)
        {
            texto += "MultPlayer: Sim"+ Environment.NewLine; 
        }
        else
        {
            texto += "SinglePlayer: Não"+ Environment.NewLine;
        }

        return texto;
    }

        public string getNome()
        {
            return this.Nome;
        }
        public int getID()
        {
            return base.id;
        }

        //Deletar
        public void Deletar()
        {
            this.Deletado = true;
        }
    }
}