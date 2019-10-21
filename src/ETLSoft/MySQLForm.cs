/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 27/09/2019
 * Time: 5:00 PM
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

namespace ETLSoft
{
	/// <summary>
	/// Description of MySQLForm.
	/// </summary>
	public partial class MySQLForm : Form
	{
		public MySQLForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		MySqlConnection conn ;
		void Button2Click(object sender, EventArgs e)
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
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public List<List<string>> data;
		public DataTable dt;
		void Button1Click(object sender, EventArgs e)
		{
			try {
			MySqlCommand command = new MySqlCommand(richTextBox1.Text, conn);
			dt = new DataTable();
			
			dt.Load(command.ExecuteReader());
			
			dataGridView1.DataSource = dt;
			
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
		void Button5Click(object sender, EventArgs e)
		{
			try {
			conn.Close();
			MessageBox.Show("Connection Closed. ");
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		//Reference: https://www.c-sharpcorner.com/article/syntax-highlighting-in-richtextbox-control-part-2/
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
		
		public string tabName;
		void Button3Click(object sender, EventArgs e)
		{
			try {
			tabName = textBox1.Text;
			this.Close();
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button4Click(object sender, EventArgs e)
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
