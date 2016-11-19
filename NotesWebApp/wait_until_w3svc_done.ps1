while ((Get-Service -Name 'w3svc').Status -eq "Running" ) 
{
    Start-Sleep -Seconds 5
}