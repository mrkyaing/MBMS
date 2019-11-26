using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Customer_Setup
{
    public partial class DetailCustomerfrm : Form
    {
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String customerID { get; set; }
        public DetailCustomerfrm()
        {
            InitializeComponent();
        }

        private void DetailCustomerfrm_Load(object sender, EventArgs e)
        {
            Customer customer = (from c in mbmsEntities.Customers where c.CustomerID == customerID select c).FirstOrDefault<Customer>();
            lblAddressEng.Text = customer.CustomerAddressInEng;
            lblAddressMM.Text = customer.CustomerAddressInMM;
            lblBillCodeNo.Text =Convert.ToString( customer.BillCode7Layer.BillCode7LayerNo);
            lblBookCode.Text =Convert.ToString( customer.Ledger.BookCode);
            lblCustomerCode.Text = customer.CustomerCode;
            lblCustomerNameEng.Text = customer.CustomerNameInEng;
            lblCustomerNameMM.Text =customer.CustomerNameInMM;
            lblLineNo.Text =Convert.ToString( customer.LineNo);
            lblPageNo.Text =Convert.ToString( customer.PageNo);
            lblNRC.Text = customer.NRC;
            lblMeterNo.Text = customer.Meter.MeterNo;
            lblPh.Text = customer.PhoneNo;
            lblPostalCode.Text = customer.Post;
            lblQuarterName.Text = customer.Quarter.QuarterNameInEng;
            lblTownshipName.Text = customer.Township.TownshipNameInEng;
        }
    }
}
