using Bussiness_Layer;
using Data_Access_Layer.Models;
using Data_Access_Layer.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RefresherProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminRepo _context;
       public AdminController(IAdminRepo context)
        {
            _context = context;
        }
        /// <summary>
        /// GET: Return the list of Products
        /// </summary>
        /// <returns>List of Products</returns>

        [HttpGet("GetAllFoodItems")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _context.GetAllProducts();
            if (products == null) BadRequest(new ViewResponseMessage { Message = "No Products Available" });
            return Ok(products);
        }

        /// <summary>
        /// Updates the Product in the Product table 
        /// </summary>
        /// <param name="requestproduct">Product</param>
        /// <returns>Operation is successfull or not </returns>

        [HttpPut("UpdateFoodItem/Id")]
        public ActionResult<ViewResponseMessage> UpdateProduct(Product product)
        {
            var res = _context.UpdateProduct(product);
            if (res == null) return BadRequest(new ViewResponseMessage { Message = "There is some wrong with the details you have entered" });
            return Ok(res);
        }

        /// <summary>
        /// Inserts the product into the Product Table
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Operation is successfull or not</returns>
        [HttpPost("AddFoodItem")]
        public ActionResult<ViewResponseMessage> InsertProduct(Product product)
        {
            var res = _context.InsertProduct(product);
            if (res == null) return BadRequest(new ViewResponseMessage { Message = "There is some wrong with the details you have entered" });
            return Ok(res);
        }
        /// <summary>
        /// Deletes the Product from the Product Table
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Operation is successfull or not</returns>

        [HttpDelete("DeleteFoodItem/{id}")]
        public ActionResult<ViewResponseMessage> DeleteProduct(int id)
        {
            var res = _context.DeleteProduct(id);
            if (res == null) return BadRequest(new ViewResponseMessage { Message = "There is some wrong with the details you have entered" });
            return Ok(res);
        }

        /// <summary>
        /// Gets the list of the Categories
        /// </summary>
        /// <returns>List of Categories</returns>

        [HttpGet("GetAllFoodCategories")]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _context.GetAllCategories();
            if (categories == null) BadRequest(new ViewResponseMessage { Message = "No Products Available" });
            return Ok(categories);
        }

        /// <summary>
        /// Get the Category with specific id 
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Category</returns>

        [HttpGet("GetFoodCategory/Id")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _context.GetCategory(id);
            if (category == null) return BadRequest(new ViewResponseMessage { Message = "There is some wrong with the details you have entered" });
            return Ok(category);
        }

        /// <summary>
        /// Inserts the Category into the Category Table
        /// </summary>
        /// <param name="requestcategory">Category</param>
        /// <returns>Operation is successfull or not</returns>

        [HttpPut("UpdateFoodCategory/Id")]
        public ActionResult<ViewResponseMessage> UpdateCategory(Category category)
        {
            var res = _context.UpdateCategory(category);
            if (res == null) return BadRequest(new ViewResponseMessage { Message = "There is some wrong with the details you have entered" });
            return Ok(res);
        }

        /// <summary>
        /// Inserts the Category into the Category Table
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns>Operation is successfull or not</returns>

        [HttpPost("AddFoodCategory")]
        public ActionResult<ViewResponseMessage> InsertCategory(Category reqcategory)
        {

            var category = _context.InsertCategory(reqcategory);
            if (category == null) return BadRequest(new ViewResponseMessage { Message = "There is some wrong with the details you have entered" });
            return Ok(category);
        }

        /// <summary>
        ///  used to Delete the Category
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Operation is successfull or not</returns>

        [HttpDelete("DeleteFoodCategory/{id}")]
        public ActionResult<ViewResponseMessage> DeleteCategory(int id)
        {
            var category = _context.DeleteCategory(id);
            if (category == null) return BadRequest(new ViewResponseMessage { Message = "There is some wrong with the details you have entered" });
            return Ok(category);
        }
    }
}
