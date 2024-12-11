using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessSim.Data.Entities
{
    public class Player : BaseEntity
    {
        /// <summary>
        /// the name of the player to be used in the game
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// a list of businesses owned by the player
        /// </summary>
        [NotMapped]
        public IList<Business> Businesses { get; set; } = new List<Business>();

        [NotMapped]
        public decimal TotalWealth { get; set; }
    }
}
