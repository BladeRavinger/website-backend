import os
import sys
import subprocess

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
	try:
	   grepOut = subprocess.check_output(["sudo", os.getcwd()+"/Deploy.sh"])                      
	except subprocess.CalledProcessError as grepexc: 
		print(grepexc.returncode)
		print(grepexc.output)
		print(os.getcwd())
		sys.exit(grepexc.returncode)
	#subprocess.call(["docker", "build", "frostebite/website-backend:dev"])
	#subprocess.call(["docker", "push", "frostebite/website-backend:dev"])
	#subprocess.call(["docker", "login", "frostebite/website-backend:dev"])