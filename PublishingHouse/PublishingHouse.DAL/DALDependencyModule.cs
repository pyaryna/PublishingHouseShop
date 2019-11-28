using Autofac;
using PublishingHouse.DAL.Interfaces.Repositories;
using PublishingHouse.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.DAL
{
    public class DALDependencyModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {                  
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<PublishingHouseUnitOfWork>().As<IPublishingHouseUnitOfWork>();
        }
    }
}
