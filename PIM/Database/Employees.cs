using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PIM.Database
{
    public class Employees
    {
        public string Id { get; set; }
        public string IdPermissao { get; set; }
        public string IdCargo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public string Situacao { get; set; }

        public Employees MapFromDB(DataRow d)
        {
            Employees employee = new Employees();

            try
            {

                var properties = typeof(Employees).GetProperties();

                foreach (var property in properties)
                {
                    var value = d[property.Name];

                    if (value != null) property.SetValue(employee, value.ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employee;
        }

        public T MapFromDB<T>(DataRow d) where T : new()
        {
            T employee = new T();

            try
            {

                var properties = typeof(T).GetProperties();

                foreach (var property in properties)
                {
                    var value = d[property.Name];

                    if (value != null) property.SetValue(employee, value.ToString());
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employee;
        }

    }
}
