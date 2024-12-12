using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace apigerenciador.Infrastructure.Data
{
    public class ConnectionManager
    {
        private readonly string _connectionString;

        public ConnectionManager()
        {
            // Lê a string de conexão a partir do arquivo de configurações (web.config ou app.config)
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada no arquivo de configuração.");
            }
        }

        // Método para obter uma nova conexão com o banco de dados
        public SqlConnection GetConnection()
        {
            // Retorna uma nova instância de SqlConnection usando a string de conexão
            return new SqlConnection(_connectionString);
        }
    }
}
