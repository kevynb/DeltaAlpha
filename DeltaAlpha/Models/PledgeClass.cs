using System.Collections.Generic;

namespace DeltaAlpha.Models
{
    public class PledgeClass
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }

        public ICollection<Brother> Members { get; set; }

        public PledgeClass()
        {
            Members = new HashSet<Brother>();
        }
    }
}