using Bmp.Core.DataAccess;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.BlogDTOs;


namespace Bmp.DataAccess.Abstarct
{
    public interface IBlogDAL : IEntityRepository<Blog>
    {
        Task<bool> AddBlog(BlogAddDTO blogAddDTO, string webRootPath);
        Task<bool> UpdateBlog(BlogUpdateDTO blogUpdateDTO, string webRootPath);
        BlogDetailDTO GetBlogByIdAdmin(int Id);
        BlogDetailLangDTO GetBlogLangById(int Id, string langCode);
        List<BlogListDTO> GetAllBlogList(string langCode);
    }
}
