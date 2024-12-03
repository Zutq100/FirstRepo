using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class ClientsTable
    {
        //Модель в которой поля соответствуют, полям в базе данных за исключение поля Requests, которое создается для связи по внешнему ключу.
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public List<OrdersTable> Requests { get; set; }
        //Переопределенный метод с помощью которого возвращается строка в нужном виде.
        public override string ToString()
            => $"ID ({ID}) - {FullName} ({Age} лет)\nEmail: {Email}\nНомер телефона: {Telephone}";
    }
}
