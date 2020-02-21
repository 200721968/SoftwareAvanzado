using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SrRestaurante.WSObtenerOrdenSoapClient servicio = new SrRestaurante.WSObtenerOrdenSoapClient();
        servicio.GenerarOrden(TextBox1.Text, int.Parse(TextBox2.Text), TextBox3.Text, int.Parse(TextBox4.Text), TextBox5.Text);

    }
}