/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 02/10/2019
 * Time: 2:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ETLSoft
{
	partial class LoadForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button8;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button8 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
			"SQL Script",
			"CSV File",
			"Weka File"});
			this.comboBox1.Location = new System.Drawing.Point(130, 53);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 24);
			this.comboBox1.TabIndex = 0;
			this.comboBox1.Text = "CSV File";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(130, 25);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(422, 22);
			this.textBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "File: ";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(12, 335);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(888, 249);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(558, 25);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "browse";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(825, 590);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(744, 590);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "OK";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(231, 163);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 30;
			this.button4.Text = "Connect";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(126, 135);
			this.textBox6.Name = "textBox6";
			this.textBox6.PasswordChar = '%';
			this.textBox6.Size = new System.Drawing.Size(180, 22);
			this.textBox6.TabIndex = 29;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(126, 107);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(180, 22);
			this.textBox5.TabIndex = 28;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(126, 78);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 22);
			this.textBox4.TabIndex = 27;
			this.textBox4.Text = "3306";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(126, 50);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(180, 22);
			this.textBox3.TabIndex = 26;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(28, 138);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 25;
			this.label6.Text = "Passwords: ";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(28, 110);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 23);
			this.label5.TabIndex = 24;
			this.label5.Text = "User: ";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(29, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 23);
			this.label4.TabIndex = 23;
			this.label4.Text = "Port: ";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(29, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 23);
			this.label3.TabIndex = 22;
			this.label3.Text = "Database: ";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(126, 21);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(180, 22);
			this.textBox2.TabIndex = 21;
			this.textBox2.Text = "localhost";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(29, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 20;
			this.label2.Text = "Server: ";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(744, 294);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(148, 23);
			this.button6.TabIndex = 32;
			this.button6.Text = "Save To SQL Server";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(626, 294);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(112, 23);
			this.button7.TabIndex = 33;
			this.button7.Text = "Preview File";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBox6);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBox5);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Location = new System.Drawing.Point(12, 131);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 198);
			this.groupBox1.TabIndex = 34;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SQL";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(639, 25);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 35;
			this.button8.Text = "Save ";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.Button8Click);
			// 
			// LoadForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 625);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "LoadForm";
			this.Text = "LoadForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
