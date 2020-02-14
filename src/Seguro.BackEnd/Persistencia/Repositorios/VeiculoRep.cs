using Dapper;
using Seguro.BackEnd.Dominio.Entidade;
using Seguro.BackEnd.Persistencia.Interfaces;
using Seguro.BackEnd.Persistencia.Repositorios.Fabriaca;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Seguro.BackEnd.Persistencia.Repositorios
{
    public class VeiculoRep : IVeiculoRep
    {
        public Veiculo Obter(Guid id)
        {
            StringBuilder sql = new StringBuilder();
            Veiculo veiculo = null;

            sql.Append($@"SELECT 
                        Marca,
                        Modelo,
                        ValorVeiculo
                        FROM Veiculo 
                        WHERE Id = @Id");

            using (var conn = new SqlConnection(ConnectionString.Conexao))
            {
                try
                {
                    var parametros = new DynamicParameters(new { id });
                    IDataReader reader = conn.ExecuteReader(sql.ToString(), parametros);

                    while (reader.Read())
                    {
                        veiculo = new Veiculo(decimal.Parse(reader["ValorVeiculo"].ToString()),
                                              reader["Marca"].ToString(),
                                              reader["Modelo"].ToString());
                    }
                }
                catch (SqlException ex)
                {
                    
                }
            }

            return veiculo;
        }
    }
}
