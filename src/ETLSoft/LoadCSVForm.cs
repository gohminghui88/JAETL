/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 27/09/2019
 * Time: 4:42 PM
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
	/// Description of LoadCSVForm.
	/// </summary>
	public partial class LoadCSVForm : Form
	{
		public LoadCSVForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//label2.Text = inFile;
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
			data = new List<List<string>>();
			dt = new DataTable();
			
			TextFieldParser tf = new TextFieldParser(label2.Text);
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
		void Button4Click(object sender, EventArgs e)
		{
			try {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";
			
			DialogResult res = ofd.ShowDialog();
			
			if(res == DialogResult.OK) {
				label2.Text = ofd.FileName;
				
				data = new List<List<string>>();
			dt = new DataTable();
			
			TextFieldParser tf = new TextFieldParser(label2.Text);
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
			textBox1.Text = Path.GetFileName(label2.Text.Replace(".csv", ""));
			}
			
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
