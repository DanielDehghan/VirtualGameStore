using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class CheckOutViewModel
    {
        public decimal Total { get; set; }

        public int Member_ID { get; set; }

        public Member Member { get; set; }

        public List<CreditCards> CreditCards { get; set; }
    }
}
