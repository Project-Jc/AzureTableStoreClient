using Microsoft.Azure.Cosmos.Table;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Storage.Table
{
	public interface ITableClient
	{
		Task<T> GetAsync<T>(string partitionKey, string rowKey);

		Task<IEnumerable<T>> QueryAsync<T>(TableQuery query);

		Task DeleteAsync(ITableEntity tableEntity);

		Task UpdateAsync(ITableEntity tableEntity);

		Task AddAsync(ITableEntity tableEntity);
	}

	public class AzureTableClient : ITableClient
	{
		private readonly string ConnectionString;
		private readonly string TableName;

		private CloudTable _cloudTable;
		private CloudTable CloudTable
		{
			get
			{
				if (_cloudTable != null)
					return _cloudTable;

				var cloudStorageAccount = CloudStorageAccount.Parse(ConnectionString);

				var cloudTableClient = cloudStorageAccount.CreateCloudTableClient();

				return _cloudTable = cloudTableClient.GetTableReference(TableName);
			}
		}

		public AzureTableClient(string connectionString, string tableName)
		{
			if (string.IsNullOrEmpty(connectionString))
				throw new ArgumentNullException(nameof(connectionString));

			if (string.IsNullOrEmpty(tableName))
				throw new ArgumentNullException(nameof(tableName));

			ConnectionString = connectionString;
			TableName = tableName;
		}

		public async Task AddAsync(ITableEntity tableEntity)
		{
			var insertOperation = TableOperation.Insert(tableEntity);

			var result = await CloudTable.ExecuteAsync(insertOperation).ConfigureAwait(false);
		}

		public Task DeleteAsync(ITableEntity tableEntity)
		{
			throw new NotImplementedException();
		}

		public Task<T> GetAsync<T>(string partitionKey, string rowKey)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<T>> QueryAsync<T>(TableQuery query)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(ITableEntity tableEntity)
		{
			throw new NotImplementedException();
		}
	}
}
