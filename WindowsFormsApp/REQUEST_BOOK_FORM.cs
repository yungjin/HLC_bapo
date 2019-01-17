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
    public partial class REQUEST_BOOK_FORM : Form
    {
        string webapiUrl;


        int sX = 580, sY = 480; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////

        TextBox Textbox1;
        TextBox Textbox2;
        TextBox Textbox3;
        TextBox Textbox4;


        public REQUEST_BOOK_FORM()
        {
            InitializeComponent();

            Load += REQUEST_BOOK_FORM_Load;
        }

        private void REQUEST_BOOK_FORM_Load(object sender, EventArgs e)
        {
            COMMON_Create_Ctl comm = new COMMON_Create_Ctl();
            webapiUrl = comm.WebapiUrl;

            // 테두리 색깔 추가
            this.Paint += new PaintEventHandler(UserControl1_Paint);

            //(좌측상단여백, 우측상단여백, 컨트롤 넓이, 컨트롤 높이, 가로 모서리 원기울기, 세로 모서리 원기울기)
            //this.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, this.Width, this.Height, 15, 15));

            FormBorderStyle = FormBorderStyle.None; //폼 상단 표시줄 제거

            this.BackColor = Color.FromArgb(218, 234, 244);

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.

            /// 좌표 체크시 추가 ///
            //Point_Print();

            

            /// 라벨 ArrayList
            ArrayList labelArr = new ArrayList();
            labelArr.Add(new LBclass(this, "입고요청상단", "입고 요청", 26, 200, 40, 40, 40, label_Click));
            labelArr.Add(new LBclass(this, "제목", "제목", 20, 80, 40, 46, 130, label_Click));
            labelArr.Add(new LBclass(this, "저자", "저자", 20, 80, 40, 46, 180, label_Click));
            labelArr.Add(new LBclass(this, "출판사", "출판사", 20, 80, 40, 46, 230, label_Click));
            labelArr.Add(new LBclass(this, "장르", "장르", 20, 80, 40, 46, 280, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 20, 20, 30, 140, 130, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 20, 20, 30, 140, 180, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 20, 20, 30, 140, 230, label_Click));
            labelArr.Add(new LBclass(this, "", ":", 20, 20, 30, 140, 280, label_Click));

            for (int i = 0; i < labelArr.Count; i++)
            {
                Label 라벨 = comm.lb((LBclass)labelArr[i]);

                if (라벨.Name == "입고요청상단")
                {
                    라벨.Font = new Font("신명조", 30, FontStyle.Bold);
                }
                else
                {
                    라벨.Font = new Font("신명조", 20, FontStyle.Bold);
                }
                Controls.Add(라벨);
            }

            // 텍스트박스 ArrayList
            ArrayList TextBoxArr = new ArrayList();
            TextBoxArr.Add(new TXTBOXclass(this, "입고텍스트제목", "", 330, 40, 200, 135, txtbox_Click));
            TextBoxArr.Add(new TXTBOXclass(this, "입고텍스트저자", "", 330, 40, 200, 185, txtbox_Click));
            TextBoxArr.Add(new TXTBOXclass(this, "입고텍스트출판사", "", 330, 40, 200, 235, txtbox_Click));
            TextBoxArr.Add(new TXTBOXclass(this, "입고텍스트장르", "", 330, 40, 200, 285, txtbox_Click));

            for (int i = 0; i < TextBoxArr.Count; i++)
            {
                TextBox 텍스트박스 = comm.txtbox((TXTBOXclass)TextBoxArr[i]);
                텍스트박스.Font = new Font(텍스트박스.Font.Name, 15, FontStyle.Bold);

                if (텍스트박스.Name == "입고텍스트제목")
                {
                    Textbox1 = 텍스트박스;
                }
                else if (텍스트박스.Name == "입고텍스트저자")
                {
                    Textbox2 = 텍스트박스;
                }
                else if (텍스트박스.Name == "입고텍스트출판사")
                {
                    Textbox3 = 텍스트박스;
                }
                else if (텍스트박스.Name == "입고텍스트장르")
                {
                    Textbox4 = 텍스트박스;
                }

                Controls.Add(텍스트박스);
            }


            ArrayList btnArray = new ArrayList();
            btnArray.Add(new BTNclass(this, "등록", "등록", 120, 50, 280, 380, btn_Click));
            btnArray.Add(new BTNclass(this, "취소", "취소", 120, 50, 415, 380, btn_Click));

            for (int i = 0; i < btnArray.Count; i++)
            {
                Button 버튼 = comm.btn((BTNclass)btnArray[i]);

                버튼.Font = new Font("견명조", 24F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));  // FontStyle.Regular                
                버튼.BackColor = Color.FromArgb(50, 178, 223);
                버튼.FlatStyle = FlatStyle.Flat;
                버튼.ForeColor = Color.White;
                버튼.Region = Region.FromHrgn(COMMON_Create_Ctl.CreateRoundRectRgn(2, 2, 버튼.Width, 버튼.Height, 18, 18));

                Controls.Add(버튼);
            }

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

            ///  버튼 설정. 
            if (button.Name == "등록")
            {
                if (Textbox1.Text == "" || Textbox2.Text == "" || Textbox3.Text == "" || Textbox4.Text == "")
                {
                    fail fail = new fail("입력칸을 모두 채워주세요");
                    fail.ShowDialog();
                    return;
                }

                LOGIN_FORM login = new LOGIN_FORM();


                if (request_book_form_request_register(Textbox1.Text, Textbox2.Text, Textbox3.Text, Textbox4.Text, login.User_Number.ToString()))
                {
                    fail fail = new fail("요청 완료 되었습니다");
                    fail.ShowDialog();

                }
                else
                {
                    fail fail = new fail("요청 실패");
                    fail.ShowDialog();
                }
            }
            else if (button.Name == "취소")
            {
                this.Close();
            }
        }

        public bool request_book_form_request_register(string title, string author, string publisher, string genre, string user_number)
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/request_book_form_request_register";
            string method = "POST";


            data.Add("title", title);
            data.Add("author", author);
            data.Add("publisher", publisher);
            data.Add("genre", genre);
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


    }
}