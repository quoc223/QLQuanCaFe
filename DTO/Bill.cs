using System;
using System.Data;

namespace QLBANCAFE.DTO
{
    public class Bill
    {
        private int status;
        private DateTime? dateTimeCheckOut;
        private DateTime? dateTimeCheckIn;

        private int iD;

        public int ID
        {
            get => iD;
            set => iD = value;
        }
        public DateTime? DateTimeCheckOut
        {
            get => dateTimeCheckOut; 
            set => dateTimeCheckOut = value;
        }
        public int Status
        { 
            get => status; 
            set => status = value; 
        }
        public DateTime? DateTimeCheckIn
        { 
            get => dateTimeCheckIn; 
            set => dateTimeCheckIn = value;
        }

        public Bill(int id, DateTime? dateCheckOut, DateTime? dateCheckIn, int status)
        {
            this.iD = id;
            this.DateTimeCheckOut = dateCheckOut;
            this.DateTimeCheckIn = dateCheckIn;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.iD = (int)row["id"];
           
            this.dateTimeCheckIn = (DateTime?)row["dateCheckIn"];

            var dateTimeCheckOutTemp = row["dateCheckOut"];
            if(dateTimeCheckOutTemp.ToString() !="")
            this.dateTimeCheckOut = (DateTime?)dateTimeCheckOutTemp;

            this.status = (int)row["status"];
           
           




        }

    }
}
