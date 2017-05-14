import os
import sys
import subprocess

## python .\SetupConfigs.py mongourl

buildpath = ".\\build_output"
sourcepath = ".\\src\\UKSFWebsite.api"
path = "\\website-backend-config"
dllpath = buildpath + "\\UKSFWebsite.api.dll"

def startDotNetDll():
	subprocess.call(["dotnet", dllpath])

def publishDotNetProgram():
	subprocess.call(["dotnet", "publish", ".\\src\\UKSFWebsite.api\\", "-o", buildpath])

def getGitConfigFolder():
	subprocess.call(["git", "clone", "https://github.com/uksf/website-backend-config.git", buildpath+path])

publishDotNetProgram()
getGitConfigFolder()
startDotNetDll()