using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class LATE_MGT_FORM : Form
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
        ListView 연체정보리스트;

        public LATE_MGT_FORM()
        {
            InitializeComponent();

            Load += LATE_MGT_FORM_Load;
        }

        private void LATE_MGT_FORM_Load(object sender, EventArgs e)
        {
            webapiUrl = comm.WebapiUrl;

            FormBorderStyle = FormBorderStyle.None; // 폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(201, 253, 223);

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            //Point_Print();

            COMMON_Create_Ctl create_ctl = new COMMON_Create_Ctl();
            create_ctl.delay_rental_check();

            BTNclass 연체정보리플레시버튼값 = new BTNclass(this, "리플레시버튼", "Refresh", 150, 50, 1285, 70, btn_Click);
            Button 연체정보리플레시버튼 = comm.btn(연체정보리플레시버튼값);
            연체정보리플레시버튼.Font = new Font("신명조", 20, FontStyle.Bold);
            Controls.Add(연체정보리플레시버튼);


            LBclass 연체정보라벨값 = new LBclass(this, "연체정보라벨", "연체자 정보", 30, 250, 50, 30, 50, label_Click);
            Label 연체정보라벨 = comm.lb(연체정보라벨값);
            Controls.Add(연체정보라벨);


            LISTVIEWclass 연체정보리스트값 = new LISTVIEWclass(this, "연체정보리스트", 1400, 600, 38, 130, listview_mousedoubleclick, listview_mousedoubleclick, 8, "", 0, "회원번호", 200, "연락처", 200, "이름", 200, "도서명", 200, "도서번호", 200, "대여일", 200, "연체일", 200);
            연체정보리스트 = comm.listView(연체정보리스트값);
            연체정보리스트.Font = new Font("신명조", 24, FontStyle.Bold);

            연체정보리스트.OwnerDraw = true;
            연체정보리스트.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lv_DrawColumnHeader);

            //연체정보리스트.BackColor = Color.AliceBlue;  // Color.FromArgb(201, 253, 223); 
            연체정보리스트.DrawSubItem += new DrawListViewSubItemEventHandler(lv_DrawSubItem);

            ClassLibrary1.MySql mysql = new ClassLibrary1.MySql();

            ArrayList arry = late_mgt_listview_delay_info();
            foreach (Hashtable ht in arry)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["user_number"].ToString());
                item.SubItems.Add(ht["phone_number"].ToString());
                item.SubItems.Add(ht["name"].ToString());
                item.SubItems.Add(ht["title"].ToString());
                item.SubItems.Add(ht["book_number"].ToString());
                item.SubItems.Add(ht["rental_day"].ToString());
                item.SubItems.Add(ht["연체일"].ToString());

                연체정보리스트.Items.Add(item);

                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    item.SubItems[i].Font = new Font("Arial", 14, FontStyle.Italic);
                }
            }

            Controls.Add(연체정보리스트);


        }

        public void Refresh_ListView()
        {
            연체정보리스트.Items.Clear();

            ClassLibrary1.MySql mysql = new ClassLibrary1.MySql();
            ArrayList arry = late_mgt_listview_delay_info();
            foreach (Hashtable ht in arry)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(ht["user_number"].ToString());
                item.SubItems.Add(ht["phone_number"].ToString());
                item.SubItems.Add(ht["name"].ToString());
                item.SubItems.Add(ht["title"].ToString());
                item.SubItems.Add(ht["book_number"].ToString());
                item.SubItems.Add(ht["rental_day"].ToString());
                item.SubItems.Add(ht["연체일"].ToString());

                연체정보리스트.Items.Add(item);

                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    item.SubItems[i].Font = new Font("Arial", 14, FontStyle.Italic);
                }
            }
        }

        public ArrayList late_mgt_listview_delay_info()
        {
            WebClient client = new WebClient();
            //NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;    //한글처리

            string url = "http://" + webapiUrl + "/late_mgt_listview_delay_info";
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



        private void listview_mousedoubleclick(object sender, MouseEventArgs e)
        {
            // MessageBox.Show("동작확인 : listview_mousedoubleclick");
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            // MessageBox.Show("동작확인 : listView_MouseClick");
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Click(Object o, EventArgs e)
        {
            Button button = (Button)o;

            if (button.Name == "리플레시버튼")
            {
                Refresh_ListView();
            }
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
            // StripLb.Text = "(" + e.X + ", " + e.Y + ")";
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

        // 리스트뷰 헤더 컬러추가
        void lv_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            e.DrawText();
        }

        // 리스트뷰 Subitem 컬러추가
        void lv_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawText();
        }

    }
}