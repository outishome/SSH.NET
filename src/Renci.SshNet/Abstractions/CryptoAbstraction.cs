﻿using System;
using Renci.SshNet.Security.Cryptography;

namespace Renci.SshNet.Abstractions
{
    internal static class CryptoAbstraction
    {
        private static readonly System.Security.Cryptography.RandomNumberGenerator Randomizer = CreateRandomNumberGenerator();

        /// <summary>
        /// Generates a <see cref="Byte"/> array of the specified length, and fills it with a
        /// cryptographically strong random sequence of values.
        /// </summary>
        /// <param name="length">The length of the array generate.</param>
        public static byte[] GenerateRandom(int length)
        {
            var random = new byte[length];
            GenerateRandom(random);
            return random;
        }

        /// <summary>
        /// Fills an array of bytes with a cryptographically strong random sequence of values.
        /// </summary>
        /// <param name="data">The array to fill with cryptographically strong random bytes.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        /// <remarks>
        /// The length of the byte array determines how many random bytes are produced.
        /// </remarks>
        public static void GenerateRandom(byte[] data)
        {
            Randomizer.GetBytes(data);
        }

        public static System.Security.Cryptography.RandomNumberGenerator CreateRandomNumberGenerator()
        {
            return System.Security.Cryptography.RandomNumberGenerator.Create();
        }

        public static System.Security.Cryptography.MD5 CreateMD5()
        {
            return System.Security.Cryptography.MD5.Create();
        }

        public static System.Security.Cryptography.SHA1 CreateSHA1()
        {
            return System.Security.Cryptography.SHA1.Create();
        }

        public static System.Security.Cryptography.SHA256 CreateSHA256()
        {
            return System.Security.Cryptography.SHA256.Create();
        }

        public static System.Security.Cryptography.SHA384 CreateSHA384()
        {
            return System.Security.Cryptography.SHA384.Create();
        }

        public static System.Security.Cryptography.SHA512 CreateSHA512()
        {
            return System.Security.Cryptography.SHA512.Create();
        }

#if FEATURE_HASH_RIPEMD160_CREATE || FEATURE_HASH_RIPEMD160_MANAGED
        public static System.Security.Cryptography.RIPEMD160 CreateRIPEMD160()
        {
#if FEATURE_HASH_RIPEMD160_CREATE
            return System.Security.Cryptography.RIPEMD160.Create();
#else
            return new System.Security.Cryptography.RIPEMD160Managed();
#endif
        }
#else
        public static global::SshNet.Security.Cryptography.RIPEMD160 CreateRIPEMD160()
        {
            return new global::SshNet.Security.Cryptography.RIPEMD160();
        }
#endif // FEATURE_HASH_RIPEMD160

        public static System.Security.Cryptography.HMACMD5 CreateHMACMD5(byte[] key)
        {
            return new System.Security.Cryptography.HMACMD5(key);
        }

        public static HMACMD5 CreateHMACMD5(byte[] key, int hashSize)
        {
            return new HMACMD5(key, hashSize);
        }

        public static System.Security.Cryptography.HMACSHA1 CreateHMACSHA1(byte[] key)
        {
            return new System.Security.Cryptography.HMACSHA1(key);
        }

        public static HMACSHA1 CreateHMACSHA1(byte[] key, int hashSize)
        {
            return new HMACSHA1(key, hashSize);
        }

        public static System.Security.Cryptography.HMACSHA256 CreateHMACSHA256(byte[] key)
        {
            return new System.Security.Cryptography.HMACSHA256(key);
        }

        public static HMACSHA256 CreateHMACSHA256(byte[] key, int hashSize)
        {
            return new HMACSHA256(key, hashSize);
        }

        public static System.Security.Cryptography.HMACSHA384 CreateHMACSHA384(byte[] key)
        {
            return new System.Security.Cryptography.HMACSHA384(key);
        }

        public static HMACSHA384 CreateHMACSHA384(byte[] key, int hashSize)
        {
            return new HMACSHA384(key, hashSize);
        }

        public static System.Security.Cryptography.HMACSHA512 CreateHMACSHA512(byte[] key)
        {
            return new System.Security.Cryptography.HMACSHA512(key);
        }

        public static HMACSHA512 CreateHMACSHA512(byte[] key, int hashSize)
        {
            return new HMACSHA512(key, hashSize);
        }

#if FEATURE_HMAC_RIPEMD160
        public static System.Security.Cryptography.HMACRIPEMD160 CreateHMACRIPEMD160(byte[] key)
        {
            return new System.Security.Cryptography.HMACRIPEMD160(key);
        }
#else
        public static global::SshNet.Security.Cryptography.HMACRIPEMD160 CreateHMACRIPEMD160(byte[] key)
        {
            return new global::SshNet.Security.Cryptography.HMACRIPEMD160(key);
        }
#endif // FEATURE_HMAC_RIPEMD160
    }
}
