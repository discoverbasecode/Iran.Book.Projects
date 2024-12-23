namespace Framework.Application.EmailUtils;

public static class EmailTemplate
{
    private static string StyleBody = "*{-webkit-font-smoothing:antialiased;}body{Margin:0;padding:0;min-width:100%;-webkit-font-smoothing:antialiased;mso-line-height-rule:exactly;}table{border-spacing:0;color:#333333;}img{border:0;}.wrapper{width:100%;table-layout:fixed;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;}.webkit{max-width:600px;}.outer{Margin:0auto;width:100%;max-width:600px;}.full-width-imageimg{width:100%;max-width:600px;height:auto;}.inner{padding:10px;}p{Margin:0;padding-bottom:10px;}.h1{font-size:21px;font-weight:bold;Margin-top:15px;Margin-bottom:5px;font-family:Arial,sans-serif;-webkit-font-smoothing:antialiased;}.h2{font-size:18px;font-weight:bold;Margin-top:10px;Margin-bottom:5px;-webkit-font-smoothing:antialiased;}";

    private static string TemplateBody(string body) =>
        $@"<center class='wrapper' style='width:100%;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;'>
                    <table class='outer' align='center' cellpadding='0' cellspacing='0' border='0' style='border-spacing:0;Margin:0auto;width:100%;max width:800px;'>
                        <tr>
                            <td style='padding-top:0;padding-bottom:0;padding-right:0;padding-left:0;'>
                                <table border='0' width='100%' cellpadding='0' cellspacing='0'>
                                    <tr><td><table style='width:100%;' cellpadding='0' cellspacing='0' border='0'><tbody>
                                        <tr><td align='center'>
                                            <center><table border='0' align='center' width='100%' cellpadding='0' cellspacing='0' style='Margin:0auto;'>
                                                <tbody>
                                                    <tr><td class='one-column' style='padding-top:0;padding-bottom:0;padding-right:0;padding-left:0;'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%' style='border-spacing:0'>
                                                            <tr><td>&nbsp;</td></tr>
                                                            <tr><td align='center'>&nbsp;</td></tr>
                                                            <tr><td height='6' bgcolor='#1f3ca6' class='contents' style='width:100%; border-top-left-radius:10px; border-top-right-radius:10px'></td><tr>
                                                        </table>
                                                    </td></tr>
                                                </tbody>
                                            </table></center>
                                        </td></tr>
                                    </tbody></table></td></tr></table></td></tr></table>
                                <table class='one-column' border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#f7f7f7'>
                                    <tr><td style='padding-left:40px;padding-right:40px;padding-top:0px;padding-bottom:40px'>
                                        <div style='direction:rtl;font-family:Tahoma;font-size:12px'>{body}</div>
                                    </td></tr>
                                </table>
                                <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                                    <tr><td><table width='100%' cellpadding='0' cellspacing='0' border='0' bgcolor='#1f3ca6'>
                                        <tr><td align='center' bgcolor='#1f3ca6' class='one-column' style='padding-top:0;padding-bottom:0;padding-right:0;padding-left:0;'>&nbsp;</td></tr>
                                        <tr><td align='center' bgcolor='#1f3ca6' class='one-column' style='padding-top:0;padding-bottom:0;padding-right:10px;padding-left:10px;'>
                                            <font style='font-size:13px;text-decoration:none;color:#ffffff;font-family:Verdana,Geneva,sans-serif;text-align:center'>
                                                <h4 style='margin:0'><a href='https://www.teknogram.ir' target='_blank' style='color:#ffffff;text-decoration:none;'>تکنوگرام مرجع فیلم های آموزشی</a></h4>
                                            </font>
                                        </td></tr>
                                        <tr><td align='center' bgcolor='#1f3ca6' class='one-column' style='padding-top:0;padding-bottom:0;padding-right:0;padding-left:0;'>&nbsp;</td></tr>
                                    </table></td></tr>
                                    <tr><td><table width='100%' cellpadding='0' cellspacing='0' border='0'>
                                        <tr><td height='6' bgcolor='#1f3ca6' class='contents' style='width:100%; border-bottom-left-radius:10px; border-bottom-right-radius:10px'></td></tr>
                                        <tr><td>&nbsp;</td></tr>
                                    </table></td></tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </center>";

    public static string BuildView(this string body)
    {
        var emailBody = $"<style type='text/css'>{StyleBody}</style>{TemplateBody(body)}";
        return emailBody;
    }
}
