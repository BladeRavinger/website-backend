import os
import sys
import subprocess
import json
import ovh
import paramiko
import time
import select

sourcepath = "/src/UKSFWebsite.api"
buildpath = "./build_output"
path = "website-backend-config"
dllpath = "./UKSFWebsite.api.dll"

def doesGitFolderExist():
	return os.path.isdir(path)

def updateConfigs():
	os.chdir(path)
	subprocess.call(["git", "reset", "--hard", "HEAD"])
	subprocess.call(["git", "clean", "-f", "-d"])
	subprocess.call(["git", "pull"])
	
def insertGitConfigSource():
	subprocess.call(["git", "clone", "https://github.com/uksf/website-backend-config.git", path])

def clearOldBuild():
	if(os.path.isdir(buildpath)):
		shutil.rmtree(buildpath)
		
def dotNetRestor():
	subprocess.call(["dotnet", "restore"])
	
def tryPublish():
	try:
	   grepOut = subprocess.check_output(["dotnet", "publish", os.getcwd() + sourcepath, "-o", buildpath, "--framework", "netcoreapp1.0", "--runtime", sys.argv[2]])                      
	except subprocess.CalledProcessError as grepexc: 
		print(grepexc.returncode)
		print(grepexc.output)
		sys.exit(grepexc.returncode)
	
def startDotNetDll():
	subprocess.call(["dotnet", dllpath])
	
def buildDockerImage():
	tag = "dev"
	
	if(os.environ['TRAVIS_PULL_REQUEST_BRANCH'] == ""):
		tag = os.environ['TRAVIS_BRANCH']
		tag = tag.replace("/", "")
		
	print "making a dockerimage with name "+tag
	
	try:
	   grepOut = subprocess.check_output(["sudo", "docker", "build", ".", "--tag", "frostebite/website-backend:"+tag])                      
	except subprocess.CalledProcessError as grepexc: 
		print(grepexc.returncode)
		print(grepexc.output)
		print(os.getcwd())
		sys.exit(grepexc.returncode)
	
	if(os.environ['TRAVIS_PULL_REQUEST_BRANCH'] == ""):
		subprocess.call(["docker", "login", "-u", os.environ['DOCKER_USERNAME'], "-p", os.environ['DOCKER_PASSWORD']])
		subprocess.call(["docker", "push", "frostebite/website-backend:"+tag])
		
def Deploy():
	print "deploying"
	client = ovh.Client(
		endpoint='ovh-eu',               # Endpoint of API OVH Europe (List of available endpoints)
		application_key=os.environ['Application_Key'],    # Application Key
		application_secret=os.environ['Application_Secret'], # Application Secret
		consumer_key=os.environ['Consumer_Key'],       # Consumer Key
	)
	#gets all vps
	result = client.get('/vps')
	print type(result)
	print json.dumps(result, indent=4)
	#loop through all vps
	for vps in result:
		print 'querying the following vps /vps/'+vps
		#get information specific to the vps
		result = client.get('/vps/'+vps)
		if(result["displayName"] == "appvps"):
			SSHandDeploy(str(result["name"]))
			
def SSHandDeploy(VPS_HOSTNAME):
	hostname = VPS_HOSTNAME
	password = os.environ['VPS_PASSWORD']

	username = "root"
	port = 22

	try:
		client = paramiko.SSHClient()
		client.set_missing_host_key_policy(paramiko.AutoAddPolicy())
		client.load_system_host_keys()
		
		client.connect(hostname, port=port, username=username, password=password)
		runSSHCommand(client, "cd ..")
		runSSHCommand(client, "ls")
		runSSHCommand(client, "docker -v")
		runSSHCommand(client, "docker images -a")
		runSSHCommand(client, "docker ps -a")
		
	finally:
		client.close()
		
def runSSHCommand(client, command):
	stdin, stdout, stderr = client.exec_command("sudo "+command)
	
	while not stdout.channel.exit_status_ready():
		# Only print data if there is data to read in the channel
		if stdout.channel.recv_ready():
			rl, wl, xl = select.select([stdout.channel], [], [], 0.0)
			if len(rl) > 0:
				# Print data from stdout
				print stdout.channel.recv(1024)