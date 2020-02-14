using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


/// <summary>
/// Summary description for WSObtenerOrden
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WSObtenerOrden : System.Web.Services.WebService
{

    public WSObtenerOrden()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string GenerarOrden(string platoPrincipal, int cantidadPrincipal, string acompañamiento, int cantidadAcompaña,string DireccionEntrega) {

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Restaurante_SA; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        conn.Open();
        SqlCommand cmd = new SqlCommand("insert into Pedidos values(@Plato_entrada,@Cantidad_Entrada,@Acompania,@Cantidad_acompaña,@Direccion_Entrega,@Estado)", conn);
        cmd.Parameters.AddWithValue("@Plato_entrada",platoPrincipal);
        cmd.Parameters.AddWithValue("@Cantidad_Entrada", cantidadPrincipal);
        cmd.Parameters.AddWithValue("@Acompania", acompañamiento);
        cmd.Parameters.AddWithValue("@Cantidad_acompaña", cantidadAcompaña);
        cmd.Parameters.AddWithValue("@Direccion_Entrega", DireccionEntrega);
        cmd.Parameters.AddWithValue("@Estado", "Creado");
        cmd.ExecuteNonQuery();
        conn.Close();
        
        return "Orden Ingresada";
    }
    [WebMethod]
    public DataSet ListarOrden()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Restaurante_SA; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select * From Pedidos", conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
        
    }

    [WebMethod]
    public void EntregarOrden(int id) {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Restaurante_SA; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        conn.Open();
        SqlCommand cmd = new SqlCommand("Update Pedidos set Estado='Entregado' Where id ="+id+";", conn);
        cmd.ExecuteNonQuery();
        conn.Close();

    }
}
