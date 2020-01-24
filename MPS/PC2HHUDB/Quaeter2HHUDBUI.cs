using MBMS.DAL;
using MPS.SQLiteHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.PC2HHUDB {
    public partial class Quaeter2HHUDBUI : Form {
        MBMSEntities mbmsEntities = new MBMSEntities();
        List<Quarter> qList = new List<Quarter>();
        public string sqlitedbPath { get; set; }
        public Quaeter2HHUDBUI() {
            InitializeComponent();
            getFileList();
            }
        private void BuildSQLiteConnection() {
            sqlitedbPath = System.Configuration.ConfigurationManager.AppSettings["DatabaseFile"] + cbofileName.SelectedItem;
            if (String.IsNullOrEmpty(Storage.ConnectionString)) {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", sqlitedbPath));
                }
            }

        private void Quaeter2HHUDBUI_Load(object sender, EventArgs e) {
            FormRefresh();
            }
        public void FormRefresh() {
            dgvQuarterList.AutoGenerateColumns = false;
            qList= (from q in mbmsEntities.Quarters where q.Active == true orderby q.QuarterCode descending select q).ToList();
            dgvQuarterList.DataSource = qList;
            }

        private void btnSave2HHUDB_Click(object sender, EventArgs e) {
            if (qList.Count == 0) {
                MessageBox.Show("There is no Villages(Quarter) data to save HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }         
                if (cbofileName.SelectedItem.Equals("Select One")) {
                MessageBox.Show("Select HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.Yes) {
                BuildSQLiteConnection();
                VillageServices sqlitevillage = new VillageServices();
                List<MPS.SQLiteHelper.Villages> sqlvillageList = new List<MPS.SQLiteHelper.Villages>();
                string sqlCommand = string.Format("SELECT * FROM Villages");
                var data = sqlitevillage.GetAll(sqlCommand);
                foreach (var v in data) {
                    foreach (Quarter q in qList) {
                        if (q.QuarterCode == v.vlg_code) {
                            MessageBox.Show("(" + q.QuarterCode + ") Villages(Quarter) code already exists in HHU db file.", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            }
                        }
                    }
                foreach (Quarter q in qList) {
                    MPS.SQLiteHelper.Villages v= new MPS.SQLiteHelper.Villages();
                    v.vlg_code = q.QuarterCode;
                    v.vlg_address = q.Address;
                    v.vlg_name = q.QuarterNameInEng;
                    v.vlg_value = q.QuarterNameInMM;
                    sqlvillageList.Add(v);
                    }
                try {
                    sqlitevillage.AddRange(sqlvillageList);
                    MessageBox.Show("Villages(Quarter) data to HHU db file is successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                catch (Exception ex) {
                    MessageBox.Show("Error occur when saving Villages to HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        private void btnRefresh_Click(object sender, EventArgs e) {
            txtQuarterCode.Text = string.Empty;
            FormRefresh();
            }

        private void btnSearch_Click(object sender, EventArgs e) {
            dgvQuarterList.AutoGenerateColumns = false;
            qList = (from q in mbmsEntities.Quarters where q.Active == true && q.QuarterCode==txtQuarterCode.Text orderby q.QuarterCode descending select q).ToList();
            dgvQuarterList.DataSource = qList;
            }
        private void getFileList() {
            this.cbofileName.Items.Add("Select One");
            this.cbofileName.SelectedIndex = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings["dbFileListPath"]);//Assuming Test is your Folder
            FileInfo[] Files = dirInfo.GetFiles("*.db"); //Getting db files
            foreach (FileInfo file in Files) {
              this.cbofileName.Items.Add(file.Name );    
                }
            }
     
        }
    }
