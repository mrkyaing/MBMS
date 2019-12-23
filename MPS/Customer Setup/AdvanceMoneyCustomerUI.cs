using MPS.BusinessLogic.AdvanceMoneyCustomerController;
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
            this.gvadvancemoneycustomer.DataSource = service.GetAdvanceMoneyCustomer();
            }
        }
    }
