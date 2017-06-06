# UKSF Website Back-end

Master branch status: <br/>
[![Build Status](https://travis-ci.org/uksf/website-backend.svg?branch=master)](https://travis-ci.org/uksf/website-backend)

# APIs
## Available
- [POST] /authtoken - Gets a new access token and stores in browser, automatically included in all HTTP messages after that
@headers{
	"userid" : "$EMAIL$", //we will use email but we will refer to this as userid to allow for email or username use later on
	"password" : "" //should be encoded as needed
}
@body{
	//none needed
}

- [GET] /authtoken - Gets information on current session
headers : {
	//none needed
}
body : {
	//none needed
}
## WIP
<table>
<tr>
<td>GET - Account</td>
</tr>
<tr>
<td>Request</td>
<td>Response</td>
</tr>
<tr>
<td><pre>GET /api/account HTTP/1.1
Host: localhost:5000
email: $email$
password: $password$</pre></td>
<td><pre>GET /api/account HTTP/1.1
Host: localhost:5000
email: $email$
password: $password$</pre></td>
</tr>
</table>


## Planned

## Broken

## Suggested
- [POST] /account/password - Updates password
- [GET] /account - Gets account information
