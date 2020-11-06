using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        //trong 1 repository:
        //  Chứa DataContext để kết nối đến EF
        //  chứa 1 danh sách kiểu IEnumerable<kiểu cần chứa> == ArrayList<type>
        //  nhớ implement cái interface kho
        //  nhớ config trong file Startup.cs -> services.AddTransient<>()
        
        private DataContext context;

        public CategoryRepository(DataContext context) => this.context = context;


        //Thằng này chính là 1 kiểu delegate (con trỏ hàm)
        public IEnumerable<Category> Categories => context.Categories;

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }
    }
}
