using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp
{
    public partial class RENTAL_INFO_FORM : Form
    {
        public LOGIN_FORM Login;
        public RENTAL_INFO_FORM()
        {
            InitializeComponent();
            Load += RENTAL_INFO_FORM_Load;
        }
        //public RENTAL_INFO_FORM(LOGIN_FORM Logi)
        //{
        //    InitializeComponent();
        //    this.Login = Login;
        //}

        private ListView lv;
        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        //===================================================================================
        COMMON_Create_Ctl comm;
        ClassLibrary1.MySql mysql;
        string webapiUrl;

        LISTVIEWclass lv_value;
        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////
        private string no;
        private void RENTAL_INFO_FORM_Load(object sender, EventArgs e)
        {
            comm = new COMMON_Create_Ctl();
            webapiUrl = comm.WebapiUrl;

            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거

            Login = new LOGIN_FORM();

            //this.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, this.Width, this.Height, 15, 15));
            //Point_Print(); //좌표 
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            
            comm.delay_rental_check();
            mysql = new ClassLibrary1.MySql();
            this.BackColor = Color.FromArgb(201, 253, 223); //백컬러
            //리스트뷰===============================================================================================================================================

            lv_value = new LISTVIEWclass(this, "ListView1", 1300, 600, 100, 50, listView_MouseClick, listview_mousedoubleclick, 9, "", 0, "대여번호", 120, "도서명", 260, "저자", 158, "출판사", 180, "대여일", 170, "반납일", 170, "연체일", 120, "상태", 120);
            lv = comm.listView(lv_value);
            Controls.Add(lv);
            lv.Font = new Font("Arial", 18, FontStyle.Bold);


            List_Views();
            //버튼=========================================================================================================================================================
            ArrayList btnArray = new ArrayList();
            btnArray.Add(new BTNclass(this, "반납", "반납", 150, 80, 1250, 660, btn1_Click));

            Button btn = comm.btn((BTNclass)btnArray[0]);
            btn.Font = new Font("견명조", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.LawnGreen;
            btn.BackColor = Color.ForestGreen;
            btn.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 150, 80, 15, 15));
            Controls.Add(btn);
            //라벨 ========================================================================================================================================================
            ArrayList lbarray = new ArrayList();
            lbarray.Add(new LBclass(this, "상태", "상태:", 30, 80, 50, 95, 660, label_Click));
            lbarray.Add(new LBclass(this, "staitus", "대여가능", 15, 100, 20, 170, 668, label_Click));

            for (int i = 0; i < lbarray.Count; i++)
            {

                Label lb = comm.lb((LBclass)lbarray[i]);

                if (lb.Name == "상태")
                {
                    lb.Font = new Font("견명조", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                }

                Controls.Add(lb);
            }
            //=================================================================================================================================================

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            GetUpdate();
            List_Views();
        }
        // 리스트뷰 ============================================================================================================================================
        public void List_Views()
        {

            lv.Items.Clear();
            ArrayList arry = GetSelect();
            foreach (Hashtable ht in arry)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["대여번호"].ToString());
                item.SubItems.Add(ht["도서명"].ToString());
                item.SubItems.Add(ht["저자"].ToString());
                item.SubItems.Add(ht["출판사"].ToString());
                item.SubItems.Add(ht["대여일"].ToString().Substring(0, 10));
                item.SubItems.Add(ht["반납일"].ToString().Substring(0, 10));
                item.SubItems.Add(ht["연체일"].ToString());
                item.SubItems.Add(ht["상태"].ToString());
                lv.Items.Add(item);
            }

            Controls.Add(lv);

        }
        // 리스트뷰 클릭 =====================================================================================================
        private void listview_mousedoubleclick(object sender, MouseEventArgs e)
        {

        }
        // 리스트뷰 클릭 =====================================================================================================
        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("동작확인 : listView_MouseClick");
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection slv = lv.SelectedItems;
            for (int i = 0; i < slv.Count; i++)
            {
                ListViewItem item = slv[i];
                no = item.SubItems[1].Text;
                //MessageBox.Show(no);
            }
        }


        public ArrayList rental_info_form_GetSelect(string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl  + "/rental_info_form_GetSelect";
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

        public ArrayList GetSelect()
        {
            return rental_info_form_GetSelect(Login.User_Number.ToString());
        }

        public void GetUpdate()
        {

            bool status = rental_info_book_rental_update(no);

            if (status)
            {

                if (rental_info_book_info_update(no))
                {
                    check check = new check();
                    check.ShowDialog();
                }
                else
                {
                    fail fail = new fail("상태 업데이트 오류");
                    fail.ShowDialog();
                }
            }
            else
            {
                fail fail = new fail("반납중 오류발생");
                fail.ShowDialog();
            }
        }

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
    }
}
