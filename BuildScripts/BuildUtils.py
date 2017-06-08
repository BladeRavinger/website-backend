import os
import sys
import subprocess
import json

sourcepath = "/src/UKSFWebsite.api"
buildpath = "./build_output"
testssourcepath = "/UKSFWebsite.api.tests"
testsbuildpath = "./build_output_tests"
path = "website-backend-config"
dllpath = "./UKSFWebsite.api.dll"

def clearOldBuild():
	if(os.path.isdir(buildpath)):
		shutil.rmtree(buildpath)
		
def dotNetRestor():
	subprocess.call(["dotnet", "restore"])
	
def tryPublish():
	try:
	   grepOut = subprocess.check_output(["dotnet", "publish", os.getcwd() + sourcepath, "-o", buildpath, "--framework", "netcoreapp1.0", "--runtime", sys.argv[2]])                      
	except subprocess.CalledProcessError as grepexc: 
		print(grepexc.returncode)
		print(grepexc.output)
		sys.exit(grepexc.returncode)
	
def startDotNetDll():
	subprocess.call(["dotnet", dllpath])
	
def buildDockerImage():
	tag = getTagForBranch()
	
	if(os.environ['TRAVIS_PULL_REQUEST_BRANCH'] == ""):
		tag = os.environ['TRAVIS_BRANCH']
		tag = tag.replace("/", "")
		
	print("making a dockerimage with name "+tag)
	
	try:
	   grepOut = subprocess.check_output(["sudo", "docker", "build", ".", "--tag", "frostebite/website-backend:"+tag])                      
	except subprocess.CalledProcessError as grepexc: 
		print(grepexc.returncode)
		print(grepexc.output)
		print(os.getcwd())
		sys.exit(grepexc.returncode)
	
	if(os.environ['TRAVIS_PULL_REQUEST_BRANCH'] == ""):
		subprocess.call(["docker", "login", "-u", os.environ['DOCKER_USERNAME'], "-p", os.environ['DOCKER_PASSWORD']])
		subprocess.call(["docker", "push", "frostebite/website-backend:"+tag])

def getTagForBranch():
	tag = "dev"
	if(os.environ['TRAVIS_PULL_REQUEST_BRANCH'] == ""):
		tag = os.environ['TRAVIS_BRANCH']
		tag = tag.replace("/", "")
	return tag