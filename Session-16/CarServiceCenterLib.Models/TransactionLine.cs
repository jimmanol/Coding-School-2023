using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Models {
    public class TransactionLine {

        // Properties
        public Guid ID { get; set; }
        public double Hours { get; set; }
        public double PricePerHour { get; set; } //constant maybe
        public double Price { get; set; }

        //Relations
        public Guid TransactionID { get; set; }
        public Guid EngineerID { get; set; }
        public Guid ServiceTaskID { get; set; }
        public Transaction Transaction { get; set; }
        //public Engineer Engineer { get; set; }
        //public ServiceTask ServiceTask { get; set; }

        //Constrators
        public TransactionLine() {
            ID = Guid.NewGuid();
        }
        public TransactionLine(Guid transactionID, Guid serviceTaskID, Guid engineerID, double hours, double pricePerHour) {
            ID = Guid.NewGuid();
            TransactionID = transactionID;
            ServiceTaskID = serviceTaskID;
            EngineerID = engineerID;
            PricePerHour = pricePerHour;
            Hours = hours;
            Price = pricePerHour * hours;
        }
    }
}