# How to start

###############################################
# Windows Server 2016 (CTP3+)

# Ensure system updates installed

# Install OneGet provider for PS
Install-Module -Name DockerMsftProvider -Repository PSGallery -Force

# Install Docker module
Install-Package -Name docker -ProviderName DockerMsftProvider

# Restart
Restart-Computer -Force


###############################################
# Windows 10 (Anniversary update) (Pro+)

# Ensure system updates installed

# Enable containers feature
Enable-WindowsOptionalFeature -Online -FeatureName containers -All

# Enable Hyper-V as it is only possible isolation mode
Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All

#Restart
Restart-Computer -Force

# Download docker 
Invoke-WebRequest "https://master.dockerproject.org/windows/amd64/docker-1.13.0-dev.zip" -OutFile "$env:TEMP\docker-1.13.0-dev.zip" -UseBasicParsing

# Expand and install
Expand-Archive -Path "$env:TEMP\docker-1.13.0-dev.zip" -DestinationPath $env:ProgramFiles
$env:path += ";c:\program files\docker"
[Environment]::SetEnvironmentVariable("Path", $env:Path + ";C:\Program Files\Docker", [EnvironmentVariableTarget]::Machine)

# Start service
dockerd --register-service
Start-Service Docker


##################################################
# MS DockerHub repo: https://hub.docker.com/u/microsoft/
docker pull microsoft/windowsservercore

docker images
# run two containers - one server nano, other one windowsservercore

# on container
Get-Process | Measure
Get-Service | Measure

# do registry change
# do file change

Get-ComputeProcess 

# run application example