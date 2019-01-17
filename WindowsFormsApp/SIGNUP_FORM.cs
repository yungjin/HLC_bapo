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
    public partial class SIGNUP_FORM : Form
    {
        string webapiUrl;

        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////
        public MAIN_FORM main;

        public SIGNUP_FORM(MAIN_FORM main)
        {
            InitializeComponent();
            this.main = main;
            Load += SIGNUP_FORM_Load;
        }
        TextBox Tb1, Tb2, Tb3, Tb4, Tb5, Tb6, Tb7, Tb8, Tb9 ,Tb10 = new TextBox();
        ComboBox combobox1;
        string Birth;
        Panel pan1 = new Panel();
        private void SIGNUP_FORM_Load(object sender, EventArgs e)
        {
            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
            webapiUrl = comm.WebapiUrl;

            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(201, 253, 223); //백컬러

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            //Point_Print();

            
            ArrayList lbarray = new ArrayList();
            ArrayList Tbarray = new ArrayList();
            ArrayList btnArray = new ArrayList();
            lbarray.Add(new LBclass(this, "lb1", "회원가입", 18, 200, 40, 200, 10, label_Click));
            lbarray.Add(new LBclass(this, "lb_ID", "아이디", 10, 150, 20, 20, 60, label_Click));
            lbarray.Add(new LBclass(this, "lb_Pass", "비밀번호", 10, 150, 20, 20, 120, label_Click));
            lbarray.Add(new LBclass(this, "lb_PassCon", "비밀번호 확인", 10, 150, 20, 20, 180, label_Click));
            lbarray.Add(new LBclass(this, "lb_Name", "이름", 10, 150, 20, 20, 240, label_Click));
            lbarray.Add(new LBclass(this, "lb_Gender", "성별", 10, 150, 20, 20, 300, label_Click));
            lbarray.Add(new LBclass(this, "lb_Birth", "생일", 10, 150, 20, 20, 360, label_Click));
            lbarray.Add(new LBclass(this, "lb_email", "이메일", 10, 150, 20, 20, 420, label_Click));
            lbarray.Add(new LBclass(this, "lb_Phon", "휴대폰 번호", 10, 150, 20, 20, 480, label_Click));
            lbarray.Add(new LBclass(this, "lb_addres", "주소", 10, 150, 20, 20, 540, label_Click));

            //Tbarray.Add(new TXTBOXclass(this, "ID", "", 150, 20, 180, 60, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Pass", "", 150, 20, 180, 120, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "PassCon", "", 150, 20, 180, 180, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Name", "", 150, 20, 180, 240, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Gender", "", 150, 20, 180, 300, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Birth", "", 150, 20, 180, 360, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "email", "", 150, 20, 180, 420, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "Phon", "", 150, 20, 180, 480, Tb_click));
            //Tbarray.Add(new TXTBOXclass(this, "addres", "", 150, 20, 180, 540, Tb_click));

            Tb1 = comm.txtbox(new TXTBOXclass(this, "ID", "", 200, 20, 180, 60, Tb_click));
            Tb2 = comm.txtbox(new TXTBOXclass(this, "Pass", "", 200, 20, 180, 120, Tb_click));
            Tb3 = comm.txtbox(new TXTBOXclass(this, "PassCon", "", 200, 20, 180, 180, Tb_click));
            Tb4 = comm.txtbox(new TXTBOXclass(this, "Name", "", 200, 20, 180, 240, Tb_click));
            Tb5 = comm.txtbox(new TXTBOXclass(this, "Gender", "", 200, 20, 180, 300, Tb_click));
            Tb6 = comm.txtbox(new TXTBOXclass(this, "Birth", "", 200, 20, 180, 360, Tb_click));
            Tb7 = comm.txtbox(new TXTBOXclass(this, "email", "", 200, 20, 180, 420, Tb_click));
            Tb8 = comm.txtbox(new TXTBOXclass(this, "Phon", "", 200, 20, 180, 480, Tb_click));
            Tb9 = comm.txtbox(new TXTBOXclass(this, "addres", "", 200, 20, 180, 540, Tb_click));

            //combobox1 = comm.comboBox(new COMBOBOXclass(this, "ComboBox1", 50, 100, 230, 360, ComboBox_SelectedIndexChanged, 5, "01", "02", "03", "04", "05"));
            //Tb10 = comm.txtbox(new TXTBOXclass(this, "Gender1", "", 40, 20, 290, 360, Tb_click));

            //combobox1.Items.Add("06");
            //combobox1.Items.Add("07");
            //combobox1.Items.Add("08");
            //combobox1.Items.Add("09");
            //combobox1.Items.Add("10");
            //combobox1.Items.Add("11");
            //combobox1.Items.Add("12");
            //combobox1.Text = "월";

            DateTimePicker dateTimePicker1 = new DateTimePicker();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.MinDate = new DateTime(1900, 6, 20);
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.Location = new Point(180, 360);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            

            //pan1.Controls.Add(Tb10);
            //pan1.Controls.Add(combobox1);
            pan1.Controls.Add(Tb1);
            pan1.Controls.Add(Tb2);
            pan1.Controls.Add(Tb3);
            pan1.Controls.Add(Tb4);
            pan1.Controls.Add(Tb5);
            //pan1.Controls.Add(Tb6);
            pan1.Controls.Add(dateTimePicker1);
            pan1.Controls.Add(Tb7);
            pan1.Controls.Add(Tb8);
            pan1.Controls.Add(Tb9);

            //=================================================================================================================================================


            pan1.Height = 650;
            pan1.Width = 500;
            pan1.Location = new Point(470, 50);
            pan1.BackColor = Color.FromArgb(218, 234, 244);

            Controls.Add(pan1);
            //==================================================================================================================================================

            // BTNclass bt1 = new BTNclass(this, "버튼Name", "버튼Text", 가로사이즈, 세로사이즈, 가로포인트, 세로포인트, 버튼클릭이벤트);

            btnArray.Add(new BTNclass(this, "가입", "가 입", 100, 50, 200, 580, btn1_Click));
            //btnArray.Add(new BTNclass(this, "닫기", "닫기", 100, 50, 300, 580, btn2_Click));

            for (int i = 0; i < btnArray.Count; i++)
            {
                Button btn = comm.btn((BTNclass)btnArray[i]);

                if (btn.Name == "가입")
                {
                    btn.Font = new Font("견명조", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.FromArgb(80, 200, 223);
                    btn.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, btn.Width, btn.Height, 15, 15));
                    btn.BackColor = Color.FromArgb(114, 241, 168);  // rgb(218,234,244)
                }
                else if (btn.Name == "닫기")
                {
                    btn.Font = new Font("견명조", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.ForeColor = Color.LawnGreen;
                    btn.BackColor = Color.ForestGreen;
                }
                pan1.Controls.Add(btn);
            }

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
            
        }

        private void Tb_click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (Tb2.Text == Tb3.Text)
            {
                if(Tb1.Text == "" || Tb2.Text == "" || Tb4.Text == "" || Tb5.Text == "" || Tb6.Text == "" || Tb7.Text == "" || Tb8.Text == "" || Tb9.Text == "")
                {
                    fail fail = new fail("입력칸을 모두 공백없이 채워주세요.");
                    fail.ShowDialog();
                    return;
                }
                //Birth = Tb5.Text + "-" + combobox1.Text + "-" + Tb10.Text;
                GetInsert(Tb1.Text, Tb2.Text, Tb4.Text, Tb5.Text, Tb6.Text, Tb7.Text, Tb8.Text, Tb9.Text);
            }
            else {
                fail fail = new fail("비밀번호를 확인해주세요.");
                fail.ShowDialog();
            }

        }

        private void btn2_Click(object sender, EventArgs e)
        {

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker1 = (DateTimePicker)sender;
            DateTime dt1 = dateTimePicker1.Value;
            Tb6.Text = dt1.ToShortDateString();
        }

        private void label_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void GetInsert(string ID, string Pass, string Name, string Gender, string Birth, string email, string Phon, string addres)
        {

            if (signup_form_GetInsert(ID, Pass, Name, Gender, Birth, email, Phon, addres))
            {
                check check = new check();
                check.ShowDialog();
                this.Hide();
                main.Login.Show();
            }
            else
            {
                fail fail = new fail("가입 실패");
                fail.ShowDialog();


                this.Hide();
                main.user1.Show();
            }

        }

        public bool signup_form_GetInsert(string ID, string Pass, string Name, string Gender, string Birth, string email, string Phon, string addres)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/signup_form_GetInsert";
            string method = "POST";

            data.Add("ID", ID);
            data.Add("Pass", Pass);
            data.Add("Name", Name);
            data.Add("Gender", Gender);
            data.Add("Birth", Birth);
            data.Add("email", email);
            data.Add("Phon", Phon);
            data.Add("addres", addres);

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
    }
}
