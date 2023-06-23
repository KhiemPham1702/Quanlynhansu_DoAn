using ban_2.Form_selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class connect
{
    public SqlConnection con;

    public connect()
    {
        this.con = new SqlConnection(@"Data Source=LAPTOP-DSO9KCIT\SQLEXPRESS;Initial Catalog=Quanlynhansu;Integrated Security=True;");
    }

    public SqlConnection Con { get => con; set => con = value; }
}