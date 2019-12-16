using MBMS.DAL;
using MPS.BusinessLogic.MeterUnitCollectionController;
using MPS.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.Data;
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
            BuildSQLiteConnection();
            }
        private void BuildSQLiteConnection() {
            if (String.IsNullOrEmpty(Storage.ConnectionString)) {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", System.Configuration.ConfigurationManager.AppSettings["DatabaseFile"]));
                }
            }
        private void MeterUnitCollectionsfrm_Load(object sender, EventArgs e) {
            bindTownship();
            bindTransformer();         
            }
        private void GetMeterUnitData(string fromDate, string toDate) {
            //VillageServices svc = new VillageServices();
            //List<Villages> vlist = svc.GetAll().Where(x=>x.vlg_name== "Mawkanin").ToList();
            //this.gvvillage.DataSource = vlist;           
            NodeMeterServices NodeMetersvc = new NodeMeterServices();
            string sqlCommand = string.Format("SELECT * FROM NodeMeter WHERE nod_bill_from>='{0}' AND nod_bill_to<='{1}' ", fromDate, toDate);
            nodeMeterList = NodeMetersvc.GetAll(sqlCommand).ToList();
            this.gvnodemeter.DataSource = nodeMeterList;
            if (nodeMeterList.Count ==0) {
                    MessageBox.Show("There is no data to collect.", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;       
                }                 
            }
        private void btncollectmeterunit_Click(object sender, EventArgs e) {
            string fromdate = dtpfromDate.Value.ToString("yyyyMMdd");
            string todate = dtptoDate.Value.ToString("yyyy-MM-dd");
            GetMeterUnitData(fromdate,todate);            
            }
        private bool SaveMeterUnitCollection(List<NodeMeter> data) {
            try {
                List<MBMS.DAL.MeterUnitCollect> meterUnitCollectList = new List<MBMS.DAL.MeterUnitCollect>();
                foreach (NodeMeter item in data) {
                    MBMS.DAL.MeterUnitCollect meterUnit = new MBMS.DAL.MeterUnitCollect();
                    meterUnit.MeterUnitCollectID = Guid.NewGuid().ToString();
                    Customer customerinfo = mbmsEntities.Customers.Where(x => x.CustomerCode == item.nod_csm_id&&x.Active==true).SingleOrDefault();//eg >>450-050-545-450-TPYTR05-00000428
                    if (customerinfo == null) {
                        ErrorList.Append("Set customer record for :" + item.nod_csm_id);
                        MessageBox.Show(ErrorList.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                        }
                    meterUnit.CustomerID = customerinfo.CustomerID;
                    meterUnit.FromDate = dtpfromDate.Value;
                    meterUnit.ToDate = dtptoDate.Value;
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
            cboTownship.SelectedIndex = 0;
            cboTransformer.SelectedIndex = 0;
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
        private void bindTownship() {
            List<Township> townshipList = new List<Township>();
            Township township = new Township();
            township.TownshipID = Convert.ToString(0);
            township.TownshipNameInEng = "Select";
            townshipList.Add(township);
            townshipList.AddRange(mbmsEntities.Townships.Where(x => x.Active == true).OrderBy(x => x.TownshipNameInEng).ToList());
            cboTownship.DataSource = townshipList;
            cboTownship.DisplayMember = "TownshipNameInEng";
            cboTownship.ValueMember = "TownshipID";
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
        }
    }
