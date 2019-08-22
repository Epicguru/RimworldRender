﻿using AForge.Video.FFMPEG;
using System;
using System.Drawing.Drawing2D;
using System.IO;
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

            Program.Log($"Starting render of all {ImagePaths.Length} files in {ImageFolderDir}");
            Program.Log($"Resolution: {r.Width}x{r.Height}, Codec: {r.Codec}, Bitrate: {r.Bitrate}");

            r.Done += () =>
            {
                startRenderButton.Invoke((MethodInvoker)(() => { startRenderButton.Enabled = true; }));
                Program.SetStatusSafe("Done!");
                Rendering = false;
                Program.SetProgressSafe(0);
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

            ImagePaths = Directory.GetFiles(ImageFolderDir, "*.png", SearchOption.TopDirectoryOnly);

            if(ImagePaths.Length < 2)
            {
                MessageBox.Show($"The folder must contain at least two images to be rendered. Found {ImagePaths.Length}.", "Not enough images", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                ImageFolderDir = null;
                ImagePaths = null;
                return;
            }

            Program.Log($"Found {ImagePaths.Length} image files.");

            Program.SetStatus($"Ready: {ImagePaths.Length} images selected.");
            startRenderButton.Enabled = true;
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
    }
}