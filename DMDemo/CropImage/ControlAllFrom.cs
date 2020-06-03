using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dm;

namespace CropImage
{
    public class ControlAllFrom
    {
        private dmsoft mydm = new dmsoft();
        public static Dictionary<string, int> HideFormList = new Dictionary<string, int>();

        public void HiedAllFrom(List<int> notHiedIntPrt)
        {
            int topIntprt = mydm.GetSpecialWindow(0);
            string strInfor = mydm.EnumWindow(topIntprt, "", "", 4);
            int i = 0;
            HideFormList.Clear();
            foreach (string s in strInfor.Split(','))
            {
                int inPrt = 0;
                if (int.TryParse(s, out inPrt))
                {
                    if (mydm.GetWindowState(inPrt, 0) == 1)//窗口存在
                    {
                        if (mydm.GetWindowState(inPrt, 2) == 1)//窗口是否可见
                        {
                            if (mydm.GetWindowState(inPrt, 3) == 0)//窗口是最小化
                            {
                                if (notHiedIntPrt.Contains(inPrt)) continue;
                                i++;
                                string strFromTitle = string.Format("{0}、{1}", i, mydm.GetWindowTitle(inPrt));
                                HideFormList.Add(strFromTitle, inPrt);
                                mydm.SetWindowState(inPrt, 2);
                            }
                        }
                    }
                }
            }

        }
    }
}
