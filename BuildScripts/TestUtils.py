import os
import sys
import subprocess
import json

def runTests():
	print("running tests")
	subprocess.call(["dotnet", "restore"])

def runReport():
	print("running reports")
	openCoverPath = sys.argv[2];
	reportGeneratorPath = sys.argv[3];
	subprocess.call([sys.argv[2]])
	subprocess.call([sys.argv[3]])