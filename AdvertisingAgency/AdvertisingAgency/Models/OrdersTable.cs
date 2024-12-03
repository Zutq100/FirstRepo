using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingAgency.Models
{
    public class OrdersTable
    {
        //Модель в которой поля соответствуют, полям в базе данных за исключение поля Client и Reviews, которые создаются для связи по внешнему ключу.
        public int ID { get; set; }
        public int ClientID { get; set; }
        public double Budget {  get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string TermOfRealization { get; set; }
        public ClientsTable Client {  get; set; }
        public List<ReviewsTable> Reviews { get; set; }

        //Переопределенный метод с помощью которого возвращается строка в нужном виде.
        public override string ToString()
            => $"ID ({ID}) " + (Client == null ? "Неизвестно" : Client.FullName) + $" - Бюджет на рекламу:{Budget} руб\n" + (Client == null ? "Неизвестно" : $"Email клиента: {Client.Email}\nТелефон клиента: {Client.Telephone}") + $"\n{Description}\nСрок заказа:{TermOfRealization}\nСтатус заказа: {Status}";
    }
}
