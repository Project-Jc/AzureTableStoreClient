
using Microsoft.Azure.Cosmos.Table;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Storage.Table.Abstractions
{
	public interface ITableClient
	{
		Task<T> GetAsync<T>(string partitionKey, string rowKey);

		Task<IEnumerable<T>> QueryAsync<T>(TableQuery query);

		Task DeleteAsync(ITableEntity tableEntity);

		Task UpdateAsync(ITableEntity tableEntity);

		Task<TableResult> AddAsync(ITableEntity tableEntity);

		Task<bool> TableExistsAsync();
	}
}
