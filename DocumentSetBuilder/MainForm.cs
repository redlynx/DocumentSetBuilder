using DocumentSetBuilder.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentSetBuilder
{
    public partial class MainForm : Form
    {

        List<String> files = new List<String>();
        Set docSet = new Set();

        string root, src, dest, destTrain, destTest, currentSrcFolderName;
        double percentageSplit;
        int seed;

        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }


        private void cmdGo_Click(object sender, EventArgs e)
        {

            SaveSettings();

            // start a background worker to to the job
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            // disable the button
            cmdGo.Enabled = false;
            
            pBDirs.Minimum = pBDirs.Value = 0;
            pBDirs.Maximum = Directory.GetDirectories(root, "*.*", SearchOption.AllDirectories).Count();
            pBDirs.Step = 1;

            backgroundWorker1.RunWorkerAsync();
         
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            int current = 0;

            // recursively repeat for every subfolder encountered
            foreach (var d in Directory.GetDirectories(root, "*.*", SearchOption.AllDirectories))
            {

                // set the src directory
                src = AddTrailingBackslash(d);

                // get the current source folder name
                currentSrcFolderName = Directory.GetParent(Path.Combine(src)).Name;

                // set the target destination
                destTrain = Path.Combine(dest, "Train", src.Substring(root.Length));
                destTest = Path.Combine(dest, "Test", src.Substring(root.Length));

                // pick the files from the source directory 
                files = GetDistinctFileList(src);
                files.Shuffle(seed);
                docSet = SplitDocumentSet(files, percentageSplit);
                // now we have a set of shuffled filemasks

                // delete and recreate destination directories
                if (Directory.Exists(destTrain)) Directory.Delete(destTrain, true);
                if (Directory.Exists(destTest)) Directory.Delete(destTest, true);
                Directory.CreateDirectory(destTrain);
                Directory.CreateDirectory(destTest);

                // now export the two created sets
                ExportDocumentSet(docSet, destTrain, destTest);

                current++;
                backgroundWorker1.ReportProgress(current / Directory.GetDirectories(root, "*.*", SearchOption.AllDirectories).Count() * 100);

            }

        }


        protected List<String> GetDistinctFileList(String path)
        {

            List<String> files = new List<String>(); 
            string[] fileEntries = Directory.GetFiles(path);

            foreach (string fileName in fileEntries)
            {

                // we add the file names without extension, so additional documents may be moved as well
                // for example: xdoc files, txt files
                files.Add(Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName)));
            }

            // remove duplicates
            files = files.Distinct().ToList();

            return files;

        }

        protected String AddTrailingBackslash(String path)
        {
            String s = path;
            if (!path.EndsWith("\\")) s = path + "\\";
            return s;
        }

        protected Set SplitDocumentSet(List<String> files, double percentageSplit)
        {
            int i = 0;
            Set splittedSet = new Set();

            // splitting the list into 2 parts (this might not be the most efficient way...)
            
            foreach (var item in files)
            {
                if (i < (files.Count - 1) * (percentageSplit))
                {
                    splittedSet.TrainingSet.Add(item);
                }
                else
                {
                    splittedSet.TestSet.Add(item);
                }
                i++;
            }

            return splittedSet;
        }


        protected void ExportDocumentSet(Set s, string destTrain, string destTest)
        {
            foreach (var item in s.TestSet)
            {
                // for each filename, there may be multiple files
                foreach (var file in Directory.GetFiles(Path.GetDirectoryName(item), Path.GetFileNameWithoutExtension(item) + ".*"))
                {
                    File.Copy(file, Path.Combine(destTest, Path.GetFileName(file)), true);
                }                
            }

            foreach (var item in s.TrainingSet)
            {
                // for each filename, there may be multiple files
                foreach (var file in Directory.GetFiles(Path.GetDirectoryName(item), Path.GetFileNameWithoutExtension(item) + ".*"))
                {
                    File.Copy(file, Path.Combine(destTrain, Path.GetFileName(file)), true);
                }                
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBDirs.PerformStep();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done processing!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmdGo.Enabled = true;

        }

        private void SaveSettings()
        {
            try
            {
                // this is the root directory that contains sub-directories with files that should be separated
                root = AddTrailingBackslash(txtSource.Text);
                // this is the target folder for test and training sets
                dest = AddTrailingBackslash(txtDestination.Text);

                // load seed and percentage split from user settings
                Int32.TryParse(txtSeed.Text, out seed);
                Double.TryParse(txtPercentageSplit.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out percentageSplit);
                
                Properties.Settings.Default.Source = root;
                Properties.Settings.Default.Destination = dest;
                Properties.Settings.Default.Seed = seed;
                Properties.Settings.Default.PercentageSplit = percentageSplit;

                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
            }
            
           
        }

        private void LoadSettings()
        {
            try
            {
                root = Properties.Settings.Default.Source;
                dest = Properties.Settings.Default.Destination;
                seed = Properties.Settings.Default.Seed;
                percentageSplit = Properties.Settings.Default.PercentageSplit;

                txtSource.Text = root;
                txtDestination.Text = dest;
                txtSeed.Text = seed.ToString();
                txtPercentageSplit.Text = percentageSplit.ToString();

            }
            catch (Exception)
            {
            }
        }

    }
}
