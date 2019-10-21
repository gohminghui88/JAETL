/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 27/09/2019
 * Time: 4:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace ETLSoft
{
	/// <summary>
	/// Description of LoadARFFForm.
	/// </summary>
	public partial class LoadARFFForm : Form
	{
		public LoadARFFForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public List<List<string>> data;
		public DataTable dt;
		public string inFile;
		
		void Button3Click(object sender, EventArgs e)
		{
			try {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "ARFF files (*.arff)|*.arff|All files (*.*)|*.*";
			DialogResult re1 = ofd.ShowDialog();
			
			if(re1 == DialogResult.OK) {
				label2.Text = ofd.FileName;
				
				StreamReader sr = new StreamReader(label2.Text);
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
			
			dataGridView1.DataSource = dt;
			textBox1.Text = Path.GetFileName(label2.Text.Replace(".arff", ""));
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button4Click(object sender, EventArgs e)
		{
			try {
			StreamReader sr = new StreamReader(label2.Text);
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
			
			dataGridView1.DataSource = dt;
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public string tabName;
		void Button1Click(object sender, EventArgs e)
		{
			try {
			tabName = textBox1.Text;
			this.Close();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			try {
			this.Close();
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
