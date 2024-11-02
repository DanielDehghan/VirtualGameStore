using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConestogaVirtualGameStore.Models
{
    public class MemberEvent
    {
        [Key]
        public int MemberEvent_ID { get; set; }

        public int RegisteredMember_ID { get; set; }

        public int RegisteredEvent_ID { get; set; }

        // Foreign key to event
        [ForeignKey("Event")]
        public int EventID { get; set; }
        public virtual Event Event { get; set; }

        // Foreign key to member
        [ForeignKey("Member")]
        public int MemberID { get; set; }
        public virtual Member Member { get; set; }
    }
}
