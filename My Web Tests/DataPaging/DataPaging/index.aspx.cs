using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace DataPaging
{
    public partial class index : System.Web.UI.Page
    {
        protected int maxYear = 2026;
        protected int minYear = 2010;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GrdData(1);
            
        }

        protected void RadDataPager1_PageIndexChanged(object sender, RadDataPagerPageIndexChangeEventArgs e)
        {
            GrdData(e.NewPageIndex + 1); ;
        }

        protected void RadDataPager1_TotalRowCountRequest(object sender, RadDataPagerTotalRowCountRequestEventArgs e)
        {
            e.TotalRowCount = 9;
        }


        private void GrdData(int _pageNo)
        {
            List<EmpData> data = new List<EmpData>();
            if (_pageNo ==1)
            {
                data.Add(new EmpData() { EmpNo = "1", EmpName = "a" });
                data.Add(new EmpData() { EmpNo = "2", EmpName = "b" });
                data.Add(new EmpData() { EmpNo = "3", EmpName = "c" });
            }

            if (_pageNo == 2)
            {
                data.Add(new EmpData() { EmpNo = "4", EmpName = "d" });
                data.Add(new EmpData() { EmpNo = "5", EmpName = "e" });
                data.Add(new EmpData() { EmpNo = "6", EmpName = "e" });
            }

            if (_pageNo == 3)
            {
                data.Add(new EmpData() { EmpNo = "7", EmpName = "g" });
                data.Add(new EmpData() { EmpNo = "8", EmpName = "h" });
                data.Add(new EmpData() { EmpNo = "9", EmpName = "i" });
            }

            grd.DataSource = data;
            grd.DataBind();
        }
    }
    public class EmpData
    {
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
    }
}