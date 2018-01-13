using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace learn20180109
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            inittreeView();
        }

        private void test()
        {
            FileInfo fi = new FileInfo("a");
            DateTime dt=fi.LastWriteTime;
        }
        /// <summary>
        /// 树形结构测试
        /// </summary>
        private void inittreeView()
        {
            this.treeView1.TopNode = new TreeNode("头结点");
            this.treeView1.Nodes.Add(new TreeNode("a"));
            this.treeView1.Nodes.Add(new TreeNode("b"));
        }
        /// <summary>
        /// 加密
        /// </summary>
        private void testJIAMI()
        {
            RijndaelManaged myRijndael =new RijndaelManaged();
            FileStream fs = File.Open("", FileMode.Create, FileAccess.Write);
            FileStream fs1 = File.Open("", FileMode.Open, FileAccess.Read);
            //加密的秘钥和
            byte[] key = {};
            byte[] IV = {};
            //写入加密文件
            CryptoStream cs=new CryptoStream(fs,myRijndael.CreateDecryptor(key,IV),CryptoStreamMode.Write);
         //   CryptoStream cs = new CryptoStream(fs, myRijndael.CreateDecryptor(key, IV), CryptoStreamMode.Read);解密

            BinaryReader br =new BinaryReader(fs);
            cs.Write(br.ReadBytes((int)fs1.Length),0,(int)fs1.Length);//写入加密文件

        }

        private void DataTransfer()
        {
            int a = 8;
            string str = a.ToString("0000");//转换为4位有效数字
        }


    }
}
