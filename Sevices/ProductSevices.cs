using App.Models;

namespace App.Services {
    public class ProductService : List<ProductModel> {
        public ProductService() {
            this.AddRange(new ProductModel[] {
                new ProductModel(){id = 1, Name = "Ip8", Price = 1000},
                new ProductModel(){id = 2, Name = "Ip10", Price = 1200},
                new ProductModel(){id = 3, Name = "Ip11", Price = 1400},
                new ProductModel(){id = 4, Name = "Ip12", Price = 1600}
            });
        }
    }
}