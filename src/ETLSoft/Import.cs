/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 07/10/2019
 * Time: 2:21 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Windows.Forms;

namespace ETLSoft
{
	/// <summary>
	/// Description of Import.
	/// </summary>
	public class Import
	{
		public Import()
		{
		}
		
		public List<List<string>> data;
		public DataTable dt;
		public void importARFF(string path) {
			
			try {
			StreamReader sr = new StreamReader(path);
			string line = "";
			List<string> res = new List<string>();
			while((line = sr.ReadLine()) != null) {
				res.Add(line);
			}
			sr.Close();
			
			List<string> columns = new List<string>();
			foreach(string d in res) {
				if(d.Contains("@ATTRIBUTE")) {
					string[] w = d.Split(' ');
					string[] q = w[1].Split('\t');
					
					columns.Add(q[0]);
				}
			}
			
			int z = 0;
			string head = "";
			foreach(string c in columns) {	
				if(z > 0) head = head + ",\"" + c + "\"";
				if(z == 0) head = "\"" + c + "\"";
				
				z++;
			}
			
			List<string> data1 = new List<string>();
			int isData = 0;
			foreach(string d in res) {
				if(d.Contains("@DATA")) {
					isData = 1;
				}
				
				if(isData == 1) {
					if(!d.Contains("%"))
						data1.Add(d);
				}
			}
			data1.RemoveAt(0);
			data1.Insert(0, head);
			
			StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "/ll.csv");
			
			foreach(string dr in data1) {
				
					sw.WriteLine(dr);
			}
			sw.Close();
			
			
			
			
			data = new List<List<string>>();
			dt = new DataTable();
			
			TextFieldParser tf = new TextFieldParser(Directory.GetCurrentDirectory() + "/ll.csv");
			tf.SetDelimiters(",");
			while(!tf.EndOfData) {
				string[] fields = tf.ReadFields();
				
				List<string> variables = new List<string>();
				
				foreach(string f in fields) {
					variables.Add(f);
				}
				data.Add(variables);
			}
			
			
			List<string> columnNames = data[0];
			
			foreach(string c in columnNames) {
				dt.Columns.Add(c);
			}
			
			int g = 0;
			foreach(List<string> row in data) {
				
				if(g != 0) {
				DataRow dr = dt.NewRow();
				
				int k = 0;
				foreach(string r in row) {
					dr[k] = r;
					k++;
				}
				dt.Rows.Add(dr);
				}
				g++;
				
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public void importCSV(string path) {
			try {
			data = new List<List<string>>();
			dt = new DataTable();
			
			TextFieldParser tf = new TextFieldParser(path);
			tf.SetDelimiters(",");
			while(!tf.EndOfData) {
				string[] fields = tf.ReadFields();
				
				List<string> variables = new List<string>();
				
				foreach(string f in fields) {
					variables.Add(f);
				}
				data.Add(variables);
			}
			
			
			List<string> columnNames = data[0];
			
			foreach(string c in columnNames) {
				dt.Columns.Add(c);
			}
			
			int g = 0;
			foreach(List<string> row in data) {
				
				if(g != 0) {
				DataRow dr = dt.NewRow();
				
				int k = 0;
				foreach(string r in row) {
					dr[k] = r;
					k++;
				}
				dt.Rows.Add(dr);
				}
				g++;
				
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public DataTable List2DataTable(List<List<string>> dat) {
			List<string> columnNames = dat[0];
			DataTable dt = new DataTable();;
			
			foreach(string c in columnNames) {
				dt.Columns.Add(c);
			}
			
			int g = 0;
			foreach(List<string> row in dat) {
				
				if(g != 0) {
				DataRow dr = dt.NewRow();
				
				int k = 0;
				foreach(string r in row) {
					dr[k] = r;
					k++;
				}
				dt.Rows.Add(dr);
				}
				g++;
			}
			
			return dt;
				
		}
			
			
		MySqlConnection conn ;
		public void connectSQL(string server, string database, string uid, string passwords, string port) {
			try {
			
			
			String connectionString = "server=" + server + ";database=" + database + ";port=" + port + ";uid=" + uid + ";password=" + passwords + ";";
			
			conn = new MySqlConnection(connectionString);
			
			conn.Open();
			MessageBox.Show("Connection Opened. ");
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public void importSQL(string query) {
			try {
			MySqlCommand command = new MySqlCommand(query, conn);
			dt = new DataTable();
			
			dt.Load(command.ExecuteReader());
			
			data = new List<List<string>>();
			
			List<string> columns = new List<string>();
			foreach(DataColumn col in dt.Columns) {
				columns.Add(col.ColumnName);
			}
			
			data.Add(columns);
			
			
			foreach(DataRow row in dt.Rows) {
				
				string[] cols = new string[row.ItemArray.Length];
				for(int x = 0; x < row.ItemArray.Length; x++) {
					
					cols[x] = row[x].ToString();
					x++;
				}
				
				List<string> j = new List<string>(cols);
				
				data.Add(j);
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public void closeSQL() {
			try {
			conn.Close();
			MessageBox.Show("Connection Closed. ");
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
