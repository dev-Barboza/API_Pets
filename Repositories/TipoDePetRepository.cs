using API_PetShop.Context;
using API_PetShop.Domains;
using API_PetShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace API_PetShop.Repositories
{
    public class TipoDePetRepository : ITipoDePet
    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();
        public TipoDePet Alterar(int id, TipoDePet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoDePet SET " +
                "Descricao = @descricao " +
                "WHERE IdTipoDePet = @id";
            cmd.Parameters.AddWithValue("@id", id);
            
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public TipoDePet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();
            
            cmd.CommandText = "SELECT * FROM TipoDePet WHERE IdTipoDePet = @id";

           
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet a = new TipoDePet();

            while (dados.Read())
            {
                a.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();

            }
            conexao.Desconectar();

            return a;

        }

        public TipoDePet Cadastrar(TipoDePet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = 
                "INSERT INTO TipoDePet ( Descricao) " +
                "VALUES" +
                "( @descricao)";
            
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoDePet WHERE IdTipoDePet = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();


            conexao.Desconectar();
        }

        public List<TipoDePet> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            
            cmd.CommandText = "SELECT * FROM TipoDePet";

          
            SqlDataReader dados = cmd.ExecuteReader();

           
            List<TipoDePet> pets = new List<TipoDePet>();

            
            while (dados.Read())
            {
                pets.Add(
                    new TipoDePet()
                    {
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
            }

            conexao.Desconectar();

            return pets;
        }
    }
}
    
