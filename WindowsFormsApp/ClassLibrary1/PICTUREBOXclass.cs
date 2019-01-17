using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public class PICTUREBOXclass
    {
        Form form;

        string name;
        string text;
        string image_name;
        int sX, sY, pX, pY;
        public EventHandler eh_picturbox;

        public PICTUREBOXclass(Form form, string name, string text, int sX, int sY, int pX, int pY, string image_name, EventHandler eh_picturbox)
        {
            this.form = form;

            this.name = name;
            this.text = text;
            this.sX = sX;
            this.sY = sY;
            this.pX = pX;
            this.pY = pY;
            this.image_name = image_name;
            this.eh_picturbox = eh_picturbox;
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
        public string Image_Name
        {
            get { return image_name; }
        }
    }
}
