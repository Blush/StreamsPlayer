namespace Domain
{
	public interface IDataProviderFactory
	{
		IStreamDataProvider CreateDataProvider(string url, int bufferSize = 1024);
	}
}