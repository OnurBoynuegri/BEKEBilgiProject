namespace BekEkProject
{
	public partial class Form1 : Form
	{
		private List<Employee> employees;
		private List<Work> works;
		private WorkAllocate workAllocate;
		public Form1()
		{
			InitializeComponent();
			InitializeData();
		}

		private void InitializeData()
		{
			employees = new List<Employee>
			{
				new Employee("Semih", "Kılıçsoy"),
				new Employee("Mert", "Günok"),
				new Employee("Rafa", "Silva"),
				new Employee("Ciro", "Immobile"),
				new Employee("Gabriel", "Paulista"),
				new Employee("Mustafa Erhan", "Hemikmoğlu")
			};

			works = new List<Work>
			{
				new Work("Job 1", 1),
				new Work("Job 2", 2),
				new Work("Job 3", 3),
				new Work("Job 4", 4),
				new Work("Job 5", 5),
				new Work("Job 6", 6)
			};

			workAllocate = new WorkAllocate(employees, works);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			var allocation = workAllocate.AllocateDilyWorks();

			listView1.Items.Clear();
			foreach (var item in allocation)
			{
				var listItem = new ListViewItem(item.Key.ToString());
				listItem.SubItems.Add(item.Value.ToString());
				listView1.Items.Add(listItem);
			}


			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
