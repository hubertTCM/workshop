# download amc past paper from https://live.poshenloh.com/past-contests

import os
import urllib.request


def download_paper(url):
    html = urllib.request.urlopen(url).read()
    file_name = os.path.basename(urllib.parse.urlparse(url).path)
    with open("out/amc/"+file_name+".html", "wb") as text_file:
        text_file.write(html)


def main():
    """entry function"""
    amc8 = ['https://live.poshenloh.com/past-contests/amc8/2023',
            'https://live.poshenloh.com/past-contests/amc8/2022',
            'https://live.poshenloh.com/past-contests/amc8/2020',
            'https://live.poshenloh.com/past-contests/amc8/2019',
            'https://live.poshenloh.com/past-contests/amc8/2018',
            'https://live.poshenloh.com/past-contests/amc8/2017',
            'https://live.poshenloh.com/past-contests/amc8/2016',
            'https://live.poshenloh.com/past-contests/amc8/2015',
            'https://live.poshenloh.com/past-contests/amc8/2014',
            'https://live.poshenloh.com/past-contests/amc8/2013',
            'https://live.poshenloh.com/past-contests/amc8/2012',
            'https://live.poshenloh.com/past-contests/amc8/2011',
            'https://live.poshenloh.com/past-contests/amc8/2010',
            'https://live.poshenloh.com/past-contests/amc8/2009',
            'https://live.poshenloh.com/past-contests/amc8/2008',
            'https://live.poshenloh.com/past-contests/amc8/2007',
            'https://live.poshenloh.com/past-contests/amc8/2006',
            'https://live.poshenloh.com/past-contests/amc8/2005',
            'https://live.poshenloh.com/past-contests/amc8/2004',
            'https://live.poshenloh.com/past-contests/amc8/2003',
            'https://live.poshenloh.com/past-contests/amc8/2002',
            'https://live.poshenloh.com/past-contests/amc8/2001',
            'https://live.poshenloh.com/past-contests/amc8/2000',
            'https://live.poshenloh.com/past-contests/amc8/1999',
            'https://live.poshenloh.com/past-contests/amc8/1998',
            'https://live.poshenloh.com/past-contests/amc8/1997']

    download_paper(amc8[0])


if __name__ == '__main__':
    main()
