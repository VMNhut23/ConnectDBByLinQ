using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace QLSV2
{
	public partial class Form1 : Form
	{
		Student st = new Student();
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataStudentDataContext db = new DataStudentDataContext();
			var lst = (from st in db.Students select st).ToList();
			dataGridView1.DataSource = lst;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			DataStudentDataContext db = new DataStudentDataContext();
			st.id = textBox1.Text;
			st.fullname = textBox2.Text;
			st.dob = textBox3.Text;
			db.Students.InsertOnSubmit(st);
			db.SubmitChanges();
			button1_Click(sender, e);
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			int i;
			i = dataGridView1.CurrentRow.Index;
			textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
			textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
			textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
		}
	}
}
