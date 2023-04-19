"""os module"""
import os
from PyPDF2 import PdfWriter, PdfReader
from dotenv import load_dotenv


def export_filenames(pdf_folder):
    "export the pdf files to order"
    pdf_files = [filename for filename in os.listdir(
        pdf_folder) if os.path.isfile(os.path.join(pdf_folder, filename))]
    with open("pdf_files.txt", "w", encoding="utf-8") as file_writer:
        list(map(lambda filename: file_writer.write(filename+os.linesep), pdf_files))


def merge_files(pdf_folder):
    "merge pdf to a single file"

    with open("pdf_files.txt", "r", encoding="utf-8") as file_reader:
        filenames = [line.rstrip()
                     for line in file_reader if len(line.rstrip()) > 0]
    pdf_writer = PdfWriter()
    for filename in filenames:
        pdf_reader = PdfReader(os.path.join(pdf_folder, filename))
        title = filename.removesuffix(".pdf").strip()
        pdf_writer.add_outline_item(title, len(pdf_writer.pages))
        list(map(pdf_writer.add_page, pdf_reader.pages))
    pdf_writer.write("out/1.姚系论文集.pdf")
    print(pdf_folder)


def remove_answer_pages():
    """answer page is in last, remove it from pdf file"""
    pdf_folder = os.getenv("PAPER_FOLDER")
    pdf_files = [filename for filename in os.listdir(
        pdf_folder) if os.path.isfile(os.path.join(pdf_folder, filename))]

    for filename in pdf_files:
        pdf_reader = PdfReader(os.path.join(pdf_folder, filename))
        pdf_writer = PdfWriter()
        list(map(pdf_writer.add_page, pdf_reader.pages[:-1]))
        pdf_writer.write("out/papers/"+filename)


def main():
    "entry function"
    load_dotenv()
    # pdf_folder = os.getenv("PDF_FOLDER")
    # export_filenames(pdf_folder)
    # merge_files(pdf_folder)
    remove_answer_pages()


if __name__ == '__main__':
    main()
    print("done")
