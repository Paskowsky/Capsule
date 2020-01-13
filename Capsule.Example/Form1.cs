using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Capsule.Example
{
    public partial class Form1 : Form
    {
        private byte[] privateKey;
        private byte[] publicKey;



        public Form1()
        {
            InitializeComponent();

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(4096))
            {
                privateKey = rsa.ExportCspBlob(true);
                publicKey = rsa.ExportCspBlob(false);
            }
        }

        private void exportPubButton_Click(object sender, EventArgs e)
        {
            string path = SaveFile("public.key", "Key (.key)|*.key");
            if (string.IsNullOrEmpty(path))
                return;

            File.WriteAllBytes(path, publicKey);
        }

        private void exportPrivButton_Click(object sender, EventArgs e)
        {
            string path = SaveFile("private.key", "Key (.key)|*.key");
            if (string.IsNullOrEmpty(path))
                return;

            File.WriteAllBytes(path, privateKey);
        }

        private void importPubButton_Click(object sender, EventArgs e)
        {
            string path = OpenFile("public.key", "Key (.key)|*.key");

            if (File.Exists(path))
            {
                publicKey = File.ReadAllBytes(path);
            }
        }

        private void importPrivButton_Click(object sender, EventArgs e)
        {
            string path = OpenFile("private.key", "Key (.key)|*.key");

            if (File.Exists(path))
            {
                privateKey = File.ReadAllBytes(path);
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = OpenFile("", "Anything (*.*)|*.*");

                if (!File.Exists(path))
                    return;

                byte[] file = File.ReadAllBytes(path);

                byte[] capsule = Capsule.WriteCapsule(file, publicKey);

                string save_path = SaveFile(Path.GetFileName(path) + ".capsule", "Capsule (.capsule)|*.capsule");

                if (string.IsNullOrEmpty(save_path))
                    return;

                File.WriteAllBytes(save_path, capsule);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\r\n" + ex.ToString());
            }
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = OpenFile("", "Anything (*.*)|*.*");

                if (!File.Exists(path))
                    return;

                byte[] file = File.ReadAllBytes(path);

                byte[] capsule = Capsule.SignCapsule(file, privateKey);

                string save_path = SaveFile(Path.GetFileName(path) + ".scapsule", "SCapsule (.scapsule)|*.scapsule");

                if (string.IsNullOrEmpty(save_path))
                    return;

                File.WriteAllBytes(save_path, capsule);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\r\n" + ex.ToString());
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = OpenFile("", "Capsule (.capsule)|*.capsule");

                if (!File.Exists(path))
                    return;

                byte[] capsule = File.ReadAllBytes(path);

                byte[] file = Capsule.ReadCapsule(capsule, privateKey);

                string save_path = SaveFile(Path.GetFileNameWithoutExtension(path), "Anything (*.*)|*.*");

                if (string.IsNullOrEmpty(save_path))
                    return;

                File.WriteAllBytes(save_path, file);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\r\n" + ex.ToString());
            }
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = OpenFile("", "SCapsule (.scapsule)|*.scapsule");

                if (!File.Exists(path))
                    return;

                byte[] capsule = File.ReadAllBytes(path);

                byte[] file = Capsule.VerifyCapsule(capsule, publicKey);

                string save_path = SaveFile(Path.GetFileNameWithoutExtension(path), "Anything (*.*)|*.*");

                if (string.IsNullOrEmpty(save_path))
                    return;

                File.WriteAllBytes(save_path, file);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\r\n" + ex.ToString());
            }
        }

        private void signEncryptSignButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = OpenFile("", "Anything (*.*)|*.*");

                if (!File.Exists(path))
                    return;

                byte[] file = File.ReadAllBytes(path);

                byte[] capsule = Capsule.SignCapsule(file, privateKey);

                capsule = Capsule.WriteCapsule(capsule, publicKey);

                capsule = Capsule.SignCapsule(capsule, privateKey);

                string save_path = SaveFile(Path.GetFileName(path) + ".scapsule", "SCapsule (.scapsule)|*.scapsule");

                if (string.IsNullOrEmpty(save_path))
                    return;

                File.WriteAllBytes(save_path, capsule);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\r\n" + ex.ToString());
            }
        }

        private void verifyDecryptVerifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = OpenFile("", "SCapsule (.scapsule)|*.scapsule");

                if (!File.Exists(path))
                    return;

                byte[] capsule = File.ReadAllBytes(path);

                capsule = Capsule.VerifyCapsule(capsule, publicKey);

                capsule = Capsule.ReadCapsule(capsule, privateKey);

                byte[] file = Capsule.VerifyCapsule(capsule, publicKey);

                string save_path = SaveFile(Path.GetFileNameWithoutExtension(path), "Anything (*.*)|*.*");

                if (string.IsNullOrEmpty(save_path))
                    return;

                File.WriteAllBytes(save_path, file);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\r\n" + ex.ToString());
            }
        }


        private static string SaveFile(string fileName, string filter)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = fileName;
                sfd.Filter = filter;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    return sfd.FileName;
                }
            }
            return string.Empty;
        }

        private static string OpenFile(string fileName, string filter)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.FileName = fileName;
                ofd.Filter = filter;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return ofd.FileName;
                }
            }
            return string.Empty;
        }
    }
}
