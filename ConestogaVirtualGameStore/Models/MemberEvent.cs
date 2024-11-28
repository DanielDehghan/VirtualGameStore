using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConestogaVirtualGameStore.Models
{
    public class MemberEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberEvent_ID { get; set; }

        public int Event_ID { get; set; }
   
        public int Member_ID { get; set; }

        public Event Event { get; set; }    
        public Member Member { get; set; }

    }
}
