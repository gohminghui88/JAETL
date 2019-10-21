/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 02/10/2019
 * Time: 2:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace ETLSoft
{
	/// <summary>
	/// Description of LoadForm.
	/// </summary>
	public partial class LoadForm : Form
	{
		public LoadForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public List<List<string>> data = new List<List<string>>();
		
		void RichTextBox1TextChanged(object sender, EventArgs e)
		{
			try {
			string keywords = @"\b(select|select distinct|where|and|or|not|order by|insert into|update|delete|min|max|count|avg|sum|like|in|between|join|inner join|left join|right join|full join|self join|union|group by|having|SELECT|SELECT DISTINCT|WHERE|AND|OR|NOT|ORDER BY|INSERT INTO|UPDATE|DELETE|MIN|MAX|COUNT|AVG|SUM|LIKE|IN|BETWEEN|JOIN|INNER JOIN|LEFT JOIN|RIGHT JOIN|FULL JOIN|SELF JOIN|UNION|GROUP BY|HAVING)\b";
			MatchCollection keywordMatches = Regex.Matches(richTextBox1.Text, keywords);
			
			int originalIndex = richTextBox1.SelectionStart;
			int originalLength = richTextBox1.SelectionLength;
			Color originalColor = Color.Black;
			
			richTextBox1.SelectionStart = 0;
			richTextBox1.SelectionLength = richTextBox1.Text.Length;
			richTextBox1.SelectionColor = originalColor;
			
    		int StartCursorPosition = richTextBox1.SelectionStart;
    		foreach (Match m in keywordMatches)
    		{
    			richTextBox1.SelectionStart = m.Index;
    			richTextBox1.SelectionLength = m.Length;
    			richTextBox1.SelectionColor = Color.Blue;
    		}
    		
    		richTextBox1.SelectionStart = originalIndex;
    		richTextBox1.SelectionLength = originalLength;
    		richTextBox1.SelectionColor = originalColor;
    		
    		richTextBox1.Focus();
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button8Click(object sender, EventArgs e)
		{
			Export es = new Export();
			
			
			if(comboBox1.Text == "CSV File") {
				es.exportCSV(data, textBox1.Text);
			}
			
			if(comboBox1.Text == "Weka File") {
				es.exportWeka(data, textBox1.Text, Path.GetFileName(textBox1.Text).Replace(".arff", ""));
			}
			
			if(comboBox1.Text == "SQL Script") {
				es.exportSQL(data, textBox1.Text, Path.GetFileName(textBox1.Text).Replace(".sql", ""));
				
			}
			
			MessageBox.Show("File Saved. ");
			
		}
		void Button7Click(object sender, EventArgs e)
		{
			StreamReader sr = new StreamReader(textBox1.Text); 
			
			string line;
			List<string> h = new List<string>();
			while((line = sr.ReadLine()) != null) {
				h.Add(line);
			}
			sr.Close();
			
			foreach(string s in h) {
				richTextBox1.Text += "\n" + s;
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			SaveFileDialog of = new SaveFileDialog();
			of.Filter = "CSV Files (*.csv)|*.csv|ARFF files (*.arff)|*.arff|SQL files (*.sql)|*.sql|All files (*.*)|*.*";
			DialogResult re1 = of.ShowDialog();
			
			if(re1 == DialogResult.OK) {
				textBox1.Text = of.FileName;
				if(of.FileName.Contains(".arff"))
					comboBox1.Text = "Weka File";
				
				if(of.FileName.Contains(".csv"))
					comboBox1.Text = "CSV File";
				
				if(of.FileName.Contains(".sql"))
					comboBox1.Text = "SQL Script";
				
				
				Export es = new Export();
			
			
			if(comboBox1.Text == "CSV File") {
				es.exportCSV(data, textBox1.Text);
			}
			
			if(comboBox1.Text == "Weka File") {
				es.exportWeka(data, textBox1.Text, Path.GetFileName(textBox1.Text).Replace(".arff", ""));
			}
			
			if(comboBox1.Text == "SQL Script") {
				es.exportSQL(data, textBox1.Text, Path.GetFileName(textBox1.Text).Replace(".sql", ""));
				
			}
			
			MessageBox.Show("File Saved. ");
				
			}
		}
		
		MySqlConnection conn ;
		void Button4Click(object sender, EventArgs e)
		{
			try {
			string server = textBox2.Text;
			string database = textBox3.Text;
			string uid = textBox5.Text;
			string passwords = textBox6.Text;
			string port = textBox4.Text;
			
			String connectionString = "server=" + server + ";database=" + database + ";port=" + port + ";uid=" + uid + ";password=" + passwords + ";";
			
			conn = new MySqlConnection(connectionString);
			
			conn.Open();
			MessageBox.Show("Connection Opened. ");
			conn.Close();
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
	
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			MySqlCommand command = new MySqlCommand(richTextBox1.Text, conn); 
			MySqlDataReader MyReader;  
        	conn.Open();  
         	MyReader = command.ExecuteReader();  
         	MessageBox.Show("Inserted. ");  
		}
		void Button3Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
