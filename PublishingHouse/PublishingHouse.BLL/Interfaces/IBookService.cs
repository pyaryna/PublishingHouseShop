using PublishingHouse.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookPreviewDto>> GetDishesInfoAsync();
    }
}
