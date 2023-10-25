﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datadrasil
{
	public static class ErrorLogger
	{
		public static void LogError(Exception ex)
		{
			string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_ErrorLog.txt";
			string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

			using (StreamWriter writer = File.AppendText(filePath))
			{
				writer.WriteLine($"[{DateTime.Now}] {ex.GetType().FullName}: {ex.Message}");
				writer.WriteLine($"StackTrace: {ex.StackTrace}");
				writer.WriteLine(new string('-', 30));
			}
		}
	}
}
