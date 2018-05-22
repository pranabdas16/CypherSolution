using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CypherCode;

namespace CypherSol
{
    class Program
    {
        private IDecryptPassword objIDecryptPassword;
        private IEncyrptPassword objIEncyrptPassword;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Statring Cypher here!" + "\n");
            #region This is the very first region to encyrpt the string.... commenting it for now
            //string str = encyrptString().ToString();
            //string decoded = dcyptString(str).ToString();
            //Console.WriteLine("Here is the encyrpted Password:" + str + "\n");
            //Console.WriteLine("Here is the decoded Password:" + decoded);
            #endregion

            #region This is to use new class library which is Cypher Sol...
            //Working code if class is public.....
            var obj = new EncryptPassword();

            string str = obj.EncryptPwd("Complex Password");

            Console.WriteLine("Here is the encyrpted Password: " + str + "\n");

            var objDecyrpt = new DecryptPassword();

            string actualPassword = objDecyrpt.DecryptPwd(str);

            Console.WriteLine("Here is the actual Password: " + actualPassword);
            #endregion



            Console.ReadLine();
      

    }
        #region To apply Interface for encryption and decryption.....
       public void applyInterface(IDecryptPassword iDecryptPassword, IEncyrptPassword iEncyrptPassword)
        {
            objIDecryptPassword = iDecryptPassword;
            objIEncyrptPassword = iEncyrptPassword;

           
        }
        #endregion
        static string encyrptString()
        {
            string password = "Complex";
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                
                //dcyptString(encodedData);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
            //return str;
        }

        static string dcyptString(string encodedData)
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
                throw new Exception("Error in Decoding to 64 " + ex.Message);
            }
        }
    }
}
