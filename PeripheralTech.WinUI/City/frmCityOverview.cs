using PeripheralTech.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeripheralTech.WinUI.City
{
    public partial class frmCityOverview : Form
    {
        private readonly APIService _cityService = new APIService("City");
        private readonly APIService _countryService = new APIService("Country");
        public frmCityOverview()
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

        private async void frmCityOverview_Load(object sender, EventArgs e)
        {
            await LoadCities(null);
            await LoadCountry();
            //dgvCities.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Outset;
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new CitySearchRequest()
            {
                CityName = txtSearch.Text
            };

            await LoadCities(search);
        }

        //making the form movable using the upper panel
        #region Panel Border
        private bool mouseDown;
        private Point lastLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

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
