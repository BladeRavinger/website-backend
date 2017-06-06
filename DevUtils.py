import os
import sys
import subprocess
import json
import time
import select

sourcepath = "/src/UKSFWebsite.api"
buildpath = "./build_output"
path = "website-backend-config"
dllpath = "./UKSFWebsite.api.dll"

def doesGitFolderExist():
	return os.path.isdir(path)

def updateConfigs():
	os.chdir(path)
	subprocess.call(["git", "reset", "--hard", "HEAD"])
	subprocess.call(["git", "clean", "-f", "-d"])
	subprocess.call(["git", "pull"])
	
def insertGitConfigSource():
	subprocess.call(["git", "clone", "https://github.com/uksf/website-backend-config.git", path])

def clearOldBuild():
	if(os.path.isdir(buildpath)):
		shutil.rmtree(buildpath)