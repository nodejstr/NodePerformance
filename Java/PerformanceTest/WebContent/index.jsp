<%@page import="org.json.JSONObject"%>
<%@page import="java.io.File"%>
<%@page import="java.io.FileReader"%>
<%@page import="com.gdgistanbul.event.test.Util"%>
<%@page import="org.json.JSONArray"%>
<%@page import="java.nio.charset.Charset"%>
<%@page import="java.io.InputStreamReader"%>
<%@page import="java.io.BufferedReader"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>NodeJSTR</title>
</head>
<body>
	<%
		try {
			BufferedReader rd = new BufferedReader(new FileReader(new File(
					"C:\\json.txt")));
			String jsonText = Util.readAll(rd);
			JSONArray array = new JSONArray(jsonText);
			out.println("<h1>Hello Node.js</h1>");
			for (int i = 0; i < array.length(); i++) {
				out.println(((JSONObject)array.get(i)).get("Id") + "<span>, </span>\n");
				out.println(((JSONObject)array.get(i)).get("Name") + "<span>, </span>\n");
				out.println(((JSONObject)array.get(i)).get("Address") + "<p></p>\n");
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	%>
</body>
</html>