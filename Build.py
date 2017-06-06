from Utils import *
import os
import sys

if(sys.argv[1] == "--noRebuild"):
	os.chdir(buildpath)
	startDotNetDll()
elif(sys.argv[1] == "--onlyBuild"):
	dotNetRestor()
	tryPublish()
elif(sys.argv[1] == "--Docker"):
	buildDockerImage()
elif(sys.argv[1] == "--buildThenRun"):
	clearOldBuild()
	dotNetRestor()
	publishDotNetProgram()
	os.chdir(buildpath)
	startDotNetDll()
elif(sys.argv[1] == "--Deploy"):
	Deploy()