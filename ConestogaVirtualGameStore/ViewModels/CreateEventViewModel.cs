using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class CreateEventViewModel
    {
        [BindNever]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(255)]
        public string Address { get; set; }


        [Required(ErrorMessage = "Country is required")]
        [StringLength(255)]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(255)]
        public string City { get; set; }

        [Required(ErrorMessage = "Province is required")]
        [StringLength(255)]
        public string SelectedProvince { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [StringLength(255)]
        [RegularExpression(@"[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage = "Postal code is not valid")]
        public string PostalCode { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        [BindNever]
        public IEnumerable<SelectListItem> Provinces { get; set; }
    }
}
