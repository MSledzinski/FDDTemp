# docker pull microsoft/mssql-server-windows-express
docker run -d -p 1433:1433 -v C:/temp/:C:/temp/  -e sa_password=Password_1234_! -e ACCEPT_EULA=Y  -e attach_dbs="[{'dbName':'Notes','dbFiles':['C:\\temp\\notes.mdf','C:\\temp\\notes_log.ldf']}]" microsoft/mssql-server-windows-express --name DatabaseHost

#docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' DatabaseHost