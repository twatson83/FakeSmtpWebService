#Fake SMTP Server Web Service

* Useful for testing emails.
* Uses Dumbster to create in memory smtp servers (http://quintanasoft.com/dumbster/)
* Can create multiple smtp servers by providing different ports.
* Can be ran as a console app or windows service.

##Web API

### GET "server?port=25"

Returns information about server
```javascript
{
	"Name": "TestServer",  				
	"Port": 25,			  				
	"Created": "2015-05-11T11:10:37",   
}
```
### GET "server/exists?port=25"

Returns true or false

### POST "server"
```javascript
{
	"Name": "TestServer",
	"Port": 25
}
```
Creates a new Smtp server

### DELETE "server?port=25"

Stops and deletes the smtp server

### DELETE "emails?port=25"

Deletes all emails on the specified smtp server

### GET "emails?port=25"

Returns all emails on the specified smtp server
```javascript
[{
	"FromAddress": "test123@example.com",
	"Headers": [{ "Header1": "123" }],
	"Important": "High",
	"Priority": "High",
	"ToAddresses": [ "add1@example.com", "add2@example.com" ],
	"Body": "<div>body</div>"
}]
```
### GET "emails/count?port=25"

Retuns number of emails on the specified server