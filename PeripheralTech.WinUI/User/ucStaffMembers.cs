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

namespace PeripheralTech.WinUI.User
{
    public partial class ucStaffMembers : UserControl
    {
        private readonly APIService _apiService = new APIService("User");
        public ucStaffMembers()
        {
            InitializeComponent();
        }

        private async void ucStaffMembers_Load(object sender, EventArgs e)
        {
            var userList = await _apiService.GetStaff<List<Model.User>>(null);

            dgvStaffMembers.AutoGenerateColumns = false;
            dgvStaffMembers.DataSource = userList;
            dgvStaffMembers.ClearSelection();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new UserSearchRequest()
            {
                FirstName = txtSearch.Text,
                LastName = txtSearch.Text,
            };
            var userList = await _apiService.GetStaff<List<Model.User>>(search);

            dgvStaffMembers.AutoGenerateColumns = false;
            dgvStaffMembers.DataSource = userList;
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if (APIService.Role == "Administrator")
            {
                ucStaffMemberDetail uc = new ucStaffMemberDetail();
                this.Parent.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                this.Parent.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show("You do not have permission to access this function!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvStaffMembers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!dgvStaffMembers.RowCount.Equals(0))
            {
                var id = dgvStaffMembers.SelectedRows[0].Cells[0].Value;
                if (APIService.UserID == int.Parse(id.ToString()) || APIService.Role == "Administrator")
                {
                    ucStaffMemberDetail uc = new ucStaffMemberDetail(int.Parse(id.ToString()));
                    this.Parent.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    uc.BringToFront();
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("You do not have permission to access this user's information!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
