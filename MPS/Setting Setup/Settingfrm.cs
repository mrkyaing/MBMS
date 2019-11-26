using MBMS.DAL;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MPS.Utility;

namespace MPS.Setting_Setup
{
    public partial class Settingfrm : Form
    {
        MBMSEntities mbmsEntities = new MBMSEntities();
       
        private ToolTip tp = new ToolTip();
        public Settingfrm()
        {
            InitializeComponent();
        }

        private void Settingfrm_Load(object sender, EventArgs e)
        {

            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(printerName);                
            }
            if (DefaultPrinter.A4Printer != null)
            {
                cboPrinter.Text = DefaultPrinter.A4Printer;
            }
            txtNoCopy.Text = SettingController.DefaultNoOfCopies.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean hasError = false;

            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            if (txtNoCopy.Text.Trim() == string.Empty || Convert.ToInt32(txtNoCopy.Text) == 0)
            {                
                tp.SetToolTip(txtNoCopy, "Error");
                tp.Show("Please number of Copy!", txtNoCopy);
                hasError = true;
            }
            if (!hasError)
            {
                DefaultPrinter.A4Printer = cboPrinter.Text;
                SettingController.CompanyName = lblCompanyName.Text;
                SettingController.CompanyEmail = lblEmail.Text;
                SettingController.CompanyName = lblCompanyName.Text;
                SettingController.CompanyWebsite = lblWebsite.Text;
                SettingController.CompanyAddress = lblAddress.Text;
                SettingController.DefaultNoOfCopies =Convert.ToInt32( txtNoCopy.Text);
                mbmsEntities.SaveChanges();

            }
        }
    }
}
