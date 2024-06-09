using System.Data;
using System.Net.WebSockets;
using Dapper;
using HeroesAPI.Data;
using HeroesAPI.Models;
using HeroesAPI.Repositories;
using Microsoft.Data.SqlClient;

namespace HeroesAPI.Repositories
{
    public class HeroeRepository : IHeroeRepository
    {
        private readonly DbConnectionFactory _connectionFactory;

        // Constructor
        public HeroeRepository(DbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        // Methods
        public async Task<IEnumerable<Heroe>> GetAllAsync()
        {
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {
                return await db.QueryAsync<Heroe>("SELECT * FROM Heroes");
            }
        }

        public async Task<Heroe?> GetByIdAsync(int id)
        {
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {
                return await db.QueryFirstOrDefaultAsync<Heroe>("SELECT * FROM Heroes WHERE HeroeId = @HeroeId", new { HeroeId = id });
            }
        }

        public async Task<int> AddAsync(Heroe heroe)
        {
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO Heroes (HeroeName, Skills) VALUES(@HeroeName, @Skills)";

                return await db.ExecuteAsync(sql, new { heroe.HeroeName, heroe.Skills });
            }
        }

        public async Task<int> UpdateAsync(Heroe heroe)
        {
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {
                var sql = "UPDATE Heroes SET HeroeName = @HeroeName, Skills = @Skills WHERE HeroeId = @HeroeId";

                return await db.ExecuteAsync(sql, new { heroe.HeroeName, heroe.Skills, heroe.HeroeId });
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection db = _connectionFactory.CreateConnection())
            {
                var sql = "DELETE FROM Heroes WHERE HeroeId = @HeroeId";

                return await db.ExecuteAsync(sql, new { HeroeId = id });
            }
        }
    }
}