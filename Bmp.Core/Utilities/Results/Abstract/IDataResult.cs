using Microsoft.AspNetCore.Http;


namespace Bmp.Core.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
