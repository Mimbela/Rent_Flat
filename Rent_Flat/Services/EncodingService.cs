using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Rent_Flat.Services
{
    public class EncodingService
    {
        public string SHA256(string password)
        {

            var crypt = new SHA256Managed();
            string hash = string.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password));
            foreach(var currentByte in crypto)
            {
                hash += currentByte.ToString("x2");
            }


            return hash;
        }
    }
}