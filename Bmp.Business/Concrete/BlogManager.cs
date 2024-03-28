using Bmp.Business.Abstarct;
using Bmp.Core.Utilities.Results.Abstract;
using Bmp.Core.Utilities.Results.Concrete.ErrorResults;
using Bmp.Core.Utilities.Results.Concrete.SuccessResults;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.DTOs.BlogDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDAL _blogDAL;

        public BlogManager(IBlogDAL blogDAL)
        {
            _blogDAL = blogDAL;
        }

        public async Task<IResult> AddBlogByLanguageAsync(BlogAddDTO blogAddDTO, string webRootPath)
        {
            var result = await _blogDAL.AddBlog(blogAddDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Blog created successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
        public IDataResult<List<BlogListDTO>> GetAllBlogs(string langCode)
        {
            try
            {
                var result = _blogDAL.GetAllBlogList(langCode);
                return new SuccessDataResult<List<BlogListDTO>>(result, "Listed");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<BlogListDTO>>(ex.Message);
            }
        }

        public IDataResult<BlogDetailDTO> GetBlogById(int id)
        {
            var result = _blogDAL.GetBlogByIdAdmin(id);
            return new SuccessDataResult<BlogDetailDTO>(result);
        }

        public IDataResult<BlogDetailLangDTO> GetBlogLangById(int id, string langCode)
        {
            var result = _blogDAL.GetBlogLangById(id, langCode);
            return new SuccessDataResult<BlogDetailLangDTO>(result);
        }

        public IResult RemoveBlog(int id)
        {
            var blog = _blogDAL.Get(x => x.Id == id);
            _blogDAL.Delete(blog);
            return new SuccessResult("Deleted Successfully");
        }

        public async Task<IResult> UpdateBlogByLanguageAsync(BlogUpdateDTO blogUpdateDTO, string webRootPath)
        {
            var result = await _blogDAL.UpdateBlog(blogUpdateDTO, webRootPath);
            if (result)
            {
                return new SuccessResult("Blog updated successfully");
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
