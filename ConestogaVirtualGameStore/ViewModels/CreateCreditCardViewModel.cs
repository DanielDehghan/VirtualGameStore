using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ConestogaVirtualGameStore.ViewModels
{
    public class CreateCreditCardViewModel
    {
        [BindNever]
        public int CreditCart_ID { get; set; }

        public int Member_ID { get; set; }

        [MinLength(16, ErrorMessage = "The minimum length is 16")]
        [MaxLength(16, ErrorMessage = "The maximum length is 16")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid credit card number")]
        [Required(ErrorMessage = "Credit card number is required")]
        public string? CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Credit card expiry date is required")]
        public DateTime? CreditCardExpiryDate { get; set; }

        [Required(ErrorMessage = "Cardholder name is required")]
        public string? CreditCardOwnerName { get; set; }

        [MinLength(3, ErrorMessage = "The minimum length is 3")]
        [MaxLength(3, ErrorMessage = "The maximum length is 16")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid CVV")]
        [Required(ErrorMessage = "Credit card verification number is required")]
        public string? CreditCardVerificationValue { get; set; }
    }
}
