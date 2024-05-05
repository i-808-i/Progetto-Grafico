using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria.AccessoDati;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProgettoGraficoTemperature
{
    public partial class Form1 : Form
    {
        List<CheckBoxListItem> list = new List<CheckBoxListItem>();
        string connection = "Provider=SQLOLEDB.1;Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=SiintTemp";
        DataConnection dc =  new DataConnection();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            string città = "";
            DateTime data;
            int temp = 0;
            int id = 0; 
            string str = "";
            int sql = 0;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            dtTime_Da.Visible = true;
            dtTime_A.Visible = true;   
            chkList_Luoghi.Visible = true;  

            
            
                using (OleDbConnection conn = dc.Connect(connection))
                {
                    using (StreamReader sr = new StreamReader("C:\\Users\\miche\\source\\repos\\ProgettoGraficoTemperature\\Temperature.csv"))
                    {
                        string currentLine;

                        while ((currentLine = sr.ReadLine()) != null)
                        {
                            città = currentLine.Split(';')[0];
                            data = DateTime.Parse(currentLine.Split(';')[1]);
                            temp = Convert.ToInt32(currentLine.Split(';')[2]);

                            OleDbDataReader reader = dc.ExecuteReader("SELECT TOP(1) IdCitta FROM AnaCitta ORDER BY IdCitta DESC", conn);
                            if (reader.Read())
                            {
                                str = reader.GetValue(0).ToString();
                                sql = Int32.Parse(str) + 1;
                            }

                            dc.Execute("IF NOT EXISTS (SELECT Nome FROM AnaCitta WHERE Nome = '" + città + "') INSERT INTO AnaCitta(IdCitta, Nome) VALUES ('" + sql + "','" + città + "')", conn);

                            OleDbCommand cmd = new OleDbCommand("SELECT IdCitta FROM AnaCitta WHERE Nome = '" + città + "'", conn);
                            id = (int)cmd.ExecuteScalar();

                            dc.Execute("IF NOT EXISTS (SELECT Data, IdCitta FROM Temperature WHERE Data = '" + data + "' AND IdCitta = '" + id + "') INSERT INTO Temperature(Data, IdCitta, TempMedia) VALUES ('" + data + "','" + id + "','" + temp + "') ELSE UPDATE Temperature SET TempMedia = '" + temp + "' WHERE Data = '" + data + "' AND IdCitta = '" + id + "'", conn);
                        }
                    }

                    chkList_Luoghi.Items.Clear();
                    DataTable dt3 = dc.Select("SELECT IdCitta, Nome FROM AnaCitta", conn);

                    for (int i = 0; i < dt3.Rows.Count; i++)
                    {
                        chkList_Luoghi.Items.Add(new CheckBoxListItem(RowUtilities.FieldInt32(dt3.Rows[i], "IdCitta"), RowUtilities.FieldString(dt3.Rows[i], "Nome")));
                    }

                    dc.Disconnect(conn);
                }
           
        }

        private void AddSeries(string name, DateTime[] x, double[] y)
        {
            Series series = new Series(name);
            series.ChartType = SeriesChartType.Line;
            series.Points.DataBindXY(x, y);
            LineChart_Temp.Series.Add(series);
        }

        private void dtTime_Da_ValueChanged(object sender, EventArgs e)
        {
            CreateLineChart();
        }

        private void dtTime_A_ValueChanged(object sender, EventArgs e)
        {
            CreateLineChart();
        }

        
        private void chkList_Luoghi_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Get the item that is about to change its check state
            CheckBoxListItem it = (CheckBoxListItem)chkList_Luoghi.Items[e.Index];

            // If the item is being checked, add it to the list
            if (e.NewValue == CheckState.Checked)
            {
                list.Add(it);
            }
            // If the item is being unchecked, remove it from the list
            else
            {
                list.Remove(it);
            }

            CreateLineChart();
        }

        private void CreateLineChart()
        {
            int i = 0;
            LineChart_Temp.Series.Clear();

            try
            {
                using (OleDbConnection conn = dc.Connect(connection))
                {
                    while (i < list.Count)
                    {
                        CheckBoxListItem item = list[i];
                        DataTable dt = dc.Select("SELECT * FROM Temperature WHERE Data >= '" + dtTime_Da.Value.ToString("dd/MM/yyyy") + "' AND Data <= '" + dtTime_A.Value.ToString("dd/MM/yyyy") + "' AND IdCitta = '" + item.IdCitta + "'", conn);

                        DateTime[] x = (from p in dt.AsEnumerable()
                                        orderby p.Field<DateTime>("Data") ascending
                                        select p.Field<DateTime>("Data")).ToArray();

                        double[] y = dt.AsEnumerable()
                        .OrderBy(p => p.Field<DateTime>("Data"))
                        .Select(p => p.Field<double>("TempMedia"))
                        .ToArray();


                        if (LineChart_Temp.Series.IsUniqueName(item._Nome))
                        {
                            AddSeries(item._Nome, x, y);

                        }

                        i++;

                    }
                    dc.Disconnect(conn);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            dtTime_Da.Visible = false;
            dtTime_A.Visible = false;
            chkList_Luoghi.Visible = false;
        }
    }
    class CheckBoxListItem
    {
        public int IdCitta;
        public string _Nome;
        public CheckBoxListItem(int IdCitta, string Nome)
        {
            this.IdCitta = IdCitta;
            this._Nome = Nome;
        }

        public override string ToString()
        {
            return _Nome;
        }
    }
}
