/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 26/09/2019
 * Time: 10:58 PM
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
	/// Description of RemoveMissingForm.
	/// </summary>
	public partial class RemoveMissingForm : Form
	{
		public RemoveMissingForm()
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
		public string dataName;
		void Button1Click(object sender, EventArgs e)
		{
			try {
			data = comboBox1.Text;
			variables = comboBox2.Text;
			dataName=textBox1.Text;
			
			this.Close();
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void RemoveMissingFormLoad(object sender, EventArgs e)
		{
			try {
				comboBox1.Items.Clear();
			foreach(string d in tableName) {
				comboBox1.Items.Add(d);
			}
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			try {
			List<string> hgh = variablesL[comboBox1.SelectedIndex];
			
			comboBox2.Items.Clear();
			foreach(string f in hgh) {
				comboBox2.Items.Add(f);
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
