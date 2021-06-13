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
using System.IO;

namespace PeripheralTech.WinUI.User
{
    public partial class ucStaffMemberDetail : UserControl
    {
        private readonly APIService _service = new APIService("User");
        private readonly APIService _userRoleService = new APIService("UserRole");
        private readonly APIService _cityService = new APIService("City");
        private int? _id = null;
        public ucStaffMemberDetail(int? userId = null)
        {
            InitializeComponent();
            _id = userId;
        }

        private async Task LoadUserRole()
        {
            var result = await _userRoleService.Get<List<Model.UserRole>>(null);
            result.Insert(0, new Model.UserRole());
            cmbUserRole.DisplayMember = "Name";
            cmbUserRole.ValueMember = "UserRoleID";
            cmbUserRole.DataSource = result;
        }
        private async Task LoadCity()
        {
            var result = await _cityService.Get<List<Model.City>>(null);
            result.Insert(0, new Model.City());
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "CityID";
            cmbCity.DataSource = result;
        }

        private async void ucStaffMemberDetail_Load(object sender, EventArgs e)
        {
            await LoadUserRole();
            await LoadCity();
            if (_id.HasValue)
            {
                var user = await _service.GetById<Model.User>(_id);

                //loading in image
                if (user.ProfileImage.Length > 0)
                {
                    byte[] imgSource = user.ProfileImage;
                    Bitmap image;
                    using (MemoryStream stream = new MemoryStream(imgSource))
                    {
                        image = new Bitmap(stream);
                    }
                    pictureBox.Image = image;
                }
                else
                {
                    pictureBox.Image = PeripheralTech.WinUI.Properties.Resources.no_profile_image;
                }
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
                txtPhoneNumber.Text = user.PhoneNumber;
                txtAddress.Text = user.Address;
                txtUsername.Text = user.Username;
                cmbUserRole.SelectedItem = user.UserRoleID;
                cmbUserRole.SelectedText = user.UserRoleName;
                cmbUserRole.SelectedValue = user.UserRoleID;
                cmbCity.SelectedItem = user.CityID;
                cmbCity.SelectedText = user.CityName;
                cmbCity.SelectedValue = user.CityID;
            }
            else
            {
                pictureBox.Image = PeripheralTech.WinUI.Properties.Resources.no_profile_image;
            }
        }

        UserUpdateRequest updateRequest = new UserUpdateRequest();
        UserUpdateRequest insertRequest = new UserUpdateRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (_id != null)
                {
                    updateRequest.FirstName = txtFirstName.Text;
                    updateRequest.LastName = txtLastName.Text;
                    updateRequest.Email = txtEmail.Text;
                    updateRequest.PhoneNumber = txtPhoneNumber.Text;
                    updateRequest.Address = txtAddress.Text;
                    updateRequest.Username = txtUsername.Text;
                    updateRequest.Password = txtPassword.Text;
                    updateRequest.PasswordConfirmation = txtPasswordConfirmation.Text;

                    var userRole = cmbUserRole.SelectedValue;
                    if (int.TryParse(userRole.ToString(), out int userId))
                    {
                        updateRequest.UserRoleID = userId;
                    }

                    var city = cmbCity.SelectedValue;
                    if (int.TryParse(city.ToString(), out int cityId))
                    {
                        updateRequest.CityID = cityId;
                    }

                    await _service.Update<Model.User>(_id, updateRequest);
                }
                else
                {
                    insertRequest.FirstName = txtFirstName.Text;
                    insertRequest.LastName = txtLastName.Text;
                    insertRequest.Email = txtEmail.Text;
                    insertRequest.PhoneNumber = txtPhoneNumber.Text;
                    insertRequest.Address = txtAddress.Text;
                    insertRequest.Username = txtUsername.Text;
                    insertRequest.Password = txtPassword.Text;
                    insertRequest.PasswordConfirmation = txtPasswordConfirmation.Text;

                    var userRole = cmbUserRole.SelectedValue;
                    if (int.TryParse(userRole.ToString(), out int userId))
                    {
                        insertRequest.UserRoleID = userId;
                    }

                    var city = cmbCity.SelectedValue;
                    if (int.TryParse(city.ToString(), out int cityId))
                    {
                        insertRequest.CityID = cityId;
                    }

                    await _service.Insert<Model.User>(insertRequest);
                }

                MessageBox.Show("Operation successful!");
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                var file = File.ReadAllBytes(fileName);

                if (_id != null)
                {
                    updateRequest.ProfileImage = file;
                }
                else
                {
                    insertRequest.ProfileImage = file;
                }
                txtImageInput.Text = fileName;

                Image image = Image.FromFile(fileName);
                pictureBox.Image = image;
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastName, null);
            }
        }

        private void cmbUserRole_Validating(object sender, CancelEventArgs e)
        {
            if (cmbUserRole.SelectedValue.Equals(0))
            {
                errorProvider.SetError(cmbUserRole, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbUserRole, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                errorProvider.SetError(txtPhoneNumber, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPhoneNumber, null);
            }
        }

        private void cmbCity_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCity.SelectedValue.Equals(0))
            {
                errorProvider.SetError(cmbCity, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbCity, null);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider.SetError(txtAddress, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAddress, null);
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else if (txtUsername.Text.Length < 4)
            {
                errorProvider.SetError(txtUsername, "Username needs to be at least 4 characters long!");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ucStaffMembers uc = new ucStaffMembers();
            this.Parent.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            this.Parent.Controls.Remove(this);
        }
    }
}
