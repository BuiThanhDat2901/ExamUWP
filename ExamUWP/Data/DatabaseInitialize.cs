using ExamUWP.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamUWP.Data
{
    class DatabaseInitialize
    {
        public static bool DropTable()
        {
            var conn = new SQLiteConnection("sqlitecontact.db");
            string sql = "DROP TABLE IF EXISTS Contact;";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;

        }
        public static bool CreateTables()
        {
            var cnn = new SQLiteConnection("sqlitecontact.db");
            string sql = @"CREATE TABLE IF NOT EXISTS 
                           Contact ( Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                                     Name VARCHAR(150), 
                                     PhoneNumber VARCHAR(150), 
                                                
                                                 );";
            using (var statement = cnn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }
        public static bool SaveTables(Contact contact)
        {
            var cnn = new SQLiteConnection("sqlitecontact.db");
            using (var createContact = cnn.Prepare("INSERT INTO Contact(Name, PhoneNumber) VALUES (?, ?)"))
            {
                createContact.Bind(1, contact.Name);
                createContact.Bind(2, contact.PhoneNumber);
                createContact.Step();
            }
            return true;
        }

        public static List<Contact> ListContact()
        {
            var list = new List<Contact>();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection("sqlitecontact.db");
                using (var stt = cnn.Prepare("select * from Contact"))
                {
                    while (stt.Step() == SQLiteResult.ROW)
                    {
                        var contactThis = new Contact()
                        {
                            Name = (string)stt["Name"],
                            PhoneNumber = (string)stt["Phone"],
                        };
                        list.Add(contactThis);
                    }
                }
                //Debug.WriteLine(list[0]);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Co loi list" + ex);
                return null;
            }
        }

        public static List<Contact> searchContactByName(string Name)
        {
            var list = new List<Contact>();
            try
            {
                Debug.WriteLine("Name la" + Name);
                SQLiteConnection cnn = new SQLiteConnection("sqlitecontact.db");
                using (var stt = cnn.Prepare($"select * from Contact where Name = '{Name}'"))
                {
                    while (stt.Step() == SQLiteResult.ROW)
                    {
                        var contact = new Contact()
                        {
                            Name = (string)stt["Name"],
                            PhoneNumber = (string)stt["Phone"],
                        };
                        list.Add(contact);
                    }
                }
                Debug.WriteLine(list[0]);
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Co loi list" + ex);
                return null;
            }
        }
    }
}
