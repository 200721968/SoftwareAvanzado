using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrincipalRepartidor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        REstauranteWS.WSObtenerOrdenSoapClient WS = new REstauranteWS.WSObtenerOrdenSoapClient();
        DataSet ds = WS.ListarOrden();
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        


    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        int CodigoSeleccionado = Convert.ToInt32(TextBox1.Text.ToString());
        REstauranteWS.WSObtenerOrdenSoapClient WS2 = new REstauranteWS.WSObtenerOrdenSoapClient();
        WS2.EntregarOrden(CodigoSeleccionado);
        DataSet ds = WS2.ListarOrden();
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
}
    