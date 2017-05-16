from Utils import *
import os
import sys

if(sys.argv(1) == "--noRebuild"):
	os.chdir(buildpath)
	startDotNetDll()
elif(sys.argv(1) == "--onlyBuild"):
	dotNetRestor()
	tryPublish()
else:
	clearOldBuild()
	dotNetRestor()
	publishDotNetProgram()
	insertGitConfigPublish()
	os.chdir(buildpath)
	startDotNetDll()