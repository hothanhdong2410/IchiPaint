using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using IchiPaint.DataAccess;
using Microsoft.Office.Interop.Excel;
using NaviCommon;

namespace IchiPaint.Common
{
    public class PhongThuy
    {
        public Dictionary<int, string> CanChiDictionary { get; set; }
        public Dictionary<int, Menh> PhongThuyDictionary { get; set; }
        public PhongThuy(string filePath)
        {
            CanChiDictionary = new Dictionary<int, string>
            {
                {1, "Giáp Tý" },
                {2, "Ất Sửu" },
                {3, "Bính Dần" },
                {4, "Đinh Mão" },
                {5, "Mậu Thìn" },
                {6, "Kỷ Tỵ" },
                {7, "Canh Ngọ" },
                {8, "Tân Mùi" },
                {9, "Nhâm Thân" },
                {10, "Quý Dậu" },
                {11, "Giáp Tuất" },
                {12, "Ất Hợi" },
                {13, "Bính Tý" },
                {14, "Đinh Sửu" },
                {15, "Mậu Dần" },
                {16, "Kỷ Mão" },
                {17, "Canh Thìn" },
                {18, "Tân Tỵ" },
                {19, "Nhâm Ngọ" },
                {20, "Quý Mùi" },
                {21, "Giáp Thân" },
                {22, "Ất Dậu" },
                {23, "Bình Tuất" },
                {24, "Đinh Hợi" },
                {25, "Mậu Tý" },
                {26, "Kỷ Sửu" },
                {27, "Canh Dần" },
                {28, "Tân Mão" },
                {29, "Nhâm Thìn" },
                {30, "Quý Tỵ" },
                {31, "Giáp Ngọ" },
                {32, "Ất Mùi" },
                {33, "Bình Thân" },
                {34, "Đinh Dậu" },
                {35, "Mậu Tuất" },
                {36, "Kỷ Hợi" },
                {37, "Canh Tý" },
                {38, "Tân Sửu" },
                {39, "Nhâm Dần" },
                {40, "Quý Mão" },
                {41, "Giáp Thìn" },
                {42, "Ất Tỵ" },
                {43, "Bính Ngọ" },
                {44, "Đinh Mùi" },
                {45, "Mậu Thân" },
                {46, "Kỷ Dậu" },
                {47, "Canh Tuất" },
                {48, "Tân Hợi" },
                {49, "Nhâm Tý" },
                {50, "Quý Sửu" },
                {51, "Giáp Dần" },
                {52, "Ất Mão" },
                {53, "Bính Thìn" },
                {54, "Đinh Tỵ" },
                {55, "Mậu Ngọ" },
                {56, "Kỷ Mùi" },
                {57, "Canh Thân" },
                {58, "Tân Dậu" },
                {59, "Nhâm Tuất" },
                {0, "Quý Hợi" }
            };
            PhongThuyDictionary = new Dictionary<int, Menh>();

            //var arrMenh = ReadFileExcel(filePath);

            NewsDA _NewsDA = new NewsDA();
            DataSet _ds = _NewsDA.Feng_Shui_GetAll();
            List<Menh> arrMenh = CBO.Fill2ListFromDataSet<Menh>(_ds, typeof(Menh));


            var start = 1948;
            foreach (var item in arrMenh)
            {
                var soCanChi = (start - 3) % 60;
                item.CanChi = CanChiDictionary[soCanChi];
                PhongThuyDictionary.Add(soCanChi, item);
                start++;
                soCanChi = (start - 3) % 60;
                item.CanChi = CanChiDictionary[soCanChi];
                PhongThuyDictionary.Add(soCanChi, item);
                start++;
            }
        }
        private static IEnumerable<Menh> ReadFileExcel(string filePath)
        {
            var xlApp = new Application();
            var xlWorkbook = xlApp.Workbooks.Open(filePath);
            _Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            var xlRange = xlWorksheet.UsedRange;
            var rowCount = xlRange.Rows.Count;
            var arrMenh = new Menh[rowCount];
            for (var j = 0; j < rowCount; j++)
            {
                var i = j + 1;
                var menh = new Menh()
                {
                    Ten = xlRange.Cells[i, 2].Value2.ToString(),
                    MauTuongSinh = xlRange.Cells[i, 3].Value2.ToString(),
                    MauTuongKhac = xlRange.Cells[i, 4].Value2.ToString()
                };
                arrMenh[j] = menh;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            return arrMenh;
        }
    }
    public class Menh
    {
        public string Ten { get; set; }
        public string CanChi { get; set; }
        public string MauTuongSinh { get; set; }
        public string MauTuongKhac { get; set; }
    }
}