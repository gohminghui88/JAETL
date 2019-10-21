/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 26/09/2019
 * Time: 11:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ETLSoft
{
	/// <summary>
	/// Description of LogForm.
	/// </summary>
	public partial class LogForm : Form
	{
		public LogForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public List<List<string>> variablesL = new List<List<string>>();
		public List<string> tableName = new List<string>();
		public string data;
		public string variables;
		public string logOption;
		public string dataName;
		void Button1Click(object sender, EventArgs e)
		{
			try {
			data = comboBox2.Text;
			variables = comboBox1.Text;
			
			if(radioButton1.Checked) logOption = "log10";
			else logOption = "log2";
			
			dataName=textBox1.Text;
			this.Close();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void ComboBox2SelectedIndexChanged(object sender, EventArgs e)
		{
			try {
			List<string> hgh = variablesL[comboBox2.SelectedIndex];
			
			comboBox1.Items.Clear();
			foreach(string f in hgh) {
				comboBox1.Items.Add(f);
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void LogFormLoad(object sender, EventArgs e)
		{
			try {
				comboBox2.Items.Clear();
			foreach(string d in tableName) {
				comboBox2.Items.Add(d);
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
