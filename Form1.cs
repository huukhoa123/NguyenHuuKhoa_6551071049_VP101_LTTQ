using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace NguyenHuuKhoa_6551071049_VP101_28_LTTQ
{
    public partial class Form1 : Form
    {
        private readonly BindingList<CongViec> danhSachCongViec = new();

        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = danhSachCongViec;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;

            dataGridView1.CellClick += dataGridView1_CellClick;
            LoadCongViecs();
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!TryReadCongViec(out CongViec? congViec))
                return;

            try
            {
                using CongViecDbContext db = new();
                if (db.CongViecs.Any(x => x.MaCongViec == congViec.MaCongViec))
                {
                    MessageBox.Show("Mã công việc đã có .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                db.CongViecs.Add(congViec);
                db.SaveChanges();
                LoadCongViecs();
                ClearInputs();
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not CongViec congViec)
            {
                MessageBox.Show("Vui lòng chọn công việc cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!TryReadCongViec(out CongViec? thongTinMoi))
                return;

            try
            {
                using CongViecDbContext db = new();
                CongViec? congViecTrongDb = db.CongViecs.FirstOrDefault(x => x.MaCongViec == congViec.MaCongViec);
                if (congViecTrongDb is null)
                {
                    MessageBox.Show("Công việc không có trong bảng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadCongViecs();
                    return;
                }

                if (congViecTrongDb.MaCongViec != thongTinMoi.MaCongViec &&
                    db.CongViecs.Any(x => x.MaCongViec == thongTinMoi.MaCongViec))
                {
                    MessageBox.Show("Mã công việc đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }

                if (congViecTrongDb.MaCongViec != thongTinMoi.MaCongViec)
                {
                   
                    db.CongViecs.Remove(congViecTrongDb);
                    db.CongViecs.Add(thongTinMoi);
                }
                else
                {
                    congViecTrongDb.TenCongViec = thongTinMoi.TenCongViec;
                    congViecTrongDb.LuongThang = thongTinMoi.LuongThang;
                }
                db.SaveChanges();
                LoadCongViecs();
                ClearInputs();
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is not CongViec congViec)
            {
                MessageBox.Show("Vui lòng chọn công việc cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa công việc '{congViec.TenCongViec}' không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using CongViecDbContext db = new();
                    db.CongViecs.Remove(congViec);
                    db.SaveChanges();
                    LoadCongViecs();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    ShowDatabaseError(ex);
                }
            }
        }

        private void LoadCongViecs()
        {
            try
            {
                using CongViecDbContext db = new();
                db.Database.EnsureCreated();
                danhSachCongViec.Clear();
                foreach (CongViec congViec in db.CongViecs.AsNoTracking().OrderBy(x => x.MaCongViec))
                    danhSachCongViec.Add(congViec);
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private static void ShowDatabaseError(Exception ex)
        {
            Exception detail = ex;
            while (detail.InnerException is not null)
                detail = detail.InnerException;

            MessageBox.Show(
                "Không thể kết nối hoặc thao tác với database. Hãy kiểm tra SQL Server và database DuLieu.\n\n" + detail.Message,
                "Lỗi database", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.Rows[e.RowIndex].DataBoundItem is not CongViec congViec)
                return;

            textBox1.Text = congViec.MaCongViec;
            textBox2.Text = congViec.TenCongViec;
            textBox3.Text = congViec.LuongThang;
        }

        private bool TryReadCongViec(out CongViec congViec)
        {
            congViec = new CongViec();
            string ma = textBox1.Text.Trim();
            string ten = textBox2.Text.Trim();
            string luongText = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(luongText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin công việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(luongText, out decimal luong) || luong < 0)
            {
                MessageBox.Show("Lương tháng phải là số không âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;
            }

            string luongDaChuanHoa = luong.ToString("0.##");
            if (luongDaChuanHoa.Length > 8)
            {
                MessageBox.Show("Lương tháng không được vượt quá 8 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;
            }

            congViec = new CongViec
            {
                MaCongViec = ma,
                TenCongViec = ten,
                LuongThang = luongDaChuanHoa
            };
            return true;
        }

        private void ClearInputs()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dataGridView1.ClearSelection();
            textBox1.Focus();
        }

    
    }
}
