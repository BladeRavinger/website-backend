from Utils import *
import os
import sys

if(sys.argv[1] == "--noRebuild"):
	os.chdir(buildpath)
	startDotNetDll()
elif(sys.argv[1] == "--onlyBuild"):
	dotNetRestor()
	tryPublish()
	insertGitConfigPublish()
elif(sys.argv[1] == "--buildThenRun"):
	clearOldBuild()
	dotNetRestor()
	publishDotNetProgram()
	insertGitConfigPublish()
	os.chdir(buildpath)
	startDotNetDll()
