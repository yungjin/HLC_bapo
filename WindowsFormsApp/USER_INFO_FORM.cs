using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp
{
    public partial class USER_INFO_FORM : Form
    {
        string webapiUrl;

        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        COMMON_Create_Ctl comm = new COMMON_Create_Ctl();

        private OpenFileDialog openFileDialog1 = new OpenFileDialog();  // openFileDialog1 변수 선언 및 초기화
        public static string _Slected_File_RootPath;
        TextBox 회원번호값;
        TextBox 연락처값;
        TextBox 이름값;
        TextBox ID값;
        TextBox 블랙리스트값;
        string search_category = "";
        TextBox 회원정보검색상자;
        ListView 회원정보검색_리스트뷰;
        ListView 대여목록_리스트뷰;
        int rental_book_number = 0;
        int listview_user_number;
        ClassLibrary1.MySql mysql;
        string sql;

        public USER_INFO_FORM()
        {
            InitializeComponent();

            Load += USER_INFO_FORM_Load;
        }

        private void USER_INFO_FORM_Load(object sender, EventArgs e)
        {
            webapiUrl = comm.WebapiUrl;

            this.Paint += new PaintEventHandler(this.Form_Paint);


            FormBorderStyle = FormBorderStyle.None; //폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(201, 253, 223);

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            //Point_Print();

            COMMON_Create_Ctl create_ctl = new COMMON_Create_Ctl();

            create_ctl.delay_rental_check();

            // 회원정보패널
            PANELclass 회원정보패널값 = new PANELclass(this, "회원정보패널", "회원정보패널", 700, 320, 20, 20);
            Panel 회원정보패널 = comm.panel(회원정보패널값);

            회원정보패널.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 회원정보패널.Width, 회원정보패널.Height, 15, 15));
            회원정보패널.BackColor = Color.FromArgb(218, 234, 244);  // rgb(218,234,244)
            Controls.Add(회원정보패널);


            // 회원정보패널 고정라벨
            ArrayList arry = new ArrayList();
            arry.Add(new LBclass(this, "회원번호", "회원번호", 17, 110, 30, 20, 30, label_Click));
            arry.Add(new LBclass(this, "연락처", "연락처", 17, 110, 30, 20, 80, label_Click));
            arry.Add(new LBclass(this, "이름", "이름", 17, 110, 30, 20, 130, label_Click));
            arry.Add(new LBclass(this, "ID", "ID", 17, 110, 30, 20, 180, label_Click));
            arry.Add(new LBclass(this, "블랙리스트여부", "블랙리스트 여부", 17, 190, 40, 20, 230, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 30, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 80, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 130, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 180, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 230, label_Click));

            for (int i = 0; i < arry.Count; i++)
            {
                Label label = comm.lb((LBclass)arry[i]);

                label.Font = new Font(label.Font.Name, 17, FontStyle.Bold);


                회원정보패널.Controls.Add(label);
            }

            // 회원정보TextBox 변동값
            ArrayList userinfoArry = new ArrayList();
            userinfoArry.Add(new TXTBOXclass(this, "회원번호값", "회원번호값", 430, 40, 240, 30, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "연락처값", "연락처값", 430, 40, 240, 80, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "이름값", "이름값", 430, 40, 240, 130, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "ID값", "ID값", 430, 40, 240, 180, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "블랙리스트값", "블랙리스트값", 430, 40, 240, 230, txtbox_Click));

            for (int i = 0; i < userinfoArry.Count; i++)
            {
                TextBox textBox = comm.txtbox((TXTBOXclass)userinfoArry[i]);
                textBox.ReadOnly = true;
                textBox.Font = new Font(textBox.Font.Name, 12, FontStyle.Bold);

                if (textBox.Name == "회원번호값")
                {
                    회원번호값 = textBox;
                }
                else if (textBox.Name == "연락처값")
                {
                    연락처값 = textBox;
                }
                else if (textBox.Name == "이름값")
                {
                    이름값 = textBox;
                }
                else if (textBox.Name == "ID값")
                {
                    ID값 = textBox;
                }
                else if (textBox.Name == "블랙리스트값")
                {
                    블랙리스트값 = textBox;
                }

                회원정보패널.Controls.Add(textBox);
            }


            //700, 300, 20, 20

            /// 버튼 - 회원정보 변경버튼
            BTNclass 버튼등급수정값 = new BTNclass(this, "버튼등급수정", "회원 등급 수정", 460, 35, 120, 270, btn_Click);
            Button 버튼등급수정 = comm.btn(버튼등급수정값);
            버튼등급수정.BackColor = Color.FromArgb(50, 178, 223);
            버튼등급수정.Font = new Font(버튼등급수정.Font.Name, 12, FontStyle.Bold);
            버튼등급수정.FlatStyle = FlatStyle.Flat;
            버튼등급수정.ForeColor = Color.White;
            버튼등급수정.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼등급수정.Width, 버튼등급수정.Height, 10, 10));
            회원정보패널.Controls.Add(버튼등급수정);

            /// 버튼 - 회원정보 변경버튼
            BTNclass 도서반납버튼값 = new BTNclass(this, "도서반납버튼", "도서 반납", 130, 40, 590, 360, btn_Click);
            Button 도서반납버튼 = comm.btn(도서반납버튼값);
            도서반납버튼.BackColor = Color.FromArgb(50, 178, 223);
            도서반납버튼.Font = new Font(도서반납버튼.Font.Name, 12, FontStyle.Bold);
            도서반납버튼.FlatStyle = FlatStyle.Flat;
            도서반납버튼.ForeColor = Color.White;
            도서반납버튼.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 도서반납버튼.Width, 도서반납버튼.Height, 10, 10));
            Controls.Add(도서반납버튼);


            /// 라벨 - 대여목록  
            LBclass 대여목록라벨값 = new LBclass(this, "대여목록", "대여 목록", 20, 200, 30, 20, 365, label_Click);
            Label 대여목록라벨 = comm.lb(대여목록라벨값);
            대여목록라벨.Font = new Font(대여목록라벨.Font.Name, 20, FontStyle.Bold);
            Controls.Add(대여목록라벨);


            // 리스트뷰 - 대여목록
            LISTVIEWclass 대여목록_리스트뷰값 = new LISTVIEWclass(this, "대여목록_ListVIew", 700, 350, 20, 407, listView_MouseClick, listview_mousedoubleclick, 6, "", 0, "대여No", 70, "책 이름", 260, "저자", 120, "출판사", 120, "대여현황", 125);
            대여목록_리스트뷰 = comm.listView(대여목록_리스트뷰값);
            대여목록_리스트뷰.Font = new Font("Arial", 14, FontStyle.Bold);
            // 처음은 내용 없음으로 빈칸 출력.
            Controls.Add(대여목록_리스트뷰);

            //  회원정보검색 - 라벨
            LBclass 회원정보검색값 = new LBclass(this, "회원정보검색", "회원정보검색 :", 20, 200, 40, 790, 95, label_Click);
            Label 회원정보검색 = comm.lb(회원정보검색값);
            회원정보검색.Font = new Font(회원정보검색.Font.Name, 20, FontStyle.Bold);
            Controls.Add(회원정보검색);

            // 회원정보검색 - 콤보박스
            COMBOBOXclass 검색카테고리값 = new COMBOBOXclass(this, "ComboBox1", 90, 120, 990, 90, ComboBox_SelectedIndexChanged, 2, "이름", "ID");
            ComboBox 콤보박스검색카테고리 = comm.comboBox(검색카테고리값);
            콤보박스검색카테고리.Font = new Font(콤보박스검색카테고리.Font.Name, 22, FontStyle.Regular);
            콤보박스검색카테고리.DropDownStyle = ComboBoxStyle.DropDownList;
            콤보박스검색카테고리.SelectedIndex = 0;
            Controls.Add(콤보박스검색카테고리);


            // 회원정보검색 검색박스상자 - TextBOX
            TXTBOXclass 회원정보검색상자값 = new TXTBOXclass(this, "회원정보검색상자", "", 250, 150, 1080, 90, txtbox_Click);
            회원정보검색상자 = comm.txtbox(회원정보검색상자값);
            회원정보검색상자.Font = new Font(회원정보검색상자.Font.Name, 20, FontStyle.Bold);
            Controls.Add(회원정보검색상자); // 수정중

            // 회원정보검색 - 버튼
            BTNclass 검색버튼값 = new BTNclass(this, "검색버튼", "검색", 100, 40, 1330, 89, btn_Click);
            Button 버튼검색 = comm.btn(검색버튼값);
            버튼검색.BackColor = Color.FromArgb(50, 178, 223);
            버튼검색.Font = new Font(버튼검색.Font.Name, 17, FontStyle.Bold);
            버튼검색.FlatStyle = FlatStyle.Flat;
            버튼검색.ForeColor = Color.White;
            //버튼검색.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼검색.Width, 버튼검색.Height, 18, 18));
            Controls.Add(버튼검색);


            // 리스트뷰 - 회원정보검색
            LISTVIEWclass 회원정보검색_리스트뷰값 = new LISTVIEWclass(this, "회원정보검색_ListVIew", 645, 575, 800, 182, listView_MouseClick, listview_mousedoubleclick, 5, "", 0, "회원번호", 120, "회원이름", 120, "주민번호 앞자리", 200, "ID", 200);
            회원정보검색_리스트뷰 = comm.listView(회원정보검색_리스트뷰값);
            회원정보검색_리스트뷰.Font = new Font("Arial", 14, FontStyle.Bold);

            ArrayList signupinfoSearch_arry = Select_signup_info_Webapi();
            foreach (Hashtable ht in signupinfoSearch_arry)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["user_number"].ToString());
                item.SubItems.Add(ht["name"].ToString());
                item.SubItems.Add(ht["birthday"].ToString().Substring(0, 10));
                item.SubItems.Add(ht["id"].ToString());
                item.Font = new Font("Arial", 14, FontStyle.Italic);
                회원정보검색_리스트뷰.Items.Add(item);
            }
            Controls.Add(회원정보검색_리스트뷰);
        }

        public ArrayList Select_signup_info_Webapi()
        {
            WebClient client = new WebClient();
            //NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;    //한글처리

            string url = "http://" + webapiUrl + "/Select_signup_info_Webapi";
            Stream result = client.OpenRead(url);

            StreamReader sr = new StreamReader(result);
            string str = sr.ReadToEnd();

            ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(str);
            ArrayList list = new ArrayList();
            foreach (JObject row in jList)
            {
                Hashtable ht = new Hashtable();
                foreach (JProperty col in row.Properties())
                {
                    ht.Add(col.Name, col.Value);
                }
                list.Add(ht);
            }

            return list;
        }

        public void User_Info_ReFresh()
        {
            회원정보검색_리스트뷰.Items.Clear();

            ArrayList signupinfoSearch_arry = Select_signup_info_Webapi();
            foreach (Hashtable ht in signupinfoSearch_arry)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["user_number"].ToString());
                item.SubItems.Add(ht["name"].ToString());
                item.SubItems.Add(ht["birthday"].ToString().Substring(0, 10));
                item.SubItems.Add(ht["id"].ToString());
                item.Font = new Font("Arial", 14, FontStyle.Italic);
                회원정보검색_리스트뷰.Items.Add(item);
            }
            Controls.Add(회원정보검색_리스트뷰);
        }

        public ArrayList user_info_form_user_signup(string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/user_info_form_user_signup";
            string method = "POST";

            data.Add("user_number", user_number);

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(strResult);
            ArrayList list = new ArrayList();
            foreach (JObject row in jList)
            {
                Hashtable ht = new Hashtable();
                foreach (JProperty col in row.Properties())
                {
                    ht.Add(col.Name, col.Value);
                }
                list.Add(ht);
            }

            return list;
        }

        public ArrayList user_info_form_user_rental_info(string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/user_info_form_user_rental_info";
            string method = "POST";

            data.Add("user_number", user_number);

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(strResult);
            ArrayList list = new ArrayList();
            foreach (JObject row in jList)
            {
                Hashtable ht = new Hashtable();
                foreach (JProperty col in row.Properties())
                {
                    ht.Add(col.Name, col.Value);
                }
                list.Add(ht);
            }

            return list;
        }

        public ArrayList user_info_form_user_info_search(string search_category, string textbox_search)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/user_info_form_user_info_search";
            string method = "POST";

            data.Add("search_category", search_category);
            data.Add("textbox_search", textbox_search);

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(strResult);
            ArrayList list = new ArrayList();
            foreach (JObject row in jList)
            {
                Hashtable ht = new Hashtable();
                foreach (JProperty col in row.Properties())
                {
                    ht.Add(col.Name, col.Value);
                }
                list.Add(ht);
            }

            return list;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary> 아래는 이벤트 처리 부분
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //////////////////////////////////////////////////////////////////////////////////////////////// 

        private void listview_mousedoubleclick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("동작확인 : listview_mousedoubleclick");
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("동작확인 : listView_MouseClick");

            ListView listView = (ListView)sender;

            int index;
            index = 회원정보검색_리스트뷰.FocusedItem.Index;  // 선택돈 아이템 인덱스 번호 얻기
            listview_user_number = Convert.ToInt32(회원정보검색_리스트뷰.Items[index].SubItems[1].Text); // 인덱스 번호의 n번째 아이템 얻기


            ArrayList bookinfoSearch_arry = user_info_form_user_signup(listview_user_number.ToString());
            foreach (Hashtable ht in bookinfoSearch_arry)
            {
                회원번호값.Text = ht["user_number"].ToString();
                연락처값.Text = ht["phone_number"].ToString();
                이름값.Text = ht["name"].ToString();
                ID값.Text = ht["id"].ToString();
                블랙리스트값.Text = ht["blacklist"].ToString();
            }


            if(listView.Name != "대여목록_ListVIew")
            {
                대여목록_리스트뷰.Items.Clear();

                ArrayList bookinfoSearch_arry2 = user_info_form_user_rental_info(listview_user_number.ToString());
                foreach (Hashtable ht in bookinfoSearch_arry2)
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(ht["rental_number"].ToString());
                    item.SubItems.Add(ht["title"].ToString());
                    item.SubItems.Add(ht["author"].ToString());
                    item.SubItems.Add(ht["publisher"].ToString());
                    item.SubItems.Add(ht["rental_status"].ToString());
                    item.Font = new Font("Arial", 14, FontStyle.Italic);
                    대여목록_리스트뷰.Items.Add(item);
                }
            }
            else if (listView.Name == "대여목록_ListVIew")
            {
                int rental_index;
                rental_index = 대여목록_리스트뷰.FocusedItem.Index;  // 선택돈 아이템 인덱스 번호 얻기
                rental_book_number = Convert.ToInt32(대여목록_리스트뷰.Items[rental_index].SubItems[1].Text); // 인덱스 번호의 n번째 아이템 얻기                
            }


            
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            search_category = (string)combo.SelectedItem;

            //MessageBox.Show(search_category);

            if (search_category == "이름")
            {
                search_category = "name";
            }
            else if (search_category == "ID")
            {
                search_category = "id";
            }

        }

        private void btn_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");

            Button button = (Button)o;

            if (button.Name == "검색버튼")
            {
                회원정보검색_리스트뷰.Items.Clear();

                if(회원정보검색상자.Text == "")
                {
                    MessageBox.Show("검색란에 입력을 확인해주세요.");
                    return;
                }

                ArrayList userinfoSearch_arry = user_info_form_user_info_search(search_category, 회원정보검색상자.Text);

                foreach (Hashtable ht in userinfoSearch_arry)
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(ht["user_number"].ToString());
                    item.SubItems.Add(ht["name"].ToString());
                    item.SubItems.Add(ht["birthday"].ToString().Substring(0, 10));
                    item.SubItems.Add(ht["id"].ToString());
                    item.Font = new Font("Arial", 14, FontStyle.Italic);
                    회원정보검색_리스트뷰.Items.Add(item);
                }

                Controls.Add(회원정보검색_리스트뷰);
            }
            else if (button.Name == "버튼등급수정")
            {
                if (회원번호값.Text == "회원번호값")
                {
                    fail fail = new fail("회원정보를 선택해주세요");
                    fail.ShowDialog();
                    return;
                }
                USER_LEVEL_UPDATE_FORM user_level_update_form = new USER_LEVEL_UPDATE_FORM(회원번호값.Text);
                user_level_update_form.StartPosition = FormStartPosition.CenterParent;
                user_level_update_form.ShowDialog();
            }
            else if(button.Name == "도서반납버튼")
            {
                if(rental_book_number == 0)
                {
                    fail fail = new fail("회원, 반납 할 도서를 선택해주세요.");
                    fail.ShowDialog();
                    return;
                }
                Book_Return_GetUpdate(rental_book_number.ToString());

            }


        }

        public void Book_Return_GetUpdate(string no)
        {

            bool status = rental_info_book_rental_update(no);

            if (status)
            {

                if (rental_info_book_info_update(no))
                {
                    fail fail = new fail("반납 되었습니다.");
                    fail.ShowDialog();
                    대여목록_리스트뷰.Items.Clear();

                    ArrayList bookinfoSearch_arry2 = user_info_form_user_rental_info(listview_user_number.ToString());
                    foreach (Hashtable ht in bookinfoSearch_arry2)
                    {
                        ListViewItem item = new ListViewItem("");
                        item.SubItems.Add(ht["rental_number"].ToString());
                        item.SubItems.Add(ht["title"].ToString());
                        item.SubItems.Add(ht["author"].ToString());
                        item.SubItems.Add(ht["publisher"].ToString());
                        item.SubItems.Add(ht["rental_status"].ToString());
                        item.Font = new Font("Arial", 14, FontStyle.Italic);
                        대여목록_리스트뷰.Items.Add(item);
                    }
                }
                else
                {
                    fail fail = new fail("대여상태 가능 업데이트 중 오류 발생.");
                    fail.ShowDialog();
                }
            }
            else
            {
                
                fail fail = new fail("반납 중 오류 발생.");
                fail.ShowDialog();
            }
        }

        public bool rental_info_book_rental_update(string no)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/rental_info_book_rental_update";
            string method = "POST";

            data.Add("no", no);

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            bool success_chk;
            if (strResult == "1")
            {
                success_chk = true;
            }
            else
            {
                success_chk = false;
            }

            return success_chk;
        }

        public bool rental_info_book_info_update(string no)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/rental_info_book_info_update";
            string method = "POST";

            data.Add("no", no);

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            bool success_chk;
            if (strResult == "1")
            {
                success_chk = true;
            }
            else
            {
                success_chk = false;
            }

            return success_chk;
        }

        private void label_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : label_Click");
        }

        private void txtbox_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : txtbox_Click");
        }

        private void chkbox_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : chkbox_Click2");
        }

        private void radio_btn_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : radio_btn_Click");
        }

        private void picturbox_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : picturbox_Click");
        }

        private void panel_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : panel_Click");
        }
        private void panel_MouseMove(Object o, MouseEventArgs e)
        {
            // StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }

        private void tabctl_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : tabctl_Click");
        }
        private void tabctl_MouseMove(Object o, MouseEventArgs e)
        {
            // StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }

        private void tabpage_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : tabpage_Click");
        }
        private void tabpage_MouseMove(Object o, MouseEventArgs e)
        {
            // StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }


        ///////////////////////// 좌표 체크시 추가 /////////////////////////////

        private void Point_Print()
        {

            MouseMove += new MouseEventHandler(this.Current_FORM_MouseMove);
            statusStrip = new StatusStrip();
            StripLb = new ToolStripStatusLabel();
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { StripLb });
            statusStrip.Location = new Point(0, sY);
            statusStrip.Name = "statusStrip1";
            statusStrip.Size = new Size(sX, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // toolStripStatusLabel1
            StripLb.Name = "StripLb1";
            StripLb.Size = new Size(121, 17);
            StripLb.Text = "StripLb1";
            Controls.Add(statusStrip);
        }
        private void Current_FORM_MouseMove(object sender, MouseEventArgs e)
        {
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
        ///////////////////////////////////////////////////////////////////////
        ///

        // 테두리 색상 추가
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, 750, 0, 750, 800);
        }
    }
}