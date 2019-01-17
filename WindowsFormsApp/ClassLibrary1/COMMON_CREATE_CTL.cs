using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{

    public class COMMON_Create_Ctl
    {
        string webapiUrl = "192.168.3.25:5000";

        public ListView listView(LISTVIEWclass lstView_obj)
        {
            ListView listView = new ListView();
            for (int i = 0; i < lstView_obj.ToTal_CNT; i++)
            {
                ColumnHeader columnHeader = new ColumnHeader();
                columnHeader.Text = lstView_obj.ColName_ArrayList[i].ToString();
                columnHeader.Width = Convert.ToInt32(lstView_obj.ColWidth_ArrayList[i]);
                columnHeader.TextAlign = HorizontalAlignment.Center;

                listView.Columns.Add(columnHeader);

                // lv.Columns.Add("No", 100, HorizontalAlignment.Center); // 위 3줄 대체 가능.

            }


            //listView.BackColor = Color.White;                    
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.MultiSelect = false;
            listView.Location = new Point(lstView_obj.PX, lstView_obj.PY);
            listView.Name = lstView_obj.Name;
            listView.Size = new Size(lstView_obj.SX, lstView_obj.SY);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.MouseClick += lstView_obj.eh_listview_Click;
            listView.MouseDoubleClick += lstView_obj.eh_listview_DoubleClick;

            return listView;
        }

        public ComboBox comboBox(COMBOBOXclass combox_obj)
        {
            ComboBox combobox = new ComboBox();
            for (int i = 0; i < combox_obj.ToTal_CNT; i++)
            {
                combobox.Items.Add(combox_obj.List_ArrayList[i]);
            }

            combobox.SelectedIndexChanged += combox_obj.eh_combobox;
            combobox.Name = combox_obj.Name;
            combobox.Location = new Point(combox_obj.PX, combox_obj.PY);
            combobox.Size = new Size(combox_obj.SX, combox_obj.SY);

            return combobox;
        }


        public Button btn(BTNclass btn_obj)
        {
            Button btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = btn_obj.Name;
            btn.Text = btn_obj.Text;
            btn.Size = new Size(btn_obj.SX, btn_obj.SY);
            btn.Location = new Point(btn_obj.PX, btn_obj.PY);
            btn.Cursor = Cursors.Hand;
            btn.Click += btn_obj.eh_btn;
            //btn.BackColor = Color.Transparent;  // 버튼배경 투명 처리.

            return btn;
        }


        public Label lb(LBclass lb_obj)
        {
            Label label = new Label();
            label.Name = lb_obj.Name;
            label.Text = lb_obj.Text;
            label.Size = new Size(lb_obj.SX, lb_obj.SY);
            label.Font = new Font("굴림", lb_obj.FSize, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
            label.Location = new Point(lb_obj.PX, lb_obj.PY);
            label.BackColor = Color.Transparent;
            label.Click += lb_obj.eh_label;
            return label;
        }

        public TextBox txtbox(TXTBOXclass txtbox_obj)
        {
            TextBox txtbox = new TextBox();
            txtbox.Name = txtbox_obj.Name;
            txtbox.Text = txtbox_obj.Text;
            txtbox.AcceptsReturn = true;
            txtbox.AcceptsTab = true;
            txtbox.Size = new Size(txtbox_obj.SX, txtbox_obj.SY);
            txtbox.Location = new Point(txtbox_obj.PX, txtbox_obj.PY);
            txtbox.Cursor = Cursors.Hand;
            txtbox.Click += txtbox_obj.eh_txtbox;
            //txtbox.ReadOnly = true;  // TextBox 비활성화

            return txtbox;
        }

        /// <summary>
        ///  w
        /// </summary>
        /// <param name="btn_obj"></param>
        /// <returns></returns>
        public CheckBox chkbox(CHKBOXclass btn_obj)
        {
            CheckBox chkbox = new CheckBox();
            chkbox.AutoSize = true;
            chkbox.Name = btn_obj.Name;
            chkbox.Text = btn_obj.Text;
            chkbox.Size = new Size(btn_obj.SX, btn_obj.SY);
            chkbox.Location = new Point(btn_obj.PX, btn_obj.PY);
            chkbox.Click += btn_obj.eh_chkbox;
            chkbox.UseVisualStyleBackColor = true;
            //chkbox.TabIndex = 0;  // 탭 눌를경우 인덱스 순서를 지정할때 사용.

            return chkbox;
        }

        public RadioButton radio_btn(RADIOclass radio_obj)
        {
            RadioButton radio_button = new RadioButton();
            radio_button.Name = radio_obj.Name;
            radio_button.Text = radio_obj.Text;
            radio_button.Size = new Size(radio_obj.SX, radio_obj.SY);
            radio_button.Location = new Point(radio_obj.PX, radio_obj.PY);
            radio_button.Click += radio_obj.eh_radio;
            //radio1.Checked = true;  // RadioButton 체크로 설정.

            return radio_button;
        }

        public PictureBox static_PictureBox(PICTUREBOXclass picturbox_obj)
        {
            PictureBox picturebox = new PictureBox();
            picturebox.Name = picturbox_obj.Name;
            picturebox.Text = picturbox_obj.Text;
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.Location = new Point(picturbox_obj.PX, picturbox_obj.PY);
            Image picturebox_myImage = (Image)Properties.Resources.ResourceManager.GetObject(picturbox_obj.Image_Name); // global::WindowsFormsHiWeather.Properties.Resources.config_image; 
            //picturebox.ClientSize = new Size(picturbox_obj.SX, picturbox_obj.SY);
            picturebox.Size = new Size(picturbox_obj.SX, picturbox_obj.SY);
            picturebox.Image = (Image)picturebox_myImage;
            picturebox.Click += picturbox_obj.eh_picturbox;
            //radio1.Checked = true;  // RadioButton 체크로 설정.

            return picturebox;
        }

        public PictureBox load_PictureBox(PICTUREBOXclass picturbox_obj)
        {
            PictureBox picturebox = new PictureBox();
            picturebox.Name = picturbox_obj.Name;
            picturebox.Text = picturbox_obj.Text;
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.Location = new Point(picturbox_obj.PX, picturbox_obj.PY);
            //Image picturebox_myImage = (Image)Properties.Resources.ResourceManager.GetObject(picturbox_obj.Image_Name); // global::WindowsFormsHiWeather.Properties.Resources.config_image; 
            //picturebox.ClientSize = new Size(picturbox_obj.SX, picturbox_obj.SY);
            picturebox.Size = new Size(picturbox_obj.SX, picturbox_obj.SY);
            picturebox.ImageLocation = "http://192.168.3.25:5000/" + picturbox_obj.Image_Name; // FTP에서불러올파일이름;
            picturebox.Click += picturbox_obj.eh_picturbox;
            //radio1.Checked = true;  // RadioButton 체크로 설정.

            return picturebox;
        }


        public Panel panel(PANELclass panel_obj)
        {
            Panel panel = new Panel();
            panel.Name = panel_obj.Name;
            panel.Text = panel_obj.Text;
            panel.Size = new Size(panel_obj.SX, panel_obj.SY);
            panel.Location = new Point(panel_obj.PX, panel_obj.PY);
            if (panel_obj.eh_panel != null)
            { panel.MouseMove += panel_obj.eh_panel; }  // MouseEventHandler 있는경우 추가.           
            panel.BackColor = Color.AliceBlue;   // 배경에 색상 지정.

            return panel;
        }


        public TabControl tab_ctl(TABCTLclass tabctl_obj)
        {
            TabControl tabcontol = new TabControl();
            tabcontol.Name = tabctl_obj.Name;
            tabcontol.Text = tabctl_obj.Text;
            tabcontol.Size = new Size(tabctl_obj.SX, tabctl_obj.SY);
            tabcontol.Location = new Point(tabctl_obj.PX, tabctl_obj.PY);
            if (tabctl_obj.eh_tabctl != null)
            { tabcontol.MouseMove += tabctl_obj.eh_tabctl; } // MouseEventHandler 있는경우 추가. 
            tabcontol.SelectedIndex = 0; // 탭 기본선택 - 첫번째 페이지 설정 [0].
            tabcontol.ItemSize = new Size(0, tabctl_obj.HT);  // 탭 선택하는부분 높이 지정.

            return tabcontol;
        }

        public TabPage tab_page(TABPAGEclass tabpg_obj)
        {
            TabPage tabpage = new TabPage();
            tabpage.Name = tabpg_obj.Name;
            tabpage.Text = tabpg_obj.Text;
            tabpage.Size = new Size(tabpg_obj.SX, tabpg_obj.SY);
            tabpage.Location = new Point(tabpg_obj.PX, tabpg_obj.PY);
            tabpage.TabIndex = 0;
            if (tabpg_obj.eh_tabpage != null)
            { tabpage.MouseMove += tabpg_obj.eh_tabpage; } // MouseEventHandler 있는경우 추가. 
            tabpage.BackColor = Color.AliceBlue;

            return tabpage;
        }

        public void delay_rental_check()
        {
            try
            {
                bool status = common_create_ctl_delay_rental_check();

                if (status)
                {
                    // MessageBox.Show("미반납 상태 업데이트 완료");
                }
                else
                {
                    //MessageBox.Show("미반납 상태 업데이트 실패");
                }
            }
            catch (Exception)
            {

            }


        }

        //public ArrayList common_create_ctl_delay_rental_check()
        public bool common_create_ctl_delay_rental_check()
        {
            WebClient client = new WebClient();
            NameValueCollection data = new NameValueCollection();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            client.Encoding = Encoding.UTF8;

            string url = "http://" + webapiUrl + "/common_create_ctl_delay_rental_check";
            string method = "POST";

            data.Add("rental_status", "1");

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

        public Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return (Image)destImage;
        }


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]            //Dll임포트
        public static extern IntPtr CreateRoundRectRgn                            //파라미터
        (
            //(좌측상단여백, 우측상단여백, 컨트롤 넓이, 컨트롤 높이, 가로 모서리 원기울기, 세로 모서리 원기울기)
            int nLeftRect,      // x-coordinate of upper-left corner
            int nTopRect,       // y-coordinate of upper-left corner
            int nRightRect,     // x-coordinate of lower-right corner
            int nBottomRect,    // y-coordinate of lower-right corner   
            int nWidthEllipse,  // height of ellipse
            int nHeightEllipse  // width of ellipse  
        );


        public string WebapiUrl
        {
            get
            {
                return webapiUrl;
            }
        }



    }
}