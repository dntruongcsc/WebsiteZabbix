using MVCProjectStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MVCProjectStructure.Models.CommonModel;

namespace MVCProjectStructure.Areas.TinTuc.Models
{
    public class TinTucModel
    {
        #region Tin tức
        public class Input
        {
            public class DocDanhSach : CommonInput.ChungThuc
            {
                public List<string> DanhSachIdDonVi { get; set; }
            }
        }
        #endregion
    }
}