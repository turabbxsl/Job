using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace IsAxtaris.appclass
{
    public class settings
    {
        public static Size Kicik
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["kicikw"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["kicikh"]);
                return sz;
            }
        }

        public static Size CVKicik
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["CVkicikw"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["CVkicikh"]);
                return sz;
            }
        }

        public static Size Boyuk
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["boyukw"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["boyukh"]);
                return sz;
            }
        }
    }
}