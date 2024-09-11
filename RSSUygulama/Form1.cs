using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace RSSUygulama
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

        // Hürriyet RSS Butonu

        private void buttonHURRİIYET_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> headlines = GetRSSHeadlines("https://www.hurriyet.com.tr/rss/anasayfa");
            foreach (var headline in headlines)
            {
                listBox1.Items.Add(headline);
            }
        }
        

        // Milliyet RSS Butonu
        private void buttonMILLIYET_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> headlines = GetRSSHeadlines("https://www.milliyet.com.tr/rss/rssNew/gundemRss.xml");
            foreach (var headline in headlines)
            {
                listBox1.Items.Add(headline);
            }
        }

        // Fotomaç RSS Butonu
        private void buttonFOTOMAC_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> headlines = GetRSSHeadlines("https://www.fotomac.com.tr/rss/anasayfa.xml");
            foreach (var headline in headlines)
            {
                listBox1.Items.Add(headline);
            }
        }

        // RSS başlıklarını döndüren metod
        private List<string> GetRSSHeadlines(string rssUrl)
        {
            List<string> headlines = new List<string>();
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                using (XmlReader reader = XmlReader.Create(rssUrl, settings))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                        {
                            headlines.Add(reader.ReadElementContentAsString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("RSS verisi yüklenirken bir hata oluştu: " + ex.Message);
            }
            return headlines;
        }

        
    }
}
