using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;

namespace TRMClassLibrary
{
    public class Simple3DES
    {
        static readonly string PasswordHash = "ERK2MMBM1R@J";
        static readonly string SaltKey = "S@LT&K3Y";
        static readonly string VIKey = "0@1b2C3D4e5F6g7H8";

        public static string Encrypt(string plainText)
        {

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
        public static bool ValidatePassword(string pwd)
        {
            return ValidatePassword(pwd, 8, 1, 1, 1, 0);
        }
         public static bool ValidatePassword(string pwd, int minLength=8, int numUpper=1, int numLower=1, int numNumbers=1,int numSpecial=0)
         {
         // Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters. 
         Regex upper = new Regex("[A-Z]");
         Regex lower = new Regex("[a-z]");
         Regex number = new Regex("[0-9]");
         // Special is "none of the above". 
         Regex special = new Regex("[^a-zA-Z0-9]");

         // Check the length. 
         if (pwd.Length < minLength)
         {
             string citemtxt = minLength > 1 ? "characters" : "character";
             System.Windows.Forms.MessageBox.Show("Password must have at least " + minLength.ToString() + citemtxt);
             return false;
         }
         // Check for minimum number of occurrences. 
         if (upper.Matches(pwd).Count < numUpper)
         {
             string citemtxt = numUpper > 1 ? "upper case letters" : "upper case letter";
             System.Windows.Forms.MessageBox.Show("Password must have at least " + numUpper.ToString() + citemtxt);

             return false ;
         }   
         if(lower.Matches(pwd).Count < numLower )
         {
             string citemtxt =  numLower > 1 ? "lower case letters" : "lower case letter";
             System.Windows.Forms.MessageBox.Show("Password must have at least " + numLower.ToString() + citemtxt);
           return false;
         }
         if(number.Matches(pwd).Count < numNumbers )
         {
             string citemtxt = numNumbers > 1 ? "numbers" : "number";
             System.Windows.Forms.MessageBox.Show("Password must have at least " + numNumbers.ToString() + citemtxt);
             return false;
         }
         if(special.Matches(pwd).Count < numSpecial )
         {
             string citemtxt = numNumbers > 1 ? "numbers" : "number";
             System.Windows.Forms.MessageBox.Show("Password must have at least " + numNumbers.ToString() + citemtxt);
             return false;
         }
         return true; 

        }

    }
 
   }
