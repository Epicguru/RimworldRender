using Accord.Video.FFMPEG;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace RimworldRender
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string ImageFolderDir;
        public static string[] ImagePaths;
        public static bool Rendering = false;

        private void UponStartButtonPressed(object sender, System.EventArgs e)
        {
            if (Rendering)
                return;

            if (ImageFolderDir == null)
                return;

            Rendering = true;
            startRenderButton.Enabled = false;

            Program.SetStatus("Starting render...");

            string outputPath = Path.Combine(new DirectoryInfo(ImageFolderDir).Parent.FullName, "Output.avi");

            Renderer r = new Renderer(outputPath, ImagePaths);
            r.Width = (int)ResolutionX.Value;
            r.Height = (int)ResolutionY.Value;
            r.Bitrate = Program.GetBitrate();
            r.Codec = Program.Format;
            r.FrameRate = (int)FramerateInput.Value;
            r.FramesPerImage = Program.GetFramesPerImage();
            r.RenderPreview = RenderPreviewCheckbox.Checked;
            r.InterpolationMode = (InterpolationMode)Enum.Parse(typeof(InterpolationMode), SamplingComboBox.Items[SamplingComboBox.SelectedIndex].ToString());

            Program.Log($"Starting render of all {ImagePaths.Length} files in {ImageFolderDir}");
            Program.Log($"Resolution: {r.Width}x{r.Height}, Codec: {r.Codec}, Bitrate: {r.Bitrate}, Sampling: {r.InterpolationMode}");

            r.Done += () =>
            {
                startRenderButton.Invoke((MethodInvoker)(() => { startRenderButton.Enabled = true; }));
                Program.SetStatusSafe("Done!");
                Rendering = false;
                Program.SetProgressSafe(0);
                Process.Start(new DirectoryInfo(ImageFolderDir).Parent.FullName);
            };

            r.StartRender();
        }

        private void UponDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void UponDragDrop(object sender, DragEventArgs e)
        {
            if (Rendering)
                return;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if(files.Length != 1)
            {
                MessageBox.Show("Please drag only the folder that contains all the images.", "Expected folder", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            if (!Directory.Exists(files[0]))
            {
                MessageBox.Show("Expected a folder, not a file. Please drag the folder that contains all the images.", "Not a folder", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            ImageFolderDir = files[0];

            SelectFolder();
        }

        private void SelectFolder()
        {
            ImagePaths = Directory.GetFiles(ImageFolderDir, "*.png", SearchOption.TopDirectoryOnly);

            if (ImagePaths.Length < 2)
            {
                MessageBox.Show($"The folder must contain at least two images to be rendered. Found {ImagePaths.Length}.", "Not enough images", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                ImageFolderDir = null;
                ImagePaths = null;
                return;
            }

            Program.Log($"Found {ImagePaths.Length} image files.");

            Program.SetStatus($"Ready: {ImagePaths.Length} images selected.");
            startRenderButton.Enabled = true;

            selectedFolderText.Text = ImageFolderDir;
        }

        private void UponComboValueChanged(object sender, System.EventArgs e)
        {
            Program.Format = (VideoCodec)Enum.Parse(typeof(VideoCodec), (string)OutputFormatCombo.Items[OutputFormatCombo.SelectedIndex]);
            Program.Log("Changed format to " + Program.Format);            
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            OutputFormatCombo.Items.AddRange(Enum.GetNames(typeof(VideoCodec)));
            SamplingComboBox.Items.AddRange(new object[]
            {
                InterpolationMode.HighQualityBicubic,
                InterpolationMode.Bicubic,
                InterpolationMode.High,
                InterpolationMode.HighQualityBilinear,
                InterpolationMode.Bilinear,
                InterpolationMode.Low,
                InterpolationMode.NearestNeighbor
            });
            OutputFormatCombo.SelectedIndex = 0;
            SamplingComboBox.SelectedIndex = 0;
            BitrateComboBox.SelectedIndex = 2;
            UponImagesPerSecondChange(null, null);
            IPSWarning.Text = "";
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private int oldBitrateIndex = 2;
        private void UponBitrateComboChange(object sender, EventArgs e)
        {
            decimal old = Program.GetBitrate(oldBitrateIndex);
            decimal div = ((decimal)Math.Pow(1000, BitrateComboBox.SelectedIndex));
            decimal newValue = old / div;

            BitrateInput.Value = newValue;
            oldBitrateIndex = BitrateComboBox.SelectedIndex;
        }

        private void UponImagesPerSecondChange(object sender, EventArgs e)
        {
            int realIPS = (int)FramerateInput.Value / Program.GetFramesPerImage();
            int expectedIPS = (int)ImagesPerSecondInput.Value;

            if(realIPS != expectedIPS)
            {
                IPSWarning.Text = $"Due to the selected framerate, the actual\n images per second will be {realIPS}.\n";
                if(ImageFolderDir != null)
                {
                    IPSWarning.Text += $"This changes expected video length from\n{((float)ImagePaths.Length / expectedIPS):F1} to {((float)ImagePaths.Length / realIPS):F1} seconds";
                }
            }
            else
            {
                IPSWarning.Text = "";
            }
        }

        private void UponFramerateChange(object sender, EventArgs e)
        {
            UponImagesPerSecondChange(sender, e);
        }

        private void UponSelectFolderButtonPressed(object sender, EventArgs e)
        {
            using (var d = new CommonOpenFileDialog("Image selector dialog"))
            {
                d.Title = "select the folder containing images.";
                d.DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                d.IsFolderPicker = true;
                d.Multiselect = false;

                if(d.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    ImageFolderDir = d.FileName;
                    SelectFolder();
                }
            }
        }

        private void CheckNewVersionButtonPressed(object sender, EventArgs e)
        {
            string txt = GetLatestVersionText();
            
            if(txt != null)
            {
                string version = txt.Split('\n')[0];

                bool upToDate = version.Trim() == Program.Version;
                txt = txt.Trim();
                txt += "\n\n" + (upToDate ? "You are up to date!" : "Download this update from the Github page.");
                MessageBox.Show(txt, "Latest version info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR - Failed to contact server for latest info! Check your internet connection!", "Latest version info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetLatestVersionText()
        {
            const string URL = @"https://raw.githubusercontent.com/Epicguru/RimworldRender/master/RimworldRender/Version.txt";

            using (WebClient wc = new WebClient())
            {
                try
                {
                    string text = wc.DownloadString(URL);

                    return text.Trim();
                }
                catch (Exception e)
                {
                    Program.Log("Exception when downloading new version data from github.");
                    Program.Log($"Exception: {e.GetType().FullName} - {e.Message}");
                    Program.Log(e.StackTrace);
                    return null;
                }
            }               
        }

        private void GithubButtonPressed(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Epicguru/RimworldRender");
        }

        private void AboutButtonPressed(object sender, EventArgs e)
        {
            MessageBox.Show($"Rimworld Render by James Billy (Epicguru)\nVersion: {Program.Version} ({Program.VersionDate})\nThis open source tool creates a video file in .avi format from a folder of images. Designed to work with rimworld images created by the Progress Renderer mod.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
