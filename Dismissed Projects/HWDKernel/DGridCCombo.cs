using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HWD.HWDKernel
{
	public class DataGridComboBoxColumn : DataGridTextBoxColumn
	{
		private ComboBox comboBox;
		private CurrencyManager cm;
		private int iCurrentRow;
		public bool errors;

		public DataGridComboBoxColumn()
		{
			this.cm = null;

			this.comboBox = new ComboBox();
			this.comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        
			this.comboBox.Leave += new EventHandler(comboBox_Leave);
		}
    
		public ComboBox ComboBox
		{
			get { return comboBox; }
		}       
            
		protected override void Edit(System.Windows.Forms.CurrencyManager 
			source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly, 
			string instantText, bool cellIsVisible)
		{
			base.Edit(source, rowNum, bounds, readOnly, instantText, 
				cellIsVisible);

			if (!readOnly && cellIsVisible)
			{
				this.iCurrentRow = rowNum;
				this.cm = source;
   
				this.DataGridTableStyle.DataGrid.Scroll += new EventHandler(DataGrid_Scroll);

				this.comboBox.Parent = this.TextBox.Parent;
				Rectangle rect = this.DataGridTableStyle.DataGrid.GetCurrentCellBounds();
				this.comboBox.Location = rect.Location;
				this.comboBox.Size = new Size(this.TextBox.Size.Width, this.comboBox.Size.Height);

				this.comboBox.SelectedIndex = this.comboBox.FindStringExact(this.TextBox.Text);

				this.comboBox.Show();
				this.comboBox.BringToFront();
				this.comboBox.Focus();
			}
		}

		protected override object GetColumnValueAtRow(System.Windows.Forms.CurrencyManager source, int rowNum)
		{
			object obj =  base.GetColumnValueAtRow(source, rowNum);
        
			CurrencyManager cm = (CurrencyManager) 
				(this.DataGridTableStyle.DataGrid.BindingContext[this.comboBox.DataSource]);

			DataView dataview = ((DataView)cm.List);
                            
			int i;

			for (i = 0; i < dataview.Count; i++)
			{
				if (obj.Equals(dataview[i][this.comboBox.ValueMember]))
					break;
			}
        
			if (i < dataview.Count)
				return dataview[i][this.comboBox.DisplayMember];
        
			return DBNull.Value;
		}

		protected override void 
			SetColumnValueAtRow(System.Windows.Forms.CurrencyManager source,
			int rowNum, object value)
		{
			object s = value;

			CurrencyManager cm = (CurrencyManager) 
				(this.DataGridTableStyle.DataGrid.BindingContext[this.comboBox.DataSource]);
			DataView dataview = ((DataView)cm.List);
			int i;

			for (i = 0; i < dataview.Count; i++)
			{
				if (s.Equals(dataview[i][this.comboBox.DisplayMember]))
					break;
			}

			if(i < dataview.Count)
				s =  dataview[i][this.comboBox.ValueMember];
			else
				s = DBNull.Value;
        
			base.SetColumnValueAtRow(source, rowNum, s);
		}

		private void DataGrid_Scroll(object sender, EventArgs e)
		{
			this.comboBox.Hide();
		}

		private void comboBox_Leave(object sender, EventArgs e)
		{
			try 
			{
				DataRowView rowView = (DataRowView) this.comboBox.SelectedItem;
				string s = (string) rowView.Row[this.comboBox.DisplayMember];

				SetColumnValueAtRow(this.cm, this.iCurrentRow, s);
				Invalidate();

				this.comboBox.Hide();
				this.DataGridTableStyle.DataGrid.Scroll -= 
					new EventHandler(DataGrid_Scroll);            
			}
			catch 
			{
				errors = true;
			}
		}
	}
}
