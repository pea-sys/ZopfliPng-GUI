using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace ZopfliPng_GUI
{
    public partial class MainForm : Form
    {
        private State _state = State.None;
        private HashSet<string> _targetFiles = new HashSet<string>();
        private HashSet<string> _ignoreFiles = new HashSet<string>();
        private long beforeSize = 0;
        private long afterSize = 0;
        private long successCount = 0;
        private readonly string workDir = Environment.CurrentDirectory + @"\tmp";
        public MainForm()
        {
            InitializeComponent();
            MinCompressionRatioValueUpDown.Value = Properties.Settings.Default.MinCompressionRatio;
            ChangeState(State.None);
        }

        private void dropPointLabel_DragEnter(object sender, DragEventArgs e)
        {
            if (_state == State.Start) return;
            e.Effect = DragDropEffects.All;
        }

        private void dropPointLabel_DragDrop(object sender, DragEventArgs e)
        {
            if (_state == State.Start) return;
            if (e.Data is null) return;
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            string[] strs = (string[])e.Data.GetData(DataFormats.FileDrop);
           
            
            if (_targetFiles.Count > 0) ChangeState(State.FileLoading);

            for (int i = 0; i < strs.Length; i++)
            {
                if (Directory.Exists(strs[i]))
                {
                    foreach (string file in Directory.EnumerateFiles(strs[i], "*.png", SearchOption.AllDirectories))
                    {
                        if (IsPNG(file))
                        {
                            _targetFiles.Add(file);
                        }
                    }
                }
                else if (File.Exists(strs[i]))
                {
                    if (IsPNG(strs[i]))
                    {
                        _targetFiles.Add(strs[i]);
                    }
                }
            }

            successCount = 0;
            if (_targetFiles.Count > 0)
            {
                ChangeState(State.Ready);
            }
            else
            {
                ChangeState(State.None);
            }
        }
        private void compressButton_Click(object sender, EventArgs e)
        {
            if (_state != State.Ready) return;

            foreach (var file in _targetFiles)
            {
                if (!File.Exists(file) ||
                    ((File.GetAttributes(file) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly))
                {
                    _ignoreFiles.Add(file);
                }
            }
            _targetFiles.RemoveWhere(x => _ignoreFiles.Contains(x));

            beforeSize = GetFileSize(_targetFiles.ToArray());

            ChangeState(State.Start);
            backgroundWorker.RunWorkerAsync();
        }
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Compress();
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            compressCountValuelabel.Text = successCount.ToString();
            guidanceLabel.Text = String.Format("Compressing({0}/{1})...", progressBar.Value.ToString(), progressBar.Maximum.ToString());
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                guidanceLabel.Text = "Error:" + e.Error.Message;
            }
            else
            {
                afterSize = GetFileSize(_targetFiles.ToArray());
                ChangeState(State.End);
                _targetFiles.Clear();
                _ignoreFiles.Clear();
            }
        }
        private bool IsPNG(string filePath)
        {
            string asciiData = Encoding.ASCII.GetString(File.ReadAllBytes(filePath));
            if (asciiData.Length > 2 && asciiData.Substring(1,3)=="PNG")
            {
                // IDAT�`�����N�̑O��acTL�������apng�Ɣ���
                long idatPos = asciiData.IndexOf("IDAT");
                long acTLPos = asciiData.IndexOf("acTL");
                if (acTLPos != -1 && acTLPos < idatPos)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        private long GetFileSize(string[] strs)
        {
            long fileSize = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                fileSize += new FileInfo(strs[i]).Length;
            }
            return fileSize;
        }

        private void Compress()
        {
            try
            {
                int index = 0;
                long beforeSize = 0;
                long afterSize = 0;
                float reduceSize = 0;
                string workPath = string.Empty;
                ProcessStartInfo psi = new ProcessStartInfo(Environment.CurrentDirectory + @"\Vendor\zopflipng.exe");
                psi.CreateNoWindow = true;

                if (Directory.Exists(workDir))
                {
                    Directory.Delete(workDir, true);
                }
                Directory.CreateDirectory(workDir);


                foreach (var file in _targetFiles)
                {
                    workPath = workDir + @"\" + Path.GetFileName(file);
                    beforeSize = new FileInfo(file).Length;
                    index++;
                    psi.Arguments = String.Format("{0} {1} -y", file, workPath);
                    Process.Start(psi)?.WaitForExit();
                    afterSize = new FileInfo(workPath).Length;
                    reduceSize = (float)afterSize / (float)beforeSize * 100;
                    if (reduceSize < (float)MinCompressionRatioValueUpDown.Value)
                    {
                        Debug.Print(file + reduceSize.ToString());
                        successCount++;
                        File.Copy(workPath, file, true);
                    }
                    File.Delete(workPath);
                    backgroundWorker.ReportProgress(index);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void ChangeState(State state)
        {
            _state = state;
            switch (state)
            {
                case State.None:
                    guidanceLabel.Text = "Drag and drop png files.";
                    compressCountValuelabel.Text = successCount.ToString();
                    dropPointLabel.AllowDrop = true;
                    compressButton.Enabled = false;
                    compressCountTitlelabel.Visible = false;
                    compressCountValuelabel.Visible = false;
                    beforeSizeTitleLabel.Visible = false;
                    beforeSizeValueLabel.Visible = false;
                    afterSizeTitleLabel.Visible = false;
                    afterSizeValueLabel.Visible = false;
                    break;
                case State.FileLoading:
                    guidanceLabel.Text = "Loading...";
                    compressButton.Enabled = false;
                    compressCountTitlelabel.Visible = false;
                    compressCountValuelabel.Visible = false;
                    beforeSizeTitleLabel.Visible = false;
                    beforeSizeValueLabel.Visible = false;
                    afterSizeTitleLabel.Visible = false;
                    afterSizeValueLabel.Visible = false;
                    progressBar.Value = 0;
                    progressBar.Refresh();
                    break;
                case State.Ready:
                    guidanceLabel.Text = "Press the Compress button";
                    compressButton.Enabled = true;
                    compressCountTitlelabel.Visible = false;
                    compressCountValuelabel.Visible = false;
                    beforeSizeTitleLabel.Visible = false;
                    beforeSizeValueLabel.Visible = false;
                    afterSizeTitleLabel.Visible = false;
                    afterSizeValueLabel.Visible = false;
                    break;
                case State.Start:
                    guidanceLabel.Text = "Compressing...";
                    compressCountValuelabel.Text = successCount.ToString();
                    compressCountTitlelabel.Visible = true;
                    compressCountValuelabel.Visible = true;
                    dropPointLabel.AllowDrop = false;
                    progressBar.Maximum = _targetFiles.Count;
                    compressButton.Enabled = false;
                    backgroundWorker.WorkerReportsProgress = true;
                    beforeSizeValueLabel.Text = beforeSize.ToString();
                    beforeSizeTitleLabel.Visible = true;
                    beforeSizeValueLabel.Visible = true;
                    break;
                case State.End:
                    guidanceLabel.Text = String.Format("Finished({0}/{1})", progressBar.Value.ToString(), progressBar.Maximum.ToString());
                    afterSizeValueLabel.Text = afterSize.ToString();
                    afterSizeTitleLabel.Visible = true;
                    afterSizeValueLabel.Visible = true;
                    dropPointLabel.AllowDrop = true;
                    break;
            }
        }

        private void settingSaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinCompressionRatio = MinCompressionRatioValueUpDown.Value;
            Properties.Settings.Default.Save();
        }
    }
}