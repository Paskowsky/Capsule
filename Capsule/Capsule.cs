using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Capsule
{
    public static class Capsule
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();


        /// <summary>
        /// Read data from capsule decrypting symmetric key with rsa private key
        /// </summary>
        /// <param name="capsule"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static byte[] ReadCapsule(byte[] capsule, byte[] privateKey)
        {
            byte[][] values = DecodeArrays(capsule);

            using (RSACryptoServiceProvider rsa = CreateRSA(privateKey))
            {
                if (rsa.PublicOnly)
                    throw new Exception();

                using (RijndaelManaged rij = new RijndaelManaged())
                {
                    rij.BlockSize = 256;
                    rij.KeySize = 256;

                    rij.Mode = CipherMode.CBC;
                    rij.Padding = PaddingMode.PKCS7;

                    rij.Key = rsa.Decrypt(values[1], false);
                    rij.IV = rsa.Decrypt(values[2], false);

                    using (ICryptoTransform dec = rij.CreateDecryptor())
                    {
                        return dec.TransformFinalBlock(values[0], 0, values[0].Length);
                    }
                }
            }

        }


        /// <summary>
        /// Write data to capsule encrypting symmetric key with rsa public key
        /// </summary>
        /// <param name="data"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static byte[] WriteCapsule(byte[] data, byte[] publicKey)
        {
            using (RSACryptoServiceProvider rsa = CreateRSA(publicKey))
            {
                using (RijndaelManaged rij = new RijndaelManaged())
                {
                    rij.BlockSize = 256;
                    rij.KeySize = 256;

                    rij.Mode = CipherMode.CBC;
                    rij.Padding = PaddingMode.PKCS7;

                    rij.GenerateIV();
                    rij.GenerateKey();

                    using (ICryptoTransform enc = rij.CreateEncryptor())
                    {
                        return EncodeArrays(enc.TransformFinalBlock(data, 0, data.Length),
                            rsa.Encrypt(rij.Key, false),
                            rsa.Encrypt(rij.IV, false));
                    }
                }
            }
        }


        /// <summary>
        /// Verify capsule signature using rsa public key
        /// </summary>
        /// <param name="capsule"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static byte[] VerifyCapsule(byte[] capsule, byte[] publicKey)
        {
            byte[][] values = DecodeArrays(capsule);
                        
            using (RSACryptoServiceProvider rsa = CreateRSA(publicKey))
            {
                using (SHA256Managed sha256 = new SHA256Managed())
                {
                    if (rsa.VerifyData(values[0], sha256, values[1]))
                        return values[0];
                }
            }
            throw new Exception("Failed to verify");
        }

        /// <summary>
        /// Sign capsule using rsa private key
        /// </summary>
        /// <param name="capsule"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static byte[] SignCapsule(byte[] capsule, byte[] privateKey)
        {
            using (RSACryptoServiceProvider rsa = CreateRSA(privateKey))
            {
                if (rsa.PublicOnly)
                    throw new Exception();

                using (SHA256Managed sha256 = new SHA256Managed())
                {
                    byte[] signature = rsa.SignData(capsule, sha256);

                    return EncodeArrays(capsule, signature);
                }
            }
        }




        private static RSACryptoServiceProvider CreateRSA(byte[] key)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportCspBlob(key);
            return rsa;
        }

        private static byte[] EncodeArrays(params byte[][] bytes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    bw.Write((byte)bytes.Length);
                    foreach (byte[] b in bytes)
                    {
                        bw.Write(b.Length);
                        bw.Write(b);
                    }
                }
                return ObfuscateArray(ms.ToArray());
            }

        }

        private static byte[][] DecodeArrays(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(DeobfuscateArray(data)))
            {
                using (BinaryReader br = new BinaryReader(ms))
                {
                    int n = br.ReadByte();
                    byte[][] r = new byte[n][];
                    for (int i = 0; i < n; i++)
                    {
                        r[i] = br.ReadBytes(br.ReadInt32());
                    }
                    return r;
                }
            }
        }

        private static byte[] ObfuscateArray(byte[] capsule)
        {
            const int keyLength = 32;

            byte[] newCapsule = new byte[capsule.Length + keyLength];
            rng.GetBytes(newCapsule);

            for (int i = 0; i < capsule.Length; i++)
            {
                newCapsule[i + keyLength] = (byte)(capsule[i] ^ newCapsule[(i % keyLength)]);
            }

            return newCapsule;
        }

        private static byte[] DeobfuscateArray(byte[] capsule)
        {
            const int keyLength = 32;

            byte[] newCapsule = new byte[capsule.Length - keyLength];

            for (int i = 0; i < newCapsule.Length; i++)
            {
                newCapsule[i] = (byte)(capsule[i + keyLength] ^ capsule[i % keyLength]);
            }

            return newCapsule;
        }

    }
}
