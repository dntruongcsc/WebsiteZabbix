using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCProjectStructure.Helpers
{
    public class XuatExcel
    {
        public static string DefaultFontFamily = "Times New Roman";
        public static int DefaultFontSize = 11;

        public static bool checkExits(dynamic obj, string key) {
            try {
                switch (key)
                {
                    case "size":
                        {
                            var flag = obj.size;
                            if (flag!=null) return true;
                            break;
                        }
                    case "font":
                        {
                            var flag = obj.font;
                            if (flag != null) return true;
                            break;
                        }                      
                }
            }
            catch (Exception ex) {
                return false;
            }
            return false;
        }
        public static Stream TaoFile(List<dynamic> listColumn, List<dynamic> list,
                string author, string title,
                string comment, string sheetName, string tableName) {
            bool flagIsFirts = true;
            List<int> dsWidth = new List<int>();
            using (var excelPackage = new ExcelPackage(new MemoryStream())) {
                excelPackage.Workbook.Properties.Author = author;
                excelPackage.Workbook.Properties.Title = title;
                excelPackage.Workbook.Properties.Comments = comment;
                var workSheet = excelPackage.Workbook.Worksheets.Add(sheetName);
                // Đổ dữ liệu
                var dataTable = new DataTable(tableName);
                var collection = list as IList<dynamic> ?? list.ToList();
                var flag = workSheet.Dimension == null;
                foreach (var item in listColumn) {
                    dataTable.Columns.Add(item.TieuDe.value, typeof(string));
                }
                foreach (var item in collection.ToList()) {
                    var dataRow = dataTable.NewRow();
                    int i = 0;
                    foreach (var itemData in item.GetType().GetProperties()) {
                        dataRow[listColumn[i].TieuDe.value] = itemData.GetValue(item, null).value.ToString();
                        if (flagIsFirts) {
                            dsWidth.Add(itemData.GetValue(item, null).value.ToString().Length >= 40 ? 50 :
                                itemData.GetValue(item, null).value.ToString().Length + 12);
                        }
                        i++;
                    }
                    flagIsFirts = false;
                    dataTable.Rows.Add(dataRow);
                }
                if (flag){
                    workSheet.Cells[1, 1].LoadFromDataTable(dataTable, true);
                }
                else{
                    workSheet.Cells[workSheet.Dimension.End.Row + 1, 1].LoadFromDataTable(dataTable, true);
                }
                if (workSheet.Dimension != null){
                    workSheet.InsertRow(workSheet.Dimension.End.Row + 2, 5);
                }
                // Format
                workSheet.Cells.Style.WrapText = true; // tự động rớt dòng

                // Tiêu đề
                for (int i = 1; i <= listColumn.Count; i++){
                    using (var range = workSheet.Cells[1, i]) {
                        workSheet.Column(i).Width = dsWidth[(i - 1)] >= 50 ? 50 : dsWidth[(i - 1)];  // độ rộng
                        //ranger power
                        var fontName = checkExits(listColumn[i-1].TieuDe, "font") ?
                                            listColumn[i-1].TieuDe.font.ToString() : DefaultFontFamily;
                        var fontSize = checkExits(listColumn[i-1].TieuDe, "size") ?
                                    listColumn[i-1].TieuDe.size : DefaultFontSize;


                        range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        range.Style.Font.SetFromFont(new Font(fontName, fontSize));
                        range.Style.Font.Bold = true;
                        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                }
                // Các dòng 
                for (int i = 2; i <= list.Count + 1; i++){
                        int j = 1;
                        foreach (var itemData in list[i-2].GetType().GetProperties()) {
                            using (var range = workSheet.Cells[i, j++]){
                                //range 
                                var fontName = checkExits(itemData.GetValue(list[i - 2], null), "font") ? 
                                            itemData.GetValue(list[i - 2], null).font.ToString() : DefaultFontFamily;
                                var fontSize = checkExits(itemData.GetValue(list[i - 2], null), "size") ? 
                                            itemData.GetValue(list[i - 2], null).size : DefaultFontSize;
                                
                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                range.Style.Font.SetFromFont(new Font(fontName, fontSize));
                                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            }
                        
                    }
                }
                //----------------------------------
                excelPackage.Save();
                return excelPackage.Stream;
            }
        }
    }
}