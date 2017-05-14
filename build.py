import subprocess

subprocess.call(["dotnet", "publish", ".\\src\\UKSFWebsite.api\\", "-o", ".\\build_output"])