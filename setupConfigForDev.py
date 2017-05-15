import os
import sys
import subprocess

## python .\SetupConfigs.py mongourl

path = "./src/UKSFWebsite.api/website-backend-config"

def getGitConfigFolder():
	subprocess.call(["git", "clone", "https://github.com/uksf/website-backend-config.git", path])

def doesGitFolderExist():
	return os.path.isdir(path)

def updateConfigs():
	os.chdir(path)
	subprocess.call(["git", "reset", "--hard", "HEAD"])
	subprocess.call(["git", "clean", "-f", "-d"])
	subprocess.call(["git", "pull"])
	##
	
if(doesGitFolderExist()):
	updateConfigs()
else:
	getGitConfigFolder()