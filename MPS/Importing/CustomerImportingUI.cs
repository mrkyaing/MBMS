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
            List<Customer> customerList = new List<Customer>();
            foreach (DataRow row in dt.Rows) {
                Customer c = new Customer();
                c.CustomerID = Guid.NewGuid().ToString();
                c.CustomerCode= row["CustomerCode"].ToString();
                c.CustomerNameInEng= row["CustomerNameInEng"].ToString();
                c.CustomerNameInMM = row["CustomerNameInMM"].ToString();
                c.NRC = row["NRC"].ToString();
                c.PhoneNo = row["PhoneNo"].ToString();
                c.Post = row["PostalCode"].ToString();
                c.TownshipID = row["Township"].ToString();
                c.QuarterID = row["Quarter"].ToString();
                c.CustomerAddressInEng = row["Address(English)"].ToString();
                c.CustomerAddressInMM = row["Address(Myanmar)"].ToString();
                c.MeterID = row["MeterNo"].ToString();
                c.LedgerID = row["LedgerCode"].ToString();
                c.PageNo = Convert.ToInt16( row["PageNo"].ToString());
                c.LineNo =Convert.ToInt16( row["LineNo"].ToString());
                c.BillCode7LayerID = row["BillCodeNo"].ToString();
                c.Active = true;
                c.CreatedDate = DateTime.Now;
                c.CreatedUserID = UserID;
                customerList.Add(c);
                }
            if (customerList.Count > 0) {
                iCustomerServices.SaveRange(customerList);
                }
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
