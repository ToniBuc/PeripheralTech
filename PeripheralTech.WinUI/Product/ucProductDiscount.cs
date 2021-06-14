using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeripheralTech.Model.Requests;

namespace PeripheralTech.WinUI.Product
{
    public partial class ucProductDiscount : UserControl
    {
        private readonly APIService _discountService = new APIService("Discount");
        private readonly APIService _productService = new APIService("Product");
        private int? _id = null;
        private int _productId;
        public ucProductDiscount(int productId, int? Id = null)
        {
            InitializeComponent();
            _id = Id;
            _productId = productId;
        }

        private async void ucProductDiscount_Load(object sender, EventArgs e)
        {
            var product = await _productService.GetById<Model.Product>(_productId);
            lblProductName.Text = product.Name;

            if (_id.HasValue)
            {
                var discount = await _discountService.GetById<Model.Discount>(_id);

                txtDiscountPercentage.Text = Convert.ToInt32(discount.DiscountPercentage).ToString();
                dtpFrom.Value = discount.From;
                dtpTo.Value = discount.To;

                if (dtpFrom.Value.Date <= DateTime.Now.Date)
                {
                    dtpFrom.Enabled = false;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new DiscountUpsertRequest()
                {
                    DiscountPercentage = Convert.ToDecimal(txtDiscountPercentage.Text),
                    From = dtpFrom.Value,
                    To = dtpTo.Value,
                    ProductID = _productId
                };

                if (_id.HasValue)
                {
                    await _discountService.Update<Model.Discount>(_id, request);
                }
                else
                {
                    await _discountService.Insert<Model.Discount>(request);
                }

                MessageBox.Show("Operation successful!");
            }
        }
    }
}
