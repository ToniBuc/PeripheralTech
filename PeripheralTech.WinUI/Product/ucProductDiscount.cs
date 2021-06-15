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
using System.Text.RegularExpressions;

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

        List<Model.Discount> discountList;
        private async Task LoadDiscounts()
        {
            var search = new DiscountSearchRequest()
            {
                ProductID = _productId
            };

            discountList = await _discountService.Get<List<Model.Discount>>(search);
        }

        private async void ucProductDiscount_Load(object sender, EventArgs e)
        {
            await LoadDiscounts();
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
                bool check = false;
                foreach(var x in discountList)
                {
                    if (x.DiscountID != _id)
                    {
                        if (x.From.Date <= dtpFrom.Value.Date && dtpTo.Value.Date <= x.To.Date)
                        {
                            check = true;
                        }
                        if (dtpFrom.Value.Date <= x.From.Date && dtpTo.Value.Date >= x.From.Date)
                        {
                            check = true;
                        }
                        if (dtpFrom.Value.Date <= x.From.Date && x.To.Date <= dtpTo.Value.Date)
                        {
                            check = true;
                        }
                        if (x.From.Date <= dtpFrom.Value.Date && x.To.Date >= dtpFrom.Value.Date)
                        {
                            check = true;
                        }
                    }
                }

                if (check == false)
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
                else
                {
                    MessageBox.Show("There is already a discount for this product within the specified timeframe!");
                }
            }
        }

        private void txtDiscountPercentage_Validating(object sender, CancelEventArgs e)
        {
            string regex = "^[1-9]$|^[1-9][0-9]$|^(100)$";
            if (string.IsNullOrWhiteSpace(txtDiscountPercentage.Text))
            {
                errorProvider.SetError(txtDiscountPercentage, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtDiscountPercentage.Text, regex))
            {
                errorProvider.SetError(txtDiscountPercentage, "The entered percentage must be a round number ranging from 1 to 100!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtDiscountPercentage, null);
            }
        }

        private void dtpFrom_Validating(object sender, CancelEventArgs e)
        {
            if (dtpFrom.Value.Date <= DateTime.Now.Date && _id == null)
            {
                errorProvider.SetError(dtpFrom, "The specified \"From\" date can not be today's date or a date that has already passed!");
                e.Cancel = true;
            }
            else if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                errorProvider.SetError(dtpFrom, "The specified \"From\" date can not be after the specified \"To\" date");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtpFrom, null);
            }
        }

        private void dtpTo_Validating(object sender, CancelEventArgs e)
        {
            if (dtpTo.Value.Date <= DateTime.Now.Date)
            {
                errorProvider.SetError(dtpTo, "The specified \"To\" date can not be today's date or a date that has already passed!");
                e.Cancel = true;
            }
            else if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                errorProvider.SetError(dtpTo, "The specified \"To\" date can not be before the specified \"From\" date");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtpTo, null);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucProductDetail uc = new ucProductDetail(_productId);
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }
    }
}
