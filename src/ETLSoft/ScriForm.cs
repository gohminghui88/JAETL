/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 11/10/2019
 * Time: 9:12 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ETLSoft
{
	/// <summary>
	/// Description of ScriForm.
	/// </summary>
	public partial class ScriForm : Form
	{
		public ScriForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		public string data;
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
		void Button2Click(object sender, EventArgs e)
		{
			richTextBox1.Text = data;
		}
	}
}
