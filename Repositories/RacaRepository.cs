using API_PetShop.Context;
using API_PetShop.Domains;
using API_PetShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Repositories
{
    public class RacaRepository : IRaca
    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();
        public Raca Alterar(int id, Raca x)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET " +
                
                "Descricao = @descricao, " +
                "IdTipoDePet = @idtipodepet WHERE IdTipoDePet = @id ";

            cmd.Parameters.AddWithValue("@descricao", x.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", x.IdTipoDePet);

            cmd.Parameters.AddWithValue("@id", id);
            

            

            conexao.Desconectar();
            return x;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            // Atribuimos nossa conexao
            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            // Dizemos quem é o @id
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca x = new Raca();

            while (dados.Read())
            {
                x.IdRaca = Convert.ToInt32(dados.GetValue(0));
                x.Descricao = dados.GetValue(1).ToString();
                x.IdTipoDePet = Convert.ToInt32(dados.GetValue(2));

            }

            conexao.Desconectar();

            return x;
        }
    

        public Raca Cadastrar(Raca x)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca ( Descricao , IdTipoDePet) " +
                "VALUES" +
                "( @descricao , @idtipodepet)";

           

            cmd.Parameters.AddWithValue("@descricao", x.Descricao);
            cmd.Parameters.AddWithValue("@idtipodepet", x.IdTipoDePet);

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return x;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id ";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            conexao.Desconectar();
        }

        public List<Raca> LerTodos()
        {

            cmd.Connection = conexao.Conectar();


            cmd.CommandText = "SELECT * FROM Raca";


            SqlDataReader dados = cmd.ExecuteReader();


            List<Raca> racas = new List<Raca>();


            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(2)),
                        
                    }
                );
            }

            conexao.Desconectar();

            return racas;
        }
    }
    }

