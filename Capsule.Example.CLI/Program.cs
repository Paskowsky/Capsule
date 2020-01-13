using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Capsule.Example.CLI
{
    class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            byte[] important_data = new byte[64];
            r.NextBytes(important_data);

            Console.WriteLine("Important Data");
            HexOut(important_data);

            using (RSACryptoServiceProvider alice = new RSACryptoServiceProvider(4096))
            {
                byte[] alicePrivateKey = alice.ExportCspBlob(true);

                byte[] alicePublicKey = alice.ExportCspBlob(false);

                byte[] encrypted_important_data = Capsule.WriteCapsule(important_data, alicePublicKey);

                Console.WriteLine("Encrypted Important Data");
                HexOut(encrypted_important_data);

                byte[] signed_important_data = Capsule.SignCapsule(encrypted_important_data, alicePrivateKey);

                Console.WriteLine("Signed Encrypted Important Data");
                HexOut(signed_important_data);

                try
                {
                    byte[] verified_encrypted_important_data = Capsule.VerifyCapsule(signed_important_data, alicePublicKey);

                    Console.WriteLine("Verified Encrypted Important Data");
                    HexOut(verified_encrypted_important_data);

                    byte[] verified_decrypted_important_data = Capsule.ReadCapsule(verified_encrypted_important_data, alicePrivateKey);

                    Console.WriteLine("Verified Decrypted Important Data");
                    HexOut(verified_decrypted_important_data);

                }
                catch
                {
                    Console.WriteLine("Failed To Verify Data");
                }

            }

            Console.ReadLine();
        }

        static void HexOut(byte[] data)
        {
            Console.WriteLine();
            Console.WriteLine(BitConverter.ToString(data).Replace("-", "").ToLowerInvariant());
            Console.WriteLine();
        }



    }
}

