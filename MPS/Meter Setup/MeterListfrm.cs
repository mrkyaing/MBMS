using MBMS.DAL;
using MPS.BusinessLogic.MeterController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Meter_Setup
{
    public partial class MeterListfrm : Form
    {
        MBMSEntities mbsEntities = new MBMSEntities();
        MeterController meterController = new MeterController();
        private List<Meter> meterList = new List<Meter>();
        string meterID;
        public string UserID { get; set; }
        public MeterListfrm()
        {
            InitializeComponent();
        }

        private void MeterListfrm_Load(object sender, EventArgs e)
        {
            FormRefresh();
            bindMeterBoxCode();
            bindMeterTypeCode();
            bindTransformer();
            bindPole();

        }
        public void bindMeterBoxCode()
        {
            List<MeterBox> meterboxList = new List<MeterBox>();
            MeterBox meterbox = new MeterBox();
            meterbox.MeterBoxID = Convert.ToString(0);
            meterbox.MeterBoxCode = "Select";
            meterboxList.Add(meterbox);
            meterboxList.AddRange(mbsEntities.MeterBoxes.Where(x => x.Active == true).ToList());
            cboMeterBoxCode.DataSource = meterboxList;
            cboMeterBoxCode.DisplayMember = "MeterBoxCode";
            cboMeterBoxCode.ValueMember = "MeterBoxID";
        }
        public void bindMeterTypeCode()
        {
            List<MeterType> meterTypeList = new List<MeterType>();
            MeterType meterType = new MeterType();
            meterType.MeterTypeID = Convert.ToString(0);
            meterType.MeterTypeCode = "Select";
            meterTypeList.Add(meterType);
            meterTypeList.AddRange(mbsEntities.MeterTypes.Where(x => x.Active == true).ToList());
            cboMeterTypeCode.DataSource = meterTypeList;
            cboMeterTypeCode.DisplayMember = "MeterTypeCode";
            cboMeterTypeCode.ValueMember = "MeterTypeID";
        }
        public void bindPole()
        {
            List<Pole> poleList = new List<Pole>();
            Pole pole = new Pole();
            pole.PoleID = Convert.ToString(0);
            pole.PoleNo = "Select";
            poleList.Add(pole);
            poleList.AddRange(mbsEntities.Poles.Where(x => x.Active == true).ToList());
            cboPole.DataSource = poleList;
            cboPole.DisplayMember = "PoleNo";
            cboPole.ValueMember = "PoleID";
        }
        public void bindTransformer()
        {
            List<Transformer> transformerList = new List<Transformer>();
            Transformer transformer = new Transformer();
            transformer.TransformerID = Convert.ToString(0);
            transformer.TransformerName = "Select";
            transformerList.Add(transformer);
            transformerList.AddRange(mbsEntities.Transformers.Where(x => x.Active == true).ToList());
            cboTransformer.DataSource = transformerList;
            cboTransformer.DisplayMember = "TransformerName";
            cboTransformer.ValueMember = "TransformerID";
        }

        public void FormRefresh()
        {
            dgvMeterList.AutoGenerateColumns = false;
            dgvMeterList.DataSource = (from m in mbsEntities.Meters where m.Active == true orderby m.MeterNo descending select m).ToList();
        }
        public void LoadData()
        {
            meterList = (from m in mbsEntities.Meters
                         where m.Active == true &&
                         m.MeterNo == txtMeterNo.Text || m.MeterBox.Pole.PoleNo == cboPole.Text ||
                         m.MeterBox.Pole.Transformer.TransformerName==cboTransformer.Text
                               || m.MeterBox.MeterBoxCode == cboMeterBoxCode.Text || m.MeterType.MeterTypeCode==cboMeterTypeCode.Text
                                select m).ToList();
            foundDataBind();
        }
        public void foundDataBind()
        {
            dgvMeterList.DataSource = "";

            if (meterList.Count < 1)
            {
                MessageBox.Show("No data Found", "Cannot find");
                dgvMeterList.DataSource = "";
                return;
            }
            else
            {
                dgvMeterList.DataSource = meterList;
            }
        }
        private void dgvMeterList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMeterList.Rows)
            {
                Meter meter = (Meter)row.DataBoundItem;
                row.Cells[0].Value = meter.MeterID;
                row.Cells[1].Value = meter.MeterNo;
                row.Cells[2].Value = meter.Model;
                row.Cells[3].Value = meter.InstalledDate;
                row.Cells[4].Value = meter.Voltage;
                row.Cells[5].Value = meter.ManufactureBy;
                row.Cells[6].Value = meter.Status;
                row.Cells[7].Value = meter.MeterBox.MeterBoxCode;
                row.Cells[8].Value = meter.MeterBoxSequence;
                row.Cells[9].Value = meter.MeterType.MeterTypeCode;
            }
        }

        private void dgvMeterList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 12)
                {
                    //DeleteForMeter
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvMeterList.Rows[e.RowIndex];                        
                        meterID = Convert.ToString(row.Cells[0].Value);
                        Meter meterObj = (Meter)row.DataBoundItem;
                        meterObj = (from m in mbsEntities.Meters where m.MeterID == meterObj.MeterID select m).FirstOrDefault();
                        var customerCount = (from c in meterObj.Customers where c.Active == true select c).Count();
                        if (customerCount > 0)
                        {
                            MessageBox.Show("This Meter No cannot deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvMeterList.DataSource = "";
                        Meter  meter = (from m in mbsEntities.Meters where m.MeterID == meterID select m).FirstOrDefault();
                        meter.Active = false;
                        meter.DeletedUserID = UserID;
                        meter.DeletedDate = DateTime.Now;
                        meterController.DeletedMeter(meter);
                        dgvMeterList.DataSource = (from m in mbsEntities.Meters where m.Active == true orderby m.MeterNo descending select m).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRefresh();

                    }

                }
                else if (e.ColumnIndex==10)
                {
                    DetailMeterfrm detailmeterForm = new DetailMeterfrm();
                    detailmeterForm.meterID = Convert.ToString(dgvMeterList.Rows[e.RowIndex].Cells[0].Value);
                    detailmeterForm.ShowDialog();

                }
                else if (e.ColumnIndex ==11)
                {
                    //EditMeter
                    MeterFrm meterForm = new MeterFrm();
                    meterForm.isEdit = true;
                    meterForm.Text = "Edit Meter";
                    meterForm.meterID = Convert.ToString(dgvMeterList.Rows[e.RowIndex].Cells[0].Value);
                    meterForm.UserID = UserID;
                    meterForm.ShowDialog();
                    this.Close();

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cboTransformer.SelectedIndex = 0;
            cboPole.SelectedIndex = 0;
            txtMeterNo.Text = string.Empty;
            cboMeterBoxCode.SelectedIndex = 0;
            cboMeterTypeCode.SelectedIndex = 0;
            FormRefresh();
        }
    }
}
