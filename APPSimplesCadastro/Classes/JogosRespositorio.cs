using System;
using System.Collections.Generic;
using APPSimplesCadastro.Interfaces;
using APPSimplesCadastro.Classes;

namespace APPSimplesCadastro
{
    public class JogosRespositorio : IRepositorio<Jogos>
    {
        private List<Jogos> listaJogos = new List<Jogos>();

        public void atualizar(int id, Jogos novo)
        {
            listaJogos[id] = novo;
        }
        public void set(Jogos novo)
        {
            listaJogos.Add(novo);
        }
        public void del(int id)
        {
            listaJogos[id].Deletar();
        }
        public List<Jogos> Lista()
        {
            return listaJogos;
        }
        public int proximoId()
        {
            return listaJogos.Count;
        }
        public Jogos getID(int id)
        {
            return listaJogos[id];
        }
    }
}