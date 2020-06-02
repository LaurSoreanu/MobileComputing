using HotelManagement.Common.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.DataModel.Model
{
    public class Language : IIdentifiable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(20)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(2)")]
        public string Code { get; set; }
    }
}
