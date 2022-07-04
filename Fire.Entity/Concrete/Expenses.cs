using Fire.Entity.Abstrack;
using System.ComponentModel.DataAnnotations;

namespace Fire.Entity.Concrete
{
    public class Expenses:IBaseEntity
    {
        [Key]
        public int id { get; set; }
        public string Description { get; set; }
        public decimal ExpensesPrice { get; set; }
        public bool personSalaryControll { get; set; }
        public int branchid { get; set; }
    }
}
