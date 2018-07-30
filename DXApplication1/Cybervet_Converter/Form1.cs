using VetTux_Converter.VetTux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VetTux_Converter
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnVetTux_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmVetTuxConversion VetTuxForm = new frmVetTuxConversion();
            VetTuxForm.ShowDialog();
        }
    }
}
