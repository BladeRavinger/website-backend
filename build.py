import subprocess
import sys
import os

sourcepath = "/src/UKSFWebsite.api/"
buildpath = "./build_output"
path = "/website-backend-config"
dllpath = "./UKSFWebsite.api.dll"

print("Build script starting in path - " + os.getcwd())

subprocess.call(["dotnet", "publish", os.getcwd() + sourcepath, "-o", buildpath, "--framework", "netcoreapp1.0", "--runtime", sys.argv[1]])