"""Module for iterating directories etc."""
import os
from moviepy.editor import VideoFileClip, concatenate_videoclips
from natsort import natsorted
from dotenv import load_dotenv

load_dotenv()

# https://stackoverflow.com/questions/56920546/combine-mp4-files-by-order-based-on-number-from-filenames-in-python


def merge_video_debug(folder_full_path):
    """find the broken video file"""

    for root, _, files in os.walk(folder_full_path):
        # files.sort()
        files = natsorted(files)
        print(root)
        for file in files:
            file_path = os.path.join(root, file)
            video = VideoFileClip(file_path)

            # output_video_file = os.path.join(root+"_" + file+".mp4")
            output_audio_file = os.path.join(root+"_" + file+".mp3")
            print("start:"+file_path)
            video.audio.write_audiofile(output_audio_file)
            print("     end:"+file_path)

            # final_clip = concatenate_videoclips([video])

            # print("start:"+output_audio_file)
            # final_clip.write_videofile(
            #     output_video_file, fps=24, remove_temp=False, temp_audiofile=output_audio_file)
            # print("     end:"+output_audio_file)


def merge_video(folder_full_path):
    """merge videos to a single file"""
    videos = []

    for root, _, files in os.walk(folder_full_path):
        # files.sort()
        files = natsorted(files)
        print(root)
        for file in files:
            file_path = os.path.join(root, file)
            video = VideoFileClip(file_path)
            videos.append(video)

        # min_height = min([c.h for c in videos])
        # min_width = min([c.w for c in videos])
        # videos = [c.resize(newsize=(min_width, min_height)) for c in videos]

        output_video_file = os.path.join(root + ".mp4")
        output_audio_file = os.path.join(root + ".mp3")
        final_clip = concatenate_videoclips(videos)
        final_clip.write_videofile(
            output_video_file, fps=24, remove_temp=False, temp_audiofile=output_audio_file)
        print(output_video_file)


def main():
    """entry function"""
    video_folder = os.getenv('VIDEO_FOLDER')

    video_debug = os.getenv('VIDEO_DEBUG')
    for root, dirs, _ in os.walk(video_folder):
        for sub_folder in dirs:
            if video_debug == 'True':
                merge_video_debug(os.path.join(root, sub_folder))
            else:
                merge_video(os.path.join(root, sub_folder))


# https://dev.to/jakewitcher/using-env-files-for-environment-variables-in-python-applications-55a1
if __name__ == "__main__":
    main()
