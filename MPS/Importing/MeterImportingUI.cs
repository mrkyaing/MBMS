﻿using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using MPS.BusinessLogic.MeterController;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Importing {
    public partial class MeterImportingUI : Form {
        IMeter meterservices;
        List<Meter> meterList = new List<Meter>();
        DataTable dt = new DataTable();
        public string UserID { get; set; }
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        public MeterImportingUI() {
            InitializeComponent();
            meterservices = new MeterController();
            }

        private void btnSelect_Click(object sender, EventArgs e) {
            ofdSelect.ShowDialog();
            }

        private void btnSave_Click(object sender, EventArgs e) {
            if (dt.Rows.Count > 0) {
               
                DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ok == DialogResult.Yes) {
                   
                    foreach (DataRow row in dt.Rows) {
                        bool isdataexit = meterservices.getMeterByMeterNo(row["MeterNo"].ToString());
                        if (isdataexit) {
                            MessageBox.Show("Meter  data already exists in the system for>" + row["MeterNo"].ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                       
                        Meter meter = new Meter();
                        progressBar1.Visible = true;
                        timer1.Enabled = true;
                        BindRecrods(meter,row);                       
                    }
                    if (meterList.Count > 0) {
                        try {
                            meterservices.SaveRange(meterList);
                            MessageBox.Show("Importing Meter data is successfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) {
                            MessageBox.Show("Error occur :(", "information");
                        }
                    }
                }//end of Yes Dialog
            }//end of dt.rows.Count>0
            }

        private void BindRecrods(Meter meter, DataRow row) {
            meter.MeterNo = row["MeterNo"].ToString();
            meter.MeterID = Guid.NewGuid().ToString();
            meter.Model = row["Model"].ToString();
            meter.InstalledDate = Convert.ToDateTime(row["InstalledDate"].ToString());
            meter.Phrase = row["Phrase"].ToString();
            meter.Wire = row["Wire"].ToString();
            meter.BasicCurrent = row["BasicCurrent"].ToString();
            meter.iMax = Convert.ToInt32(row["iMax"]);
            meter.Voltage = Convert.ToInt32(row["Voltage"]);
            meter.ManufactureBy = row["ManufactureBy"].ToString();
            meter.Status = row["Status"].ToString();
            meter.AvailableYear = Convert.ToInt32(row["AvailableYear"]);
            MeterBox meterbox = meterservices.getMeterBoxByMeterBoxNo(row["MeterBoxCode"].ToString());
            if (meterbox == null) {
                MessageBox.Show("Please define Meter Box Code for>" + meter.MeterNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool checkmeterboxsequence = meterservices.getMeterByMeterboxIdBoxSequence(meterbox.MeterBoxID, Convert.ToString(row["MeterBoxSequence"]));
            if (checkmeterboxsequence) {
                MessageBox.Show("Meter Box Sequence is already used!!>" + meter.MeterNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            meter.MeterBoxID = meterbox.MeterBoxID;        
            meter.MeterBoxSequence = Convert.ToString(row["MeterBoxSequence"]);
            MeterType metertype = meterservices.getMeterTypeByMeterTypeCode(row["MeterTypeCode"].ToString());
            if (metertype == null) {
                MessageBox.Show("Please define Meter Type Code for>" + meter.MeterNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            meter.MeterTypeID = metertype.MeterTypeID;
            meter.Active = true;
            meter.CreatedDate = DateTime.Now;
            meter.CreatedUserID = UserID;
            meterList.Add(meter);
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
        private void timer1_Tick(object sender, EventArgs e) {
            progressBar1.PerformStep();
            for(int i = 1; i <= 100; i++) {
                // Wait 50 milliseconds.  
                Thread.Sleep(50);
                progressBar1.Value = i;            
            }
            if (Convert.ToInt32(progressBar1.Value) == 100) {
                timer1.Enabled = false;
            }
        }
    }
    }
