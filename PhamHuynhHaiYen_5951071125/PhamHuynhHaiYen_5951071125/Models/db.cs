using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PhamHuynhHaiYen_5951071125.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-OCUUTDBF\SQLEXPRESS;Initial Catalog=DemoCRUB;Integrated Security=True");

        //select
        public DataSet Empget(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@STATE", emp.State);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                msg = "OK";
                return ds;
            }catch(Exception e)
            {
                msg = e.Message;
                return ds;
            }
        }
        //them sua
        public string Empdml(Employee emp, out string msg)
        {           
            msg = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                cmd.Parameters.AddWithValue("@City", emp.City);
                cmd.Parameters.AddWithValue("@STATE", emp.State);
                cmd.Parameters.AddWithValue("@Country", emp.Country);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@flag", emp.flag);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception e)
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                msg = e.Message;
                return msg;
            }
        }
    }
    
    
}
