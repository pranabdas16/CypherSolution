using System;

namespace CypherCode
{
    // Going forwar it's good to make other way arround so that we private this class...
    public class EncryptPassword : IEncyrptPassword
    {
        public string EncryptPwd(string pwd)
        {
            try
            {
                pwd = CheckLengthEncryption(pwd).ToString();
                return pwd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string CheckLengthEncryption(string pwd)
        {
            try
            {
                if (pwd.Length > 0)
                {
                    pwd = pwd.Trim();
                    pwd = EncryptptionPassword(pwd).ToString();
                }
                return pwd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string EncryptptionPassword(string pwd)
        {
            try
            {
                byte[] encData_byte = new byte[pwd.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(pwd);
                string encodedData = Convert.ToBase64String(encData_byte);

                encodedData = SaltPassword(encodedData).ToString();

                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string SaltPassword(string pwd)
        {
            try
            {
                pwd = prefixPwd + pwd + postfixPed;

                return pwd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string prefixPwd = "XMLHNMHESHOHXZ";
        private string postfixPed = "MNCXJKELHDIHTS";
    }
}