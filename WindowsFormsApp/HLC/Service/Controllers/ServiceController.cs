using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Module;
using MySql.Data.MySqlClient;

namespace Service.Controllers
{

    
    [ApiController]
    public class ServiceController : ControllerBase
    {
        // book_info_form
        [Route("book_info_form_listview")]
        [HttpGet]
        public ActionResult<ArrayList> Book_info_form_listview()
        {
            Console.WriteLine("select : book_info_form_listview");

            DataBase db = new DataBase();
            //string sql = "select book_number, availability, title, author, publisher from book_info;";
            MySqlDataReader sdr = db.HLC_Reader("p_book_info_form_listview");
            //MySqlDataReader sdr = db.CMDReader(sql);
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }

        [Route("book_info_listview_click_select_post")]
        [HttpPost]
        public ActionResult<ArrayList> Book_info_listview_click_select_post([FromForm] string book_number)
        {
            Console.WriteLine("Book_info_listview_click_select_post-----");
            Console.WriteLine("book_number : " + book_number);

            DataBase db = new DataBase();
            //string sql = string.Format("select * from book_info where book_number = {0};", book_number);

            Hashtable ht = new Hashtable();
            ht.Add("_book_number", book_number);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_book_info_listview_click_select_post", ht);

            //MySqlDataReader sdr = db.CMDReader(sql);
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }
        // 오류 수정 요망 =========================================================================//////////////////////////////////////////////////////////
        [Route("book_info_search_category_select_post")]
        [HttpPost]
        public ActionResult<ArrayList> Book_info_search_category_select_post([FromForm] string search_category,[FromForm] string search_text)
        {
            Console.WriteLine("Book_info_search_category_select_post-----");
            Console.WriteLine("search_category : " + search_category);
            Console.WriteLine("search_text : " + search_text);

            
            DataBase db = new DataBase();
            //string sql = string.Format("select * from book_info where {0} LIKE '%{1}%'", search_category, search_text);

            Hashtable ht = new Hashtable();
            ht.Add("_search_category", search_category);
            ht.Add("_search_text", search_text);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_book_info_search_category_select_post", ht);	

            //MySqlDataReader sdr = db.CMDReader(sql);
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }

        [Route("book_info_insert_book_rental_update")]
        [HttpPost]
        public ActionResult<string> Book_info_insert_book_rental_update([FromForm] string book_number, [FromForm] string user_number)
        {
            Console.WriteLine("book_info_insert_book_rental_update-----");
            Console.WriteLine("book_number : " + book_number);
            Console.WriteLine("user_number : " + user_number);
      
           
            
            DataBase db = new DataBase();
            //string sql = string.Format("INSERT INTO book_rental(book_number, user_number) VALUES({0}, {1}); update book_info set availability = '불가' where book_number = {0};", book_number, user_number);
            
            Hashtable ht = new Hashtable();
            ht.Add("_book_number", book_number);
            ht.Add("_user_number", user_number);


            if(db.HLC_NonQuery_Value("p_book_info_insert_book_rental_update", ht))
            {
                return "1";
            }
            else 
            {
                return "0";
            }
            db.Close();
        }


        [Route("book_info_bookinfo_config_update")]
        [HttpPost]
        public ActionResult<string> Book_info_bookinfo_config_update([FromForm] string book_number, [FromForm] string title, [FromForm] string author,[FromForm] string publisher,[FromForm] string genre,[FromForm] string brief_introduction,[FromForm] string book_location)
        {
            Console.WriteLine("Book_info_bookinfo_config_update-----");
            Console.WriteLine("book_number : " + book_number);
            Console.WriteLine("title : " + title);
            Console.WriteLine("author : " + author);
            Console.WriteLine("publisher : " + publisher);
            Console.WriteLine("genre : " + genre);
            Console.WriteLine("brief_introduction : " + brief_introduction);
            Console.WriteLine("book_location : " + book_location);

      
           
            
            DataBase db = new DataBase();
            string sql = string.Format("update book_info set title = '{1}', author = '{2}', publisher = '{3}', genre = '{4}', brief_introduction = '{5}', book_location = '{6}' where book_number = {0};", book_number, title, author, publisher, genre, brief_introduction, book_location);
            if(db.CMDNonQuery(sql))
            {
                return "1";
            }
            else 
            {
                return "0";
            }
            db.Close();
        }

        // book_MGT_form
        [Route("request_listview")]
        [HttpGet]
        public ActionResult<ArrayList> Request_listview()
        {
            Console.WriteLine("select : Request_listview");

            DataBase db = new DataBase();
            //string sql = "select R.request_number, S.user_number, S.name, R.title, R.author, R.publisher, R.genre from signup S inner join Receiving_equest R on (S.user_number = R.user_number);";
            
            MySqlDataReader sdr = db.HLC_Reader("p_request_listview");

            //MySqlDataReader sdr = db.CMDReader(sql);
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }

        [Route("book_mgt_request_listview_click_select_post")]
        [HttpPost]
        public ActionResult<ArrayList> Book_mgt_request_listview_click_select_post([FromForm] string request_number)
        {
            Console.WriteLine("Book_mgt_request_listview_click_select_post-----");
            Console.WriteLine("request_number : " + request_number);


            DataBase db = new DataBase();
            //string sql = string.Format("select R.request_number, S.user_number, S.name, R.title, R.author, R.publisher, R.genre from signup S inner join Receiving_equest R on (S.user_number = R.user_number and R.request_number = {0});", request_number);
            Hashtable ht = new Hashtable();
            ht.Add("_request_number", request_number);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_book_mgt_request_listview_click_select_post", ht);

            //MySqlDataReader sdr = db.CMDReader(sql);
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }

        [Route("book_mgt_register_btn")]
        [HttpPost]
        public ActionResult<string> Book_mgt_register_btn([FromForm] string title,[FromForm] string author,[FromForm] string publisher,[FromForm] string genre,[FromForm] string book_location,[FromForm] string brief_introduction,[FromForm] string image_location,[FromForm] string image_FileName)
        {
            Console.WriteLine("Book_mgt_register_btn-----");
            Console.WriteLine("title : " + title);
            Console.WriteLine("author : " + author);
            Console.WriteLine("publisher : " + publisher);
            Console.WriteLine("genre : " + genre);
            Console.WriteLine("book_location : " + book_location);
            Console.WriteLine("brief_introduction : " + brief_introduction);
            Console.WriteLine("image_location : " + image_location);
            Console.WriteLine("image_FileName : " + image_FileName);
            
            DataBase db = new DataBase();
            //string sql = string.Format("insert into book_info(title, author, publisher, genre, book_location, brief_introduction, image_location, image_FileName) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');", title, author, publisher, genre, book_location, brief_introduction, image_location, image_FileName);
             Hashtable ht = new Hashtable();
            ht.Add("_title", title);
            ht.Add("_author", author);
            ht.Add("_publisher", publisher);
            ht.Add("_genre", genre);
            ht.Add("_book_location", book_location);
            ht.Add("_brief_introduction", brief_introduction);
            ht.Add("_image_location", image_location);
            ht.Add("_image_FileName", image_FileName);
            
			//string sql = string.Format("UPDATE signup set passwod = '{0}' where user_number = {1};", passwod, user_number);
			if(db.HLC_NonQuery_Value("p_book_mgt_register_btn", ht))
			{
				return "1";
			}
			else 
			{
				return "0";
			}
            db.Close();
        }
        //=============================================================================================================
        [Route("request_list_delete")]
        [HttpPost]
        public ActionResult<string> Request_list_delete([FromForm] string request_number)
        {
            Console.WriteLine("Request_list_delete-----");
            Console.WriteLine("request_number : " + request_number);
            
            DataBase db = new DataBase();
            //string sql = string.Format("delete from Receiving_equest where request_number = {0};", request_number);
            Hashtable ht = new Hashtable();
            ht.Add("_request_number", request_number);
            
			if(db.HLC_NonQuery_Value("p_request_list_delete", ht))
			{
				return "1";
			}
			else 
			{
				return "0";
			}
            db.Close();
        }


        // DETAIL_BOOK_FORM
        [Route("book_count_api")]
        [HttpPost]
        public ActionResult<ArrayList> Book_count_api([FromForm] string book_name)
        {
            Console.WriteLine("Book_count_api-----");
            Console.WriteLine("book_name : " + book_name);


            DataBase db = new DataBase();
            //string sql = string.Format("select title, count(*) COUNT from book_info where title = '{0}';", book_name);
            //MySqlDataReader sdr = db.CMDReader(sql);
            Hashtable ht = new Hashtable();
            ht.Add("_book_name", book_name);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_book_count_api", ht);

            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }
        //====================================================================================================================================================================
        //====================================================================================================================================================================
        //====================================================================================================================================================================
        //====================================================================================================================================================================
        //====================================================================================================================================================================
        [Route("detail_book_info")]
        [HttpPost]
        public ActionResult<ArrayList> Detail_book_info([FromForm] string book_name)
        {
            Console.WriteLine("Detail_book_info-----");
            Console.WriteLine("book_name : " + book_name);


            DataBase db = new DataBase();
            //string sql = string.Format("select * from book_info where title = '{0}';", book_name);
            //MySqlDataReader sdr = db.CMDReader(sql);
            Hashtable ht = new Hashtable();
            ht.Add("_book_name", book_name);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_detail_book_info", ht);	

            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }

        // LATE_MGT_FORM
        [Route("late_mgt_listview_delay_info")]
		[HttpGet]
		public ActionResult<ArrayList> Late_mgt_listview_delay_info()
		{
			Console.WriteLine("select : Late_mgt_listview_delay_info");

			DataBase db = new DataBase();
			//string sql = "select S.user_number, S.phone_number, S.name, I.title, I.book_number, R.rental_day, TO_DAYS(now()) - TO_DAYS(R.return_schedule) 연체일 from book_info as I inner join book_rental as R on (I.book_number = R.book_number and TO_DAYS(now()) - TO_DAYS(R.return_schedule) > 0 and R.rental_status <> 2) inner join signup as S on (S.user_number = R.user_number);";
			//MySqlDataReader sdr = db.CMDReader(sql);
            MySqlDataReader sdr = db.HLC_Reader("p_late_mgt_listview_delay_info");
			ArrayList list = new ArrayList();
			while(sdr.Read())
			{
				Hashtable ht = new Hashtable();
				for (int i = 0; i < sdr.FieldCount; i++)
				{
					ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
				}
				list.Add(ht);
			}
			db.ReaderClose(sdr);
            db.Close();

			return list;
		}

        // LOGIN_FORM
        [Route("login_form_PW_Select_API")]
		[HttpPost]
		public ActionResult<string> Login_form_PW_Select_API([FromForm] string id)
		{
			Console.WriteLine("Login_form_PW_Select_API-----");
			Console.WriteLine("_id : " + id);          


			DataBase db = new DataBase();
			//string sql = string.Format("select passwod  from signup where id = '{0}';", id);
			//MySqlDataReader sdr = db.CMDReader(sql);	

            
            Hashtable ht = new Hashtable();
            ht.Add("_id", id);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_login_form_PW_Select_API", ht);	

            string p= ".";
			while (sdr.Read())
            {
                p = sdr.GetValue(0).ToString();
            }
            db.ReaderClose(sdr);
            db.Close();

            return p;
		}

        [Route("User_Number_Member_Rank_Chk_API")]
		[HttpPost]
		public ActionResult<ArrayList> User_Number_Member_Rank_Chk_API([FromForm] string id,[FromForm] string pw)
		{
			Console.WriteLine("User_Number_Member_Rank_Chk_API-----");
			Console.WriteLine("_id : " + id);  
            Console.WriteLine("_pw : " + pw); 

			DataBase db = new DataBase();
			//string sql = string.Format("select user_number, member_rank from signup where id = '{0}' && passwod = '{1}';", id, pw);
			//MySqlDataReader sdr = db.CMDReader(sql);

            Hashtable ht = new Hashtable();
            ht.Add("_id", id);
            ht.Add("_pw", pw);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_User_Number_Member_Rank_Chk_API", ht);	

			ArrayList list = new ArrayList();
			while(sdr.Read())
			{
				ht = new Hashtable();				
                ht.Add("user_Number", sdr.GetValue(0).ToString());
                ht.Add("member_rank", sdr.GetValue(1).ToString());
				
				list.Add(ht);
			}
            db.ReaderClose(sdr);
            db.Close();

            return list;
		}

        //MY_INFO_FORM
        [Route("GetUPDATE_API")]
		[HttpPost]
		public ActionResult<string> GetUPDATE_API([FromForm] string email,[FromForm] string Phon,[FromForm] string addres,[FromForm] string user_number)
		{
			Console.WriteLine("GetUPDATE_API-----");
			Console.WriteLine("_email : " + email);
			Console.WriteLine("_Phon : " + Phon);
            Console.WriteLine("_addres : " + addres);
			Console.WriteLine("_user_number : " + user_number);

		   
			
			DataBase db = new DataBase();
			//string sql = string.Format("UPDATE signup set email = '{0}',phone_number = '{1}',address = '{2}' where user_number = {3};", email, Phon, addres, user_number);
			
            Hashtable ht = new Hashtable();
            ht.Add("_email", email);
            ht.Add("_Phon", Phon);
            ht.Add("_addres", addres);
            ht.Add("_user_number", user_number);
            
			//string sql = string.Format("UPDATE signup set passwod = '{0}' where user_number = {1};", passwod, user_number);
			if(db.HLC_NonQuery_Value("p_GetUPDATE_API", ht))
			{
				return "1";
			}
			else 
			{
				return "0";
			}
            db.Close();
		}

        [Route("GetUPDATE_Pass_API")]
		[HttpPost]
		public ActionResult<string> GetUPDATE_Pass_API([FromForm] string passwod,[FromForm] string user_number)
		{
			Console.WriteLine("GetUPDATE_Pass_API-----");
			Console.WriteLine("passwod : " + passwod);
			Console.WriteLine("user_number : " + user_number);
			
			DataBase db = new DataBase();
			//string sql = string.Format("UPDATE signup set passwod = '{0}' where user_number = {1};", passwod, user_number);


			Hashtable ht = new Hashtable();
            ht.Add("_passwod", passwod);
            ht.Add("_user_number", user_number);
            
			//string sql = string.Format("UPDATE signup set passwod = '{0}' where user_number = {1};", passwod, user_number);
			if(db.HLC_NonQuery_Value("p_GetUPDATE_Pass_API", ht))
			{
				return "1";
			}
			else 
			{
				return "0";
			}
            db.Close();
		}

        [Route("user_ID_Select_API")]
		[HttpPost]
		public ActionResult<string> User_ID_Select_API([FromForm] string PWtext)
		{
			Console.WriteLine("User_ID_Select_API-----");
			Console.WriteLine("PWtext : " + PWtext);


			DataBase db = new DataBase();
			//string sql = string.Format("select id from signup where passwod = '{0}';", PWtext);
			//MySqlDataReader sdr = db.CMDReader(sql);
            Hashtable ht = new Hashtable();
            ht.Add("_PWtext", PWtext);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_user_ID_Select_API", ht);	
            
			string p = ".";
			while(sdr.Read())
			{
				p = sdr.GetValue(0).ToString();
			}
			db.ReaderClose(sdr);
            db.Close();

			return p;
		}

        [Route("signup_user_number_GetSelect_API")]
		[HttpPost]
		public ActionResult<ArrayList> Signup_user_number_GetSelect_API([FromForm] string user)
		{
			Console.WriteLine("Signup_user_number_GetSelect_API-----");
			Console.WriteLine("user : " + user);


			DataBase db = new DataBase();
			//string sql = string.Format("select * from signup where user_number = {0};", user);
			//MySqlDataReader sdr = db.CMDReader(sql);

            Hashtable ht = new Hashtable();
            ht.Add("_user", user);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_signup_user_number_GetSelect_API", ht);	

			ArrayList list = new ArrayList();
			while(sdr.Read())
			{
				ht = new Hashtable();
				for (int i = 0; i < sdr.FieldCount; i++)
				{
					ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
				}
				list.Add(ht);
			}
			db.ReaderClose(sdr);
            db.Close();

			return list;
		}

        //Passwod_Check.cs
        [Route("Passwod_Check_PW_Select_API")]
		[HttpPost]
		public ActionResult<string> Passwod_Check_PW_Select_API([FromForm] string PWtext, [FromForm] string user_number)
		{
			Console.WriteLine("Passwod_Check_PW_Select_API-----");
			Console.WriteLine("PWtext : " + PWtext);
            Console.WriteLine("user_number : " + user_number);

			DataBase db = new DataBase();
			//string sql = string.Format("select passwod from signup where passwod = '{0}' && user_number = {1};", PWtext, user_number);
			//MySqlDataReader sdr = db.CMDReader(sql);
            Hashtable ht = new Hashtable();
            ht.Add("_PWtext", PWtext);
            ht.Add("_user_number", user_number);

			MySqlDataReader sdr = db.HLC_Reader_Value("p_Passwod_Check_PW_Select_API", ht);	

			string p = ".";
			while(sdr.Read())
			{
				p = sdr.GetValue(0).ToString();
			}
			db.ReaderClose(sdr);
            db.Close();

			return p;
		}

        // RENTAL_INFO_FORM
        [Route("rental_info_form_GetSelect")]
		[HttpPost]
		public ActionResult<ArrayList> Rental_info_form_GetSelect([FromForm] string user_number)
		{
			Console.WriteLine("Rental_info_form_GetSelect-----");
			Console.WriteLine("user_number : " + user_number);


			DataBase db = new DataBase();
			//string sql = string.Format("select R.rental_number 대여번호,	I.title 도서명, I.author 저자, I.publisher 출판사, R.rental_day 대여일, R.return_schedule 반납일, case when TO_DAYS(now()) - TO_DAYS(return_schedule) > 0 then '연체됨' when TO_DAYS(now()) - TO_DAYS(return_schedule) <= 0 then '연체안됨' else '' end 연체일, case when R.rental_status = 0 then '대여중' when R.rental_status = 1 then '반납요망' else '' end 상태 from	book_info as I inner join book_rental as R on (I.book_number = R.book_number) WHERE R.user_number = _user_number && (R.rental_status = 1 || R.rental_status = 0);", user_number);
			//MySqlDataReader sdr = db.CMDReader(sql);

            Hashtable ht = new Hashtable();
            ht.Add("_user_number", user_number);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_rental_info_form_GetSelect", ht);	

			ArrayList list = new ArrayList();
			while(sdr.Read())
			{
				ht = new Hashtable();
				for (int i = 0; i < sdr.FieldCount; i++)
				{
					ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
				}
				list.Add(ht);
			}
			db.ReaderClose(sdr);
            db.Close();

			return list;
		}

        [Route("rental_info_book_rental_update")]
		[HttpPost]
		public ActionResult<string> Rental_info_book_rental_update([FromForm] string no)
		{
			Console.WriteLine("Rental_info_book_rental_update-----");
			Console.WriteLine("no : " + no);   
			
			DataBase db = new DataBase();
			//string sql = string.Format("update book_rental set rental_status = 2 WHERE rental_number = {0};", no );
            Hashtable ht = new Hashtable();
            ht.Add("_no", no);
			if(db.HLC_NonQuery_Value("p_rental_info_book_rental_update", ht))
			{
				return "1";
			}
			else 
			{
				return "0";
			}
            db.Close();
		}

        [Route("rental_info_book_info_update")]
		[HttpPost]
		public ActionResult<string> Rental_info_book_info_update([FromForm] string no)
		{
			Console.WriteLine("Rental_info_book_info_update-----");
			Console.WriteLine("no : " + no);   
			
			DataBase db = new DataBase();
			//string sql = string.Format("update book_info set availability = '가능' where book_number in (select book_number from book_rental where rental_number = {0} and rental_status = 2);", no);
			
            Hashtable ht = new Hashtable();
            ht.Add("_no", no);

            if(db.HLC_NonQuery_Value("p_rental_info_book_info_update", ht))
			{
				return "1";
			}
			else 
			{
				return "0";
			}
            db.Close();
		}


        //REQUEST_BOOK_FORM
        [Route("request_book_form_request_register")]
		[HttpPost]
		public ActionResult<string> Request_book_form_request_register([FromForm] string title,[FromForm] string author,[FromForm] string publisher,[FromForm] string genre,[FromForm] string user_number)
		{
			Console.WriteLine("Request_book_form_request_register-----");
			Console.WriteLine("title : " + title);
			Console.WriteLine("author : " + author);
            Console.WriteLine("publisher : " + publisher);
            Console.WriteLine("genre : " + genre);
            Console.WriteLine("user_number : " + user_number);		   
			
			DataBase db = new DataBase();
			//string sql = string.Format("insert into Receiving_equest(title, author, publisher, genre, user_number) values('{0}', '{1}', '{2}', '{3}', {4});", title, author, publisher, genre, user_number);
			
            Hashtable ht = new Hashtable();
            
            ht.Add("_title", title);
            ht.Add("_author", author);
            ht.Add("_publisher", publisher);
            ht.Add("_genre", genre);
            ht.Add("_user_number", user_number);
            
			//string sql = string.Format("UPDATE signup set passwod = '{0}' where user_number = {1};", passwod, user_number);
			if(db.HLC_NonQuery_Value("p_request_book_form_request_register", ht))
			{
				return "1";
			}
			else 
			{
				return "0";
			}
            db.Close();
		}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////                        ///////////////////                              //////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////       ////////         ///////////////////            ////////          ///////////////////////////////////////
////////////////////////////////////////////////////////////////////////////                        ///////////////////                              ////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////         /////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////    ////    ////    ////    ////    ////   ////  ///  ///   ////   ///////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //SIGNUP_FORM.cs
         //SIGNUP_FORM.cs
        [Route("signup_form_GetInsert")]
      [HttpPost]
      public ActionResult<string> Signup_form_GetInsert([FromForm] string ID,[FromForm] string Pass,[FromForm] string Name,[FromForm] string Gender,[FromForm] string Birth,[FromForm] string email,[FromForm] string Phon,[FromForm] string addres)
      {
         Console.WriteLine("signup_form_GetInsert-----");
         Console.WriteLine("ID", ID);
            Console.WriteLine("Pass", Pass);
            Console.WriteLine("Name", Name);
            Console.WriteLine("Gender", Gender);
            Console.WriteLine("Birth", Birth);
            Console.WriteLine("email", email);
            Console.WriteLine("Phon", Phon);
            Console.WriteLine("addres", addres);         
         
         DataBase db = new DataBase();
         //string sql = string.Format("INSERT INTO signup(id,passwod,name,gender,birthday,email,phone_number,address) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", ID, Pass, Name, Gender, Birth, email, Phon, addres);
            Hashtable ht = new Hashtable();
            ht.Add("_ID", ID);
         ht.Add("_Pass", Pass);
         ht.Add("_Name", Name);
         ht.Add("_Gender", Gender);
         ht.Add("_Birth", Birth);
         ht.Add("_email", email);
         ht.Add("_Phon", Phon);
         ht.Add("_addres", addres);
         if(db.HLC_NonQuery_Value("p_signup_form_GetInsert", ht))
         {
            return "1";
         }
         else 
         {
            return "0";
         }
            db.Close();
      }

        //USER_INFO_FORM.cs
        [Route("user_info_form_user_signup")]
      [HttpPost]
      public ActionResult<ArrayList> User_info_form_user_signup([FromForm] string user_number)
      {
         Console.WriteLine("User_info_form_user_signup-----");
         Console.WriteLine("user_number : " + user_number);

         DataBase db = new DataBase();
         //string sql = string.Format("select * from signup where user_number = {0}", user_number);
         Hashtable ht = new Hashtable();
            ht.Add("_user_number", user_number);
         MySqlDataReader sdr = db.HLC_Reader_Value("p_user_info_form_user_signup", ht);   
         ArrayList list = new ArrayList();
         while(sdr.Read())
         {
            ht = new Hashtable();
            for (int i = 0; i < sdr.FieldCount; i++)
            {
               ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
            }
            list.Add(ht);
         }
         db.ReaderClose(sdr);
            db.Close();

         return list;
      }

        [Route("user_info_form_user_rental_info")]
      [HttpPost]
      public ActionResult<ArrayList> User_info_form_user_rental_info([FromForm] string user_number)
      {
         Console.WriteLine("User_info_form_user_rental_info-----");
         Console.WriteLine("user_number : " + user_number);
            
         DataBase db = new DataBase();
         //string sql = string.Format("select   I.book_number, I.title, I.author, I.publisher, case when R.rental_status = 0 then '대여중' when R.rental_status = 1 then '미반납' end as 'rental_status' from   book_info I inner join   book_rental  R on (R.user_number = {0} and I.book_number = R.book_number and R.rental_status <> 2);", user_number);
         Hashtable ht = new Hashtable();
            ht.Add("_user_number", user_number);
         MySqlDataReader sdr = db.HLC_Reader_Value("p_user_info_form_user_rental_info", ht);   
         ArrayList list = new ArrayList();
         while(sdr.Read())
         {
            ht = new Hashtable();
            for (int i = 0; i < sdr.FieldCount; i++)
            {
               ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
            }
            list.Add(ht);
         }
         db.ReaderClose(sdr);
            db.Close();

         return list;
      }

        [Route("user_info_form_user_info_search")]
      [HttpPost]
      public ActionResult<ArrayList> User_info_form_user_info_search([FromForm] string search_category, [FromForm] string textbox_search)
      {
         Console.WriteLine("User_info_form_user_info_search-----");
         Console.WriteLine("search_category : " + search_category);
            Console.WriteLine("textbox_search : " + textbox_search);
            
         DataBase db = new DataBase();
         //string sql = string.Format("select * from signup where {0} LIKE '%{1}%'", search_category, textbox_search);
         Hashtable ht = new Hashtable();
            ht.Add("_search_category", search_category);
            ht.Add("_textbox_search", textbox_search);
         MySqlDataReader sdr = db.HLC_Reader_Value("p_user_info_form_user_info_search", ht);   
         ArrayList list = new ArrayList();
         while(sdr.Read())
         {
            ht = new Hashtable();
            for (int i = 0; i < sdr.FieldCount; i++)
            {
               ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
            }
            list.Add(ht);
         }
         db.ReaderClose(sdr);
            db.Close();

         return list;
      }

      [Route("Select_signup_info_Webapi")]
        [HttpGet]
        public ActionResult<ArrayList> Select_signup_info_Webapi()
        {
            Console.WriteLine("Select_signup_info_Webapi--------------");

            DataBase db = new DataBase();           
            
            MySqlDataReader sdr = db.HLC_Reader("p_Select_signup_info_Webapi");
            ArrayList list = new ArrayList();
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                }
                list.Add(ht);
            }
            db.ReaderClose(sdr);
            db.Close();

            return list;
        }

        [Route("user_blackList_select_post")]
      [HttpPost]
      public ActionResult<ArrayList> user_blackList_select_post([FromForm] string user_number)
		{
			Console.WriteLine("user_blackList_select_post-----");
			Console.WriteLine("user_number : " + user_number);


			DataBase db = new DataBase();
			//string sql = string.Format("select R.rental_number 대여번호,	I.title 도서명, I.author 저자, I.publisher 출판사, R.rental_day 대여일, R.return_schedule 반납일, case when TO_DAYS(now()) - TO_DAYS(return_schedule) > 0 then '연체됨' when TO_DAYS(now()) - TO_DAYS(return_schedule) <= 0 then '연체안됨' else '' end 연체일, case when R.rental_status = 0 then '대여중' when R.rental_status = 1 then '반납요망' else '' end 상태 from	book_info as I inner join book_rental as R on (I.book_number = R.book_number) WHERE R.user_number = _user_number && (R.rental_status = 1 || R.rental_status = 0);", user_number);
			//MySqlDataReader sdr = db.CMDReader(sql);

            Hashtable ht = new Hashtable();
            ht.Add("_user_number", user_number);
			MySqlDataReader sdr = db.HLC_Reader_Value("p_user_blackList_select_post", ht);	

			ArrayList list = new ArrayList();
			while(sdr.Read())
			{
				ht = new Hashtable();
				for (int i = 0; i < sdr.FieldCount; i++)
				{
					ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
                    Console.WriteLine(sdr.GetName(i).ToString());
                    Console.WriteLine(sdr.GetValue(i).ToString());
				}
				list.Add(ht);
			}
			db.ReaderClose(sdr);
            db.Close();

			return list;
		}


        //USER_LEVEL_UPDATE_FORM
        [Route("user_level_update_form_user_number_signup_info")]
      [HttpPost]
      public ActionResult<ArrayList> User_level_update_form_user_number_signup_info([FromForm] string user_number)
      {
         Console.WriteLine("User_level_update_form_user_number_signup_info-----");
         Console.WriteLine("user_number : " + user_number);
         
         DataBase db = new DataBase();
         //string sql = string.Format("select * from signup where user_number = {0}", user_number);
          Hashtable ht = new Hashtable();
            ht.Add("_user_number", user_number);
         MySqlDataReader sdr = db.HLC_Reader_Value("p_user_level_update_form_user_number_signup_info", ht);   
         ArrayList list = new ArrayList();
         while(sdr.Read())
         {
            ht = new Hashtable();
            for (int i = 0; i < sdr.FieldCount; i++)
            {
               ht.Add(sdr.GetName(i).ToString(), sdr.GetValue(i).ToString());
            }
            list.Add(ht);
         }
         db.ReaderClose(sdr);
            db.Close();

         return list;
      }

      [Route("user_level_update_form_signup_blacklist_Y_set")]
      [HttpPost]
      public ActionResult<string> User_level_update_form_signup_blacklist_Y_set([FromForm] string user_number)
      {
         Console.WriteLine("User_level_update_form_signup_blacklist_Y_set-----");
         Console.WriteLine("user_number : " + user_number);
         
         DataBase db = new DataBase();
         //string sql = string.Format("select * from signup where user_number = {0}", user_number);
         Hashtable ht = new Hashtable();
         ht.Add("_user_number", user_number);
         
          if(db.HLC_NonQuery_Value("p_user_level_update_form_signup_blacklist_Y_set", ht))
         {
            return "1";
         }
         else 
         {
            return "0";
         }
            db.Close();

      }

      [Route("user_level_update_form_signup_blacklist_N_set")]
      [HttpPost]
      public ActionResult<string> User_level_update_form_signup_blacklist_N_set([FromForm] string user_number)
      {
         Console.WriteLine("User_level_update_form_signup_blacklist_N_set-----");
         Console.WriteLine("user_number : " + user_number);
         
         DataBase db = new DataBase();
         //string sql = string.Format("select * from signup where user_number = {0}", user_number);
          Hashtable ht = new Hashtable();
            ht.Add("_user_number", user_number);

          if(db.HLC_NonQuery_Value("p_user_level_update_form_signup_blacklist_N_set", ht))
         {
            return "1";
         }
         else 
         {
            return "0";
         }
            db.Close();
      }

        [Route("user_level_update_form_signup_member_rank_0_set")]
      [HttpPost]
      public ActionResult<string> User_level_update_form_signup_member_rank_0_set([FromForm] string user_number)
      {
         Console.WriteLine("User_level_update_form_signup_member_rank_0_set-----");
         Console.WriteLine("user_number : " + user_number);         
         
         DataBase db = new DataBase();
            Hashtable ht = new Hashtable();
            ht.Add("_user_number", user_number);
         //string sql = string.Format("update signup set member_rank = 0 where user_number = {0};", user_number);
         if(db.HLC_NonQuery_Value("p_user_level_update_form_signup_member_rank_0_set", ht))
         {
            return "1";
         }
         else 
         {
            return "0";
         }
            db.Close();
      }

        [Route("user_level_update_form_signup_member_rank_1_set")]
      [HttpPost]
      public ActionResult<string> User_level_update_form_signup_member_rank_1_set([FromForm] string user_number)
      {
         Console.WriteLine("User_level_update_form_signup_member_rank_1_set-----");
         Console.WriteLine("user_number : " + user_number);         
         
         DataBase db = new DataBase();
            Hashtable ht = new Hashtable();
            ht.Add("_user_number", user_number);
         //string sql = string.Format("update signup set member_rank = 1 where user_number = {0};", user_number);
         if(db.HLC_NonQuery_Value("p_user_level_update_form_signup_member_rank_1_set", ht))
         {
            return "1";
         }
         else 
         {
            return "0";
         }
            db.Close();
      }

        //COMMON_Create_Ctl.cs
        [Route("common_create_ctl_delay_rental_check")]
      [HttpPost]
      public ActionResult<string> Common_create_ctl_delay_rental_check([FromForm] string rental_status)
      {
         Console.WriteLine("Common_create_ctl_delay_rental_check-----");
         Console.WriteLine("rental_status : " + rental_status);   
         
         DataBase db = new DataBase();

            Hashtable ht = new Hashtable();
            ht.Add("_rental_status", rental_status);

         //string sql = string.Format("update book_rental set rental_status = {0} where rental_number in (select rental_number from book_rental where (TO_DAYS(now()) - TO_DAYS(return_schedule)) > 0 and rental_status <> 2);", rental_status);
         if(db.HLC_NonQuery_Value("p_common_create_ctl_delay_rental_check", ht))
         {
            return "1";
         }
         else 
         {
            return "0";
         }
            db.Close();
      }

      

        
        ////////////////////////////////////////////////////////

        // [Route("select")]
        // [HttpGet]
        // public ActionResult<ArrayList> Select()
        // {
        //     Console.WriteLine("Select");

        //     DataBase db = new DataBase();
        //     MySqlDataReader sdr = db.Reader("sp_select");
        //     ArrayList list = new ArrayList();
        //     while(sdr.Read())
        //     {
        //         string[] arr = new string[6];
        //         for (int i = 0; i < sdr.FieldCount; i++)
        //         {
        //             arr[i] = sdr.GetValue(i).ToString();
        //         }
        //         list.Add(arr);
        //     }
        //     db.ReaderClose(sdr);
        //     db.Close();

        //     return list;
        // }

        // [Route("insert")]
        // [HttpPost]
        // public ActionResult<string> Insert([FromForm] string name, [FromForm] string age)
        // {
        //     string param = string.Format("{0}, {1}", name, age);
        //     Console.WriteLine("Insert : " + param);
        //     Hashtable ht = new Hashtable();
        //     ht.Add("@name", name);
        //     ht.Add("@age", age);
        //     DataBase db = new DataBase();
        //     if(db.NonQuery("sp_insert", ht))
        //     {
        //         return "1";
        //     }
        //     else 
        //     {
        //         return "0";
        //     }
        //     db.Close();
        // }

        // [Route("update")]
        // [HttpPost]
        // public ActionResult<string> Update([FromForm] string no,[FromForm] string name, [FromForm] string age)
        // {
        //     string param = string.Format("{0}, {1}, {2}", no, name, age);
        //     Console.WriteLine("Update : " + param);
        //     Hashtable ht = new Hashtable();
        //     ht.Add("@no", no);
        //     ht.Add("@name", name);
        //     ht.Add("@age", age);
        //     DataBase db = new DataBase();
        //     if(db.NonQuery("sp_update", ht))
        //     {
        //         return "1";
        //     }
        //     else 
        //     {
        //         return "0";
        //     }
        //     db.Close();
        // }

        // [Route("delete")]
        // [HttpPost]
        // public ActionResult<string> Delete([FromForm] string no)
        // {
        //     string param = string.Format("{0}", no);
        //     Console.WriteLine("Delete : " + param);
        //     Hashtable ht = new Hashtable();
        //     ht.Add("@no", no);
        //     DataBase db = new DataBase();
        //     if(db.NonQuery("sp_delete", ht))
        //     {
        //         return "1";
        //     }
        //     else 
        //     {
        //         return "0";
        //     }
        //     db.Close();
        // }
    
        [Route("imageUpload")]
        [HttpPost]
        public ActionResult<string> ImageUpload([FromForm] string fileName, [FromForm] string fileData)
        {
            //Console.WriteLine("fileName : {0}", fileName);
            //Console.WriteLine("fileData : {0}", fileData);

            //string path = "C:\\public\\Images";
            string path = System.IO.Directory.GetCurrentDirectory();
            string url="";
            path += "\\wwwroot";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            
            byte[] data = Convert.FromBase64String(fileData);
            try
            {
                string ext = fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));
                Guid saveName = Guid.NewGuid();
                string fullName = saveName + ext;                            // 저장되는 파일명 만들
                string fullPath = string.Format("{0}\\{1}", path, fullName); // 전체 경로 + 저장파일명 (주소)
                FileInfo fi = new FileInfo(fullPath);
                FileStream fs = fi.Create();
                fs.Write(data, 0, data.Length);
                Console.WriteLine("파일 저장 완료");
                fs.Close();

                url = string.Format("http://ljh5432.iptime.org:5000/{0}", fullName);

                // Hashtable ht = new Hashtable();
                // ht.Add("@fName", fileName);
                // ht.Add("@fUrl", url);
                // ht.Add("@fDesc", "");
                // DataBase db = new DataBase();
                // if(db.NonQuery("sp_file_insert", ht))
                // {
                //     return url;
                // }
                // else 
                // {
                //     return "0";
                // }
            }
            catch
            {
                Console.WriteLine("파일 저장 중 오류 발생");
            }
            
            return url;
        }
    }
}