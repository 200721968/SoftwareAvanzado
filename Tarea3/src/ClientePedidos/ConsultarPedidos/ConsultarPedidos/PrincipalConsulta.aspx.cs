using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrincipalConsulta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RestauranteWS.WSObtenerOrdenSoap WS = new RestauranteWS.WSObtenerOrdenSoapClient();
        DataSet ds = WS.ListarOrden();
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        RestauranteWS.WSObtenerOrdenSoap WS = new RestauranteWS.WSObtenerOrdenSoapClient();
        DataSet ds = WS.ListarOrden();
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
}