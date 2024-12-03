using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class ReviewsTable
    {
        //Модель в которой поля соответствуют, полям в базе данных за исключение поля Order, которое создается для связи по внешнему ключу.
        public int ID { get; set; }
        public int OrderID { get; set; }
        public string DescriptionReviews { get; set; }
        public OrdersTable Order { get; set; }

    }
}
