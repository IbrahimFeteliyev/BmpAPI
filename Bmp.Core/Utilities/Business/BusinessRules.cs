using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;

namespace Bmp.Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Check(params IResult[] logics)
        {
            foreach (var item in logics)
            {
                if (!item.Success)
                    return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
