package com.gdgistanbul.event.test;

import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class PerformanceTest {
	public static void main(String[] args) {
		double result = 0;
		SimpleDateFormat format = new SimpleDateFormat("m:s:S");
		System.err.println(format.format(new Date()));
		for (double i = 0; i < 1000000000; i++) {
			result += Math.sqrt(i);
		}
		System.err.println(format.format(new Date()));
		DecimalFormat df = new DecimalFormat("#.##");
		System.err.println(df.format(result));
	}
}
