using System.Data;

namespace QLBANCAFE.DTO
{
    public class BillInfor
    {
        private int iD;
        private int idBill;
        private int idFood;
        private int count;

        public int IdBill
        {
            get => idBill;
            set => idBill = value;
        }
        public int IdFood
        {
            get => idFood;
            set => idFood = value;
        }
        public int Count
        {
            get => count;
            set => count = value;
        }
        public int ID
        { 
            get => iD;
            set => iD = value; 
        }

        public BillInfor(int id, int idBill, int idFood, int count)
        {
            this.IdBill = idBill;
            this.IdFood = idFood;
            this.Count  =  count;
            this.ID     =    id;
        } 
        public BillInfor(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IdBill = (int)row["idBill"];
            this.IdFood = (int)row["idFood"];
            this.Count = (int)row["count"];

        }
    }
}

