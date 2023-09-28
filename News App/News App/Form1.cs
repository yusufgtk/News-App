using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace News_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            
            if (textBox1.Text != "")
            {
                try
                {
                    var rssUrl = textBox1.Text;
                    XmlReader xmlReader = XmlReader.Create(rssUrl);
                    SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
                    xmlReader.Close();
                    Label[] label = new Label[feed.Items.Count()];
                    int i = 0;
                    foreach (var item in feed.Items)
                    {
                        //label[i].Text = item.Title.Text;
                        listView1.Items.Add((i + 1).ToString() + ") Haber");
                        listView1.Items.Add("Haber Başlığı => " + item.Title.Text);
                        listView1.Items.Add("Haber Açıklaması => " + item.Summary.Text);
                        listView1.Items.Add("Haber Linki => " + item.Links[0].Uri.ToString());
                        listView1.Items.Add("Haber Tarihi :  => " + item.PublishDate.ToString());
                        listView1.Items.Add("---------------------------------------------------------");
                        i++;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Girdiğiniz Rss Linkinde Sorun Oluştu!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Rss Linkini Giriniz!");
            }
        }
    }
}
