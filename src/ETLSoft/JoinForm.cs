/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 27/09/2019
 * Time: 2:10 PM
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
	/// Description of JoinForm.
	/// </summary>
	public partial class JoinForm : Form
	{
		public JoinForm()
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
		public string data1;
		public string data2;
		public string data1Variable;
		public string data2Variable;
		public string joinDataName;
		void Button1Click(object sender, EventArgs e)
		{
			try {
			data1 = comboBox3.Text;
			data1Variable = comboBox2.Text;
			data2 = comboBox4.Text;
			data2Variable = comboBox1.Text;
			joinDataName = textBox1.Text;
			
			this.Close();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void ComboBox3SelectedIndexChanged(object sender, EventArgs e)
		{
			try {
			List<string> hgh = variablesL[comboBox3.SelectedIndex];
			
			comboBox2.Items.Clear();
			foreach(string f in hgh) {
				comboBox2.Items.Add(f);
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void ComboBox4SelectedIndexChanged(object sender, EventArgs e)
		{
			try {
			List<string> hgh = variablesL[comboBox4.SelectedIndex];
			
			comboBox1.Items.Clear();
			foreach(string f in hgh) {
				comboBox1.Items.Add(f);
			}
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void JoinFormLoad(object sender, EventArgs e)
		{
			try {
				comboBox3.Items.Clear();
			for(int i = 0; i < tableName.Count; i++) {
				comboBox3.Items.Add(tableName[i]);
				
			}
				
				comboBox4.Items.Clear();
			
			for(int i = 0; i < tableName.Count; i++) {
				comboBox4.Items.Add(tableName[i]);
				
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
