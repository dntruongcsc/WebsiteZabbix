using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectStructure.Helpers
{
    public class XuLyChung
    {
        public static string XuLyChuoiSo(double so, int soPhanCach = 2)
        {
            var kq = "";
            try
            {
                if (so!=0)
                {
                    switch (soPhanCach)
                    {
                        case 0:
                            kq = string.Format("{0:n0}", so);
                            break;
                        case 1:
                            kq = so % 1 > 0 ? string.Format("{0:n1}", so) : string.Format("{0:n0}", so);
                            break;
                        case 2:
                            kq = so % 1 > 0 ? string.Format("{0:n2}", so) : string.Format("{0:n0}", so);
                            break;
                        case 3:
                            kq = so % 1 > 0 ? string.Format("{0:n3}", so) : string.Format("{0:n0}", so);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception){}
            return kq;
        }
    }
}