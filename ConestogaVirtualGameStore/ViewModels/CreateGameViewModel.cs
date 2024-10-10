using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class CreateGameViewModel
    {
        [BindNever]
        public int GameId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string SelectedGenre { get; set; }

        [Required(ErrorMessage = "Release Date is required")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Platform is required")]

        public string SelectedPlatform { get; set; }


        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 999.99, ErrorMessage = "Price must be between 0.01 and 999.99")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Cover Image URL is required")]
        [Url(ErrorMessage = "Invalid URL format")]
        public string CoverImageURL { get; set; }

        [BindNever]
        public IEnumerable<SelectListItem> Platforms { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem> Genres { get; set; }

    }
}
