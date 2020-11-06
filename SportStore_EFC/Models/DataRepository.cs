using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore_EFC.Models
{
    public class DataRepository : IRepository
    {
        //private List<Product> data = new List<Product>();
        private DataContext context;

        public DataRepository(DataContext context)
        {
            this.context = context;
        }

        //Do mặc dih95 của thằng EFC là bỏ qua relationships của các bảng
        //trừ khi mình include 1 cách rõ ràng trong query
        //Điều này nghĩa là: thuộc tính dẫn đường Category trong lớp Product sẽ mang giá trị mặc định là null
        //Xử lí việc này bằng cách:
        //  gọi hàm Include được cung cấp sẵn để populate thuộc tính dẫn đường với dữ liệu liên quan
        //  và được gọi bằng IQueryable<T> object (object này dại diện cho 1 query)
        //Câu lệnh phía dưới này tức là: Lấy những thằng products mà nó include 1 category chung được truyền vào
        public IEnumerable<Product> Products => context.Products
            .Include(p => p.Category).ToArray();
        //        The Include method is defined in the Microsoft.EntityFrameworkCore namespace, and it accepts a
        //lambda expression that selects the navigation property you want Entity Framework Core to include in the
        //query.The Find method that I used for the GetProduct method cannot be used with the Include method,
        //so I have replaced it with the First method, which achieves the same effect.The result of these changes is
        //that Entity Framework Core will populate the Product.Category navigation property for the Product objects
        //created by the Products property and the GetProduct method.


        public void AddProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }

        public Product GetProduct(long key)
        {
            return context.Products.Include(product => product.Category).First(product => product.ID == key);
        }

        public void UpdateAll(Product[] products)
        {
            //this.context.Products.UpdateRange(products);
            //this.context.SaveChanges();

            //Change detection
            //Dòng code dưới này sẽ kiểm tra sự thay đổi của dữ liệu
            //Nếu có thay đổi thì tự sinh code sql trong cmd
            //Nếu không thì sẽ không sinh code sql để chạy vào data base

            //Convert từ array sang dictionary == hashmap
            Dictionary<long, Product> data = products.ToDictionary(p => p.ID);

            //Nhét những thằng có id trong dictionary vào baseline
            IEnumerable<Product> baseline =
            context.Products.Where(p => data.Keys.Contains(p.ID));
            foreach (Product databaseProduct in baseline)
            {
                //gán những thằng được gửi từ request vào những thằng nằm trong DataContext
                Product requestProduct = data[databaseProduct.ID];
                databaseProduct.Name = requestProduct.Name;
                databaseProduct.Category = requestProduct.Category;
                databaseProduct.PurchasePrice = requestProduct.PurchasePrice;
                databaseProduct.RetailPrice = requestProduct.RetailPrice;
            }
            this.context.SaveChanges();
        }

        public void UpdateProduct(Product p)
        {
            //this.context.Products.Update(p);
            //this.context.SaveChanges();
            Product prod = GetProduct(p.ID);
            prod.Name = p.Name;
            //prod.Category = p.Category; //Vì đã biến category thành 1 table nên comment dòng này
            prod.PurchasePrice = p.PurchasePrice;
            prod.RetailPrice = p.RetailPrice;
            prod.CategoryID = p.CategoryID;
            this.context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

    }
}
