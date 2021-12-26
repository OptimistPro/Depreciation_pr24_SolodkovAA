using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Depreciation_pr24_SolodkovAA
{
	public partial class main_form : Form
	{
		public main_form()
		{
			InitializeComponent();
		}

		private void clear_Click(object sender, EventArgs e)
		{
			table.Rows.Clear();
			start.Text = "0";
			norm.Text = "0";
			finish.Text = "0";
			price_object.Value = 0;
			month.Value = 0;
		}

		private float depreciation(float price,int month)
		{
			return price / month;
		}



		private void calculate_Click(object sender, EventArgs e)
		{
			if(price_object.Value!=0&& month.Value != 0)
			{
				DateTime dt = dateTimeStart.Value;
				dt=dt.AddMonths(1);
				start.Text = dt.ToString("Y");
				dt = dt.AddMonths(System.Convert.ToInt32(month.Value)-1);
				finish.Text = dt.ToString("Y");

				float depreciation_sum = depreciation( System.Convert.ToSingle(price_object.Value), System.Convert.ToInt32(month.Value));
				float norm_depreciation = System.Convert.ToSingle(100/month.Value);
				norm.Text = System.Convert.ToString(Math.Round(norm_depreciation, 2));
				sum_a.Text = System.Convert.ToString(depreciation_sum);
				//double price = PMT(System.Convert.ToDouble(procent_credit.Value), System.Convert.ToInt32(month.Value), System.Convert.ToDouble(price_credit.Value));
				//price_month.Text = System.Convert.ToString(Math.Round(price,2)) +" Руб.";
				//price_general.Text = System.Convert.ToString(Math.Round(price * System.Convert.ToDouble(month.Value), 2)) + " Руб.";
				//price_overpayments.Text = System.Convert.ToString(Math.Round((price * System.Convert.ToDouble(month.Value)) - System.Convert.ToDouble(price_credit.Value), 2)) + " Руб.";

				//double price_o = System.Convert.ToDouble(price_credit.Value);
				//var rate = System.Convert.ToDouble(procent_credit.Value) / 100 / 12;
				table.Rows.Clear();
				dt = dateTimeStart.Value;
				float price = System.Convert.ToInt32(price_object.Value);
				float cumulative = 0;
				for (int i = 0;i< System.Convert.ToInt32(month.Value); i++)
				{
					table.Rows.Add();
					table.Rows[i].Cells[0].Value = i+1;
					dt = dt.AddMonths(1);
					table.Rows[i].Cells[1].Value = dt.ToString("Y");
					table.Rows[i].Cells[2].Value = Math.Round(price, 2);
					table.Rows[i].Cells[3].Value = Math.Round(depreciation_sum, 2);
					price -= depreciation_sum;
					table.Rows[i].Cells[4].Value = Math.Round(price, 2);
					cumulative += depreciation_sum;
					table.Rows[i].Cells[5].Value = Math.Round(cumulative, 2);

				}

			}
		}
	}
}
