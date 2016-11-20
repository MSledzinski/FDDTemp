# Starting from Windows Server Core
FROM microsoft/windowsservercore

# hack for DNS cache bug
# https://github.com/docker/docker/issues/27499
RUN powershell -Command "set-itemproperty -path 'HKLM:\SYSTEM\CurrentControlSet\Services\Dnscache\Parameters' -Name ServerPriorityTimeLimit -Value 0 -Type DWord"

# Remove existing websites (and port bindings as well)
RUN powershell -Command "Get-WebSite | Remove-WebSite"

# Copy files
RUN md c:\Service
WORKDIR c:/Service
COPY ./NotesWebApi/bin/Release/ c:/Service

# Expose port 80 
EXPOSE 80

# Run main service
CMD c:\Service\NotesWebApi.exe