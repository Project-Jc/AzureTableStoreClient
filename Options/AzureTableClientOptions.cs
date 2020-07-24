namespace Azure.Storage.Table.Options
{
	public class AzureTableClientOptions
	{
		public string ConnectionString { get; set; }

		public string TableName { get; set; }

		public bool CreateTableIfNotExists { get; set; }
	}
}
