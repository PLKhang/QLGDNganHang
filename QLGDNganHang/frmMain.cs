using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLGDNganHang
{
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;

        public frmMain()
        {
            InitializeComponent();
        }
        private bool ExistedForm(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return true;   //nếu frmMain đã tồn tại thì trả về f, không thì trả về null.
            return false;
        }
        private void btnLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rbnManage.Visible = rbnReport.Visible = rbnRegister.Visible = false;
            btnLogout.Enabled = false;

        }
    }
}
