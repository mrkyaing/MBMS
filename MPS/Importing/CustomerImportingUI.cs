using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Importing {
    public partial class CustomerImportingUI : Form {
        ICustomer iCustomerServices;
        DataTable dt = new DataTable();
        public string UserID { get; set; }
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        public CustomerImportingUI() {
            InitializeComponent();
            iCustomerServices = new CustomerController();
            }

        private void btnSelect_Click(object sender, EventArgs e) {
            ofdSelect.ShowDialog();
            }

        private void btnSave_Click(object sender, EventArgs e) {
            if (dt.Rows.Count > 0) {
                DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ok == DialogResult.Yes) {
                    List<Customer> customerList = new List<Customer>();
                    foreach (DataRow row in dt.Rows) {
                        bool isdataexit = iCustomerServices.GetCustomerCustomerCode(row["CustomerCode"].ToString());
                        if (isdataexit) {
                            MessageBox.Show("Customer  data already exists in the system for>" + row["CustomerCode"].ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        bool IsSMDSerialNoExist = iCustomerServices.GetCustomerBySMDNo(row["SMDNo"].ToString());
                        if (IsSMDSerialNoExist) {
                            MessageBox.Show("Customer  SMD Serial No already exists in the system for>" + row["CustomerCode"].ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        Customer customerEntity = new Customer();
                        customerEntity.CustomerCode = row["CustomerCode"].ToString();
                        customerEntity.CustomerID = Guid.NewGuid().ToString();
                        customerEntity.SMDNo = row["SMDNo"].ToString();
                        customerEntity.CustomerNameInEng = row["CustomerNameInEng"].ToString();
                        customerEntity.CustomerNameInMM = row["CustomerNameInMM"].ToString();
                        customerEntity.NRC = row["NRC"].ToString();
                        customerEntity.PhoneNo = row["PhoneNo"].ToString();
                        customerEntity.Post = row["PostalCode"].ToString();
                        Township t = iCustomerServices.GetTownshipByTownshipCode(row["TownshipCode"].ToString());
                        if (t == null) {
                            MessageBox.Show("Please define Township Code for>" + customerEntity.CustomerCode, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        customerEntity.TownshipID = t.TownshipID;
                        customerEntity.Township = t;
                        Quarter q = iCustomerServices.GetQuarterByQarterCode(row["QuarterCode"].ToString());
                        if (q == null) {
                            MessageBox.Show("Please define Quarter Code  for>" + customerEntity.CustomerCode, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        customerEntity.QuarterID = q.QuarterID;
                        customerEntity.Quarter = q;
                        customerEntity.CustomerAddressInEng = row["Address(English)"].ToString();
                        customerEntity.CustomerAddressInMM = row["Address(Myanmar)"].ToString();
                        Meter m = iCustomerServices.GetMeterByQarterNo(row["MeterNo"].ToString());
                        if (m == null) {
                            MessageBox.Show("Please define MeterNo data for>" + customerEntity.CustomerCode, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        bool IsMeterIDExitsin = iCustomerServices.GetCustomerByMeterID(m.MeterBoxID);
                        if (IsMeterIDExitsin) {
                            MessageBox.Show("Customer  Meter No already exists in the system for>" + row["CustomerCode"].ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        customerEntity.MeterID = m.MeterBoxID;
                        customerEntity.Meter = m;

                        Ledger l = iCustomerServices.GetLedgerByLedgerCode(Convert.ToInt32(row["LedgerCode"].ToString()));
                        if (l == null) {
                            MessageBox.Show("Please define LedgerCode data for>" + customerEntity.CustomerCode, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        customerEntity.Ledger = l;
                        customerEntity.LedgerID = l.LedgerID;
                        customerEntity.PageNo = Convert.ToInt16(row["PageNo"].ToString());
                        customerEntity.LineNo = Convert.ToInt16(row["LineNo"].ToString());
                        BillCode7Layer b = iCustomerServices.GetBillCode7LayerByBillCodeNo(Convert.ToInt32(row["BillCodeNo"].ToString()));
                        if (b == null) {
                            MessageBox.Show("Please define BillCodeNo data for>" + customerEntity.CustomerCode, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        customerEntity.BillCode7LayerID = b.BillCode7LayerID;
                        customerEntity.BillCode7Layer = b;
                        customerEntity.Active = true;
                        customerEntity.CreatedDate = DateTime.Now;
                        customerEntity.CreatedUserID = UserID;
                        customerList.Add(customerEntity);
                    }
                    if (customerList.Count > 0) {
                        try {
                            iCustomerServices.SaveRange(customerList);
                            MessageBox.Show("Importing Customer data is successfylly saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) {
                            MessageBox.Show("Error occur :(", "information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }//end of yes dialog
            }//end of dt.Rows.Count>0
            }

        private void ofdSelect_FileOk(object sender, CancelEventArgs e) {
            string filePath = ofdSelect.FileName;
            string extension = Path.GetExtension(filePath);
            string conString = "";
            string sheetName = "";
            switch (extension) {
                case ".xls":
                    conString = string.Format(Excel03ConString, filePath, "YES");
                    break;
                case ".xlsx":
                    conString = string.Format(Excel07ConString, filePath, "YES");
                    break;
                default:
                    MessageBox.Show("Invalid file", "Informtion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            using (OleDbConnection con = new OleDbConnection(conString)) {
                using (OleDbCommand cmd = new OleDbCommand()) {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    sheetName = dt.Rows[0]["Table_Name"].ToString();
                    con.Close();
                    }
                }
            using (OleDbConnection con = new OleDbConnection(conString)) {
                using (OleDbCommand cmd = new OleDbCommand()) {
                    OleDbDataAdapter oda = new OleDbDataAdapter();
                    cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    oda.SelectCommand = cmd;           
                    oda.Fill(dt);
                    con.Close();
                    gvCustomer.DataSource = dt;
                    }
                }
            }
        }
    }
