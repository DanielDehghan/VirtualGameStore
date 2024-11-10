using ConestogaVirtualGameStore.Models;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class GameDetailViewModel
    {
        public string Title { get; set; }
        public Game Game { get; set; }
        public IEnumerable<Game> GameRecommendations { get; set; }
    }
}
