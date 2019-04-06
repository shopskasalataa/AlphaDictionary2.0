using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using System.Drawing;
using System.IO;

namespace OCR
{
    public static class OCR
    {
        //get imgsource
        public static string GetText(byte[] imgsource)
        {
            Bitmap bitmap;
            using (var ms = new MemoryStream(imgsource))
            {
                bitmap = new Bitmap(ms);
            }

            var ocrtext = "";
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var img = PixConverter.ToPix(bitmap))
                {
                    using (var page = engine.Process(img))
                    {
                        ocrtext = page.GetText();
                    }
                }
            }
            return ocrtext; //Do smth with the string
        }
    }
}
