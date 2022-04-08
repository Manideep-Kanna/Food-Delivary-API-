using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Models;
using Data_Access_Layer.Views;
namespace Bussiness_Layer
{
    public interface IAdminRepo
    {
        /// <summary>
        /// GET: Return the list of Products
        /// </summary>
        /// <returns>List of Products</returns>
        /// 

        public List<Product> GetAllProducts();

        /// <summary>
        /// Updates the Product in the Product table 
        /// </summary>
        /// <param name="requestproduct">Product</param>
        /// <returns>Operation is successfull or not </returns>
        /// 

        public ViewResponseMessage? UpdateProduct(Product requestproduct);


        /// <summary>
        /// Inserts the product into the Product Table
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Operation is successfull or not</returns>
        /// 

        public ViewResponseMessage? InsertProduct(Product product);

        /// <summary>
        /// Gets the list of the Categories
        /// </summary>
        /// <returns>List of Categories</returns>
        /// 

        public List<Category> GetAllCategories();

        /// <summary>
        /// Inserts the Category into the Category Table
        /// </summary>
        /// <param name="category">Category</param>
        /// <returns>Operation is successfull or not</returns>
        /// 

        public ViewResponseMessage InsertCategory(Category category);

        /// <summary>
        /// Deletes the Product from the Product Table
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>Operation is successfull or not</returns>
        /// 

        public ViewResponseMessage? DeleteProduct(int id);

        /// <summary>
        ///  used to Delete the Category
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Operation is successfull or not</returns>
        /// 

        public ViewResponseMessage? DeleteCategory(int id);

        /// <summary>
        /// Update the Category in the Category Table
        /// </summary>
        /// <param name="requestcategory">Category</param>
        /// <returns>Operation is successfull or not</returns>
        /// 

        public ViewResponseMessage? UpdateCategory(Category requestcategory);

        /// <summary>
        /// Get the Category with specific id 
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Category</returns>
        /// 

        public Category? GetCategory(int id);
    }
}
