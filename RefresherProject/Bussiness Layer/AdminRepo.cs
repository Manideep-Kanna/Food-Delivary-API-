using Data_Access_Layer;
using Data_Access_Layer.Models;
using Data_Access_Layer.Views;
using Microsoft.EntityFrameworkCore;

namespace Bussiness_Layer
{
    public class AdminRepo : IAdminRepo
    {
        private DataContext _context;
        public AdminRepo(DataContext context)
        {
            _context = context;
        }
        public ViewResponseMessage? DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return null;
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return new ViewResponseMessage { Message = $"The category of category_id {id} is removed " };
        }

        public ViewResponseMessage? DeleteProduct(int id)
        {

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return new ViewResponseMessage { Message = $"The product of product_id {id} is removed " };
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Category? GetCategory(int id)
        {
            Category category;
            try
            {
                category = _context.Categories.Where(ex => ex.Id == id).First();
            }
            catch (Exception)
            {
                return null;
            }
            return category;
        }

        public ViewResponseMessage InsertCategory(Category category)
        {
            try 
            {
                category.CreatedDate = DateTime.Now;
                category.UpdatedDate = category.CreatedDate;
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return new ViewResponseMessage { Message = $"The Category {category.Name} is inserted" };
        }

        public ViewResponseMessage? InsertProduct(Product product)
        {
            try
            {
                product.CreatedDate=DateTime.Now;
                product.UpdatedDate = product.CreatedDate;
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return null;
            }


            return new ViewResponseMessage { Message = $"The Product {product.Name} is inserted" };
        }

        public ViewResponseMessage? UpdateCategory(Category requestcategory)
        {
            var category = _context.Categories.Find(requestcategory.Id);
            if (category == null)
                return null;
            category.Id = requestcategory.Id;
            category.Name = requestcategory.Name;
            category.UpdatedDate = DateTime.Now;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return new ViewResponseMessage { Message = "Successfully Category Updated" };
        }

        public ViewResponseMessage? UpdateProduct(Product requestproduct)
        {
            var product = _context.Products.Find(requestproduct.Id);
            if (product == null)
                return null;
            product.Id = requestproduct.Id;
            product.Name = requestproduct.Name;
            product.Cost = requestproduct.Cost;
            product.CategoryId = requestproduct.CategoryId;
            product.Description = requestproduct.Description;
            product.UpdatedDate = DateTime.Now;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return new ViewResponseMessage { Message = "Successfully Product Updated" };
        }
    }
}