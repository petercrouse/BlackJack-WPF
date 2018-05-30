using System;
using System.ComponentModel.DataAnnotations;

namespace Game.Models.Entities

{
    public class GameUser : GameEntity
    {
        [Required]
        [MaxLength(25)]
        public string Alias { get; set; }

        public string Email { get; set; }
    }
}
