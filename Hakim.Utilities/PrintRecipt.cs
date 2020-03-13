using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Drawing;

namespace Hakim.Utilities
{
    public class Print
    {
		// DAMN!! :-)
        public void PrintRecipt(PrintPageEventArgs e, string lastName, DateTime date, int price,
            string itemName1 = "", string itemValue1 = "",
			string itemName2 = "", string itemValue2 = "")
        {
            int columnPosition = 0;
            int rowPosition = 20;

            FontFamily fontFamily = new FontFamily("Tahoma");
            Font boldFont = new Font(fontFamily, 8, FontStyle.Bold);
			Font regularFont = new Font(fontFamily, 8, FontStyle.Regular);

			// HEADER
			e.Graphics.DrawString("درمانگاه شبانه روزی حکیم", boldFont, Brushes.Black, 
                (float)columnPosition, (float)rowPosition);
            rowPosition = rowPosition + 20;
            e.Graphics.DrawLine(Pens.Black, new Point(0, rowPosition), new Point(e.PageSettings.Bounds.Width, rowPosition));
            
            columnPosition = 0;
            rowPosition += 10;

			// BODY
			e.Graphics.DrawString("نام خانوادگی: ", boldFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
			columnPosition += 120;
			e.Graphics.DrawString(lastName, regularFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
			
			columnPosition = 0;
			rowPosition += 20;

			e.Graphics.DrawString("تاریخ: ", boldFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
			columnPosition += 120;
			e.Graphics.DrawString(date.ToShamsi(), regularFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
			
			columnPosition = 0;

			if (itemName1 != "")
			{
				rowPosition += 20;
				e.Graphics.DrawString(itemName1, boldFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
				columnPosition += 120;
				e.Graphics.DrawString(itemValue1, regularFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
				columnPosition = 0;
			}

			if (itemName2 != "")
			{
				rowPosition += 20;
				e.Graphics.DrawString(itemName2, boldFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
				columnPosition += 120;
				e.Graphics.DrawString(itemValue2, regularFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
				columnPosition = 0;
			}
			
			rowPosition += 20;

			e.Graphics.DrawString("مبلغ به ریال", boldFont, Brushes.Black, (float)columnPosition, (float)rowPosition);
			columnPosition += 120;
			e.Graphics.DrawString(price.ToString("#,0"), regularFont, Brushes.Black, (float)columnPosition, (float)rowPosition);			    
			columnPosition = 0;

			// FOOTER
			rowPosition += 20;
			e.Graphics.DrawLine(Pens.Black, new Point(0, rowPosition), new Point(e.PageSettings.Bounds.Width, rowPosition));
			columnPosition = 0;
		}
	}
}
