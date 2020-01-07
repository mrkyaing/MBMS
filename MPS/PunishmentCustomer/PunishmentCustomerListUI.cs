using MPS.BusinessLogic.PunishmentCustomerController;
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

namespace MPS.PunishmentCustomerList {
    public partial class PunishmentCustomerListUI : Form {
        IPunishmentCustomerServices service = null;
        public PunishmentCustomerListUI() {
            InitializeComponent();
            service = new PunishmentCustomerController();
            }

        private void PunishmentCustomerListUI_Load(object sender, EventArgs e) {
            pageRefresh();
            }
        private void pageRefresh() {
            gvpunishmentCustomer.AutoGenerateColumns = false;
            this.gvpunishmentCustomer.DataSource = service.GetPunishmentCustomer();
            }

        private void btnSearch_Click(object sender, EventArgs e) {
            gvpunishmentCustomer.DataSource = null;
            gvpunishmentCustomer.AutoGenerateColumns = false;
            List<PunishmentCustomerVM> data = service.GetPunishmentCustomerByFromDateCustomerID(dtpfromDate.Value, dtpToDate.Value);
            if (data.Count == 0) {
                MessageBox.Show("There is no data to show");

                }
            else {
                this.gvpunishmentCustomer.DataSource = data;
                }
            }

        private void btnCancel_Click(object sender, EventArgs e) {
            dtpfromDate.Value = dtpToDate.Value = DateTime.Now;
            gvpunishmentCustomer.DataSource = null;
            }
        }
    }
