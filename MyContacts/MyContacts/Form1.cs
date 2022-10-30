using MyContacts.Repository;
using MyContacts.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form1 : Form
    {
        IContactsRepository repository;
        public Form1()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGride();
        }
        private void BindGride()
        {
            dgContacts.AutoGenerateColumns = false;
            dgContacts.DataSource = repository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGride();
        }

        private void btnNewContact_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGride();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgContacts.CurrentRow != null)
            {
                string rowName = dgContacts.CurrentRow.Cells[1].Value.ToString();
                string rowFamily = dgContacts.CurrentRow.Cells[2].Value.ToString();
                string fullName = rowName + " " + rowFamily;

                if (MessageBox.Show($"آیا از حذف {fullName} اطمینان دارید؟", "توجه", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    int contactID = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(contactID);
                    BindGride();
                }
            }
            else
            {
                MessageBox.Show("لطفا یک مخاطب را از لیست انتخاب نمایید");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgContacts.CurrentRow != null)
            {
                int contactID = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                frmAddOrEdit frm = new frmAddOrEdit();
                frm.contactID = contactID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGride();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgContacts.DataSource = repository.Search(txtSearch.Text);
        }
    }
}
