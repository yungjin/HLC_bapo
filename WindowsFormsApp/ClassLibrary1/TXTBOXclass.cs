using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class TXTBOXclass
    {
        Form form;

        string name;
        string text;
        int sX, sY, pX, pY;
        public EventHandler eh_txtbox;

        public TXTBOXclass(Form form, string name, string text, int sX, int sY, int pX, int pY, EventHandler eh_txtbox)
        {
            this.form = form;

            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.eh_txtbox = eh_txtbox;
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
    }
}
