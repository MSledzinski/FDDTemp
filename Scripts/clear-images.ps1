 # remove stopped containers
 docker rm $(docker ps -a -q)

 # removed non tagged images
 $noneImages = docker images | ForEach-Object { 
   
    $tokens = ([string]$_).Split(' ',[System.StringSplitOptions]::RemoveEmptyEntries)

    if($tokens[0] -eq '<none>'){
        $tokens[2]      
    }
 }

 $noneImages | ForEach-Object { docker rmi $_ }