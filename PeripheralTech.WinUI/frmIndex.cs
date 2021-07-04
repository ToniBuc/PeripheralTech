using PeripheralTech.WinUI.City;
using PeripheralTech.WinUI.Company;
using PeripheralTech.WinUI.News;
using PeripheralTech.WinUI.Orders;
using PeripheralTech.WinUI.Product;
using PeripheralTech.WinUI.Question;
using PeripheralTech.WinUI.Reports;
using PeripheralTech.WinUI.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeripheralTech.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private const int CS_DropShadow = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        //making the form movable using the upper panel
        #region Panel Top Border
        private bool mouseDown;
        private Point lastLocation;
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void frmIndex_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ucStaffMembers uc = new ucStaffMembers();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
            panel1.Controls["ucStaffMembers"].BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ucCityOverview uc = new ucCityOverview();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
            panel1.Controls["ucCityOverview"].BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ucCompanyOverview uc = new ucCompanyOverview();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
            panel1.Controls["ucCompanyOverview"].BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ucProductOverview uc = new ucProductOverview();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
            panel1.Controls["ucProductOverview"].BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ucNewsOverview uc = new ucNewsOverview();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
            panel1.Controls["ucNewsOverview"].BringToFront();
        }

        private void btnQuestions_Click(object sender, EventArgs e)
        {
            ucQuestionOverview uc = new ucQuestionOverview();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
            panel1.Controls["ucQuestionOverview"].BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ucOrderOverview uc = new ucOrderOverview();
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
            panel1.Controls["ucOrderOverview"].BringToFront();
        }
    }
}
