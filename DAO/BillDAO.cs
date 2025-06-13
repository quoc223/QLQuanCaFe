using QLBANCAFE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBANCAFE.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }

        }
        private BillDAO() { }
        /// <summary>
        /// Thành công bill id
        /// Thất bại -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data= DataProvide.Instance.ExcuteQuery("select b.id, b.dateCheckOut, b.dateCheckIn, b.status  from bill b where idTable =" + id + " and status = 0");
            if(data.Rows.Count>0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        /// <summary>
        /// Chèn thêm bill mơi vào
        /// </summary>
        /// <param name="id"></param>
        public void InsertBill(int id)
        {
            DataProvide.Instance.ExcuteNonQuery("exec InsertBill @idTable ", new object[] { id });
        }
        public int GetMaxIDBill()
        {
            try 
            {
                return (int)DataProvide.Instance.ExcuteScalar("Select Max(id) from BILL");
            }
            catch
            {
                return 1;
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void CheckOut(int id)
        {
            string query = "UPDATE dbo.BILL Set status = 1 where id ="+id;
            DataProvide.Instance.ExcuteNonQuery(query);
        }
    }
}
