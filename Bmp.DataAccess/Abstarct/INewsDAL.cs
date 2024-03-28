using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.NewsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.DataAccess.Abstarct
{
    public interface INewsDAL : IEntityRepository<News>
    {
        Task<bool> AddNews(NewsAddDTO blogAddDTO, string webRootPath);
        Task<bool> UpdateNews(NewsUpdateDTO blogUpdateDTO, string webRootPath);
        NewsDetailDTO GetNewsByIdAdmin(int Id);
        NewsDetailLangDTO GetNewsLangById(int Id, string langCode);
        List<NewsListDTO> GetAllNewsList(string langCode);
    }
}
