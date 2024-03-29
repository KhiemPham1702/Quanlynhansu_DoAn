﻿using ban_2.Form_selection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ban_2
{
    public partial class Add_TV_form : Form
    {
        Employee employee = new Employee();

        public Add_TV_form(Employee a)
        {
            InitializeComponent();
            employee = a;
        }

        SqlConnection con = new connect().Con;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private bool kt()
        {
            if (tbAddID.Text == "" || tbAddName.Text == "" || tbAddIDC.Text == "" || tbAddPhone.Text == "" || tbAddDress.Text == "" || tbAddEducation.Text == "" || tbAddEmail.Text == "" || (radioButton1.Checked == false && radioButton2.Checked == false))
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!!!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private string gioitinh()
        {
            if (radioButton1.Checked == true)
                return "Nam";
            if (radioButton2.Checked == true)
                return "Nữ";
            return "";
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadPB()
        {
            string sql = "SELECT TENPHONGBAN FROM PHONGBAN";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbDepartment.DataSource = dt;
            cbDepartment.DisplayMember = "TENPHONGBAN";
            cbDepartment.ValueMember = "TENPHONGBAN";
            con.Close();
            Load_positon();
        }

        public void Add_TV_form_Load(object sender, EventArgs e)
        {

            string sql = "SELECT TENPHONGBAN FROM PHONGBAN";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbDepartment.DataSource = dt;
            cbDepartment.DisplayMember = "TENPHONGBAN";
            cbDepartment.ValueMember = "TENPHONGBAN";
            con.Close();
            Load_positon();
            LoadPB();
        }

        public void Load_positon()
        {
            string sql = "SELECT TENCV FROM CHUCVU";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbPosition.DataSource = dt;
            cbPosition.DisplayMember = "TENCV";
            cbPosition.ValueMember = "TENCV";
            con.Close();
        }

        string Get_MACV()
        {
            string sql = "SELECT MACV FROM CHUCVU WHERE TENCV = N'" + cbPosition.SelectedValue.ToString() + "'";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows[0][0].ToString();
        }

        string Get_MAPB()
        {
            string sql = "SELECT MAPB FROM PHONGBAN WHERE TENPHONGBAN = N'" + cbDepartment.SelectedValue.ToString() + "'";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows[0][0].ToString();
        }

        bool Check_TP()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlDataReader dr;
            string sql = "select NHANVIEN.MANV,NHANVIEN.HOTEN,NHANVIEN.MAPB,PHONGBAN.TENPHONGBAN,CHUCVU.TENCV from PHONGBAN, NHANVIEN, CHUCVU where PHONGBAN.MAPB = NHANVIEN.MAPB and NHANVIEN.MACV = CHUCVU.MACV and CHUCVU.TENCV = N'Trưởng phòng' and TENPHONGBAN = N'" + cbDepartment.SelectedValue.ToString() + "'";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }
        }

        bool Check_PP()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlDataReader dr;
            String sql = "select NHANVIEN.MANV,NHANVIEN.HOTEN,NHANVIEN.MAPB,PHONGBAN.TENPHONGBAN,CHUCVU.TENCV from PHONGBAN, NHANVIEN, CHUCVU where PHONGBAN.MAPB = NHANVIEN.MAPB and NHANVIEN.MACV = CHUCVU.MACV and CHUCVU.TENCV = N'Phó phòng' and TENPHONGBAN = N'" + cbDepartment.SelectedValue.ToString() + "'";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }
        }

        void Add_NV(string MAPB, string MACV, string gt)
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO NHANVIEN (MANV, MAPB, MACV, HOTEN, CCCD, GIOITINH, NGAYSINH, SDT, EMAIL, DIACHI, HOCVAN)  VALUES ('" + tbAddID.Text + "', '" + MAPB + "', '" + MACV + "', N'" + tbAddName.Text + "','" + tbAddIDC.Text + "', N'" + gt + "','" + pickerBirthday.Value.ToString("yyyy-MM-dd") + "','" + tbAddPhone.Text + "', '" + tbAddEmail.Text + "', N'" + tbAddDress.Text + "', N'" + tbAddEducation.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully added", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbAddID.Text = tbAddName.Text = tbAddEmail.Text = tbAddIDC.Text = tbAddPhone.Text = tbAddDress.Text = tbAddEducation.Text = "";
            radioButton1.Checked = radioButton2.Checked = false;
            this.Close();
            employee.ketnoicsdl();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (kt())
            {
                try
                {
                    string gt = gioitinh();                                      
                    string MAPB = Get_MAPB();
                    string MACV = Get_MACV();
                    
                    if (MACV == "CV001")
                    {
                        if (Check_TP() == true) 
                        {
                            Add_NV(MAPB, MACV, gt);
                        } 
                        else
                            MessageBox.Show("This department already has a head", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (MACV == "CV002")
                    {
                        if (Check_PP() == true)
                        {
                            Add_NV(MAPB, MACV, gt);
                        }
                        else
                            MessageBox.Show("This department already has a deputy", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else Add_NV(MAPB, MACV, gt);
                }
                catch
                {
                    MessageBox.Show("ID employee already exists", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {           
            
        }

        private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void tbAddPhone_TextChanged(object sender, EventArgs e)
        {
            Int64 num = 0;

            if (Int64.TryParse(tbAddPhone.Text, out num))
            { }
            else
            {
                if (tbAddPhone.Text != "") MessageBox.Show("Only input number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbAddPhone.Text = "";
            }
        }

        private void tbAddIDC_TextChanged(object sender, EventArgs e)
        {
            Int64 num = 0;

            if (Int64.TryParse(tbAddIDC.Text, out num))
            { }
            else
            {
                if (tbAddIDC.Text != "") MessageBox.Show("Only input number", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbAddIDC.Text = "";
            }
        }
    }
}
