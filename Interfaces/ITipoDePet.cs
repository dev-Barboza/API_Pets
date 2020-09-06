using API_PetShop.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Interfaces
{
    interface ITipoDePet
    {

        TipoDePet BuscarPorId(int id);
        List<TipoDePet> LerTodos();
        TipoDePet Cadastrar(TipoDePet a);
        TipoDePet Alterar(int id, TipoDePet a);
        void Excluir(int id);
    }
}
