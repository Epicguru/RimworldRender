using Accord.Video.FFMPEG;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace RimworldRender
{
    static class Program
    {
        public static string Version { get; private set; }
        public static string VersionDate { get; private set; }
        public static string VersionDescription { get; private set; }

        public static VideoCodec Format = VideoCodec.Default;
        private static MainWindow window;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadVersionInfo();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(window = new MainWindow());
        }

        public static void LoadVersionInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "RimworldRender.Version.txt";
            string result = null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }

            string[] lines = result.Split('\n');
            Version = lines[0].Trim();
            VersionDate = lines[1].Trim();
            VersionDescription = string.Empty;
            for (int i = 2; i < lines.Length; i++)
            {
                VersionDescription += lines[i];
            }
        }

        public static void Log(string s)
        {
            Console.WriteLine(s ?? "null");
        }

        public static void SetStatus(string status)
        {
            window.statusLabel.Text = status;
        }

        public static void SetStatusSafe(string status)
        {
            window.statusLabel.Invoke((MethodInvoker)(() => window.statusLabel.Text = status));
        }

        public static void SetProgressSafe(float p)
        {
            window.ProgressBar.Invoke((MethodInvoker)(() => window.ProgressBar.Value = (int)Math.Round(p * 100f)));
        }

        public static void SetEstimatedTimeSafe(string s)
        {
            window.EstimatedTime.Invoke((MethodInvoker)(() => window.EstimatedTime.Text = "Estimated time: " + s));
        }

        public static void SetPreview(Bitmap b)
        {
            window.PictureBox.Invoke((MethodInvoker)(() =>
            {
                var box = window.PictureBox;
                if (box.Image != null)
                    box.Image.Dispose();
                box.Image = b.GetThumbnailImage(box.Width, box.Height, null, IntPtr.Zero);
            }));            
        }

        public static int GetBitrate()
        {
            return (int)Math.Round(GetBitrate(window.BitrateComboBox.SelectedIndex));
        }

        public static int GetFramesPerImage()
        {
            int imagesPerSecond = (int)window.ImagesPerSecondInput.Value;
            int calc = (int)window.FramerateInput.Value / imagesPerSecond;
            return calc <= 0 ? 1 : calc;
        }

        public static decimal GetBitrate(int index)
        {
            decimal value = window.BitrateInput.Value;
            decimal multiplier = (decimal)Math.Pow(1000, index);

            return value * multiplier;
        }
    }
}
