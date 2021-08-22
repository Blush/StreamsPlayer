namespace Domain
{
	public interface IDataProviderFactory
	{
		IStreamDataProvider CreateDataProvider();
	}
}