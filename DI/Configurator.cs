using Domain;
using Microsoft.Extensions.DependencyInjection;
using Streams.DataProviders;
using Streams.Players.Mjpeg;
using System;

namespace DI
{
	public static class Configurator
	{
		private static ServiceProvider serviceProvider;
		private static object serviceProviderLocker = new object();
		public static ServiceProvider GetServiceProvider()
		{
			if(serviceProvider == null)
			{
				lock(serviceProviderLocker)
				{
					if (serviceProvider == null)
					{
						serviceProvider = new ServiceCollection()
							.AddScoped<IDataProviderFactory, StreamDataProviderFactory>()
							.AddTransient<IVideoPlayer>((service) => new MjpegPlayer(service.GetService<IDataProviderFactory>(), 1024 * 1024))
							.BuildServiceProvider();
					}
				}
			}

			return serviceProvider;
		}

	}
}
