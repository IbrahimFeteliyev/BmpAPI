using AutoMapper;
using Bmp.Business.Abstarct;
using Bmp.Business.AutoMapper;
using Bmp.Business.Concrete;
using Bmp.Core.Security.Hasing;
using Bmp.Core.Security.Models;
using Bmp.Core.Security.TokenHandler;
using Bmp.DataAccess.Abstarct;
using Bmp.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Bmp.Business.DependencyResolver
{
    public static class ServiceRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();


            services.AddScoped<HasingHandler>();
            services.AddScoped<TokenGenerator>();
            services.AddScoped<JWTConfig>();

            services.AddScoped<IAuthDal, AuthDal>();
            services.AddScoped<IAuthManager, AuthManager>();

            services.AddScoped<IUserRoleDal, UserRoleDal>();
            services.AddScoped<IUserRoleManager, UserRoleManager>();

            services.AddScoped<IRoleDal, RoleDal>();
            services.AddScoped<IRoleManager, RoleManager>();

            services.AddScoped<IAboutDAL, EFAboutDAL>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IIntroductionDAL, EFIntroductionDAL>();
            services.AddScoped<IIntroductionService, IntroductionManager>();

            services.AddScoped<IAdvantageDAL, EFAdvantageDAL>();
            services.AddScoped<IAdvantageService, AdvantageManager>();

            services.AddScoped<IShortInfoDAL, EFShortInfoDAL>();
            services.AddScoped<IShortInfoService, ShortInfoManager>();

            services.AddScoped<IHospitalBranchDAL, EFHospitalBranchDAL>();
            services.AddScoped<IHospitalBranchService, HospitalBranchManager>();

            services.AddScoped<IContactDAL, EFContactDAL>();
            services.AddScoped<IContactService, ContactManager>();


            services.AddScoped<IDepartmentDAL, EFDepartmentDAL>();
            services.AddScoped<IDepartmentService, DepartmentManager>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
