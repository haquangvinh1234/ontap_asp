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
    public partial class TimKiemSinhVien : System.Web.UI.Page
    {
        private static string chuoiKetnoi = "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=QL_SinhVien_OnTap;Integrated Security=True";
        private static SqlConnection con = new SqlConnection(chuoiKetnoi);
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
            catch (Exception ex)
            {
                lblErorr.Style["color"] = "red";
                lblErorr.Text = "Lỗi kết nối" + ex.ToString();
            }
        }

        protected void grvDSSV_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void grvDSSV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDSSV.PageIndex = e.NewPageIndex;
        }

        protected void btnTimTheoMa_Click(object sender, EventArgs e)
        {
            try
            {
                string search_by_id = "SELECT * FROM tbl_sinhvien WHERE MaSV='" + txtMaSV.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(search_by_id, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grvDSSV.DataSource = dt;
                grvDSSV.DataBind();
                txtMaSV.Text = "";
            }
            catch (Exception)
            {
                lblErorr.Text = "Lỗi. Vui lòng kiểm tra lại";
            }
        }

        protected void btnTimTheoTen_Click(object sender, EventArgs e)
        {
            try
            {
                string search_by_name = "SELECT * FROM tbl_sinhvien WHERE TenSV='" + txtTenSV.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(search_by_name, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grvDSSV.DataSource = dt;
                grvDSSV.DataBind();
                txtTenSV.Text = "";
            }
            catch (Exception)
            {
                lblErorr.Text = "Lỗi. Vui lòng kiểm tra lại";
            }
        }
    }
}