/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 26/09/2019
 * Time: 11:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ETLSoft
{
	/// <summary>
	/// Description of PreviewForm.
	/// </summary>
	public partial class PreviewForm : Form
	{
		public DataTable datatable;
		public PreviewForm()
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
			try {
			dataGridView1.DataSource = datatable;
			}
			
			catch(Exception ex) {
				MessageBox.Show(ex.ToString());
			}
		}
		
		
		
	}
}
