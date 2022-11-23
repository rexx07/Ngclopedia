namespace Ngclopedia.Application.Interfaces.Common;

public interface IExcelWriter : ITransientService
{
    Stream WriteToStream<T>(IList<T> data);
}