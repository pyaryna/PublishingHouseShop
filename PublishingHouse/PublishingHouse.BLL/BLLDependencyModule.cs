using Autofac;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.BLL.Services;
using PublishingHouse.DAL;
using PublishingHouse.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse.BLL
{
    public class BLLDependencyModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<AuthorService>().As<IAuthorService>();
            builder.RegisterType<CartService>().As<ICartService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<NotificationService>().As<INotificationService>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            builder.RegisterModule<DALDependencyModule>();
        }
    }
}
