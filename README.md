# Trinity_Matrix_Management_GUI
A management GUI for Matrix-Synapse server

## To do list

- Do proper error handling
- Parse responses properly according to spec
- Optimize cancerous codes
- Force logout of all devices(security response for admins)
- Properly redact before purging room

## Features already available
- Get whois on user
- Deactivate an account
- Reset password
- Create new user(this is using the old API. Same API used as if you create a user via SSH terminal)
- Query rooms(publicly listed rooms only)
- Purge room
- View supported API versions

## [Note] Purge Room 
When a room is purged, what happens is that you basically kick every user out, delist the room from directory and set it to invite only. Then the program will proceed to kick also the admin(you). This is the ensure that nobody will ever have access to the room ever. 
