﻿using MBMS.DAL;
using MPS.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.PC2HHUDB {
    public partial class MeterList2HHUDB : Form {
        MBMSEntities mbmsEntities = new MBMSEntities();
        List<Meter> meterList = new List<Meter>();
        public MeterList2HHUDB() {
            InitializeComponent();
       
            }
        private void BuildSQLiteConnection() {
            if (String.IsNullOrEmpty(Storage.ConnectionString)) {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", System.Configuration.ConfigurationManager.AppSettings["DatabaseFile"]));
                }
            }
        private void MeterList2HHUDB_Load(object sender, EventArgs e) {
            getMeterList();
            bindMeterBoxList();
            }
        public void bindMeterBoxList() {
            List<MeterBox> meterboxList = new List<MeterBox>();
            MeterBox mb = new MeterBox();
            mb.MeterBoxID = Convert.ToString(0);
            mb.MeterBoxCode = "Select";
            meterboxList.Add(mb);
            meterboxList.AddRange(mbmsEntities.MeterBoxes.Where(x => x.Active == true).OrderBy(x => x.MeterBoxCode).ToList());
            cbometerBox.DataSource = meterboxList;
            cbometerBox.DisplayMember = "MeterBoxCode";
            cbometerBox.ValueMember = "MeterBoxID";
            }
        private void btnSearch_Click(object sender, EventArgs e) {
            meterList.Clear();
            meterList = (from m in mbmsEntities.Meters
                         where m.Active == true &&
                         m.MeterNo == txtmeternoSearch.Text ||
                         m.Model==txtmetermodelsearch.Text||
                         m.MeterBox.MeterBoxCode==cbometerBox.Text
                        select m).ToList();
            dgvMeterList.DataSource = meterList;
            }
        private void getMeterList() {
            this.dgvMeterList.AutoGenerateColumns = false;
            meterList = (from m in mbmsEntities.Meters where m.Active == true  select m).ToList();
            dgvMeterList.DataSource = meterList;        
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            getMeterList();
            bindMeterBoxList();
            this.txtmeternoSearch.Text = txtmetermodelsearch.Text = string.Empty;
            }

        private void btnSave2HHUDB_Click(object sender, EventArgs e) {

            if (meterList.Count == 0) {
                MessageBox.Show("There is no Meter data to save HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.Yes) {
                BuildSQLiteConnection();
                MetersServices sqlitemetersservices = new MetersServices();
                List<MPS.SQLiteHelper.Meters> sqlpoleList = new List<MPS.SQLiteHelper.Meters>();
                string sqlCommand = string.Format("SELECT * FROM Meters");
                var data = sqlitemetersservices.GetAll(sqlCommand);
                foreach (var v in data) {
                    foreach (Meter m in meterList) {
                        if (m.MeterNo == v.mtr_id) {
                            MessageBox.Show("(" + m.MeterNo + ") Meter code already exists in HHU db file.", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            }
                        }
                    }
                foreach (Meter m in meterList) {
                    MPS.SQLiteHelper.Meters meter = new MPS.SQLiteHelper.Meters();
                    meter.mtr_id = m.MeterNo;
                    meter.mtr_inst = m.InstalledDate.ToString();
                    meter.mtr_make = m.ManufactureBy;
                    meter.mtr_model = m.Model.ToString() ;
                    meter.mtr_create = m.CreatedDate.ToString();
                    Customer c= m.Customers.Where(x => x.MeterID == m.MeterID).SingleOrDefault();
                    if (c == null) {
                        MessageBox.Show("set customer data for>"+m.MeterNo, "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                        }
                    meter.mtr_csm_id = m.Customers.Where(x => x.MeterID == m.MeterID).SingleOrDefault().CustomerCode;
                    Pole p = mbmsEntities.Poles.Where(x => x.Transformer.QuarterID == c.QuarterID).SingleOrDefault();
                    if (p == null) {
                        MessageBox.Show("set Pole data for>" + m.MeterNo, "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                        }
                    meter.mtr_pole = p.PoleNo;
                    sqlpoleList.Add(meter);
                    }
                try {
                    sqlitemetersservices.AddRange(sqlpoleList);
                    MessageBox.Show("Meters data to HHU db file is successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                catch (Exception ex) {
                    MessageBox.Show("Error occur when saving Meters to HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }