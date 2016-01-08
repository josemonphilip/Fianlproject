using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rc.Domain
{
    public class AssesmentQuestion
    {
        public int AssesmentQuestionID { get; set; }
        public string Question { get; set; }
        public int SortOrder { get; set; }
        public int AssesmentType { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<AssesmentAnswer> AssesmentAnswers { get; set; }
    }
}
