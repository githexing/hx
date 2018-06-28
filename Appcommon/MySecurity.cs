using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;
//using System.Web.Security;


namespace AppCommon
{
    public class MySecurity
    {
        #region 非对称加密
        #region 加密Key
        private static string _QueryStringKey = "12345678"; //URL传输参数加密Key这个key可以自己设置支持8位这个东西很重要的
        #endregion

        #region 加密算法
        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="QueryString"></param>
        /// <returns></returns>
        public static string EncryptQueryString(string QueryString)
        {
            return Encrypt(QueryString, _QueryStringKey);
        }
        public static string EncryptQueryString(string QueryString, string pKey)
        {
            return Encrypt(QueryString, pKey);
        }
        #endregion

        #region 解密算法
        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="QueryString"></param>
        /// <returns></returns>
        public static string DecryptQueryString(string QueryString)
        {
            return Decrypt(QueryString, _QueryStringKey);
        }
        public static string DecryptQueryString(string QueryString,string pKey)
        {
            return Decrypt(QueryString,pKey);
        }
        #endregion

        #region 其他加密算法
        private static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider(); //把字符串放到byte数组中

            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);


            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey); //建立加密对象的密钥和偏移量
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey); //原文使用ASCIIEncoding.ASCII方法的GetBytes方法 
            MemoryStream ms = new MemoryStream(); //使得输入密码必须输入英文文本
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        private static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey); //建立加密对象的密钥和偏移量，此值重要，不能修改 
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder(); //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        #endregion
        #region 使用散列方式加密 MD5加密
        /// <summary> 
        /// 使用MD5对字符串进行加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encrypts(string str)
        {
            string result = string.Empty;
            //先将要加密的字符串转换成byte数组
            byte[] inputData = System.Text.Encoding.Default.GetBytes(str);
            //在通过MD5类加密，并得到加密后的byte[]类型
            byte[] data = System.Security.Cryptography.MD5.Create().ComputeHash(inputData);
            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                //将每个byte数据转换成16进制。"X":表示大写16进制；"X2"：表示大写16进制保留2位；"x"：表示小写16进制
                strBuild.Append(data[i].ToString("X2"));
            }
            result = strBuild.ToString();
            result = result.ToLower();
            return result;
        }
        #endregion
        #region 使用非对称算法加密、解密 
        /// <summary>
        /// 获取系统公钥、私钥
        /// </summary>
        public  static class GetRSAKey
        {
            private static readonly string pPrivateKey_Admin = @"<RSAKeyValue><Modulus>qwXtxLB+YIY6Gp/FCm0+u6z5sPWZknjIu6YMOBjkSDJfDxS9KFWjwUeTFEqgFJVM4hGVDF7VmwJsUmgm91T+Gsh+xCKDPMNjmPSOxN33CXbeoqYE9qA3xFCXpeHtZoDsj6zaALdyJ+K4yiILeCtaJAkocXCOCH/wfIzFI0S+S/U=</Modulus><Exponent>AQAB</Exponent><P>5rztDjhHvnzSZAskC236yqynVs3V8EHguDAONweGv/FpnYtVEvbApUXXpQwkmjtPsfsI7TdLmXThuHM5OGckNw==</P><Q>vb9UGMeG/Wd/hK9/a6dfRo/oZnwEdjGUnO5LueTESTwhoXM2/Zg1IIKxkZ9YfCxODd/Fn2q7HvGrfqtyBo4TMw==</Q><DP>3DfSdHDooHiXgJ5Vb4cvBkLUj3dyyZTGemR7HLBVPlqVd6SktK3G3baUA1Vclcsn2/GA6o6M29B/IkDuitN97w==</DP><DQ>m7RseyUIZdtPbf9hjWK8MTgYGjk8pAzNifWV2IaceAhLBKR6BKGpPvNgaUIcJ1Fn/8SX89huktb3xqtDl5Nwtw==</DQ><InverseQ>nShsJ7022iRBZf82Bj5PLyHtfu/xiuFrKXBIBW+F1zdvUW0XKkFRjU5b5fePw9k7NuuX73duBTCRkGbvbSbJJQ==</InverseQ><D>ncmVij/QCVwt5Xx8vdb25w57PHIMI2A+yyoy4drNW3Ll0zMuJjWFJQDVSQZk1Ti+O2E/Y69nYmGE8S7YrJ8E5Msdah2FMBHIsxLNv5d9J2ccdle0siD15m0Lhy4u+Fmtqfd1XxXOTeD3JN5EqpG0BINDFsM0bpvbvi4GrXug/s0=</D></RSAKeyValue>";
            private static readonly string pPrivateKey_Baoming = @"<RSAKeyValue><Modulus>5/ty+QRhHqgVQeI40VsuJEQZSBIqmIcV5+EQYg2X/QBrURsmwjrpxz0/foLdmVoqmrc1146Tu4H5CdJzU3GyiawFHz8Ws3pMT/B/ME10/iG/Y8mCtsk9J27Bif83Qf+ySG16VLWMKrpuaDBYxX4U9g2VcoAASeVAUbCFF4icrtU=</Modulus><Exponent>AQAB</Exponent><P>9HX80klj2yju+tKLLgOQCd9vF2v3KgM+e0U83568/P/9PfsFmLnaEHpCPUKqRTSyqyUQZX2PT1xnb4GUrYJ9yQ==</P><Q>8u6sCmFreHEfQpJoGKD+DaHgW2uYNPQum0ybWRAB/5HWiDSDVOGBpSvOhT2uW7pV1290fXOrB/LviDYwNL8+rQ==</Q><DP>hgbmLPi1uaOQmo2yZvDnGLKaerHj2fHbYMROIqAqJ1/GHSQyJlDHAL+271VMexLwXiq8+ZfEaZNU1mqp9BMWGQ==</DP><DQ>iYiED/BtdqecigT3OBJVIoSlzzwP1NL1W+i3/mkoqHb5XO1V+QUeb9NoPVjZUIciuDAaZDfK+VoZMCV1jzdClQ==</DQ><InverseQ>ljhSR6BSQ5Q/1c5bzb6cd5Q8ieNY7n2L2PJG8BSgBuueAzPmAIyHcXJIkq/CD0aCSLV46BriwCdEPDnQ3XC/Pg==</InverseQ><D>FGRtMeippOk/nSAGwJiUUMnPsx8tsWTGjzCgoQ3y22GrDWEmohJNtJ70sulME4vyjNEoIX++CtCdFLj0PFSVTgwB0wZJ169zIgVdfBnaPs8Xr/ACcZ+M65mO78C1BVdEBh0inRFBYOFZvx2/1aoHCH+coEabKVHf6hpOqkJHYmE=</D></RSAKeyValue>";
            private static readonly string pPrivateKey_Kaowu = @"<RSAKeyValue><Modulus>zolsl4+xLL/rG/r9a8ECs0t5o7GM6E11auCDlb2WiDqNjRLaYZQ1b/h6gVAG0ZDikACBvoIxsfRU6GHfiRhgZ9/eAVXImSwgQgXIjq0TwTHRQ81CDDw9KctWXTZhnySLOqSZRd4Pv9JAWx8fQOjZEC9VjAJb/Qhy4NRMo1uGBpM=</Modulus><Exponent>AQAB</Exponent><P>+SdT3GNc3c39LWVAUUlLMwJy13o9yL+KEs3sMUZOJSrLZ6B8RvKXIH7wtUN/P65OcDujU05UTfnIXhCosb/iww==</P><Q>1DZO9fVKQGHIOk+F0M9z9H/muh+UY1OgoBANQL8Qsa2254BZRZ5jShAmQiSoQhtnCCqm9ZLXFed/N1dMPEVv8Q==</Q><DP>aLQLPOGQxDFthOc46TAI5w3PXxgi4LsFdjONX4OxEVNzmT/LGjGWKvTNiQ8taYCBvA6D611OdlpSxpzvl4sQ6w==</DP><DQ>YZaf9SfZ/4V4CKitRvs/vb5bolgHay33/eOj1JSI3syeAhPZ+dP+oP6QOXaWEeB8HxtOMDxYwO/2ZsK0gjsEYQ==</DQ><InverseQ>3H+85RO+oURC+uCGxgEXfaLjL4ishNwVh7Gcb6ZEOZMrZg8LsKVCyeNaDadlA1eZpmE+TqJXk/6cehsHjf40dw==</InverseQ><D>wDAw1HfprnKIHOlZmENqd9zru98j96bcdC+nQlfBE9MolPXOMK7xatgVZu9I6QmhSc6u7M/J3oY13Gf20mPUkCb3PPuh1+QQvGV8k0iAek2NUXlh+WXBLpder7exAEVM4Srnf9zV0mvDEGDEiObV6tv/l3E5UIuK0MctlQJgmQE=</D></RSAKeyValue>";
            private static readonly string pPrivateKey_Luqu = @"<RSAKeyValue><Modulus>qREC6/PYthazryRvk/lCsKU4HIiKQUa8/MPm6xd4S5za52xZ/aQqIxw+hhv1bxJBcPZrLoeyrkKXpSpAKxqXw56GrfHXB+S1sohDm0HqAsp/nQW++VVwHD2w/p+JsogECfrEGsQ/XYmUgBU94izUYwTqslN3uSsu+KYYd3wWmhM=</Modulus><Exponent>AQAB</Exponent><P>7LjXappOokEV6EuSgpCe+aunsi8P6jhIs11paRnfDz8UcpNQuIKUOYLRNJ5HDkq2dnXjwexcotbBdV7ph4IXoQ==</P><Q>ttWxVZM4SaQkqEN/XtB5cMoe4w9/uB8yYDngphoH2wg7bCMEHuzC2CWh7+xaypnuMdWwgzppWdtZz8IeG93FMw==</Q><DP>T6JzHXKhp2Xb19Ssie3a/UTo2kGIyhN7KZPwJSJF7twapdy3GAsdkCdY96mTX9R0g29vWkqIc2Npm3F9gE+cYQ==</DP><DQ>mT5O3l0ApqiPmQDJ9xxhTSn77XCGKjrrrD+WjWHwB6PEuoQ25fyn6ybPrhq6lmmifd6Pjc4dkxUJF9uqBM1ChQ==</DQ><InverseQ>ehDKTkaZTd2hGxs1CbHViOH9ZuobaDFUcY/3jH6GY8By1LODLmbYhLzev+LNVmayrY4hDtkK9H9Sjx2NCW4Fuw==</InverseQ><D>KplHtC4n35GOysWSe6VloV6v6biZpWLugX3W9EtgmyS1n3QUpK01lM0sD9yBle/yn0TnsrysT+4liY9AxduYe18CIVUHEaEf3eqDCc5SEUQLloWYRYnD3e/etDld9MUU5YvmCIXn0Ils58HKWJ4NnVh3GzqeOPfwrFMfZYYkXUE=</D></RSAKeyValue>";
            private static readonly string pPrivateKey_Daima = @"<RSAKeyValue><Modulus>2dPE4U63boNkuPSft3yJP37ZqpGcDYSbpgW94xb/EgBKd99MN2M+Dtd7oMKRvwefwsZEUBKRg0cIPTJk3pIzMVePt+sUD2RL4n7Y68qsR7srw846r4bwT79q+rQMYoplV+mjPgsG+kk+qk/q9To+AhDmqSfpHUXBxE2v+sMctt8=</Modulus><Exponent>AQAB</Exponent><P>9JSsiuIjP+ry02K8/qEr4S7nNG541wt3/gnDvdqZlgSU6WHOwGp/iWjxRYwFtPUYSHxQr2vTAxkpXTTgSHmBhQ==</P><Q>4/9Tg/jwShw5x2BWmELg+zn+FzAxe8N/29O48l0j3kpnonEEaDLbr2YzKJn4DEt+O1QcVIRA7ifrg0dtqUXSEw==</Q><DP>biYC6u1bKK8cOv0N1rMpOtnPwHo8K8T7fkpRgFBRuRFJKy4kWd3coDrF5idgbpWvIP3zrH0n5A5R5aspkxo9rQ==</DP><DQ>srqiDo+kVoRf6uKjn4K1+VsRy7203M95uKr1jdDj4Es1iIrOKJzNyGb2bbqdT44Sq5GZD8wJVmim3+ermImqTw==</DQ><InverseQ>ZYp3vczyYftRlm1uj4nTuxJfshLaJncIWPJGR167jz5tBqv0Cz7Y7ZzQ+9BJOKv2xQiEy8K+LBpKNdpMcCcYWg==</InverseQ><D>zgIPGDrXFmijsJyCFQlt0CRK/Zr6aHp6rhiODqBoGYE27Im9zkBIp8a5gD+jkXRHbvEOGGCHSA28yAvKBAlm6UuCCs/3AJHcG94bnr7SZoLY75G8ttsnkbZjC8PZr0vlVwGxo/R/idUEdC0imB3QJpBnb/dhhqZpkf+IOLBFTyk=</D></RSAKeyValue>";
            private static readonly string pPrivateKey_Update = @"<RSAKeyValue><Modulus>uVy/X6x3gWGAjim5dL6wrwHOE6i/MACcd2lAmHAIRNXpxDnA9Vt2r8LzKT9T8wtJ4QsuAPMzcA+g7S0Xq64GQUXmdvBasqcnFMeAJISN7FV9/o/ACmfBX03mniaNI1x/5cFlJrhIbOMvlXSF/OyLL4jhe/ANu3q083H/wecZQNM=</Modulus><Exponent>AQAB</Exponent><P>8fVyJKHU3O95nT693HQsM4msJm0UwgioT78zJOdIkyMMGE9u+d4WsqsY3rq9Wp718E8ijMJGCX+UbiEHzkfEZQ==</P><Q>xB6AQRlECCuQdgEJr+2OGTiSFlxndZGOccLItbRLrRk5sZNcQcdCAOXIaneTcVjKCcSxu3EU7tR4SBJzYQkQ1w==</Q><DP>4y4P9DE2yhLX3zqvzbQOZH2Zc6Lr4Jt8XRQrEzVNwUkg7Bp5GobaTPu1KDux2spyJSZITF2EoRp25UiCKb7cuQ==</DP><DQ>C6lopPZUpku43lt3cP+mOHe1sCC0gjgyiS808iETcuqSFK4XiU3I7fa78SDFIrNN6EDK9MNnpD/8GwUF2VpJpw==</DQ><InverseQ>tbBUgPnEzf/Xapjvtu62tgIt5wQUcpQLAaCIzyTMZY8e5YZZusa3XgL4KYMqZtSrJ+MS/hzzUWgosFDKeKoxKw==</InverseQ><D>BVTamEjgoxMH3I7sq6P0dwQpRj17SkkqNvELD5dhVYGFmMREfYok7sc/sTcGFh6EAHoO164nE5kPeuLqJGD8AwYC+xb1ojmHmSM4GrR0qPfBVrXMK6jM54iqOFTQ3NnmRAqdcD40fpckDHCWloPVWccUuTbFvDLj0J8kMACHPjk=</D></RSAKeyValue>";
            private static readonly string pPrivateKey_Shezhi = @"<RSAKeyValue><Modulus>uVy/X6x3gWGAjim5dL6wrwHOE6i/MACcd2lAmHAIRNXpxDnA9Vt2r8LzKT9T8wtJ4QsuAPMzcA+g7S0Xq64GQUXmdvBasqcnFMeAJISN7FV9/o/ACmfBX03mniaNI1x/5cFlJrhIbOMvlXSF/OyLL4jhe/ANu3q083H/wecZQNM=</Modulus><Exponent>AQAB</Exponent><P>8fVyJKHU3O95nT693HQsM4msJm0UwgioT78zJOdIkyMMGE9u+d4WsqsY3rq9Wp718E8ijMJGCX+UbiEHzkfEZQ==</P><Q>xB6AQRlECCuQdgEJr+2OGTiSFlxndZGOccLItbRLrRk5sZNcQcdCAOXIaneTcVjKCcSxu3EU7tR4SBJzYQkQ1w==</Q><DP>4y4P9DE2yhLX3zqvzbQOZH2Zc6Lr4Jt8XRQrEzVNwUkg7Bp5GobaTPu1KDux2spyJSZITF2EoRp25UiCKb7cuQ==</DP><DQ>C6lopPZUpku43lt3cP+mOHe1sCC0gjgyiS808iETcuqSFK4XiU3I7fa78SDFIrNN6EDK9MNnpD/8GwUF2VpJpw==</DQ><InverseQ>tbBUgPnEzf/Xapjvtu62tgIt5wQUcpQLAaCIzyTMZY8e5YZZusa3XgL4KYMqZtSrJ+MS/hzzUWgosFDKeKoxKw==</InverseQ><D>BVTamEjgoxMH3I7sq6P0dwQpRj17SkkqNvELD5dhVYGFmMREfYok7sc/sTcGFh6EAHoO164nE5kPeuLqJGD8AwYC+xb1ojmHmSM4GrR0qPfBVrXMK6jM54iqOFTQ3NnmRAqdcD40fpckDHCWloPVWccUuTbFvDLj0J8kMACHPjk=</D></RSAKeyValue>";

            private static readonly string pPublicKey_NZ = @"<RSAKeyValue><Modulus>5bdcyWOCrfNig4zxVzHdolE7O9mcEp04rB/UnZZ7ucGoKk1vE/fWi6UDJhSy085jWcCDUSAAsA1smJ1O1dogNSTAw0WvF00OhkxR9KbEmjfDB3umE2rRGAyf/b8vtfXqHnpSwhf2XTZFuYkXsArno0MCs6l52VQFf4/N/t9p6wU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            private static readonly string ppPublicKey_Admin = @"<RSAKeyValue><Modulus>qwXtxLB+YIY6Gp/FCm0+u6z5sPWZknjIu6YMOBjkSDJfDxS9KFWjwUeTFEqgFJVM4hGVDF7VmwJsUmgm91T+Gsh+xCKDPMNjmPSOxN33CXbeoqYE9qA3xFCXpeHtZoDsj6zaALdyJ+K4yiILeCtaJAkocXCOCH/wfIzFI0S+S/U=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            private static readonly string pPublicKey_Baoming = @"<RSAKeyValue><Modulus>5/ty+QRhHqgVQeI40VsuJEQZSBIqmIcV5+EQYg2X/QBrURsmwjrpxz0/foLdmVoqmrc1146Tu4H5CdJzU3GyiawFHz8Ws3pMT/B/ME10/iG/Y8mCtsk9J27Bif83Qf+ySG16VLWMKrpuaDBYxX4U9g2VcoAASeVAUbCFF4icrtU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            private static readonly string pPublicKey_Kaowu = @"<RSAKeyValue><Modulus>zolsl4+xLL/rG/r9a8ECs0t5o7GM6E11auCDlb2WiDqNjRLaYZQ1b/h6gVAG0ZDikACBvoIxsfRU6GHfiRhgZ9/eAVXImSwgQgXIjq0TwTHRQ81CDDw9KctWXTZhnySLOqSZRd4Pv9JAWx8fQOjZEC9VjAJb/Qhy4NRMo1uGBpM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            private static readonly string pPublicKey_Luqu = @"<RSAKeyValue><Modulus>qREC6/PYthazryRvk/lCsKU4HIiKQUa8/MPm6xd4S5za52xZ/aQqIxw+hhv1bxJBcPZrLoeyrkKXpSpAKxqXw56GrfHXB+S1sohDm0HqAsp/nQW++VVwHD2w/p+JsogECfrEGsQ/XYmUgBU94izUYwTqslN3uSsu+KYYd3wWmhM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            private static readonly string pPublicKey_Daima = @"<RSAKeyValue><Modulus>2dPE4U63boNkuPSft3yJP37ZqpGcDYSbpgW94xb/EgBKd99MN2M+Dtd7oMKRvwefwsZEUBKRg0cIPTJk3pIzMVePt+sUD2RL4n7Y68qsR7srw846r4bwT79q+rQMYoplV+mjPgsG+kk+qk/q9To+AhDmqSfpHUXBxE2v+sMctt8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            private static readonly string pPublicKey_Update = @"<RSAKeyValue><Modulus>uVy/X6x3gWGAjim5dL6wrwHOE6i/MACcd2lAmHAIRNXpxDnA9Vt2r8LzKT9T8wtJ4QsuAPMzcA+g7S0Xq64GQUXmdvBasqcnFMeAJISN7FV9/o/ACmfBX03mniaNI1x/5cFlJrhIbOMvlXSF/OyLL4jhe/ANu3q083H/wecZQNM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            private static readonly string pPublicKey_Shezhi = @"<RSAKeyValue><Modulus>uVy/X6x3gWGAjim5dL6wrwHOE6i/MACcd2lAmHAIRNXpxDnA9Vt2r8LzKT9T8wtJ4QsuAPMzcA+g7S0Xq64GQUXmdvBasqcnFMeAJISN7FV9/o/ACmfBX03mniaNI1x/5cFlJrhIbOMvlXSF/OyLL4jhe/ANu3q083H/wecZQNM=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            #region 获取系统公钥
            /// <summary>
            /// 南职院
            /// </summary>
            public static string PublicKey_NZ
            {
                get { return pPublicKey_NZ; }
            }
            /// <summary>
            /// 后台系统
            /// </summary>
            public static string PublicKey_Admin
            {
                get { return ppPublicKey_Admin; }
            }
            /// <summary>
            /// 报名系统
            /// </summary>
            public static string PublicKey_Baoming
            {
                get { return pPublicKey_Baoming; }
            }
            /// <summary>
            /// 考务系统
            /// </summary>
            public static string PublicKey_Kaowu
            {
                get { return pPublicKey_Kaowu; }
            }
            /// <summary>
            /// 录取系统
            /// </summary>
            public static string PublicKey_Luqu
            {
                get { return pPublicKey_Luqu; }
            }
            /// <summary>
            /// 代码管理
            /// </summary>
            public static string PublicKey_Daima
            {
                get { return pPublicKey_Daima; }
            }
            /// <summary>
            /// 远程更新
            /// </summary>
            public static string PublicKey_Update
            {
                get { return pPublicKey_Update; }
            }
            /// <summary>
            /// 系统设置
            /// </summary>
            public static string PublicKey_Shezhi
            {
                get { return pPublicKey_Shezhi; }
            }
            #endregion
            #region 获取系统私钥
            /// <summary>
            /// 后台系统
            /// </summary>
            public static string PrivateKey_Admin
            {
                get { return pPrivateKey_Admin; }
            }
            /// <summary>
            /// 报名系统
            /// </summary>
            public static string PrivateKey_Baoming
            {
                get { return pPrivateKey_Baoming; }
            }
            /// <summary>
            /// 考务系统
            /// </summary>
            public static string PrivateKey_Kaowu
            {
                get { return pPrivateKey_Kaowu; }
            }
            /// <summary>
            /// 录取系统
            /// </summary>
            public static string PrivateKey_Luqu
            {
                get { return pPrivateKey_Luqu; }
            }
            /// <summary>
            /// 代码管理
            /// </summary>
            public static string PrivateKey_Daima
            {
                get { return pPrivateKey_Daima; }
            }
            /// <summary>
            /// 远程更新
            /// </summary>
            public static string PrivateKey_Update
            {
                get { return pPrivateKey_Update; }
            }
            /// <summary>
            /// 系统设置
            /// </summary>
            public static string PrivateKey_Shezhi
            {
                get { return pPrivateKey_Shezhi; }
            }

            #endregion

        }

        
        /// <summary>        
        /// 在非对称加密时，产生“公钥”和“私钥”        
        /// </summary>
        ///
        public static void GeneratePrivateKey()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            //产生私钥
            string privateKey = RSA.ToXmlString(true);
            //产生公钥            
            string publicKey = RSA.ToXmlString(false);
            ////写入文本文件中
            //StreamWriter one = new StreamWriter(@"d:/RSA_publicKey_Daima.txt", true, UTF8Encoding.UTF8);
            //one.Write(publicKey);
            //StreamWriter two = new StreamWriter(@"d:/RSA_privateKey_Daima.txt", true, UTF8Encoding.UTF8);
            //two.Write(privateKey);
            //one.Flush();
            //two.Flush();
            //one.Close();
            //two.Close();
        }

        /// <summary>        
        /// 非对称加密        
        /// </summary>        
        /// <param name="str">要加密的数据</param>        
        /// <param name="publicKey">公钥</param>        
        /// <returns>加密结果</returns>        
        public static string AsymmectricEncrypts(string str, string publicKey)        
        {            
            string result = string.Empty;            
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();            
            byte[] data = System.Text.Encoding.UTF8.GetBytes(str);            
            //设置公钥            
            RSA.FromXmlString(publicKey);            
            byte[] btResult = RSA.Encrypt(data, true);            
            result = Convert.ToBase64String(btResult);            
            return result;        
        }        
        /// <summary>        
        /// 非对称加密后的解密        
        /// </summary>        
        /// <param name="strcode">加密后的字符串</param>        
        /// <param name="privateKey">密钥（私钥）</param>        
        /// <returns>解密后的结果</returns>        
        public static string AsymmectricDecrypts(string strcode, string privateKey)        
        {           
            string result = string.Empty;           
            byte[] bydata = Convert.FromBase64String(strcode);    
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();      
            //私钥        
            RSA.FromXmlString(privateKey);       
            byte[] byR = RSA.Decrypt(bydata, true);       
            result = System.Text.Encoding.UTF8.GetString(byR);    
            return result;      
        }     
        #endregion
        #region DES对称加密解密方法
        public static class GetDESKey
        {
            private static readonly string pDESKeySSO = "linshubo_lsb_swlk";
            private static readonly string pDESKeyMenu = "linshubo_lsb_swlk";
            private static readonly string pDESKeyUpdate = "linshubo_lsb_swlk";
            private static readonly string pDESKeyShezhi = "linshubo_lsb_swlk";
            public static string DESKeySSO
            {
                get { return pDESKeySSO; }
            }
            public static string DESKeyMenu
            {
                get { return pDESKeyMenu; }
            }
            public static string DESKeyUpdate
            {
                get { return pDESKeyUpdate; }
            }
            public static string DESKeyShezhi
            {
                get { return pDESKeyShezhi; }
            }
        }

        /// <summary>
        /// 进行DES加密。
        /// </summary>
        /// <param name="pToEncrypt">要加密的字符串。</param>
        /// <param name="sKey">密钥。</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        public static string DESEncrypt(string pToEncrypt, string sKey)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary>
        /// 进行DES解密。
        /// </summary>
        /// <param name="pToDecrypt">要解密的以Base64</param>
        /// <param name="sKey">密钥。</param>
        /// <returns>已解密的字符串。</returns>
        public static string DESDecrypt(string pToDecrypt, string sKey)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }
        #endregion
        #endregion
        #region WebServiceKey
        public static class GetWebServiceKey
        {
            private static readonly string pWebServiceKeyNZ = "ABrGYb0SqQBRLOvFVyw46pGBCWOBcAXb"; //南职院
            private static readonly string pWebServiceKeyAdmin = "ABrGYb0SqQBRLOvFVyw46pGBCWOBcAXb"; //后台管理
            private static readonly string pWebServiceKeyBaoming = "ABrGYb0SqQBRLOvFVyw46pGBCWOBcAXb"; //报名管理
            private static readonly string pWebServiceKeyKaowu = "ABrGYb0SqQBRLOvFVyw46pGBCWOBcAXb"; //考务管理
            private static readonly string pWebServiceKeyLuqu = "ABrGYb0SqQBRLOvFVyw46pGBCWOBcAXb"; //录取管理

            public static string WebServiceKeyNZ
            {
                get { return pWebServiceKeyNZ; }
            }
            public static string WebServiceKeyAdmin
            {
                get { return pWebServiceKeyAdmin; }
            }
            public static string WebServiceKeyBaoming
            {
                get { return pWebServiceKeyBaoming; }
            }
            public static string WebServiceKeyKaowu
            {
                get { return pWebServiceKeyKaowu; }
            }
            public static string WebServiceKeyLuqu
            {
                get { return pWebServiceKeyLuqu; }
            }
        }
        #endregion
        #region UpdateKey
        public static class GetUpdateKey
        {
            private static readonly string pUpdateKeyAdmin = "ABrGYb0SqQBRLOvFVyw46pGBCWOBcAXb"; //后台管理
            private static readonly string pUpdateKeyBaoming = "ABrGYb0SqQBRLOvFVyw46pGBCWOBcAXb"; //报名管理
            private static readonly string pUpdateKeyKaowu = "ABrGYb0SqQBRLOvFVyw46pGBCWOBcAXb"; //考务管理
            private static readonly string pUpdateKeyLuqu = "ABrGYb0SqQBRLOvFVyw46pGBCWOBcAXb"; //录取管理

            public static string UpdateKeyAdmin
            {
                get { return pUpdateKeyAdmin; }
            }
            public static string UpdateKeyBaomin
            {
                get { return pUpdateKeyBaoming; }
            }
            public static string UpdateKeyKaowu
            {
                get { return pUpdateKeyKaowu; }
            }
            public static string UpdateKeyLuqu
            {
                get { return pUpdateKeyLuqu; }
            }
        }
        #endregion
    }
}
