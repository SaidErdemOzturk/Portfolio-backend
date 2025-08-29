using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterType<ProjectManager>().As<IProjectService>().SingleInstance();
            builder.RegisterType<EfProjectDal>().As<IProjectDal>().SingleInstance();

            builder.RegisterType<TechnologyManager>().As<ITechnologyService>().SingleInstance();
            builder.RegisterType<EfTechnologyDal>().As<ITechnologyDal>().SingleInstance();

            builder.RegisterType<ImageManager>().As<IImageService>().SingleInstance();
            builder.RegisterType<EfImageDal>().As<IImageDal>().SingleInstance();

            builder.RegisterType<JobManager>().As<IJobService>().SingleInstance();
            builder.RegisterType<EfJobDal>().As<IJobDal>().SingleInstance();

            builder.RegisterType<JobDescriptionManager>().As<IJobDescriptionService>().SingleInstance();
            builder.RegisterType<EfJobDescriptionDal>().As<IJobDescriptionDal>().SingleInstance();

            builder.RegisterType<ProfileManager>().As<IProfileService>().SingleInstance();
            builder.RegisterType<EfProfileDal>().As<IProfileDal>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            
        }
    }
}
