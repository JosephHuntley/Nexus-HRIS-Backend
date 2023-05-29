using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Controller.Models;

namespace Controller
{
    public static class Password
    {
        const int keySize = 64;
        const int iterations = 350000;
        private static HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static string HashPassword(string password, byte[] salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
            salt,
            iterations,
                hashAlgorithm,
                keySize);
            return Convert.ToHexString(hash);
        }


        /// <summary>
        /// Checks if the JWT Claim EmployeeId matches the provided id.
        /// </summary>
        /// <param name="user">ControllerBase.User</param>
        /// <param name="id">Id of the employee that CRUD actions are being preformed on</param>
        /// <returns> true if the id's match and false if they don't or the claim EmployeeId does not exist</returns>
        public static bool Authorize(ClaimsPrincipal user, int id)
        {
            string? userId = user.FindFirst("EmployeeId")?.Value;

            if (userId is null)
            {
                return false;
            }

            if (Convert.ToInt64(userId) != id)
            {
                return false;
            }

            return true;
        }
    }
}

