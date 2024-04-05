using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static OrderService.Models.Utility;

namespace OrderService.Models
{

    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public int Status { get; set; }


    }
}
