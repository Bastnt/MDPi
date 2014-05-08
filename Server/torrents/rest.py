import cherrypy
import sqlite3

TORRENT_DB = 'torrents.db'
TABLE_DB = 'list'

class Root:
	@cherrypy.expose
	def index(self):
		return "HOME"
	
	@cherrypy.expose
	@cherrypy.tools.json_out()
	def torrent(self, id=None):
		db = sqlite3.connect(TORRENT_DB)
		req = "select * from {}".format(TABLE_DB)
		if id:
			req += " where id={}".format(int(id))
		res = db.execute(req)
		if res:
			return [x for x in res]
		else:
			return {}

root = Root()

conf = {'global':{ 
			'server.socket_host':'0.0.0.0',
			'server.socket_port':8000
		},
	}

cherrypy.quickstart(root, '/', conf)
