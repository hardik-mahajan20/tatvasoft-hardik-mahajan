using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Logic_Layer.Entity
{
    public class ResposeResult
    {
        public Object Data { get; set; }    

        public String Message {  get; set; }
        public ResponseStatus Result {  get; set; } 

    }
    public enum ResponseStatus
    {
        Error,
        Success
    }

}
