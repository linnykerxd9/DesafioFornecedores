using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Infra.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        private readonly INotificationService _notificationService;


        public ProductService(IProductsRepository productsRepository, 
                              ICategoryService categoryService,
                              ISupplierService supplierService)
        {
            _productsRepository = productsRepository;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }
        public async Task<IEnumerable<Product>> ToList()
        {
            return await _productsRepository.ToList();
        }

        public async Task<PaginationModel<Product>> Pagination(int page, int size, string query)
        {
            if(query == null){
                return await _productsRepository.Pagination(page,size);
            }
            return await _productsRepository.Pagination(page,size,x => x.Name.ToLower().Contains(query.ToLower()) ||
                                                                  x.BarCode.ToLower().Contains(query));
        }
        public  async Task<Product> Find(Expression<Func<Product, bool>> expression)
        {
            return await _productsRepository.Find(expression);
        }
        public async Task AddProduct(Product product)
        {
            if(!ProductIsValid(product)) return;

              var supplier = await _supplierService.Find(x => x.Id == product.SupplierId);
                if(supplier == null){
                    _notificationService.AddError("Supplier not exists, only registered suppliers can be linked to the product");
                    return;
                }
              var category = await _categoryService.Find(x => x.Id == product.CategoryId);
               if(category == null){
                    _notificationService.AddError("Category not exists, only registered categories can be linked to the product");
                    return;
                }
            await _productsRepository.Insert(product);
            await _productsRepository.SaveChanges();
        }

        public async Task RemoveProduct(Product product)
        {
            if(product == null ||
              product.Id == Guid.Empty){
                  if(product == null)
                        _notificationService.AddError("Product object is null");
                  if(product.Id == Guid.Empty)
                        _notificationService.AddError("Product id is null");
                    return;
              }
                
            await _productsRepository.Remove(product);
            await _productsRepository.SaveChanges();
        }

        public async Task UpdateProduct(Product product)
        {
            if(!ProductIsValid(product)) return;

            var productUpdate = await _productsRepository.Find(x => x.Id == product.Id);
            if(productUpdate == null) {
                _notificationService.AddError("Product not exists");
                    return;
            }
            productUpdate.SetActive(product.Active);
            productUpdate.SetBarCode(product.BarCode);
            productUpdate.SetName(product.Name);
            productUpdate.SetPricePurchase(product.PricePurchase);
            productUpdate.SetPriceSales(product.PriceSales);
            productUpdate.SetQuantityStock(product.QuantityStock);

            await _productsRepository.Update(productUpdate);
            await _productsRepository.SaveChanges();
        }
        public async Task InsertImage(Image image)
        {
            if(image == null ||
                image.ImagePath == null ||
                image.ProductId == Guid.Empty)
                {
                    if(image == null)
                        _notificationService.AddError("Image is null");
                    if(image.ImagePath == null)
                        _notificationService.AddError("error while saving the image");
                    if(image.ProductId == Guid.Empty)
                      _notificationService.AddError("Product Id is null");
                    return;
                }
            var productExists = await _productsRepository.Find(x => x.Id == image.ProductId);
            if(productExists == null) {
                _notificationService.AddError("Product Not exists");
                    return;
            }
            await _productsRepository.InsertImage(image);
            await _productsRepository.SaveChanges();
        }


        public async Task RemoveImage(Image image)
        {
            if(image == null ||
                image.ImagePath == null ||
                image.Id == Guid.Empty)
                {
                    if(image == null)
                        _notificationService.AddError("Image is null");
                    if(image.ImagePath == null)
                        _notificationService.AddError("error while saving the image");
                    if(image.Id == Guid.Empty)
                      _notificationService.AddError(" Id is null");
                    return;
                }

            await _productsRepository.RemoveImage(image);
            await _productsRepository.SaveChanges();
        }

        private bool ProductIsValid(Product product){
             if(product == null ||
             product.Id == Guid.Empty ||
              product.PricePurchase < 0 ||
              product.PriceSales < 0 ||
              product.BarCode == null ||
              product.Name == null ||
              product.QuantityStock < 0){
                  if(product == null)
                        _notificationService.AddError("Product object is null");
                  if(product.Id == Guid.Empty)
                        _notificationService.AddError("Product Id is Null");
                  if(product.PricePurchase < 0)
                        _notificationService.AddError("Price purchase is negative");
                  if(product.PriceSales < 0)
                        _notificationService.AddError("Price sale is negative");
                  if(product.BarCode == null)
                        _notificationService.AddError("Bar code is null");
                  if(product.Name == null)
                        _notificationService.AddError("Product Name is null");
                  if(product.QuantityStock < 0)
                        _notificationService.AddError("Quantity in stock is null");
                    return false;
              }
              return true;
        }
    }
}