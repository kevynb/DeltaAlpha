using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace DeltaAlpha.Models
{
    public class Brother
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string HomeTown { get; set; }
        public string NickName { get; set; }
        public string Position { get; set; }

        public int? PledgeClassId { get; set; }
        public int? BigBrotherId { get; set; }
        public int FamilyId { get; set; }

        public Family Family { get; set; }
        public PledgeClass PledgeClass { get; set; }
        public virtual Brother BigBrother { get; set; }
        public virtual ICollection<Brother> LittleBrothers { get; set; }

        public string FullName
        {
            get { return this.FirstName + " " + this.MiddleName + " " + this.LastName; }
        }
    }
}