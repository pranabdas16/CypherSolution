using System;

namespace CypherCode
{
  // Going forwar it's good to make other way arround so that we private this class...
  public class DecryptPassword : IDecryptPassword
    {
        public string DecryptPwd(string pwd)
        {
            try
            {
                return CheckLengthDecryption(pwd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string CheckLengthDecryption(string pwd)
        {
            try
            {
                if (pwd.Length > 25)
                {
                    string encodedData = pwd;
                    pwd = CleansePassword(encodedData);
                }
                return pwd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string CleansePassword(string pwd)
        {
            try
            {
                if (pwd.Length > 25)
                {
                    pwd = pwd.Substring(14);
                    pwd = pwd.Substring(0, pwd.Length - 14);
                    pwd = DecryptionPassword(pwd);
                }

                return pwd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string DecryptionPassword(string encodedData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}