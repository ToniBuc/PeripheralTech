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

namespace PeripheralTech.WinUI.City
{
    public partial class ucCityOverview : UserControl
    {
        private readonly APIService _cityService = new APIService("City");
        private readonly APIService _countryService = new APIService("Country");
        public ucCityOverview()
        {
            InitializeComponent();
        }

        private async Task LoadCities(CitySearchRequest search)
        {
            var cityList = await _cityService.Get<List<Model.City>>(search);

            dgvCities.AutoGenerateColumns = false;
            dgvCities.DataSource = cityList;
        }

        private async Task LoadCountry()
        {
            var result = await _countryService.Get<List<Model.Country>>(null);
            result.Insert(0, new Model.Country());
            cmbCountry.DisplayMember = "Name";
            cmbCountry.ValueMember = "CountryID";
            cmbCountry.DataSource = result;
        }

        private async void ucCityOverview_Load(object sender, EventArgs e)
        {
            await LoadCities(null);
            await LoadCountry();
            cmbCountry.BringToFront();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new CitySearchRequest()
            {
                CityName = txtSearch.Text
            };

            await LoadCities(search);
        }

        public int? _cityId = null;
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var request = new CityUpsertRequest()
                {
                    Name = txtCityName.Text,
                    ZIPCode = txtZIPCode.Text
                };

                var country = cmbCountry.SelectedValue;
                if (int.TryParse(country.ToString(), out int countryId))
                {
                    request.CountryID = countryId;
                }

                if (_cityId != null)
                {
                    await _cityService.Update<Model.City>(_cityId, request);

                    _cityId = null;
                    txtCityName.Text = "";
                    cmbCountry.SelectedIndex = 0;
                    txtZIPCode.Text = "";
                    cityLabel.Text = "New City";

                    MessageBox.Show("Operation successful!");
                }
                else
                {
                    await _cityService.Insert<Model.City>(request);

                    MessageBox.Show("Operation successful!");
                }

                await LoadCities(null);
            }

        }

        private async void dgvCities_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!dgvCities.RowCount.Equals(0))
            {
                var id = dgvCities.SelectedRows[0].Cells[0].Value;
                _cityId = int.Parse(id.ToString());

                var city = await _cityService.GetById<Model.City>(_cityId);

                txtCityName.Text = city.Name;
                txtZIPCode.Text = city.ZIPCode;
                cmbCountry.SelectedItem = city.CountryID;
                cmbCountry.SelectedText = city.CountryName;
                cmbCountry.SelectedValue = city.CountryID;
                cityLabel.Text = city.Name;
            }
        }

        private void txtCityName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCityName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtCityName, Properties.Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtCityName, null);
            }
        }

        private void cmbCountry_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCountry.SelectedValue.Equals(0))
            {
                e.Cancel = true;
                errorProvider.SetError(cmbCountry, Properties.Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(cmbCountry, null);
            }
        }
    }
}
