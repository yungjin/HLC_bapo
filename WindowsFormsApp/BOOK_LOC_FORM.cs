using System;
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
    public partial class BOOK_LOC_FORM : Form
    {
        int sX = 1500, sY = 800; // 폼 사이즈 지정.

        PictureBox pictureBox;

        public BOOK_LOC_FORM()
        {
            InitializeComponent();
            Load += BOOK_LOC_FORM_Load;
        }

        private void BOOK_LOC_FORM_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(201, 253, 223); //백컬러
            ClientSize = new Size(sX, sY);  // 폼 사이즈 지정.
            FormBorderStyle = FormBorderStyle.None;// 폼 상단 표시줄 제거
            Mape_Load(); //맵 이미지 로드
        }

        private void Mape_Load()
        {
            pictureBox = new PictureBox();

            pictureBox.Image = (Bitmap)ClassLibrary1.Properties.Resources.ResourceManager.GetObject("Map");
            pictureBox.Location = new Point(50, 25);
            pictureBox.Size = new Size(1400, 700);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox.Paint += new PaintEventHandler(this.pictureBox1_Paint);
            Controls.Add(pictureBox);
        }
    }
}
