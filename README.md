# ApiRoles

JWT Steps
1) Right Click on Project folder name. In this case 
ApiRoles -> properties -> Debug -> Gerenal (Open debug launch profiles UI) 
in ApiRoles Scroll Down and on 
App URL box put this :- https://localhost:7140

Postman 
([FromForm] LoginModel model)
then in postman body -> 
select - form-data(json) 
send key value pair

([FromBody] RegisterModel model)
then 
select - raw(json)
{
    username:"sameer",
    password:"password"
}

----------------------------------------------------------------------------------------------------------------------
Is all sites use jwt token
and after registration it store token in local storage
if i visits many sites that means many token in local storage
So it becomes tedious to handle. Is there any alternative solution for it

there are alternative solutions you can consider:
Session-based authentication:
Single Sign-On (SSO): 
Token-based authentication

-----------------------------------------------------------------------------------------------------------------------
