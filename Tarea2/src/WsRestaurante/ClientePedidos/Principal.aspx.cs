using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ServiceRef.WSObtenerOrdenSoapClient WS = new ServiceRef.WSObtenerOrdenSoapClient();
        //DataSet ds = WS.ListarOrden();
        //GridView1.DataSource = ds.Tables[0];
        //GridView1.DataBind();
            
     }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ServiceRef.WSObtenerOrdenSoapClient WS = new ServiceRef.WSObtenerOrdenSoapClient();
        DataSet ds = WS.ListarOrden();
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

    }
}