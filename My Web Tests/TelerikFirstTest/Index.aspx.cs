using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<MyData> myData = new List<MyData>();
        myData.Add(new MyData() { EmpId = "a", EmpName = "Sherif" });
        myData.Add(new MyData() { EmpId = "b", EmpName = "Ahmed" });
        RadGrid1.DataSource = myData;
        RadGrid1.DataBind();
    }
}

public class MyData
{
    public string EmpId { get; set; }
    public string EmpName { get; set; }
}

