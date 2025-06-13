using QLBANCAFE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBANCAFE.DAO
{
    public class BillInforDAO
    {
        private static BillInforDAO instance;
        public static BillInforDAO Instance
        {
            get { if (instance == null) instance = new BillInforDAO(); return BillInforDAO.instance; }
            private set { BillInforDAO.instance = value; }

        }
        private BillInforDAO() { }

        public List<BillInfor> GetListBillInfor(int id)
        {
            List<BillInfor> listbillinfor = new List<BillInfor>();

            DataTable data = DataProvide.Instance.ExcuteQuery("GetBillInforByID @idBill ="+ id);

            foreach(DataRow item in data.Rows)
            {
                BillInfor infor = new BillInfor(item);
                listbillinfor.Add(infor);
            }
            return listbillinfor;
        }
        public void InsertBillInfor(int idbill, int idfood, int count)
        {
            DataProvide.Instance.ExcuteNonQuery("InsertBillInfor @idTable , @idFood , @count", new object[] { idbill, idfood, count });
        }
    }
}
