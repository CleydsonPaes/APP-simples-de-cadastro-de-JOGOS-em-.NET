using System;
using System.Collections.Generic;

namespace APPSimplesCadastro.Interfaces
{
    public interface IRepositorio<Tipo>
    {
        List<Tipo> Lista();
        Tipo getID(int id);
        void set (Tipo novo);
        void del (int id);
        void atualizar (int id, Tipo novo);
        int proximoId();

         
    }
}