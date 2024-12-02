using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class GameDetailViewModel
    {
        public string Title { get; set; }
        public Game Game { get; set; }
        public IEnumerable<Game> GameRecommendations { get; set; }
        public IEnumerable<Review> GameReviews { get; set; }

        public int Member_ID;
        public float AverageRating { get; set; }
        public bool HasBeenReviewed { get; set; }
        public bool IsBought { get; set; }
    }
}
