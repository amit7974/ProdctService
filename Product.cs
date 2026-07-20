using System.ComponentModel.DataAnnotations;

namespace CrudFullstack.Model
{
    public class Product
    {
        public int productId { get; set; }
        //createvalidation for productName
        [Required(ErrorMessage = "Product Name is required")]
        public string? productName { get; set; }

        public double productPrice { get; set; }

        public string? productDescription { get; set; } = null;
        public string productCategory { get; set; }
        public bool IsExpire { get; set; }

        public DateTime DateTime {  get; set; }
        
           
        }
    }
