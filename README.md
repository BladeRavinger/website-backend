# UKSF Website Back-end
[![Build Status](https://travis-ci.org/uksf/website-backend.svg?branch=master)](https://travis-ci.org/uksf/website-backend)
# APIs
## Available
- [POST] /authtoken - Gets a new access token and stores in browser, automatically included in all HTTP messages after that
@headers{
	"loginid" : "$EMAIL$", //we will use email but we will refer to this as userid to allow for email or username use later on
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

- [POST] /account - registers the user 
@headers{
	"username" : "", // username
	"password" : "", //should be encoded as needed
	"email" : "" // username
}

## Planned

## Broken

## Suggested
- [POST] /account/password - Updates password
- [GET] /account - Gets account information
