using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyContacts.Repository
{
    interface IContactsRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactID);
        DataTable Search(string parameter);
        bool Insert(string name, string family, string mobile, string email, int age, string address);
        bool Update(int contactID, string name, string family, string mobile, string email, int age, string address);
        bool Delete(int contactID);
    }
}
