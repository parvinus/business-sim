using System.ComponentModel.DataAnnotations;
using BusinessSim.Data.Enumerations;

namespace BusinessSim.Data.Entities
{
    public class BankAccount : BaseEntity
    {
        /// <summary>
        /// a human-friendly name to identify the account
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// the amount of currency held in this account
        /// </summary>
        [Required]
        public decimal Balance { get; set; }

        /// <summary>
        /// Separates personal accounts of the player from business and department accounts
        /// </summary>
        [Required]
        public AccountType Type { get; set; }

        /// <summary>
        /// The unique ID to link the player or business to the account
        /// </summary>
        [Required]
        public Guid ParentId { get; set; }

        /// <summary>
        /// The unit of currency the account holds
        /// </summary>
        [Required]
        public CurrencyUnit CurrencyUnit { get; set; }
    }
}
