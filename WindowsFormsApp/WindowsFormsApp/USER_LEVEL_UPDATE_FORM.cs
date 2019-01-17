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

    public partial class USER_LEVEL_UPDATE_FORM : Form
    {
        string webapiUrl;

        int sX = 800, sY = 450; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        COMMON_Create_Ctl comm = new COMMON_Create_Ctl();

        private OpenFileDialog openFileDialog1 = new OpenFileDialog();  // openFileDialog1 변수 선언 및 초기화
        public static string _Slected_File_RootPath;

        string 회원등급Temp값;
        string 회원IDTemp값;
        string 회원이름Temp값;
        string 회원번호Temp값;
        string 연락처Temp값;

        RadioButton 관리자라디오버튼;
        RadioButton 회원라디오버튼;
        RadioButton 블랙리스트라디오버튼;
        RadioButton 블랙리스트해제라디오버튼;

        string user_number;

        public USER_LEVEL_UPDATE_FORM()
        {
            InitializeComponent();

            Load += USER_LEVEL_UPDATE_FORM_Load;
        }

        public USER_LEVEL_UPDATE_FORM(string user_number)
        {
            InitializeComponent();

            this.user_number = user_number;
            Load += USER_LEVEL_UPDATE_FORM_Load;
        }

        private void USER_LEVEL_UPDATE_FORM_Load(object sender, EventArgs e)
        {
            webapiUrl = comm.WebapiUrl;

            this.Paint += new PaintEventHandler(this.Form_Paint);

            //FormBorderStyle = FormBorderStyle.None; 폼 상단 표시줄 제거

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            //Point_Print();

            COMMON_Create_Ctl create_ctl = new COMMON_Create_Ctl();

            // 회원등급 수정 고정라벨
            ArrayList arry = new ArrayList();
            arry.Add(new LBclass(this, "회원등급제목", "회원 등급 수정", 17, 200, 30, 30, 30, label_Click));
            arry.Add(new LBclass(this, "회원등급", "회원 등급", 17, 140, 30, 30, 115, label_Click));
            arry.Add(new LBclass(this, "회원ID", "회원 ID", 17, 140, 30, 30, 175, label_Click));
            arry.Add(new LBclass(this, "회원이름", "회원 이름", 17, 140, 30, 30, 235, label_Click));
            arry.Add(new LBclass(this, "회원번호", "회원 번호", 17, 140, 30, 30, 295, label_Click));
            arry.Add(new LBclass(this, "연락처", "연락처", 17, 140, 40, 30, 355, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 115, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 175, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 235, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 295, label_Click));
            arry.Add(new LBclass(this, "", ":", 12, 30, 40, 210, 355, label_Click));

            for (int i = 0; i < arry.Count; i++)
            {
                Label label = comm.lb((LBclass)arry[i]);

                label.Font = new Font(label.Font.Name, 20, FontStyle.Bold);


                Controls.Add(label);
            }


            ArrayList userinfoSearch_arry = user_level_update_form_user_number_signup_info(user_number);
            foreach (Hashtable ht in userinfoSearch_arry)
            {
                회원등급Temp값 = ht["member_rank"].ToString();
                회원IDTemp값 = ht["id"].ToString();
                회원이름Temp값 = ht["name"].ToString();
                회원번호Temp값 = ht["user_number"].ToString();
                연락처Temp값 = ht["phone_number"].ToString();
            }


            // 회원등급 TextBox 변동값
            ArrayList userinfoArry = new ArrayList();
            userinfoArry.Add(new TXTBOXclass(this, "회원등급값", "회원등급값", 250, 40, 250, 110, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "회원ID값", "회원ID값", 250, 40, 250, 170, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "회원이름값", "회원이름값", 250, 40, 250, 230, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "회원번호값", "회원번호값", 250, 40, 250, 290, txtbox_Click));
            userinfoArry.Add(new TXTBOXclass(this, "연락처값", "연락처값", 250, 40, 250, 350, txtbox_Click));

            for (int i = 0; i < userinfoArry.Count; i++)
            {
                TextBox textBox = comm.txtbox((TXTBOXclass)userinfoArry[i]);
                textBox.ReadOnly = true;
                textBox.Font = new Font(textBox.Font.Name, 18, FontStyle.Bold);

                if (textBox.Name == "회원등급값")
                {
                    if (회원등급Temp값 == "0")
                    {
                        textBox.Text = "관리자";
                    }
                    else if (회원등급Temp값 == "1")
                    {
                        textBox.Text = "일반회원";
                    }
                    else
                    {
                        textBox.Text = "비회원";
                    }


                }
                else if (textBox.Name == "회원ID값")
                {
                    textBox.Text = 회원IDTemp값;
                }
                else if (textBox.Name == "회원이름값")
                {
                    textBox.Text = 회원이름Temp값;
                }
                else if (textBox.Name == "회원번호값")
                {
                    textBox.Text = 회원번호Temp값;
                }
                else if (textBox.Name == "연락처값")
                {
                    textBox.Text = 연락처Temp값;
                }

                Controls.Add(textBox);
            }


            // 권한 선택 - 라디오 버튼
            ArrayList radio_arry = new ArrayList();
            radio_arry.Add(new RADIOclass(this, "관리자권한", "관리자 권한", 250, 40, 550, 120, radio_btn_Click));
            radio_arry.Add(new RADIOclass(this, "회원권한", "회원 권한", 250, 40, 550, 170, radio_btn_Click));
            radio_arry.Add(new RADIOclass(this, "블랙리스트설정", "블랙리스트 설정", 250, 40, 550, 220, radio_btn_Click));
            radio_arry.Add(new RADIOclass(this, "블랙리스트해제", "블랙리스트 해제", 250, 40, 550, 270, radio_btn_Click));

            for (int i = 0; i < radio_arry.Count; i++)
            {
                RadioButton 권한선택라디오 = comm.radio_btn((RADIOclass)radio_arry[i]);

                권한선택라디오.Font = new Font(권한선택라디오.Font.Name, 20, FontStyle.Bold);
                Controls.Add(권한선택라디오);

                if (권한선택라디오.Name == "관리자권한")
                {
                    관리자라디오버튼 = 권한선택라디오;

                }
                else if (권한선택라디오.Name == "회원권한")
                {
                    회원라디오버튼 = 권한선택라디오;

                }
                else if (권한선택라디오.Name == "블랙리스트설정")
                {
                    블랙리스트라디오버튼 = 권한선택라디오;

                }
                else if (권한선택라디오.Name == "블랙리스트해제")
                {
                    블랙리스트해제라디오버튼 = 권한선택라디오;

                }

            }


            // 권한 선택 - 설정 버튼
            ArrayList btn_arry = new ArrayList();
            btn_arry.Add(new BTNclass(this, "설정완료", "설정 완료", 100, 40, 570, 345, btn_Click));
            btn_arry.Add(new BTNclass(this, "취소", "취 소", 100, 40, 680, 345, btn_Click));

            for (int i = 0; i < btn_arry.Count; i++)
            {
                Button 권한설정버튼 = comm.btn((BTNclass)btn_arry[i]);

                권한설정버튼.BackColor = Color.FromArgb(50, 178, 223);
                권한설정버튼.Font = new Font(권한설정버튼.Font.Name, 12, FontStyle.Bold);
                권한설정버튼.FlatStyle = FlatStyle.Flat;
                권한설정버튼.ForeColor = Color.White;
                권한설정버튼.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 권한설정버튼.Width, 권한설정버튼.Height, 10, 10));
                Controls.Add(권한설정버튼);
            }


        }


        public ArrayList user_level_update_form_user_number_signup_info(string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/user_level_update_form_user_number_signup_info";
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

        public bool user_level_update_form_signup_member_rank_0_set(string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/user_level_update_form_signup_member_rank_0_set";
            string method = "POST";


            data.Add("user_number", user_number);

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

        public bool user_level_update_form_signup_member_rank_1_set(string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/user_level_update_form_signup_member_rank_1_set";
            string method = "POST";


            data.Add("user_number", user_number);

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

        public bool user_level_update_form_signup_blacklist_Y_set(string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/user_level_update_form_signup_blacklist_Y_set";
            string method = "POST";


            data.Add("user_number", user_number);

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

        public bool user_level_update_form_signup_blacklist_N_set(string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/user_level_update_form_signup_blacklist_N_set";
            string method = "POST";


            data.Add("user_number", user_number);

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
            //MessageBox.Show("동작확인 : btn_Click");

            Button button = (Button)o;

            if (button.Name == "설정완료")
            {
                if (관리자라디오버튼.Checked == false && 회원라디오버튼.Checked == false && 블랙리스트라디오버튼.Checked == false && 블랙리스트해제라디오버튼.Checked == false)
                {
                    fail fail = new fail("권한 라디오 버튼을 선택해주세요");
                    fail.ShowDialog();

                }

                //MessageBox.Show("설정완료");
                if (관리자라디오버튼.Checked == true)
                {
                    if (user_level_update_form_signup_member_rank_0_set(회원번호Temp값))
                    {
                        fail fail = new fail("관리자 권한 변경 완료");
                        fail.ShowDialog();
                    }
                    else
                    {
                        fail fail = new fail("관리자 권한 변경오류 발생");
                        fail.ShowDialog();
                    }

                }
                else if (회원라디오버튼.Checked == true)
                {

                    if (user_level_update_form_signup_member_rank_1_set(회원번호Temp값))
                    {
                        fail fail = new fail("회원 권한 변경 완료");
                        fail.ShowDialog();
                    }
                    else
                    {
                        fail fail = new fail("회원 권한 변경오류 발생");
                        fail.ShowDialog();
                    }
                }
                else if (블랙리스트라디오버튼.Checked == true)
                {

                    if (user_level_update_form_signup_blacklist_Y_set(회원번호Temp값))
                    {
                        fail fail = new fail("블랙리스트 권한 변경 완료");
                        fail.ShowDialog();
                    }
                    else
                    {
                        fail fail = new fail("블랙리스트 권한 변경오류 발생");
                        fail.ShowDialog();
                    }
                }
                else if (블랙리스트해제라디오버튼.Checked == true)
                {

                    if (user_level_update_form_signup_blacklist_N_set(회원번호Temp값))
                    {
                        fail fail = new fail("블랙리스트 해제 변경 완료");
                        fail.ShowDialog();
                    }
                    else
                    {
                        fail fail = new fail("블랙리스트 해제 변경오류 발생");
                        fail.ShowDialog();
                    }
                }

            }
            else if (button.Name == "취소")
            {
                this.Close();
            }
        }

        private void label_Click(Object o, EventArgs e)
        {
            //  MessageBox.Show("동작확인 : label_Click");
        }

        private void txtbox_Click(Object o, EventArgs e)
        {
            //  MessageBox.Show("동작확인 : txtbox_Click");
        }

        private void chkbox_Click(Object o, EventArgs e)
        {
            //  MessageBox.Show("동작확인 : chkbox_Click2");
        }

        private void radio_btn_Click(Object o, EventArgs e)
        {
            //MessageBox.Show("동작확인 : radio_btn_Click");

        }

        private void picturbox_Click(Object o, EventArgs e)
        {
            //  MessageBox.Show("동작확인 : picturbox_Click");
        }

        private void panel_Click(Object o, EventArgs e)
        {
            //  MessageBox.Show("동작확인 : panel_Click");
        }
        private void panel_MouseMove(Object o, MouseEventArgs e)
        {
            //  StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }

        private void tabctl_Click(Object o, EventArgs e)
        {
            //  MessageBox.Show("동작확인 : tabctl_Click");
        }
        private void tabctl_MouseMove(Object o, MouseEventArgs e)
        {
            //  StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }

        private void tabpage_Click(Object o, EventArgs e)
        {
            //  MessageBox.Show("동작확인 : tabpage_Click");
        }
        private void tabpage_MouseMove(Object o, MouseEventArgs e)
        {
            //  StripLb.Text = "(" + e.X + ", " + e.Y + ")";
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
            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0), 2);
            e.Graphics.DrawLine(pen, 30, 70, 770, 70);
        }
    }
}