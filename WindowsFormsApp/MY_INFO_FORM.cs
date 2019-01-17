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

    public partial class MY_INFO_FORM : Form
    {
        string webapiUrl;
        public LOGIN_FORM Login;
        public bool YN;
        public Passwod_Check p_Check;

        public MY_INFO_FORM()
        {
            InitializeComponent();

            Load += MY_INFO_FORM_Load;
        }

        public MY_INFO_FORM(LOGIN_FORM Login)
        {
            this.Login = Login;
        }
        int sX = 1500, sY = 800; // 폼 사이즈 지정.



        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        TextBox Tb1, Tb2, Tb3, Tb4, Tb5, Tb6, Tb7, Tb8, Tb9 = new TextBox();
        Panel pan1 = new Panel();

        ComboBox combobox1;

        Button btn1;
        Button btn2;
        Button btn3;

        private bool btnYn = true;

        private void MY_INFO_FORM_Load(object sender, EventArgs e)
        {
            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
            webapiUrl = comm.WebapiUrl;

            this.BackColor = Color.FromArgb(201, 253, 223); //백컬러

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거

            /// 좌표 체크시 추가 ///
            //Point_Print();
            Login = new LOGIN_FORM();

            
            ArrayList lbarray = new ArrayList();
            ArrayList Tbarray = new ArrayList();
            ArrayList btnArray = new ArrayList();
            lbarray.Add(new LBclass(this, "lb_ID", "아이디", 10, 150, 20, 20, 60, label_Click));
            lbarray.Add(new LBclass(this, "lb_Pass", "비밀번호", 10, 150, 20, 20, 120, label_Click));
            lbarray.Add(new LBclass(this, "lb_PassCon", "이름", 10, 50, 20, 20, 180, label_Click));
            lbarray.Add(new LBclass(this, "lb_Name", "성별", 10, 150, 20, 20, 240, label_Click));
            lbarray.Add(new LBclass(this, "lb_Gender", "생일", 10, 150, 20, 20, 300, label_Click));
            lbarray.Add(new LBclass(this, "lb_Birth", "이메일", 10, 150, 20, 20, 360, label_Click));
            lbarray.Add(new LBclass(this, "lb_email", "휴대폰", 10, 150, 20, 20, 420, label_Click));
            lbarray.Add(new LBclass(this, "lb_Phon", "주소", 10, 150, 20, 20, 480, label_Click));

            //Tbarray.Add(new TXTBOXclass(this, "ID", "", 150, 20, 180, 60, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Pass", "", 150, 20, 180, 120, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "PassCon", "", 150, 20, 180, 180, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Name", "", 150, 20, 180, 240, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Gender", "", 150, 20, 180, 300, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Birth", "", 150, 20, 180, 360, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "email", "", 150, 20, 180, 420, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Phon", "", 150, 20, 180, 480, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "addres", "", 150, 20, 180, 540, Tb_click));

            Tb1 = comm.txtbox(new TXTBOXclass(this, "ID", "", 150, 20, 180, 60 - 1, Tb_click));
            Tb2 = comm.txtbox(new TXTBOXclass(this, "Pass", "", 150, 20, 180, 120 - 1, Tb_click));
            Tb3 = comm.txtbox(new TXTBOXclass(this, "name", "", 150, 20, 180, 180 - 1, Tb_click));
            Tb4 = comm.txtbox(new TXTBOXclass(this, "Name", "", 150, 20, 180, 240 - 1, Tb_click));
            Tb5 = comm.txtbox(new TXTBOXclass(this, "Gender", "", 150, 20, 180, 300 - 1, Tb_click));
            Tb6 = comm.txtbox(new TXTBOXclass(this, "Birth", "", 150, 20, 180, 360 - 1, Tb_click));
            Tb7 = comm.txtbox(new TXTBOXclass(this, "email", "", 150, 20, 180, 420 - 1, Tb_click));
            Tb8 = comm.txtbox(new TXTBOXclass(this, "Phon", "", 150, 20, 180, 480 - 1, Tb_click));


            //combobox1 = comm.comboBox(new COMBOBOXclass(this, "ComboBox1", 50, 100, 230, 300 - 1, ComboBox_SelectedIndexChanged, 5, "01", "02", "03", "04", "05"));
            //Tb9 = comm.txtbox(new TXTBOXclass(this, "Gender1", "", 40, 20, 290, 300 - 1, Tb_click));


            //pan1.Controls.Add(Tb9);
            //pan1.Controls.Add(combobox1);
            //combobox1.Items.Add("06");
            //combobox1.Items.Add("07");
            //combobox1.Items.Add("08");
            //combobox1.Items.Add("09");
            //combobox1.Items.Add("10");
            //combobox1.Items.Add("11");
            //combobox1.Items.Add("12");
            //combobox1.Text = "월";


            pan1.Controls.Add(Tb1);
            pan1.Controls.Add(Tb2);
            pan1.Controls.Add(Tb3);
            pan1.Controls.Add(Tb4);
            pan1.Controls.Add(Tb5);
            pan1.Controls.Add(Tb6);
            pan1.Controls.Add(Tb7);
            pan1.Controls.Add(Tb8);


            //=================================================================================================================================================


            pan1.Height = 650;
            pan1.Width = 500;
            pan1.Location = new Point(470, 50);
            pan1.BackColor = Color.FromArgb(218, 234, 244);

            Controls.Add(pan1);
            //==================================================================================================================================================


            //버튼==============================================================================================================================================

            // BTNclass bt1 = new BTNclass(this, "버튼Name", "버튼Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 버튼클릭이벤트);



            btn1 = comm.btn(new BTNclass(this, "비밀번호 변경", "비밀번호 변경", 100, 50, 100, 580, btn1_Click));
            btn2 = comm.btn(new BTNclass(this, "정보수정", "정보수정", 100, 50, 300, 580, btn2_Click));
            btn3 = comm.btn(new BTNclass(this, "취소", "취소", 100, 50, 400, 580, btn3_Click));

            pan1.Controls.Add(btn1);
            pan1.Controls.Add(btn2);
            pan1.Controls.Add(btn3);
            btn3.Hide();
            //for (int i = 0; i < btnArray.Count; i++)
            //{
            //    btn = comm.btn((BTNclass)btnArray[i]);

            //    if (btn.Name == "비밀번호 변경")
            //    {
            //        btn.Font = new Font("견명조", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
            //        btn.FlatStyle = FlatStyle.Flat;
            //        btn.ForeColor = Color.LawnGreen;
            //        btn.BackColor = Color.ForestGreen;
            //    }
            //    else if (btn.Name == "정보수정")
            //    {
            //        btn.Font = new Font("견명조", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
            //        btn.FlatStyle = FlatStyle.Flat;
            //        btn.ForeColor = Color.LawnGreen;
            //        btn.BackColor = Color.ForestGreen;
            //    }

            //    else if (btn.Name == "취소")
            //    {
            //        btn.Font = new Font("견명조", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
            //        btn.FlatStyle = FlatStyle.Flat;
            //        btn.ForeColor = Color.LawnGreen;
            //        btn.BackColor = Color.ForestGreen;
            //    }
            //    pan1.Controls.Add(btn);
            //}
            //==================================================================================================================================================
            //기본 띄어지는 유저정보

            List_View();



            Tb1.ReadOnly = ReadYn();
            Tb2.ReadOnly = ReadYn();
            Tb3.ReadOnly = ReadYn();
            Tb4.ReadOnly = ReadYn();
            Tb5.ReadOnly = ReadYn();
            Tb6.ReadOnly = ReadYn();
            Tb7.ReadOnly = ReadYn();
            Tb8.ReadOnly = ReadYn();



            //==================================================================================================================================================



            //==================================================================================================================================================
            //for (int i = 0; i < Tbarray.Count; i++)
            //{
            //    tb = comm.txtbox((TXTBOXclass)Tbarray[i]);

            //    Controls.Add(tb);
            //}

            for (int i = 0; i < lbarray.Count; i++)
            {
                Label lb = comm.lb((LBclass)lbarray[i]);

                pan1.Controls.Add(lb);
            }


        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void List_View()
        {
            foreach (Hashtable ht in GetSelect(Login.User_Number.ToString()))
            {
                Tb1.Text = (ht["id"].ToString());
                Tb2.Text = "************";
                Tb3.Text = (ht["name"].ToString());
                Tb4.Text = (ht["gender"].ToString());
                Tb5.Text = (ht["birthday"].ToString());
                Tb6.Text = (ht["email"].ToString());
                Tb7.Text = (ht["phone_number"].ToString());
                Tb8.Text = (ht["address"].ToString());
            }
            Tb5.Text = Tb5.Text.Substring(0, 10);
        }

        private bool ReadYn()
        {
            return true;
        }

        private void Tb_click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e) //비밀번호 버튼 클릭
        {
            if (btn1.Text == "비밀번호 변경")
            {
                p_Check = new Passwod_Check(this);
                p_Check.ShowDialog();

                if (p_Check.Yn)
                {
                    btn3.Show();
                    Tb2.ReadOnly = false;
                    foreach (Hashtable ht in GetSelect(Login.User_Number.ToString()))
                    {
                        Tb2.Text = (ht["passwod"].ToString());
                        Tb6.Text = (ht["email"].ToString());
                        Tb7.Text = (ht["phone_number"].ToString());
                        Tb8.Text = (ht["address"].ToString());
                    }
                    Tb5.Text = Tb5.Text.Substring(0, 10);
                    Tb6.ReadOnly = true;
                    Tb7.ReadOnly = true;
                    Tb8.ReadOnly = true;
                    btnYn = false;
                    btn2.Text = "정보수정";
                    btn1.Text = "변경완료";
                    p_Check.Yn = false;
                }
                p_Check.Close();

            }
            else if (btn1.Text == "변경완료")
            {
                

                GetUPDATE_Pass(Tb2.Text, Login.User_Number.ToString());

                List_View();

                Tb2.ReadOnly = true;


                btnYn = true;

                btn1.Text = "비밀번호 변경";
                btn2.Text = "정보수정";
                btn3.Hide();
            }
        }

        private void btn2_Click(object sender, EventArgs e) //정보수정 버튼 클릭
        {
            if (btn2.Text == "정보수정")
            {
                p_Check = new Passwod_Check(this);
                p_Check.ShowDialog();

                if (p_Check.Yn)
                {
                    foreach (Hashtable ht in GetSelect(Login.User_Number.ToString()))
                    {
                        Tb2.Text = "************";
                    }
                    btn3.Show();
                    Tb6.ReadOnly = false;
                    Tb7.ReadOnly = false;
                    Tb8.ReadOnly = false;
                    Tb2.ReadOnly = true;
                    btnYn = false;
                    btn1.Text = "비밀번호 변경";
                    btn2.Text = "수정완료";
                }
                p_Check.Close();

            }
            else if (btn2.Text == "수정완료")
            {
                GetUPDATE(Tb6.Text, Tb7.Text, Tb8.Text, Login.User_Number.ToString());

                Tb6.ReadOnly = true;
                Tb7.ReadOnly = true;
                Tb8.ReadOnly = true;

                btn2.Text = "정보수정";
                btn1.Text = "비밀번호 변경";
                btnYn = true;
                btn3.Hide();
            }
        }

        private void btn3_Click(object sender, EventArgs e) //취소 버튼 클릭
        {
            if (!btnYn)
            {

                List_View();

                Tb2.ReadOnly = true;
                Tb6.ReadOnly = true;
                Tb7.ReadOnly = true;
                Tb8.ReadOnly = true;

                btn2.Text = "정보수정";
                btn1.Text = "비밀번호 변경";
                btn3.Hide();
                btnYn = true;

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

        private void label_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool GetUPDATE_API(string email, string Phon, string addres, string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/GetUPDATE_API";
            string method = "POST";

            data.Add("email", email);
            data.Add("Phon", Phon);
            data.Add("addres", addres);
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

        public bool GetUPDATE_Pass_API(string passwod, string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/GetUPDATE_Pass_API";
            string method = "POST";

            data.Add("passwod", passwod);
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

        public string user_ID_Select_API(string PWtext)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/user_ID_Select_API";
            string method = "POST";

            data.Add("PWtext", PWtext);

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            return strResult;
        }


        public ArrayList signup_user_number_GetSelect_API(string user)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/signup_user_number_GetSelect_API";
            string method = "POST";


            data.Add("user", user);

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

        public void GetUPDATE(string email, string Phon, string addres, string user_number)
        {

            if (GetUPDATE_API(email, Phon, addres, user_number))
            {
                check check = new check();
                check.ShowDialog();
            }
            else
            {
                fail fail = new fail("수정 실패");
                fail.ShowDialog();
            }


        }

        public void GetUPDATE_Pass(string passwod, string user_number)
        {

            if (GetUPDATE_Pass_API(passwod, user_number))
            {
                check check = new check();
                check.ShowDialog();
            }
            else
            {
                fail fail = new fail("수정 실패");
                fail.ShowDialog();
            }

        }

        public string user_Select(string PWtext)
        {
            return user_ID_Select_API(PWtext);
        }

        public ArrayList GetSelect(string user)
        {
            return signup_user_number_GetSelect_API(user);
        }

    }
}
