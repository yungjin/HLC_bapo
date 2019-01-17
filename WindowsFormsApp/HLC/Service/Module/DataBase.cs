using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Service.Module 
{
    public class DataBase
    {
        private MySqlConnection conn;
        private bool status;

        public DataBase()
        {
            status = Connection();
        }

        private bool Connection()
        {
            try
            {
                // conn = new MySqlConnection();
                // string server = "gudi.kr";
                // string uid = "gdc3";
                // string port = "5002";
                // string password = "gdc3";
                // string database = "gdc3_2";

                conn = new MySqlConnection();
                string server = "ljh5432.iptime.org";
                string uid = "root";
                string port = "3333";
                string password = "1234";
                string database = "gdc3_2";


                conn.ConnectionString = string.Format("server={0};Port={1};uid={2};password={3};database={4}", server, port, uid, password, database);
                //conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Open();
                    Console.WriteLine("conn.Open() : 실행완료");
                }
                else
                    try{
                        conn.Open();
                    }catch(Exception ex){
                        Console.WriteLine(ex.GetType().FullName);
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("conn.Open() : 실패");
                    }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                Console.WriteLine("conn.Open() : 실패");
                return false;
            }
        }
    
        public void Close()
        {
            if (status)
            {
                conn.Close();
            }
        }

        public MySqlDataReader Reader(string sql)
        {
            if (status)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    return comm.ExecuteReader();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }            
        }

        public MySqlDataReader HLC_Reader(string sql)
        {
            if (status)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    return comm.ExecuteReader();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }            
        }
        

         public MySqlDataReader HLC_Reader_Value(string sql, Hashtable ht)
        {
            if (status)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;

                     foreach (DictionaryEntry data in ht)
                    {
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }

                    return comm.ExecuteReader();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }            
        }
        public bool HLC_NonQuery_Value(string sql, Hashtable ht)
        {
            if (status)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (DictionaryEntry data in ht)
                    {
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }

                    comm.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ReaderClose(MySqlDataReader sdr)
        {
            try
            {
                sdr.Close();
                return true;
            }
            catch
            {
                return false;
            }            
        }  


        public bool NonQuery(string sql, Hashtable ht)
        {
            if (status)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;

                    foreach (DictionaryEntry data in ht)
                    {
                        comm.Parameters.AddWithValue(data.Key.ToString(), data.Value);
                    }

                    comm.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public MySqlDataReader CMDReader(string sql)
        {
            if (status)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;
                    Console.WriteLine("DaTaBase Acess Success!!!!");            
                    return comm.ExecuteReader();
                    
                }
                catch
                {
                    Console.WriteLine("DaTaBase Acess Fail!!!!");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("DaTaBase Acess Fail!!!!");
                return null;
            }            
        }


        public bool CMDNonQuery(string sql)
        {
            if (status)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand();
                    comm.CommandText = sql;
                    comm.Connection = conn;  
                    
                    comm.ExecuteNonQuery();
                    Console.WriteLine("Database CMDNonQuery 실행완료");
                    return true;
                }
                catch
                {
                    Console.WriteLine("Database CMDNonQuery 오류발생!!!");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}