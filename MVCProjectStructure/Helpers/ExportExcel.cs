using ClosedXML.Excel;
using Common.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Xuất ra tập tin Excel
/// </summary>
public class ExportExcel
{
    public void Create()
    {
        var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Inserting Data");

        // From a list of strings
        var listOfStrings = new List<String>();
        listOfStrings.Add("House");
        listOfStrings.Add("Car");
        ws.Cell(1, 1).Value = "From Strings";
        ws.Cell(1, 1).AsRange().AddToNamed("Titles");
        var rangeWithStrings = ws.Cell(2, 1).InsertData(listOfStrings);

        // From a list of arrays
        var listOfArr = new List<Int32[]>();
        listOfArr.Add(new Int32[] { 1, 2, 3 });
        listOfArr.Add(new Int32[] { 1 });
        listOfArr.Add(new Int32[] { 1, 2, 3, 4, 5, 6 });
        ws.Cell(1, 3).Value = "From Arrays";
        ws.Range(1, 3, 1, 8).Merge().AddToNamed("Titles");
        var rangeWithArrays = ws.Cell(2, 3).InsertData(listOfArr);

        // From a DataTable
        var dataTable = GetTable();
        ws.Cell(6, 1).Value = "From DataTable";
        ws.Range(6, 1, 6, 4).Merge().AddToNamed("Titles");
        var rangeWithData = ws.Cell(7, 1).InsertData(dataTable.AsEnumerable());

        // From a query
        var list = new List<Person>();
        list.Add(new Person() { Name = "John", Age = 30, House = "On Elm St." });
        list.Add(new Person() { Name = "Mary", Age = 15, House = "On Main St." });
        list.Add(new Person() { Name = "Luis", Age = 21, House = "On 23rd St." });
        list.Add(new Person() { Name = "Henry", Age = 45, House = "On 5th Ave." });

        var people = from p in list
                     where p.Age >= 21
                     select new { p.Name, p.House, p.Age };

        ws.Cell(6, 6).Value = "From Query";
        ws.Range(6, 6, 6, 8).Merge().AddToNamed("Titles");
        var rangeWithPeople = ws.Cell(7, 6).InsertData(people.AsEnumerable());

        // Prepare the style for the titles
        var titlesStyle = wb.Style;
        StyleTitles(titlesStyle, true, XLAlignmentHorizontalValues.Center, XLColor.Aqua);

        // Format all titles in one shot
        wb.NamedRanges.NamedRange("Titles").Ranges.Style = titlesStyle;

        ws.Columns().AdjustToContents();

        wb.SaveAs("InsertingData.xlsx");
    }

    private static void StyleTitles(IXLStyle titlesStyle, bool fontBold, XLAlignmentHorizontalValues alignmentHorizontal, XLColor BackgroundColor)
    {
        titlesStyle.Font.Bold = fontBold;
        titlesStyle.Alignment.Horizontal = alignmentHorizontal;
        titlesStyle.Fill.BackgroundColor = BackgroundColor;
    }

    class Person
    {
        public String House { get; set; }
        public String Name { get; set; }
        public Int32 Age { get; set; }
    }

    private static DataTable GetTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("Dosage", typeof(int));
        table.Columns.Add("Drug", typeof(string));
        table.Columns.Add("Patient", typeof(string));
        table.Columns.Add("Date", typeof(DateTime));

        table.Rows.Add(25, "Indocin", "David", DateTime.Now);
        table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
        table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
        table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
        table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
        return table;
    }

    public class ColumsMerge
    {
        public int CotBD { get; set; }
        public int SoCotGop { get; set; }
        public string Ten { get; set; }
        public int ChieuCaoDong { get; set; }
    }
    public class ColumsOfRowMerge
    {
        public int DongBD { get; set; }
        public int SoDongGop { get; set; }
        public string Ten { get; set; }
        public int ChieuCaoDong { get; set; }
    }

    public class ThongTinDoanhNghiep
    {
        public string TenCoSo { get; set; }
        public string NguoiDaiDien { get; set; }
        public string NganhNghe { get; set; }
        public string NamHoatDong { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
    }

    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <returns></returns>
    public static string Export2Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont,
                             bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                             XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                             XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response, int[] arrWidhtCollum)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.Cell("A1").Value = Title;
                if (DateRange)
                {
                    ws.Cell("A2").Value = "Ngày xuất: " + ExportDate;
                }
                else
                {
                    ws.Cell("A2").Value = "";
                }

                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 3;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                        StartCharCols++;
                    }
                }
                #endregion

                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                //border definitions for Columns
                Range = "A3:" + StartCharCols.ToString() + "3";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 4;

                //char StartCharDataCol = char.MinValue;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val = 0;
                        DateTime dt = DateTime.Now;
                        if (int.TryParse(a, out val))
                        {
                            ws.Cell(DataCell).Value = val;
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        //check if datetime type
                        else if (DateTime.TryParse(a, out dt))
                        {
                            ws.Cell(DataCell).Value = dt.ToShortDateString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        ws.Cell(DataCell).SetValue(a);
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 3;
                Range = "A4:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Code to save the file
                //HttpResponseBase httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }

                //httpResponse.End();
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu!";
        }
    }

    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable có merge cột (số cột merge động)
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <param name="ColumStartMerge">Cột bắt đầu gộp</param>
    /// <param name="NumberColumMerge">Số cột gôp</param>
    /// <param name="NameColumMerge">Tên cột gộp</param>
    /// <param name="HeightRowMerge">Chiều cao dòng gộp</param>
    /// <returns></returns>
    public static string Export3Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont, int HeaderHeightRow,
                                     bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                                     XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                                     XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response,
                                     int[] arrWidhtCollum, int ColumStartMerge, int NumberColumMerge, string NameColumMerge, int HeightRowMerge)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.Cell("A1").Value = Title;
                if (DateRange)
                {
                    ws.Cell("A2").Value = "Ngày xuất: " + ExportDate;
                }
                else
                {
                    ws.Cell("A2").Value = "";
                }

                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 3;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "4";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        int socot = ColumStartMerge + NumberColumMerge;
                        if (i == ColumStartMerge)
                        {
                            char CharMerge = StartCharCols;
                            char cotBD = StartCharCols;
                            for (int c = ColumStartMerge; c < socot; c++)
                            {
                                string DataCell = CharMerge.ToString() + "4";
                                ws.Cell(DataCell).Value = cols[c - 1];
                                ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                ws.Cell(DataCell).Style.Font.Bold = true;
                                ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                CharMerge++;
                                StartCharCols++;
                            }
                            CharMerge--;//trừ 1
                            string RangeHeadTable = cotBD.ToString() + StartIndexCols.ToString() + ":" + CharMerge.ToString() + StartIndexCols.ToString();
                            ws.Cell(cotBD.ToString() + StartIndexCols.ToString()).Value = NameColumMerge;
                            ws.Range(RangeHeadTable).Merge();
                            ws.Row(3).Height = HeightRowMerge;//Chiều cao dòng cần merge
                            ws.Range(RangeHeadTable).Style.Font.Bold = true;
                            ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                            ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                            ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Range(RangeHeadTable).Style.Font.FontColor = ColumnForeColor;

                        }
                        else if (i < ColumStartMerge || i >= socot)//cột không liên quan cột merge và khác cột cuối
                        {
                            string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                            string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "4";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                            StartCharCols++;
                        }
                    }
                }
                #endregion

                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Row(1).Height = HeaderHeightRow;
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                //border definitions for Columns
                Range = "A3:" + StartCharCols.ToString() + "4";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 5;

                //char StartCharDataCol = char.MinValue;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val = 0;
                        DateTime dt = DateTime.Now;
                        if (int.TryParse(a, out val))
                        {
                            ws.Cell(DataCell).Value = val;
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        //check if datetime type
                        else if (DateTime.TryParse(a, out dt))
                        {
                            ws.Cell(DataCell).Value = dt.ToShortDateString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        ws.Cell(DataCell).SetValue(a);
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 4;
                Range = "A5:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ////Code to save the file
                //HttpResponse httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                //// Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(httpResponse.OutputStream);
                //    memoryStream.Close();
                //}

                //httpResponse.End();
                //return "Ok";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu!";
        }
    }

    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable có merge cột(nhiều cột merge)
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <param name="_ListColumsMerge">Danh sách cột gộp</param>
    /// <returns></returns>
    public static string Export4Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont, int HeaderHeightRow,
                                     bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                                     XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                                     XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response,
                                     int[] arrWidhtCollum, List<ColumsMerge> _ListColumsMerge)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.Cell("A1").Value = Title;
                if (DateRange)
                    ws.Cell("A2").Value = "Ngày xuất: " + ExportDate;
                else
                    ws.Cell("A2").Value = "";
                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 3;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "4";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        int kytu = StartCharCols;
                        foreach (var item in _ListColumsMerge)
                        {
                            int n = item.CotBD + item.SoCotGop;
                            if (i == item.CotBD)
                            {
                                char CharMerge = StartCharCols;
                                char kyTuCotBD = StartCharCols;
                                for (int c = item.CotBD; c < n; c++)
                                {
                                    string DataCell = CharMerge.ToString() + "4";
                                    ws.Cell(DataCell).Value = cols[c - 1];
                                    ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                    ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                    ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Cell(DataCell).Style.Font.Bold = true;
                                    ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                    ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                    CharMerge++;
                                    StartCharCols++;
                                }
                                CharMerge--;//trừ 1
                                string RangeHeadTable = kyTuCotBD.ToString() + StartIndexCols.ToString() + ":" + CharMerge.ToString() + StartIndexCols.ToString();
                                ws.Cell(kyTuCotBD.ToString() + StartIndexCols.ToString()).Value = item.Ten;
                                ws.Range(RangeHeadTable).Merge();
                                ws.Row(3).Height = item.ChieuCaoDong;//Chiều cao dòng cần merge
                                ws.Range(RangeHeadTable).Style.Font.Bold = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                                ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                ws.Range(RangeHeadTable).Style.Font.FontColor = ColumnForeColor;
                                i = n - 1;
                            }
                        }
                        if (kytu.Equals(StartCharCols))
                        {
                            string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                            string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "4";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                            StartCharCols++;
                        }
                        if (i == cols.Length)
                        {
                            //Giảm lại 1 ký tự do cộng lên cuối cùng
                            StartCharCols--;
                        }
                    }

                }
                #endregion

                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Row(1).Height = HeaderHeightRow;
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


                //border definitions for Columns
                Range = "A3:" + StartCharCols.ToString() + "4";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 5;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val = 0;
                        DateTime dt = DateTime.Now;
                        if (int.TryParse(a, out val))
                        {
                            ws.Cell(DataCell).Value = val;
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        //check if datetime type
                        else if (DateTime.TryParse(a, out dt))
                        {
                            ws.Cell(DataCell).Value = dt.ToShortDateString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        ws.Cell(DataCell).SetValue(a);
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 4;
                Range = "A5:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Code to save the file
                //HttpResponse httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                //// Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(httpResponse.OutputStream);
                //    memoryStream.Close();
                //}

                //httpResponse.End();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu";
        }
    }

    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <param name="thongTinDoanhNgiep">Thông tin doanh nghiệp</param>
    /// <returns></returns>
    public static string Export5Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont,
                             bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                             XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                             XLColor ColumnForeColor, string SheetName, string FileName, HttpResponse response, int[] arrWidhtCollum, ThongTinDoanhNghiep thongTinDoanhNgiep)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.Cell("A1").Value = Title;
                if (DateRange)
                {
                    ws.Cell("A2").Value = "Ngày xuất: " + ExportDate;
                }
                else
                {
                    ws.Cell("A2").Value = "";
                }

                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 3;

                //Thông tin doanh nghiệp
                if (thongTinDoanhNgiep != null)
                {
                    string DataCell = "";
                    DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                    ws.Cell(DataCell).Value = "- Tên cơ sở: " + thongTinDoanhNgiep.TenCoSo;
                    StartIndexCols++;
                    DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                    ws.Cell(DataCell).Value = "- Người đại diện theo pháp luật: " + thongTinDoanhNgiep.NguoiDaiDien;
                    StartIndexCols++;
                    DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                    ws.Cell(DataCell).Value = "- Ngành nghề sản xuất, kinh doanh: " + thongTinDoanhNgiep.NganhNghe;
                    StartIndexCols++;
                    DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                    ws.Cell(DataCell).Value = "- Năm đi vào hoạt động sản xuất, kinh doanh: " + thongTinDoanhNgiep.NamHoatDong;
                    StartIndexCols++;
                    DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                    ws.Cell(DataCell).Value = "- Địa chỉ: " + thongTinDoanhNgiep.DiaChi;
                    StartIndexCols++;
                    DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                    ws.Cell(DataCell).Value = "- Điện thoại: " + thongTinDoanhNgiep.DienThoai + ", Email: " + thongTinDoanhNgiep.Email + ", Số Fax: " + thongTinDoanhNgiep.Fax;
                    StartIndexCols++;
                }
                //End thông tin

                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                        StartCharCols++;
                    }
                }
                #endregion

                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                //border definitions for Columns
                Range = "A" + StartIndexCols + ":" + StartCharCols.ToString() + StartIndexCols;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                StartIndexCols++;
                int StartIndexData = StartIndexCols;

                //char StartCharDataCol = char.MinValue;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val = 0;
                        DateTime dt = DateTime.Now;
                        if (int.TryParse(a, out val))
                        {
                            ws.Cell(DataCell).Value = val;
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        //check if datetime type
                        else if (DateTime.TryParse(a, out dt))
                        {
                            ws.Cell(DataCell).Value = dt.ToShortDateString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        ws.Cell(DataCell).SetValue(a);
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count - 1 + StartIndexCols;
                Range = "A" + StartIndexCols + ":" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Code to save the file
                HttpResponse httpResponse = response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wb.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();
                }

                httpResponse.End();
                return "Ok";
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu";
        }
    }

    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable có merge cột(nhiều cột merge), merge row, tiêu đề table 3 dòng
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <param name="_ListColumsMerge">Danh sách cột gộp</param>
    /// <returns></returns>
    public static string Export6Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont, int HeaderHeightRow,
                                     bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                                     XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                                     XLColor ColumnForeColor, string SheetName, string FileName, HttpResponse response,
                                     int[] arrWidhtCollum, List<ColumsMerge> _ListColumsMerge, List<ColumsMerge> _ListColumsMerge2)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.Cell("A1").Value = Title;
                if (DateRange)
                    ws.Cell("A2").Value = "Ngày xuất: " + ExportDate;
                else
                    ws.Cell("A2").Value = "";
                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }
                #region Dòng 1
                char StartCharCols = 'A';
                int StartIndexCols = 3;
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "5";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        int kytu = StartCharCols;
                        foreach (var item in _ListColumsMerge)
                        {
                            int n = item.CotBD + item.SoCotGop;
                            if (i == item.CotBD)
                            {
                                char CharMerge = StartCharCols;
                                char kyTuCotBD = StartCharCols;

                                var StartCharCols2 = StartCharCols;
                                for (int c = item.CotBD; c < n; c++)
                                {
                                    string DataCell = CharMerge.ToString() + "4";
                                    ws.Cell(DataCell).Value = cols[c - 1];
                                    ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                    ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                    ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Cell(DataCell).Style.Font.Bold = true;
                                    ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                    ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                    CharMerge++;
                                    StartCharCols++;
                                }
                                CharMerge--;//trừ 1
                                string RangeHeadTable = kyTuCotBD.ToString() + StartIndexCols.ToString() + ":" + CharMerge.ToString() + StartIndexCols.ToString();
                                ws.Cell(kyTuCotBD.ToString() + StartIndexCols.ToString()).Value = item.Ten;
                                ws.Range(RangeHeadTable).Merge();
                                ws.Row(3).Height = item.ChieuCaoDong;//Chiều cao dòng cần merge
                                ws.Range(RangeHeadTable).Style.Font.Bold = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                                ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                ws.Range(RangeHeadTable).Style.Font.FontColor = ColumnForeColor;
                                i = n - 1;

                                bool dl = false;
                                //Xử lý merge dòng 2--------------------------------------------------------------------------------------------------------------------------------------------------
                                for (int j = item.CotBD; j <= n; j++)
                                {
                                    int kytu2 = StartCharCols2;
                                    foreach (var item2 in _ListColumsMerge2)
                                    {
                                        int n2 = item2.CotBD + item2.SoCotGop;
                                        if (j == item2.CotBD)
                                        {
                                            char CharMerge2 = StartCharCols2;
                                            char kyTuCotBD2 = StartCharCols2;
                                            for (int c = item2.CotBD; c < n2; c++)
                                            {
                                                string DataCell = CharMerge2.ToString() + "5";
                                                ws.Cell(DataCell).Value = cols[c - 1];
                                                ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                                ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                                ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                                ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                                ws.Cell(DataCell).Style.Font.Bold = true;
                                                ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                                ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                                CharMerge2++;
                                                StartCharCols2++;
                                                dl = true;
                                            }
                                            CharMerge2--;//trừ 1
                                            string RangeHeadTable2 = kyTuCotBD2.ToString() + "4:" + CharMerge2.ToString() + "4";
                                            ws.Cell(kyTuCotBD2.ToString() + "4").Value = item2.Ten;
                                            ws.Range(RangeHeadTable2).Merge();
                                            ws.Row(4).Height = item2.ChieuCaoDong;//Chiều cao dòng cần merge
                                            ws.Range(RangeHeadTable2).Style.Font.Bold = true;
                                            ws.Range(RangeHeadTable2).Style.Alignment.SetWrapText(true);
                                            ws.Range(RangeHeadTable2).Style.Alignment.WrapText = true;
                                            ws.Range(RangeHeadTable2).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                            ws.Range(RangeHeadTable2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                            ws.Range(RangeHeadTable2).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                            ws.Range(RangeHeadTable2).Style.Font.FontColor = ColumnForeColor;
                                            j = n2 - 1;
                                        }
                                        if (kytu2.Equals(StartCharCols2) && dl == false)
                                        {
                                            string DataCell = StartCharCols2.ToString() + "4";
                                            string RangeRowMerge = StartCharCols2.ToString() + "4:" + StartCharCols2.ToString() + "5";
                                            ws.Range(RangeRowMerge).Merge();
                                            ws.Cell(DataCell).Value = cols[j - 1];
                                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[j - 1];
                                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                            ws.Cell(DataCell).Style.Font.Bold = true;
                                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                            StartCharCols2++;
                                            dl = false;
                                        }
                                        //if (j == n)
                                        //{
                                        //    //Giảm lại 1 ký tự do cộng lên cuối cùng
                                        //    StartCharCols2--;
                                        //}                                        
                                    }
                                }
                                //--------------------------------------------------------------------------------------------------------------------------------------------------
                            }
                        }

                        if (kytu.Equals(StartCharCols))
                        {
                            string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                            string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "5";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                            StartCharCols++;
                        }
                        if (i == cols.Length)
                        {
                            //Giảm lại 1 ký tự do cộng lên cuối cùng
                            StartCharCols--;
                        }
                    }
                }
                #endregion
                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Row(1).Height = HeaderHeightRow;
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


                //border definitions for Columns
                Range = "A3:" + StartCharCols.ToString() + "5";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 6;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val = 0;
                        DateTime dt = DateTime.Now;
                        if (int.TryParse(a, out val))
                        {
                            ws.Cell(DataCell).Value = val;
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        //check if datetime type
                        else if (DateTime.TryParse(a, out dt))
                        {
                            ws.Cell(DataCell).Value = dt.ToShortDateString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        ws.Cell(DataCell).SetValue(a);
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 5;
                Range = "A5:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Code to save the file
                HttpResponse httpResponse = response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wb.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                    memoryStream.Close();
                }

                httpResponse.End();
                return "Ok";
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu";
        }
    }

    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="Title1">Tên niên khóa</param>
    /// <param name="HeaderBackgroundColor1">Màu nền niên khóa</param>
    /// <param name="HeaderForeColor1">Màu chữ niên khóa</param>
    /// <param name="HeaderFont1">Kích thước chữ niên khóa</param>
    /// <param name="Title2">CHXHCN VN</param>
    /// <param name="HeaderBackgroundColor2">Màu nền CHXHCN VN</param>
    /// <param name="HeaderForeColor2">Màu chữ CHXHCN VN</param>
    /// <param name="HeaderFon2">Kích thước CHXHCN VN</param>
    /// <param name="Title3">Độc lập - Tự do -Hạnh Phúc</param>
    /// <param name="HeaderBackgroundColor3">Màu nền Độc lập - Tự do -Hạnh Phúc</param>
    /// <param name="HeaderForeColor3">Màu chữ Độc lập - Tự do -Hạnh Phúc</param>
    /// <param name="HeaderFon3">Kích thước Độc lập - Tự do -Hạnh Phúc</param>
    /// <param name="Title4">Sở</param>
    /// <param name="HeaderBackgroundColor4">Màu nền Sở</param>
    /// <param name="HeaderForeColor4">Màu chữ Sở</param>
    /// <param name="HeaderFon4">Kích thước Sở</param>
    /// <param name="Title5">Trường</param>
    /// <param name="HeaderBackgroundColor5">Màu nền Trường</param>
    /// <param name="HeaderForeColor5">Màu chữ Trường</param>
    /// <param name="HeaderFon5">Kích thước Trường</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <returns></returns>
    public static string Export7Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont,
                             string Title1, XLColor HeaderBackgroundColor1, XLColor HeaderForeColor1, int HeaderFont1,
                             string Title2, XLColor HeaderBackgroundColor2, XLColor HeaderForeColor2, int HeaderFont2,
                             string Title3, XLColor HeaderBackgroundColor3, XLColor HeaderForeColor3, int HeaderFont3,
                             string Title4, XLColor HeaderBackgroundColor4, XLColor HeaderForeColor4, int HeaderFont4,
                             string Title5, XLColor HeaderBackgroundColor5, XLColor HeaderForeColor5, int HeaderFont5,
                             bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                             XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                             XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response, int[] arrWidhtCollum)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.Cell("G1").Value = Title2;
                ws.Cell("G2").Value = Title3;
                ws.Cell("A3").Value = Title;
                ws.Cell("A1").Value = Title4;
                ws.Cell("A2").Value = Title5;
                ws.Cell("A4").Value = Title1;

                if (DateRange)
                {
                    ws.Cell("A5").Value = "Ngày xuất: " + ExportDate;
                }
                else
                {
                    ws.Cell("A5").Value = "";
                }

                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 6;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                        StartCharCols++;
                    }
                }
                #endregion

                //Merging Header

                string Range = "A3:" + StartCharCols.ToString() + "3";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                Range = "A4:" + StartCharCols.ToString() + "4";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont1;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor1 != null && HeaderForeColor1 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor1;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor1;
                }



                Range = "G1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont2;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor2 != null && HeaderForeColor2 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor2;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor2;
                }

                Range = "G2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont3;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor3 != null && HeaderForeColor3 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor3;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor3;
                }

                //Range = "A1:" + StartCharCols.ToString() + "1";
                Range = "A1:D1";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont4;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor4 != null && HeaderForeColor4 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor4;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor4;
                }

                //Range = "A2:" + StartCharCols.ToString() + "2";
                Range = "A2:D2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont5;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor5 != null && HeaderForeColor5 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor5;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor5;
                }

                Range = "E1:F2";

                ws.Range(Range).Merge();

                //Style definitions for Date range
                Range = "A5:" + StartCharCols.ToString() + "5";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                //border definitions for Columns
                Range = "A6:" + StartCharCols.ToString() + "6";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 7;

                //char StartCharDataCol = char.MinValue;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val = 0;
                        DateTime dt = DateTime.Now;
                        if (int.TryParse(a, out val))
                        {
                            ws.Cell(DataCell).Value = val;
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        //check if datetime type
                        else if (DateTime.TryParse(a, out dt))
                        {
                            ws.Cell(DataCell).Value = dt.ToShortDateString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        ws.Cell(DataCell).SetValue(a);
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 6;
                Range = "A7:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Code to save the file
                //HttpResponseBase httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }

                //httpResponse.End();
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu!";
        }
    }

    ///-------------------------------------------------------------------------------------------------------------------------------------
    /// New version: Cải tiến xuất có định dạng kiểu số
    /// Export4_2Excel --> Có thêm danh sách cột kiểu double
    /// Export6_2Excel --> Có thêm danh sách cột kiểu double và danh sách cột kiểu int
    ///-------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable có merge cột(nhiều cột merge), thêm thông tin xuất ra dữ liệu dạng số double
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <param name="_ListColumsMerge">Danh sách cột gộp</param>
    /// <param name="_ListCollumTypeNumberDouble">Danh sách cột số kiểu double</param>
    /// <returns></returns>
    public static string Export4Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont, int HeaderHeightRow,
                                     bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                                     XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                                     XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response,
                                     int[] arrWidhtCollum, List<ColumsMerge> _ListColumsMerge, int[] _ListCollumTypeNumberDouble, int[] _ListCollumTypeNumberInt)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.Cell("A1").Value = Title;
                if (DateRange)
                    ws.Cell("A2").Value = "Ngày xuất: " + ExportDate;
                else
                    ws.Cell("A2").Value = "";
                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 3;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "4";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        int kytu = StartCharCols;
                        foreach (var item in _ListColumsMerge)
                        {
                            int n = item.CotBD + item.SoCotGop;
                            if (i == item.CotBD)
                            {
                                char CharMerge = StartCharCols;
                                char kyTuCotBD = StartCharCols;
                                for (int c = item.CotBD; c < n; c++)
                                {
                                    string DataCell = CharMerge.ToString() + "4";
                                    ws.Cell(DataCell).Value = cols[c - 1];
                                    ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                    ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                    ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Cell(DataCell).Style.Font.Bold = true;
                                    ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                    ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                    CharMerge++;
                                    StartCharCols++;
                                }
                                CharMerge--;//trừ 1
                                string RangeHeadTable = kyTuCotBD.ToString() + StartIndexCols.ToString() + ":" + CharMerge.ToString() + StartIndexCols.ToString();
                                ws.Cell(kyTuCotBD.ToString() + StartIndexCols.ToString()).Value = item.Ten;
                                ws.Range(RangeHeadTable).Merge();
                                ws.Row(3).Height = item.ChieuCaoDong;//Chiều cao dòng cần merge
                                ws.Range(RangeHeadTable).Style.Font.Bold = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                                ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                ws.Range(RangeHeadTable).Style.Font.FontColor = ColumnForeColor;
                                i = n - 1;
                            }
                        }
                        if (kytu.Equals(StartCharCols))
                        {
                            string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                            string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "4";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                            StartCharCols++;
                        }
                        if (i == cols.Length)
                        {
                            //Giảm lại 1 ký tự do cộng lên cuối cùng
                            StartCharCols--;
                        }
                    }

                }
                #endregion

                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Row(1).Height = HeaderHeightRow;
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


                //border definitions for Columns
                Range = "A3:" + StartCharCols.ToString() + "4";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 5;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int k_int = 0, k_double = 0;//Dùng tối ưu vòng lặp
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val_int = 0;
                        DateTime dt = DateTime.Now;
                        double val_double = 0;

                        bool Cell_Double = false, Cell_Int = false;
                        for (int k = k_double; k < _ListCollumTypeNumberDouble.Count(); k++)
                        {
                            if (StartCharData == (_ListCollumTypeNumberDouble[k] + 64))//Cộng cho 64 là do 65 là char 'A'
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 4;//4 định dạng là #,##0.00 (Xem trong Format Cell in excel)
                                Cell_Double = true;
                                k_double = k + 1;
                                break;
                            }
                        }
                        for (int k = k_int; k < _ListCollumTypeNumberInt.Count(); k++)
                        {
                            if (StartCharData == (_ListCollumTypeNumberInt[k] + 64))//Cộng cho 64 là do 65 là char 'A'
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 2;//2 định dạng là 0 (Xem trong Format Cell in excel)
                                Cell_Int = true;
                                k_int = k + 1;
                                break;
                            }
                        }
                        if ((int.TryParse(a, out val_int) && j == 0) || (int.TryParse(a, out val_int) && Cell_Int))//--Cột số thứ tự hoặc cột kiểu int
                        {
                            ws.Cell(DataCell).Value = val_int;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else if (double.TryParse(a, out val_double) && Cell_Double)//--Cột số kiểu double
                        {
                            ws.Cell(DataCell).Value = val_double;
                            if (val_double == 0) ws.Cell(DataCell).Value = 0;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else
                        {
                            ws.Cell(DataCell).Value = a.ToString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 4;
                Range = "A5:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ////Code to save the file
                //HttpResponse httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                //// Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(httpResponse.OutputStream);
                //    memoryStream.Close();
                //}

                //httpResponse.End();
                //return "Ok";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception e)
        {
            return "Lỗi dữ liệu";
        }
    }

    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable có merge cột(nhiều cột merge), merge row, tiêu đề table 3 dòng, có thêm danh sách cột kiểu double và danh sách cột kiểu int
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <param name="_ListColumsMerge">Danh sách cột gộp</param>
    /// <param name="_ListCollumTypeNumberDouble">Danh sách cột số kiểu double</param>
    /// <param name="_ListCollumTypeNumberInt">Danh sách cột số kiểu int</param>
    /// <returns></returns>
    public static string Export6_2Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont, int HeaderHeightRow,
                                     bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                                     XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                                     XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response,
                                     int[] arrWidhtCollum, List<ColumsMerge> _ListColumsMerge, List<ColumsMerge> _ListColumsMerge2, int[] _ListCollumTypeNumberDouble, int[] _ListCollumTypeNumberInt)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.Cell("A1").Value = Title;
                if (DateRange)
                    ws.Cell("A2").Value = "Ngày xuất: " + ExportDate;
                else
                    ws.Cell("A2").Value = "";
                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }
                #region Dòng 1
                char StartCharCols = 'A';
                int StartIndexCols = 3;
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "5";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        int kytu = StartCharCols;
                        foreach (var item in _ListColumsMerge)
                        {
                            int n = item.CotBD + item.SoCotGop;
                            if (i == item.CotBD)
                            {
                                char CharMerge = StartCharCols;
                                char kyTuCotBD = StartCharCols;

                                var StartCharCols2 = StartCharCols;
                                for (int c = item.CotBD; c < n; c++)
                                {
                                    string DataCell = CharMerge.ToString() + "4";
                                    ws.Cell(DataCell).Value = cols[c - 1];
                                    ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                    ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                    ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Cell(DataCell).Style.Font.Bold = true;
                                    ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                    ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                    CharMerge++;
                                    StartCharCols++;
                                }
                                CharMerge--;//trừ 1
                                string RangeHeadTable = kyTuCotBD.ToString() + StartIndexCols.ToString() + ":" + CharMerge.ToString() + StartIndexCols.ToString();
                                ws.Cell(kyTuCotBD.ToString() + StartIndexCols.ToString()).Value = item.Ten;
                                ws.Range(RangeHeadTable).Merge();
                                ws.Row(3).Height = item.ChieuCaoDong;//Chiều cao dòng cần merge
                                ws.Range(RangeHeadTable).Style.Font.Bold = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                                ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                ws.Range(RangeHeadTable).Style.Font.FontColor = ColumnForeColor;
                                i = n - 1;

                                bool dl = false;
                                //Xử lý merge dòng 2--------------------------------------------------------------------------------------------------------------------------------------------------
                                for (int j = item.CotBD; j <= n; j++)
                                {
                                    int kytu2 = StartCharCols2;
                                    foreach (var item2 in _ListColumsMerge2)
                                    {
                                        int n2 = item2.CotBD + item2.SoCotGop;
                                        if (j == item2.CotBD)
                                        {
                                            char CharMerge2 = StartCharCols2;
                                            char kyTuCotBD2 = StartCharCols2;
                                            for (int c = item2.CotBD; c < n2; c++)
                                            {
                                                string DataCell = CharMerge2.ToString() + "5";
                                                ws.Cell(DataCell).Value = cols[c - 1];
                                                ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                                ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                                ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                                ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                                ws.Cell(DataCell).Style.Font.Bold = true;
                                                ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                                ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                                CharMerge2++;
                                                StartCharCols2++;
                                                dl = true;
                                            }
                                            CharMerge2--;//trừ 1
                                            string RangeHeadTable2 = kyTuCotBD2.ToString() + "4:" + CharMerge2.ToString() + "4";
                                            ws.Cell(kyTuCotBD2.ToString() + "4").Value = item2.Ten;
                                            ws.Range(RangeHeadTable2).Merge();
                                            ws.Row(4).Height = item2.ChieuCaoDong;//Chiều cao dòng cần merge
                                            ws.Range(RangeHeadTable2).Style.Font.Bold = true;
                                            ws.Range(RangeHeadTable2).Style.Alignment.SetWrapText(true);
                                            ws.Range(RangeHeadTable2).Style.Alignment.WrapText = true;
                                            ws.Range(RangeHeadTable2).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                            ws.Range(RangeHeadTable2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                            ws.Range(RangeHeadTable2).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                            ws.Range(RangeHeadTable2).Style.Font.FontColor = ColumnForeColor;
                                            j = n2 - 1;
                                        }
                                        if (kytu2.Equals(StartCharCols2) && dl == false)
                                        {
                                            string DataCell = StartCharCols2.ToString() + "4";
                                            string RangeRowMerge = StartCharCols2.ToString() + "4:" + StartCharCols2.ToString() + "5";
                                            ws.Range(RangeRowMerge).Merge();
                                            ws.Cell(DataCell).Value = cols[j - 1];
                                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[j - 1];
                                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                            ws.Cell(DataCell).Style.Font.Bold = true;
                                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                            StartCharCols2++;
                                            dl = false;
                                        }
                                        //if (j == n)
                                        //{
                                        //    //Giảm lại 1 ký tự do cộng lên cuối cùng
                                        //    StartCharCols2--;
                                        //}                                        
                                    }
                                }
                                //--------------------------------------------------------------------------------------------------------------------------------------------------
                            }
                        }

                        if (kytu.Equals(StartCharCols))
                        {
                            string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                            string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "5";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                            StartCharCols++;
                        }
                        if (i == cols.Length)
                        {
                            //Giảm lại 1 ký tự do cộng lên cuối cùng
                            StartCharCols--;
                        }
                    }
                }
                #endregion
                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Row(1).Height = HeaderHeightRow;
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


                //border definitions for Columns
                Range = "A3:" + StartCharCols.ToString() + "5";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 6;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int k_int = 0, k_double = 0;//Dùng tối ưu vòng lặp
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val_int = 0;
                        DateTime dt = DateTime.Now;
                        double val_double = 0;

                        bool Cell_Double = false, Cell_Int = false;
                        for (int k = k_double; k < _ListCollumTypeNumberDouble.Count(); k++)
                        {
                            if (StartCharData == (_ListCollumTypeNumberDouble[k] + 64))//Cộng cho 64 là do 65 là char 'A'
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 4;//4 định dạng là #,##0.00 (Xem trong Format Cell in excel)
                                Cell_Double = true;
                                k_double = k + 1;
                                break;
                            }
                        }
                        for (int k = k_int; k < _ListCollumTypeNumberInt.Count(); k++)
                        {
                            if (StartCharData == (_ListCollumTypeNumberInt[k] + 64))//Cộng cho 64 là do 65 là char 'A'
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 2;//2 định dạng là 0 (Xem trong Format Cell in excel)
                                Cell_Int = true;
                                k_int = k + 1;
                                break;
                            }
                        }
                        if ((int.TryParse(a, out val_int) && j == 0) || (int.TryParse(a, out val_int) && Cell_Int))//--Cột số thứ tự hoặc cột kiểu int
                        {
                            ws.Cell(DataCell).Value = val_int;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else if (double.TryParse(a, out val_double) && Cell_Double)//--Cột số kiểu double
                        {
                            ws.Cell(DataCell).Value = val_double;
                            if (val_double == 0) ws.Cell(DataCell).Value = 0;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else
                        {
                            ws.Cell(DataCell).Value = a.ToString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 5;
                Range = "A5:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ////Code to save the file
                //HttpResponse httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                //// Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(httpResponse.OutputStream);
                //    memoryStream.Close();
                //}

                //httpResponse.End();
                //return "Ok";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu";
        }
    }

    #region Format Cell in excel
    ///<summary>
    ///**ID**** Format Code**
    ///0	General
    ///1	0
    ///2	0.00
    ///3	#,##0
    ///4	#,##0.00
    ///9	0%
    ///10	0.00%
    ///11	0.00E+00
    ///12	# ?/?
    ///13	# ??/??
    ///14	d/m/yyyy
    ///15	d-mmm-yy
    ///16	d-mmm
    ///17	mmm-yy
    ///18	h:mm tt
    ///19	h:mm:ss tt
    ///20	H:mm
    ///21	H:mm:ss
    ///22	m/d/yyyy H:mm
    ///37	#,##0 ;(#,##0)
    ///38	#,##0 ;[Red](#,##0)
    ///39	#,##0.00;(#,##0.00)
    ///40	#,##0.00;[Red](#,##0.00)
    ///45	mm:ss
    ///46	[h]:mm:ss
    ///47	mmss.0
    ///48	##0.0E+0
    ///49	@
    ///</summary>
    ///range.Style.NumberFormat.NumberFormatId = #;
    #endregion
    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// 
    /// 
    /// 
    /// <param name="Title1">SỞ NÔNG NGHIỆP & PTNT CÀ MAU</param>
    /// <param name="HeaderBackgroundColor1">Màu nền SỞ NÔNG NGHIỆP & PTNT CÀ MAU</param>
    /// <param name="HeaderForeColor1">Màu chữ SỞ NÔNG NGHIỆP & PTNT CÀ MAU</param>
    /// <param name="HeaderFont1">Kích thước chữ SỞ NÔNG NGHIỆP & PTNT CÀ MAU</param>
    /// <param name="Title2">TRUNG TÂM GIỐNG NÔNG NGHIỆP</param>
    /// <param name="HeaderBackgroundColor2">Màu nền TRUNG TÂM GIỐNG NÔNG NGHIỆP</param>
    /// <param name="HeaderForeColor2">Màu chữ TRUNG TÂM GIỐNG NÔNG NGHIỆP</param>
    /// <param name="HeaderFon2">Kích thước TRUNG TÂM GIỐNG NÔNG NGHIỆP</param>
    /// <param name="Title3">Số: /TB.GNN</param>
    /// <param name="HeaderBackgroundColor3">Màu nền Số: /TB.GNN</param>
    /// <param name="HeaderForeColor3">Màu chữ Số: /TB.GNN</param>
    /// <param name="HeaderFon3">Kích thước Số: /TB.GNN</param>
    /// <param name="Title4">CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</param>
    /// <param name="HeaderBackgroundColor4">Màu nền CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</param>
    /// <param name="HeaderForeColor4">Màu chữ CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</param>
    /// <param name="HeaderFon4">Kích thước CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</param>
    /// <param name="Title5">Độc lập - Tự do - Hạnh phúc</param>
    /// <param name="HeaderBackgroundColor5">Màu nền Độc lập - Tự do - Hạnh phúc</param>
    /// <param name="HeaderForeColor5">Màu chữ Độc lập - Tự do - Hạnh phúc</param>
    /// <param name="HeaderFon5">Kích thước Độc lập - Tự do - Hạnh phúc</param>

    /// <returns></returns>
    public static string Export8Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont,
                             string Title1, XLColor HeaderBackgroundColor1, XLColor HeaderForeColor1, int HeaderFont1,
                             string Title2, XLColor HeaderBackgroundColor2, XLColor HeaderForeColor2, int HeaderFont2,
                             string Title3, XLColor HeaderBackgroundColor3, XLColor HeaderForeColor3, int HeaderFont3,
                             string Title4, XLColor HeaderBackgroundColor4, XLColor HeaderForeColor4, int HeaderFont4,
                             string Title5, XLColor HeaderBackgroundColor5, XLColor HeaderForeColor5, int HeaderFont5,
                             bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                             XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                             XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response, int[] arrWidhtCollum)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.ShowGridLines = false;
                ws.Style.Font.FontName = "Times New Roman";
                ws.Cell("A1").Value = Title1;
                ws.Cell("A2").Value = Title2;
                ws.Cell("A3").Value = Title3;

                ws.Cell("D1").Value = Title4;
                ws.Cell("D2").Value = Title5;

                ws.Cell("A5").Value = Title;
                if (DateRange)
                {
                    ws.Cell("A4").Value = "Cà Mau, " + ExportDate;
                }
                else
                {
                    ws.Cell("A4").Value = "";
                }

                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 6;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                        StartCharCols++;
                    }
                }
                #endregion

                //Merging Header

                string Range = "A5:" + StartCharCols.ToString() + "5";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A4:" + StartCharCols.ToString() + "4";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                //border definitions for Columns
                Range = "A6:" + StartCharCols.ToString() + "6";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                //gộp A1:B1
                Range = "A1:B1";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont1;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor1 != null && HeaderForeColor1 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor1;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor1;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp A2:B2
                Range = "A2:B2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont2;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor2 != null && HeaderForeColor2 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor2;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor2;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp A3:B3
                Range = "A3:B3";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont3;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor3 != null && HeaderForeColor3 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor3;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor3;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp D1:F1
                Range = "D1:F1";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont4;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor4 != null && HeaderForeColor4 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor4;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor4;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp D2:F2
                Range = "D2:F2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont5;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor5 != null && HeaderForeColor5 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor5;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor5;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp D3:F3
                Range = "D3:F3";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp C1:C3
                Range = "C1:C3";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 7;

                //char StartCharDataCol = char.MinValue;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        a = a.Replace("&gt;", ">");
                        a = a.Replace("&lt;", "<");
                        //check if value is of integer type
                        int val = 0;
                        DateTime dt = DateTime.Now;
                        if (int.TryParse(a, out val))
                        {
                            ws.Cell(DataCell).Value = val;
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        //check if datetime type
                        else if (DateTime.TryParse(a, out dt))
                        {
                            ws.Cell(DataCell).Value = dt.ToShortDateString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        ws.Cell(DataCell).SetValue(a);
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        string Cell = "";
                        if (StartCharData == 'B')
                        {
                            Cell = StartCharData.ToString() + StartIndexData;
                            ws.Cell(Cell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 6;
                Range = "A7:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Code to save the file
                //HttpResponseBase httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }

                //httpResponse.End();
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu!";
        }
    }
    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable có merge cột (số cột merge động)
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <param name="ColumStartMerge">Cột bắt đầu gộp</param>
    /// <param name="NumberColumMerge">Số cột gôp</param>
    /// <param name="NameColumMerge">Tên cột gộp</param>
    /// <param name="HeightRowMerge">Chiều cao dòng gộp</param>
    /// 
    /// <param name="Title1">SỞ NÔNG NGHIỆP & PTNT CÀ MAU</param>
    /// <param name="HeaderBackgroundColor1">Màu nền SỞ NÔNG NGHIỆP & PTNT CÀ MAU</param>
    /// <param name="HeaderForeColor1">Màu chữ SỞ NÔNG NGHIỆP & PTNT CÀ MAU</param>
    /// <param name="HeaderFont1">Kích thước chữ SỞ NÔNG NGHIỆP & PTNT CÀ MAU</param>
    /// <param name="Title2">TRUNG TÂM GIỐNG NÔNG NGHIỆP</param>
    /// <param name="HeaderBackgroundColor2">Màu nền TRUNG TÂM GIỐNG NÔNG NGHIỆP</param>
    /// <param name="HeaderForeColor2">Màu chữ TRUNG TÂM GIỐNG NÔNG NGHIỆP</param>
    /// <param name="HeaderFon2">Kích thước TRUNG TÂM GIỐNG NÔNG NGHIỆP</param>
    /// <param name="Title3">Số: /TB.GNN</param>
    /// <param name="HeaderBackgroundColor3">Màu nền Số: /TB.GNN</param>
    /// <param name="HeaderForeColor3">Màu chữ Số: /TB.GNN</param>
    /// <param name="HeaderFon3">Kích thước Số: /TB.GNN</param>
    /// <param name="Title4">CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</param>
    /// <param name="HeaderBackgroundColor4">Màu nền CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</param>
    /// <param name="HeaderForeColor4">Màu chữ CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</param>
    /// <param name="HeaderFon4">Kích thước CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</param>
    /// <param name="Title5">Độc lập - Tự do - Hạnh phúc</param>
    /// <param name="HeaderBackgroundColor5">Màu nền Độc lập - Tự do - Hạnh phúc</param>
    /// <param name="HeaderForeColor5">Màu chữ Độc lập - Tự do - Hạnh phúc</param>
    /// <param name="HeaderFon5">Kích thước Độc lập - Tự do - Hạnh phúc</param>
    /// 
    /// <returns></returns>
    public static string Export9Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont, int HeaderHeightRow,
                                     string Title1, XLColor HeaderBackgroundColor1, XLColor HeaderForeColor1, int HeaderFont1,
                                     string Title2, XLColor HeaderBackgroundColor2, XLColor HeaderForeColor2, int HeaderFont2,
                                     string Title3, XLColor HeaderBackgroundColor3, XLColor HeaderForeColor3, int HeaderFont3,
                                     string Title4, XLColor HeaderBackgroundColor4, XLColor HeaderForeColor4, int HeaderFont4,
                                     string Title5, XLColor HeaderBackgroundColor5, XLColor HeaderForeColor5, int HeaderFont5,
                                     bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                                     XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                                     XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response,
                                     int[] arrWidhtCollum, int ColumStartMerge, int NumberColumMerge, string NameColumMerge, int HeightRowMerge)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.ShowGridLines = false;
                ws.Style.Font.FontName = "Times New Roman";
                ws.Cell("A1").Value = Title1;
                ws.Cell("A2").Value = Title2;
                ws.Cell("A3").Value = Title3;

                ws.Cell("D1").Value = Title4;
                ws.Cell("D2").Value = Title5;

                ws.Cell("A5").Value = Title;
                if (DateRange)
                {
                    ws.Cell("A4").Value = "Cà Mau, " + ExportDate;
                }
                else
                {
                    ws.Cell("A4").Value = "";
                }

                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 6;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        string RangeRowMerge = StartCharCols.ToString() + "6:" + StartCharCols.ToString() + "7";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        int socot = ColumStartMerge + NumberColumMerge;
                        if (i == ColumStartMerge)
                        {
                            char CharMerge = StartCharCols;
                            char cotBD = StartCharCols;
                            for (int c = ColumStartMerge; c < socot; c++)
                            {
                                string DataCell = CharMerge.ToString() + "7";
                                ws.Cell(DataCell).Value = cols[c - 1];
                                ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                ws.Cell(DataCell).Style.Font.Bold = true;
                                ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                CharMerge++;
                                StartCharCols++;
                            }
                            CharMerge--;//trừ 1
                            string RangeHeadTable = cotBD.ToString() + StartIndexCols.ToString() + ":" + CharMerge.ToString() + StartIndexCols.ToString();
                            ws.Cell(cotBD.ToString() + StartIndexCols.ToString()).Value = NameColumMerge;
                            ws.Range(RangeHeadTable).Merge();
                            ws.Row(3).Height = HeightRowMerge;//Chiều cao dòng cần merge
                            ws.Range(RangeHeadTable).Style.Font.Bold = true;
                            ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                            ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                            ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                            ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Range(RangeHeadTable).Style.Font.FontColor = ColumnForeColor;

                        }
                        else if (i < ColumStartMerge || i >= socot)//cột không liên quan cột merge và khác cột cuối
                        {
                            string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                            string RangeRowMerge = StartCharCols.ToString() + "6:" + StartCharCols.ToString() + "7";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                            StartCharCols++;
                        }
                    }
                }
                #endregion

                //Merging Header

                string Range = "A5:" + StartCharCols.ToString() + "5";

                ws.Range(Range).Merge();
                ws.Row(1).Height = HeaderHeightRow;
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A4:" + StartCharCols.ToString() + "4";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                //border definitions for Columns
                Range = "A6:" + StartCharCols.ToString() + "7";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                //gộp A1:B1
                Range = "A1:B1";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont1;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor1 != null && HeaderForeColor1 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor1;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor1;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp A2:B2
                Range = "A2:B2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont2;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor2 != null && HeaderForeColor2 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor2;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor2;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp A3:B3
                Range = "A3:B3";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont3;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor3 != null && HeaderForeColor3 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor3;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor3;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp D1:F1
                Range = "D1:F1";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont4;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor4 != null && HeaderForeColor4 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor4;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor4;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp D2:F2
                Range = "D2:F2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont5;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor5 != null && HeaderForeColor5 != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor5;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor5;
                }
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp D3:F3
                Range = "D3:F3";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;

                //gộp C1:C3
                Range = "C1:C3";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.None;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.None;



                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 8;

                //char StartCharDataCol = char.MinValue;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        a = a.Replace("&gt;", ">");
                        a = a.Replace("&lt;", "<");
                        //check if value is of integer type
                        int val = 0;
                        DateTime dt = DateTime.Now;
                        if (int.TryParse(a, out val))
                        {
                            ws.Cell(DataCell).Value = val;
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        //check if datetime type
                        else if (DateTime.TryParse(a, out dt))
                        {
                            ws.Cell(DataCell).Value = dt.ToShortDateString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        ws.Cell(DataCell).SetValue(a);
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        string Cell = "";
                        if (StartCharData == 'B')
                        {
                            Cell = StartCharData.ToString() + StartIndexData;
                            ws.Cell(Cell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 7;
                Range = "A8:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ////Code to save the file
                //HttpResponse httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                //// Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(httpResponse.OutputStream);
                //    memoryStream.Close();
                //}

                //httpResponse.End();
                //return "Ok";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu!";
        }
    }
    /// <summary>
    /// Xuất ra tập tin Excel từ DataTable
    /// </summary>
    /// <param name="Title">Tiêu đề lớn trên cùng</param>
    /// <param name="HeaderBackgroundColor">Màu nền tiêu đề</param>
    /// <param name="HeaderForeColor">Màu chữ tiêu đề</param>
    /// <param name="HeaderFont">Kích thước chữ tiêu đề</param>
    /// <param name="DateRange">Hiển thị ngày xuất hay không</param>
    /// <param name="ExportDate">Ngày xuất</param>
    /// <param name="DateRangeBackgroundColor">Màu nền ngày xuất</param>
    /// <param name="DateRangeForeColor">Màu chữ ngày xuất</param>
    /// <param name="DateRangeFont">Kích thước chữ ngày xuất</param>
    /// <param name="DataTable">Dữ liệu dạng DataTable</param>
    /// <param name="ColumnBackgroundColor">Màu nền cột</param>
    /// <param name="ColumnForeColor">Màu chữ cột</param>
    /// <param name="SheetName">Tên sheet</param>
    /// <param name="FileName">Tên file lưu</param>
    /// <param name="response">Phương thức trả về</param>
    /// <param name="arrWidhtCollum">Mảng độ rộng từng cột (Lưu ý: số phần tử trong mảng phải trùng với số cột)</param>
    /// <returns></returns>
    public static string Export10Excel(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont,
                             bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                             XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                             XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response, int[] arrWidhtCollum)
    {
        try
        {
            DataTable table = DataTable;
            if (DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(SheetName);
                ws.ShowGridLines = false;
                ws.Style.Font.FontName = "Times New Roman";
                ws.Cell("A1").Value = Title;
                if (DateRange)
                {
                    ws.Cell("A2").Value = ExportDate;
                }
                else
                {
                    ws.Cell("A2").Value = "";
                }

                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 3;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                        StartCharCols++;
                    }
                }
                #endregion

                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                //border definitions for Columns
                Range = "A3:" + StartCharCols.ToString() + "3";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 4;

                //char StartCharDataCol = char.MinValue;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        a = a.Replace("&gt;", ">");
                        a = a.Replace("&lt;", "<");
                        //check if value is of integer type
                        int val = 0;
                        DateTime dt = DateTime.Now;
                        if (int.TryParse(a, out val))
                        {
                            ws.Cell(DataCell).Value = val;
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        //check if datetime type
                        else if (DateTime.TryParse(a, out dt))
                        {
                            ws.Cell(DataCell).Value = dt.ToShortDateString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        ws.Cell(DataCell).SetValue(a);
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        string Cell = "";
                        if (StartCharData == 'B')
                        {
                            Cell = StartCharData.ToString() + StartIndexData;
                            ws.Cell(Cell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }

                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 3;
                Range = "A4:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Code to save the file
                //HttpResponseBase httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                // Flush the workbook to the Response.OutputStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }

                //httpResponse.End();
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception)
        {
            return "Lỗi dữ liệu!";
        }
    }
    //-------------------------------------------------------------------------------------------------------------------
    #region V2.0 --Update input style

    public class EXF
    {
        public class StyleFormat
        {
            public Style Header { get; set; }
            public Style DateRange { get; set; }
            public Style Column { get; set; }
            public StyleFormat()
            {
                Header = new Style();
                DateRange = new Style();
                Column = new Style();
            }
            public class Style
            {
                public XLColor Background { get; set; }
                public XLColor Foreground { get; set; }
                public int FontSize { get; set; }
                public int Height { get; set; }
                public bool Show { get; set; }

            }
        }
        public class FLStyle
        {
            public Type Type { get; set; }
            public XLColor Background { get; set; }
            public XLColor Foreground { get; set; }
            public int Height { get; set; }
        }
        public class Type
        {
            public const string Header = "Header";
            public const string DateRange = "DateRange";
        }

        public class Export4
        {
            public string FileName { get; set; }
            public string Title { get; set; }
            public string SheetName { get; set; }
            public bool DateRange { get; set; }
            public string ExportDate { get; set; }
            public DataTable DataTable { get; set; }
            public int[] arrWidhtCollum { get; set; }
            public List<ExportExcel.ColumsMerge> _ListColumsMerge { get; set; }
            public int[] _ListCollumTypeNumberDouble { get; set; }
            public int[] _ListCollumTypeNumberInt { get; set; }
            public Export4()
            {
                FileName = "DanhSach";
                Title = "Danh sách";
                SheetName = "Sheet1";
                DateRange = true;
                DataTable = new DataTable();
                arrWidhtCollum = new Int32[] { };
                _ListColumsMerge = new List<ColumsMerge>();
                _ListCollumTypeNumberDouble = new Int32[] { };
                _ListCollumTypeNumberInt = new Int32[] { };
            }
        }
        public class Export6 : Export4
        {
            public List<ExportExcel.ColumsMerge> _ListColumsMerge2 { get; set; }
            public Export6()
            {
                _ListColumsMerge2 = new List<ColumsMerge>();
            }
        }
    }

    public static void SetDefaultStyle(out EXF.StyleFormat defaultFormat)
    {
        defaultFormat = new EXF.StyleFormat();
        /// Header
        defaultFormat.Header.Background = XLColor.White;
        defaultFormat.Header.Foreground = XLColor.Black;
        defaultFormat.Header.FontSize = 20;
        defaultFormat.Header.Height = 40;

        ///DateRange
        defaultFormat.DateRange.Background = XLColor.White;
        defaultFormat.DateRange.Foreground = XLColor.Black;
        defaultFormat.Header.FontSize = 12;
        defaultFormat.DateRange.Height = 20;
        defaultFormat.DateRange.Show = true;

        ///Column
        defaultFormat.Column.Background = XLColor.White;
        defaultFormat.Column.Foreground = XLColor.Black;
    }
    private static void MapStyleDefault(ref EXF.StyleFormat.Style style)
    {
        style.Background = style.Background != null ? style.Background : XLColor.White;
        style.Foreground = style.Foreground != null ? style.Background : XLColor.Black;
        style.FontSize = style.FontSize != 0 ? style.FontSize : 12;
        style.Height = style.Height != 0 ? style.Height : 20;
        style.Show = style.Show;
    }
    public static void SetStyle(EXF.StyleFormat.Style style, string type, ref EXF.StyleFormat defaultFormat)
    {
        MapStyleDefault(ref style);
        switch (type)
        {
            case "Header":
                defaultFormat.Header.Background = style.Background;
                defaultFormat.Header.Foreground = style.Foreground;
                defaultFormat.Header.FontSize = style.FontSize;
                defaultFormat.Header.Height = style.Height;
                //default show header
                //defaultFormat.Header.Show = style.Show;
                break;
            case "DateRange":
                defaultFormat.DateRange.Background = style.Background;
                defaultFormat.DateRange.Foreground = style.Foreground;
                defaultFormat.DateRange.FontSize = style.FontSize;
                defaultFormat.DateRange.Height = style.Height;
                defaultFormat.DateRange.Show = style.Show;
                break;
            case "Column":
                defaultFormat.Column.Background = style.Background;
                defaultFormat.Column.Foreground = style.Foreground;
                break;
        }
    }
    public static string MultipleSheet(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont, int HeaderHeightRow,
                                     bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                                     XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                                     XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response,
                                     int[] arrWidhtCollum, List<ColumsMerge> _ListColumsMerge, int[] _ListCollumTypeNumberDouble, int[] _ListCollumTypeNumberInt,
                                     DataTable DataTable2, string TableName2, DataTable DataTable3, string TableName3,
                                     DataTable DataTable4, string TableName4, DataTable DataTable5, string TableName5,
                                     DataTable DataTable6, string TableName6,
                                     string TenHuyen)
    {
        try
        {
            var wb = new XLWorkbook();
            DataTable table = DataTable;

            if (DataTable != null)
            {
                var ws = wb.Worksheets.Add(SheetName);
                //
                // DataTable mutiple 2,3,4,5,6
                //-----------------------
                InsertSheet(wb, DataTable2, TableName2);
                InsertSheet(wb, DataTable3, TableName3);
                InsertSheet(wb, DataTable4, TableName4);
                InsertSheet(wb, DataTable5, TableName5);
                InsertSheet(wb, DataTable6, TableName6);
                //-----------------------

                string[] arrCols = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                    "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                ws.Cell("A1").Value = Title;

                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                int StartCharCols = 0;
                int StartIndexCols = 3;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = arrCols[StartCharCols] + StartIndexCols.ToString();
                        string RangeRowMerge = arrCols[StartCharCols] + "3:" + arrCols[StartCharCols] + "4";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        int kytu = StartCharCols;
                        foreach (var item in _ListColumsMerge)
                        {
                            int n = item.CotBD + item.SoCotGop;
                            if (i == item.CotBD)
                            {
                                int CharMerge = StartCharCols;
                                int kyTuCotBD = StartCharCols;
                                for (int c = item.CotBD; c < n; c++)
                                {
                                    string DataCell = arrCols[CharMerge] + "4";
                                    ws.Cell(DataCell).Value = cols[c - 1];
                                    ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                    ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                    ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Cell(DataCell).Style.Font.Bold = true;
                                    ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                    ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                    CharMerge++;
                                    StartCharCols++;
                                }
                                CharMerge--;//trừ 1
                                string RangeHeadTable = arrCols[kyTuCotBD] + StartIndexCols.ToString() + ":" + arrCols[CharMerge] + StartIndexCols.ToString();
                                ws.Cell(arrCols[kyTuCotBD] + StartIndexCols.ToString()).Value = item.Ten;
                                ws.Range(RangeHeadTable).Merge();
                                ws.Row(3).Height = item.ChieuCaoDong;//Chiều cao dòng cần merge
                                ws.Range(RangeHeadTable).Style.Font.Bold = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                                ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                ws.Range(RangeHeadTable).Style.Font.FontColor = ColumnForeColor;
                                i = n - 1;
                            }
                        }
                        if (kytu == StartCharCols)
                        {
                            string DataCell = arrCols[StartCharCols] + StartIndexCols.ToString();
                            string RangeRowMerge = arrCols[StartCharCols] + "3:" + arrCols[StartCharCols] + "4";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                            StartCharCols++;
                        }
                        if (i == cols.Length)
                        {
                            //Giảm lại 1 ký tự do cộng lên cuối cùng
                            StartCharCols--;
                        }
                    }

                }
                #endregion

                //Merging Header

                string Range = "A1:" + arrCols[StartCharCols] + "1";

                ws.Range(Range).Merge();
                ws.Row(1).Height = HeaderHeightRow;
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for tên Huyện
                string Range_Huyen = "A2:C2";
                ws.Cell("A2").Value = (!string.IsNullOrEmpty(TenHuyen)) ? TenHuyen : "";
                ws.Range(Range_Huyen).Merge();
                ws.Range(Range_Huyen).Style.Font.FontSize = 14;
                ws.Range(Range_Huyen).Style.Font.Bold = true;
                ws.Range(Range_Huyen).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range_Huyen).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                //Style definitions for Date range
                Range = "D2:" + arrCols[StartCharCols] + "2";
                if (DateRange)
                    ws.Cell("D2").Value = "Ngày xuất: " + ExportDate;
                else
                    ws.Cell("D2").Value = "";
                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


                //border definitions for Columns
                Range = "A3:" + arrCols[StartCharCols] + "4";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                int StartCharData = 0;
                int StartIndexData = 5;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int k_int = 0, k_double = 0;//Dùng tối ưu vòng lặp
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        string DataCell = arrCols[StartCharData] + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val_int = 0;
                        DateTime dt = DateTime.Now;
                        double val_double = 0;

                        bool Cell_Double = false, Cell_Int = false;
                        for (int k = k_double; k < _ListCollumTypeNumberDouble.Count(); k++)
                        {
                            if (StartCharData == (_ListCollumTypeNumberDouble[k] - 1))//Do StartCharData chạy từ 0
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 4;//4 định dạng là #,##0.00 (Xem trong Format Cell in excel)
                                Cell_Double = true;
                                k_double = k + 1;
                                break;
                            }
                        }
                        for (int k = k_int; k < _ListCollumTypeNumberInt.Count(); k++)
                        {
                            if (StartCharData == (_ListCollumTypeNumberInt[k] - 1))
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 2;//2 định dạng là 0 (Xem trong Format Cell in excel)
                                Cell_Int = true;
                                k_int = k + 1;
                                break;
                            }
                        }
                        if ((int.TryParse(a, out val_int) && j == 0) || (int.TryParse(a, out val_int) && Cell_Int))//--Cột số thứ tự hoặc cột kiểu int
                        {
                            ws.Cell(DataCell).Value = val_int;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else if (double.TryParse(a, out val_double) && Cell_Double)//--Cột số kiểu double
                        {
                            ws.Cell(DataCell).Value = val_double;
                            if (val_double == 0) ws.Cell(DataCell).Value = 0;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else
                        {
                            ws.Cell(DataCell).Value = a.ToString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        StartCharData++;
                    }
                    StartCharData = 0;//reset vị trí về 0
                    StartIndexData++;
                }
                #endregion

                int LastChar = table.Columns.Count - 1;
                int TotalRows = table.Rows.Count + 4;
                Range = "A5:" + arrCols[LastChar] + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ////Code to save the file
                //HttpResponse httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                //// Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(httpResponse.OutputStream);
                //    memoryStream.Close();
                //}

                //httpResponse.End();
                //return "Ok";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception ex)
        {
            return "Lỗi dữ liệu";
        }
    }
    /// <summary>
    /// Xuất excel có 1 dòng thông tin đầu table( Ex: Tên huyện)
    /// </summary>
    /// <param name="Title"></param>
    /// <param name="HeaderBackgroundColor"></param>
    /// <param name="HeaderForeColor"></param>
    /// <param name="HeaderFont"></param>
    /// <param name="HeaderHeightRow"></param>
    /// <param name="DateRange"></param>
    /// <param name="ExportDate"></param>
    /// <param name="DateRangeBackgroundColor"></param>
    /// <param name="DateRangeForeColor"></param>
    /// <param name="DateRangeFont"></param>
    /// <param name="DataTable"></param>
    /// <param name="ColumnBackgroundColor"></param>
    /// <param name="ColumnForeColor"></param>
    /// <param name="SheetName"></param>
    /// <param name="FileName"></param>
    /// <param name="response"></param>
    /// <param name="arrWidhtCollum"></param>
    /// <param name="_ListColumsMerge"></param>
    /// <param name="_ListCollumTypeNumberDouble"></param>
    /// <param name="_ListCollumTypeNumberInt"></param>
    /// <param name="ThongTin"></param>
    /// <returns></returns>
    public static string Excel1RowInforSheet(string Title, XLColor HeaderBackgroundColor, XLColor HeaderForeColor, int HeaderFont, int HeaderHeightRow,
                                     bool DateRange, string ExportDate, XLColor DateRangeBackgroundColor,
                                     XLColor DateRangeForeColor, int DateRangeFont, DataTable DataTable, XLColor ColumnBackgroundColor,
                                     XLColor ColumnForeColor, string SheetName, string FileName, HttpResponseBase response,
                                     int[] arrWidhtCollum, List<ColumsMerge> _ListColumsMerge, int[] _ListCollumTypeNumberDouble, int[] _ListCollumTypeNumberInt,
                                     string ThongTin)
    {
        try
        {
            var wb = new XLWorkbook();
            DataTable table = DataTable;

            if (DataTable != null)
            {
                var ws = wb.Worksheets.Add(SheetName);

                string[] arrCols = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                    "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ" };
                ws.Cell("A1").Value = Title;

                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                int StartCharCols = 0;
                int StartIndexCols = 3;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = arrCols[StartCharCols] + StartIndexCols.ToString();
                        string RangeRowMerge = arrCols[StartCharCols] + "3:" + arrCols[StartCharCols] + "4";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                        ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                    }
                    else
                    {
                        int kytu = StartCharCols;
                        foreach (var item in _ListColumsMerge)
                        {
                            int n = item.CotBD + item.SoCotGop;
                            if (i == item.CotBD)
                            {
                                int CharMerge = StartCharCols;
                                int kyTuCotBD = StartCharCols;
                                for (int c = item.CotBD; c < n; c++)
                                {
                                    string DataCell = arrCols[CharMerge] + "4";
                                    ws.Cell(DataCell).Value = cols[c - 1];
                                    ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                    ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                    ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Cell(DataCell).Style.Font.Bold = true;
                                    ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                    ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                                    CharMerge++;
                                    StartCharCols++;
                                }
                                CharMerge--;//trừ 1
                                string RangeHeadTable = arrCols[kyTuCotBD] + StartIndexCols.ToString() + ":" + arrCols[CharMerge] + StartIndexCols.ToString();
                                ws.Cell(arrCols[kyTuCotBD] + StartIndexCols.ToString()).Value = item.Ten;
                                ws.Range(RangeHeadTable).Merge();
                                ws.Row(3).Height = item.ChieuCaoDong;//Chiều cao dòng cần merge
                                ws.Range(RangeHeadTable).Style.Font.Bold = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                                ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                                ws.Range(RangeHeadTable).Style.Font.FontColor = ColumnForeColor;
                                i = n - 1;
                            }
                        }
                        if (kytu == StartCharCols)
                        {
                            string DataCell = arrCols[StartCharCols] + StartIndexCols.ToString();
                            string RangeRowMerge = arrCols[StartCharCols] + "3:" + arrCols[StartCharCols] + "4";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = ColumnBackgroundColor;
                            ws.Cell(DataCell).Style.Font.FontColor = ColumnForeColor;
                            StartCharCols++;
                        }
                        if (i == cols.Length)
                        {
                            //Giảm lại 1 ký tự do cộng lên cuối cùng
                            StartCharCols--;
                        }
                    }

                }
                #endregion

                //Merging Header

                string Range = "A1:" + arrCols[StartCharCols] + "1";

                ws.Range(Range).Merge();
                ws.Row(1).Height = HeaderHeightRow;
                ws.Range(Range).Style.Font.FontSize = HeaderFont;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (HeaderBackgroundColor != null && HeaderForeColor != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = HeaderBackgroundColor;
                    ws.Range(Range).Style.Font.FontColor = HeaderForeColor;
                }

                //Style definitions for tên Huyện
                string Range_Huyen = "A2:C2";
                ws.Cell("A2").Value = (!string.IsNullOrEmpty(ThongTin)) ? ThongTin : "";
                ws.Range(Range_Huyen).Merge();
                ws.Range(Range_Huyen).Style.Font.FontSize = 14;
                ws.Range(Range_Huyen).Style.Font.Bold = true;
                ws.Range(Range_Huyen).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range_Huyen).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                //Style definitions for Date range
                Range = "D2:" + arrCols[StartCharCols] + "2";
                if (DateRange)
                    ws.Cell("D2").Value = "Ngày xuất: " + ExportDate;
                else
                    ws.Cell("D2").Value = "";
                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


                //border definitions for Columns
                Range = "A3:" + arrCols[StartCharCols] + "4";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                int StartCharData = 0;
                int StartIndexData = 5;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int k_int = 0, k_double = 0;//Dùng tối ưu vòng lặp
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        string DataCell = arrCols[StartCharData] + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val_int = 0;
                        DateTime dt = DateTime.Now;
                        double val_double = 0;

                        bool Cell_Double = false, Cell_Int = false;
                        for (int k = k_double; k < _ListCollumTypeNumberDouble.Count(); k++)
                        {
                            if (StartCharData == (_ListCollumTypeNumberDouble[k] - 1))//Do StartCharData chạy từ 0
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 4;//4 định dạng là #,##0.00 (Xem trong Format Cell in excel)
                                Cell_Double = true;
                                k_double = k + 1;
                                break;
                            }
                        }
                        for (int k = k_int; k < _ListCollumTypeNumberInt.Count(); k++)
                        {
                            if (StartCharData == (_ListCollumTypeNumberInt[k] - 1))
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 2;//2 định dạng là 0 (Xem trong Format Cell in excel)
                                Cell_Int = true;
                                k_int = k + 1;
                                break;
                            }
                        }
                        if ((int.TryParse(a, out val_int) && j == 0) || (int.TryParse(a, out val_int) && Cell_Int))//--Cột số thứ tự hoặc cột kiểu int
                        {
                            ws.Cell(DataCell).Value = val_int;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else if (double.TryParse(a, out val_double) && Cell_Double)//--Cột số kiểu double
                        {
                            ws.Cell(DataCell).Value = val_double;
                            if (val_double == 0) ws.Cell(DataCell).Value = 0;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else
                        {
                            ws.Cell(DataCell).Value = a.ToString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        StartCharData++;
                    }
                    StartCharData = 0;//reset vị trí về 0
                    StartIndexData++;
                }
                #endregion

                int LastChar = table.Columns.Count - 1;
                int TotalRows = table.Rows.Count + 4;
                Range = "A5:" + arrCols[LastChar] + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ////Code to save the file
                //HttpResponse httpResponse = response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + FileName);

                //// Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(httpResponse.OutputStream);
                //    memoryStream.Close();
                //}

                //httpResponse.End();
                //return "Ok";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }
                return FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception ex)
        {
            return "Lỗi dữ liệu";
        }
    }

    private static void InsertSheet(XLWorkbook wb, DataTable table, string tableName)
    {
        if (table != null)
        {
            var ws2 = wb.Worksheets.Add(Utility.ConvertToUnsign(tableName.Replace(" ", "")).ToUpper());

            ws2.Cell(2, 1).Value = tableName;
            ws2.Range(2, 1, 2, 2).Merge();
            ws2.Cell("A2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws2.Cell("A2").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            ws2.Cell("A2").Style.Font.Bold = true;

            ws2.Cell("B3").WorksheetColumn().Width = 25;
            ws2.Cell("B3").Style.Alignment.WrapText = true;
            var rangeWithData = ws2.Cell(3, 1).InsertData(table.AsEnumerable());

            var Range = "A3:B" + (table.Rows.Count + 2);
            ws2.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws2.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws2.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws2.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        }
    }
    #endregion

    #region V3
    /// <summary>
    /// Hàm mẫu không sử dụng chỉ dùng tham khảo
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public string HamMau()
    {
        var defaultFormat = new EXF.StyleFormat();
        var Input = new EXF.Export6();
        SetDefaultStyle(out defaultFormat);
        //Cần dùng style nào thì gán giá trị vào, không cần gán hết
        defaultFormat.Header.Height = 40;

        DataTable dt = new DataTable();
        //Xữ lý thông tin cho DataTable
        Input.DataTable = dt;
        Input.arrWidhtCollum = new Int32[] { 3, 35, 15, 15, 35 };//Lưu ý mảng độ rộng cột phải bằng số cột trong DataTable
        Input._ListColumsMerge.Add(new ExportExcel.ColumsMerge { CotBD = 4, SoCotGop = 2, Ten = "Tên cột gộp", ChieuCaoDong = 20 });
        Input._ListColumsMerge2.Add(new ExportExcel.ColumsMerge { CotBD = 4, SoCotGop = 2, Ten = "Tên cột gộp", ChieuCaoDong = 20 });
        Input._ListCollumTypeNumberDouble = new int[] { 3, 4 };
        Input._ListCollumTypeNumberInt = new int[] { 1, 6 };
        V3_Export6_2Excel(defaultFormat, Input);
        return "";
    }

    /// <summary>
    /// Dùng cho trường hợp có merge cột 
    /// </summary>
    /// <param name="StyleFormat">Style mặc định</param>
    /// <param name="Input">object chứa thông tin đầu vào</param>
    /// <returns></returns>
    public static string V3_Export4Excel(EXF.StyleFormat StyleFormat, EXF.Export4 Input)
    {
        try
        {
            //---------------------------------------
            //Tạm thời chưa dùng style cho DateRange
            //---------------------------------------

            //XLColor DateRangeBackgroundColor = defaultFormat.DateRange.Background;
            //XLColor DateRangeForeColor = defaultFormat.DateRange.Foreground;
            //int DateRangeFont = defaultFormat.DateRange.FontSize;
            //---------------------------------------

            if (string.IsNullOrEmpty(Input.ExportDate))
            {
                Input.ExportDate = "ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            }
            
            DataTable table = Input.DataTable;
            if (Input.DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(Input.SheetName);
                ws.Cell("A1").Value = Input.Title;
                if (Input.DateRange)
                    ws.Cell("A2").Value = "Ngày xuất: " + Input.ExportDate;
                else
                    ws.Cell("A2").Value = "";
                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }

                char StartCharCols = 'A';
                int StartIndexCols = 3;
                #region CreatingColumnHeaders - Dòng đầu trong DataTable
                var ArrayWidthCol = Input.arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "4";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                        ws.Cell(DataCell).Style.Font.FontColor = StyleFormat.Column.Foreground;
                    }
                    else
                    {
                        int kytu = StartCharCols;
                        foreach (var item in Input._ListColumsMerge)
                        {
                            int n = item.CotBD + item.SoCotGop;
                            if (i == item.CotBD)
                            {
                                char CharMerge = StartCharCols;
                                char kyTuCotBD = StartCharCols;
                                for (int c = item.CotBD; c < n; c++)
                                {
                                    string DataCell = CharMerge.ToString() + "4";
                                    ws.Cell(DataCell).Value = cols[c - 1];
                                    ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                    ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                    ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Cell(DataCell).Style.Font.Bold = true;
                                    ws.Cell(DataCell).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                                    ws.Cell(DataCell).Style.Font.FontColor = StyleFormat.Column.Foreground;
                                    CharMerge++;
                                    StartCharCols++;
                                }
                                CharMerge--;//trừ 1
                                string RangeHeadTable = kyTuCotBD.ToString() + StartIndexCols.ToString() + ":" + CharMerge.ToString() + StartIndexCols.ToString();
                                ws.Cell(kyTuCotBD.ToString() + StartIndexCols.ToString()).Value = item.Ten;
                                ws.Range(RangeHeadTable).Merge();
                                ws.Row(3).Height = item.ChieuCaoDong;//Chiều cao dòng cần merge
                                ws.Range(RangeHeadTable).Style.Font.Bold = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                                ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                                ws.Range(RangeHeadTable).Style.Font.FontColor = StyleFormat.Column.Foreground;
                                i = n - 1;
                            }
                        }
                        if (kytu.Equals(StartCharCols))
                        {
                            string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                            string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "4";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                            ws.Cell(DataCell).Style.Font.FontColor = StyleFormat.Column.Foreground;
                            StartCharCols++;
                        }
                        if (i == cols.Length)
                        {
                            //Giảm lại 1 ký tự do cộng lên cuối cùng
                            StartCharCols--;
                        }
                    }

                }
                #endregion

                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Row(1).Height = StyleFormat.Header.Height;
                ws.Range(Range).Style.Font.FontSize = StyleFormat.Header.FontSize;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (StyleFormat.Header.Background != null && StyleFormat.Header.Foreground != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = StyleFormat.Header.Background;
                    ws.Range(Range).Style.Font.FontColor = StyleFormat.Header.Foreground;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


                //border definitions for Columns
                Range = "A3:" + StartCharCols.ToString() + "4";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 5;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int k_int = 0, k_double = 0;//Dùng tối ưu vòng lặp
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val_int = 0;
                        DateTime dt = DateTime.Now;
                        double val_double = 0;

                        bool Cell_Double = false, Cell_Int = false;
                        for (int k = k_double; k < Input._ListCollumTypeNumberDouble.Count(); k++)
                        {
                            if (StartCharData == (Input._ListCollumTypeNumberDouble[k] + 64))//Cộng cho 64 là do 65 là char 'A'
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 4;//4 định dạng là #,##0.00 (Xem trong Format Cell in excel)
                                Cell_Double = true;
                                k_double = k + 1;
                                break;
                            }
                        }
                        for (int k = k_int; k < Input._ListCollumTypeNumberInt.Count(); k++)
                        {
                            if (StartCharData == (Input._ListCollumTypeNumberInt[k] + 64))//Cộng cho 64 là do 65 là char 'A'
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 2;//2 định dạng là 0 (Xem trong Format Cell in excel)
                                Cell_Int = true;
                                k_int = k + 1;
                                break;
                            }
                        }
                        if ((int.TryParse(a, out val_int) && j == 0) || (int.TryParse(a, out val_int) && Cell_Int))//--Cột số thứ tự hoặc cột kiểu int
                        {
                            ws.Cell(DataCell).Value = val_int;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else if (double.TryParse(a, out val_double) && Cell_Double)//--Cột số kiểu double
                        {
                            ws.Cell(DataCell).Value = val_double;
                            if (val_double == 0) ws.Cell(DataCell).Value = 0;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else
                        {
                            ws.Cell(DataCell).Value = a.ToString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 4;
                Range = "A5:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ////Code to save the file
                //HttpResponse httpResponse = Input.response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + Input.FileName);

                //// Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(httpResponse.OutputStream);
                //    memoryStream.Close();
                //}

                //httpResponse.End();
                //return "Ok";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), Input.FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }
                return Input.FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception e)
        {
            return "Lỗi dữ liệu";
        }
    }

    /// <summary>
    /// Dùng cho trường hợp có merge cột (2 dòng merge cột)
    /// </summary>
    /// <param name="StyleFormat">Style mặc định</param>
    /// <param name="Input">object chứa thông tin đầu vào</param>
    /// <returns></returns>
    public static string V3_Export6_2Excel(EXF.StyleFormat StyleFormat, EXF.Export6 Input)
    {
        try
        {
            //Khai báo
            //-------------------------------
            //Tạm thời chưa dùng style cho DateRange
            //XLColor DateRangeBackgroundColor = defaultFormat.DateRange.Background;
            //XLColor DateRangeForeColor = defaultFormat.DateRange.Foreground;
            //int DateRangeFont = defaultFormat.DateRange.FontSize;

            if (string.IsNullOrEmpty(Input.ExportDate))
            {
                Input.ExportDate = "ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            }
            //-------------------------------
            DataTable table = Input.DataTable;
            if (Input.DataTable != null)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(Input.SheetName);
                ws.Cell("A1").Value = Input.Title;
                if (Input.DateRange)
                    ws.Cell("A2").Value = "Ngày xuất: " + Input.ExportDate;
                else
                    ws.Cell("A2").Value = "";
                //add columns
                string[] cols = new string[table.Columns.Count];
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    var a = table.Columns[c].ToString();
                    cols[c] = table.Columns[c].ToString().Replace('_', ' ');
                }
                #region Dòng 1
                char StartCharCols = 'A';
                int StartIndexCols = 3;
                var ArrayWidthCol = Input.arrWidhtCollum;//Lưu ý số phần tử trong mảng = số cột
                for (int i = 1; i <= cols.Length; i++)
                {
                    if (i == cols.Length)//Cột cuối
                    {
                        string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                        string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "5";
                        ws.Range(RangeRowMerge).Merge();
                        ws.Cell(DataCell).Value = cols[i - 1];
                        ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1]/*cols[i - 1].ToString().Length + 10*/;
                        ws.Cell(DataCell).Style.Alignment.WrapText = true;//Tự động xuống dòng
                        ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        ws.Cell(DataCell).Style.Font.Bold = true;
                        ws.Cell(DataCell).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                        ws.Cell(DataCell).Style.Font.FontColor = StyleFormat.Column.Foreground;
                    }
                    else
                    {
                        int kytu = StartCharCols;
                        foreach (var item in Input._ListColumsMerge)
                        {
                            int n = item.CotBD + item.SoCotGop;
                            if (i == item.CotBD)
                            {
                                char CharMerge = StartCharCols;
                                char kyTuCotBD = StartCharCols;

                                var StartCharCols2 = StartCharCols;
                                for (int c = item.CotBD; c < n; c++)
                                {
                                    string DataCell = CharMerge.ToString() + "4";
                                    ws.Cell(DataCell).Value = cols[c - 1];
                                    ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                    ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                    ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                    ws.Cell(DataCell).Style.Font.Bold = true;
                                    ws.Cell(DataCell).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                                    ws.Cell(DataCell).Style.Font.FontColor = StyleFormat.Column.Foreground;
                                    CharMerge++;
                                    StartCharCols++;
                                }
                                CharMerge--;//trừ 1
                                string RangeHeadTable = kyTuCotBD.ToString() + StartIndexCols.ToString() + ":" + CharMerge.ToString() + StartIndexCols.ToString();
                                ws.Cell(kyTuCotBD.ToString() + StartIndexCols.ToString()).Value = item.Ten;
                                ws.Range(RangeHeadTable).Merge();
                                ws.Row(3).Height = item.ChieuCaoDong;//Chiều cao dòng cần merge
                                ws.Range(RangeHeadTable).Style.Font.Bold = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetWrapText(true);
                                ws.Range(RangeHeadTable).Style.Alignment.WrapText = true;
                                ws.Range(RangeHeadTable).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                ws.Range(RangeHeadTable).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                ws.Range(RangeHeadTable).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                                ws.Range(RangeHeadTable).Style.Font.FontColor = StyleFormat.Column.Foreground;
                                i = n - 1;

                                bool dl = false;
                                //Xử lý merge dòng 2--------------------------------------------------------------------------------------------------------------------------------------------------
                                for (int j = item.CotBD; j <= n; j++)
                                {
                                    int kytu2 = StartCharCols2;
                                    foreach (var item2 in Input._ListColumsMerge2)
                                    {
                                        int n2 = item2.CotBD + item2.SoCotGop;
                                        if (j == item2.CotBD)
                                        {
                                            char CharMerge2 = StartCharCols2;
                                            char kyTuCotBD2 = StartCharCols2;
                                            for (int c = item2.CotBD; c < n2; c++)
                                            {
                                                string DataCell = CharMerge2.ToString() + "5";
                                                ws.Cell(DataCell).Value = cols[c - 1];
                                                ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[c - 1];
                                                ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                                ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                                ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                                ws.Cell(DataCell).Style.Font.Bold = true;
                                                ws.Cell(DataCell).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                                                ws.Cell(DataCell).Style.Font.FontColor = StyleFormat.Column.Foreground;
                                                CharMerge2++;
                                                StartCharCols2++;
                                                dl = true;
                                            }
                                            CharMerge2--;//trừ 1
                                            string RangeHeadTable2 = kyTuCotBD2.ToString() + "4:" + CharMerge2.ToString() + "4";
                                            ws.Cell(kyTuCotBD2.ToString() + "4").Value = item2.Ten;
                                            ws.Range(RangeHeadTable2).Merge();
                                            ws.Row(4).Height = item2.ChieuCaoDong;//Chiều cao dòng cần merge
                                            ws.Range(RangeHeadTable2).Style.Font.Bold = true;
                                            ws.Range(RangeHeadTable2).Style.Alignment.SetWrapText(true);
                                            ws.Range(RangeHeadTable2).Style.Alignment.WrapText = true;
                                            ws.Range(RangeHeadTable2).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                            ws.Range(RangeHeadTable2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                            ws.Range(RangeHeadTable2).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                                            ws.Range(RangeHeadTable2).Style.Font.FontColor = StyleFormat.Column.Foreground;
                                            j = n2 - 1;
                                        }
                                        if (kytu2.Equals(StartCharCols2) && dl == false)
                                        {
                                            string DataCell = StartCharCols2.ToString() + "4";
                                            string RangeRowMerge = StartCharCols2.ToString() + "4:" + StartCharCols2.ToString() + "5";
                                            ws.Range(RangeRowMerge).Merge();
                                            ws.Cell(DataCell).Value = cols[j - 1];
                                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[j - 1];
                                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                            ws.Cell(DataCell).Style.Font.Bold = true;
                                            ws.Cell(DataCell).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                                            ws.Cell(DataCell).Style.Font.FontColor = StyleFormat.Column.Foreground;
                                            StartCharCols2++;
                                            dl = false;
                                        }
                                        //if (j == n)
                                        //{
                                        //    //Giảm lại 1 ký tự do cộng lên cuối cùng
                                        //    StartCharCols2--;
                                        //}                                        
                                    }
                                }
                                //--------------------------------------------------------------------------------------------------------------------------------------------------
                            }
                        }

                        if (kytu.Equals(StartCharCols))
                        {
                            string DataCell = StartCharCols.ToString() + StartIndexCols.ToString();
                            string RangeRowMerge = StartCharCols.ToString() + "3:" + StartCharCols.ToString() + "5";
                            ws.Range(RangeRowMerge).Merge();
                            ws.Cell(DataCell).Value = cols[i - 1];
                            ws.Cell(DataCell).WorksheetColumn().Width = ArrayWidthCol[i - 1];
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            ws.Cell(DataCell).Style.Font.Bold = true;
                            ws.Cell(DataCell).Style.Fill.BackgroundColor = StyleFormat.Column.Background;
                            ws.Cell(DataCell).Style.Font.FontColor = StyleFormat.Column.Foreground;
                            StartCharCols++;
                        }
                        if (i == cols.Length)
                        {
                            //Giảm lại 1 ký tự do cộng lên cuối cùng
                            StartCharCols--;
                        }
                    }
                }
                #endregion
                //Merging Header

                string Range = "A1:" + StartCharCols.ToString() + "1";

                ws.Range(Range).Merge();
                ws.Row(1).Height = StyleFormat.Header.Height;
                ws.Range(Range).Style.Font.FontSize = StyleFormat.Header.FontSize;
                ws.Range(Range).Style.Font.Bold = true;

                ws.Range(Range).Style.Alignment.SetWrapText(true);
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                if (StyleFormat.Header.Background != null && StyleFormat.Header.Foreground != null)
                {
                    ws.Range(Range).Style.Fill.BackgroundColor = StyleFormat.Header.Background;
                    ws.Range(Range).Style.Font.FontColor = StyleFormat.Header.Foreground;
                }

                //Style definitions for Date range
                Range = "A2:" + StartCharCols.ToString() + "2";

                ws.Range(Range).Merge();
                ws.Range(Range).Style.Font.FontSize = 10;
                ws.Range(Range).Style.Font.Bold = true;
                ws.Range(Range).Style.Alignment.SetVertical(XLAlignmentVerticalValues.Bottom);
                ws.Range(Range).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);


                //border definitions for Columns
                Range = "A3:" + StartCharCols.ToString() + "5";
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                #region Phần thân trong DataTable

                char StartCharData = 'A';
                int StartIndexData = 6;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int k_int = 0, k_double = 0;//Dùng tối ưu vòng lặp
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        string DataCell = StartCharData.ToString() + StartIndexData;
                        var a = table.Rows[i][j].ToString();
                        a = a.Replace("&nbsp;", " ");
                        a = a.Replace("&amp;", "&");
                        //check if value is of integer type
                        int val_int = 0;
                        DateTime dt = DateTime.Now;
                        double val_double = 0;

                        bool Cell_Double = false, Cell_Int = false;
                        for (int k = k_double; k < Input._ListCollumTypeNumberDouble.Count(); k++)
                        {
                            if (StartCharData == (Input._ListCollumTypeNumberDouble[k] + 64))//Cộng cho 64 là do 65 là char 'A'
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 4;//4 định dạng là #,##0.00 (Xem trong Format Cell in excel)
                                Cell_Double = true;
                                k_double = k + 1;
                                break;
                            }
                        }
                        for (int k = k_int; k < Input._ListCollumTypeNumberInt.Count(); k++)
                        {
                            if (StartCharData == (Input._ListCollumTypeNumberInt[k] + 64))//Cộng cho 64 là do 65 là char 'A'
                            {
                                //ws.Cell(DataCell).Style.NumberFormat.NumberFormatId = 2;//2 định dạng là 0 (Xem trong Format Cell in excel)
                                Cell_Int = true;
                                k_int = k + 1;
                                break;
                            }
                        }
                        if ((int.TryParse(a, out val_int) && j == 0) || (int.TryParse(a, out val_int) && Cell_Int))//--Cột số thứ tự hoặc cột kiểu int
                        {
                            ws.Cell(DataCell).Value = val_int;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else if (double.TryParse(a, out val_double) && Cell_Double)//--Cột số kiểu double
                        {
                            ws.Cell(DataCell).Value = val_double;
                            if (val_double == 0) ws.Cell(DataCell).Value = 0;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        else
                        {
                            ws.Cell(DataCell).Value = a.ToString();
                            ws.Cell(DataCell).Style.Alignment.WrapText = true;
                            ws.Cell(DataCell).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                        }
                        StartCharData++;
                    }
                    StartCharData = 'A';
                    StartIndexData++;
                }
                #endregion

                char LastChar = Convert.ToChar(StartCharData + table.Columns.Count - 1);
                int TotalRows = table.Rows.Count + 5;
                Range = "A5:" + LastChar + TotalRows;
                ws.Range(Range).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Range(Range).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ////Code to save the file
                //HttpResponse httpResponse = Input.response;
                //httpResponse.Clear();
                //httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //httpResponse.AddHeader("content-disposition", "attachment;filename=" + Input.FileName);

                //// Flush the workbook to the Response.OutputStream
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(httpResponse.OutputStream);
                //    memoryStream.Close();
                //}

                //httpResponse.End();
                //return "Ok";
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/DaTa/Temp"), Input.FileName);
                    wb.SaveAs(memoryStream);
                    FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                    memoryStream.WriteTo(file);
                    memoryStream.Close();
                    file.Close();
                }
                return Input.FileName;
            }
            else
            {
                return "Không có dữ liệu";
            }
        }
        catch (Exception ex)
        {
            return "Lỗi dữ liệu";
        }
    }
    #endregion
}