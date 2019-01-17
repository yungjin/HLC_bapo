using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Service.Modules
{
    public class TestBean
    {
        public int no { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }

    public static class LocalDB
    {
        private static string server = "(localdb)\\ProjectsV13";
        private static string uid = "root";
        private static string password = "1234";
        private static string database = "Test2";

        public static string connectionString = string.Format("server={0};uid={1};password={2};database={3}", server, uid, password, database);
    }

    public static class TestService
    {
        private static SqlConnection conn;
        private static Hashtable resultMap, dataRow;
        private static ArrayList resultList;

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = LocalDB.connectionString;
                conn.Open();
                return conn;
            }
            catch
            {
                Console.WriteLine("접속 실패");
                return null;
            }
        }

        public static Hashtable Select()
        {
            resultList = new ArrayList();
            resultMap = new Hashtable();
            try
            {
                conn = GetConnection();
                SqlCommand comm = new SqlCommand("sp_select", conn);
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = comm.ExecuteReader();
                while (sdr.Read())
                {
                    dataRow = new Hashtable();
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        dataRow.Add(sdr.GetName(i), sdr.GetValue(i));
                    }
                    resultList.Add(dataRow);
                }
                sdr.Close();                
                resultMap.Add("msgCode", 1);
                resultMap.Add("data", resultList);
            }
            catch
            {
                Console.WriteLine("실행 실패");
                resultMap.Add("msgCode", 0);
            }
            finally 
            {
                conn.Close();
            }
            return resultMap;
        }

        public static Hashtable Insert(TestBean tb)
        {
            resultList = new ArrayList();
            resultMap = new Hashtable();
            try
            {
                conn = GetConnection();
                SqlCommand comm = new SqlCommand("sp_insert", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@name", tb.name);
                comm.Parameters.AddWithValue("@age", tb.age);
                comm.ExecuteNonQuery();
                resultMap.Add("msgCode", 1);
            }
            catch
            {
                Console.WriteLine("실행 실패");
                resultMap.Add("msgCode", 0);
            }
            finally 
            {
                conn.Close();
            }
            return resultMap;
        }

        public static Hashtable Update(TestBean tb)
        {
            resultList = new ArrayList();
            resultMap = new Hashtable();
            try
            {
                conn = GetConnection();
                SqlCommand comm = new SqlCommand("sp_update", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@no", tb.no);
                comm.Parameters.AddWithValue("@name", tb.name);
                comm.Parameters.AddWithValue("@age", tb.age);
                comm.ExecuteNonQuery();
                resultMap.Add("msgCode", 1);
            }
            catch
            {
                Console.WriteLine("실행 실패");
                resultMap.Add("msgCode", 0);
            }
            finally 
            {
                conn.Close();
            }
            return resultMap;
        }

        public static Hashtable Delete(TestBean tb)
        {
            resultList = new ArrayList();
            resultMap = new Hashtable();
            try
            {
                conn = GetConnection();
                SqlCommand comm = new SqlCommand("sp_delete", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@no", tb.no);
                comm.ExecuteNonQuery();
                resultMap.Add("msgCode", 1);
            }
            catch
            {
                Console.WriteLine("실행 실패");
                resultMap.Add("msgCode", 0);
            }
            finally 
            {
                conn.Close();
            }
            return resultMap;
        }
    }
}