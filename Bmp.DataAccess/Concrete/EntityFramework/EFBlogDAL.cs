using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Helper;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.BlogDTOs;
using Microsoft.EntityFrameworkCore;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFBlogDAL : EfEntityRepositoryBase<Blog, AppDbContext>, IBlogDAL
    {
        public async Task<bool> AddBlog(BlogAddDTO blogAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                Blog blog = new()
                {
                    CoverPhoto = await blogAddDTO.CoverPhoto.SaveFileAsync(webRootPath),
                };

                for (int i = 0; i < blogAddDTO.MainTitle.Count; i++)
                {
                    BlogLanguage blogLanguage = new()
                    {
                        BlogId = blog.Id,
                        MainTitle = blogAddDTO.MainTitle[i],
                        MainContent = blogAddDTO.MainContent[i],
                        LangCode = blogAddDTO.LangCode[i]
                    };

                    blog.BlogLanguages.Add(blogLanguage);
                }

                for (int i = 0; i < blogAddDTO.BlogContents.Count; i++)
                {
                    BlogContent blogContent = new()
                    {
                        BlogId = blog.Id,
                    };
                    await context.BlogContents.AddAsync(blogContent);

                    for (int j = 0; j < blogAddDTO.BlogContents[i].Title.Count; j++)
                    {
                        BlogContentLanguage blogContentLanguage = new()
                        {
                            BlogContentId = blogContent.Id,
                            Title = blogAddDTO.BlogContents[i].Title[j],
                            Content = blogAddDTO.BlogContents[i].Content[j],
                            LangCode = blogAddDTO.LangCode[j]
                        };
                        blogContent.BlogContentLanguages.Add(blogContentLanguage);
                    }

                    blog.BlogContents.Add(blogContent);
                }

                for (int i = 0; i < blogAddDTO.PhotoUrl.Count; i++)
                {
                    BlogPhoto blogPhoto = new()
                    {
                        BlogId = blog.Id,
                        PhotoUrl = await blogAddDTO.PhotoUrl[i].SaveFileAsync(webRootPath),
                    };
                    blog.BlogPhotos.Add(blogPhoto);
                }

                await context.Blogs.AddAsync(blog);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<BlogListDTO> GetAllBlogList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Blogs.Select(x => new BlogListDTO
            {
                Id = x.Id,
                MainTitle = x.BlogLanguages.FirstOrDefault(x => x.LangCode == langCode).MainTitle,
                MainContent = x.BlogLanguages.FirstOrDefault(x => x.LangCode == langCode).MainContent,
                PhotoUrl = x.BlogPhotos.Select(x => x.PhotoUrl).ToList(),
                CoverPhoto = x.CoverPhoto,
                Contents = x.BlogContents.Select(f => new BlogContentListDTO
                {
                    Title = f.BlogContentLanguages
                                         .Where(l => l.LangCode == langCode)
                                         .Select(l => l.Title)
                                         .ToList(),
                    Content = f.BlogContentLanguages
                                         .Where(l => l.LangCode == langCode)
                                         .Select(l => l.Content)
                                         .ToList(),
                }).ToList()
            }).ToList();

            return result;
        }

        public BlogDetailDTO GetBlogByIdAdmin(int Id)
        {
            using var context = new AppDbContext();

            var result = context.Blogs
                .Include(x => x.BlogLanguages)
                .Include(x => x.BlogContents)
                .Include(x => x.BlogPhotos)
                .Select(x => new BlogDetailDTO()
                {
                    Id = x.Id,
                    CoverPhoto = x.CoverPhoto,
                    UpdatedDate = x.UpdatedDate,
                    CreatedDate = x.CreatedDate,
                    MainTitle = x.BlogLanguages.Select(x => x.MainTitle).ToList(),
                    MainContent = x.BlogLanguages.Select(x => x.MainContent).ToList(),
                    PhotoUrl = x.BlogPhotos.Select(x => x.PhotoUrl).ToList(),
                    Contents = x.BlogContents.Select(f => new BlogContentListDTO
                    {
                        Title = f.BlogContentLanguages.Select(l => l.Title).ToList(),
                        Content = f.BlogContentLanguages.Select(l => l.Content).ToList(),
                    }).ToList()
                })
                .FirstOrDefault(x => x.Id == Id);
            return result;
        }

        public BlogDetailLangDTO GetBlogLangById(int Id, string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Blogs
                .Include(x => x.BlogLanguages)
                .Include(x => x.BlogContents)
                .Include(x => x.BlogPhotos)
                .Select(x => new BlogDetailLangDTO()
                {
                    Id = x.Id,
                    CoverPhoto = x.CoverPhoto,
                    UpdatedDate = x.UpdatedDate,
                    CreatedDate = x.CreatedDate,
                    MainContent = x.BlogLanguages
                        .Where(hbl => hbl.LangCode == langCode)
                        .Select(hbl => hbl.MainContent)
                        .FirstOrDefault(),
                    MainTitle = x.BlogLanguages
                        .Where(hbl => hbl.LangCode == langCode)
                        .Select(hbl => hbl.MainTitle)
                        .FirstOrDefault(),
                    PhotoUrls = x.BlogPhotos
                        .Select(hbp => hbp.PhotoUrl)
                        .ToList(),
                    Contents = x.BlogContents.Select(f => new BlogContentLangDTO
                    {
                        Title = f.BlogContentLanguages
                            .Where(hbfl => hbfl.LangCode == langCode)
                            .Select(hbfl => hbfl.Title)
                            .FirstOrDefault(),
                        Content = f.BlogContentLanguages
                            .Where(hbfl => hbfl.LangCode == langCode)
                            .Select(hbfl => hbfl.Content)
                            .FirstOrDefault(),
                    }).ToList()
                })
                .FirstOrDefault(x => x.Id == Id);
            return result;
        }


        public async Task<bool> UpdateBlog(BlogUpdateDTO blogUpdateDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                var blog = context.Blogs.FirstOrDefault(x => x.Id == blogUpdateDTO.Id);

                if (blogUpdateDTO.CoverPhoto != null)
                {
                    blog.CoverPhoto = await blogUpdateDTO.CoverPhoto.SaveFileAsync(webRootPath);
                }


                var blogLanguages = context.BlogLanguages.Where(x => x.BlogId == blog.Id).ToList();
                for (int i = 0; i < blogLanguages.Count; i++)
                {
                    blogLanguages[i].MainTitle = blogUpdateDTO.MainTitle[i];
                    blogLanguages[i].MainContent = blogUpdateDTO.MainContent[i];
                }
                context.BlogLanguages.UpdateRange(blogLanguages);


                if (blogUpdateDTO.PhotoUrl != null)
                {
                    var blogPhotos = context.BlogPhotos.Where(x => x.BlogId == blog.Id).ToList();

                    // Delete all existing photos
                    context.BlogPhotos.RemoveRange(blogPhotos);

                    // Add new photos
                    foreach (var photoUrl in blogUpdateDTO.PhotoUrl)
                    {
                        var newPhoto = new BlogPhoto
                        {
                            BlogId = blog.Id,
                            PhotoUrl = await photoUrl.SaveFileAsync(webRootPath)
                        };
                        context.BlogPhotos.Add(newPhoto);
                    }

                    context.SaveChanges();
                }

                var blogContents = context.BlogContents.Include(f => f.BlogContentLanguages).Where(x => x.BlogId == blog.Id).ToList();

                for (int i = 0; i < blogContents.Count; i++)
                {
                    for (int j = 0; j < blogContents[i].BlogContentLanguages.Count; j++)
                    {
                        blogContents[i].BlogContentLanguages[j].Title = blogUpdateDTO.BlogContents[i].Title[j];
                        blogContents[i].BlogContentLanguages[j].Content = blogUpdateDTO.BlogContents[i].Content[j];
                    }
                }


                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


    }
}
