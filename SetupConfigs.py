import os
import sys
import subprocess

## python .\SetupConfigs.py mongourl

path = "./src/UKSFWebsite.api/appsettings.json"

##ignore changes
##subprocess.call(["git", "update-index", "--assume-unchanged", path])

config = open(path,"r").read()
config = config.replace("$connectionUrl$", sys.argv[1])

open(path, "w").write(config)

	

