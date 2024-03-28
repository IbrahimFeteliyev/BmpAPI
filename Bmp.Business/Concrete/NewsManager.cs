using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs.NewsDTOs;

namespace Bmp.Business.Concrete
{
    internal class NewsManager : INewsService
    {
        private readonly INewsDAL _newsDAL;

        public NewsManager(INewsDAL newsDAL)
        {
            _newsDAL = newsDAL;
        }

        public async Task<IResult> AddNewsByLanguageAsync(NewsAddDTO newsAddDTO, string webRootPath)
        {
            var result = await _newsDAL.AddNews(newsAddDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("News created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
        public IDataResult<List<NewsListDTO>> GetAllNewss(string langCode)
        {
            try
            {
                var result = _newsDAL.GetAllNewsList(langCode);
                return new SuccessDataResult<List<NewsListDTO>>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<NewsListDTO>>(ex.Message);
            }
        }

        public IDataResult<NewsDetailDTO> GetNewsById(int id)
        {
            var result = _newsDAL.GetNewsByIdAdmin(id);
            return new SuccessDataResult<NewsDetailDTO>(result);
        }

        public IDataResult<NewsDetailLangDTO> GetNewsLangById(int id, string langCode)
        {
            var result = _newsDAL.GetNewsLangById(id, langCode);
            return new SuccessDataResult<NewsDetailLangDTO>(result);
        }

        public IResult RemoveNews(int id)
        {
            var news = _newsDAL.Get(x => x.Id == id);
            _newsDAL.Delete(news);
            return new SuccessResult("Deleted Successfully");
        }

        public async Task<IResult> UpdateNewsByLanguageAsync(NewsUpdateDTO newsUpdateDTO, string webRootPath)
        {
            var result = await _newsDAL.UpdateNews(newsUpdateDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("News updated successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
