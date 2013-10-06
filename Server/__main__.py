import urllib.request
import sys
import re
import json
import sqlite3
import getopt


# =============== Constantes ===============
CONFIG_FILE = "server.conf"
CL_OPTIONS = "l"
CL_FULL_OPTIONS = []


# =============== Load Conf & DB ===============
def load_conf():
	try:
		config_file = open(CONFIG_FILE, "r")
	except IOError:
		print("No config file... ")
		config_file = open(CONFIG_FILE, 'w+')
		config_file.write("""{
								"base": "list.db"
							 }""")
		config_file.seek(0)
		print("	{} created.".format(CONFIG_FILE))

	config = json.loads(config_file.read())

	if(not "base" in config):
		print("No database configured in {} ... Exiting.".format(CONFIG_FILE))
		exit()

	entries_db = sqlite3.connect(config['base'])

"""
def search():
	f = urllib.request.urlopen("http://www.animetake.com/?s=shingek")

	reEpisode = re.compile(b'<a href="(.+?)" title.+?>.*?Shingeki\sno\sKyojin\s.*?Episode\s+23.*?</a>')
	result = reEpisode.search(f.read(30000))
	if(result):
		print(result.group(1))
	else:
		print("Pas sorti ")
"""

def usage():
	print("List of options:")
	print("	-l 	Display all tracked medias.")

def main():
	load_conf()

	try:
		opts, args = getopt.getopt(sys.argv[1:], CL_OPTIONS, CL_FULL_OPTIONS)
	except getopt.GetoptError as err:
		print(err)
		usage()
		exit()

	if(opts == []):
		usage()

	for o, a in opts:
		if o == "-l":
			print("Voici la liste !")

if __name__ == '__main__':
	main()