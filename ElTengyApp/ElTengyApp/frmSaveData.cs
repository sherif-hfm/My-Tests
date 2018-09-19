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
    public partial class frmSaveData : Form
    {
        public frmSaveData()
        {
            InitializeComponent();
        }

        private void frmSaveData_Load(object sender, EventArgs e)
        {
            FillSex();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase("Students.db"))
            {
                db.DropCollection("Students");
                // Get customer collection
                var col = db.GetCollection<DataHolder>("Students");

                var student = new Student { Id = txtId.Text, Name = txtName.Text, BirthDate = dtBirth.Value, Sex = (int)cbSex.SelectedValue };
                var dataHolder = new DataHolder() { Id = student.Id, Data = student.Encrypt() };
                // Insert new customer document
                col.Insert(dataHolder);
            }
            MessageBox.Show("Save Done");
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var student = new Student { Id = txtId.Text, Name = txtName.Text, BirthDate = dtBirth.Value, Sex = (int)cbSex.SelectedValue };
            txtEncryptData.Text = student.Encrypt();
        }
    }
}
