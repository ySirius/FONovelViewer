using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FONovelViewer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 软件设置

        private static readonly string SoftwareName = "FONovelViewer";

        private static readonly string CacheFile = "usercache.txt";

        private static readonly string TmpFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + SoftwareName;

        private static readonly string StoragePath = TmpFolderPath + "\\storage";

        private static readonly string CachePath = TmpFolderPath + "\\cache";


        #endregion

        #region 数据变量

        private int chapterNum = 0;

        private int lineNum = 0;

        private Novel novel;

        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(TmpFolderPath))
                Directory.CreateDirectory(TmpFolderPath);

            if (!Directory.Exists(StoragePath))
                Directory.CreateDirectory(StoragePath);

            if (!Directory.Exists(CachePath))
                Directory.CreateDirectory(CachePath);
        }


        private void FrmMain_Shown(object sender, EventArgs e)
        {
            string cache = Path.Combine(TmpFolderPath, CacheFile);
            if (File.Exists(cache))
            {
                string content = File.ReadAllText(cache);
                if (!string.IsNullOrEmpty(content))
                {
                    string infopath = Path.Combine(CachePath, content);
                    if (File.Exists(infopath))
                    {
                        string[] lines = File.ReadAllLines(infopath);
                        chapterNum = Convert.ToInt32(lines[0]);
                        lineNum = Convert.ToInt32(lines[1]);
                    }
                    //if (MessageBox.Show(string.Format("上次[{0}]看到第[{1}]章,是否继续?", content, chapterNum)
                    //    , "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                    string novelpath = Path.Combine(StoragePath, content);
                    LoadNovel(novelpath, chapterNum);
                    lbchapters.Visible = false;
                    //}
                }
            }
        }

        private void TsmOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(文本文件)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dlg.FileName))
                {
                    string newPath = Path.Combine(TmpFolderPath, "storage", Path.GetFileName(dlg.FileName));
                    if (!File.Exists(newPath))
                        File.Copy(dlg.FileName, newPath, true);
                    LoadNovel(dlg.FileName);
                    File.WriteAllText(Path.Combine(TmpFolderPath, CacheFile), Path.GetFileName(dlg.FileName));
                }
            }
        }

        private void LoadNovel(string path)
        {
            LoadNovel(path, 0);
            chapterNum = 0;
        }

        private void LoadNovel(string path, int num)
        {
            novel = new Novel();
            novel.Name = Path.GetFileNameWithoutExtension(path);
            //LoadChapter(File.ReadAllText(path));

            ReadFile(path);
            UpdateListBox();
            if (novel.Chapters.Count > num)
            {
                tbContent.Text = novel.Chapters[num].Content;
            }
            lbchapters.SelectedIndex = num;
        }


        private void ReadFile(string filePath, int bufferSize = 8192)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize))
            {
                using (StreamReader reader = new StreamReader(fileStream, Encoding.GetEncoding("GB2312")))
                {
                    string strLine;
                    Chapter chapter = new Chapter();
                    while ((strLine = reader.ReadLine()) != null)
                    {
                        Regex reg = new Regex("第(.*?)章");
                        if (reg.IsMatch(strLine))
                        {
                            if (strLine.Length < 20)
                            {
                                chapter = new Chapter();
                                string name = strLine.Trim().Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                                chapter.Name = name;
                                novel.Chapters.Add(chapter);
                            }
                        }
                        chapter.Content += strLine + "\r\n";
                    }
                }
            }
        }

        private void LoadChapter(string content)
        {
            string[] lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] patArr = { "第(.*?)章", };
            Chapter chapter = new Chapter();
            foreach (var strLine in lines)
            {
                Regex reg = new Regex("第(.*?)章");
                if (reg.IsMatch(strLine))
                {
                    if (strLine.Length < 20)
                    {
                        chapter = new Chapter();
                        string name = strLine.Trim().Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
                        chapter.Name = name;
                        novel.Chapters.Add(chapter);
                    }
                }
                chapter.Content += strLine + "\r\n";
            }
        }

        private void UpdateListBox()
        {
            if (novel == null) return;
            lbchapters.Items.Clear();
            foreach (var chapter in novel.Chapters)
            {
                lbchapters.Items.Add(chapter.Name);
            }    
        }

        private void BtnPre_Click(object sender, EventArgs e)
        {
            if (novel == null || novel.Chapters.Count == 0) return;
            if (chapterNum > 0)
            {
                chapterNum--;
                lineNum = 0;
                UpdateInfo();
                tbContent.SelectionStart = 0;
                tbContent.ScrollToCaret();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (novel == null || novel.Chapters.Count == 0) return;
            if (chapterNum < novel.Chapters.Count - 1)
            {
                chapterNum++;
                lineNum = 0;
                UpdateInfo();
                tbContent.SelectionStart = 0;
                tbContent.ScrollToCaret();
            }
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            lbchapters.Visible = true;
        }

        private void TbContent_Click(object sender, EventArgs e)
        {
            if (novel == null || string.IsNullOrEmpty(novel.Name)) return;
            lbchapters.Visible = false;
            lineNum = tbContent.SelectionStart;
            string path = Path.Combine(CachePath, novel.Name + ".txt");
            File.WriteAllText(path, chapterNum + "\r\n" + lineNum);
        }

        private void UpdateInfo()
        {
            lbchapters.SelectedIndex = chapterNum;
            tbContent.Text = novel.Chapters[chapterNum].Content;
            this.Text = novel.Chapters[chapterNum].Name;
            string path = Path.Combine(CachePath, novel.Name + ".txt");
            File.WriteAllText(path, chapterNum + "\r\n" + lineNum);
        }

        private void lbchapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbchapters.SelectedIndex != -1)
            {
                chapterNum = lbchapters.SelectedIndex;
                lineNum = 0;
                UpdateInfo();
            }
        }
    }
}
