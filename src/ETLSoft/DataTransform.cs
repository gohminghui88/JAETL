/*
 * Created by SharpDevelop.
 * User: gohmi
 * Date: 01/10/2019
 * Time: 2:31 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ETLSoft
{
	/// <summary>
	/// Description of DataTransform.
	/// </summary>
	public class DataTransform
	{
		public DataTransform()
		{
		}
		
		public List<List<string>> join(List<List<string>> data1, List<List<string>> data2, int data1Num, int data2Num) {
		
			
			List<List<string>> result = new List<List<string>>();
			
			//for each row in data1
			foreach(List<string> row in data1) {
				
				//for each row in data2
				List<string> te = new List<string>();
				foreach(List<String> row2 in data2) {
					
					//row data1 and row data2 col match
					if(row[data1Num] == row2[data2Num]) {
						
						//join two row;
						//row2.RemoveAt(data2Num);
						te = row.Concat(row2).ToList();
						
						
						//add to results
						result.Add(te);
					}
				}
			}
			
			List<string> columns = result[0];
			List<string> res = new List<string>();
			int f = 0;
			foreach(string c in columns) {
				if(res.Contains(c) != true) {
					res.Add(c);
				}
				
				else 
					res.Add(c + f.ToString());
				
				f++;
			}
			
			result.RemoveAt(0);
			result.Insert(0, res);
			
			//return results;
			return result;
			
			
			
			
			
		}
		
		public List<List<string>> replaceMissingValues(List<List<string>> data, int colNum, string replace) {
			
			
			for(int i = 0; i < data.Count; i++) {
				
				if(data[i][colNum] == "" || data[i][colNum] == ".") {
					data[i][colNum] = replace;
				}
			}
			
			return data;
			
			
		}
		
		public List<List<string>> RemoveMissingValues(List<List<string>> data, int colNum) {
			
			
			List<List<string>> result = new List<List<string>>();
			
			foreach(List<string> row in data) {
				
				List<string> temp = row;
				
				int j = 0;
				
				if(colNum == -999) {
					if(row.Contains("") || row.Contains(".")) j = 0;
					else result.Add(temp);
				}
				
				else {
					if(row[colNum] == "" || row[colNum] == ".") j = 0;
					else result.Add(temp);
				}
			}
			
			return result;
			
			
		}
		
		public List<List<string>> TransformLog(List<List<string>> da, int colNum, string log) {
			
			
			for(int i = 0; i < da.Count; i++) {
				
				if(i > 0) {
				if(log == "log10")
					da[i][colNum] = Math.Log10(float.Parse(da[i][colNum])).ToString();
				else
					da[i][colNum] = Math.Log(float.Parse(da[i][colNum])).ToString();
				
				}
			}
			
			return da;
			
		
		}
		
		public List<List<string>> removeDuplicates(List<List<string>> data) {
			
			List<List<string>> results = new List<List<string>>();
			
			foreach(List<string> row in data) {
				if(!isInside(row, results))
					results.Add(row);
			}
			
			return results;
		}
		
		
		public bool isInside(List<string> da, List<List<string>> data) {
			foreach(List<string> row in data) {
				if(isEqual(da, row)) {
					return true;
				}
			}
			
			return false;
		}
		
		public bool isEqual(List<string> da, List<string> da2) {
		
			int w = 0;
			for(int i = 0; i < da2.Count; i++) {
				if(da[i] == da2[i]) {
					w = w + 1;
				}
			}
			
			if(w == da.Count) return true;
			
			return false;
		}
		/*
		public List<List<string>> removeDuplicates(List<List<string>> data) {
			
		}
		
		public bool isInside(List<string> l, 
		
		public List<List<string>> removeDuplicates(List<List<string>> data, int colNum) {
			
			//data.Distinct();
			List<List<string>> result = new List<List<string>>();
			
			
			foreach(List<string> row in data) {
				
				
				if(!isInside(row, result)) {
					result.Add(row);
				}
			}
			
			return data;
			
			
			
			
		}
		
		
		public bool isInside(List<string> k, List<List<string>> da) {
			
			foreach(List<string> d in da) {
				
				if (isEqual(d, k)) {
					return true;
				}
			}
			
			return false;
			
		}
		
		
		public bool isEqual(List<string> da, List<string> da2) {
			int er = 0;
			
			int i = 0;
			foreach(string d in da) {
				
				if(d == da2[i]) {
					er = er + 1;
				}
				
				i++;
			}
			
			if(er == da.Count) return true;
			else return false;
		}
		*/
		
		public List<List<string>> variablesSleection(List<List<string>> data, List<int> colNum) {
			
			
			List<List<string>> result = new List<List<string>>();
			
			foreach(List<string> row in data) {
				
				List<string> tj = new List<string>();
				foreach(int d in colNum) {
					tj.Add(row[d]);
				}
				
				result.Add(tj);
			}
			
			return result;
			
			
			
			
		}
		
		public List<List<string>> map(List<List<string>> data, int colNum, List<string> map) {
			
			
			List<List<string>> result = new List<List<string>>();
			
			// for each row in data
			foreach(List<string> row in data) {
				
				List<string> h = row;
				//foreach map in map
				foreach(string m in map) {
					string w = m.Split(':')[0];
					string e = m.Split(':')[1];
					
					if(h[colNum] == w) 
						h[colNum] = e;
				}
				
				result.Add(h);
			}
			
			return result;
			
		
		}
		
		public List<List<string>> filtering(List<List<string>> data, int colNum, string option, string option2) {
			
			
			List<List<string>> result = new List<List<string>>();
			List<string> columns = data[0];
			data.RemoveAt(0);
			foreach(List<string> row in data) {
				
				 if(option == ">=") {
					if(float.Parse(row[colNum]) >= float.Parse(option2)) {
						result.Add(row);
					}
				}
				
				if(option == "<=") {
					if(float.Parse(row[colNum]) <= float.Parse(option2)) {
						result.Add(row);
					}
				}
				
				if(option == ">") {
					float f = float.Parse(row[colNum]);
					float g = float.Parse(option2);
					if(float.Parse(row[colNum]) > float.Parse(option2)) {
						result.Add(row);
					}
				}
				
				if(option == "<") {
					if(float.Parse(row[colNum]) < float.Parse(option2)) {
						result.Add(row);
					}
				}
				
				if(option == "=") {
					if(float.Parse(row[colNum]) == float.Parse(option2)) {
						result.Add(row);
					}
				}
				 
			}
			
			result.Insert(0, columns);
			return result;
			
		
		}
	}
}
