using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs.ShortInfoDTOs;
using IResult = Bmp.Core.Utilities.Results.Abstract.IResult;


namespace Bmp.Business.Concrete
{
    public class ShortInfoManager : IShortInfoService
    {
        private readonly IShortInfoDAL _shortInfoDAL;

        public ShortInfoManager(IShortInfoDAL shortInfoDAL)
        {
            _shortInfoDAL = shortInfoDAL;
        }

        public async Task<IResult> AddShortInfoByLanguageAsync(ShortInfoAddDTO shortInfoAddDTO)
        {
            var result = await _shortInfoDAL.AddShortInfo(shortInfoAddDTO);
            if (result)
            {
                return new SuccessResult("ShortInfo created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<List<ShortInfoAdminListDTO>> GetAllShortInfosAdmin(string langCode)
        {
            try
            {
                var result = _shortInfoDAL.GetAllShortInfosAdminList(langCode);
                return new SuccessDataResult<List<ShortInfoAdminListDTO>>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<ShortInfoAdminListDTO>>(ex.Message);
            }
        }

        public IDataResult<ShortInfoAdminDetailDTO> GetShortInfoById(int id)
        {
            var result = _shortInfoDAL.GetShortInfoByIdAdmin(id);
            return new SuccessDataResult<ShortInfoAdminDetailDTO>(result);
        }

        public IResult RemoveShortInfo(int id)
        {
            var shortInfo = _shortInfoDAL.Get(x => x.Id == id);
            _shortInfoDAL.Delete(shortInfo);
            return new SuccessResult("Deleted Successfully");
        }

        public async Task<IResult> UpdateShortInfoByLanguageAsync(ShortInfoUpdateDTO shortInfoUpdateDTO, int Id)
        {
            var result = await _shortInfoDAL.UpdateShortInfo(shortInfoUpdateDTO, Id);
            if (result)
            {
                return new SuccessResult("Success");
            }
            return new ErrorResult("Error");
        }
    }
}
