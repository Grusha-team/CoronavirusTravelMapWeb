var count = 0 ;
var id1=0;
var id2=0;
let coordinates = [];
var countries = [] ;
var helper = 0 ;

var countr = document.getElementsByClassName("country");

//TOOLTIP FOR ALL COUNTRIES
for(let i=0;i<countr.length;++i)
{
  cname=countr[i].getAttribute("data-name");
  countr[i].setAttribute("data-tooltip",cname);
   }

//DELAY
function del(k)
{
  k.setAttribute('style', "fill:#ffcc99;fill-rule:evenodd");
}


//BUTTON SCRIPT
function clickhandler()
{   
  for(let i=0;i<countr.length;++i)
  {
    cname=countr[i].getAttribute("data-name");
    countr[i].setAttribute("style","fill:#c0c0c0;fill-rule:evenodd");
  }
  $(".route").text("");
  $(".restrictions__countryRestrictions").text(" ");
  let countriesid = [];
  a=(document.getElementById("startCountry").value);
  b=(document.getElementById("finishCountry").value);
  var start = a     
  var finish = b   
  var requestURL = 'http://176.119.156.192/GetRoute?start=' + encodeURIComponent(start) + '&finish=' + encodeURIComponent(finish);
  var request = new XMLHttpRequest();
  request.open('GET', requestURL, false);
  request.send(); 
  var resp = JSON.parse(request.response);
  countries = resp;
  console.log(countries);
  count=0;
  countryName=[]
  countryQuarantine=[]
  countryTest=[]
  for (i in resp)
  {
    count++;
    countryName.push(countries[i]["name"]);
    countryQuarantine.push(countries[i]["quarantine"]);
    countryTest.push(countries[i]["covidtest"]);
  }
  var route = start;
  var restrictions = '\n ';
  timer = 2000;
  for (let i = 1 ; i < count-1; i++)
  {   
      var k = document.querySelector('[data-name="'+countryName[i]+'"');
      countriesid.push(k.getAttribute("id"));
      if(i===1)
      {
        setTimeout(del, 300, k);
      }
      else
      {
        setTimeout(del, 300, k);
      }
      var c = k.getAttribute("d");
      coordinates.push(c);
      route = route + " \n" + "→"+ " \n" + k.getAttribute("data-name");
      time = timer + 4000;   
    }
  for(let i=0;i<count;i++)
  {
    restrictions = restrictions +"\t"+ countryName[i] + "\t" + "Quarantine:" + countryQuarantine[i] + "\t" + "COVID test:" + countryTest[i] + "\t";
  }
  route = route +  "\n "+ "→"+ " \n" + finish;
  $(".route").text(route);
  $(".restrictions__countryRestrictions").text(restrictions);
  for ( i in coordinates)
  {
    var k = i.split();
  }
  var f = document.querySelector('[data-name="'+start+'"');
  countriesid.unshift(f.getAttribute("id"));
  f = document.querySelector('[data-name="'+finish+'"');
  countriesid.push(f.getAttribute("id"));
  console.log(countriesid);
  l1=countriesid.length -1
  c1=document.getElementById(countriesid[0]);
  c2=document.getElementById(countriesid[l1]);
  c1.setAttribute('style', "fill:darkOrange;fill-rule:evenodd");
  c2.setAttribute('style', "fill:darkOrange;fill-rule:evenodd");
  for(let i=0;i<countriesid.length;++i)
  {
    qwe=document.getElementById(countriesid[i]);
    console.log(qwe);
    qwe.setAttribute("data-tooltip", countryName[i] + '  ' + "Quarantine:  " + countryQuarantine[i] + " COVID test:   " + countryTest[i] );     
  }
}
//CHART
var margin = {top: 10, right: 30, bottom: 30, left: 60},
    width = 250 - margin.left - margin.right,
    height = 200 - margin.top - margin.bottom;
// append the svg object to the body of the page
var svg = d3.select("#myDataViz")
  .append("svg")
    .attr("width", width + margin.left + margin.right)
    .attr("height", height + margin.top + margin.bottom)
  .append("g")
    .attr("transform",
          "translate(" + margin.left + "," + margin.top + ")");
//Read the data
d3.csv("https://raw.githubusercontent.com/holtzy/data_to_viz/master/Example_dataset/3_TwoNumOrdered_comma.csv",
  //format variables
  function(d){
    return { date : d3.timeParse("%Y-%m-%d")(d.date), value : d.value }
  },
  function(data) {
    // Add X axis --> it is a date format
    var x = d3.scaleTime()
      .domain(d3.extent(data, function(d) { return d.date; }))
      .range([ 0, width ]);
    svg.append("g")
      .attr("transform", "translate(0," + height + ")")
      .call(d3.axisBottom(x));

    // Add Y axis
    var y = d3.scaleLinear()
      .domain([0, d3.max(data, function(d) { return +d.value; })])
      .range([ height, 0 ]);
    svg.append("g")
      .call(d3.axisLeft(y));

    // Add the line
    svg.append("path")
      .datum(data)
      .attr("fill", "none")
      .attr("stroke", "darkOrange")
      .attr("stroke-width", 1.5)
      
      .attr("d", d3.line()
        .x(function(d) { return x(d.date) })
        .y(function(d) { return y(d.value) })
        )
    
        
})

//TOOLTIP
$("[data-tooltip]").mousemove(function (eventObject) {

  $data_tooltip = $(this).attr("data-tooltip");
  
  $(".tooltip").text($data_tooltip)
               .css({ 
                   "top" : eventObject.pageY - 18,
                  "left" : eventObject.pageX -10
               })
               .show();

}).mouseout(function () {

  $(".tooltip").hide()
               .text("")
               .css({
                   "top" : 0,
                  "left" : 0
               });
});















//