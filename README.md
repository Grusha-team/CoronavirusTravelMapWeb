Simple API.
<h1>Usage </h1>
 <text> Send all <b> <code>[GET]</code></b> requests here :  http://176.119.156.192/ </text>
                   <h3>Functionality</h3>
                   <ul> <li>/GetRoute
                  <ul><li>start [name of the country]</li>
                        <li>finish [name of the country]</li>
                </ul></li>
              <li>/GetCountryData
               <ul><li>name [name of the country]</li> </ul></li>
 <li>/GetAllCountries</li></ul>
                 Example of the request: <code>http://176.119.156.192/GetRoute?start=Egypt&finish=Britain</code> <br>  
Example of the answer : <code> [{"name":"Egypt","quarantine":"unknown","covidtest":"unknown"},{"name":"HongKong","quarantine":"yes","covidtest":"no","ListsOfCountries":null},{"name":"Britain","quarantine":"unknown","covidtest":"unknown"}]</code>
<h1> Useful data </h1>
 All<b> <code> country names</code></b> and data can be found in our google (what a shame) table: https://docs.google.com/spreadsheets/d/10NY3Un__WHHni1reM3Blb-ZcuroYm8eR0-yMdn3oBC8/edit#gid=0

