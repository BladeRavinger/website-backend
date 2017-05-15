import subprocess

sourcepath = ".\\src\\UKSFWebsite.api"
buildpath = ".\\build_output"
path = "\\website-backend-config"
dllpath = ".\\UKSFWebsite.api.dll"

subprocess.call(["dotnet", "publish", sourcepath, "-o", buildpath, "--framework", "netcoreapp1.0", "--runtime", sys.argv[1]])