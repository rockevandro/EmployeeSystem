using System.Collections.Generic;

namespace EmployeeSystem.WebMVC.Models
{
    public class EmployeeViewModel
    {
        public EmployeeFilterModel EmployeeFilter { get; set; }
        public List<EmployeeModel> EmployeeList { get; set; }
    }
}
