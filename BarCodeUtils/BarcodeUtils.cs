using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarCodeUtils
{
    public static class BarcodeUtils
    {
        public static string BarcodeInfo(int flag)
        {
            switch (flag)
            {
                case 1:
                    return "private DispatcherTimer sessionTimer;  sessionTimer = new DispatcherTimer();  sessionTimer.Interval = TimeSpan.FromMinutes(1); sessionTimer.Tick += SessionTimerTick; sessionTimer.Start(); ";
                case 2:
                    return " string str = 'ERTYUIOPASDFGHJKLZXCVBNMqwertyuiopsdfghjklzxcvbnm1234567890'; string captcha = new string(str.OrderBy(c => Guid.NewGuid()).ToArray()).Substring(4);"
                    + " < TextBlock TextDecorations = 'Strikethrough' FontWeight = 'Bold' Foreground = 'Red' /> ;";
                case 3:
                    return "string file = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + '\\Resources\\' + 'barcode.pdf';"
                               + " GeneratedBarcode gen = BarcodeWriter.CreateBarcode('123456789012', BarcodeEncoding.EAN13);"
                   + " gen.AddBarcodeValueTextBelowBarcode();"
                   + " gen.SaveAsPdf(file);"

                   + " BarcodeResults results = BarcodeReader.Read(file);"
                  + "  if (results != null)" + " {"
                   + "     foreach (BarcodeResult result in results)"
                    + "    {"
                   + "         MessageBox.Show(result.Text);"
                    + "    }"
                   + " }";
                case 4:
                    return "OpenFileDialog op = new OpenFileDialog();"
                        + " op.Title = 'Select a picture';"
                    + " op.Filter = 'All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png';"
                    + " if (op.ShowDialog() == true)"
                   + " {"
                       + " string fileName = Guid.NewGuid() + op.SafeFileName;"
                       + " string newFilePath = System.IO.Path.Combine(folderpath, fileName);"
                       + " File.Copy(op.FileName, newFilePath);"
                       + " imgPhoto.Source = new BitmapImage(new Uri(op.FileName)); ";
                case 5:
                    return "SELECT "
+ " COLUMN_NAME AS 'COLUMN_NAME',"
+ " DATA_TYPE +"
+ " CASE"
+ " WHEN CHARACTER_MAXIMUM_LENGTH IS NULL THEN ''"
+ " ELSE ' (' + CONVERT(NVARCHAR(10), CHARACTER_MAXIMUM_LENGTH) + ')'"
+ " END AS 'DATA_TYPE ( CHARACTER_MAXIMUM_LENGTH )',"
+ " case"
+ " when IS_NULLABLE = 'YES' THEN 'N'"
+ " else 'Y'"
+ " end as 'is_nullable'"
+ " FROM"
+ " INFORMATION_SCHEMA.COLUMNS"
+ " WHERE "
+ " TABLE_NAME = ''; ";
                case 6:
                    return "";
                default:
                    return "";

            }
        }
        public static bool CheckBarcode(string barcodeValue)
        {
            if (barcodeValue.Length != 13)
                return false;

            int checksum = 0;
            for (int i = 0; i < 12; i++)
            {
                int digit = int.Parse(barcodeValue[i].ToString());
                checksum += (i % 2 == 0) ? digit : digit * 3;
            }

            int checksumDigit = (10 - (checksum % 10)) % 10;
            int lastDigit = int.Parse(barcodeValue[12].ToString());

            if (checksumDigit != lastDigit)
                return false;

            return true;
        }
    }
}
