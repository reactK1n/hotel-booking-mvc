using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_booking_model
{
    public class TransactionPeriod
    {
        /// <summary>  
        /// DOB datetime data type property   
        /// to display date type control  
        /// </summary>  
        [Display(Name = "")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
        
    }
}
