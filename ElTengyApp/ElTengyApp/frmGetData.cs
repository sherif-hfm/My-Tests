using ElTengyApp.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElTengyApp
{
    public partial class frmGetData : Form
    {
        public frmGetData()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillSex()
        {
            List<Sex> sexList = new List<Sex>();
            sexList.Add(new Sex() { SexCode = 0, SexDesc = "Male" });
            sexList.Add(new Sex() { SexCode = 1, SexDesc = "Female" });
            cbSex.ValueMember = "SexCode";
            cbSex.DisplayMember = "SexDesc";
            cbSex.DataSource = sexList;
        }
        private void frmGetData_Load(object sender, EventArgs e)
        {
            FillSex();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase("Students.db"))
            {
                // Get customer collection
                var col = db.GetCollection<DataHolder>("Students");
                var result = col.FindOne(x => x.Id.Equals(txtId.Text));
                txtEncryptData.Text = result.Data;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase("Students.db"))
            {
                // Get customer collection
                var col = db.GetCollection<DataHolder>("Students");
                var result = col.FindOne(x => x.Id.Equals(txtId.Text));
                var student = DataHolder.Decrypt(result.Data);

                txtName.Text = student.Name;
                cbSex.SelectedValue = student.Sex;
                dtBirth.Value = student.BirthDate;
            }
        }
    }
}
