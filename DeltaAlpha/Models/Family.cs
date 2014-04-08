using System.Collections.Generic;

namespace DeltaAlpha.Models
{
    public class Family
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Brother> Members { get; set; }

        public Family()
        {
            Members = new HashSet<Brother>();
        }
    }
}