﻿using MBMS.DAL;
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
        Customer customer = new Customer();
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
            if (txtCustomerCode.Text == string.Empty)
            {
                tooltip.SetToolTip(txtCustomerCode, "Error");
                tooltip.Show("Please fill up Customer Code!", txtCustomerCode);
                hasError = false;
            }
            else if (txtAddressEng.Text == string.Empty)
            {
                tooltip.SetToolTip(txtAddressEng, "Error");
                tooltip.Show("Please fill up Address (English)!", txtAddressEng);
                hasError = false;
            }
            else if (txtAddressMM.Text == string.Empty)
            {
                tooltip.SetToolTip(txtAddressMM, "Error");
                tooltip.Show("Please fill up Address (Myanmar)!", txtAddressMM);
                hasError = false;
            }
            else if (txtCustomerNameEng.Text == string.Empty)
            {
                tooltip.SetToolTip(txtCustomerNameEng, "Error");
                tooltip.Show("Please fill up Customer Name (English)!", txtCustomerNameEng);
                hasError = false;
            }
            else if (txtCustomerNameMM.Text == string.Empty)
            {
                tooltip.SetToolTip(txtCustomerNameMM, "Error");
                tooltip.Show("Please fill up Customer Name (Myanmar)!", txtCustomerNameMM);
                hasError = false;
            }
            else if (txtNRC.Text == string.Empty)
            {
                tooltip.SetToolTip(txtNRC, "Error");
                tooltip.Show("Please fill up NRC!", txtNRC);
                hasError = false;
            }
            else if (txtLineNo.Text == string.Empty)
            {
                tooltip.SetToolTip(txtLineNo, "Error");
                tooltip.Show("Please fill up Line No!", txtLineNo);
                hasError = false;
            }
            else if (txtPageNo.Text == string.Empty)
            {
                tooltip.SetToolTip(txtPageNo, "Error");
                tooltip.Show("Please fill up Page No!", txtPageNo);
                hasError = false;
            }
            else if (txtPhone.Text == string.Empty)
            {
                tooltip.SetToolTip(txtPhone, "Error");
                tooltip.Show("Please fill up Phone No!", txtPhone);
                hasError = false;
            }
            else if (cboBillCodeNo.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboBillCodeNo, "Error");
                tooltip.Show("Please choose Bill Code No!", cboBillCodeNo);
                hasError = false;
            }
            else if (cboBookCode.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboBookCode, "Error");
                tooltip.Show("Please choose Book Code!", cboBookCode);
                hasError = false;
            }
            else if (cboMeterNo.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboMeterNo, "Error");
                tooltip.Show("Please choose Meter No!", cboMeterNo);
                hasError = false;
            }
            else if (cboQuarterName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboQuarterName, "Error");
                tooltip.Show("Please choose Quarter Name!", cboQuarterName);
                hasError = false;
            }
            else if (cboTownshipName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboTownshipName, "Error");
                tooltip.Show("Please choose Township Name!", cboTownshipName);
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
                    customer.UpdatedUserID = UserID;
                    customer.UpdatedDate = DateTime.Now;
                    customerController.UpdateCustomer(updateCustomer);
                    //updating the meter history information
                    if(!cboMeterNo.SelectedValue.Equals(updateCustomer.MeterID)) {
                        meterHistory.MeterID = updateCustomer.MeterID;
                        meterservice.UpdateMeterHistory(meterHistory);
                        }             
                    MessageBox.Show("Successfully Updated Customer!", "Update");
                    Clear();
                    CustomerListfrm customerListForm = new CustomerListfrm();
                    customerListForm.Show();
                    this.Close();
                }
                else
                {
                    int customerCodeCount = 0, nrcCount=0;
                    customerCodeCount = (from c in mbmsEntities.Customers where c.CustomerCode == txtCustomerCode.Text && c.Active == true select c).ToList().Count;
                    nrcCount = (from c in mbmsEntities.Customers where c.NRC == txtNRC.Text && c.Active == true select c).ToList().Count;
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
    }
}
