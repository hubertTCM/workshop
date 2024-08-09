
import os
import urllib.request
import urllib.parse


def download(url):
    '''download file from url'''

    # url = "http://photographs.500px.com/kyle/09-09-201315-47-571378756077.jpg"
    # a = urlparse(url)
    # print(a.path) # Output: /kyle/09-09-201315-47-571378756077.jpg
    # print(os.path.basename(a.path))  # Output: 09-09-201315-47-571378756077.jpg
    file_name = os.path.basename(urllib.parse.urlparse(url).path)
    urllib.request.urlretrieve(url, "out/math/"+file_name)


def main():
    """entry function"""
    # [...document.querySelectorAll("a")].filter(link => link.href.endsWith(".pdf")).map(link=>link.href)
    urls = ['https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2023.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2023.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2022.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2022.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2021.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2021.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2020.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2020.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2019.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2019.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2018.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2018.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2017.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2017.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2016.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2016.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2005.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2005.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/questions/Questions2004.pdf',
            'https://www.maths.otago.ac.nz/jmc/documents/solutions/Solutions2004.pdf']
    for url in urls:
        print(f"starting {url}")
        download(url)


# https://dev.to/jakewitcher/using-env-files-for-environment-variables-in-python-applications-55a1
if __name__ == "__main__":
    main()
