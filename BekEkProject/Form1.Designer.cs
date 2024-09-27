namespace BekEkProject
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button1 = new Button();
			listView1 = new ListView();
			PersonName = new ColumnHeader();
			Task = new ColumnHeader();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(118, 81);
			button1.Name = "button1";
			button1.Size = new Size(94, 29);
			button1.TabIndex = 0;
			button1.Text = "Atama1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// listView1
			// 
			listView1.Columns.AddRange(new ColumnHeader[] { PersonName, Task });
			listView1.Location = new Point(96, 116);
			listView1.Name = "listView1";
			listView1.Size = new Size(540, 307);
			listView1.TabIndex = 1;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(listView1);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			ResumeLayout(false);
		}

		#endregion

		private Button button1;
		private ListView listView1;
		private ColumnHeader PersonName;
		private ColumnHeader Task;
	}
}
