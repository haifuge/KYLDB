using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;

namespace KYLDB.Forms
{
    public partial class DataImportExport : Form
    {
        private DataImportExport()
        {
            InitializeComponent();
        }

        private static DataImportExport singleton = null;
        public static DataImportExport GetInstance()
        {
            if (singleton == null)
                singleton = new DataImportExport();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private void DataImportExport_Load(object sender, EventArgs e)
        {
            string sql = "select * from KLYTables";
            DataTable dt = DBOperator.QuerySql(sql);
            
            var tableList = from row in dt.AsEnumerable()
                          select row.Field<string>(0);
            cTableList.DataSource = tableList.ToList();
            cExportTable.DataSource = tableList.ToList();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Excel|*.xlsx|Excel|*.xlsm|cvs|*.cvs|All|*.*";
            od.RestoreDirectory = true;
            od.FilterIndex = 1;
            if (od.ShowDialog() == DialogResult.OK)
            {
                tFilePath.Text = od.FileName;
            }
        }

        private async void btnImport_Click(object sender, EventArgs e)
        {
            cTableList.Enabled = false;
            tFilePath.Enabled = false;
            btnImport.Enabled = false;
            btnSelectFile.Enabled = false;
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;

            string tableName = cTableList.Text;
            string filePath = tFilePath.Text;
            await Task.Run(() => importData(filePath, tableName));

            MessageBox.Show("Import success");
            cTableList.Enabled = true;
            tFilePath.Enabled = true;
            btnImport.Enabled = true;
            btnSelectFile.Enabled = true;
            progressBar1.Visible = false;
        }

        private void importData(string filePath, string tableName)
        {
            DataTable dt = ReadExcelToDataTable(filePath, tableName);
            string sql = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql += "insert into " + tableName + " values(";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sql += "'" + dt.Rows[i][j].ToString().Replace("'", "''") + "',";
                }
                sql = sql.Substring(0, sql.Length - 1) + ",''); ";
            }
            DBOperator.ExecuteSql(sql);
        }

        private DataTable ReadExcelToDataTable(string filePath, string tableName)
        {
            if (filePath == string.Empty) throw new ArgumentNullException("路径参数不能为空");
            DataTable table = new DataTable("table");
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int col = 1, row = 1;
            // read header
            while (xlRange.Cells[row, col].Value2 != null)
            {
                table.Columns.Add(xlRange.Cells[row, col].Value2.ToString());
                col++;
            }
            row = 2;
            // read data
            switch (tableName)
            {
                case "AccountInfo":
                    while (xlRange.Cells[row, 1].Value2 != null)
                    {
                        DataRow dr = table.NewRow();
                        for (int j = 1; j < col; j++)
                        {
                            object obj = xlRange.Cells[row, j].Value2;
                            string cell = obj == null ? "" : obj.ToString();
                            // FirstCheckDate, PayClosedDate, BankStartDate ,PayStartDate
                            if ((j == 80 || j == 40 || j == 35 || j == 28)&& cell != "")
                            {
                                cell = DateTime.FromOADate(double.Parse(cell)).ToShortDateString();
                            }
                            dr[j - 1] = cell;
                        }
                        table.Rows.Add(dr);
                        row++;
                    }
                    break;
            }
            
            xlWorkbook.Close();
            xlApp.Quit();
            return table;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Title = "Select file";
            sd.Filter = "Excel|*.xlsx|Excel|*.xlsm|cvs|*.cvs|All|*.*";
            sd.FilterIndex = 1;
            sd.SupportMultiDottedExtensions = false;
            sd.RestoreDirectory = true;
            if (sd.ShowDialog() == DialogResult.OK)
            {
                tSavePath.Text = sd.FileName;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            cExportTable.Enabled = false;
            tSavePath.Enabled = false;
            btnExport.Enabled = false;
            btnSave.Enabled = false;
            progressBar2.Visible = true;

            string tableName = cExportTable.Text;
            string filePath = tSavePath.Text;
            await Task.Run(() => exportExcel(tableName, filePath));

            MessageBox.Show("export success");
            cExportTable.Enabled = true;
            tSavePath.Enabled = true;
            btnExport.Enabled = true;
            btnSave.Enabled = true;
            progressBar2.Visible = false;
        }
        private void exportExcel(string tableName, string filePath)
        {
            string sql = "select * from " + tableName;
            DataTable dt = DBOperator.QuerySql(sql);
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbooks xlWorkbooks = xlApp.Workbooks;
            Excel.Workbook xlWorkbook = xlWorkbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            xlWorksheet.Cells.Font.Size = 11;
            Excel.Range xlRange;

            // write header
            for(int i = 0; i < dt.Columns.Count; i++)
            {
                xlWorksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                xlRange = xlWorksheet.Cells[1, i + 1];
                xlRange.Interior.ColorIndex = 15;
                xlRange.Font.Bold = true;
            }
            // write data
            switch (tableName)
            {
                case "AccountInfo":
                    // 处理日期类型
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            string data = dt.Rows[i][j].ToString();
                            if ((j == 79 || j == 39 || j == 34 || j == 27)&& data != "")
                            {
                                data = DateTime.Parse(data).ToShortDateString();
                            }
                            xlWorksheet.Cells[j + 1][i + 2] = data;
                        }
                    }
                    break;
            }
            
            try
            {
                xlWorkbook.Saved = true;
                xlWorkbook.SaveCopyAs(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
            }
            finally { 
                xlWorkbook.Close();
                xlApp.Quit();
            }
        }

        private void DataImportExport_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
