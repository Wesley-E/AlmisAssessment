using System;
using System.Globalization;
using AlmisAssessment.Configuration;
using AlmisAssessment.Models.Controls;
using AlmisAssessment.Models.Product;
using AlmisAssessment.Services;
using AppKit;
using Foundation;
using Product = AlmisAssessment.Models.Controls.Product;

namespace AlmisAssessment
{
    public partial class ViewController : NSViewController
    {
        private Period _period = new Period(0, 0, 0, 0);
        private decimal _investmentAmount = 0m;
        private readonly Products _products;

        public ViewController(IntPtr handle) : base(handle)
        {
            var repository = new Repository.Repository();
            IProductService productService = new ProductService(repository);
            _products = productService.BuildProducts(
                productService.LoadProducts(AppSettingsManager.Settings["productFile"]));
        }

        partial void TermFieldInput(NSObject sender)
        {
            _period = new Period(0, 0, 0, TermField.IntValue);
            ProductTable.Delegate = new ProductTableDelegate(this, BuildTableDataSource());
            ProductTable.ReloadData();
        }

        partial void InvestmentFieldInput(NSObject sender)
        {
            _investmentAmount = InvestmentField.IntValue;
            ProductTable.Delegate = new ProductTableDelegate(this, BuildTableDataSource());
            ProductTable.ReloadData();
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            var dataSource = BuildTableDataSource();

            ProductTable.DataSource = dataSource;
            ProductTable.Delegate = new ProductTableDelegate(this, dataSource);
        }

        private ProductTableDataSource BuildTableDataSource()
        {
            var dataSource = new ProductTableDataSource();

            foreach (var (_, value) in _products.All)
            {
                dataSource.Products.Add(new Product(
                    value.Name, 
                    $"{value.InterestRate.Percentage}%",
                    $"{value.Yield(_investmentAmount, _period, DateTime.Now)}"));
            }

            return dataSource;
        }
        
        public override NSObject RepresentedObject
        {
            get { return base.RepresentedObject; }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}