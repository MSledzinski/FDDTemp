#Starting from Windows Server Core [1]
FROM microsoft/windowsservercore

# Install IIS Web Server [2]
RUN powershell -Command Add-WindowsFeature Web-Server

# Remove existing websites (and port bindings as well)
RUN powershell -Command "Remove-Item C:\inetpub\wwwroot\iisstart.*"

# hack for DNS cache bug
# https://github.com/docker/docker/issues/27499
RUN powershell -Command "set-itemproperty -path 'HKLM:\SYSTEM\CurrentControlSet\Services\Dnscache\Parameters' -Name ServerPriorityTimeLimit -Value 0 -Type DWord"

# Copy files
COPY ./out/ c:/inetpub/wwwroot

#  xcopy c:\build\WebApp\* c:\inetpub\wwwroot /s
# Expose port to access web site
EXPOSE 80

# Run blocking check
ENTRYPOINT ["powershell", ".\\wait_until_w3svc_done.ps1"]
