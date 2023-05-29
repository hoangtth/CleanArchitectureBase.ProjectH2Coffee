using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanArchitectureBase.Domain.Helpers
{
    public class HMACUtil
    {
        public static bool ValidateSignature(string secureKey, string dataSign, string sign)
        {
            try
            {
                if (string.IsNullOrEmpty(secureKey)) return false;
                string signSystem = HmacGenerator(dataSign, secureKey + "", "SHA1");
                if (signSystem == sign)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ValidateSignature: " + ex.Message);
                //commonLogger.ErrorFormat("ValidateSignature: partnerCode= {0}, dataSign= {1}, sign= {2}, ex= {3}", partnerCode, dataSign, ex.Message);
                return false;
            }
        }

        public static string HmacGenerator(string input, string key, string type = "SHA1")
        {
            try
            {
                byte[] bKey = System.Text.Encoding.UTF8.GetBytes(key);
                string retVal = "";
                switch (type.ToUpper().Trim())
                {
                    case "SHA1":
                        HMACSHA1 myhmacsha1 = new HMACSHA1(bKey);
                        byte[] byteArray = Encoding.ASCII.GetBytes(input);
                        MemoryStream stream = new MemoryStream(byteArray);
                        retVal = myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
                        break;

                    case "SHA256":
                        HMACSHA256 myhmacsha256 = new HMACSHA256(bKey);
                        byte[] byteArray256 = Encoding.ASCII.GetBytes(input);
                        MemoryStream stream256 = new MemoryStream(byteArray256);
                        retVal = myhmacsha256.ComputeHash(stream256).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
                        break;

                    case "SHA384":
                        HMACSHA384 myhmacsha384 = new HMACSHA384(bKey);
                        byte[] byteArray384 = Encoding.ASCII.GetBytes(input);
                        MemoryStream stream384 = new MemoryStream(byteArray384);
                        retVal = myhmacsha384.ComputeHash(stream384).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
                        break;

                    case "SHA512":
                        HMACSHA512 myhmacsha512 = new HMACSHA512(bKey);
                        byte[] byteArray512 = Encoding.ASCII.GetBytes(input);
                        MemoryStream stream512 = new MemoryStream(byteArray512);
                        retVal = myhmacsha512.ComputeHash(stream512).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
                        break;

                    case "MD5":
                        HMACMD5 myhmacshamd5 = new HMACMD5(bKey);
                        byte[] byteArrayMd5 = Encoding.ASCII.GetBytes(input);
                        MemoryStream streamMd5 = new MemoryStream(byteArrayMd5);
                        retVal = myhmacshamd5.ComputeHash(streamMd5).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
                        break;

                    case "MD5_NOHMAC":
                        MD5 myhmacshamd5_noHMAC = new MD5CryptoServiceProvider();
                        byte[] byteArrayMd5_noHMAC = Encoding.ASCII.GetBytes(input);
                        MemoryStream streamMd5_noHMAC = new MemoryStream(byteArrayMd5_noHMAC);
                        retVal = myhmacshamd5_noHMAC.ComputeHash(streamMd5_noHMAC).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
                        break;

                    default:
                        HMACSHA1 myhmacshaDefault = new HMACSHA1(bKey);
                        byte[] byteArrayDefault = Encoding.ASCII.GetBytes(input);
                        MemoryStream streamDefault = new MemoryStream(byteArrayDefault);
                        retVal = myhmacshaDefault.ComputeHash(streamDefault).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
                        break;
                }
                return retVal;
            }
            catch (Exception ex)
            {
                Console.WriteLine("HmacGenerator: input={0}, key={1}, type={2}, ex={3}", input, key, type, ex.Message);
                return "";
            }
        }

        public static string CreateAuditNumber(string cashierCode = "")
        {
            Random random = new Random();
            //return cashierCode + DateTime.Now.ToString("yyyyMMddHHmmssfff") + (9999 + random.Next(9000));
            return DateTime.Now.ToString("yyMMddHHmmssfff") + (999 + random.Next(900));
        }

        public static string HmacGeneratorForPartnerRequest(string requestID, string parterCode, string type = "SHA1", string key = "")
        {
            //INVOICE_SECURE_KEY
            //var key = ConfigurationManager.AppSettings["PARTNER_SECURE_KEY"];
            var input = string.Concat(requestID, parterCode);
            return HmacGenerator(input, key, type);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static bool IsValidPhone(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;
            return Regex.Match(phoneNumber, @"(0[3|5|7|8|9])+([0-9]{8})").Success;
        }

    }
}
