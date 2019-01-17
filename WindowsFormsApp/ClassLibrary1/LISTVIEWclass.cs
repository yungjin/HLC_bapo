using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class LISTVIEWclass
    {

        Form form;
        string name;
        int sX, sY, pX, pY;
        public MouseEventHandler eh_listview_Click;
        public MouseEventHandler eh_listview_DoubleClick;
        private ArrayList colname_array = new ArrayList();
        private ArrayList colwidth_array = new ArrayList();

        int total_columns_count;
        string col_name_1;
        string col_name_2;
        string col_name_3;
        string col_name_4;
        string col_name_5;
        string col_name_6;
        string col_name_7;
        string col_name_8;
        string col_name_9;
        string col_name_10;

        int col_width_1;
        int col_width_2;
        int col_width_3;
        int col_width_4;
        int col_width_5;
        int col_width_6;
        int col_width_7;
        int col_width_8;
        int col_width_9;
        int col_width_10;

        // 컬럼1개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_width_1 = col_width1;

            colname_array.Add(col_name_1);
            colwidth_array.Add(col_width1);
        }

        // 컬럼2개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1, string col_name_2, int col_width2)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_name_2 = col_name_2;

            this.col_width_1 = col_width1;
            this.col_width_2 = col_width2;

            colname_array.Add(col_name_1);
            colname_array.Add(col_name_2);

            colwidth_array.Add(col_width1);
            colwidth_array.Add(col_width2);
        }

        // 컬럼3개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1, string col_name_2, int col_width2, string col_name_3, int col_width3)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_name_2 = col_name_2;
            this.col_name_3 = col_name_3;

            this.col_width_1 = col_width1;
            this.col_width_2 = col_width2;
            this.col_width_3 = col_width3;

            colname_array.Add(col_name_1);
            colname_array.Add(col_name_2);
            colname_array.Add(col_name_3);

            colwidth_array.Add(col_width1);
            colwidth_array.Add(col_width2);
            colwidth_array.Add(col_width3);
        }

        // 컬럼4개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1, string col_name_2, int col_width2, string col_name_3, int col_width3, string col_name_4, int col_width4)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_name_2 = col_name_2;
            this.col_name_3 = col_name_3;
            this.col_name_4 = col_name_4;

            this.col_width_1 = col_width1;
            this.col_width_2 = col_width2;
            this.col_width_3 = col_width3;
            this.col_width_4 = col_width4;

            colname_array.Add(col_name_1);
            colname_array.Add(col_name_2);
            colname_array.Add(col_name_3);
            colname_array.Add(col_name_4);

            colwidth_array.Add(col_width1);
            colwidth_array.Add(col_width2);
            colwidth_array.Add(col_width3);
            colwidth_array.Add(col_width4);
        }

        // 컬럼5개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1, string col_name_2, int col_width2, string col_name_3, int col_width3, string col_name_4, int col_width4, string col_name_5, int col_width5)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_name_2 = col_name_2;
            this.col_name_3 = col_name_3;
            this.col_name_4 = col_name_4;
            this.col_name_5 = col_name_5;

            this.col_width_1 = col_width1;
            this.col_width_2 = col_width2;
            this.col_width_3 = col_width3;
            this.col_width_4 = col_width4;
            this.col_width_5 = col_width5;

            colname_array.Add(col_name_1);
            colname_array.Add(col_name_2);
            colname_array.Add(col_name_3);
            colname_array.Add(col_name_4);
            colname_array.Add(col_name_5);

            colwidth_array.Add(col_width1);
            colwidth_array.Add(col_width2);
            colwidth_array.Add(col_width3);
            colwidth_array.Add(col_width4);
            colwidth_array.Add(col_width5);
        }

        // 컬럼6개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1, string col_name_2, int col_width2, string col_name_3, int col_width3, string col_name_4, int col_width4, string col_name_5, int col_width5, string col_name_6, int col_width6)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_name_2 = col_name_2;
            this.col_name_3 = col_name_3;
            this.col_name_4 = col_name_4;
            this.col_name_5 = col_name_5;
            this.col_name_6 = col_name_6;

            this.col_width_1 = col_width1;
            this.col_width_2 = col_width2;
            this.col_width_3 = col_width3;
            this.col_width_4 = col_width4;
            this.col_width_5 = col_width5;
            this.col_width_6 = col_width6;

            colname_array.Add(col_name_1);
            colname_array.Add(col_name_2);
            colname_array.Add(col_name_3);
            colname_array.Add(col_name_4);
            colname_array.Add(col_name_5);
            colname_array.Add(col_name_6);

            colwidth_array.Add(col_width1);
            colwidth_array.Add(col_width2);
            colwidth_array.Add(col_width3);
            colwidth_array.Add(col_width4);
            colwidth_array.Add(col_width5);
            colwidth_array.Add(col_width6);
        }

        // 컬럼7개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1, string col_name_2, int col_width2, string col_name_3, int col_width3, string col_name_4, int col_width4, string col_name_5, int col_width5, string col_name_6, int col_width6, string col_name_7, int col_width7)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_name_2 = col_name_2;
            this.col_name_3 = col_name_3;
            this.col_name_4 = col_name_4;
            this.col_name_5 = col_name_5;
            this.col_name_6 = col_name_6;
            this.col_name_7 = col_name_7;

            this.col_width_1 = col_width1;
            this.col_width_2 = col_width2;
            this.col_width_3 = col_width3;
            this.col_width_4 = col_width4;
            this.col_width_5 = col_width5;
            this.col_width_6 = col_width6;
            this.col_width_7 = col_width7;

            colname_array.Add(col_name_1);
            colname_array.Add(col_name_2);
            colname_array.Add(col_name_3);
            colname_array.Add(col_name_4);
            colname_array.Add(col_name_5);
            colname_array.Add(col_name_6);
            colname_array.Add(col_name_7);

            colwidth_array.Add(col_width1);
            colwidth_array.Add(col_width2);
            colwidth_array.Add(col_width3);
            colwidth_array.Add(col_width4);
            colwidth_array.Add(col_width5);
            colwidth_array.Add(col_width6);
            colwidth_array.Add(col_width7);
        }

        // 컬럼8개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1, string col_name_2, int col_width2, string col_name_3, int col_width3, string col_name_4, int col_width4, string col_name_5, int col_width5, string col_name_6, int col_width6, string col_name_7, int col_width7, string col_name_8, int col_width8)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_name_2 = col_name_2;
            this.col_name_3 = col_name_3;
            this.col_name_4 = col_name_4;
            this.col_name_5 = col_name_5;
            this.col_name_6 = col_name_6;
            this.col_name_7 = col_name_7;
            this.col_name_8 = col_name_8;

            this.col_width_1 = col_width1;
            this.col_width_2 = col_width2;
            this.col_width_3 = col_width3;
            this.col_width_4 = col_width4;
            this.col_width_5 = col_width5;
            this.col_width_6 = col_width6;
            this.col_width_7 = col_width7;
            this.col_width_8 = col_width8;

            colname_array.Add(col_name_1);
            colname_array.Add(col_name_2);
            colname_array.Add(col_name_3);
            colname_array.Add(col_name_4);
            colname_array.Add(col_name_5);
            colname_array.Add(col_name_6);
            colname_array.Add(col_name_7);
            colname_array.Add(col_name_8);

            colwidth_array.Add(col_width1);
            colwidth_array.Add(col_width2);
            colwidth_array.Add(col_width3);
            colwidth_array.Add(col_width4);
            colwidth_array.Add(col_width5);
            colwidth_array.Add(col_width6);
            colwidth_array.Add(col_width7);
            colwidth_array.Add(col_width8);
        }

        // 컬럼9개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1, string col_name_2, int col_width2, string col_name_3, int col_width3, string col_name_4, int col_width4, string col_name_5, int col_width5, string col_name_6, int col_width6, string col_name_7, int col_width7, string col_name_8, int col_width8, string col_name_9, int col_width9)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_name_2 = col_name_2;
            this.col_name_3 = col_name_3;
            this.col_name_4 = col_name_4;
            this.col_name_5 = col_name_5;
            this.col_name_6 = col_name_6;
            this.col_name_7 = col_name_7;
            this.col_name_8 = col_name_8;
            this.col_name_9 = col_name_9;

            this.col_width_1 = col_width1;
            this.col_width_2 = col_width2;
            this.col_width_3 = col_width3;
            this.col_width_4 = col_width4;
            this.col_width_5 = col_width5;
            this.col_width_6 = col_width6;
            this.col_width_7 = col_width7;
            this.col_width_8 = col_width8;
            this.col_width_9 = col_width9;

            colname_array.Add(col_name_1);
            colname_array.Add(col_name_2);
            colname_array.Add(col_name_3);
            colname_array.Add(col_name_4);
            colname_array.Add(col_name_5);
            colname_array.Add(col_name_6);
            colname_array.Add(col_name_7);
            colname_array.Add(col_name_8);
            colname_array.Add(col_name_9);

            colwidth_array.Add(col_width1);
            colwidth_array.Add(col_width2);
            colwidth_array.Add(col_width3);
            colwidth_array.Add(col_width4);
            colwidth_array.Add(col_width5);
            colwidth_array.Add(col_width6);
            colwidth_array.Add(col_width7);
            colwidth_array.Add(col_width8);
            colwidth_array.Add(col_width9);
        }

        // 컬럼10개
        public LISTVIEWclass(Form form, string name, int sX, int sY, int pX, int pY, MouseEventHandler eh_listview_Click, MouseEventHandler eh_listview_DoubleClick, int total_columns_count, string col_name_1, int col_width1, string col_name_2, int col_width2, string col_name_3, int col_width3, string col_name_4, int col_width4, string col_name_5, int col_width5, string col_name_6, int col_width6, string col_name_7, int col_width7, string col_name_8, int col_width8, string col_name_9, int col_width9, string col_name_10, int col_width10)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_listview_Click = eh_listview_Click;
            this.eh_listview_DoubleClick = eh_listview_DoubleClick;
            this.total_columns_count = total_columns_count;
            this.col_name_1 = col_name_1;
            this.col_name_2 = col_name_2;
            this.col_name_3 = col_name_3;
            this.col_name_4 = col_name_4;
            this.col_name_5 = col_name_5;
            this.col_name_6 = col_name_6;
            this.col_name_7 = col_name_7;
            this.col_name_8 = col_name_8;
            this.col_name_9 = col_name_9;
            this.col_name_10 = col_name_10;

            this.col_width_1 = col_width1;
            this.col_width_2 = col_width2;
            this.col_width_3 = col_width3;
            this.col_width_4 = col_width4;
            this.col_width_5 = col_width5;
            this.col_width_6 = col_width6;
            this.col_width_7 = col_width7;
            this.col_width_8 = col_width8;
            this.col_width_9 = col_width9;
            this.col_width_10 = col_width10;

            colname_array.Add(col_name_1);
            colname_array.Add(col_name_2);
            colname_array.Add(col_name_3);
            colname_array.Add(col_name_4);
            colname_array.Add(col_name_5);
            colname_array.Add(col_name_6);
            colname_array.Add(col_name_7);
            colname_array.Add(col_name_8);
            colname_array.Add(col_name_9);
            colname_array.Add(col_name_10);

            colwidth_array.Add(col_width1);
            colwidth_array.Add(col_width2);
            colwidth_array.Add(col_width3);
            colwidth_array.Add(col_width4);
            colwidth_array.Add(col_width5);
            colwidth_array.Add(col_width6);
            colwidth_array.Add(col_width7);
            colwidth_array.Add(col_width8);
            colwidth_array.Add(col_width9);
            colwidth_array.Add(col_width10);
        }

        public Form Form
        {
            get { return form; }
        }

        public string Name
        {
            get { return name; }
        }
        public int SX
        {
            get { return sX; }
        }
        public int SY
        {
            get { return sY; }
        }
        public int PX
        {
            get { return pX; }
        }
        public int PY
        {
            get { return pY; }
        }

        public int ToTal_CNT
        {
            get { return total_columns_count; }
        }

        public string getCol_Name_1
        {
            get { return col_name_1; }
        }

        public string getCol_Name_2
        {
            get { return col_name_2; }
        }

        public string getCol_Name_3
        {
            get { return col_name_3; }
        }

        public string getCol_Name_4
        {
            get { return col_name_4; }
        }

        public string getCol_Name_5
        {
            get { return col_name_5; }
        }

        public string getCol_Name_6
        {
            get { return col_name_6; }
        }

        public string getCol_Name_7
        {
            get { return col_name_7; }
        }

        public string getCol_Name_8
        {
            get { return col_name_8; }
        }

        public string getCol_Name_9
        {
            get { return col_name_9; }
        }

        public string getCol_Name_10
        {
            get { return col_name_10; }
        }

        public int getcol_width_1
        {
            get { return col_width_1; }
        }

        public int getcol_width_2
        {
            get { return col_width_2; }
        }

        public int getcol_width_3
        {
            get { return col_width_3; }
        }

        public int getcol_width_4
        {
            get { return col_width_4; }
        }

        public int getcol_width_5
        {
            get { return col_width_5; }
        }

        public int getcol_width_6
        {
            get { return col_width_6; }
        }

        public int getcol_width_7
        {
            get { return col_width_7; }
        }

        public int getcol_width_8
        {
            get { return col_width_8; }
        }

        public int getcol_width_9
        {
            get { return col_width_9; }
        }

        public int getcol_width_10
        {
            get { return col_width_10; }
        }

        public ArrayList ColName_ArrayList
        {
            get { return colname_array; }
        }

        public ArrayList ColWidth_ArrayList
        {
            get { return colwidth_array; }
        }

    }
}