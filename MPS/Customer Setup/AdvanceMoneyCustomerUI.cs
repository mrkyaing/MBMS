using MPS.BusinessLogic.AdvanceMoneyCustomerController;
using MPS.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Customer_Setup {
    public partial class AdvanceMoneyCustomerUI : Form {
        IAdvanceMoneyCustomerServices service;
        public AdvanceMoneyCustomerUI() {
            InitializeComponent();
            service = new AdvanceMoneyCustomerController();
            }

        private void AdvanceMoneyCustomerUI_Load(object sender, EventArgs e) {
            pageRefresh();
            }

        private void pageRefresh() {
            gvadvancemoneycustomer.AutoGenerateColumns = false;
            this.gvadvancemoneycustomer.DataSource = service.GetAdvanceMoneyCustomer();
            }

        private void btnSearch_Click(object sender, EventArgs e) {
            gvadvancemoneycustomer.DataSource = null;
            gvadvancemoneycustomer.AutoGenerateColumns = false;
            List<AdvanceMoneyCustomerVM> data = service.GetAdvanceMoneyCustomerByFromDateCustomerID(dtpfromDate.Value, dtpToDate.Value);
            if (data.Count == 0) { MessageBox.Show("There is no data to show");
              
                }
            else {
                this.gvadvancemoneycustomer.DataSource = data;
                }
            }

        private void btnCancel_Click(object sender, EventArgs e) {
            dtpfromDate.Value = dtpToDate.Value = DateTime.Now;
            gvadvancemoneycustomer.DataSource = null;
            }
        }
    }
