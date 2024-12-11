using System.ComponentModel.DataAnnotations;

namespace BusinessSim.Data.Entities
{
    public class BusinessDepartment : BaseEntity
    {
        /// <summary>
        /// The GUID representing the business this department belongs to
        /// </summary>
        [Required]
        public Guid BusinessId { get; set; }

        /// <summary>
        /// a human-friendly name to identify this department
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A more detailed description of the department and its purpose
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
