﻿using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RSATest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            //string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Public.key");
            //StreamReader sr = new StreamReader(filePath, System.Text.Encoding.UTF8);
            //string publicKey = sr.ReadToEnd();
            //sr.Close();

            txtEncryptData.Text = RSAHelper.encryptByPublicKey(txtPublicKey.Text, txtMing.Text);

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            txtMing.Text = RSAHelper.decryptByPrivateKey(txtPrivateKey.Text, txtEncryptData.Text);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var keyDict = RSAHelper.GeneratRsaKey();
            var publickey = keyDict["PUBLIC"];
            var privatekey = keyDict["PRIVATE"];
            txtPrivateKey.Text = privatekey;
            txtPublicKey.Text = publickey;
            string privateKeyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "private.key");
            System.IO.File.WriteAllText(privateKeyFilePath, privatekey);

            string publicKeyFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "public.key");
            System.IO.File.WriteAllText(publicKeyFilePath, publickey);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtEncryptData.Text = RSAHelper.encryptByPrivateKey(txtPrivateKey.Text, txtMing.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtMing.Text = RSAHelper.decryptByPublicKey(txtPublicKey.Text, txtEncryptData.Text);
        }
    }
}
