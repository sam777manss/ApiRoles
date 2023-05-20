# ApiRoles

JWT Steps
1) Right Click on Project folder name in this case 
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
    password:"Same1998@"
}
