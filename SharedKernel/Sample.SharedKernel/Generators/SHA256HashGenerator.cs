﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Text;

namespace Sofa.CourseManagement.SharedKernel.Generators
{
    public static class SHA256HashGenerator
    {
        public static string GenerateSHA256Hash(string stringToHash)
        {
            try
            {
                byte[] salt = Encoding.ASCII.GetBytes("12hi^UfgHDR8iY2H");
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: stringToHash,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));
                return hashed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
