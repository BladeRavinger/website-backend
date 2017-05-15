import subprocess
import sys
import os

sourcepath = "/src/UKSFWebsite.api/"
buildpath = "./build_output"
path = "/website-backend-config"
dllpath = "./UKSFWebsite.api.dll"

print("Build script starting in path - " + os.getcwd())


try:
   grepOut = subprocess.check_output(["dotnet", "publish", os.getcwd() + sourcepath, "-o", buildpath, "--framework", "netcoreapp1.0", "--runtime", sys.argv[1]])                      
except subprocess.CalledProcessError as grepexc: 
	print(grepexc.returncode)
	print(grepexc.output)
	sys.exit(grepexc.returncode)