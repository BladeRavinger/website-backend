import os
import sys
import subprocess
import shutil
import sys

## python .\SetupConfigs.py mongourl

sourcepath = ".\\src\\UKSFWebsite.api"
buildpath = sourcepath+".\\build_output"
path = "\\website-backend-config"
dllpath = ".\\UKSFWebsite.api.dll"

def startDotNetDll():
	subprocess.call(["dotnet", dllpath])

def publishDotNetProgram():
	subprocess.call(["dotnet", "publish", ".\\src\\UKSFWebsite.api\\", "-o", buildpath, "--framework", "netcoreapp1.0", "--runtime", sys.argv[1]])

def getGitConfigFolder():
	subprocess.call(["git", "clone", "https://github.com/uksf/website-backend-config.git", buildpath+path])

def clearOldBuild():
	if(os.path.isdir(buildpath)):
		shutil.rmtree(buildpath)

clearOldBuild()
publishDotNetProgram()
getGitConfigFolder()
os.chdir(buildpath)
startDotNetDll()