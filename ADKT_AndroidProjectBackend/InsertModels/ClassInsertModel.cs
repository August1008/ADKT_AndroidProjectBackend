using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADKT_AndroidProjectBackend.InsertModels
{
    public class ClassInsertModel
    {
        public string ClassId { set; get; }
        public string Subject { set; get; }
        public DateTime startDate { set; get; }
        public DateTime endDate { set; get; }
        public string TeacherId { set; get; }

    }
}
