# Rimworld Render
A tool designed to join create a video file from screenshots or map renders created by the Rimworld mod Progress Renderer [(Steam)](https://steamcommunity.com/sharedfiles/filedetails/?id=1438693028) [(Github)](https://github.com/Lanilor/Progress-Renderer) created by Lanilor.

**Important** Only runs on 64-bit Windows computers!

## Why use this
The Progress Renderer mod can create really high resolution screenshots that are very hard to manipulate in video editing software. Creating a video of all those screenshots to create a timelapse is commonly done using FFMPEG, but a problem with that is that all screenshots have to be exactly the same resolution. This is a big problem if you want to resize the screenshot area in-game. FFMPEG is also a command line tool that not all Rimworld players will be comfortable using.

Using this tool you get a simple but functional user interface that allows you to adjust many settings to create the ideal video file from as many images as you want, and the input images can be in varying resolutions.

## How to use
Download the latest release from [the releases page](https://github.com/Epicguru/RimworldRender/releases).
It will be a zip file, so extract it by doing _right click > Extract all... > Extract_.
Opening the folder that you just extracted to, you should see the following:
![Folder](https://raw.githubusercontent.com/Epicguru/RimworldRender/master/Documentation/Images/Folder.png)

Simply double click on _Run Rimworld Render.exe_ to run the tool. **If the program does not open, check that you are using a 64-bit Windows computer!**

### The user interface
![UI](https://raw.githubusercontent.com/Epicguru/RimworldRender/master/Documentation/Images/UI.png)

On the **left** are the settings. These settings are by default optimized for a 1080p video. Each setting is explained in more detail later on.

In the **center** is the 'working area'. It will display more information once the video is being rendered.

On the **right** are buttons that display help or other information.

### Create a video!
Using the default settings, create a video by doing the following:
1. Press the **Select folder** button in the top-center.
2. Navigate to the folder that contains all your Rimworld images. Where this folder is depends on you mod settings.
3. With the folder now chosen, the '*Waiting for folder...*' text should have changed to *Ready: x images selected*.
4. Press the Start Render button and wait!

Once the video is done rendering (you can see the progress in the bar, and see an estimated remaining time), the folder containing the video file will automatically open.
This video file will be located **next to** the images folder, and will be called *Output.avi*. You can now use this video in any video editing software.

## Settings
#### Resolution
The horizontal and vertical size, in pixels, that the output video file will have. If all of your input images are the same resolution, it sometimes makes sense to set the resolution to the same as the image's resolution. This makes rendering faster.
#### Sampling
This is the algorithm used to resize the input images so that they fit into the video frame. **I highly recommend leaving it on HighQualityBicubic**.
#### Codec
This is the algorithm used to encode the video file, and can be thought of as similar to file format. Again, **I highly recommend leaving it on MPEG4**.
*NOTE: You can rename the ouput video file from Output.avi to Output.mp4 and it will work just fine.*
#### Bitrate
The bitrate that the output video uses. A full explaination of this is beyond the scope of this documentation, but **if the ouput video ever looks choppy, or has compression artifacts increase this value**. In general, higher resolutions and framerates will require a higher bitrate. 20 mbps is a good value for everything from 1080p video to 4k video.
#### Famerate
The number of frames displayed per second. **Should always be the same as or higher than the Images per second value**. The only reason why framerate and images per second are two seperate settings is because some video players don't work properly when videos have very low framerates.
#### Images per second
The number of input images that will be played per second. This is completely up to you, and is not a technical setting. For example, if you stored one image per Rimworld day then you could have one second of video equal 10 Rimworld days by setting this value to 10. Generally you will want to set the Framerate to the same value as the Images per second.

## Plans and TODO
- [ ] Support Gif creation.
- [ ] Create 32 bit version. (Would only allow for 2GB of RAM tho...)
- [ ] Increase stability, automatically record and send crash reports.
- [ ] Turn into a Rimworld mod?
- [ ] Make command line inputs work, for automation. 

## Contribution
Feel welcome to fork this Github repo and make you own changes to the program. You should compile using Visual Studio 2017 or 2019. The dependencies are all handled by NuGet.
It would be great if you could submit those changes as a pull request so that I can merge them into this project for everyone to enjoy.
I'm a 17 year old Rimworld and programming enthusiast, so as much as I'd like to I probably won't be able to update this project very frequently once I get back into my A Level exams, so all contributions are very appreciated.

