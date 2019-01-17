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


    public partial class LOGIN_FORM : Form
    {
        string webapiUrl;

        MAIN_FORM form;
        public BOOK_INFO_FORM user1;
        public static int member_rank = 4; // 0 관리자 / 1 유저 / 4 비회원
        public static int user_Number;
        public RENTAL_INFO_FORM RENTAL1;
        public MY_INFO_FORM MYinfo;
        public Passwod_Check p_check;
        public LOGIN_FORM(MAIN_FORM form)
        {
            InitializeComponent();
            this.form = form;
            Load += LOGIN_FORM_Load;
        }
        public LOGIN_FORM()
        {
            InitializeComponent();
            Load += LOGIN_FORM_Load;
        }
        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        TextBox Tb1, Tb2 = new TextBox();//텍스트박스 
        Panel pan1 = new Panel();

        private void LOGIN_FORM_Load(object sender, EventArgs e)
        {
            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
            webapiUrl = comm.WebapiUrl;

            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거
            
            comm.delay_rental_check();
            this.BackColor = Color.FromArgb(201, 253, 223); //백컬러
            Point_Print(); //좌표 
            //=============
            //RENTAL1 = new RENTAL_INFO_FORM(this);
            //MYinfo = new MY_INFO_FORM(this);
            //p_check = new Passwod_Check(this);
            //=============
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            //라벨 ==============================================================================================================================================
            ArrayList lbarray = new ArrayList();
            lbarray.Add(new LBclass(this, "lb_Login", "로그인", 20, 150, 50, 180, 80 - 20, label_Click));
            lbarray.Add(new LBclass(this, "lb_ID", "아이디", 10, 80, 20, 80, 250 - 50, label_Click));
            lbarray.Add(new LBclass(this, "lb_Pass", "비밀번호", 10, 80, 20, 80, 300 - 50, label_Click));

            for (int i = 0; i < lbarray.Count; i++)
            {

                Label lb = comm.lb((LBclass)lbarray[i]);

                if (lb.Name == "lb_Login")
                {
                    lb.ForeColor = Color.Green;
                    lb.Font = new Font("견명조", 32F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                }

                pan1.Controls.Add(lb);
            }
            //=================================================================================================================================================



            Tb1 = comm.txtbox(new TXTBOXclass(this, "ID", "", 150, 20, 175, 245 - 50, Tb_click));
            Tb2 = comm.txtbox(new TXTBOXclass(this, "Pass", "", 150, 20, 175, 295 - 50, Tb_click));
            pan1.Controls.Add(Tb1);
            pan1.Controls.Add(Tb2);


            //=================================================================================================================================================


            pan1.Height = 380;
            pan1.Width = 500;
            pan1.Location = new Point(470, 120);
            pan1.BackColor = Color.FromArgb(218, 234, 244);


            Controls.Add(pan1);
            //==================================================================================================================================================
            // BTNclass bt1 = new BTNclass(this, "버튼Name", "버튼Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 버튼클릭이벤트);
            ArrayList btnArray = new ArrayList();
            btnArray.Add(new BTNclass(this, "로그인", "로그인", 100, 80, 345, 240 - 50, btn1_Click));
            btnArray.Add(new BTNclass(this, "회원가입", "회원가입", 100, 40, 345, 320 - 50, btn2_Click));
            //btnArray.Add(new BTNclass(this, "뒤로가기", "←", 50, 40, 450, 0, btn3_Click));



            for (int i = 0; i < btnArray.Count; i++)
            {
                Button btn = comm.btn((BTNclass)btnArray[i]);

                if (btn.Name == "로그인")
                {
                    btn.Font = new Font("견명조", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.FromArgb(80, 200, 223);
                    btn.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, btn.Width, btn.Height, 15, 15));
                    btn.BackColor = Color.FromArgb(114, 241, 168);  // rgb(218,234,244)
                }
                else if (btn.Name == "회원가입")
                {
                    btn.Font = new Font("견명조", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.FromArgb(80, 200, 223);
                    btn.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, btn.Width, btn.Height, 15, 15));
                    btn.BackColor = Color.FromArgb(114, 241, 168);  // rgb(218,234,244)
                }
                pan1.Controls.Add(btn);
            }
            //=================================================================================================================================================
        }

        private void Tb_click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

            if (Tb2.Text == PW_Select(Tb1.Text))
            {
                // MessageBox.Show("로그인 성공");

                form.lb_Logout.Show();

                Hashtable user_info = User_Number_Member_Rank_Chk_API(Tb1.Text, Tb2.Text);
                user_Number = Convert.ToInt32(user_info["user_Number"].ToString());
                member_rank = Convert.ToInt32(user_info["member_rank"].ToString());

                //MessageBox.Show("user_Number : " + user_Number.ToString() + " member_rank : " + member_rank.ToString());

                this.Hide();
                if (member_rank == 1)
                {
                    form.user1.Show();
                    form.btn1.Show();
                    form.btn2.Show();
                    form.btn3.Show();
                    form.btn.Show();
                    form.Login.Hide();
                    form.Signup.Hide();


                }
                if (member_rank == 0)
                {
                    form.user1.Hide();
                    form.user1.Dispose();
                    BOOK_INFO_FORM login_user1 = new BOOK_INFO_FORM(form);
                    //user1.FormBorderStyle = FormBorderStyle.None;
                    login_user1.TopLevel = false;
                    login_user1.TopMost = true;
                    login_user1.MdiParent = form;
                    login_user1.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
                    form.panel1.Controls.Add(login_user1);
                    form.user1 = login_user1;

                    form.user1.Show();
                    form.btn5.Show();
                    form.btn6.Show();
                    form.btn7.Show();
                    form.btn.Show();
                    form.Login.Hide();
                    form.Signup.Hide();


                }
                if (member_rank == 4)
                {
                    form.lb_Login.Show();
                    form.lb_Signup.Show();
                }
                else
                {
                    form.lb_Login.Hide();
                    form.lb_Signup.Hide();
                }



            }

            else
            {
                fail fail = new fail("아이디 또는 비밀번호가 틀립니다.");
                fail.ShowDialog();
            }

            
        }

        public int Member_rank
        {
            get
            {
                return member_rank;
            }
            set
            {
                member_rank = value;
            }
        }

        public int User_Number
        {
            get
            {
                return user_Number;
            }
            set
            {
                user_Number = value;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Signup.Show();
        }

        private void btn3_Click(object sender, EventArgs e)
        {


        }

        public void Login_Select(string Idtext)
        {

        }

        //public string ID_Select(string Idtext)
        //{
        //    string i = ".";
        //    MySql my = new MySql();
        //    string sql = string.Format("select passwod  from signup where id = '{0}';", Idtext);
        //    MySqlDataReader sdr = my.Reader(sql);
        //    while (sdr.Read())
        //    {
        //        i = sdr.GetValue(0).ToString();
        //    }
        //    return i;
        //}

        public string PW_Select(string id)
        {
            return login_form_PW_Select_API(id);
        }

        //public bool ID_Pass_Select(string Idtext, string PWtext)
        //{
        //    try
        //    {
        //        string i = ".";
        //        MySql my = new MySql();
        //        string sql = string.Format("select user_number from signup where id = '{0}' && passwod = {1};", Idtext, PWtext);
        //        MySqlDataReader sdr = my.Reader(sql);
        //        while (sdr.Read())
        //        {
        //            i = sdr.GetValue(0).ToString();
        //        }

        //        return true;
        //    }

        //    catch
        //    {
        //        return false;
        //    }

        //}

        public string login_form_PW_Select_API(string id)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/login_form_PW_Select_API";
            string method = "POST";

            data.Add("id", id);

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            return strResult;
        }

        public Hashtable User_Number_Member_Rank_Chk_API(string id, string pw)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/User_Number_Member_Rank_Chk_API";
            string method = "POST";

            data.Add("id", id);
            data.Add("pw", pw);

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            ArrayList jList = JsonConvert.DeserializeObject<ArrayList>(strResult);
            Hashtable ht = new Hashtable();
            foreach (JObject row in jList)
            {

                foreach (JProperty col in row.Properties())
                {
                    ht.Add(col.Name, col.Value);
                }

            }

            return ht;
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
            StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
    }
}
