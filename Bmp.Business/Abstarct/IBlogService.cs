using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Entities.DTOs.BlogDTOs;


namespace Bmp.Business.Abstarct
{
    public interface IBlogService
    {
        Task<IResult> AddBlogByLanguageAsync(BlogAddDTO blogAddDTO, string webRootPath);
        Task<IResult> UpdateBlogByLanguageAsync(BlogUpdateDTO blogUpdateDTO, string webRootPath);
        IDataResult<BlogDetailDTO> GetBlogById(int id);
        IDataResult<BlogDetailLangDTO> GetBlogLangById(int id, string langCode);
        IDataResult<List<BlogListDTO>> GetAllBlogs(string langCode);
        IResult RemoveBlog(int id);

    }
}