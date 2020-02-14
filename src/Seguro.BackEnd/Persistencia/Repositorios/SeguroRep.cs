using Objeto = Seguro.BackEnd.Dominio.ObjetoDeValor;
using System.Text;
using System.Data.SqlClient;
using Seguro.BackEnd.Persistencia.Interfaces;
using Dapper;
using Seguro.BackEnd.Persistencia.Repositorios.Fabriaca;
using Seguro.BackEnd.Dominio.Commando.SeguroCmd;
using System.Collections.Generic;
using System.Linq;
using Seguro.BackEnd.Dominio.Entidade;
using System.Data;
using System.Text.RegularExpressions;

namespace Seguro.BackEnd.Persistencia.Repositorios
{
    public class SeguroRep : ISeguroRep
    {
        public Objeto.Seguro[] Filtrar(FiltrarCmd comando)
        {
            IList<Objeto.Seguro> resultado = new List<Objeto.Seguro>();
            StringBuilder sql = new StringBuilder();
            StringBuilder sqlFiltro = new StringBuilder();
            var parametros = new DynamicParameters();

            sql.Append($@"SELECT 
                        V.Marca,
                        V.Modelo,
                        V.ValorVeiculo,
                        Se.Nome,
                        Se.Idade,
                        Se.CPF 
                        FROM { nameof(Objeto.Seguro)} AS S ");
            sql.Append($" INNER JOIN { nameof(Veiculo)} As V On V.Id = S.IdVeiculo ");
            sql.Append($" INNER JOIN { nameof(Segurado)} As Se On Se.Id = S.IdSegurado ");

            if (!string.IsNullOrEmpty(comando.Nome))
            {
                sqlFiltro.Append(" AND Se.Nome = @Nome  ");
                parametros.Add("@Nome", comando.Nome, DbType.AnsiString, size: 255);
            }

            if (!string.IsNullOrEmpty(comando.Cpf))
            {
                sqlFiltro.Append(" AND Se.CPF = @Cpf  ");
                parametros.Add("@CPF", comando.Cpf, DbType.AnsiString, size: 15);
            }

            if (comando.Idade > 0)
            {
                sqlFiltro.Append(" AND Se.Idade = @Idade  ");
                parametros.Add("@Idade", comando.Idade, DbType.Int16);
            }

            if (!string.IsNullOrEmpty(comando.Marca))
            {
                sqlFiltro.Append(" AND V.Marca = @Marca  ");
                parametros.Add("@Marca", comando.Marca, DbType.AnsiString, size: 250);
            }

            if (!string.IsNullOrEmpty(comando.Modelo))
            {
                sqlFiltro.Append(" AND V.Modelo = @Modelo  ");
                parametros.Add("@Modelo", comando.Modelo, DbType.AnsiString, size: 250);
            }

            if (comando.ValorVeiculo > 0)
            {
                sqlFiltro.Append(" AND V.ValorVeiculo = @ValorVeiculo  ");
                parametros.Add("@ValorVeiculo", comando.ValorVeiculo, DbType.Decimal);
            }

            sql.Append(Regex.Replace(sqlFiltro.ToString(), @"^ AND ", " WHERE "));

            using (var conn = new SqlConnection(ConnectionString.Conexao))
            {
                IDataReader reader = conn.ExecuteReader(sql.ToString(), parametros);

                while (reader.Read())
                {
                    Veiculo veiculo = new Veiculo(decimal.Parse(reader["ValorVeiculo"].ToString()),
                                                  reader["Marca"].ToString(),
                                                  reader["Modelo"].ToString());
                    Segurado segurado = new Segurado(reader["Nome"].ToString(),
                                                     reader["CPF"].ToString(),
                                                     int.Parse(reader["Idade"].ToString()));

                    Objeto.Seguro seguro = new Objeto.Seguro(veiculo, segurado);
                    resultado.Add(seguro);
                }
            }

            return resultado.ToArray();
        }

        public int Inserir(Objeto.Seguro seguro)
        {
            StringBuilder sql = new StringBuilder();
            int resultado = -1;

            sql.Append($@"
                         INSERT INTO { nameof(Objeto.Seguro) } (Id, IdVeiculo, IdSegurado)
                                VALUES(@Id, @IdVeiculo, @IdSegurado)");

            using (var conn = new SqlConnection(ConnectionString.Conexao))
            {
                try
                {
                    var parametros = new DynamicParameters(new
                    {
                        seguro.Id,
                        IdVeiculo = seguro.Veiculo.Id,
                        IdSegurado = seguro.Segurado.Id
                    });

                    resultado = conn.Execute(sql.ToString(), parametros);

                }
                catch (SqlException ex)
                {
                    resultado = 0;
                }
            }

            return resultado;
        }


    }
}
