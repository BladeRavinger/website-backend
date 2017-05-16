from Utils import *
	
if(doesGitFolderExist()):
	updateConfigs()
else:
	insertGitConfigSource()