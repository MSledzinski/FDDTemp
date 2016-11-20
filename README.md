Demo apps for FDD

Note:
1. If image build is failing with 'cannot resolve DNS' error, try:
- open Powershell console as admin
- run: Stop-Service docker
- run: notepad C:\ProgramData\Docker\config\daemon.json
- add to file: { "dns": ["8.8.8.8"] }
- save and close
- run: Start-Service docker
   

