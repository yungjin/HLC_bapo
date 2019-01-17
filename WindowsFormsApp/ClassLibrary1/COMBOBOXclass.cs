using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class COMBOBOXclass
    {

        Form form;
        string name;
        int sX, sY, pX, pY;
        public EventHandler eh_combobox;
        private ArrayList list_array = new ArrayList();

        int total_list_count;
        string list_name_1;
        string list_name_2;
        string list_name_3;
        string list_name_4;
        string list_name_5;
        string list_name_6;
        string list_name_7;
        string list_name_8;
        string list_name_9;
        string list_name_10;


        // List 1개
        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;

            list_array.Add(list_name_1);
        }

        // List 2개
        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1, string list_name_2)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;
            this.list_name_2 = list_name_2;

            list_array.Add(list_name_1);
            list_array.Add(list_name_2);
        }

        // List 3개
        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1, string list_name_2, string list_name_3)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;
            this.list_name_2 = list_name_2;
            this.list_name_3 = list_name_3;

            list_array.Add(list_name_1);
            list_array.Add(list_name_2);
            list_array.Add(list_name_3);
        }

        // List 4개
        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1, string list_name_2, string list_name_3, string list_name_4)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;
            this.list_name_2 = list_name_2;
            this.list_name_3 = list_name_3;
            this.list_name_4 = list_name_4;

            list_array.Add(list_name_1);
            list_array.Add(list_name_2);
            list_array.Add(list_name_3);
            list_array.Add(list_name_4);
        }

        // List 4개
        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1, string list_name_2, string list_name_3, string list_name_4, string list_name_5)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;
            this.list_name_2 = list_name_2;
            this.list_name_3 = list_name_3;
            this.list_name_4 = list_name_4;
            this.list_name_5 = list_name_5;

            list_array.Add(list_name_1);
            list_array.Add(list_name_2);
            list_array.Add(list_name_3);
            list_array.Add(list_name_4);
            list_array.Add(list_name_5);

        }

        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1, string list_name_2, string list_name_3, string list_name_4, string list_name_5, string list_name_6)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;
            this.list_name_2 = list_name_2;
            this.list_name_3 = list_name_3;
            this.list_name_4 = list_name_4;
            this.list_name_5 = list_name_5;
            this.list_name_6 = list_name_6;

            list_array.Add(list_name_1);
            list_array.Add(list_name_2);
            list_array.Add(list_name_3);
            list_array.Add(list_name_4);
            list_array.Add(list_name_5);
            list_array.Add(list_name_6);
        }

        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1, string list_name_2, string list_name_3, string list_name_4, string list_name_5, string list_name_6, string list_name_7)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;
            this.list_name_2 = list_name_2;
            this.list_name_3 = list_name_3;
            this.list_name_4 = list_name_4;
            this.list_name_5 = list_name_5;
            this.list_name_6 = list_name_6;
            this.list_name_7 = list_name_7;

            list_array.Add(list_name_1);
            list_array.Add(list_name_2);
            list_array.Add(list_name_3);
            list_array.Add(list_name_4);
            list_array.Add(list_name_5);
            list_array.Add(list_name_6);
            list_array.Add(list_name_7);
        }

        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1, string list_name_2, string list_name_3, string list_name_4, string list_name_5, string list_name_6, string list_name_7, string list_name_8)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;
            this.list_name_2 = list_name_2;
            this.list_name_3 = list_name_3;
            this.list_name_4 = list_name_4;
            this.list_name_5 = list_name_5;
            this.list_name_6 = list_name_6;
            this.list_name_7 = list_name_7;
            this.list_name_8 = list_name_8;

            list_array.Add(list_name_1);
            list_array.Add(list_name_2);
            list_array.Add(list_name_3);
            list_array.Add(list_name_4);
            list_array.Add(list_name_5);
            list_array.Add(list_name_6);
            list_array.Add(list_name_7);
            list_array.Add(list_name_8);
        }

        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1, string list_name_2, string list_name_3, string list_name_4, string list_name_5, string list_name_6, string list_name_7, string list_name_8, string list_name_9)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;
            this.list_name_2 = list_name_2;
            this.list_name_3 = list_name_3;
            this.list_name_4 = list_name_4;
            this.list_name_5 = list_name_5;
            this.list_name_6 = list_name_6;
            this.list_name_7 = list_name_7;
            this.list_name_8 = list_name_8;
            this.list_name_9 = list_name_9;

            list_array.Add(list_name_1);
            list_array.Add(list_name_2);
            list_array.Add(list_name_3);
            list_array.Add(list_name_4);
            list_array.Add(list_name_5);
            list_array.Add(list_name_6);
            list_array.Add(list_name_7);
            list_array.Add(list_name_8);
            list_array.Add(list_name_9);
        }

        public COMBOBOXclass(Form form, string name, int sX, int sY, int pX, int pY, EventHandler eh_combobox, int total_list_count, string list_name_1, string list_name_2, string list_name_3, string list_name_4, string list_name_5, string list_name_6, string list_name_7, string list_name_8, string list_name_9, string list_name_10)
        {
            this.form = form;
            this.name = name;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_combobox = eh_combobox;
            this.total_list_count = total_list_count;

            this.list_name_1 = list_name_1;
            this.list_name_2 = list_name_2;
            this.list_name_3 = list_name_3;
            this.list_name_4 = list_name_4;
            this.list_name_5 = list_name_5;
            this.list_name_6 = list_name_6;
            this.list_name_7 = list_name_7;
            this.list_name_8 = list_name_8;
            this.list_name_9 = list_name_9;
            this.list_name_10 = list_name_10;

            list_array.Add(list_name_1);
            list_array.Add(list_name_2);
            list_array.Add(list_name_3);
            list_array.Add(list_name_4);
            list_array.Add(list_name_5);
            list_array.Add(list_name_6);
            list_array.Add(list_name_7);
            list_array.Add(list_name_8);
            list_array.Add(list_name_9);
            list_array.Add(list_name_10);
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
            get { return total_list_count; }
        }

        public string getList_Name_1
        {
            get { return list_name_1; }
        }

        public string getList_Name_2
        {
            get { return list_name_2; }
        }

        public string getList_Name_3
        {
            get { return list_name_3; }
        }

        public string getList_Name_4
        {
            get { return list_name_4; }
        }

        public string getList_Name_5
        {
            get { return list_name_5; }
        }

        public string getList_Name_6
        {
            get { return list_name_6; }
        }

        public string getList_Name_7
        {
            get { return list_name_7; }
        }

        public string getList_Name_8
        {
            get { return list_name_8; }
        }

        public string getCol_Name_9
        {
            get { return list_name_9; }
        }

        public string getList_Name_10
        {
            get { return list_name_10; }
        }

        public ArrayList List_ArrayList
        {
            get { return list_array; }
        }


    }
}