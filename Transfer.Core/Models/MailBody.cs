using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Core.Models
{
    public static class MailBody
    {

        public static string MailBodyPnr(string pnr)
        {
            string html = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
        .email-container {
            background-color: #ffffff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
        }
        h1 {
            color: #333333;
            text-align: center;
        }
        p {
            color: #666666;
            text-align: center;
        }
    </style>
</head>
<body>
    <div class=""email-container"">
        <h1>Teşekkürler!</h1>
        <center><img src=""https://www.biletdukkani.com/_nuxt/img/biletdukkani.8f5dbe6.png""></center>
        <p>Satın almış olduğunuz için teşekkür ederiz.</p>
        <p>Bilet bilgileriniz aşağıda yer almaktadır:</p>
        <p><strong>PNR :</strong> " + pnr + @"</p>
    </div>
</body>
</html>
";
            return html;
        }



    }
}
