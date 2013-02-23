var http = require("http"),
fs = require("fs");

http.createServer(function (req, res) {
  res.writeHead(200, { 'Content-Type': 'text/html' });
  res.write('<!DOCTYPE html>\n<html>\n<head>\n');
  res.write('</head>\n<body>\n');
  res.write('<h1>Hello Node.js</h1>\n');
  var personList = eval(GetJsonData());
  for (var i = 0; i < personList.length; i++) {
	  res.write(personList[i].Id + "<span>, </span>\n");
	  res.write(personList[i].Name + "<span>, </span>\n");
	  res.write(personList[i].Address + "<p></p>\n");
  }
  res.end('</body>\n</html>\n');
}).listen(8081); 

function GetJsonData() {
  var fileData = fs.readFileSync('json.txt');
  return JSON.parse(fileData.toString());
}
console.log('node is ready port ' + 8081)