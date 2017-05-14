import os
import sys
import subprocess

## python .\SetupConfigs.py mongourl

path = "./src/UKSFWebsite.api/website-backend-config"
files = os.listdir(path)

def handleContents(content, file):
	subprocess.call(["git", "update-index", "--assume-unchanged", path+"/"+file])
	content = content.replace("$connectionUrl$", sys.argv[1])
	open(path+"/"+file, "w").write(content)
	return content

def handleFile(file):
	print file
	config = open(path+"/"+file,"r").read()
	config = handleContents(config, file)
	print config
	
for file in files:
	handleFile(file)

def startDotNetDll():
	subprocess.call(["dotnet", ".\\build_output\UKSFWebsite.api.dll"])

def publishDotNetProgram():
	subprocess.call(["dotnet", "publish", ".\\src\\UKSFWebsite.api\\", "-o", ".\\build_output"])