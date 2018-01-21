using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace ImageViewer.ViewModel
{
    public class ImageViewModel : ViewModelBase
    {
        public string Name { get; set; }
        private string _path;
        private Uri _source;

        public Uri Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public override string ToString()
        {
            return _source.ToString();
        }

        public BitmapImage Image(string path)
        {
            object file = File.OpenRead(path);
            BitmapImage image = file as BitmapImage; // chcek and improve
            return image;
        }

        private string GetFileName()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "*";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Return open file dialog box results
            return (result == true) ? dlg.FileName : null;
        }

        private void LoadLine(string line)
        {
            string[] words = line.Split(" \t,.;()\"\'".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                string wordLower = word.ToLower();
                int count;

                //if (!_wordCounts.TryGetValue(wordLower, out count))
                //{
                //    count = 0;
                //    _wordCounts.Add(wordLower, 0);
                //}

                //_wordCounts[wordLower] = count + 1;
            }
        }

        private void LoadFileData(string file)
        {
            if (!string.IsNullOrEmpty(file))
            {
                using (FileStream contents = File.OpenRead(file))
                using (StreamReader reader = new StreamReader(contents))
                {
                    //_wordCounts.Clear();

                    while (!reader.EndOfStream)
                    {
                        LoadLine(reader.ReadLine());
                    }
                }
            }
        }
    }
}
