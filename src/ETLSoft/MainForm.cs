/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 28/05/2019
 * Time: 3:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ETLSoft
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		List<List<List<string>>> data = new List<List<List<string>>>();
		List<DataTable> dt = new List<DataTable>();
		List<List<string>> variablesL = new List<List<string>>();
		List<String> tableName = new List<string>();
		
		List<string> script = new List<string>();
		List<string> scriptName = new List<string>();
		
		void Button1Click(object sender, EventArgs e)
		{
			try {
			if(radioButton1.Checked) {
				LoadCSVForm lcsvf = new LoadCSVForm();
				lcsvf.ShowDialog();
				
				if(listBox1.Items.Contains(lcsvf.tabName) != true) {
					
				data.Add(lcsvf.data);
				dt.Add(lcsvf.dt);
				variablesL.Add(lcsvf.data[0]);
				
				if(lcsvf.tabName != "") {
					listBox1.Items.Add(lcsvf.tabName);
					tableName.Add(lcsvf.tabName);
				}
				
				}
				
				else 
					MessageBox.Show("Table Name duplicated");
			}
			
			if(radioButton2.Checked) {
				MySQLForm mForm = new MySQLForm();
				mForm.ShowDialog();
				
				if(listBox1.Items.Contains(mForm.tabName) != true) {
					
				data.Add(mForm.data);
				dt.Add(mForm.dt);
				variablesL.Add(mForm.data[0]);
				
				if(mForm.tabName != "") {
					listBox1.Items.Add(mForm.tabName);
					tableName.Add(mForm.tabName);
				}
				
				}
				
				else 
					MessageBox.Show("Table Name duplicated");
			}
			
			if(radioButton3.Checked) {
				LoadARFFForm larfff = new LoadARFFForm();
				larfff.ShowDialog();
				
				if(listBox1.Items.Contains(larfff.tabName) != true) {
				
				data.Add(larfff.data);
				dt.Add(larfff.dt);
				variablesL.Add(larfff.data[0]);
				
				if(larfff.tabName != "") {
					listBox1.Items.Add(larfff.tabName);
					tableName.Add(larfff.tabName);
				}
				
				}
				
				else 
					MessageBox.Show("Table Name duplicated");
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
			
		}
		
		
		void Button2Click(object sender, EventArgs e)
		{
			try {
				
			removeDtable();
			string it = listBox2.SelectedItem.ToString();
			int i = scriptName.IndexOf(it);
			string scr = script[i];
			
			string[] k = script[i].Split('\n');
			
			
			foreach(string d in k) {
				
				
				DataTransform dataTransf = new DataTransform();
				string[] uy = d.Split(' ');
				
				if(uy[0] == "join") {
					
					if(tableName.Contains(uy[5].Replace("\"", "").Replace("joinData=", "")) != true) {
						
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data1=", ""));
					List<List<string>> dat1 = data[index];
					
					int index2 = tableName.IndexOf(uy[2].Replace("\"", "").Replace("data2=", ""));
					List<List<string>> dat2 = data[index2];
					
					int colNum = variablesL[index].IndexOf(uy[3].Replace("\"", "").Replace("data1Variable=", ""));
					int colNum2 = variablesL[index2].IndexOf(uy[4].Replace("\"", "").Replace("data2Variable=", ""));
					
					dat1 = dataTransf.RemoveMissingValues(dat1, colNum);
					dat2 = dataTransf.RemoveMissingValues(dat2, colNum2);
					
					
					dat = dataTransf.join(dat1, dat2, colNum, colNum2);
					
					variablesL.Add(dat[0]);
					tableName.Add(uy[5].Replace("\"", "").Replace("joinData=", ""));
					data.Add(dat);
					
				
					
					}
					
					else {
						MessageBox.Show(uy[5].Replace("\"", "").Replace("joinData=", "") + " tableName Already existed. ");
					}
				}
				
				if(uy[0] == "removeMissingValues") {
					
					if(tableName.Contains(uy[3].Replace("\"", "").Replace("dataName=", ""))  != true){
						
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					int colNum = variablesL[index].IndexOf(uy[2].Replace("\"", "").Replace("variables=", ""));
					
					dat = dataTransf.RemoveMissingValues(dat1, colNum);
					
					tableName.Add(uy[3].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					   }
					
					else {
						MessageBox.Show(uy[3].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
					   
				}
				
				if(uy[0] == "replaceMissingValues") {
					
					if(tableName.Contains(uy[4].Replace("\"", "").Replace("dataName=", "")) != true) {
						
					
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					string h = uy[2].Replace("variables=", "").Replace("\"", "");
					int colNum = variablesL[index].IndexOf(h);
					
					dat = dataTransf.replaceMissingValues(dat1, colNum, uy[3].Replace("\"", "").Replace("replaceString=", ""));
					
					tableName.Add(uy[4].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					}
					
					else {
						MessageBox.Show(uy[4].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "removeDuplicates") {
					
					if(tableName.Contains(uy[2].Replace("\"", "").Replace("dataName=", "")) != true) {
						
					
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					dat = dataTransf.removeDuplicates(dat1);
					
					tableName.Add(uy[2].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[2].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "mapping") {
					
					if(tableName.Contains(uy[4].Replace("\"", "").Replace("dataName=", "")) != true) {
						
					
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					int colNum = variablesL[index].IndexOf(uy[2].Replace("\"", "").Replace("variables=", ""));
					
					List<string> hjh = new List<string>();
					foreach(string f in uy[3].Replace("\"", "").Replace("opt=", "").Replace("[", "").Replace("]", "").Split(',')) {
						hjh.Add(f);
					}
					
					dat1 = dataTransf.RemoveMissingValues(dat1, colNum);
					dat = dataTransf.map(dat1, colNum, hjh);
					
					tableName.Add(uy[4].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[4].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "filtering") {
					
					if(tableName.Contains(uy[4].Replace("\"", "").Replace("dataName=", "")) != true) {
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					int colNum = variablesL[index].IndexOf(uy[2].Replace("\"", "").Replace("variables=", ""));
					
					dat1 = dataTransf.RemoveMissingValues(dat1, colNum);
					dat = dataTransf.filtering(dat1, colNum, uy[3].Replace("\"", "").Replace("opt=", ""), uy[4].Replace("\"", "").Replace("opt2=", ""));
					
					tableName.Add(uy[4].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[4].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "variableSelection") {
					
					if(tableName.Contains(uy[3].Replace("\"", "").Replace("dataName=", "")) != true) {
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					
					List<int> hjh = new List<int>();
					string[] g = uy[2].Replace("\"", "").Replace("variables=", "").Replace("[", "").Replace("]", "").Split(',');
					foreach(string f in g) {
						int colNum = variablesL[index].IndexOf(f);
						hjh.Add(colNum);
					}
					dat = dataTransf.variablesSleection(dat1, hjh);
					
					tableName.Add(uy[3].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[3].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "logTransform") {
					
					if(tableName.Contains(uy[4].Replace("\"", "").Replace("dataName=", "")) != true) {
					
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					int colNum = variablesL[index].IndexOf(uy[2].Replace("\"", "").Replace("variables=", ""));
					
					string option = uy[3].Replace("\"", "").Replace("opt=", "");
					
					dat1 = dataTransf.RemoveMissingValues(dat1, colNum);
					dat = dataTransf.TransformLog(dat1, colNum, option);
					
					tableName.Add(uy[4].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[4].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
					
					
					
				}
				
			}
			
			Import imj = new Import();
			PreviewForm pf = new PreviewForm();
			pf.datatable = imj.List2DataTable(dat);
			pf.ShowDialog();
			//PreviewForm pf = new PreviewForm();
			//pf.ShowDialog();
			
			LoadForm exf = new LoadForm();
			exf.data = dat;
			exf.ShowDialog();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		public void removeDtable() {
			string[] k = richTextBox1.Text.Split('\n');
			List<String> res = new List<string>();
			
			foreach(string s in k) {
				
				if(s.Contains("joinData=")) {
					string ggh = "joinData=";
					
					string gjg = s.Substring(s.IndexOf(ggh) + ggh.Length);
					res.Add(gjg.Replace("\"", ""));
				}
				
				if(s.Contains("dataName=")) {
					
					string ggh = "dataName=";
					
					string gjg = s.Substring(s.IndexOf(ggh) + ggh.Length);
					res.Add(gjg.Replace("\"", ""));
				}
				
			}
			
			foreach(string re in res) {
				int index = tableName.IndexOf(re);
				
				if(index != -1) {
				data.RemoveAt(index);
				variablesL.RemoveAt(index);
				tableName.RemoveAt(index);
				}
			}
		}
		
		List<List<string>> dat = new List<List<string>>();
		void Button5Click(object sender, EventArgs e)
		{
			try {
				
			removeDtable();
			string[] k = richTextBox1.Text.Split('\n');
			
			
			foreach(string d in k) {
				
				
				DataTransform dataTransf = new DataTransform();
				string[] uy = d.Split(' ');
				
				if(uy[0] == "join") {
					
					if(tableName.Contains(uy[5].Replace("\"", "").Replace("joinData=", "")) != true) {
						
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data1=", ""));
					List<List<string>> dat1 = data[index];
					
					int index2 = tableName.IndexOf(uy[2].Replace("\"", "").Replace("data2=", ""));
					List<List<string>> dat2 = data[index2];
					
					int colNum = variablesL[index].IndexOf(uy[3].Replace("\"", "").Replace("data1Variable=", ""));
					int colNum2 = variablesL[index2].IndexOf(uy[4].Replace("\"", "").Replace("data2Variable=", ""));
					
					dat1 = dataTransf.RemoveMissingValues(dat1, colNum);
					dat2 = dataTransf.RemoveMissingValues(dat2, colNum2);
					
					
					dat = dataTransf.join(dat1, dat2, colNum, colNum2);
					
					variablesL.Add(dat[0]);
					tableName.Add(uy[5].Replace("\"", "").Replace("joinData=", ""));
					data.Add(dat);
					
				
					
					}
					
					else {
						MessageBox.Show(uy[5].Replace("\"", "").Replace("joinData=", "") + " tableName Already existed. ");
					}
				}
				
				if(uy[0] == "removeMissingValues") {
					
					if(tableName.Contains(uy[3].Replace("\"", "").Replace("dataName=", ""))  != true){
						
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					int colNum = variablesL[index].IndexOf(uy[2].Replace("\"", "").Replace("variables=", ""));
					
					dat = dataTransf.RemoveMissingValues(dat1, colNum);
					
					tableName.Add(uy[3].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					   }
					
					else {
						MessageBox.Show(uy[3].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
					   
				}
				
				if(uy[0] == "replaceMissingValues") {
					
					if(tableName.Contains(uy[4].Replace("\"", "").Replace("dataName=", "")) != true) {
						
					
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					string h = uy[2].Replace("variables=", "").Replace("\"", "");
					int colNum = variablesL[index].IndexOf(h);
					
					dat = dataTransf.replaceMissingValues(dat1, colNum, uy[3].Replace("\"", "").Replace("replaceString=", ""));
					
					tableName.Add(uy[4].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					}
					
					else {
						MessageBox.Show(uy[4].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "removeDuplicates") {
					
					if(tableName.Contains(uy[2].Replace("\"", "").Replace("dataName=", "")) != true) {
						
					
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					dat = dataTransf.removeDuplicates(dat1);
					
					tableName.Add(uy[2].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[2].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "mapping") {
					
					if(tableName.Contains(uy[4].Replace("\"", "").Replace("dataName=", "")) != true) {
						
					
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					int colNum = variablesL[index].IndexOf(uy[2].Replace("\"", "").Replace("variables=", ""));
					
					List<string> hjh = new List<string>();
					foreach(string f in uy[3].Replace("\"", "").Replace("opt=", "").Replace("[", "").Replace("]", "").Split(',')) {
						hjh.Add(f);
					}
					
					dat1 = dataTransf.RemoveMissingValues(dat1, colNum);
					dat = dataTransf.map(dat1, colNum, hjh);
					
					tableName.Add(uy[4].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[4].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "filtering") {
					
					if(tableName.Contains(uy[4].Replace("\"", "").Replace("dataName=", "")) != true) {
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					int colNum = variablesL[index].IndexOf(uy[2].Replace("\"", "").Replace("variables=", ""));
					
					dat1 = dataTransf.RemoveMissingValues(dat1, colNum);
					dat = dataTransf.filtering(dat1, colNum, uy[3].Replace("\"", "").Replace("opt=", ""), uy[4].Replace("\"", "").Replace("opt2=", ""));
					
					tableName.Add(uy[4].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[4].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "variableSelection") {
					
					if(tableName.Contains(uy[3].Replace("\"", "").Replace("dataName=", "")) != true) {
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					
					List<int> hjh = new List<int>();
					string[] g = uy[2].Replace("\"", "").Replace("variables=", "").Replace("[", "").Replace("]", "").Split(',');
					foreach(string f in g) {
						int colNum = variablesL[index].IndexOf(f);
						hjh.Add(colNum);
					}
					dat = dataTransf.variablesSleection(dat1, hjh);
					
					tableName.Add(uy[3].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[3].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
				}
				
				if(uy[0] == "logTransform") {
					
					if(tableName.Contains(uy[4].Replace("\"", "").Replace("dataName=", "")) != true) {
					
					int index = tableName.IndexOf(uy[1].Replace("\"", "").Replace("data=", ""));
					List<List<string>> dat1 = data[index];
					
					int colNum = variablesL[index].IndexOf(uy[2].Replace("\"", "").Replace("variables=", ""));
					
					string option = uy[3].Replace("\"", "").Replace("opt=", "");
					
					dat1 = dataTransf.RemoveMissingValues(dat1, colNum);
					dat = dataTransf.TransformLog(dat1, colNum, option);
					
					tableName.Add(uy[4].Replace("\"", "").Replace("dataName=", ""));
					data.Add(dat);
					variablesL.Add(dat[0]);
					
					
					
					}
					
					else {
						MessageBox.Show(uy[4].Replace("\"", "").Replace("dataName=", "") + "tableName Already existed. ");
					}
					
					
					
				}
				
			}
			
			Import imj = new Import();
			PreviewForm pf = new PreviewForm();
			pf.datatable = imj.List2DataTable(dat);
			pf.ShowDialog();
			//PreviewForm pf = new PreviewForm();
			//pf.ShowDialog();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			try {
			if(comboBox1.Text == "Join") {
				JoinForm jf = new JoinForm();
				jf.variablesL = variablesL;
				jf.tableName = tableName;
				jf.ShowDialog();
				
				string data = jf.data1;
				string data2 = jf.data2;
				string data1Variable = jf.data1Variable;
				string data2Variable = jf.data2Variable;
				string joinData = jf.joinDataName;
				
				
				richTextBox1.Text += "\njoin " + "data1=\"" + data + "\" data2=\"" + data2 + "\" data1Variable=\"" + data1Variable + "\" data2Variable=\"" + data2Variable + "\" joinData=\"" + joinData + "\"";
				richTextBox2.Text += "\n" + joinData;
			}
			
			if(comboBox1.Text == "Remove Missing Values") {
				RemoveMissingForm rmf = new RemoveMissingForm();
				rmf.variablesL = variablesL;
				rmf.tableName = tableName;
				rmf.ShowDialog();
				
				string data = rmf.data;
				string variables = rmf.variables;
				string dataName = rmf.dataName;
				
				richTextBox1.Text += "\n" + "removeMissingValues " + "data=\"" + data + "\" variables=\"" + variables + "\" dataName=\"" + dataName + "\"";
				richTextBox2.Text += "\n" + dataName;
			}
			
			if(comboBox1.Text == "Replace Missing Values") {
				ReplaceMissingForm rmf = new ReplaceMissingForm();
				rmf.variablesL = variablesL;
				rmf.tableName = tableName;
				rmf.ShowDialog();
				
				string data = rmf.data;
				string variables = rmf.variables;
				string replaceString = rmf.replaceString;
				string dataName = rmf.dataName;
				
				richTextBox1.Text += "\n" + "replaceMissingValues" + " data=\"" + data + "\" variables=\"" + variables + "\" replaceString=\"" + replaceString + "\" dataName=\"" + dataName + "\"";
				richTextBox2.Text += "\n" + dataName;
			}
			
			if(comboBox1.Text == "Remove Duplicates") {
				RemoveDuplicatesForm1 rmf = new RemoveDuplicatesForm1();
				rmf.variablesL = variablesL;
				rmf.tableName = tableName;
				rmf.ShowDialog();
				
				string dataName = rmf.dataName;
				string data = rmf.data;
				richTextBox1.Text += "\nremoveDuplicates data=\"" + data + "\" dataName=\"" + dataName + "\"";
				richTextBox2.Text += "\n" + dataName;
			}
			
			if(comboBox1.Text == "Mapping") {
				MappingForm rmf = new MappingForm();
				rmf.variablesL = variablesL;
				rmf.tableName = tableName;
				rmf.ShowDialog();
				
				string dataName = rmf.dataName;
				string data = rmf.data;
				string variables = rmf.variables;
				List<string> values2 = rmf.values2;
				
				string opt = ""; int k = 0;
				foreach(string s in values2) {
					if(k > 0) opt = opt + "," + s;
					else opt = s;
					
					k++;
				}
				
				richTextBox1.Text += "\nmapping data=\"" + data + "\" variables=\"" + variables + "\" opt=\"[" + opt + "]\" dataName=\"" + dataName + "\"";
				richTextBox2.Text += "\n" + dataName;
			}
			
			if(comboBox1.Text == "Filtering") {
				FilteringForm rmf = new FilteringForm();
				rmf.variablesL = variablesL;
				rmf.tableName = tableName;
				rmf.variablesL = variablesL;
				rmf.ShowDialog();
				
				string dataName = rmf.dataName;
				string data = rmf.data;
				string variables = rmf.variables;
				string op = rmf.operat;
				string opf = rmf.operat2;
				
				richTextBox1.Text += "\nfiltering data=\"" + data + "\" variables=\"" + variables + "\" opt=\"" + op + "\" opt2=\"" + opf + "\" dataName=\"" + dataName + "\"";
				richTextBox2.Text += "\n" + dataName;
				
			}
			
			if(comboBox1.Text == "Variable Selection") {
				VariableSelectionForm rmf = new VariableSelectionForm();
				rmf.variablesL = variablesL;
				rmf.tableName = tableName;
				rmf.ShowDialog();
				
				string dataName = rmf.dataName;
				string data = rmf.data;
				List<string> variables = rmf.variables2;
				
				string opt = ""; int k = 0;
				foreach(string s in variables) {
					if(k > 0) opt = opt + "," + s;
					else opt = s;
					
					k++;
				}
				
				richTextBox1.Text += "\nvariableSelection data=\"" + data + "\" variables=\"[" + opt + "]\" dataName=\"" + dataName + "\"";
				richTextBox2.Text += "\n" + dataName;
			}
			
			if(comboBox1.Text == "Log Transform") {
				LogForm rmf = new LogForm();
				rmf.variablesL = variablesL;
				rmf.tableName = tableName;
				rmf.ShowDialog();
				
				string dataName = rmf.dataName;
				string data = rmf.data;
				string variables = rmf.variables;
				string o = rmf.logOption;
				
				richTextBox1.Text += "\nlogTransform data=\"" + data + "\" variables=\"" + variables + "\" opt=\"" + o + "\" dataName=\"" + dataName + "\"";
				richTextBox2.Text += "\n" + dataName;
			}
				
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
			
			
		void Button4Click(object sender, EventArgs e)
		{
			try {
			PreviewForm pf = new PreviewForm();
			//int g = 
			//pf.datatable = dt;
			pf.datatable = dt[listBox1.SelectedIndex];
			pf.ShowDialog();
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		void Button6Click(object sender, EventArgs e)
		{
			try {
				
			if(!listBox2.Items.Contains(textBox1.Text)) {
			listBox2.Items.Add(textBox1.Text);
			script.Add(richTextBox1.Text);
			scriptName.Add(textBox1.Text);
			   }
			
			else 
				MessageBox.Show("Name is duplicated or repeated");
			
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		void RichTextBox1TextChanged(object sender, EventArgs e)
		{
			try {
			string keywords = @"\b(join|data1|data2|data1Variable|data2Variable|jonData|removeMissingValues|data|variables|replaceMissingValues|replaceString|removeDuplicates|data|mapping|data|variables|opt|filtering|data|variables|opt|opt2|variableSelection|data|variables|logTransform|data|variable)\b";
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
		void ListBox2SelectedIndexChanged(object sender, EventArgs e)
		{
	
		}
		void ListBox2MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string it = listBox2.SelectedItem.ToString();
			int i = scriptName.IndexOf(it);
			string scr = script[i];
			
			ScriForm sf = new ScriForm();
			sf.data = scr;
			sf.ShowDialog();
			
			
		}
	}
}
