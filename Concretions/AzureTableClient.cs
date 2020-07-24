using Azure.Storage.Table.Abstractions;
using Azure.Storage.Table.Options;

using Microsoft.Azure.Cosmos.Table;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Storage.Table.Concretions
{
	public class AzureTableClient : ITableClient
	{
		private readonly AzureTableClientOptions TableClientOptions;

		private CloudTable _cloudTable;
		private CloudTable CloudTable
		{
			get
			{
				if (_cloudTable != null)
					return _cloudTable;

				var cloudStorageAccount = CloudStorageAccount.Parse(TableClientOptions.ConnectionString);

				var cloudTableClient = cloudStorageAccount.CreateCloudTableClient();

				return _cloudTable = cloudTableClient.GetTableReference(TableClientOptions.TableName);
			}
		}

		public AzureTableClient(AzureTableClientOptions tableClientOptions)
		{
			ValidateTableClientOptions(tableClientOptions);

			TableClientOptions = tableClientOptions;
		}

		public async Task<TableResult> AddAsync(ITableEntity tableEntity)
		{
			await CreateTableIfNotExistsAsync();

			var insertOperation = TableOperation.Insert(tableEntity);

			var insertResult = await CloudTable.ExecuteAsync(insertOperation).ConfigureAwait(false);

			return insertResult;
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

		public async Task<bool> TableExistsAsync()
		{
			return await CloudTable.ExistsAsync();
		}

		private async Task CreateTableIfNotExistsAsync()
		{
			if (TableClientOptions.CreateTableIfNotExists)
			{
				await CloudTable.CreateIfNotExistsAsync();
			}
		}

		private bool IsSuccessStatusCode(int statusCode)
		{
			return (statusCode >= 200 && statusCode <= 299);
		}

		private void ValidateTableClientOptions(AzureTableClientOptions tableClientOptions)
		{
			if (tableClientOptions == null)
				throw new ArgumentNullException(nameof(tableClientOptions));

			else if (string.IsNullOrEmpty(tableClientOptions.ConnectionString))
				throw new ArgumentNullException(nameof(AzureTableClientOptions.ConnectionString));

			else if (string.IsNullOrEmpty(tableClientOptions.TableName))
				throw new ArgumentNullException(nameof(AzureTableClientOptions.TableName));
		}
	}
}
