using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using ClosedXML.Excel;
using DesafioFornecedores.Domain.Interface.Services;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.WebApp.Extensions;
using DesafioFornecedores.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DesafioFornecedores.WebApp.Controllers
{
    public class ReportController : MainController
    {
        private readonly ISupplierService _supplierService;

        public ReportController(IMapper mapper, INotificationService notificationService, ISupplierService supplierService) : base(mapper, notificationService)
        {
            _supplierService = supplierService;
        }
       [Authorize(Policy = "AdminOnly")]
        private async Task<DataTable> getData() {
                //Creating DataTable  
                var suppliers = await _supplierService.ToList();
                DataTable dt = new DataTable();
                //Setiing Table Name  
                dt.TableName = "EmployeeData";
                //Add Columns  
                dt.Columns.Add("Supplier Status");
                dt.Columns.Add("Supplier Fantasy Name");
                dt.Columns.Add("Product Status");
                dt.Columns.Add("Product Name");
                dt.Columns.Add("Product Price sale");
                dt.Columns.Add("Product Prive Purchase");
                dt.Columns.Add("Product Category");
                //Add Rows in DataTable 
                foreach (var item in suppliers)
                {
                    if(item.Product.Count > 0){
                         foreach (var products in item.Product)
                    {
                        dt.Rows.Add(item.Active,
                                    item.FantasyName,
                                    products.Active,
                                    products.Name,
                                    products.PriceSales,
                                    products.PricePurchase,
                                    products.Category.Name
                                    );
                    }
                    }else{
                        dt.Rows.Add(item.Active,
                                    item.FantasyName);
                    }
                }
                dt.AcceptChanges();
                return dt;
    }
       
       [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<ActionResult> WriteDataToExcel()
        {
            DataTable dt = await getData();
            //Name of File  
            string fileName = "Report.xlsx";
            using (XLWorkbook wb = new XLWorkbook())
            {
                //Add DataTable in worksheet  
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    //Return xlsx Excel File  
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);  
                }
            }
        }   
    }
}