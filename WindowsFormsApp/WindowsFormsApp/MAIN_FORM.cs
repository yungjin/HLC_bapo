using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp
{
    public partial class MAIN_FORM : Form
    {
        public Panel panel1;

        PictureBox pictureBox;
        // MDI 자식폼 테스트 
        Sample_Form Child1 = new Sample_Form();
        public Label lb_Login;
        public Label lb_Signup;
        public Label lb_Logout;
        public Button btn;
        public Button btn1;
        public Button btn2;
        public Button btn3;


        public Button btn5;
        public Button btn6;
        public Button btn7;
        //로긴/회원가입==================================================================================================
        public LOGIN_FORM Login;
        public SIGNUP_FORM Signup;
        public LOGIN_FORM login_frm;

        //유저 폼 =======================================================================================================
        public BOOK_INFO_FORM user1;
        public RENTAL_INFO_FORM user2 = new RENTAL_INFO_FORM();
        public MY_INFO_FORM user3 = new MY_INFO_FORM();
        public BOOK_LOC_FORM user4 = new BOOK_LOC_FORM();
        //관리자 폼======================================================================================================

        public USER_INFO_FORM root2 = new USER_INFO_FORM();
        public BOOK_MGT_FORM root3 = new BOOK_MGT_FORM();
        public LATE_MGT_FORM root4 = new LATE_MGT_FORM();


        //===============================================================================================================



        int sX = 1500, sY = 930; // 폼 사이즈 지정.

        ///////// 좌표 체크시 추가 /////////
        static ToolStripStatusLabel StripLb;
        StatusStrip statusStrip;
        ///////////////////////////////////


        public MAIN_FORM()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //=======================================================================================================
            user1 = new BOOK_INFO_FORM(this);
            login_frm = new LOGIN_FORM(this);
            Login = new LOGIN_FORM(this);
            Signup = new SIGNUP_FORM(this);
            //=======================================================================================================

            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            this.IsMdiContainer = true;     // MDI 설정.

            //좌표 체크시 추가  
            //Point_Print();

            // 컨트롤 객체생성. 
            COMMON_Create_Ctl comm_create_ctl = new COMMON_Create_Ctl();

            // 생성할 패널 정보 객체 생성.
            PANELclass pn1 = new PANELclass(this, "panel1", "panel_main", 1500, 780, 0, 145);

            panel1 = comm_create_ctl.panel(pn1);  // ex) 판넬만들기 :  create_ctl.CTL명(CTL값);           
            Controls.Add(panel1);  // 원하는 컨트롤에 추가함.

            BTNclass bt1 = new BTNclass(this, "유저1", "도서정보", 285, 145, 0, 0, btn1_Click);
            BTNclass bt2 = new BTNclass(this, "유저2", "대여목록", 285, 145, 285, 0, btn2_Click);
            BTNclass bt3 = new BTNclass(this, "유저3", "나의정보", 285, 145, 570, 0, btn3_Click);
            BTNclass bt4 = new BTNclass(this, "유저4", "위치정보", 285, 145, 855, 0, btn4_Click);

            BTNclass bt6 = new BTNclass(this, "관리2", "회원정보", 285, 145, 285, 0, btn6_Click);
            BTNclass bt7 = new BTNclass(this, "관리3", "도서관리", 285, 145, 570, 0, btn7_Click);
            BTNclass bt8 = new BTNclass(this, "관리4", "연체관리", 285, 145, 855, 0, btn8_Click);

            btn = comm_create_ctl.btn(bt1);
            ButtonConfig(btn, "book_info");
            btn1 = comm_create_ctl.btn(bt2);
            ButtonConfig(btn1, "rental_list");
            btn2 = comm_create_ctl.btn(bt3);
            ButtonConfig(btn2, "my_information");
            btn3 = comm_create_ctl.btn(bt4);
            ButtonConfig(btn3, "book_location");

            btn5 = comm_create_ctl.btn(bt6);
            ButtonConfig(btn5, "user_management");
            btn6 = comm_create_ctl.btn(bt7);
            ButtonConfig(btn6, "book_management");
            btn7 = comm_create_ctl.btn(bt8);
            ButtonConfig(btn7, "overdue_management");


            Controls.Add(btn);

            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);


            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btn7);

            //MessageBox.Show("login_frm.Member_rank : " + login_frm.Member_rank);

            if (login_frm.Member_rank == 4) // 비회원
            {
                user1.Show();
                btn1.Hide();
                btn2.Hide();
                btn3.Hide();

                btn5.Hide();
                btn6.Hide();
                btn7.Hide();
            }

            //else if (member_rank == 0) //관리자
            //{

            //    btn.Hide();
            //    btn1.Hide();
            //    btn2.Hide();
            //    btn3.Hide();
            //}
            //else if(member_rank == 1) //유저
            //{
            //    user1.Show();
            //    btn4.Hide();
            //    btn5.Hide();
            //    btn6.Hide();
            //    btn7.Hide();
            //}




            //라벨 ==============================================================================================================================================
            ArrayList lbarray = new ArrayList();
            lbarray.Add(new LBclass(this, "Login", "Login   /", 15, 90, 30, 1500 - 190, 10, label_Click));
            lbarray.Add(new LBclass(this, "Signup", "Signup", 15, 90, 30, 1500 - 100, 10, label2_Click));
            lbarray.Add(new LBclass(this, "Logout", "Logout", 15, 90, 30, 1500 - 100, 10, label3_Click));


            for (int i = 0; i < lbarray.Count; i++)
            {

                Label lb = comm_create_ctl.lb((LBclass)lbarray[i]);
                lb.Visible = true;
                lb.Cursor = Cursors.Hand;
                lb.Parent = pictureBox;
                lb.BackColor = Color.FromArgb(201, 253, 223);
                lb.BringToFront();
                lb.ForeColor = Color.FromArgb(39, 174, 97);

                if (lb.Name == "Login")
                {
                    lb.Font = new Font("견명조", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));

                    lb_Login = lb;
                }
                else if (lb.Name == "Signup")
                {
                    lb.Font = new Font("견명조", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                    lb_Signup = lb;
                }
                else if (lb.Name == "Logout")
                {
                    lb.Font = new Font("견명조", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                    lb_Logout = lb;
                }
                Controls.Add(lb);
            }
            lb_Logout.Hide();

            //=====================================================================================================================================================

            Logo_Load();//로고 이미지

            // Set the Parent Form of the Child window.
            //Child1.TopLevel = false;
            //Child1.TopMost = true;
            //Child1.MdiParent = this;
            //Child1.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            //panel1.Controls.Add(Child1);

            //Child2.Show();
            //Child1.Show();
            //Child1.Dispose();

            //Set the Parent Form of the Child window.

            user1.TopLevel = false;
            user1.TopMost = true;
            user1.MdiParent = this;
            user1.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(user1);

            user2.TopLevel = false;
            user2.TopMost = true;
            user2.MdiParent = this;
            user2.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(user2);

            user3.TopLevel = false;
            user3.TopMost = true;
            user3.MdiParent = this;
            user3.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(user3);

            user4.TopLevel = false;
            user4.TopMost = true;
            user4.MdiParent = this;
            user4.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(user4);

            Login.TopLevel = false;
            Login.TopMost = true;
            Login.MdiParent = this;
            Login.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(Login);

            Signup.TopLevel = false;
            Signup.TopMost = true;
            Signup.MdiParent = this;
            Signup.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(Signup);


            root2.TopLevel = false;
            root2.TopMost = true;
            root2.MdiParent = this;
            root2.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(root2);

            root3.TopLevel = false;
            root3.TopMost = true;
            root3.MdiParent = this;
            root3.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(root3);

            root4.TopLevel = false;
            root4.TopMost = true;
            root4.MdiParent = this;
            root4.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(root4);


        }



        private void Logo_Load()
        {
            pictureBox = new PictureBox();

            pictureBox.Image = (Bitmap)ClassLibrary1.Properties.Resources.ResourceManager.GetObject("logo");
            pictureBox.Location = new Point(1500 - 360, 0);
            pictureBox.Size = new Size(360, 145);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BackColor = Color.FromArgb(201, 253, 223);
            //pictureBox.Paint += new PaintEventHandler(this.pictureBox1_Paint);
            Controls.Add(pictureBox);
        }

        private void ButtonConfig(Button btn, string image_name)
        {
            btn.Font = new Font("신명조", 30.0F, FontStyle.Bold);
            btn.ForeColor = Color.White;
            Image btn_myImage;
            btn_myImage = (Image)Properties.Resources.ResourceManager.GetObject(image_name);
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(100, 100);
            imageList.Images.Add(btn_myImage);
            imageList.TransparentColor = Color.Transparent;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextAlign = ContentAlignment.MiddleRight;
            btn.ImageIndex = 0;
            btn.ImageList = imageList;
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(39, 174, 97);
        }


        private void btn1_Click(Object o, EventArgs e)
        {

            user1.Show();
            user1.Book_Info_ListView_Refresh();
            user2.Hide();
            user3.Hide();
            user4.Hide();
            root2.Hide();
            root3.Hide();
            root4.Hide();
            Login.Hide();
            Signup.Hide();

        }

        private void btn2_Click(Object o, EventArgs e)
        {
            user2.Show();
            user1.Hide();
            user3.Hide();
            user4.Hide();
            Login.Hide();
            Signup.Hide();
            user2.List_Views();

        }

        private void btn3_Click(Object o, EventArgs e)
        {
            user3.Show();
            user3.List_View();
            user2.Hide();
            user1.Hide();
            user4.Hide();
            Login.Hide();
            Signup.Hide();

        }

        private void btn4_Click(Object o, EventArgs e)
        {
            user4.Show();
            user2.Hide();
            user3.Hide();
            user1.Hide();
            Login.Hide();
            Signup.Hide();

        }


        private void btn6_Click(Object o, EventArgs e)
        {
            user1.Hide();
            root2.Show();
            root2.User_Info_ReFresh();
            root3.Hide();
            root4.Hide();
            Login.Hide();
            Signup.Hide();            

        }

        private void btn7_Click(Object o, EventArgs e)
        {
            user1.Hide();
            root2.Hide();
            root3.Show();
            root4.Hide();
            Login.Hide();
            Signup.Hide();
            root3.list_Refresh();
        }

        private void btn8_Click(Object o, EventArgs e)
        {
            user1.Hide();
            root2.Hide();
            root3.Hide();
            root4.Show();
            root4.Refresh_ListView();
            Login.Hide();
            Signup.Hide();

        }
        //로긴 회원 =======================================================================================
        private void label_Click(Object o, EventArgs e)//로긴
        {
            user1.Hide();
            Login.Show();
            Signup.Hide();
        }

        private void label2_Click(object sender, EventArgs e)//회원
        {
            user1.Hide();
            Login.Hide();
            Signup.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            login_frm.Member_rank = 4;
            login_frm.User_Number = 0;

            user1.Dispose();
            BOOK_INFO_FORM login_user1 = new BOOK_INFO_FORM(this);
            //user1.FormBorderStyle = FormBorderStyle.None;
            login_user1.TopLevel = false;
            login_user1.TopMost = true;
            login_user1.MdiParent = this;
            login_user1.Dock = DockStyle.Fill; //판넬크기에 맞게 사이즈 늘림.
            panel1.Controls.Add(login_user1);
            user1 = login_user1;

            user1.Show();
            user2.Hide();
            user3.Hide();
            user4.Hide();
            root2.Hide();
            root3.Hide();
            root4.Hide();

            btn.Show();
            btn1.Hide();
            btn2.Hide();
            btn3.Hide();
            btn5.Hide();
            btn6.Hide();
            btn7.Hide();
            //MessageBox.Show("로그아웃");

            lb_Logout.Hide();
            lb_Login.Show();
            lb_Signup.Show();

        }
        //===============================================================================================
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

        private void pictureBox1_Paint(Object o, PaintEventArgs e)
        {
            e.Graphics.DrawString(lb_Login.Text, lb_Login.Font, new SolidBrush(lb_Login.ForeColor), lb_Login.Left - pictureBox.Left, lb_Login.Top - pictureBox.Top);
            e.Graphics.DrawString(lb_Signup.Text, lb_Login.Font, new SolidBrush(lb_Signup.ForeColor), lb_Signup.Left - pictureBox.Left, lb_Signup.Top - pictureBox.Top);
            e.Graphics.DrawString(lb_Logout.Text, lb_Logout.Font, new SolidBrush(lb_Logout.ForeColor), lb_Logout.Left - pictureBox.Left, lb_Logout.Top - pictureBox.Top);
        }


        private void picturbox_Click(Object o, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Current_FORM_MouseMove(object sender, MouseEventArgs e)
        {
            // StripLb.Text = "(" + e.X + ", " + e.Y + ")";
        }
        ///////////////////////////////////////////////////////////////////////
    }
}