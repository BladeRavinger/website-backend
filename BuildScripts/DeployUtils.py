import os
import sys
import subprocess
import time
import select
import json

sourcepath = "/UKSFWebsite.api"
buildpath = "./build_output"
path = "website-backend-config"
dllpath = "./UKSFWebsite.api.dll"

def Deploy():
	import ovh
	import paramiko
	print("deploying")
	client = ovh.Client(
		endpoint='ovh-eu',               # Endpoint of API OVH Europe (List of available endpoints)
		application_key=os.environ['Application_Key'],    # Application Key
		application_secret=os.environ['Application_Secret'], # Application Secret
		consumer_key=os.environ['Consumer_Key'],       # Consumer Key
	)
	#gets all vps
	result = client.get('/vps')
	print(type(result))
	print(json.dumps(result, indent=4))
	#loop through all vps
	for vps in result:
		print('querying the following vps /vps/'+vps)
		#get information specific to the vps
		result = client.get('/vps/'+vps)
		if(result["displayName"] == "appvps" and getTagForBranch() == "master"):
			SSHandDeploy(str(result["name"]))
			
def SSHandDeploy(VPS_HOSTNAME):
	import ovh
	import paramiko
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
		
		runSSHCommand(client, "docker stop $(docker ps -aq)")
		runSSHCommand(client, "docker ps")
		
		runSSHCommand(client, "docker rm $(docker ps -aq)")
		runSSHCommand(client, "docker rmi $(docker images -q)")
		runSSHCommand(client, "docker images -a")
		runSSHCommand(client, "docker ps -a")
		
		runSSHCommand(client, "docker login -u " + os.environ['DOCKER_USERNAME'] + " -p " + os.environ['DOCKER_PASSWORD'])
		
		runSSHCommand(client, "docker pull frostebite/website-backend:"+getTagForBranch())
		runSSHCommand(client, "docker images -a")
		runSSHCommand(client, "docker ps -a")
		
		stdin, stdout, stderr = client.exec_command("sudo docker run -p 5000:5000 -e DbConUrl='"+os.environ['DbConUrl']+"' frostebite/website-backend:"+getTagForBranch())
		
		
		
	finally:
		client.close()
		
def runSSHCommand(client, command):
	import ovh
	import paramiko
	stdin, stdout, stderr = client.exec_command("sudo "+command)
	
	while not stdout.channel.exit_status_ready():
		# Only print data if there is data to read in the channel
		if stdout.channel.recv_ready():
			rl, wl, xl = select.select([stdout.channel], [], [], 0.0)
			if len(rl) > 0:
				# Print data from stdout
				print(stdout.channel.recv(1024))
				
def getTagForBranch():
	import ovh
	import paramiko
	tag = "dev"
	if(os.environ['TRAVIS_PULL_REQUEST_BRANCH'] == ""):
		tag = os.environ['TRAVIS_BRANCH']
		tag = tag.replace("/", "")
	return tag