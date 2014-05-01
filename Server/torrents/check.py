#!/usr/bin/python
#-*- coding: utf-8 -*-
import sqlite3
import re
import urllib.request
import os
import getopt
import sys

WEBSITE = "http://www.animetake.com/"
DL_LINK = "http://www.nyaa.se/?page=download&tid={}"
TORRENT_FOLDER = 'watch/'
TORRENT_DB = 'torrents.db'
TABLE_DB = "list"
CHECK_ONLY = False

def main():
	load_options()

	web_page = urllib.request.urlopen(WEBSITE).read().decode("utf8")
	db = sqlite3.connect(TORRENT_DB)
	animes = db.execute("select * from {}".format(TABLE_DB))

	for anime in animes:
		torrent_link = re.search(anime[Anime.hit_regex], web_page)
		print("--------------------------------------------------------")
		print(anime[Anime.name])
		if torrent_link == None:
			print("Did not match.")
			continue
		if torrent_link.group(1) == str(anime[Anime.count]):
			print("Nothing new ({}).".format(anime[Anime.count]))
			continue

		print("New torrent ({}).".format(torrent_link.group(1)))
		download_page = str(urllib.request.urlopen(torrent_link.group(0)).read())
		torrent_id = re.search(anime[Anime.dl_regex], download_page)
		if torrent_id == None:
			print("Did not match download link.")
			continue
		print("Torrent ID:",torrent_id.group(1))
		my_link = DL_LINK.format(torrent_id.group(1))
		to_exec = "wget --no-verbose -O '{}{}.{}.torrent' '{}'".format(TORRENT_FOLDER, anime[Anime.name], anime[Anime.count]+1, my_link)
		if CHECK_ONLY:
			print(to_exec)
			continue
		else:
			if os.system(to_exec) != 0:
				print("Error in downloading the torrent.")
				continue
		db.execute("update list set count={} where id={}".format(anime[Anime.count]+1, anime[Anime.id]))
		db.commit()
		print("Torrent refreshed.")

def load_options():
	try:
		opts, args = getopt.getopt(sys.argv[1:], "hc")
	except getopt.GetoptError as err:
		print(err)
		usage()

	for o, a in opts:
		if o == "-h":
			usage()
		if o == "-c":
			global CHECK_ONLY
			CHECK_ONLY = True

def usage():
	print("Bastnt's animes checker\n")
	print("Usage: {} [OPTIONS]".format(sys.argv[0]))
	print(" -h    Display this help")
	print(" -c    Check only (does not download the torrent files)")
	exit()

class Anime:
	id=0
	name=1
	hit_regex=2
	dl_regex=3
	count=4

if __name__ == "__main__":
	main()
