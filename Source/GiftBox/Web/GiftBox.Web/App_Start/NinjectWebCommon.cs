[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GiftBox.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GiftBox.Web.App_Start.NinjectWebCommon), "Stop")]

namespace GiftBox.Web.App_Start
{
    using System.Data.Entity;
    using System;
    using System.Web;

    using GiftBox.Data;
    using GiftBox.Data.Common.Repositories;
    using GiftBox.Data.Contracts;
    using GiftBox.Web.Infrastructure.Caching;
    using GiftBox.Web.Infrastructure.Populators;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<GiftBoxDbContext>().InRequestScope();
            kernel.Bind<IGiftBoxDbContext>().To<GiftBoxDbContext>().InRequestScope();

            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind(typeof(IDeletableEntityRepository<>)).To(typeof(DeletableEntityRepository<>));

            kernel.Bind<IDropDownListPopulator>().To<DropDownListPopulator>();
            kernel.Bind<ICacheService>().To<InMemoryCache>();

            kernel.Bind(b => b.From("GiftBox.Services.Data").SelectAllClasses().BindDefaultInterface());
        }        
    }
}
