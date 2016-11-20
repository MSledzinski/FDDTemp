function Get-ContainersIpAddresses()
{
    $runningIds = docker ps -q

    foreach($id in $runningIds)
    {
        $ip = docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' $id
    
        Write-Output (New-Object -TypeName PSObject -Property @{ "ContainerIP" = $ip; "ContainerID" = $id })
    }
}

function Find-SampleWebAppFileInLayers()
{
    $file = Get-ChildItem -Path 'C:\ProgramData\docker\windowsfilter' 'SampleWebAppWithDocker.sln' -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1

    # file.Build.Layer
    $path = $file.Directory.Parent.Parent.FullName
    & explorer $path

}



