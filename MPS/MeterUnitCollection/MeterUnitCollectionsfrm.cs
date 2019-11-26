using MBMS.DAL;
using MPS.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace MPS.MeterUnitCollect {
    public partial class MeterUnitCollectionsfrm : Form {
        MBMSEntities mbmsEntities = new MBMSEntities();
      
        public string UserID { get; set; }
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

        private void GetMeterUnitData(string fromDate,string toDate) {
            //VillageServices svc = new VillageServices();
            //List<Villages> vlist = svc.GetAll().Where(x=>x.vlg_name== "Mawkanin").ToList();
            //this.gvvillage.DataSource = vlist;           
            NodeMeterServices NodeMetersvc = new NodeMeterServices();
            string sqlCommant = string.Format("SELECT * FROM NodeMeter WHERE nod_bill_from>='{0}' AND nod_bill_to<='{1}' ", fromDate, toDate);
            var data = NodeMetersvc.GetAll(sqlCommant).ToList();
            this.gvnodemeter.DataSource = data;
            }
            
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

        private void btncollectmeterunit_Click(object sender, EventArgs e) {
            string fromdate = dtpfromDate.Value.ToString("yyyy-MM-dd");
            string todate = dtptoDate.Value.ToString("yyyy-MM-dd");
            this.GetMeterUnitData(fromdate,todate);           
            }

        private void bindMeterUnitCollection(MBMS.DAL.MeterUnitCollect meterUnitCollect) {
            meterUnitCollect.MeterUnitCollectID = Guid.NewGuid().ToString();
            meterUnitCollect.Active = true;
            meterUnitCollect.CreatedDate = DateTime.Now;
            meterUnitCollect.CreatedUserID = UserID;
            }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.dtpfromDate.Value = DateTime.Now;
            dtptoDate.Value = DateTime.Now;
            cboTownship.SelectedIndex = 0;
            cboTransformer.SelectedIndex = 0;
            this.Text = "Meter Unit Collections";
            this.gvnodemeter.DataSource = null;
            this.gvnodemeter.Refresh();
         
            }
        }
    }
