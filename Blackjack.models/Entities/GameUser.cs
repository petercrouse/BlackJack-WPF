using System.ComponentModel.DataAnnotations;

namespace Blackjack.models.Entities

{
    public class GameUser
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Alias { get; set; }
        public string Email { get; set; }
    }
}
