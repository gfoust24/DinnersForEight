using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace DinnersForEight
{
	//TODO allow user manipulations of host exceptions (multiple months)?
	/*
		show next dinner - accept/decline option?
	 */
	public partial class Form1 : Form
	{
		public DataSet ds;
		public List<int[,]> history;
		public List<string> historyDate;
		string fileName = @"\dinnersforeight.xml", msg;

		public Form1()
		{
			InitializeComponent();
			openToolStripMenuItem_Click(new object(), new EventArgs());
			UpdateCellColors();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string path = Directory.GetCurrentDirectory() + fileName;
			System.IO.StreamReader file = new System.IO.StreamReader(path);
			//if save file exists, import data
			if (File.Exists(path))
			{
				System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(DinnersForEight));
				
				DinnersForEight projData = (DinnersForEight)reader.Deserialize(file);
				ds = projData.ds;
				historyDate = projData.historyDate;
				history = projData.getHistory();
			}
			else
			{
				//if save file is not found, create data structures
				MessageBox.Show("Save file not found. Ensure file is in same directory as program.\n" + path);

				DinnersForEight projData2 = new DinnersForEight();
				ds = projData2.ds;
				historyDate = projData2.historyDate;
				history = projData2.getHistory();
			}
			
			dgvUser.DataSource = ds;
			dgvUser.DataMember = "user";

			dgvMatchCount.DataSource = ds;
			dgvMatchCount.DataMember = "matchCount";

			UpdateCellColors();
			file.Close();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(DinnersForEight));

			System.IO.StreamWriter file = new System.IO.StreamWriter(Directory.GetCurrentDirectory() + fileName);
			writer.Serialize(file, new DinnersForEight(ds, history, historyDate));
			file.Close();
		}

		private void lsbDinnerSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lsbDinnerSelect.SelectedItem.ToString().Equals("<empty>"))
				return;

			int[,] dinner = history[lsbDinnerSelect.SelectedIndex];

			txtDinnerInfo.Text = "";
			for (int i = 0; i < dinner.GetLength(0); i++ )
			{
				txtDinnerInfo.Text += "Group " + (i + 1) + "\r\n";
				for (int j = 0; j < dinner.GetLength(1); j++)
				{
					if (dinner[i, j] != -1)
						txtDinnerInfo.Text += dgvUser.Rows[dinner[i, j]].Cells["Name"].Value + "\r\n";
				}
				txtDinnerInfo.Text += "\r\n";
			}
		}

		private void btnNextDinner_Click(object sender, EventArgs e)
		{
			List<int> users = new List<int>();
			for (int i = 0; i < ds.Tables["user"].Rows.Count; i++)
			{
				if (Convert.ToBoolean(ds.Tables["user"].Rows[i]["Active"]))
				{
					users.Add(i);
				}
			}
			int numUsers = users.Count;
			int numDinners = (numUsers + 2) / 4;
			int currentDinner;
			bool isSorted;
			List<int> remaining = new List<int>();
			int[,] hostedCountSorted, currDinnerGridTally = new int[2, numUsers];
			int[,] dinners = new int[numDinners, 5];
			string date = "";

			for (int i = 0; i < dinners.GetLength(0); i++)
			{
				for (int j = 0; j < dinners.GetLength(1); j++)
				{
					dinners[i, j] = -1;
				}
			}

			int to, from, temp1, temp2;

			//get date
			System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
			date = mfi.GetAbbreviatedMonthName(dateTimePicker1.Value.Month) + " " + dateTimePicker1.Value.Year;
			
			hostedCountSorted = new int[2, numUsers];
			for (int i = 0; i < numUsers; i++)
			{
				hostedCountSorted[0, i] = users[i];
				hostedCountSorted[1, i] = Convert.ToInt16(ds.Tables["user"].Rows[users[i]]["Host#"].ToString()) + 1;
			}

			//host month/active exceptions
			int dateMonth = dateTimePicker1.Value.Month;
			int userMonth;
			for (int i = 0; i < numUsers; i++)
			{
				userMonth = Convert.ToInt16(ds.Tables["user"].Rows[users[i]]["Month"]);
				if (userMonth == dateMonth)
				{
					hostedCountSorted[1, users[i]] = 0;
				}
				else if (userMonth != 0)
				{
					hostedCountSorted[1, users[i]] = Int16.MaxValue;
				}
			}

			//randomize
			Random rnd = new Random();

			for (int i = 0; i < numUsers * 2; i++)
			{
				to = rnd.Next(0, hostedCountSorted.GetLength(1));
				from = rnd.Next(0, hostedCountSorted.GetLength(1));
				temp1 = hostedCountSorted[0, to];
				temp2 = hostedCountSorted[1, to];
				hostedCountSorted[0, to] = hostedCountSorted[0, from];
				hostedCountSorted[1, to] = hostedCountSorted[1, from];
				hostedCountSorted[0, from] = temp1;
				hostedCountSorted[1, from] = temp2;
			}

			//sort
			do
			{
				isSorted = true;
				for (int i = 0; i < hostedCountSorted.GetLength(1) - 1; i++)
				{
					if (hostedCountSorted[1, i] > hostedCountSorted[1, i + 1])
					{
						//swap hosted values
						temp1 = hostedCountSorted[1, i];
						hostedCountSorted[1, i] = hostedCountSorted[1, i + 1];
						hostedCountSorted[1, i + 1] = temp1;
						//swap id
						temp1 = hostedCountSorted[0, i];
						hostedCountSorted[0, i] = hostedCountSorted[0, i + 1];
						hostedCountSorted[0, i + 1] = temp1;
						isSorted = false;
					}
				}
			} while (!isSorted);

			//choose the lowest x hosts, where x is the number of dinners
			for (int i = 0; i < numDinners; i++)
			{
				//update number of times user has hosted
				ds.Tables["user"].Rows[hostedCountSorted[0, i]]["Host#"] = Convert.ToInt16(ds.Tables["user"].Rows[hostedCountSorted[0, i]]["Host#"].ToString()) + 1;

				//add host id to dinner array
				dinners[i, 0] = hostedCountSorted[0, i];
			}

			//list of ids
			remaining = users; //(basically name change)
			
			//remove hosts from grid copy
			for (int i = 0; i < dinners.GetLength(0); i++)
			{
				remaining.Remove(dinners[i, 0]);
			}
			
			//for each person left, find them a group
			currentDinner = 0;
			while (remaining.Count > 0)
			{
				//get grid tally for all users according to people in current group
				currDinnerGridTally = new int[2, remaining.Count];
				for (int i = 0; i < dinners.GetLength(1); i++)
				{
					if (dinners[currentDinner, i] == -1)
						break;
					for (int j = 0; j < remaining.Count; j++)
					{
						currDinnerGridTally[0, j] = remaining[j];
						currDinnerGridTally[1, j] += Convert.ToInt16(ds.Tables["matchCount"].Rows[dinners[currentDinner, i]][remaining[j]]);
					}
				}

				//randomize
				for (int i = 0; i < currDinnerGridTally.GetLength(1) * 2; i++)
				{
					to = rnd.Next(0, currDinnerGridTally.GetLength(1));
					from = rnd.Next(0, currDinnerGridTally.GetLength(1));
					temp1 = currDinnerGridTally[0, to];
					temp2 = currDinnerGridTally[1, to];
					currDinnerGridTally[0, to] = currDinnerGridTally[0, from];
					currDinnerGridTally[1, to] = currDinnerGridTally[1, from];
					currDinnerGridTally[0, from] = temp1;
					currDinnerGridTally[1, from] = temp2;
				}

				//sort
				do
				{
					isSorted = true;
					for (int i = 0; i < currDinnerGridTally.GetLength(1) - 1; i++)
					{
						if (currDinnerGridTally[1, i] > currDinnerGridTally[1, i + 1])
						{
							//swap hosted values
							temp1 = currDinnerGridTally[1, i];
							currDinnerGridTally[1, i] = currDinnerGridTally[1, i + 1];
							currDinnerGridTally[1, i + 1] = temp1;
							//swap id
							temp1 = currDinnerGridTally[0, i];
							currDinnerGridTally[0, i] = currDinnerGridTally[0, i + 1];
							currDinnerGridTally[0, i + 1] = temp1;
							isSorted = false;
						}
					}
				} while (!isSorted);

				//find available spot (indicated by -1) and put new member in
				for (int k = 1; k < dinners.GetLength(1); k++)
				{
					if (dinners[currentDinner, k] == -1)
					{
						dinners[currentDinner, k] = currDinnerGridTally[0, 0];

						break;
					}
				}
				remaining.Remove(currDinnerGridTally[0, 0]);

				currentDinner = (currentDinner + 1) % numDinners;
			}

			//increase matched (grid) count
			//loop through dinners
			for (int i = 0; i < dinners.GetLength(0); i++)
			{
				for (int j = 0; j < dinners.GetLength(1); j++)
				{
					for (int k = 0; k < dinners.GetLength(1); k++)
					{
						if (!(j == k || dinners[i, j] == -1 || dinners[i, k] == -1))
						{
							ds.Tables["matchCount"].Rows[dinners[i, j]][dinners[i, k]] = Convert.ToInt16(ds.Tables["matchCount"].Rows[dinners[i, j]][dinners[i, k]]) + 1;
						}
					}
				}
			}

			history.Add(dinners);
			historyDate.Add(date);
			if (lsbDinnerSelect.Items[0].ToString().Equals("<empty>"))
				lsbDinnerSelect.Items.Clear();
			lsbDinnerSelect.Items.Add(date);

			UpdateCellColors();
		}
		
		private void dgvUser_RowValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (dgvUser.Rows.Count - 1 == dgvMatchCount.Rows.Count)
				return;
			DataColumn dc;
			
			//average host count
			int sum = 0;
			int count = ds.Tables["user"].Rows.Count;
			for (int i = 0; i < count; i++)
			{
				sum += Convert.ToInt16(ds.Tables["user"].Rows[i]["Host#"]);
			}
			sum /= count;
			ds.Tables["user"].Rows[e.RowIndex]["Host#"] = sum;

			//add row and column to match count
			dc = new DataColumn((ds.Tables["user"].Rows.Count).ToString(), typeof(Int16));
			dc.DefaultValue = 0;
			ds.Tables["matchCount"].Columns.Add(dc);
			ds.Tables["matchCount"].Rows.Add();
			ds.Tables["matchCount"].Rows[ds.Tables["matchCount"].Rows.Count - 1][ds.Tables["matchCount"].Columns.Count - 1] = Int16.MaxValue;

			UpdateCellColors();
		}

		private void UpdateCellColors()
		{
			int min = Int16.MaxValue, max = 0, curr;
			for (int i = 0; i < ds.Tables["matchCount"].Rows.Count; i++)
			{
				for (int j = 0; j < ds.Tables["matchCount"].Columns.Count; j++)
				{
					curr = Convert.ToInt16(ds.Tables["matchCount"].Rows[i][j]);
					if (curr != Int16.MaxValue)
					{
						max = Math.Max(max, curr);
						min = Math.Min(min, curr);
					}
				}
			}
			if (min > max)
				return;
			double spread = 510.0 / (max - min);
			
			int red, green;
			DataGridViewRow row;
			DataGridViewCellStyle style;
			for (int i = 0; i < dgvMatchCount.Rows.Count; i++)
			{
				row = dgvMatchCount.Rows[i];
				for (int j = 0; j < row.Cells.Count; j++)
				{
					curr = Convert.ToInt16(ds.Tables["matchCount"].Rows[i][j]);
					style = new DataGridViewCellStyle();
					if (curr != Int16.MaxValue)
					{
						curr -= min;
						if (Double.IsInfinity(spread))
						{
							red = 255;
							green = 255;
						}
						else
						{
							red = (int)(curr * spread);
							green = 510 - red;

							red = Math.Min(red, 255);
							green = Math.Min(green, 255);
						}

						style.BackColor = Color.FromArgb(red, green, 0);
						style.ForeColor = Color.Black;
					}
					else
					{
						style.ForeColor = Color.FromArgb(171, 171, 171);
						style.BackColor = Color.FromArgb(171, 171, 171);
					}
					row.Cells[j].Style = style;
				}
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 1)
			{
				//refresh dinner list
				if (historyDate.Count > 0)
				{
					lsbDinnerSelect.Items.Clear();
					foreach (String strDate in historyDate)
					{
						lsbDinnerSelect.Items.Add(strDate);
					}
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.Application.Exit();
		}

		private void dgvMatchCount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			UpdateCellColors();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult result = MessageBox.Show("Do you want to save before exiting?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				saveToolStripMenuItem_Click(sender, e);
			}
			else if (result == DialogResult.Cancel)
			{
				e.Cancel = true;
			}
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			UpdateCellColors();
		}

		private void dgvMatchCount_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
		{
			e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
		}
		
		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var maxCount = Int16.MinValue;
			var x = new System.Diagnostics.Stopwatch();
			
			x.Start();
			for (int i = 0; i < ds.Tables["matchCount"].Columns.Count; i++)
			{
				maxCount = Math.Max(maxCount, ds.Tables["matchCount"].AsEnumerable().Max(r => Convert.ToInt16(r[i])));
			}

			//for (int i = 0; i < ds.Tables["matchCount"].Columns.Count; i++)
			//{
			//	for (int j = 0; j < ds.Tables["matchCount"].Rows.Count; j++)
			//	{
					
			//		maxCount = Math.Max(maxCount, Convert.ToInt16(ds.Tables["matchCount"].Rows[j][i]));
			//	}
			//}
			x.Stop();
			MessageBox.Show(x.ElapsedTicks.ToString());
		}
	}

	public class DinnersForEight
	{
		public DataSet ds;
		public List<List<int[]>> history;
		public List<string> historyDate;

		public DinnersForEight()
		{
			DataTable dt;
			DataColumn dc;

			ds = new DataSet("ds");

			dt = new DataTable("user");
			dc = new DataColumn("ID", typeof(Int16));
			dc.AutoIncrement = true;
			dc.AutoIncrementSeed = 1;
			dt.Columns.Add(dc);
			dc = new DataColumn("Name", typeof(String));
			dt.Columns.Add(dc);
			dc = new DataColumn("Host#", typeof(Int16));
			dc.DefaultValue = 0;
			dc.AllowDBNull = false;
			dt.Columns.Add(dc);
			dc = new DataColumn("Active", typeof(Boolean));
			dc.DefaultValue = true;
			dc.AllowDBNull = false;
			dt.Columns.Add(dc);
			dc = new DataColumn("Month", typeof(Int16));
			dc.DefaultValue = 0;
			dc.AllowDBNull = false;
			dt.Columns.Add(dc);
			ds.Tables.Add(dt);

			dt = new DataTable("matchCount");
			ds.Tables.Add(dt);
			history = new List<List<int[]>>();
			historyDate = new List<string>();
		}

		public DinnersForEight(DataSet pds, List<int[,]> phistory, List<string> phistoryDate)
		{
			ds = pds;
			historyDate = phistoryDate;

			history = new List<List<int[]>>();
			int[] tempArray;
			List<int[]> tempList;
			for (int i = 0; i < phistory.Count; i++)
			{
				tempList = new List<int[]>();
				for (int j = 0; j < phistory[i].GetLength(0); j++)
				{
					tempArray = new int[phistory[i].GetLength(1)];
					for (int k = 0; k < phistory[i].GetLength(1); k++)
					{
						tempArray[k] = phistory[i][j, k];
					}
					tempList.Add(tempArray);
				}
				history.Add(tempList);
			}
		}

		public List<int[,]> getHistory()
		{
			List<int[,]> rHistory = new List<int[,]>();
			int[,] tempArray;
			for (int i = 0; i < history.Count; i++)
			{
				tempArray = new int[history[i].Count, history[i][0].GetLength(0)];
				for (int j = 0; j < history[i].Count; j++)
				{
					for (int k = 0; k < history[i][j].GetLength(0); k++)
					{
						tempArray[j, k] = history[i][j][k];
					}
				}
				rHistory.Add(tempArray);
			}
			return rHistory;
		}
	}
}
