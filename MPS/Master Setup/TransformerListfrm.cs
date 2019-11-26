using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Master_Setup
{
    public partial class TransformerListfrm : Form
    {
        MBMSEntities mbsEntities = new MBMSEntities();
        TransformerController transformerController = new TransformerController();
        private List<Transformer> transformerList = new List<Transformer>();
        string TransformerID;
        public string UserID { get; set; }
        public TransformerListfrm()
        {
            InitializeComponent();
        }

        private void TransformerListfrm_Load(object sender, EventArgs e)
        {
            bindQuarter();
            FormRefresh();
        }
        public void bindQuarter()
        {
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbsEntities.Quarters.Where(x => x.Active == true).ToList());
            cboQuarterName.DataSource = quarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
        }
        public void FormRefresh()
        {
            dgvTransformerList.AutoGenerateColumns = false;
            dgvTransformerList.DataSource = (from tf in mbsEntities.Transformers where tf.Active == true orderby tf.TransformerName descending select tf).ToList();
        }
        public void loadData()
        {
            transformerList = (from tf in mbsEntities.Transformers
                        where tf.Active == true &&
                        tf.TransformerName == txtTransformerName.Text  || tf.Model==txtTransformerModel.Text || tf.Quarter.QuarterNameInEng == cboQuarterName.Text
                        select tf).ToList();
            foundDataBind();

        }
        public void foundDataBind()
        {

            dgvTransformerList.DataSource = "";

            if (transformerList.Count < 1)
            {
                MessageBox.Show("No data Found", "Cannot find");
                dgvTransformerList.DataSource = "";
                return;
            }
            else
            {
                dgvTransformerList.DataSource = transformerList;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void dgvTransformerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransformerList.Rows)
            {
                Transformer transformer = (Transformer)row.DataBoundItem;
                row.Cells[0].Value = transformer.TransformerID;
                row.Cells[1].Value = transformer.TransformerName;
                row.Cells[2].Value = transformer.Model;
                row.Cells[3].Value = transformer.GPSX;
                row.Cells[4].Value = transformer.GPSY;
                row.Cells[5].Value = transformer.Status;
                row.Cells[6].Value = transformer.Quarter.QuarterNameInEng;
                row.Cells[7].Value = transformer.Address;
            }
        }

        private void dgvTransformerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 9)
                {
                    //DeleteForTransformer
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvTransformerList.Rows[e.RowIndex];
                        Transformer transObi = (Transformer)row.DataBoundItem;
                        transObi = (from t in mbsEntities.Transformers where t.TransformerID == transObi.TransformerID select t).FirstOrDefault();
                        var poleCount = (from t in transObi.Poles where t.Active == true select t).Count();
                        var ledgerCount = (from l in transObi.Ledgers where l.Active == true select l).Count();
                        if(poleCount > 0)
                            {
                            MessageBox.Show("This Transformer cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (ledgerCount > 0)
                        {
                            MessageBox.Show("This Transformer cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        TransformerID = Convert.ToString(row.Cells[0].Value);
                   
                            dgvTransformerList.DataSource = "";
                            Transformer transformer = (from tf in mbsEntities.Transformers where tf.TransformerID == TransformerID select tf).FirstOrDefault();
                            transformer.Active = false;
                            transformer.DeletedUserID = UserID;
                            transformer.DeletedDate = DateTime.Now;
                            transformerController.DeleteTransformer(transformer);
                            dgvTransformerList.DataSource = (from tf in mbsEntities.Transformers where tf.Active == true orderby tf.TransformerName descending select tf).ToList();
                            MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormRefresh();
                        
                    }

                }
                else if (e.ColumnIndex == 8)
                {
                    //EditTransformer
                    Transformerfrm transForm = new Transformerfrm();
                    transForm.isEdit = true;
                    transForm.Text = "Edit Transformer";
                    transForm.TransformerID = Convert.ToString(dgvTransformerList.Rows[e.RowIndex].Cells[0].Value);
                    transForm.UserID = UserID;
                    transForm.ShowDialog();
                    this.Close();

                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTransformerModel.Text = string.Empty;
            txtTransformerName.Text = string.Empty;
            cboQuarterName.SelectedIndex = 0;
            FormRefresh();            
        }

        private void btnAddNewTrans_Click(object sender, EventArgs e)
        {
            Transformerfrm transForm = new Transformerfrm();
            transForm.UserID = UserID;
            transForm.Show();
            this.Close();
        }
    }
}
