import os
import sys
import subprocess
import shutil
import sys

## python .\SetupConfigs.py mongourl

buildpath = ".\\build_output"
sourcepath = ".\\src\\UKSFWebsite.api"
path = "\\website-backend-config"
dllpath = buildpath + "\\UKSFWebsite.api.dll"

def startDotNetDll():
	subprocess.call(["dotnet", dllpath])

def publishDotNetProgram():
	subprocess.call(["dotnet", "build", ".\\src\\UKSFWebsite.api\\", "-o", buildpath, "--framework", "netcoreapp1.1", "--runtime", sys.argv[1]])

def getGitConfigFolder():
	subprocess.call(["git", "clone", "https://github.com/uksf/website-backend-config.git", buildpath+path])

def clearOldBuild():
	if(os.path.isdir(buildpath)):
		shutil.rmtree(buildpath)

clearOldBuild()
publishDotNetProgram()
getGitConfigFolder()
startDotNetDll()