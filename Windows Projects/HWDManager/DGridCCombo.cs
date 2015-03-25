using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HWD
{
	/// <summary>
	/// Summary description for DGridCCombo.
	/// </summary>
	// Derive class from DataGridTextBoxColumn
	public class DataGridComboBoxColumn : DataGridTextBoxColumn
	{
		// Hosted combobox control
		private ComboBox comboBox;
		private CurrencyManager cm;
		private int iCurrentRow;
		public bool errors;
    
		// Constructor - create combobox, 
		// register selection change event handler,
		// register lose focus event handler
		public DataGridComboBoxColumn()
		{
			this.cm = null;

			// Create combobox and force DropDownList style
			this.comboBox = new ComboBox();
			this.comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        
			// Add event handler for notification when combobox loses focus
			this.comboBox.Leave += new EventHandler(comboBox_Leave);
		}
    
		// Property to provide access to combobox 
		public ComboBox ComboBox
		{
			get { return comboBox; }
		}       
            
		// On edit, add scroll event handler, and display combobox
		protected override void Edit(System.Windows.Forms.CurrencyManager 
			source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly, 
			string instantText, bool cellIsVisible)
		{
			base.Edit(source, rowNum, bounds, readOnly, instantText, 
				cellIsVisible);

			if (!readOnly && cellIsVisible)
			{
				// Save current row in the DataGrid and currency manager 
				// associated with the data source for the DataGrid
				this.iCurrentRow = rowNum;
				this.cm = source;
    
				// Add event handler for DataGrid scroll notification
				this.DataGridTableStyle.DataGrid.Scroll 
					+= new EventHandler(DataGrid_Scroll);

				// Site the combobox control within the current cell
				this.comboBox.Parent = this.TextBox.Parent;
				Rectangle rect = 
					this.DataGridTableStyle.DataGrid.GetCurrentCellBounds();
				this.comboBox.Location = rect.Location;
				this.comboBox.Size = 
					new Size(this.TextBox.Size.Width, 
					this.comboBox.Size.Height);

				// Set combobox selection to given text
				this.comboBox.SelectedIndex =
					this.comboBox.FindStringExact(this.TextBox.Text);

				// Make the combobox visible and place on top textbox control
				this.comboBox.Show();
				this.comboBox.BringToFront();
				this.comboBox.Focus();
			}
		}

		// Given a row, get the value member associated with a row.  Use the
		// value member to find the associated display member by iterating 
		// over bound data source
		protected override object 
			GetColumnValueAtRow(System.Windows.Forms.CurrencyManager source, 
			int rowNum)
		{
			// Given a row number in the DataGrid, get the display member
			object obj =  base.GetColumnValueAtRow(source, rowNum);
        
			// Iterate through the data source bound to the ColumnComboBox
			CurrencyManager cm = (CurrencyManager) 
				(this.DataGridTableStyle.DataGrid.BindingContext[this.comboBox.DataSource]);
			// Assumes the associated DataGrid is bound to a DataView or 
			// DataTable 
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

		// Given a row and a display member, iterate over bound data source to 
		// find the associated value member.  Set this value member.
		protected override void 
			SetColumnValueAtRow(System.Windows.Forms.CurrencyManager source,
			int rowNum, object value)
		{
			object s = value;

			// Iterate through the data source bound to the ColumnComboBox
			CurrencyManager cm = (CurrencyManager) 
				(this.DataGridTableStyle.DataGrid.BindingContext[this.comboBox.DataSource]);
			// Assumes the associated DataGrid is bound to a DataView or 
			// DataTable 
			DataView dataview = ((DataView)cm.List);
			int i;

			for (i = 0; i < dataview.Count; i++)
			{
				if (s.Equals(dataview[i][this.comboBox.DisplayMember]))
					break;
			}

			// If set item was found return corresponding value, 
			// otherwise return DbNull.Value
			if(i < dataview.Count)
				s =  dataview[i][this.comboBox.ValueMember];
			else
				s = DBNull.Value;
        
			base.SetColumnValueAtRow(source, rowNum, s);
		}

		// On DataGrid scroll, hide the combobox
		private void DataGrid_Scroll(object sender, EventArgs e)
		{
			this.comboBox.Hide();
		}

		// On combobox losing focus, set the column value, hide the combobox,
		// and unregister scroll event handler
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
