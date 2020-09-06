using API_PetShop.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Interfaces
{
    interface IRaca
    {
        Raca BuscarPorId(int id);
        List<Raca> LerTodos();
        Raca Cadastrar(Raca x);
        Raca Alterar(int id, Raca x);
        void Excluir(int id);
    }
}

