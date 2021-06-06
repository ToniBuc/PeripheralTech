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

namespace PeripheralTech.WinUI.User
{
    public partial class frmStaffMembers : Form
    {
        private readonly APIService _apiService = new APIService("User");
        public frmStaffMembers()
        {
            InitializeComponent();
        }

        private async void frmStaffMembers_Load(object sender, EventArgs e)
        {
            var userList = await _apiService.GetStaff<List<Model.User>>(null);

            dgvStaffMembers.AutoGenerateColumns = false;
            dgvStaffMembers.DataSource = userList;
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

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if (APIService.Role == "Administrator")
            {
                frmStaffMemberDetail frm = new frmStaffMemberDetail();
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.Show();
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
                    frmStaffMemberDetail frm = new frmStaffMemberDetail(int.Parse(id.ToString()));
                    frm.MaximizeBox = false;
                    frm.MinimizeBox = false;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("You do not have permission to access this user's information!", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
