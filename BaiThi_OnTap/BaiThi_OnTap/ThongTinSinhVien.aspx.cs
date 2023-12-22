using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiThi_OnTap
{
    public partial class ThongTinSinhVien : System.Web.UI.Page
    {
        public static string chuoiKetnoi = "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=QL_SinhVien_OnTap;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(chuoiKetnoi);
        protected void Page_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        public void HienThi()
        {
            try
            {
                string load = "SELECT * FROM tbl_sinhvien";
                SqlDataAdapter adapter = new SqlDataAdapter(load, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                grvDSSV.DataSource = dataTable;
                grvDSSV.DataBind();

            }
            catch(Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi kết nối";
            }
        }

        protected void grvDSSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string load = "SELECT * FROM tbl_sinhvien";
                SqlDataAdapter adapter = new SqlDataAdapter(load, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                int dong = grvDSSV.SelectedIndex;
                int trang = grvDSSV.PageIndex;
                txtMaSV.Text = dataTable.Rows[trang * 3 + dong][0].ToString();
                txtTenSV.Text = dataTable.Rows[trang * 3 + dong][1].ToString();

            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi kết nối";
            }
        }

        protected void grvDSSV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDSSV.PageIndex = e.NewPageIndex;
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string insert = "INSERT INTO tbl_sinhvien(MaSV, TenSV)VALUES(N'" + txtMaSV.Text + "', N'" + txtTenSV.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(insert, con);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
                HienThi();
                lblErorr.Style["color"] = "blue";
                lblErorr.Text = "Thêm thành công";
                txtMaSV.Text = "";
                txtTenSV.Text = "";
            }
            catch(Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi kết nối";
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = "DELETE FROM tbl_sinhvien WHERE MaSV='"+ txtMaSV.Text +"'";
                SqlCommand sqlCommand = new SqlCommand(delete, con);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
                HienThi();
                lblErorr.Style["color"] = "blue";
                lblErorr.Text = "Xoá thành công";
                txtMaSV.Text = "";
                txtTenSV.Text = "";
            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi kết nối";
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string update = "UPDATE tbl_sinhvien SET TenSV=N'"+ txtTenSV.Text +"' WHERE MaSV='"+ txtMaSV.Text +"'";
                SqlCommand sqlCommand = new SqlCommand(update, con);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
                HienThi();
                lblErorr.Style["color"] = "blue";
                lblErorr.Text = "Cập nhật thành công";
                txtMaSV.Text = "";
                txtTenSV.Text = "";
            }
            catch (Exception)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi kết nối";
            }
        }
    }
}