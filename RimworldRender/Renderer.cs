using AForge.Video.FFMPEG;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace RimworldRender
{
    public class Renderer
    {
        public string[] Images { get; }
        public string OutputDir { get; }

        public int FrameRate = 24;
        public int FramesPerImage = 24 / 4;
        public int Width = 1920, Height = 1080;
        public int Bitrate = 1000 * 1000;
        public VideoCodec Codec = VideoCodec.MPEG4;
        public bool RenderPreview = false;

        public Action Done;

        private Thread thread;

        public Renderer(string output, string[] images)
        {
            this.Images = images ?? throw new ArgumentNullException("images", "Images array cannot be null.");
            this.OutputDir = output ?? throw new ArgumentNullException("output", "Output path cannot be null.");
        }

        public void StartRender()
        {
            if (thread != null)
                return;

            thread = new Thread(RunRender);
            thread.Name = "Render Thread";
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
        }

        private void RunRender()
        {
            Stopwatch watch = new Stopwatch();
            using (var writer = new VideoFileWriter())
            {
                writer.Open(OutputDir, Width, Height, FrameRate, Codec, Bitrate);

                for (int i = 0; i < Images.Length; i++)
                {
                    watch.Restart();

                    string path = Images[i];
                    string name = new FileInfo(path).Name;

                    Program.SetStatusSafe($"Loading {name}...");
                    Bitmap bitmap = new Bitmap(new FileStream(path, FileMode.Open));

                    Program.SetStatusSafe($"Resizing {name}...");
                    Bitmap frame;
                    if(bitmap.Width == Width && bitmap.Height == Height)
                    {
                        frame = bitmap;
                    }
                    else
                    {
                        frame = ResizeAndCenter(bitmap);
                        bitmap.Dispose();
                    }

                    if (RenderPreview)
                    {
                        Program.SetStatusSafe("Rending preview...");
                        Program.SetPreview(frame);
                    }

                    for (int j = 0; j < FramesPerImage; j++)
                    {
                        Program.SetStatusSafe($"Writing {name}: Frame {j + 1} of {FramesPerImage}.");
                        writer.WriteVideoFrame(frame);
                    }

                    frame.Dispose();

                    Program.SetProgressSafe((float)(i + 1) / Images.Length);

                    System.GC.Collect();

                    watch.Stop();
                    var elapsed = watch.Elapsed;
                    int remaing = Images.Length - (i + 1);
                    TimeSpan sum = TimeSpan.Zero;
                    for (int j = 0; j < remaing; j++)
                    {
                        sum = sum.Add(elapsed);
                    }

                    Program.SetEstimatedTimeSafe(sum.ToString(@"hh\:mm\:ss"));
                }

                writer.Close();
            }

            Done?.Invoke();
        }

        private Bitmap ResizeAndCenter(Bitmap original)
        {
            Bitmap resized = new Bitmap(Width, Height);

            var (w, h, ox, oy) = ScaleToFit(original.Width, original.Height, Width, Height);

            using (Graphics g = Graphics.FromImage(resized))
            {
                g.Clear(Color.Black);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, new Rectangle(ox, oy, w, h), new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);
            }

            return resized;
        }

        private (int width, int height, int offX, int offY) ScaleToFit(int width, int height, int containerWidth, int containerHeight)
        {
            int fw = 0;
            int fh = 0;
            int ox = 0;
            int oy = 0;

            bool containerWide = containerWidth >= containerHeight;
            bool imageWide = width >= height;
            int containerMin = containerWide ? containerWidth : containerHeight;

            float wScale = ScaleToFit(width, containerWidth);
            float hScale = ScaleToFit(height, containerHeight);

            // First fit x.
            fw = containerWidth;
            fh = round(height * wScale);
            ox = 0;
            oy = (containerHeight - fh) / 2;

            // Check if y goes out of bounds, and scale to y if it does.
            if(oy < 0)
            {
                fw = round(width * hScale);
                fh = containerHeight;
                ox = (containerWidth - fw) / 2;
                oy = 0;
            }

            return (fw, fh, ox, oy);

            int round(float x)
            {
                return (int)Math.Ceiling(x);
            }
        }

        private float ScaleToFit(int start, int end)
        {
            float scale = (float)end / start;
            return scale;
        }
    }
}
