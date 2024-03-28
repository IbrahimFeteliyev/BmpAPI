using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.NewsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Business.Abstarct
{
    public interface INewsService
    {
        Task<IResult> AddNewsByLanguageAsync(NewsAddDTO newsAddDTO, string webRootPath);
        Task<IResult> UpdateNewsByLanguageAsync(NewsUpdateDTO newsUpdateDTO, string webRootPath);
        IDataResult<NewsDetailDTO> GetNewsById(int id);
        IDataResult<NewsDetailLangDTO> GetNewsLangById(int id, string langCode);
        IDataResult<List<NewsListDTO>> GetAllNewss(string langCode);
        IResult RemoveNews(int id);

    }
}
