using System.ComponentModel.DataAnnotations;
using BusinessSim.Data.Enumerations;

namespace BusinessSim.Data.Entities
{
    public class Business : BaseEntity
    {
        /// <summary>
        /// The ID of the player who owns the business
        /// </summary>
        [Required]
        public Guid PlayerId { get; set; }

        /// <summary>
        /// a human-friendly name for the business
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The specific industry the business competes in
        /// </summary>
        [Required]
        public Industry Industry { get; set; }
    }
}
