﻿using MBMS.DAL;
using MPS.BusinessLogic.LedgerController;
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
    public partial class Accountfrm : Form
    {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
        string ledgerID;
        public Boolean isEdit { get; set; }
        
        LedgerController ledgerController = new LedgerController();
        public Accountfrm()
        {
            InitializeComponent();
        }

        private void RegisterAccount_Load(object sender, EventArgs e)
        {
            bindTransformer();
            FormRefresh();
        }
        public void bindTransformer()
        {
            List<Transformer> transformerlist = new List<Transformer>();
            Transformer transformer = new Transformer();
            transformer.TransformerID = Convert.ToString(0);
            transformer.TransformerName = "Select";
            transformerlist.Add(transformer);
            transformerlist.AddRange(mbmsEntities.Transformers.Where(x => x.Active == true).ToList());
            cboTransformerName.DataSource = transformerlist;
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

            if (txtLedgerCode.Text == string.Empty)
            {
                tooltip.SetToolTip(txtLedgerCode, "Error");
                tooltip.Show("Please fill up Ledger Code!", txtLedgerCode);
                hasError = false;
            }
            else if (txtBookCode.Text == string.Empty)
            {
                tooltip.SetToolTip(txtBookCode, "Error");
                tooltip.Show("Please fill up Book Code!", txtBookCode);
                hasError = false;
            }
            else if (cboTransformerName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboTransformerName, "Error");
                tooltip.Show("Please choose Transformer Name!", cboTransformerName);
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
                    int editLedgerCodeCount = 0;
                    int editLedgerCode =Convert.ToInt32( txtLedgerCode.Text);
                    Ledger updateLedger = (from l in mbmsEntities.Ledgers where l.LedgerID == ledgerID select l).FirstOrDefault();
                    if (Convert.ToInt32( txtLedgerCode.Text) != updateLedger.LedgerCode)
                    {
                        editLedgerCodeCount = (from l in mbmsEntities.Ledgers where l.LedgerCode == editLedgerCode && l.Active == true select l).ToList().Count;
                    }

                    if (editLedgerCodeCount > 0)
                    {
                        tooltip.SetToolTip(txtLedgerCode, "Error");
                        tooltip.Show("Ledger Code is already exist!", txtLedgerCode);
                        return;
                    }
                    updateLedger.LedgerCode =Convert.ToInt32( txtLedgerCode.Text);
                    updateLedger.BookCode =Convert.ToInt32( txtBookCode.Text);
                    updateLedger.TransformerID = cboTransformerName.SelectedValue.ToString(); ;
                    updateLedger.UpdatedUserID = UserID;
                    updateLedger.UpdatedDate = DateTime.Now;
                    ledgerController.UpdateLedger(updateLedger);
                    MessageBox.Show("Successfully updated Ledger!", "Update");
                    Clear();
                    FormRefresh();
                }
                else
                {
                    Ledger ledger = new Ledger();
                    int ledgerCodeCount = 0;
                    int ledgerCode =Convert.ToInt32( txtLedgerCode.Text);
                    ledgerCodeCount = (from l in mbmsEntities.Ledgers where l.LedgerCode == ledgerCode && l.Active == true select l).ToList().Count;
                    if (ledgerCodeCount > 0)
                    {
                        tooltip.SetToolTip(txtLedgerCode, "Error");
                        tooltip.Show("Ledger Code is already exist!", txtLedgerCode);
                        return;
                    }

                    ledger.LedgerID = Guid.NewGuid().ToString();
                    ledger.LedgerCode = Convert.ToInt32(txtLedgerCode.Text);
                    ledger.BookCode = Convert.ToInt32(txtBookCode.Text);
                    ledger.TransformerID = cboTransformerName.SelectedValue.ToString();
                    ledger.Active = true;
                    ledger.CreatedUserID = UserID;
                    ledger.CreatedDate = DateTime.Now;
                    ledgerController.Save(ledger);
                    MessageBox.Show("Successfully registered Ledger! Please check it in 'Ledger List'.", "Save Success");
                    Clear();
                    FormRefresh();
                }
            }
        }

        public void Clear()
        {
            txtBookCode.Text = string.Empty;
            txtLedgerCode.Text = string.Empty;
            cboTransformerName.SelectedIndex = 0;
        }
        public void FormRefresh()
        {
            dgvLedgerList.AutoGenerateColumns = false;
            dgvLedgerList.DataSource = (from l in mbmsEntities.Ledgers where l.Active == true orderby l.LedgerCode descending select l).ToList();
        }

        private void dgvLedgerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvLedgerList.Rows)
            {
                Ledger ledger = (Ledger)row.DataBoundItem;
                row.Cells[0].Value = ledger.LedgerID;
                row.Cells[1].Value = ledger.LedgerCode;
                row.Cells[2].Value = ledger.BookCode;
                row.Cells[3].Value = ledger.Transformer.TransformerName;
            }
        }

        private void dgvLedgerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    //DeleteForLedger
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {

                        DataGridViewRow row = dgvLedgerList.Rows[e.RowIndex];
                        ledgerID = Convert.ToString(row.Cells[0].Value);
                        Ledger ledgerObj = (Ledger)row.DataBoundItem;
                        ledgerObj = (from l in mbmsEntities.Ledgers where l.LedgerID == ledgerObj.LedgerID select l).FirstOrDefault();
                        var customerCount = (from c in ledgerObj.Customers where c.Active == true select c).Count();
                        if (customerCount > 0)
                        {
                            MessageBox.Show("This Book Code cannot deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvLedgerList.DataSource = "";
                        Ledger ledger = (from l in mbmsEntities.Ledgers where l.LedgerID == ledgerID select l).FirstOrDefault();
                        ledger.Active = false;
                        ledger.DeletedUserID = UserID;
                        ledger.DeletedDate = DateTime.Now;
                        ledgerController.DeleteLedger(ledger);
                        dgvLedgerList.DataSource = (from l in mbmsEntities.Ledgers where l.Active == true orderby l.LedgerCode descending select l).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        FormRefresh();

                    }

                }
                else if (e.ColumnIndex == 4)
                {
                    //EditLedger
                    DataGridViewRow row = dgvLedgerList.Rows[e.RowIndex];
                    ledgerID = Convert.ToString(row.Cells[0].Value);
                    txtLedgerCode.Text = Convert.ToString(row.Cells[1].Value);
                    txtBookCode.Text = Convert.ToString(row.Cells[2].Value);
                    cboTransformerName.Text = Convert.ToString(row.Cells[3].Value);
                    isEdit = true;
                    btnSave.Text = "Update";
                }

                }
            }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtLedgerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtBookCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void cboTransformerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }
    }
}
