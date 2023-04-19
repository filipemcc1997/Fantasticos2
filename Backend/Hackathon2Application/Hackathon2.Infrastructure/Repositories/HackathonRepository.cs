﻿using Dapper;
using Hackathon2.Core.Interfaces.Repositories;
using Hackathon2.Core.Models;
using Hackathon2.Core.Settings;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Hackathon2.Infrastructure.Repositories
{
    public class HackathonRepository : IHackathonRepository
    {
        private readonly RepositorySettings _repositorySettings;


        public HackathonRepository(
               IOptions<RepositorySettings> repositoryOptions)
        {
            _repositorySettings = repositoryOptions.Value;
        }

        public Task<bool> AddCartAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsAsync()
        {

            try
            {
                await using var connection = new SqlConnection(_repositorySettings.ConnectionString);
                await connection.OpenAsync();

                var query = @"SELECT * FROM tblProducts";

                var result = connection.Query<Product>(query).ToList();
            }
            catch (SqlException ex)
            {
                throw;
            }

            return null;
        }
    }
}
