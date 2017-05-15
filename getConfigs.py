import os
import sys
import subprocess
import shutil
import sys

subprocess.call(["git", "clone", "https://github.com/uksf/website-backend-config.git", sys.argv(1)])