using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class BaseRepModel
    {
        public string ID { get; set; }
        public string Rep { get; set; }
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string AltPhone { get; set; }
        public string MemoForUpdate { get; set; }
    }
}
