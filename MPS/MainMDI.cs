
using MPS.Billing;
using MPS.CompanyProfileSetup;
using MPS.Customer_Setup;
using MPS.Importing;
using MPS.Master_Setup;
using MPS.Meter_Setup;
using MPS.MeterBillCalculation;
using MPS.MeterBillPayment;
using MPS.MeterUnitCollect;
using MPS.PC2HHUDB;
using MPS.PunishmentCustomerList;
using MPS.Setting_Setup;
using MPS.User_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS
{
    public partial class MainMDI : Form
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        private int childFormNumber = 0;

        public MainMDI()
        {
            InitializeComponent();
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

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

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

        private void hHUToPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PolePC2HHUDB poleui2hhudb = new PolePC2HHUDB();
            poleui2hhudb.UserID = UserID;
            poleui2hhudb.Show();
            }

        private void roleManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rolefrm roleForm = new Rolefrm();
            roleForm.UserID = UserID;
            roleForm.Show();
        }

        private void MainMDI_Load(object sender, EventArgs e)
        {
             tpUserName.Text = UserName;
        }

        private void userListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserListfrm userListForm = new UserListfrm();
            userListForm.UserID = UserID;
            userListForm.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Userfrm userForm = new Userfrm();
            userForm.UserID = UserID;
            userForm.Show();
        }

        private void townshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Townshipfrm townshipForm = new Townshipfrm();
            townshipForm.UserID = UserID;
            townshipForm.Show();
        }

        private void QuarterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quarterfrm quarterForm = new Quarterfrm();
            quarterForm.UserID = UserID;
            quarterForm.Show();
        }

        private void transformerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transformerfrm transformerForm = new Transformerfrm();
            transformerForm.UserID = UserID;
            transformerForm.Show();
        }

        private void transformeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransformerListfrm transListForm = new TransformerListfrm();
            transListForm.UserID = UserID;
            transListForm.Show();
        }

        private void poleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Polefrm poleForm = new Polefrm();
            poleForm.UserID = UserID;
            poleForm.Show();
        }

        private void meterTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterTypefrm meterTypeForm = new MeterTypefrm();
            meterTypeForm.UserID = UserID;
            meterTypeForm.Show();
        }

        private void punishementRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PunishmentRulefrm punishementRuleForm = new PunishmentRulefrm();
            punishementRuleForm.UserID = UserID;
            punishementRuleForm.Show();
           
        }

        private void meterBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterBoxfrm meterBoxForm = new MeterBoxfrm();
            meterBoxForm.UserID = UserID;
            meterBoxForm.Show();
        }

        private void billCode7LayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillCode7Layerfrm billcode7LayerForm = new BillCode7Layerfrm();
            billcode7LayerForm.UserID = UserID;
            billcode7LayerForm.Show();
        }

        private void billCode7LayerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillCode7LayerList billCode7LayerForm = new BillCode7LayerList();
            billCode7LayerForm.UserID = UserID;
            billCode7LayerForm.Show();
        }

        private void addLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accountfrm ledgerForm = new Accountfrm();
            ledgerForm.UserID = UserID;
            ledgerForm.Show();
        }

        private void addMeterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterFrm meterForm = new MeterFrm();
            meterForm.UserID = UserID;
            meterForm.Show();
        }

        private void meterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterListfrm meterListForm = new MeterListfrm();
            meterListForm.UserID = UserID;
            meterListForm.Show();
        }

        private void AddNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customerfrm customerForm = new Customerfrm();
            customerForm.UserID = UserID;
            customerForm.Show();
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerListfrm customerListForm = new CustomerListfrm();
            customerListForm.UserID = UserID;
            customerListForm.Show();
        }

        private void MainMDI_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
            }

        private void MainMDI_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
            }

        private void existToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("are you sure to exit the system?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == result) {
                Application.Exit();
                }
            }

        private void meterBillCollectToolStripMenuItem_Click(object sender, EventArgs e) {
            MeterUnitCollectionsfrm _MeterUnitCollectionsfrm = new MeterUnitCollectionsfrm();
            _MeterUnitCollectionsfrm.UserID = UserID;
            _MeterUnitCollectionsfrm.Show();
            }

        private void companyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyProfilefrm companyProfileForm = new CompanyProfilefrm();
            companyProfileForm.UserID = UserID;
            companyProfileForm.Show();
        }

        private void configurationSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settingfrm settingform = new Settingfrm();
            settingform.Show();
        }

        private void importExportCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerImportingUI importCustomerDataForm = new CustomerImportingUI();
            importCustomerDataForm.UserID = UserID;
            importCustomerDataForm.Show();
        }

        private void meterBillCalculationProcessToolStripMenuItem_Click(object sender, EventArgs e) {

            MeterBillCalculate mbc = new MeterBillCalculate();
            mbc.UserID = UserID;
            mbc.Show();
            }

        private void meterBillPaymentToolStripMenuItem_Click(object sender, EventArgs e) {
            MeterBillPaymentList mbp = new MeterBillPaymentList();
            mbp.UserID = UserID;
            mbp.Show();
            
        }

        private void advanceMoneyCustomerListToolStripMenuItem_Click(object sender, EventArgs e) {
            new AdvanceMoneyCustomerUI().Show();
            }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult isExit = MessageBox.Show("Are you sure to logout?", "Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (isExit == DialogResult.Yes) {
                this.Hide();
                new frmLogin().Show();
                }
            }

        private void punishmentCustomerListToolStripMenuItem_Click(object sender, EventArgs e) {
            new PunishmentCustomerListUI().Show();
            }

        private void pCToHHUToolStripMenuItem_Click(object sender, EventArgs e) {
            new Quaeter2HHUDBUI().Show(); 
            }

        private void meterDataToHHUDBToolStripMenuItem_Click(object sender, EventArgs e) {
            new MeterList2HHUDB().Show();
            }

        private void customerDataToHHUDBToolStripMenuItem_Click(object sender, EventArgs e) {
            CustomerList2HHUDB cdbui = new CustomerList2HHUDB();
            cdbui.UserID = UserID;
            cdbui.Show();
            }
        }
}
