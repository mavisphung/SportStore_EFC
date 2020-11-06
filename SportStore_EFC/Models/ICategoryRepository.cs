using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public interface ICategoryRepository
    {
        //Thành phần không thể thiếu để sau khi EF binding thì có thằng trỏ vào
        IEnumerable<Category> Categories { get; }

        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
