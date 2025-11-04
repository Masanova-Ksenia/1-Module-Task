using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._1
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Имя: {Name}, Email: {Email}, " +
                   $"Регистрация: {RegistrationDate:dd.MM.yyyy}, Статус: {Status}";
        }
    }
}
