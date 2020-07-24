
using Microsoft.Azure.Cosmos.Table;

namespace Azure.Storage.Table.Extensions
{
	public static class TableResultExtensions
	{
		public static bool IsTableResultSuccess(this TableResult tableResult)
		{
			return (tableResult.HttpStatusCode >= 200 && tableResult.HttpStatusCode <= 299);
		}

		public static void EnsureTableResultSuccess(this TableResult tableResult)
		{
			if (!tableResult.IsTableResultSuccess())
				throw new StorageException($"TableResult failed with status code ({tableResult.HttpStatusCode})");
		}
	}
}
