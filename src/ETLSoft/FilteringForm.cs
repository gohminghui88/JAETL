/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 26/09/2019
 * Time: 11:20 PM
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
	/// Description of FilteringForm.
	/// </summary>
	public partial class FilteringForm : Form
	{
		public FilteringForm()
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
		public string operat;
		public string operat2;
		public string dataName;
		void Button1Click(object sender, EventArgs e)
		{
			try {
			data = comboBox3.Text;
			variables = comboBox1.Text;
			operat = comboBox2.Text;
			operat2 = textBox1.Text;
			dataName=textBox2.Text;
			
			this.Close();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void FilteringFormLoad(object sender, EventArgs e)
		{
			try {
				
			comboBox3.Items.Clear();
			foreach(string d in tableName) {
				comboBox3.Items.Add(d);
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		void ComboBox3SelectedIndexChanged(object sender, EventArgs e)
		{
			try {
			List<string> hgh = variablesL[comboBox3.SelectedIndex];
			comboBox1.Items.Clear();
			foreach(string f in hgh) {
				comboBox1.Items.Add(f);
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
