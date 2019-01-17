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
    public partial class Passwod_Check : Form
    {       
        int sX = 500, sY = 250; // 폼 사이즈 지정.
        public LOGIN_FORM Login;
        public MY_INFO_FORM my;
        public bool Yn = false;
        string webapiUrl;

        public Passwod_Check()
        {
            InitializeComponent();
            Load += Passwod_Check_Load;
        }

        public Passwod_Check(LOGIN_FORM Login)
        {

            this.Login = Login;

        }
        public Passwod_Check(MY_INFO_FORM my)
        {

            this.my = my;
            Load += Passwod_Check_Load;

        }

        COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
        TextBox Tb1;
        private void Passwod_Check_Load(object sender, EventArgs e)
        {
            webapiUrl = comm.WebapiUrl;

            Login = new LOGIN_FORM();
            my = new MY_INFO_FORM();

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            this.BackColor = Color.FromArgb(201, 253, 223); //백컬러

            Label lb = comm.lb(new LBclass(this, "lb_Pass", "비밀번호 확인", 10, 80, 20, 80, 120, label_Click));

            Tb1 = comm.txtbox(new TXTBOXclass(this, "Pass", "", 150, 20, 175, 118, Tb_click));

            Button btn = comm.btn(new BTNclass(this, "확인", "확인", 80, 40, 345, 110, btn1_Click));
            btn.Font = new Font("견명조", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.FromArgb(80, 200, 223);
            btn.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, btn.Width, btn.Height, 15, 15));
            btn.BackColor = Color.FromArgb(114, 241, 168);  // rgb(218,234,244)


            Controls.Add(btn);
            Controls.Add(Tb1);
            Controls.Add(lb);
        }

        private void btn1_Click(object sender, EventArgs e) //버튼클릭
        {
            //MessageBox.Show(Login.User_Number.ToString());

            if (Tb1.Text == PW_Select(Tb1.Text, Login.User_Number.ToString()))
            {
                Tb1.Clear();
                //MessageBox.Show("확인완료");
                this.Close();
                Yn = true;
            }
            else
            {
                Tb1.Clear();
                fail fail = new fail("인증 실패");
                fail.ShowDialog();

                Yn = false;
            }
        }

        private void Tb_click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        public string PW_Select(string PWtext, string user_number)
        {
            return Passwod_Check_PW_Select_API(PWtext, user_number);
        }

        public string Passwod_Check_PW_Select_API(string PWtext, string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/Passwod_Check_PW_Select_API";
            string method = "POST";


            data.Add("PWtext", PWtext);
            data.Add("user_number", user_number);

            byte[] result = client.UploadValues(url, method, data);
            string strResult = Encoding.UTF8.GetString(result);

            return strResult;
        }

    }
}
