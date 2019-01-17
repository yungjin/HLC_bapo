using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class TABCTLclass
    {
        Form form;

        string name;
        string text;
        int sX, sY, pX, pY, H;
        public MouseEventHandler eh_tabctl;

        public TABCTLclass(Form form, string name, string text, int sX, int sY, int pX, int pY, int H)
        {
            this.form = form;

            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.H = H;
        }

        public TABCTLclass(Form form, string name, string text, int sX, int sY, int pX, int pY, int H, MouseEventHandler eh_tabctl)
        {
            this.form = form;
            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.H = H;
            this.eh_tabctl = eh_tabctl;
        }

        public Form Form
        {
            get { return form; }
        }

        public string Name
        {
            get { return name; }
        }
        public string Text
        {
            get { return text; }
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
        public int HT
        {
            get { return H; }
        }
    }
}

