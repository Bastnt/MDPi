import urllib.request
import sys
import re

f = urllib.request.urlopen("http://www.animetake.com/?s=shingek")

reEpisode = re.compile(b'<a href="(.+?)" title.+?>.*?Shingeki\sno\sKyojin\s.*?Episode\s+23.*?</a>')
result = reEpisode.search(f.read(30000))
if(result):
	print(result.group(1))
else:
	print("Pas sorti ")
	
#sys.stdin.read(1)