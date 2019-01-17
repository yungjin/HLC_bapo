using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace ClassLibrary1
{
    public class MySql
    {
        private MySqlConnection conn;

        public MySql()
        {
            this.conn = GetConnection();
        }

        private MySqlConnection GetConnection()
        {
            string host = "gudi.kr";
            string user = "gdc3";
            string port = "5002";
            string pwd = "gdc3";
            string db = "gdc3_2";

            //string host = "ljh5432.iptime.org";
            //string port = "3333";
            //string user = "root";
            //string pwd = "1234";
            //string db = "test";

            string connStr = string.Format(@"server={0};Port={1};user={2};password={3};database={4}", host, port, user, pwd, db);

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                //MessageBox.Show("성공");
                return conn;
            }
            catch
            {
                //MessageBox.Show("GetConnection 연결실패");
                return null;
            }
        }
        public bool ConnectionClose()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool NonQuery(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    comm.ExecuteNonQuery();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            try
            {
                if (conn != null)
                {
                    MySqlCommand comm = new MySqlCommand(sql, conn);
                    return comm.ExecuteReader();
                }
                else
                {
                    try { 
                        MessageBox.Show("conn 실패");
                        MySqlCommand comm = new MySqlCommand(sql, conn);
                        return comm.ExecuteReader();
                    }
                    catch
                    {
                        return null;
                    }
                    
                }
            }
            catch
            {
                
                return null;
            }
        }

        public void ReaderClose(MySqlDataReader reader)
        {
            reader.Close();
        }


        ///// 메소드 구현

        public ArrayList GetSelect()
        {
            MySql my = new MySql();
            string sql = "select book_number, availability, title, author, publisher from book_info;";
            MySqlDataReader sdr = my.Reader(sql);
            //string result = "";
            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    //result += string.Format("{0}\t:\t{1}\t", sdr.GetName(i), sdr.GetValue(i));
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));

                }
                //result += "\n";
                list.Add(ht);
                Console.WriteLine(list.ToString());
            }
            ReaderClose(sdr);
            ConnectionClose();
            return list;
        }


        public ArrayList GetInsert(string id, string name, string passwd)
        {
            MySql my = new MySql();
            string sql = string.Format("insert into test values ('{0}','{1}','{2}');", id, name, passwd);
            if (my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }

        public ArrayList GetUpdate(string id, string name, string passwd)
        {
            MySql my = new MySql();
            string sql = string.Format("update test set name = '{1}', passwd = '{2}' where id = '{0}';", id, name, passwd);
            if (my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }

        public ArrayList GetDelete(string id, string name, string passwd)
        {
            MySql my = new MySql();
            string sql = string.Format("delete from test where id = '{0}'", id);
            if (my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }

        public ArrayList RankSelect()
        {
            MySql my = new MySql();
            string sql = "SELECT member_rank FROM signup";
            MySqlDataReader sdr = my.Reader(sql);
            //string result = "";
            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    //result += string.Format("{0}\t:\t{1}\t", sdr.GetName(i), sdr.GetValue(i));
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));

                }
                //result += "\n";
                list.Add(ht);
                Console.WriteLine(list.ToString());
            }
            return list;
        }


        public ArrayList Select(string val)
        {
            MySql my = new MySql();
            string sql = val;
            MySqlDataReader sdr = my.Reader(sql);
            //string result = "";
            ArrayList list = new ArrayList();
            while (sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    //result += string.Format("{0}\t:\t{1}\t", sdr.GetName(i), sdr.GetValue(i));
                    ht.Add(sdr.GetName(i), sdr.GetValue(i));

                }
                //result += "\n";
                list.Add(ht);
                Console.WriteLine(list.ToString());
            }
            ReaderClose(sdr);
            ConnectionClose();
            return list;
        }

        public bool NonQuery_INSERT(string val)
        {
            MySql my = new MySql();
            string sql = val;
            if (my.NonQuery(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}