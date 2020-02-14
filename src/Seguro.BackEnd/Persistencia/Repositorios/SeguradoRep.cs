using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Seguro.BackEnd.Dominio.Entidade;
using Seguro.BackEnd.Persistencia.Interfaces;
using Seguro.BackEnd.Persistencia.Repositorios.Fabriaca;

namespace Seguro.BackEnd.Persistencia.Repositorios
{
    public class SeguradoRep : ISeguradoRep
    {
        public Segurado Obter(Guid id)
        {
            StringBuilder sql = new StringBuilder();
            Segurado segurado = null;

            sql.Append($@"SELECT 
                        Nome,
                        CPF,
                        Idade
                        FROM Segurado 
                        WHERE Id = @Id");

            using (var conn = new SqlConnection(ConnectionString.Conexao))
            {
                try
                {
                    var parametros = new DynamicParameters(new { id });
                    IDataReader reader = conn.ExecuteReader(sql.ToString(), parametros);

                    while (reader.Read())
                    {
                        segurado = new Segurado(reader["Nome"].ToString(), 
                                                reader["CPF"].ToString(), 
                                                int.Parse(reader["Idade"].ToString()));
                    }
                }
                catch (SqlException ex) {  }
            }

            return segurado;
        }
    }
}
