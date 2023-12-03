using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Services.AddSingleton<> karşılığı = builder.RegisterType<>
            //ProductManager istenilirse IProductService veriyoruz.
            //Çoklu instance üretmek yerine 1 tane instance üretiliyor.
            //Program.cs karşılığı buradadır.
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<ModelManager>().As<IModelService>().SingleInstance();
            builder.RegisterType<EfModelDal>().As<IModelDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<VehicleManager>().As<IVehicleService>().SingleInstance();
            builder.RegisterType<EfVehicleDal>().As<IVehicleDal>().SingleInstance();

            builder.RegisterType<VehicleImageManager>().As<IVehicleImagesService>().SingleInstance();
            builder.RegisterType<EfVehicleImageDal>().As<IVehicleImageDal>().SingleInstance();

            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();
           

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //İmplemente edilmiş sınıfları bul,AspectInterceptoru çağır anlamında.
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}