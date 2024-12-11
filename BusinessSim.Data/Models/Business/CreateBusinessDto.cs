using BusinessSim.Data.Enumerations;

namespace BusinessSim.Data.Models.Business
{
    public class CreateBusinessDto
    {
        public Guid PlayerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public Industry Industry { get; set; }
    }
}
