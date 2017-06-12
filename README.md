# UKSF Website Back-end

## Branch Statuses:

|master|config/deploy|config/build|
|---|---|---|
|[![Build Status](https://travis-ci.org/uksf/website-backend.svg?branch=master)](https://travis-ci.org/uksf/website-backend)[![Coverage Status](https://coveralls.io/repos/github/uksf/website-backend/badge.svg?branch=master)](https://coveralls.io/github/uksf/website-backend?branch=config%2Fdeploy)[![Build status](https://ci.appveyor.com/api/projects/status/d31lsarcu5ltmeao/branch/master?svg=true)](https://ci.appveyor.com/project/frostebite/website-backend/branch/master)|[![Build Status](https://travis-ci.org/uksf/website-backend.svg?branch=config%2Fdeploy)](https://travis-ci.org/uksf/website-backend)[![Coverage Status](https://coveralls.io/repos/github/uksf/website-backend/badge.svg?branch=config%2Fdeploy)](https://coveralls.io/github/uksf/website-backend?branch=config%2Fdeploy)[![Build status](https://ci.appveyor.com/api/projects/status/d31lsarcu5ltmeao/branch/config/deploy?svg=true)](https://ci.appveyor.com/project/frostebite/website-backend/branch/config/deploy)|[![Build Status](https://travis-ci.org/uksf/website-backend.svg?branch=config%2Fbuild)](https://travis-ci.org/uksf/website-backend)[![Coverage Status](https://coveralls.io/repos/github/uksf/website-backend/badge.svg?branch=config%2Fbuild)](https://coveralls.io/github/uksf/website-backend?branch=config%2Fbuild)[![Build status](https://ci.appveyor.com/api/projects/status/d31lsarcu5ltmeao/branch/config/build?svg=true)](https://ci.appveyor.com/project/frostebite/website-backend/branch/config/build)|
    
    
# APIs
## Available
<!-- API START -->
<table>
  <tr>
  <!-- Method -->
    <td><b>POST</b></td>
  <!-- Controller -->
    <td>AuthToken</td>
  </tr>
  <tr>
  <!-- Description -->
    <td colspan="2">Gets a new access token and stores in browser, automatically included<br/>in all HTTP messages after that.</td>
  </tr>
  <tr>
    <td>Request</td>
    <td>Response</td>
  </tr>
<tr>
<!-- Request -->
<td><pre>POST /api/authtoken HTTP/1.1
Host: localhost:5000
loginid: $loginid$
password: $password$</pre></td>
<!-- Response -->
<td><pre>POST /api/authtoken HTTP/1.1
Host: localhost:5000
loginid: $loginid$
password: $password$</pre></td>
</tr>
</table>
<!-- API END -->
<!-- API START -->
<table>
  <tr>
  <!-- Method -->
    <td><b>GET</b></td>
  <!-- Controller -->
    <td>AuthToken</td>
  </tr>
  <tr>
  <!-- Description -->
    <td colspan="2">Gets information on current session.</td>
  </tr>
  <tr>
    <td>Request</td>
    <td>Response</td>
  </tr>
<tr>
<!-- Request -->
<td><pre>GET /api/authtoken HTTP/1.1
Host: localhost:5000</pre></td>
<!-- Response -->
<td><pre>GET /api/authtoken HTTP/1.1
Host: localhost:5000</pre></td>
</tr>
</table>
<!-- API END -->

## WIP
<!-- API START -->
<table>
  <tr>
  <!-- Method -->
    <td><b>GET</b></td>
  <!-- Controller -->
    <td>Account</td>
  </tr>
  <tr>
  <!-- Description -->
    <td colspan="2">Gets information about the user's account.</td>
  </tr>
  <tr>
    <td>Request</td>
    <td>Response</td>
  </tr>
<tr>
<!-- Request -->
<td><pre>GET /api/account HTTP/1.1
Host: localhost:5000
email: $email$
password: $password$</pre></td>
<!-- Response -->
<td><pre>GET /api/account HTTP/1.1
Host: localhost:5000
email: $email$
password: $password$</pre></td>
</tr>
</table>
<!-- API END -->


## Planned

## Broken

## Suggested
- [POST] /account/password - Updates password
- [GET] /account - Gets account information
