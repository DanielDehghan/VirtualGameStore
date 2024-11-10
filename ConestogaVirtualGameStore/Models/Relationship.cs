using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.Models
{
    public class Relationship
    {
        [Key]
        public int Relationship_ID { get; set; }

        public string Relationship_Type { get; set; }

        public ICollection<MemberRelationship> MemberRelationship { get; set; }
    }
}
