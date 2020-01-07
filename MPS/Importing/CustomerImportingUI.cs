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
        public string UserID { get; set; }
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        public CustomerImportingUI() {
            InitializeComponent();
            }

        private void btnSelect_Click(object sender, EventArgs e) {
            ofdSelect.ShowDialog();
            }

        private void btnSave_Click(object sender, EventArgs e) {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] {
        new DataColumn("CustomerId", typeof(int)),
        new DataColumn("Name", typeof(string)),
        new DataColumn("Country", typeof(string))
    });
            foreach (DataGridViewRow row in gvCustomer.Rows) {
                int customerId = Convert.ToInt32(row.Cells[0].Value);
                string name = row.Cells[1].Value.ToString();
                string country = row.Cells[2].Value.ToString();
                dt.Rows.Add(customerId, name, country);
                }
            if (dt.Rows.Count > 0) {
                string str = ConfigurationManager.ConnectionStrings["MBMSEntities"].ConnectionString;
                using (SqlConnection sqlcon = new SqlConnection(str)) {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlcon)) {
                        sqlBulkCopy.DestinationTableName = "dbo.Customers";
                        sqlBulkCopy.ColumnMappings.Add("CustomerId", "CustomerId");
                        sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                        sqlBulkCopy.ColumnMappings.Add("Country", "Country");
                        sqlcon.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        sqlcon.Close();
                        }
                    }
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
                    DataTable dt = new DataTable();
                    oda.Fill(dt);
                    con.Close();
                    gvCustomer.DataSource = dt;
                    }
                }
            }
        }
    }
