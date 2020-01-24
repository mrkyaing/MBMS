using MBMS.DAL;
using MPS.BusinessLogic.MeterUnitCollectionController;
using MPS.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MPS.MeterUnitCollect {
    public partial class MeterUnitCollectionsfrm : Form {
        StringBuilder ErrorList = new StringBuilder();
        MBMSEntities mbmsEntities = new MBMSEntities();
        IMeterUnitCollections iMeterUnitColleciton = new MeterUnitCollectionController();
        public string UserID { get; set; }
        List<NodeMeter> nodeMeterList = null;
        public MeterUnitCollectionsfrm() {
            InitializeComponent();
            getDbFileList();
            }
        private void getDbFileList() {
            this.cbofileName.Items.Add("Select One");
            this.cbofileName.SelectedIndex = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings["dbFileListPath"]);
            FileInfo[] Files = dirInfo.GetFiles("*.db"); //Getting db files
            foreach (FileInfo file in Files) {
                this.cbofileName.Items.Add(file.Name);
                }
            }
        private void BuildSQLiteConnection() {
            string sqlitedbPath = System.Configuration.ConfigurationManager.AppSettings["DatabaseFile"] + cbofileName.SelectedItem;
            if (String.IsNullOrEmpty(Storage.ConnectionString)) {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", sqlitedbPath));
                }
            }
        private void MeterUnitCollectionsfrm_Load(object sender, EventArgs e) {
            bindQuarter();
            bindTransformer();         
            }
        private void GetMeterUnitData(string fromDate, string toDate,string QuarterID) {
            this.BuildSQLiteConnection();      
            NodeMeterServices NodeMetersvc = new NodeMeterServices();
            string sqlCommand = string.Empty;
            if (string.IsNullOrEmpty(QuarterID)) {
                sqlCommand = string.Format("SELECT * FROM NodeMeter WHERE nod_bill_from>='{0}' AND nod_bill_to<='{1}' ", fromDate, toDate);
                }
            else {
                sqlCommand = string.Format("SELECT * FROM NodeMeter WHERE nod_bill_from>='{0}' AND nod_bill_to<='{1}' AND nod_village_code in (select vlg_code from Villages where vlg_code='{2}')", fromDate, toDate,QuarterID);
                }
            nodeMeterList = NodeMetersvc.GetAll(sqlCommand).ToList();
            this.gvnodemeter.DataSource = nodeMeterList;
            if (nodeMeterList.Count ==0) {
                    MessageBox.Show("There is no data to collect.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;       
                }                 
            }
        private void btncollectmeterunit_Click(object sender, EventArgs e) {
            string fromdate = dtpfromDate.Value.ToString("yyyyMMdd");
            string todate = dtptoDate.Value.ToString("yyyy-MM-dd");
            string qCode = string.Empty;
            string qid = cboQuarter.SelectedValue.ToString();
            if (!cboQuarter.SelectedValue.Equals("0")) {
                qCode = mbmsEntities.Quarters.Where(x => x.QuarterID == qid).SingleOrDefault().QuarterCode;
                }
            if (cbofileName.SelectedItem.Equals("Select One")) {
                MessageBox.Show("Select HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            GetMeterUnitData(fromdate,todate,qCode);            
            }
        private bool SaveMeterUnitCollection(List<NodeMeter> data) {
            ErrorList.Clear();
            DateTime fromDate = dtpfromDate.Value.Date;
            DateTime toDate = dtptoDate.Value.Date;
            string transformerId = string.Empty;
            if(!cboTransformer.SelectedValue.Equals("0"))
            transformerId = cboTransformer.SelectedValue.ToString();
            bool checkData = false;
            if (!string.IsNullOrEmpty(transformerId)) {
                 checkData = mbmsEntities.MeterBills.Any(x => EntityFunctions.TruncateTime(x.InvoiceDate) >= fromDate && EntityFunctions.TruncateTime(x.InvoiceDate) <= toDate 
                 && x.MeterUnitCollect.TransformerID == transformerId);
                }else {
                 checkData = mbmsEntities.MeterBills.Any(x => EntityFunctions.TruncateTime(x.InvoiceDate) >= fromDate && EntityFunctions.TruncateTime(x.InvoiceDate) <= toDate);
                }
           
            if (checkData) {
                MessageBox.Show("Bill Units can't re-collect because data is already calculated and printed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                }
            try {
                List<MBMS.DAL.MeterUnitCollect> meterUnitCollectList = new List<MBMS.DAL.MeterUnitCollect>();
                foreach (NodeMeter item in data) {
                    MBMS.DAL.MeterUnitCollect meterUnit = new MBMS.DAL.MeterUnitCollect();              
                    Customer customerinfo = mbmsEntities.Customers.Where(x => x.CustomerCode == item.nod_csm_id&&x.Active==true).SingleOrDefault();//eg >>450-050-545-450-TPYTR05-00000428
                    if (customerinfo == null) {
                        ErrorList.Append("Set customer record for :" + item.nod_csm_id);
                        MessageBox.Show(ErrorList.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                        }
                    meterUnit.MeterUnitCollectID = Guid.NewGuid().ToString();
                    meterUnit.CustomerID = customerinfo.CustomerID;
                    string y = item.nod_bill_from;
                    string m = item.nod_bill_from;
                    string d = item.nod_bill_from;                                  
                    meterUnit.FromDate = item.nod_bill_from==""?dtpfromDate.Value:Convert.ToDateTime(y.Substring(0, 4) + "-"+m.Substring(4, 2) + "-"+d.Substring(6, 2));
                    meterUnit.ToDate = item.nod_bill_to==""?dtptoDate.Value:Convert.ToDateTime(item.nod_bill_to);
                    meterUnit.TotalMeterUnit = (decimal)item.nod_pres_eng;
                    meterUnit.BillMonth = (int)item.nod_bill_month;
                    Transformer transformer = mbmsEntities.Transformers.Where(x => x.QuarterID == customerinfo.QuarterID&&x.Active==true).SingleOrDefault();
                    if (transformer == null) {
                        ErrorList.Append("Set transformer record for :" + customerinfo.Quarter.QuarterNameInEng);
                        MessageBox.Show(ErrorList.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                        }
                    meterUnit.TransformerID = transformer.TransformerID;
                    meterUnit.PoleID = mbmsEntities.Poles.Where(x => x.TransformerID == transformer.TransformerID&&x.Active==true).SingleOrDefault().PoleID;
                    meterUnit.MeterID = customerinfo.MeterID;
                    meterUnit.GPSX = Convert.ToDecimal(item.nod_gps_h);
                    meterUnit.GPSY = Convert.ToDecimal(item.nod_gps_l);
                    meterUnit.MeterStatus = item.nod_status;
                    meterUnit.OMRModelNo = item.nod_model;
                    meterUnit.DigitalModelNo = item.nod_model;
                    meterUnit.BillCode = customerinfo.BillCode7Layer.BillCode7LayerNo.ToString();
                    meterUnit.Active = true;
                    meterUnit.CreatedDate = DateTime.Now;
                    meterUnit.CreatedUserID = UserID;
                    meterUnitCollectList.Add(meterUnit);
                    }
                iMeterUnitColleciton.MeterUnitCollectionsProces(meterUnitCollectList);
                return true;
                }
            catch (Exception ex) {
                return false;
                }
            }
        #region Cancel Click Action

        private void btnCancel_Click(object sender, EventArgs e) {
            this.dtpfromDate.Value = DateTime.Now;
            dtptoDate.Value = DateTime.Now;
            cboQuarter.SelectedIndex = 0;
            cbofileName.SelectedIndex = cboTransformer.SelectedIndex = 0;
            this.Text = "Meter Unit Collections";
            this.gvnodemeter.DataSource = null;
            this.gvnodemeter.Refresh();
         
            }
        #endregion

        #region Bind Township & Transformer Data List            
        private void bindTransformer() {
            List<Transformer> transformerList = new List<Transformer>();
            Transformer transformer = new Transformer();
            transformer.TransformerID = Convert.ToString(0);
            transformer.TransformerName = "Select";
            transformerList.Add(transformer);
            transformerList.AddRange(mbmsEntities.Transformers.Where(x => x.Active == true).OrderBy(x => x.TransformerName).ToList());
            cboTransformer.DataSource = transformerList;
            cboTransformer.DisplayMember = "TransformerName";
            cboTransformer.ValueMember = "TransformerID";
            
            }
        private void bindQuarter() {
            List<Quarter> quarterList = new List<Quarter>();
            Quarter q = new Quarter();
            q.QuarterID = Convert.ToString(0);
            q.QuarterNameInEng = "Select";
            quarterList.Add(q);
            quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true).OrderBy(x => x.QuarterNameInEng).ToList());
            cboQuarter.DataSource = quarterList;
            cboQuarter.DisplayMember = "QuarterNameInEng";
            cboQuarter.ValueMember = "QuarterID";
            
            }
        #endregion
        private void btnSave_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("are you sure to collect all of meter unit data to the system?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == result) {
                if (SaveMeterUnitCollection(nodeMeterList)) {
                    MessageBox.Show("Meter Unit Collection process is successully complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        private void cboQuarter_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboQuarter.SelectedIndex >0) {
                string qid = cboQuarter.SelectedValue.ToString();
                List<Transformer> data = mbmsEntities.Transformers.Where(x => x.Active == true && x.QuarterID==qid).OrderBy(x => x.TransformerName).ToList();
                if(data.Count>0)
                cboTransformer.DataSource = data;
                else {
                    MessageBox.Show("There is no transformer data.");
                    this.bindTransformer();
                    }
                }
            }
        }
    }
