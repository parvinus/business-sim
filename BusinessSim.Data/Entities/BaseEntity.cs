using System.ComponentModel.DataAnnotations;

namespace BusinessSim.Data.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// a GUID to uniquely identify any individual record
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The date and time the record was created
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// the date and time the record was last updated
        /// </summary>
        [Required]
        public DateTime DateLastModified { get; set; }
    }
}
