using Autofac;

using Business.Abstract;
using Business.Concrete;

using Core.Utilities.Security.Jwt;

using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinnessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfSehirlerDal>().As<ISehirlerDal>();
            builder.RegisterType<SehirlerManager>().As<ISehirlerService>();

            builder.RegisterType<EfSehirlerHavaDurumlariDal>().As<ISehirlerHavaDurumlariDal>();
            builder.RegisterType<SehirlerHavaDurumuManager>().As<ISehirlerHavaDurumuService>();

            builder.RegisterType<EfSysLogDal>().As<ISysLogDal>();
            builder.RegisterType<SysLogManager>().As<ISysLog>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
