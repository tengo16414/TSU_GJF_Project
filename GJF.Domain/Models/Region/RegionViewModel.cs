using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GJF.Domain.Models.Region
{
    public class RegionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "შევსება აუცილებელია")]
        [DisplayName("რეგიონი")]
        [Remote("IsValidRegion", "Validator", AdditionalFields = "Id", ErrorMessage = "აღნიშნული რეგიონი უკვე არსებობს!")]
        public string Name { get; set; }
    }
}
