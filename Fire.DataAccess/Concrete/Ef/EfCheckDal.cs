using Fire.DataAccess.Abstrack;
using Fire.DataAccess.DbConnection;
using Fire.Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Fire.DataAccess.Concrete.Ef
{
    public class EfCheckDal : EfRepositoryDal<Check, DataContext>, ICheckDal
    {
        public List<Check> GetCheckByBranchid(int brancid)
        {
            using (var db = new DataContext())
            {
                return db.CheckCont.Where(x => x.İsDelete == false && x.branchid == brancid).ToList();
            }
        }

        public Check GetCheckBySerialNumber(string serialnumber)
        {
            using (var db=new DataContext())
            {
                return db.CheckCont.Where(x => x.checkNumber == serialnumber && x.İsDelete == false).FirstOrDefault();
            }
        }

        public List<Check> GetEmptyCheckByGiveNumber(int branchid, int giveid)
        {
            using (var db = new DataContext())
            {
                var give = new List<Check>();
                if (branchid == 0)
                {
                    give = db.CheckCont.Where(x => x.İsDelete == false && x.toWhoWasGiven == giveid).ToList();

                }
                else
                {
                    give = db.CheckCont.Where(x => x.İsDelete == false && x.toWhoWasGiven == giveid && x.branchid == branchid).ToList();
                }
                return give;
            }
        }
    }
}
