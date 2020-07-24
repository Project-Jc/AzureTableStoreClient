using Azure.Storage.Table.Abstractions;
using Azure.Storage.Table.Concretions;
using Azure.Storage.Table.Options;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace Azure.Storage.Table.Extensions.DependencyInjection
{
	public static class AzureTableClientServiceCollectionExtensions
	{
		public static IServiceCollection AddAzureTableClient(this IServiceCollection serviceCollection, Action<AzureTableClientOptions> action)
		{
			var tableClientOptions = new AzureTableClientOptions();

			action(tableClientOptions);

			serviceCollection.AddSingleton(tableClientOptions);
			serviceCollection.AddSingleton<ITableClient, AzureTableClient>();

			return serviceCollection;
		}
	}
}
