using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ZopfliPng_GUI
{
    public partial class MainForm : Form
    {
        private State _state = State.None;
        private HashSet<string> _targetFiles = new HashSet<string>();
        private long beforeSize = 0;
        private long afterSize = 0;

        public MainForm()
        {
            InitializeComponent();
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
                    foreach(string file in Directory.EnumerateFiles(strs[i], "*.png", SearchOption.AllDirectories))
                    {
                        _targetFiles.Add(file);
                    }
                }
                else if (File.Exists(strs[i]) && Path.GetExtension(strs[i]) == ".png")
                {
                    _targetFiles.Add(strs[i]);
                }
            }

            beforeSize = GetFileSize(_targetFiles.ToArray());
            if (_targetFiles.Count > 0) ChangeState(State.Ready);
        }
        private void compressButton_Click(object sender, EventArgs e)
        {
            if (_state != State.Ready) return;
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
            }
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
            for(int index = 0; index <_targetFiles.Count;index++)
            {
                System.Threading.Thread.Sleep(200);
                backgroundWorker.ReportProgress(index);
            }
        }

        private void ChangeState(State state)
        {
            _state = state;
            switch (state)
            {
                case State.None:
                    guidanceLabel.Text = "Drag and drop png files.";
                    dropPointLabel.AllowDrop = true;
                    compressButton.Enabled = false;
                    beforeSizeTitleLabel.Visible = false;
                    beforeSizeValueLabel.Visible = false;
                    afterSizeTitleLabel.Visible = false;
                    afterSizeValueLabel.Visible = false;
                    break;
                case State.FileLoading:
                    guidanceLabel.Text = "Loading...";
                    compressButton.Enabled = false;
                    beforeSizeTitleLabel.Visible = false;
                    beforeSizeValueLabel.Visible = false;
                    afterSizeTitleLabel.Visible = false;
                    afterSizeValueLabel.Visible = false;
                    break;
                case State.Ready:
                    guidanceLabel.Text = "Press the Compress button";
                    compressButton.Enabled = true;
                    beforeSizeValueLabel.Text = beforeSize.ToString();
                    beforeSizeTitleLabel.Visible = true;
                    beforeSizeValueLabel.Visible = true;
                    afterSizeTitleLabel.Visible = false;
                    afterSizeValueLabel.Visible = false;
                    break;
                case State.Start:
                    guidanceLabel.Text = "Compressing...";
                    dropPointLabel.AllowDrop = false;
                    progressBar.Maximum = _targetFiles.Count - 1;
                    compressButton.Enabled = false;
                    backgroundWorker.WorkerReportsProgress = true;
                    break;
                case State.End:
                    guidanceLabel.Text = "Finished";
                    afterSizeValueLabel.Text = afterSize.ToString();
                    afterSizeTitleLabel.Visible = true;
                    afterSizeValueLabel.Visible = true;
                    dropPointLabel.AllowDrop = true;
                    break;
            }
        }
    }
}