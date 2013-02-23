<%@page import="java.text.DecimalFormat"%>
<%@page import="java.util.Date"%>
<%@page import="java.text.SimpleDateFormat"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>GDG Istanbul Test</title>
</head>
<body>
	<%
		double result = 0;
		SimpleDateFormat format = new SimpleDateFormat("m:s:S");
		out.println("<p>"+format.format(new Date())+"</p>");
		for (double i = 0; i < 1000000000; i++) {
			result += Math.sqrt(i);
		}
		out.println("<p>"+format.format(new Date())+"</p>");
		DecimalFormat df = new DecimalFormat("#.##");
		out.println("<p>"+df.format(result)+"</p>");
	%>
</body>
</html>