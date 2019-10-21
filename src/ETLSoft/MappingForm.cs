/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 26/09/2019
 * Time: 11:18 PM
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
	/// Description of MappingForm.
	/// </summary>
	public partial class MappingForm : Form
	{
		public MappingForm()
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
		public string values;
		public string to;
		public List<string> values2 = new List<string>();
		public string dataName;
		
		void Button1Click(object sender, EventArgs e)
		{
			try {
			data = comboBox1.Text;
			variables = comboBox2.Text;
			values = textBox1.Text;
			to = textBox2.Text;
			dataName=textBox3.Text;
			
			List<string> valuesw = new List<string>();
			for(int i = 0; i < listBox1.Items.Count; i++) {
				valuesw.Add(listBox1.Items[i].ToString());
			}
			
			List<string> tow = new List<string>();
			for(int i = 0; i < listBox2.Items.Count; i++) {
				tow.Add(listBox2.Items[i].ToString());
			}
			
			int q = 0;
			foreach(string sd in valuesw) {
				
				values2.Add(valuesw[q] + ":" + tow[q]);
				q++;
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
			listBox1.Items.Add(textBox1.Text);
			listBox2.Items.Add(textBox2.Text);
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void MappingFormLoad(object sender, EventArgs e)
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
