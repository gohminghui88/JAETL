/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 26/09/2019
 * Time: 11:27 PM
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
	/// Description of VariableSelectionForm.
	/// </summary>
	public partial class VariableSelectionForm : Form
	{
		public VariableSelectionForm()
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
		public List<String>  variables2 = new List<string>();
		public string dataName;
		void Button1Click(object sender, EventArgs e)
		{
			try {
			
			dataName=textBox1.Text;
			data = comboBox1.Text;
			foreach(string s in listBox2.Items) {
				variables2.Add(s);
			}
			this.Close();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			try {
			listBox2.Items.Add(listBox1.SelectedItem.ToString());
			listBox1.Items.Remove(listBox1.SelectedItem.ToString());
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			try {
			listBox1.Items.Add(listBox2.SelectedItem.ToString());
			listBox2.Items.Remove(listBox2.SelectedItem.ToString());
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void VariableSelectionFormLoad(object sender, EventArgs e)
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
			
			foreach(string f in hgh) {
				
				listBox1.Items.Add(f);
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
