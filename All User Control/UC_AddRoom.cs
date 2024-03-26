using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlikhachsan.All_User_Control
{
    public partial class UC_AddRoom : UserControl
    {
        function fn = new function();
        String query;

        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "select * from rooms";
            DataSet ds = fn.getData(query);
            gridThemphong.DataSource = ds.Tables[0];
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if(txtRoomNo.Text != "" && txtRoomType.Text != "" && txtBed.Text != "" && txtPrice.Text != "")
            {
                String roomno = txtRoomNo.Text;                
                String type = txtRoomType.Text;
                String bed = txtBed.Text;   
                Int64 price = Int64.Parse(txtPrice.Text);
                query = "insert into rooms(roomNo, roomType, bed, price) values ('" + roomno + "','" + type + "','" + bed + "','" + price + "')";
                fn.setData(query, "Đã thêm phòng");
                UC_AddRoom_Load(this, null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin vui lòng điền đầy đủ thông tin", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtRoomNo.Clear();
            txtRoomType.SelectedIndex = -1;
            txtBed.SelectedIndex = -1;
            txtPrice.Clear();
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();

        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dg;
            dg = MessageBox.Show("Bạn chắc chắn muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dg == DialogResult.Yes)
            {
                int indexOfRow = gridThemphong.CurrentCell.RowIndex;
                gridThemphong.Rows.RemoveAt(indexOfRow);
            }

        }
        public void exportfile_excel(DataTable dataTable, string sheetname, string title)
        {
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = 20;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value = "RoomID";

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value = "RoomNo";

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value = "RoomType";

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value = "BedType";

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value = "Price";

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value = "Booked";

            Microsoft.Office.Interop.Excel.Range rowhead = oSheet.get_Range("A3", "F3");
            rowhead.Font.Bold = true;
            rowhead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count - 2;
            int columnEnd = dataTable.Columns.Count;

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            range.Value2 = arr;

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataColumn col1 = new DataColumn("RoomID");
            DataColumn col2 = new DataColumn("RoomNo");
            DataColumn col3 = new DataColumn("RoomType");
            DataColumn col4 = new DataColumn("Bed");
            DataColumn col5 = new DataColumn("Price");
            DataColumn col6 = new DataColumn("Booked");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);

            foreach (DataGridViewRow row in gridThemphong.Rows)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["RoomID"] = row.Cells["RoomID"].Value;
                newRow["RoomNo"] = row.Cells["RoomNo"].Value;
                newRow["RoomType"] = row.Cells["RoomType"].Value;
                newRow["Bed"] = row.Cells["Bed"].Value;
                newRow["Price"] = row.Cells["Price"].Value;
                newRow["Booked"] = row.Cells["Booked"].Value;

                dataTable.Rows.Add(newRow);
            }

            exportfile_excel(dataTable, "Danh sach", "DANH SÁCH PHÒNG");
        }
    }
}
