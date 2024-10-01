using System.ComponentModel.DataAnnotations;

namespace HireMeAPI.DTOs
{
    public class WorkFieldDTO
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        
        
    }
}
