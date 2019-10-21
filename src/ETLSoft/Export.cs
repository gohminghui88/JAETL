/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 01/10/2019
 * Time: 4:42 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ETLSoft
{
	/// <summary>
	/// Description of Export.
	/// </summary>
	public class Export
	{
		public Export()
		{
		}
		
		
		public void exportCSV(List<List<string>> data, string filePath) {
			
			try {
			StreamWriter sw = new StreamWriter(filePath);
			
			foreach(List<string> row in data) {
				string l = "";
				foreach(string col in row) {
					l += "\"" + col + "\",";
				}
				sw.WriteLine(l.Remove(l.Length - 1));
			}
			
			sw.Close();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public void exportWeka(List<List<string>> data, string filePath, string t) {
			
			try {
			List<string> variables = data[0];
			//remove header
			data.RemoveAt(0);
			
			//create attributes
			string table = "";
			table += "@RELATION " + t + "\n\n";
			
			foreach(string v in variables) {
				table += "\n@ATTRIBUTE " + v + "\tstring";
			}
			
			//create data
			table += "\n@DATA";
			
			// for each row
			foreach(List<string> row in data) {
				string h = ""; int a = 0;
				
				//for each col
				foreach(string col in row) {
					if(a == 0) h = col;
					
					else
						h += ",\"" + col + "\"";
					
					a++;
				}
				
				//table add row
				table += "\n" + h;
			}
			
			//table to row
			string[] ad = table.Split('\n');
			StreamWriter sw = new StreamWriter(filePath);
			foreach(string a in ad) {
				sw.WriteLine(a);
			}
			
			sw.Close();
			
			}
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public void exportSQL(List<List<string>> data, string filePath, string tableName) {
			try {
			
			string tableScri = "CREATE TABLE " + tableName + "(";
			List<string> variables = data[0];
			data.RemoveAt(0);
			
			int u = 0;
			foreach(string v in variables) {
				if(u == variables.Count - 1)
					tableScri += "\n" + v + "\t" + "varchar(255) ";
				else tableScri += "\n" + v + "\t" + "varchar(255), ";
				u++;
			}
			
			tableScri += ");\n";
			
			
			foreach(List<string> row in data) {
				
				int i = 0;
				string f = "";
				foreach(string col in row) {
					
					if(i > 0) f += ",\'" + col + "\'";
					else f = "\'" + col + "\'";
					
					i++;
				}
				
				string q = "INSERT INTO " + tableName + " VALUES (" + f + ");";
				tableScri = tableScri + "\n" + q;
			}
			
			string[] ad = tableScri.Split('\n');
			StreamWriter sw = new StreamWriter(filePath);
			foreach(string a in ad) {
				sw.WriteLine(a);
			}
			
			sw.Close();
			
			}
			
			catch(Exception ex) {
				
			}
		}
	}
}
