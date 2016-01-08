using rc.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.DAL
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        //static BaseContext()
        //{
        //    Database.SetInitializer<TContext>(null);
        //}
        public BaseContext()
            : base("rcContext")
        {
            Database.SetInitializer<rcContext>(new dbInit());
        }

    }

    public class dbInit : DropCreateDatabaseIfModelChanges<rcContext>
    {
        protected override void Seed(rcContext context)
        {
            Customer cust = new Customer() {NursingHomeName="XXXX",Address="XXXX",City="xxxxx",ContactName="XXX",Email="xx@xx.com" };
            context.Customers.Add(cust);
            //Ward w = new Ward() {Description="Ward-1",CustomerID=1,TotalBeds=20 };
            //context.Wards.Add(w);
           // GeneralPractitioner gp = new GeneralPractitioner() { FirstName = "fname", SurName = "sname", Address = "address" };
            //context.GeneralPractitioners.Add(gp);
            base.Seed(context);
        }
    }
}
