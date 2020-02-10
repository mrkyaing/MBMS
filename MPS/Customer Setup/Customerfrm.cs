using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using MPS.BusinessLogic.MeterController;
using MPS.Customer_Setup;
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
    public partial class Customerfrm : Form
    {
        IMeter meterservice;
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
        public MeterHistory  meterHistory { get; set; }
        public String customerID { get; set; }        
        public Boolean isEdit { get; set; }
        string townsipCode;
        
        CustomerController customerController = new CustomerController();
        public Customerfrm()
        {
            InitializeComponent();
            meterservice = new MeterController();
        }

        private void RegisterCustomer_Load(object sender, EventArgs e)
        {
            bindQuarter();
            bindTownship();
            bindBillCode();
            bindBookCode();
            bindMeter();
            txtPageNo.Enabled = false;
            txtLineNo.Enabled = false;
            if (isEdit)
            {
                if (isEdit)
                {
                    btnSave.Text = "Update";
                    Customer customer = (from c in mbmsEntities.Customers where c.CustomerID == customerID select c).FirstOrDefault();
                    txtAddressEng.Text = customer.CustomerAddressInEng;
                    txtAddressMM.Text = customer.CustomerAddressInMM;
                    txtCustomerCode.Text = customer.CustomerCode;
                    txtCustomerNameEng.Text = customer.CustomerNameInEng;
                    txtCustomerNameMM.Text = customer.CustomerNameInMM;
                    txtLineNo.Text = Convert.ToString(customer.LineNo);
                    txtPageNo.Text = Convert.ToString(customer.PageNo);
                    txtPhone.Text = customer.PhoneNo;
                    txtPost.Text = customer.Post;
                    txtNRC.Text = customer.NRC;
                    cboBillCodeNo.Text = Convert.ToString(customer.BillCode7Layer.BillCode7LayerNo);
                    cboBookCode.Text = Convert.ToString(customer.Ledger.BookCode);
                    cboMeterNo.Text = customer.Meter.MeterNo;
                    cboQuarterName.Text = customer.Quarter.QuarterNameInEng;
                    cboTownshipName.Text = customer.Township.TownshipNameInEng;
                    txtSMDSerial.Text = customer.SMDNo;
                    }              
                }
        }
        public void bindQuarter()
        {
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true).OrderBy(x=>x.QuarterNameInEng).ToList());
            cboQuarterName.DataSource = quarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
        }

        public void bindBillCode()
        {
            List<BillCode7Layer> billode7LayerList = new List<BillCode7Layer>();
            BillCode7Layer billCode = new BillCode7Layer();
            billCode.BillCode7LayerID = Convert.ToString(0);
            billCode.BillCode7LayerNo = 0;
            billode7LayerList.Add(billCode);
            billode7LayerList.AddRange(mbmsEntities.BillCode7Layer.Where(x => x.Active == true).OrderBy(x=>x.BillCode7LayerNo).ToList());
            cboBillCodeNo.DataSource = billode7LayerList;
            cboBillCodeNo.DisplayMember = "BillCode7LayerNo";
            cboBillCodeNo.ValueMember = "BillCode7LayerID";
        }
        public void bindBookCode()
        {
            List<Ledger> ledgerList = new List<Ledger>();
            Ledger ledger = new Ledger();
            ledger.LedgerID = Convert.ToString(0);
            ledger.BookCode = 0;
            ledgerList.Add(ledger);
            ledgerList.AddRange(mbmsEntities.Ledgers.Where(x => x.Active == true).OrderBy(x=>x.BookCode).ToList());
            cboBookCode.DataSource = ledgerList;
            cboBookCode.DisplayMember = "BookCode";
            cboBookCode.ValueMember = "LedgerID";
        }
        public void bindTownship()
        {
            List<Township> townshipList = new List<Township>();
            Township township = new Township();
            township.TownshipID = Convert.ToString(0);
            township.TownshipNameInEng = "Select";
            townshipList.Add(township);
            townshipList.AddRange(mbmsEntities.Townships.Where(x => x.Active == true).OrderBy(x=>x.TownshipNameInEng).ToList());
            cboTownshipName.DataSource = townshipList;
            cboTownshipName.DisplayMember = "TownshipNameInEng";
            cboTownshipName.ValueMember = "TownshipID";
        }

        public void bindMeter()
        {
            List<Meter> meterList = new List<Meter>();
            Meter meter = new Meter();
            meter.MeterID = Convert.ToString(0);
            meter.MeterNo = "Select";
            meterList.Add(meter);
            meterList.AddRange(mbmsEntities.Meters.Where(x => x.Active == true).OrderBy(x=>x.MeterNo).ToList());
            cboMeterNo.DataSource = meterList;
            cboMeterNo.DisplayMember = "MeterNo";
            cboMeterNo.ValueMember = "MeterID";
        }
        
        public bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";
              if (cboTownshipName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboTownshipName, "Error");
                tooltip.Show("Please choose Township Name!", cboTownshipName);
                cboTownshipName.Focus();
                hasError = false;
            }
            else if (cboQuarterName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboQuarterName, "Error");
                tooltip.Show("Please choose Quarter Name!", cboQuarterName);
                cboQuarterName.Focus();
                hasError = false;
            }
            else if (txtCustomerCode.Text == string.Empty)
            {
                tooltip.SetToolTip(txtCustomerCode, "Error");
                tooltip.Show("Please fill up Customer Code!", txtCustomerCode);
                txtCustomerCode.Focus();
                hasError = false;
            }
            else if (txtCustomerNameEng.Text == string.Empty)
            {
                tooltip.SetToolTip(txtCustomerNameEng, "Error");
                tooltip.Show("Please fill up Customer Name (English)!", txtCustomerNameEng);
                txtCustomerNameEng.Focus();
                hasError = false;
            }
            else if (txtCustomerNameMM.Text == string.Empty)
            {
                tooltip.SetToolTip(txtCustomerNameMM, "Error");
                tooltip.Show("Please fill up Customer Name (Myanmar)!", txtCustomerNameMM);
                txtCustomerNameMM.Focus();
                hasError = false;
            }
            else if (txtNRC.Text == string.Empty)
            {
                tooltip.SetToolTip(txtNRC, "Error");
                tooltip.Show("Please fill up NRC!", txtNRC);
                txtNRC.Focus();
                hasError = false;
            }
            else if (txtPhone.Text == string.Empty)
            {
                tooltip.SetToolTip(txtPhone, "Error");
                tooltip.Show("Please fill up Phone No!", txtPhone);
                txtPhone.Focus();
                hasError = false;
            }
            else if (txtAddressEng.Text == string.Empty)
            {
                tooltip.SetToolTip(txtAddressEng, "Error");
                tooltip.Show("Please fill up Address (English)!", txtAddressEng);
                txtAddressEng.Focus();
                hasError = false;
            }
            else if (txtAddressMM.Text == string.Empty)
            {
                tooltip.SetToolTip(txtAddressMM, "Error");
                tooltip.Show("Please fill up Address (Myanmar)!", txtAddressMM);
                txtAddressMM.Focus();
                hasError = false;
            }      
              else if (cboMeterNo.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboMeterNo, "Error");
                tooltip.Show("Please choose Meter No!", cboMeterNo);
                cboMeterNo.Focus();
                hasError = false;
            }
            else if (cboBookCode.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboBookCode, "Error");
                tooltip.Show("Please choose Book Code!", cboBookCode);
                cboBookCode.Focus();
                hasError = false;
            }
            else if (txtPageNo.Text == string.Empty)
            {
                tooltip.SetToolTip(txtPageNo, "Error");
                tooltip.Show("Please fill up Page No!", txtPageNo);
                txtPageNo.Focus();
                hasError = false;
            }

            else if (txtLineNo.Text == string.Empty)
            {
                tooltip.SetToolTip(txtLineNo, "Error");
                tooltip.Show("Please fill up Line No!", txtLineNo);
                txtLineNo.Focus();
                hasError = false;
            }

            else if (cboBillCodeNo.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboBillCodeNo, "Error");
                tooltip.Show("Please choose Bill Code No!", cboBillCodeNo);
                cboBillCodeNo.Focus();
                hasError = false;
            }
          
            return hasError;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (checkValidation())
            {
                if (isEdit)
                {
                    int editBookCode = 0; int editPageNo = 0; int editLineNo = 0; int editLineCount = 0;
                    int editMeterCount = 0;
                    editBookCode = Convert.ToInt32(cboBookCode.Text);
                    editLineNo = Convert.ToInt32(txtLineNo.Text);
                    editPageNo = Convert.ToInt32(txtPageNo.Text);

                    bool IsSMDSerialExist = mbmsEntities.Customers.Any(x => x.SMDNo == txtSMDSerial.Text);
                    if (IsSMDSerialExist) {
                        tooltip.SetToolTip(txtSMDSerial, "Error");
                        tooltip.Show("Customer SMD Serial No is already exist!", txtSMDSerial);
                        return;
                        }

                    int editCustomerCodeCount = 0, editNRCCount = 0;
                    Customer updateCustomer = (from c in mbmsEntities.Customers where c.CustomerID == customerID select c).FirstOrDefault();
                    if (txtCustomerCode.Text != updateCustomer.CustomerCode)
                    {
                        editCustomerCodeCount = (from c in mbmsEntities.Customers where c.CustomerCode == txtCustomerCode.Text && c.Active == true select c).ToList().Count;
                    }
                    if (txtNRC.Text != updateCustomer.NRC)
                    {
                        editNRCCount = (from c in mbmsEntities.Customers where c.NRC == txtNRC.Text && c.Active == true select c).ToList().Count;
                    }
                    if (editLineNo != updateCustomer.LineNo)
                    {
                        editLineCount = (from c in mbmsEntities.Customers where (c.Ledger.BookCode == editBookCode && c.LineNo == editLineNo && c.PageNo == editPageNo) && c.Active == true select c).ToList().Count;
                    }
                    if (cboMeterNo.SelectedText != updateCustomer.Meter.MeterNo)
                    {
                        editMeterCount= (from c in mbmsEntities.Customers where c.Meter.MeterNo == cboMeterNo.SelectedText && c.Active == true select c).ToList().Count;
                    }

                    if (editCustomerCodeCount > 0)
                    {
                        tooltip.SetToolTip(txtCustomerCode, "Error");
                        tooltip.Show("Customer Code is already exist!", txtCustomerCode);
                        return;
                    }
                    if (editNRCCount > 0)
                    {
                        tooltip.SetToolTip(txtNRC, "Error");
                        tooltip.Show("NRC is already exist!", txtNRC);
                        return;
                    }
                    if (editLineCount > 0)
                    {
                        tooltip.SetToolTip(txtLineNo, "Error");
                        tooltip.Show("Line No is already used!", txtLineNo);
                        return;
                    } 
                    if (editMeterCount > 0)
                    {
                        tooltip.SetToolTip(cboMeterNo, "Error");
                        tooltip.Show("Meter Serial No is already used!", cboMeterNo);
                        return;
                    }
                    string oldMeterNo = updateCustomer.Meter.MeterNo;
                    updateCustomer.CustomerCode = txtCustomerCode.Text;
                    updateCustomer.CustomerNameInEng = txtCustomerNameEng.Text;
                    updateCustomer.CustomerNameInMM = txtCustomerNameMM.Text;
                    updateCustomer.CustomerAddressInEng = txtAddressEng.Text;
                    updateCustomer.CustomerAddressInMM = txtAddressMM.Text;
                    updateCustomer.NRC = txtNRC.Text;
                    updateCustomer.PhoneNo = txtPhone.Text;
                    updateCustomer.Post = txtPost.Text;
                    updateCustomer.PageNo = Convert.ToInt32(txtPageNo.Text);
                    updateCustomer.LineNo = Convert.ToInt32(txtLineNo.Text);
                    updateCustomer.LedgerID = cboBookCode.SelectedValue.ToString();
                    updateCustomer.QuarterID = cboQuarterName.SelectedValue.ToString();
                    updateCustomer.TownshipID = cboTownshipName.SelectedValue.ToString();
                    updateCustomer.BillCode7LayerID = cboBillCodeNo.SelectedValue.ToString();
                    updateCustomer.MeterID = cboMeterNo.SelectedValue.ToString();
                    updateCustomer.SMDNo = txtSMDSerial.Text;
                    updateCustomer.UpdatedUserID = UserID;
                    updateCustomer.UpdatedDate = DateTime.Now;
                    customerController.UpdateCustomer(updateCustomer);
                    //updating the meter history information
                    if(!cboMeterNo.Text.Equals(oldMeterNo) && meterHistory !=null) {
                        meterHistory.MeterID = updateCustomer.MeterID;
                        meterservice.UpdateMeterHistory(meterHistory);
                        }             
                    MessageBox.Show("Successfully Updated Customer!", "Update");
                    Clear();
                    CustomerListfrm customerListForm = new CustomerListfrm();
                    customerListForm.Show();
                    this.Close();
                }
                else {
                    bool IsSMDSerialExist = mbmsEntities.Customers.Any(x => x.SMDNo == txtSMDSerial.Text);
                    if (IsSMDSerialExist) {
                        tooltip.SetToolTip(txtSMDSerial, "Error");
                        tooltip.Show("Customer SMD Serial No is already exist!", txtSMDSerial);
                        return;
                        }
                    int customerCodeCount = 0, nrcCount=0;
                    customerCodeCount = (from c in mbmsEntities.Customers where c.CustomerCode == txtCustomerCode.Text && c.Active == true select c).ToList().Count;
                    nrcCount = (from c in mbmsEntities.Customers where c.NRC == txtNRC.Text && c.Active == true select c).ToList().Count;
                    int bookCode = 0; int pageNo = 0; int lineNo = 0; int lineCount = 0;
                    bookCode = Convert.ToInt32(cboBookCode.Text);
                    lineNo = Convert.ToInt32(txtLineNo.Text);
                    pageNo = Convert.ToInt32(txtPageNo.Text);

                    lineCount = (from c in mbmsEntities.Customers where (c.Ledger.BookCode == bookCode && c.PageNo == pageNo && c.LineNo == lineNo) && c.Active == true select c).ToList().Count;


                    if (customerCodeCount > 0)
                    {
                        tooltip.SetToolTip(txtCustomerCode, "Error");
                        tooltip.Show("Customer Code is already exist!", txtCustomerCode);
                        return;
                    }
                    if (nrcCount > 0)
                    {
                        tooltip.SetToolTip(txtNRC, "Error");
                        tooltip.Show("Customer NRC is already exist!", txtNRC);
                        return;
                    }
                    if (lineCount > 0)
                    {
                        tooltip.SetToolTip(txtLineNo, "Error");
                        tooltip.Show("Line No is already used!", txtLineNo);
                        return;
                    }
                    Customer customer = new Customer();
                    customer.CustomerID = Guid.NewGuid().ToString();
                    customer.CustomerCode = txtCustomerCode.Text;
                    customer.CustomerNameInEng = txtCustomerNameEng.Text;
                    customer.CustomerNameInMM = txtCustomerNameMM.Text;
                    customer.CustomerAddressInEng = txtAddressEng.Text;
                    customer.CustomerAddressInMM = txtAddressMM.Text;
                    customer.NRC = txtNRC.Text;
                    customer.PhoneNo = txtPhone.Text;
                    customer.Post = txtPost.Text;
                    customer.PageNo = Convert.ToInt32(txtPageNo.Text);
                    customer.LineNo = Convert.ToInt32(txtLineNo.Text);
                    customer.LedgerID = cboBookCode.SelectedValue.ToString();
                    customer.QuarterID = cboQuarterName.SelectedValue.ToString();
                    customer.TownshipID = cboTownshipName.SelectedValue.ToString();
                    customer.BillCode7LayerID = cboBillCodeNo.SelectedValue.ToString();
                    customer.MeterID = cboMeterNo.SelectedValue.ToString();
                    customer.SMDNo = txtSMDSerial.Text;
                    customer.Active = true;
                    customer.CreatedUserID = UserID;
                    customer.CreatedDate = DateTime.Now;
                    customerController.Save(customer);
                    MessageBox.Show("Successfully registered Customer! Please check it in 'Customer List'.", "Save Success");
                    Clear();
                }
            }
        }
        public void Clear()
        {
            txtAddressEng.Text = string.Empty;
            txtAddressMM.Text = string.Empty;
            txtCustomerCode.Text = string.Empty;
            txtCustomerNameEng.Text = string.Empty;
            txtCustomerNameMM.Text = string.Empty;
            txtLineNo.Text = string.Empty;
            txtNRC.Text = string.Empty;
            txtPageNo.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPost.Text = string.Empty;
            cboBillCodeNo.SelectedIndex = 0;
            cboBookCode.SelectedIndex = 0;
            cboMeterNo.SelectedIndex = 0;
            cboQuarterName.SelectedIndex = 0;
            cboTownshipName.SelectedIndex = 0;
            txtSMDSerial.Text = string.Empty;
           
        }

        private void cboBookCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPageNo.Enabled = true;
            txtLineNo.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtCustomerNameEng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtCustomerNameMM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtNRC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void cboTownshipName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void cboBillCodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void cboTownshipName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                if (cboTownshipName.SelectedIndex > 0)
                {
                    mbmsEntities = new MBMSEntities();
                    string townshipID = Convert.ToString(cboTownshipName.SelectedValue);
                    List<Quarter> quarterList = new List<Quarter>();
                    Quarter quarter = new Quarter();
                    quarter.QuarterID = Convert.ToString(0);
                    quarter.QuarterNameInEng = "Select";
                    quarterList.Add(quarter);
                    quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true && x.TownshipID == townshipID).OrderBy(x => x.QuarterNameInEng).ToList());
                    cboQuarterName.DataSource = quarterList;
                    cboQuarterName.DisplayMember = "QuarterNameInEng";
                    cboQuarterName.ValueMember = "QuarterID";
                    var towshipData = (from t in mbmsEntities.Townships where t.TownshipID == townshipID select t).FirstOrDefault();
                    txtCustomerCode.Text = towshipData.TownshipCode;
                    townsipCode = txtCustomerCode.Text;
                }
            }
        }

        private void cboQuarterName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isEdit)
            {
                if (cboQuarterName.SelectedIndex > 0)
                {
                    mbmsEntities = new MBMSEntities();
                    string quarterID = Convert.ToString(cboQuarterName.SelectedValue);
                    var quarterData = (from q in mbmsEntities.Quarters where q.QuarterID == quarterID select q).FirstOrDefault();
                    txtCustomerCode.Text = townsipCode+"-" + quarterData.QuarterCode;
                }
            }
        }

        private void Customerfrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(cboTownshipName);
            tooltip.Hide(cboQuarterName);
            tooltip.Hide(txtCustomerCode);
            tooltip.Hide(txtCustomerNameEng);
            tooltip.Hide(txtCustomerNameMM);
            tooltip.Hide(txtNRC);
            tooltip.Hide(txtPhone);
            tooltip.Hide(txtAddressEng);
            tooltip.Hide(txtAddressMM);
            tooltip.Hide(cboMeterNo);
            tooltip.Hide(txtPhone);
            tooltip.Hide(txtLineNo);
            tooltip.Hide(cboBillCodeNo);
            tooltip.Hide(cboBookCode);
        }
    }
}
