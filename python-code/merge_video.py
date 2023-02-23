import os
from moviepy.editor import *
from natsort import natsorted
from dotenv import load_dotenv

load_dotenv()

# https://stackoverflow.com/questions/56920546/combine-mp4-files-by-order-based-on-number-from-filenames-in-python


def merge_video(folder_full_path):
    L = []

    for root, _, files in os.walk(folder_full_path):
        # files.sort()
        files = natsorted(files)
        print(root)
        for file in files:
            extension = os.path.splitext(file)[1]
            if extension == '.mp4':
                filePath = os.path.join(root, file)
                video = VideoFileClip(filePath)
                L.append(video)

        output_video_file = os.path.join(root + ".mp4")
        output_audio_file = os.path.join(root + ".mp3")
        final_clip = concatenate_videoclips(L)
        final_clip.write_videofile(
            output_video_file, fps=24, remove_temp=False, temp_audiofile=output_audio_file)
        print(output_video_file)


# https://dev.to/jakewitcher/using-env-files-for-environment-variables-in-python-applications-55a1
if __name__ == "__main__":
    video_folder = os.getenv('VIDEO_FOLDER')

    for root, dirs, _ in os.walk(video_folder):
        for dir in dirs:
            merge_video(os.path.join(root, dir))
