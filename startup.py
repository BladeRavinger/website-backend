import subprocess

sourcepath = ".\\src\\UKSFWebsite.api"
buildpath = ".\\build_output"
path = "\\website-backend-config"
dllpath = ".\\UKSFWebsite.api.dll"

subprocess.call(["dotnet", dllpath])