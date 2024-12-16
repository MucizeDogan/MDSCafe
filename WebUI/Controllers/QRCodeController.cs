using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace WebUI.Controllers {
    public class QRCodeController : Controller {
        public IActionResult Index(string value) {
            using (MemoryStream memoryStream = new MemoryStream()) {
                QRCodeGenerator createQRCode = new QRCodeGenerator();
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);   //Karekodun içeriğini oluşturur.
                using (Bitmap image = squareCode.GetGraphic(10)) {    //Bellekte oluşturulan qr code un çizimini gerçekleştiriyor.
                    image.Save(memoryStream, ImageFormat.Png); // png formatında kaydediyor.
                    ViewBag.QrCodeImage="data:image/png;base64" + Convert.ToBase64String(memoryStream.ToArray());
                }  
            }
                return View();
        }
    }
}
