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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp
{
    public partial class BOOK_MGT_FORM : Form
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
        PictureBox 책이미지;
        TextBox 간략소개상자;
        ListView 요청입고_리스트뷰;

        TextBox 제목값;
        TextBox 저자값;
        TextBox 출판사값;
        TextBox 장르값;
        TextBox 도서위치값;
        String 이미지Load경로 = "";
        String 본파일이름 = "";

        int request_number = 0;       


        public BOOK_MGT_FORM()
        {
            InitializeComponent();

            Load += BOOK_MGT_FORM_Load;
        }

        private void BOOK_MGT_FORM_Load(object sender, EventArgs e)
        {
            webapiUrl = comm.WebapiUrl;

            this.Paint += new PaintEventHandler(this.Form_Paint);

            FormBorderStyle = FormBorderStyle.None; //폼 상단 표시줄 제거
            //this.BackColor = Color.Aquamarine;
            this.BackColor = Color.FromArgb(201, 253, 223);

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            //Point_Print();

            COMMON_Create_Ctl create_ctl = new COMMON_Create_Ctl();


            // 책정보패널
            PANELclass 책정보패널값 = new PANELclass(this, "책정보패널", "책정보패널", 720, 750, 10, 10);
            Panel 책정보패널 = comm.panel(책정보패널값);


            //(좌측상단여백, 우측상단여백, 컨트롤 넓이, 컨트롤 높이, 가로 모서리 원기울기, 세로 모서리 원기울기)
            책정보패널.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 책정보패널.Width, 책정보패널.Height, 15, 15));
            책정보패널.BackColor = Color.FromArgb(218, 234, 244);  // rgb(218,234,244)
            Controls.Add(책정보패널);


            // 도서사진 픽쳐박스
            PICTUREBOXclass picturboxValue = new PICTUREBOXclass(this, "picturebox1", "picturebox_txt1", 220, 260, 10, 20, "default_book_image.png", picturbox_Click);
            책이미지 = comm.load_PictureBox(picturboxValue);
            책정보패널.Controls.Add(책이미지);

            // 간략소개상자 - TextBOX
            TXTBOXclass 간략소개상자값 = new TXTBOXclass(this, "간략소개상자", "", 665, 280, 26, 380, txtbox_Click);
            간략소개상자 = comm.txtbox(간략소개상자값);
            간략소개상자.Font = new Font("Arial", 24, FontStyle.Bold);
            간략소개상자.Multiline = true;
            간략소개상자.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 간략소개상자.Width, 간략소개상자.Height, 18, 18));
            간략소개상자.ScrollBars = ScrollBars.Vertical;
            책정보패널.Controls.Add(간략소개상자);

            // 책정보패널 고정라벨
            ArrayList arry = new ArrayList();
            arry.Add(new LBclass(this, "제목", "제목    :", 17, 110, 40, 235, 40, label_Click));
            arry.Add(new LBclass(this, "저자", "저자    :", 17, 110, 40, 235, 90, label_Click));
            arry.Add(new LBclass(this, "출판사", "출판사 :", 17, 110, 40, 235, 140, label_Click));
            arry.Add(new LBclass(this, "장르", "장르    :", 17, 110, 40, 235, 190, label_Click));
            arry.Add(new LBclass(this, "도서위치", "위치    :", 17, 110, 40, 235, 240, label_Click));
            arry.Add(new LBclass(this, "간략소개", "간략소개 :", 17, 130, 40, 26, 340, label_Click));


            for (int i = 0; i < arry.Count; i++)
            {
                Label label = comm.lb((LBclass)arry[i]);

                if (label.Name == "간략소개")
                {
                    label.Font = new Font(label.Font.Name, 20, FontStyle.Bold | FontStyle.Underline);
                }
                else
                {
                    label.Font = new Font(label.Font.Name, 17, FontStyle.Bold);
                }

                책정보패널.Controls.Add(label);
            }


            // 책정보패널 선택한 리스트 텍스트박스 값
            ArrayList arryValue = new ArrayList();
            arryValue.Add(new TXTBOXclass(this, "제목값", "제목값", 340, 40, 349, 35, txtbox_Click));
            arryValue.Add(new TXTBOXclass(this, "저자값", "저자값", 340, 40, 349, 85, txtbox_Click));
            arryValue.Add(new TXTBOXclass(this, "출판사값", "출판사값", 340, 40, 349, 135, txtbox_Click));
            arryValue.Add(new TXTBOXclass(this, "장르값", "장르값", 340, 40, 349, 185, txtbox_Click));
            arryValue.Add(new TXTBOXclass(this, "도서위치값", "A열 2 - 1", 340, 40, 349, 235, txtbox_Click));

            for (int i = 0; i < arryValue.Count; i++)
            {
                TextBox textbox = comm.txtbox((TXTBOXclass)arryValue[i]);
                textbox.Font = new Font(textbox.Font.Name, 17, FontStyle.Bold);
                책정보패널.Controls.Add(textbox);

                if (textbox.Name == "제목값")
                {
                    제목값 = textbox;
                }
                else if (textbox.Name == "저자값")
                {
                    저자값 = textbox;
                }
                else if (textbox.Name == "출판사값")
                {
                    출판사값 = textbox;
                }
                else if (textbox.Name == "장르값")
                {
                    장르값 = textbox;
                }
                else if (textbox.Name == "도서위치값")
                {
                    도서위치값 = textbox;
                }
            }



            ArrayList btnarry = new ArrayList();
            btnarry.Add(new BTNclass(this, "등록버튼", "등 록", 120, 50, 575, 670, btn_Click));
            btnarry.Add(new BTNclass(this, "이미지추가버튼", "도서 이미지 추가", 180, 30, 32, 285, btn_Click));
            btnarry.Add(new BTNclass(this, "요청리스트삭제", "요청 리스트 삭제", 180, 40, 1295, 50, btn_Click));

            for (int i = 0; i < btnarry.Count; i++)
            {
                Button 버튼 = comm.btn((BTNclass)btnarry[i]);

                if (버튼.Name == "등록버튼")
                {
                    버튼.Font = new Font(버튼.Font.Name, 20, FontStyle.Bold);
                }
                else if (버튼.Name == "이미지추가버튼")
                {
                    버튼.Font = new Font(버튼.Font.Name, 13, FontStyle.Bold);
                }
                버튼.BackColor = Color.FromArgb(50, 178, 223);
                버튼.FlatStyle = FlatStyle.Flat;
                버튼.ForeColor = Color.White;
                버튼.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼.Width, 버튼.Height, 18, 18));

                if (버튼.Name == "요청리스트삭제")
                {
                    버튼.Font = new Font(버튼.Font.Name, 13, FontStyle.Bold);
                    Controls.Add(버튼);
                }
                else
                {
                    책정보패널.Controls.Add(버튼);
                }

            }



            LBclass 요청입고목록값 = new LBclass(this, "요청입고목록", "입고 요청한 도서 목록", 24, 400, 40, 770, 40, label_Click);
            Label 요청입고목록 = comm.lb(요청입고목록값);
            요청입고목록.Font = new Font(요청입고목록.Font.Name, 24, FontStyle.Bold);
            Controls.Add(요청입고목록);


            LISTVIEWclass 요청입고_리스트뷰값 = new LISTVIEWclass(this, "요청입고리스트뷰", 700, 650, 775, 105, listView_MouseClick, listview_mousedoubleclick, 6, "", 0, "회원번호", 100, "요청자", 100, "도서명", 300, "저자", 100, "출판사", 100);
            요청입고_리스트뷰 = comm.listView(요청입고_리스트뷰값);
            요청입고_리스트뷰.Font = new Font("Arial", 15, FontStyle.Bold);

            ClassLibrary1.MySql mysql = new ClassLibrary1.MySql();


            ArrayList Receiving_equest_arry = Select_Webapi("request_listview");
            foreach (Hashtable ht in Receiving_equest_arry)
            {
                ListViewItem item = new ListViewItem(ht["request_number"].ToString());
                item.SubItems.Add(ht["user_number"].ToString());
                item.SubItems.Add(ht["name"].ToString());
                item.SubItems.Add(ht["title"].ToString());
                item.SubItems.Add(ht["author"].ToString());
                item.SubItems.Add(ht["publisher"].ToString());
                item.Font = new Font("Arial", 15, FontStyle.Italic);

                요청입고_리스트뷰.Items.Add(item);
            }

            Controls.Add(요청입고_리스트뷰);




        }

        public ArrayList Select_Webapi(string controll_name)
        {
            WebClient client = new WebClient();
            //NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;    //한글처리

            string url = "http://" + webapiUrl + "/" + controll_name;
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

        public ArrayList book_mgt_request_listview_click_select_post(string request_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/book_mgt_request_listview_click_select_post";
            string method = "POST";


            data.Add("request_number", request_number);

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

        public bool book_mgt_register_btn(string title, string author, string publisher, string genre, string book_location, string brief_introduction, string image_location, string image_FileName)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/book_mgt_register_btn";
            string method = "POST";


            data.Add("title", title);
            data.Add("author", author);
            data.Add("publisher", publisher);
            data.Add("genre", genre);
            data.Add("book_location", book_location);
            data.Add("brief_introduction", brief_introduction);
            data.Add("image_location", image_location);
            data.Add("image_FileName", image_FileName);


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

        public bool request_list_delete(string request_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/request_list_delete";
            string method = "POST";


            data.Add("request_number", request_number);


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

        ////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary> 아래는 이벤트 처리 부분
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //////////////////////////////////////////////////////////////////////////////////////////////// 


        // 리스트뷰 더블클릭
        private void listview_mousedoubleclick(object sender, MouseEventArgs e)
        {
            // MessageBox.Show("마우스 더블클릭 동작확인");
        }

        // 리스트뷰 마우스클릭
        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("동작확인 : listView_MouseClick");            

            int index;
            index = 요청입고_리스트뷰.FocusedItem.Index;  // 선택돈 아이템 인덱스 번호 얻기
            request_number = Convert.ToInt32(요청입고_리스트뷰.Items[index].SubItems[0].Text); // 인덱스 번호의 n번째 아이템 얻기

            ClassLibrary1.MySql mysql = new ClassLibrary1.MySql();

            ArrayList Receiving_equest_arry = book_mgt_request_listview_click_select_post(request_number.ToString());
            foreach (Hashtable ht in Receiving_equest_arry)
            {
                제목값.Text = ht["title"].ToString();
                저자값.Text = ht["author"].ToString();
                출판사값.Text = ht["publisher"].ToString();
                장르값.Text = ht["genre"].ToString();
                도서위치값.Text = "";
            }
        }


        // 콤보박스 인덱스 선택
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void list_Refresh()
        {
            요청입고_리스트뷰.Items.Clear();

            ClassLibrary1.MySql mysql = new ClassLibrary1.MySql();

            ArrayList Receiving_equest_arry = Select_Webapi("request_listview");
            foreach (Hashtable ht in Receiving_equest_arry)
            {
                ListViewItem item = new ListViewItem(ht["request_number"].ToString());
                item.SubItems.Add(ht["user_number"].ToString());
                item.SubItems.Add(ht["name"].ToString());
                item.SubItems.Add(ht["title"].ToString());
                item.SubItems.Add(ht["author"].ToString());
                item.SubItems.Add(ht["publisher"].ToString());
                item.Font = new Font("Arial", 15, FontStyle.Italic);

                요청입고_리스트뷰.Items.Add(item);
            }
        }


        // 버튼클릭
        private void btn_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : btn_Click");

            Button button = (Button)o;


            /// 입고요청 버튼 설정. 
            if (button.Name == "이미지추가버튼")
            {
                // MessageBox.Show("이미지추가버튼");
                WebApi_Image_Select();
                //Image_Select();
            }
            else if (button.Name == "등록버튼")
            {
                //  MessageBox.Show("등록버튼");

                if (제목값.Text == "" || 저자값.Text == "" || 출판사값.Text == "" || 장르값.Text == "" || 도서위치값.Text == "" || 간략소개상자.Text == "" || 이미지Load경로 == "" || 본파일이름 == "")
                {
                    fail fail = new fail("빈칸밑 이미지파일 등록");
                    fail.ShowDialog();
                    return;
                }

                // MessageBox.Show("이미지Load경로 : " + 이미지Load경로);
                //  MessageBox.Show("본파일이름 : " + 본파일이름);

                ClassLibrary1.MySql mysql = new ClassLibrary1.MySql();

                string Temp = "";
                Temp = 간략소개상자.Text.Replace("\'", "\"");
                간략소개상자.Text = Temp;

                bool status = book_mgt_register_btn(제목값.Text, 저자값.Text, 출판사값.Text, 장르값.Text, 도서위치값.Text, 간략소개상자.Text, 이미지Load경로, 본파일이름);

                if (status)
                {
                    fail fail = new fail("등록 완료");
                    fail.ShowDialog();
                }
                else
                {
                    fail fail = new fail("간략소개 4000자 이하로 입력 후 등록 시도해주세요.");
                    fail.ShowDialog();
                }
            }

            if (button.Name == "요청리스트삭제")
            {
                if (request_number == 0)
                {
                    fail fail = new fail("삭제 할 리스트를 선택해주세요.");
                    fail.ShowDialog();
                    return;
                }

                ClassLibrary1.MySql mysql = new ClassLibrary1.MySql();
                bool status = request_list_delete(request_number.ToString());

                if (status)
                {
                    list_Refresh();
                }
                else
                {
                    fail fail = new fail("요청리스트 삭제 중 오류가 발생하였습니다.");
                    fail.ShowDialog();
                }
            }

        }

        private void label_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : label_Click");
        }

        private void txtbox_Click(Object o, EventArgs e)
        {
            return;
            //MessageBox.Show("동작확인 : txtbox_Click");
        }

        private void chkbox_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : chkbox_Click2");
        }

        private void radio_btn_Click(Object o, EventArgs e)
        {
            // MessageBox.Show("동작확인 : radio_btn_Click");
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
            //  MessageBox.Show("동작확인 : tabctl_Click");
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
            //  StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }

        private void WebApi_Image_Select()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Images only. |*.jpg; *.jpeg; *.png; *.gif;";

            if (of.ShowDialog() == DialogResult.OK)
            {

                string filePath = of.FileName;
                Image img = Image.FromFile(filePath);
                //textBox1.Text = textBox1.Text + "\r\n" + filePath;

                int start = filePath.LastIndexOf("\\") + 1;
                int len = filePath.Length - start;
                string fileName = filePath.Substring(start, len);

                WebClient wc = new WebClient();
                NameValueCollection param = new NameValueCollection();
                본파일이름 = fileName;
                param.Add("fileName", fileName);

                /************************************************************************************/
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                string fileData = Convert.ToBase64String(ms.ToArray());
                param.Add("fileData", fileData);
                ms.Close();
                /************************************************************************************/

                try
                {
                    byte[] result = wc.UploadValues("http://192.168.3.25:5000/imageUpload", "POST", param);
                    string resultStr = Encoding.UTF8.GetString(result);
                    fail fail = new fail("파일 저장 완료");
                    fail.ShowDialog();
                    이미지Load경로 = resultStr;
                    책이미지.ImageLocation = resultStr; // Webapi Service wwwroot 경로에 파일이름 위치경로.

                }
                catch
                {
                    fail fail = new fail("저장중 오류 발생");
                    fail.ShowDialog();
                }

            }
            else
            {
                // MessageBox.Show("취소");
            }
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
            // StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
        ///////////////////////////////////////////////////////////////////////
        ///

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            e.Graphics.DrawLine(pen, 750, 0, 750, 800);
        }



    }
}