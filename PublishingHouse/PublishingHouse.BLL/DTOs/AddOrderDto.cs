using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublishingHouse.BLL.DTOs
{
    public class AddOrderDto
    {
        [Required]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Прізвище")]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефону")]
        public string Phone { get; set; }
        [Required]
        public string Deliver { get; set; }
        public string DeliverAddress { get; set; }
        public DateTime DateTime { get; set; }
        public List<CartDto> Carts { get; set; }        
    }
}
