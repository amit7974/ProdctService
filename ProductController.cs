using CrudFullstack.Data;
using CrudFullstack.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CrudFullstack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductController : ControllerBase
    {
        // note..when ever you communication with components  through  service  in Angular you  must create variable..like private readonly AppDpContext_context;


        public readonly AppDbContext _context;
        //it is coonstructor  with AppDpcontext dependency Injection.
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        //this method is used to get all products from the database.
        [HttpGet("getAllProduct")]

        public IActionResult getAllProducts()
        {
            try
            {
                var product = _context.Products.ToList();
                if (product.Count==0) {
                    return NotFound("No products available");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error :"+ ex.Message);
            }

     
        }
        // add new products
        [HttpPost("AddProduct")]
        public IActionResult AddProducts(Product Products)
        {
            _context.Products.Add(Products);
            _context.SaveChanges();
            return Ok("Product added successfully");
        }
        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(Product Products,int id)
        {
            try
            {
                var isRecordAvailable = _context.Products.SingleOrDefault(m => m.productId == id);
                if (isRecordAvailable == null)
                {
                    return NotFound("Product not found");
                }

                isRecordAvailable.productName = Products.productName;
                isRecordAvailable.productPrice = Products.productPrice;
                isRecordAvailable.productDescription = Products.productDescription;
                isRecordAvailable.productCategory = Products.productCategory;
                isRecordAvailable.IsExpire = Products.IsExpire;
                isRecordAvailable.DateTime = Products.DateTime;
                _context.SaveChanges();
                return Ok("Product added sucessfully");
            }

            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }

            
        }
        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {

                var singleRecord = _context.Products.SingleOrDefault(m => m.productId == id);
                if (singleRecord == null)
                {
                    return NotFound("Product not found");
                }
                _context.Products.Remove(singleRecord);
                return Ok("product delete");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error:" + ex.Message);
            }
        }
    }



}
