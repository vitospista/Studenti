using CorsoEnaip2018_ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsoEnaip2018_ProjectManagement.ViewModels
{
    public class ProjectRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public DateTime Delivery { get; set; }
        public string IsInTime { get; set; }
        public decimal Gain { get; set; }

        public static ProjectRow Map(Project model)
        {
            return new ProjectRow
            {
                CustomerName = model.Customer.Name,
                IsInTime = model.EndDate > model.DeliveryDate
                    ? "Scaduto"
                    : "Ok",
                Gain = model.Price - model.Cost,
            };
        }
    }
}
