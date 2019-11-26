﻿using MBMS.DAL;
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

namespace MPS
{
    public partial class Polefrm : Form
    {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
        string poleID;
        public Boolean isEdit { get; set; }
        Pole pole = new Pole();
        PoleController poleController = new PoleController();

        public Polefrm()
        {
            InitializeComponent();
        }

        private void Polefrm_Load(object sender, EventArgs e)
        {
            bindTransformer();
            FormRefresh();
        }
        public void bindTransformer()
        {
            List<Transformer> transList = new List<Transformer>();
            Transformer trans = new Transformer();
            trans.TransformerID = Convert.ToString(0);
            trans.TransformerName = "Select";
            transList.Add(trans);
            transList.AddRange(mbmsEntities.Transformers.Where(x => x.Active == true).OrderBy(x=> x.TransformerName).ToList());
            cboTransformerName.DataSource = transList;
            cboTransformerName.DisplayMember = "TransformerName";
            cboTransformerName.ValueMember = "TransformerID";
        }
        public bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";

            if (txtPoleNo.Text == string.Empty)
            {
                tooltip.SetToolTip(txtPoleNo, "Error");
                tooltip.Show("Please fill up Pole No!", txtPoleNo);
                hasError = false;
            }
            else if (txtGPSX.Text == string.Empty)
            {
                tooltip.SetToolTip(txtGPSX, "Error");
                tooltip.Show("Please fill up Pole GPS-X!", txtGPSX);
                hasError = false;
            }
            else if (txtGPSY.Text == string.Empty)
            {
                tooltip.SetToolTip(txtGPSY, "Error");
                tooltip.Show("Please fill up Pole GPS-Y!", txtGPSY);
                hasError = false;
            }
            else if (cboTransformerName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboTransformerName, "Error");
                tooltip.Show("Please Choose Transformer Name!", cboTransformerName);
                hasError = false;
            }
            return hasError;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (checkValidation())
            {
                if (isEdit)
                {
                    int editPoleNoCount=0;
                    Pole updatePole = (from p in mbmsEntities.Poles where p.PoleID == poleID select p).FirstOrDefault();
                    if (txtPoleNo.Text != updatePole.PoleNo)
                    {
                        editPoleNoCount = (from p in mbmsEntities.Poles where p.PoleNo ==txtPoleNo.Text && p.Active==true  select p).ToList().Count;
                    }

                    if (editPoleNoCount > 0)
                    {
                        tooltip.SetToolTip(txtPoleNo, "Error");
                        tooltip.Show("Pole No is already exist!", txtPoleNo);
                        return;
                    }
                    updatePole.PoleNo = txtPoleNo.Text;
                    updatePole.GPSX =Convert.ToDecimal( txtGPSX.Text);
                    updatePole.GPSY = Convert.ToDecimal(txtGPSY.Text);
                    updatePole.TransformerID = cboTransformerName.SelectedValue.ToString();
                    updatePole.UpdatedUserID = UserID;
                    updatePole.UpdatedDate = DateTime.Now;
                    poleController.UpdatePole(updatePole);
                    MessageBox.Show("Successfully updated Pole!", "Update");
                    Clear();
                    FormRefresh();
                }
                else
                {
                    int poleNoCount = 0;
                    poleNoCount = (from p in mbmsEntities.Poles where p.PoleNo == txtPoleNo.Text && p.Active==true select p).ToList().Count;

                    if (poleNoCount > 0)
                    {
                        tooltip.SetToolTip(txtPoleNo, "Error");
                        tooltip.Show("Pole No is already exist!", txtPoleNo);
                        return;
                    }
                    pole.PoleID = Guid.NewGuid().ToString();
                    pole.PoleNo = txtPoleNo.Text;
                    pole.GPSX = Convert.ToDecimal(txtGPSX.Text);
                    pole.GPSY = Convert.ToDecimal(txtGPSY.Text);
                    pole.TransformerID = cboTransformerName.SelectedValue.ToString();
                    pole.Active = true;
                    pole.CreatedUserID = UserID;
                    pole.CreatedDate = DateTime.Now;
                    poleController.Save(pole);
                    MessageBox.Show("Successfully registered Pole! Please check it in 'Pole List'.", "Save Success");
                    Clear();
                    FormRefresh();
                }
            }
        }
        public void Clear()
        {
            txtPoleNo.Text = string.Empty;
            txtGPSX.Text = string.Empty;
            txtGPSY.Text = string.Empty;
            cboTransformerName.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void FormRefresh()
        {
            dgvPoleList.AutoGenerateColumns = false;
            dgvPoleList.DataSource = (from p in mbmsEntities.Poles where p.Active == true orderby p.PoleNo descending select p).ToList();
        }

        private void dgvPoleList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPoleList.Rows)
            {
                Pole pole = (Pole)row.DataBoundItem;
                row.Cells[0].Value = pole.PoleID;
                row.Cells[1].Value = pole.PoleNo;
                row.Cells[2].Value = pole.GPSX;
                row.Cells[3].Value = pole.GPSY;
                row.Cells[4].Value = pole.Transformer.TransformerName;
                     }
        }

        private void dgvPoleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    //DeleteForPole
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {

                        DataGridViewRow row = dgvPoleList.Rows[e.RowIndex];
                        poleID = Convert.ToString(row.Cells[0].Value);
                        Pole poleObj = (Pole)row.DataBoundItem;
                        poleObj = (from p in mbmsEntities.Poles where p.PoleID == poleObj.PoleID select p).FirstOrDefault();
                        var meterBoxCount = (from mb in poleObj.MeterBoxes where mb.Active == true select mb).Count();
                        if (meterBoxCount > 0)
                        {
                            MessageBox.Show("This Pole cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvPoleList.DataSource = "";
                            Pole pole = (from p in mbmsEntities.Poles where p.PoleID == poleID select p).FirstOrDefault();
                            pole.Active = false;
                            pole.DeletedUserID = UserID;
                            pole.DeletedDate = DateTime.Now;
                        poleController.DeletePole(pole);
                            dgvPoleList.DataSource = (from p in mbmsEntities.Poles where p.Active == true orderby p.PoleNo descending select p).ToList();
                            MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            FormRefresh();
                        
                    }

                }
                else if (e.ColumnIndex == 5)
                {
                    //EditPole
                    DataGridViewRow row = dgvPoleList.Rows[e.RowIndex];
                    poleID = Convert.ToString(row.Cells[0].Value);
                    txtPoleNo.Text = Convert.ToString(row.Cells[1].Value);
                    txtGPSX.Text = Convert.ToString(row.Cells[2].Value);
                    txtGPSY.Text = Convert.ToString(row.Cells[3].Value);
                    cboTransformerName.Text = Convert.ToString(row.Cells[4].Value);
                    isEdit = true;

                }
            }
        }

        private void txtGPSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void txtGPSY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
    }
}
