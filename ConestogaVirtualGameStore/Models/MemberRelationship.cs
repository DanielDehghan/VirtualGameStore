using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConestogaVirtualGameStore.Models
{
    public class MemberRelationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberRelationshipId { get; set; }

        // Member that adds a new member
        public int Member_ID { get; set; }

        public int Relationship_ID { get; set; }

        // Member that is added by Member_ID
        public int MemberAdded_ID { get; set; }

        public Member Member { get; set; }

        public Member MemberAdded { get; set; }

        public Relationship Relationship { get; set; }
    }

}
