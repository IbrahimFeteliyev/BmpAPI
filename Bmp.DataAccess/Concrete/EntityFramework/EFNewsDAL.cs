using Bmp.Core.DataAccess.EntityFramework;
using Bmp.Core.Helper;
using Bmp.DataAccess.Abstarct;
using Bmp.Entities.Concrete;
using Bmp.Entities.DTOs.NewsDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class EFNewsDAL : EfEntityRepositoryBase<News, AppDbContext>, INewsDAL
    {
        public async Task<bool> AddNews(NewsAddDTO blogAddDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                News blog = new()
                {
                    CoverPhoto = await blogAddDTO.CoverPhoto.SaveFileAsync(webRootPath),
                };

                for (int i = 0; i < blogAddDTO.MainTitle.Count; i++)
                {
                    NewsLanguage blogLanguage = new()
                    {
                        NewsId = blog.Id,
                        MainTitle = blogAddDTO.MainTitle[i],
                        MainContent = blogAddDTO.MainContent[i],
                        LangCode = blogAddDTO.LangCode[i]
                    };

                    blog.NewsLanguages.Add(blogLanguage);
                }

                for (int i = 0; i < blogAddDTO.NewsContents.Count; i++)
                {
                    NewsContent blogContent = new()
                    {
                        NewsId = blog.Id,
                    };
                    await context.NewsContents.AddAsync(blogContent);

                    for (int j = 0; j < blogAddDTO.NewsContents[i].Title.Count; j++)
                    {
                        NewsContentLanguage blogContentLanguage = new()
                        {
                            NewsContentId = blogContent.Id,
                            Title = blogAddDTO.NewsContents[i].Title[j],
                            Content = blogAddDTO.NewsContents[i].Content[j],
                            LangCode = blogAddDTO.LangCode[j]
                        };
                        blogContent.NewsContentLanguages.Add(blogContentLanguage);
                    }

                    blog.NewsContents.Add(blogContent);
                }

                for (int i = 0; i < blogAddDTO.PhotoUrl.Count; i++)
                {
                    NewsPhoto blogPhoto = new()
                    {
                        NewsId = blog.Id,
                        PhotoUrl = await blogAddDTO.PhotoUrl[i].SaveFileAsync(webRootPath),
                    };
                    blog.NewsPhotos.Add(blogPhoto);
                }

                await context.Newss.AddAsync(blog);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<NewsListDTO> GetAllNewsList(string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Newss.Select(x => new NewsListDTO
            {
                Id = x.Id,
                MainTitle = x.NewsLanguages.FirstOrDefault(x => x.LangCode == langCode).MainTitle,
                MainContent = x.NewsLanguages.FirstOrDefault(x => x.LangCode == langCode).MainContent,
                PhotoUrl = x.NewsPhotos.Select(x => x.PhotoUrl).ToList(),
                CoverPhoto = x.CoverPhoto,
                Contents = x.NewsContents.Select(f => new NewsContentListDTO
                {
                    Title = f.NewsContentLanguages
                                         .Where(l => l.LangCode == langCode)
                                         .Select(l => l.Title)
                                         .ToList(),
                    Content = f.NewsContentLanguages
                                         .Where(l => l.LangCode == langCode)
                                         .Select(l => l.Content)
                                         .ToList(),
                }).ToList()
            }).ToList();

            return result;
        }

        public NewsDetailDTO GetNewsByIdAdmin(int Id)
        {
            using var context = new AppDbContext();

            var result = context.Newss
                .Include(x => x.NewsLanguages)
                .Include(x => x.NewsContents)
                .Include(x => x.NewsPhotos)
                .Select(x => new NewsDetailDTO()
                {
                    Id = x.Id,
                    CoverPhoto = x.CoverPhoto,
                    UpdatedDate = x.UpdatedDate,
                    CreatedDate = x.CreatedDate,
                    MainTitle = x.NewsLanguages.Select(x => x.MainTitle).ToList(),
                    MainContent = x.NewsLanguages.Select(x => x.MainContent).ToList(),
                    PhotoUrl = x.NewsPhotos.Select(x => x.PhotoUrl).ToList(),
                    Contents = x.NewsContents.Select(f => new NewsContentListDTO
                    {
                        Title = f.NewsContentLanguages.Select(l => l.Title).ToList(),
                        Content = f.NewsContentLanguages.Select(l => l.Content).ToList(),
                    }).ToList()
                })
                .FirstOrDefault(x => x.Id == Id);
            return result;
        }

        public NewsDetailLangDTO GetNewsLangById(int Id, string langCode)
        {
            using var context = new AppDbContext();

            var result = context.Newss
                .Include(x => x.NewsLanguages)
                .Include(x => x.NewsContents)
                .Include(x => x.NewsPhotos)
                .Select(x => new NewsDetailLangDTO()
                {
                    Id = x.Id,
                    CoverPhoto = x.CoverPhoto,
                    UpdatedDate = x.UpdatedDate,
                    CreatedDate = x.CreatedDate,
                    MainContent = x.NewsLanguages
                        .Where(hbl => hbl.LangCode == langCode)
                        .Select(hbl => hbl.MainContent)
                        .FirstOrDefault(),
                    MainTitle = x.NewsLanguages
                        .Where(hbl => hbl.LangCode == langCode)
                        .Select(hbl => hbl.MainTitle)
                        .FirstOrDefault(),
                    PhotoUrls = x.NewsPhotos
                        .Select(hbp => hbp.PhotoUrl)
                        .ToList(),
                    Contents = x.NewsContents.Select(f => new NewsContentLangDTO
                    {
                        Title = f.NewsContentLanguages
                            .Where(hbfl => hbfl.LangCode == langCode)
                            .Select(hbfl => hbfl.Title)
                            .FirstOrDefault(),
                        Content = f.NewsContentLanguages
                            .Where(hbfl => hbfl.LangCode == langCode)
                            .Select(hbfl => hbfl.Content)
                            .FirstOrDefault(),
                    }).ToList()
                })
                .FirstOrDefault(x => x.Id == Id);
            return result;
        }


        public async Task<bool> UpdateNews(NewsUpdateDTO blogUpdateDTO, string webRootPath)
        {
            try
            {
                using var context = new AppDbContext();
                var blog = context.Newss.FirstOrDefault(x => x.Id == blogUpdateDTO.Id);

                if (blogUpdateDTO.CoverPhoto != null)
                {
                    blog.CoverPhoto = await blogUpdateDTO.CoverPhoto.SaveFileAsync(webRootPath);
                }


                var blogLanguages = context.NewsLanguages.Where(x => x.NewsId == blog.Id).ToList();
                for (int i = 0; i < blogLanguages.Count; i++)
                {
                    blogLanguages[i].MainTitle = blogUpdateDTO.MainTitle[i];
                    blogLanguages[i].MainContent = blogUpdateDTO.MainContent[i];
                }
                context.NewsLanguages.UpdateRange(blogLanguages);


                if (blogUpdateDTO.PhotoUrl != null)
                {
                    var blogPhotos = context.NewsPhotos.Where(x => x.NewsId == blog.Id).ToList();

                    // Delete all existing photos
                    context.NewsPhotos.RemoveRange(blogPhotos);

                    // Add new photos
                    foreach (var photoUrl in blogUpdateDTO.PhotoUrl)
                    {
                        var newPhoto = new NewsPhoto
                        {
                            NewsId = blog.Id,
                            PhotoUrl = await photoUrl.SaveFileAsync(webRootPath)
                        };
                        context.NewsPhotos.Add(newPhoto);
                    }

                    context.SaveChanges();
                }

                var blogContents = context.NewsContents.Include(f => f.NewsContentLanguages).Where(x => x.NewsId == blog.Id).ToList();

                for (int i = 0; i < blogContents.Count; i++)
                {
                    for (int j = 0; j < blogContents[i].NewsContentLanguages.Count; j++)
                    {
                        blogContents[i].NewsContentLanguages[j].Title = blogUpdateDTO.NewsContents[i].Title[j];
                        blogContents[i].NewsContentLanguages[j].Content = blogUpdateDTO.NewsContents[i].Content[j];
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
