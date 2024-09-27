using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace BekProject2
{
	public partial class Form1 : Form
	{
		private List<Employee> employees;
		private List<Job> jobs;
		public Form1()
		{
			InitializeComponent();
			LoadEmployeesAndJobsFromDatabase();
		}

		private void LoadEmployeesAndJobsFromDatabase()
		{
			using (var context = new BekEbilgiDbContext())
			{
				employees = context.Employees.ToList();
				jobs = context.Jobs.ToList();
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		private void jobAssing_Click(object sender, EventArgs e)
		{
			JobAllocate jobAllocator = new JobAllocate(employees, jobs,new BekEbilgiDbContext());

			var dailyAllocations = jobAllocator.AllocateDailyJobs();

			jobAllocator.SaveAllocationsToDatabase(dailyAllocations);

			listView1.Items.Clear();
			foreach (var allocation in dailyAllocations)
			{
				ListViewItem item = new ListViewItem(allocation.Key.FirstName + " " + allocation.Key.LastName);
				item.SubItems.Add(allocation.Value.JobName + " (Difficulty: " + allocation.Value.Difficulty + ")");
				listView1.Items.Add(item);
			}


			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
		private void List_Click(object sender, EventArgs e)
		{
			using (var context = new BekEbilgiDbContext())
			{
				var employees = context.Employees.ToList();

				// Tüm çalışanlar için iş atamalarını tarih sırasına göre gruplandır
				var employeeJobAssignments = context.EmployeeJobs
					.GroupBy(ej => ej.EmployeeId)
					.Select(g => new
					{
						EmployeeId = g.Key,
						EmployeeName = g.FirstOrDefault().Employee.FirstName + " " + g.FirstOrDefault().Employee.LastName,
						Jobs = g.OrderBy(ej => ej.AssignedDate)
								.Select(ej => new
								{
									JobName = ej.Job.JobName,
									AssignedDate = ej.AssignedDate
								})
								.ToList()
					})
					.ToList();

				// İlk başta DataGridView sütunlarını temizle
				dataGridView1.Columns.Clear();

				// "Employee Name" başlıklı ilk sütunu ekle
				dataGridView1.Columns.Add("EmployeeName", "Çalışan İsmi");

				// En fazla gün sayısını bulalım (hangi çalışan en fazla gün iş almışsa o kadar sütun açacağız)
				int maxDays = employeeJobAssignments.Max(e => e.Jobs.Count);

				// Dinamik olarak gün sütunlarını ekle (1.gün, 2.gün, vs.)
				for (int i = 1; i <= maxDays; i++)
				{
					dataGridView1.Columns.Add("Day" + i, i + ". Gün");
				}

				// Satırları doldurma (her çalışanın yaptığı işleri ekleyelim)
				foreach (var employee in employeeJobAssignments)
				{
					var row = new DataGridViewRow();
					row.CreateCells(dataGridView1);

					// İlk hücreye çalışan ismini ekle
					row.Cells[0].Value = employee.EmployeeName;

					// Sonraki hücrelere o çalışanın yaptığı işleri gün sırasına göre ekle
					for (int i = 0; i < employee.Jobs.Count; i++)
					{
						row.Cells[i + 1].Value = employee.Jobs[i].JobName;
					}

					dataGridView1.Rows.Add(row);
				}
			}
		}
		private void Delete_Click(object sender, EventArgs e)
		{
			using (var context = new BekEbilgiDbContext())
			{
				// Tüm EmployeeJob kayıtlarını sil
				var allEmployeeJobs = context.EmployeeJobs.ToList();
				context.EmployeeJobs.RemoveRange(allEmployeeJobs);

				// Değişiklikleri kaydet
				context.SaveChanges();
			}
		}
		private Button List;
		private Button Delete;

		private void InitializeComponent()
		{
			List = new Button();
			Delete = new Button();
			listView1 = new ListView();
			PersonName = new ColumnHeader();
			Task = new ColumnHeader();
			dataGridView1 = new DataGridView();
			jobAssing = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// List
			// 
			List.Location = new Point(555, 201);
			List.Name = "List";
			List.Size = new Size(94, 29);
			List.TabIndex = 1;
			List.Text = "List";
			List.UseVisualStyleBackColor = true;
			List.Click += List_Click;
			// 
			// Delete
			// 
			Delete.Location = new Point(710, 201);
			Delete.Name = "Delete";
			Delete.Size = new Size(94, 29);
			Delete.TabIndex = 2;
			Delete.Text = "Sil";
			Delete.UseVisualStyleBackColor = true;
			Delete.Click += Delete_Click;
			// 
			// listView1
			// 
			listView1.Columns.AddRange(new ColumnHeader[] { PersonName, Task });
			listView1.Location = new Point(23, 217);
			listView1.Name = "listView1";
			listView1.Size = new Size(370, 301);
			listView1.TabIndex = 3;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(527, 236);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(564, 361);
			dataGridView1.TabIndex = 4;
			// 
			// jobAssing
			// 
			jobAssing.Location = new Point(32, 168);
			jobAssing.Name = "jobAssing";
			jobAssing.Size = new Size(94, 29);
			jobAssing.TabIndex = 5;
			jobAssing.Text = "JobAssign";
			jobAssing.UseVisualStyleBackColor = true;
			jobAssing.Click += jobAssing_Click;
			// 
			// Form1
			// 
			ClientSize = new Size(1103, 749);
			Controls.Add(jobAssing);
			Controls.Add(dataGridView1);
			Controls.Add(listView1);
			Controls.Add(Delete);
			Controls.Add(List);
			Name = "Form1";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}

		private ListView listView1;
		private ColumnHeader PersonName;
		private DataGridView dataGridView1;
		private ColumnHeader Task;
		private Button jobAssing;


	}
}
