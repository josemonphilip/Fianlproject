using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class AssesmentAnswer
    {
        public int AssesmentAnswerID { get; set; }
        public string Options { get; set; }
        public int AssesmentQuestionID { get; set; }
        public int Score { get; set; }


        [ForeignKey("AssesmentQuestionID")]
        public AssesmentQuestion AssesmentQuestion { get; set; }
    }
}
