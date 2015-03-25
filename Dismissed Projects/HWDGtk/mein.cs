using System;
using Gdk;
using Gtk;
using Pango;
using System.Data;
using System.Data.SqlClient;

namespace HWD
{
public class HWDGtk 
{
	private Gtk.Window myWin;
	private Button btn;
	private Button btn2;
	private Button btn3;
	private Button btn4;
	private Button btn5;
	private Notebook nb;
	private TreeView tv;
	private VBox vb;
	private Label lbPageS;
	private Table nbPageS;
	private Label lbPageA;
	private VBox nbPageA;
	private Entry txtScan;
	private Label lbScan;
	private MessageDialog msg;
	private ScrolledWindow swin;
	private ScrolledWindow swin2;
	private TreeStore store = null;
	private TreeStore storeT = null;
	private Statusbar sb;
	private Gtk.Window winH;
	private Label lblTitle;
	private VBox vb2;
	private string insys;
	private Gtk.Window winT;
	private VBox vb3;
	private VBox vb4;
	private Label lblTitleT;
	private TreeView tvT;
	private HBox hb3;
	private Entry txtName;
	private Entry txtUser;
	private Label lblName;
	private Label lblUser;
	private FontDescription newFont = FontDescription.FromString("Sans 24");
	
	public HWDGtk()
	{

		InitializeComponent();
	}
	private void InitializeComponent()
	{
		PopulateItems();
			
		myWin = new Gtk.Window("HWDGtk");
		myWin.SetDefaultSize (640, 480);
		
		vb = new VBox();
		nb = new Notebook();
		tv = new TreeView(store);
		lbPageS = new Label("Scan");
		nbPageS = new Table(3,2,false);
		lbPageA = new Label("Clients");
		nbPageA = new VBox(false,2);
		btn = new Button (Gtk.Stock.Find);
		btn.UseStock = true;
		btn2 = new Button ("Set Tech Personal");
		txtScan = new Entry();
		lbScan = new Label("Scan hostname:");
		swin = new ScrolledWindow(new Adjustment(600, 600, 800, 1, 1, 1), new Adjustment(400, 400, 800, 1, 1, 1));
		sb = new Statusbar();
		
	    	sb.Push (1, "Ready");
	    	sb.HasResizeGrip = true;

		btn.Clicked += new EventHandler (btn_click);
		
		btn2.Clicked += new EventHandler (btn2_click);

		nbPageS.Attach(lbScan, 0, 1, 0, 1);
		nbPageS.Attach(txtScan, 1, 2, 0, 1);
		nbPageS.Attach(btn, 2, 3, 0, 2);
		
		nbPageA.Add(btn2);
		
     		nb.AppendPage(nbPageS, lbPageS);
		nb.AppendPage(nbPageA, lbPageA);
		     	
		tv.HeadersVisible = true;
		tv.AppendColumn ("Computer Name", new CellRendererText (), "text", 0);
		tv.AppendColumn ("Model", new CellRendererText (), "text", 1);
		tv.AppendColumn ("Manufacturer", new CellRendererText (), "text", 2);
		tv.AppendColumn ("Serial Number", new CellRendererText (), "text", 3);
		tv.AppendColumn ("OS", new CellRendererText (), "text", 4);
		tv.RowActivated += new RowActivatedHandler(tvSelected);
		tv.ColumnsAutosize();
		tv.Reorderable = true;
		
		swin.HscrollbarPolicy = PolicyType.Automatic;
		swin.VscrollbarPolicy = PolicyType.Automatic;
		swin.Add(tv);
			
		vb.PackStart(nb, false, false, 1);
		vb.PackStart(swin, true, true, 1);
		vb.PackStart(sb, false, false, 1);
		
		myWin.Add(vb);
		myWin.DeleteEvent += new DeleteEventHandler(delete);
		myWin.ShowAll();	
	}
	private void PopulateItems()
	{
		store = new TreeStore (typeof (string), typeof (string), typeof (string), typeof (string), typeof (string));
		SqlCommand sqlcommand = new SqlCommand("SELECT ComputerName, Model, Manufacturer, SerialNumber, OS FROM HWD", Auth.sqlConn);
		SqlDataReader sqlrd = sqlcommand.ExecuteReader();
		while(sqlrd.Read())
			store.AppendValues(sqlrd.GetString(0), sqlrd.GetString(1), sqlrd.GetString(2), sqlrd.GetString(3), sqlrd.GetString(4));

		sqlrd.Close();
	}
	
	private void PopulateTechs()
	{
		storeT = new TreeStore (typeof (string), typeof (string), typeof (string));
		SqlCommand sqlcommand = new SqlCommand("SELECT * FROM TechPersonal", Auth.sqlConn);
		SqlDataReader sqlrd = sqlcommand.ExecuteReader();
		while(sqlrd.Read())
			storeT.AppendValues(sqlrd.GetInt32(0).ToString(), sqlrd.GetString(1), sqlrd.GetString(2));

		sqlrd.Close();
	}
		
	public void delete(object o , DeleteEventArgs args)
  	{
  		Auth.sqlConn.Close();
		myWin.Destroy();
		Application.Quit();
  	}
  	
  	void btn_click(object obj, EventArgs args)
	{
		msg = new MessageDialog(myWin, Gtk.DialogFlags.Modal, Gtk.MessageType.Warning, Gtk.ButtonsType.Ok, "Impossible to scan WMI, you are LINUX!!!");
  		msg.Response += new ResponseHandler(response);
  		msg.Run();
	}
	
	void response (object obj, ResponseArgs args)
	{
		//if (args.ResponseId == ResponseType.Ok)
		//	txtScan.Text = "OK";
		//else
		//	txtScan.Text = "DIE";
		msg.Destroy();
	}
	
	void tvSelected(object o, RowActivatedArgs args)
	{
		TreeView tv = (TreeView) o;
		TreeModel model = tv.Model;
		TreeIter iter;
		model.GetIter (out iter, args.Path);
		GLib.Value val = new GLib.Value();
		model.GetValue (iter, 0, ref val);
		sb.Push(0,(string) val);
		insys = (string) val;
		OpenDetails();
	}

	void OpenDetails()
	{
		winH = new Gtk.Window("Details " + insys);
		lblTitle = new Label("Details " + insys);
		vb2 = new VBox();
		
		lblTitle.ModifyFont(newFont);
		
		vb2.PackStart(lblTitle, false, false, 1);
		
		winH.Add(vb2);
		winH.ShowAll();	
	}
	
	void btn2_click (object obj, EventArgs args)
	{
		PopulateTechs();
		
		winT = new Gtk.Window("Technics");
		winT.SetDefaultSize (640, 480);
		lblTitleT = new Label("Technics");
		vb3 = new VBox();
		vb4 = new VBox();
		hb3 = new HBox();
		tvT = new TreeView(storeT);
		txtName = new Entry();
		txtUser = new Entry();
		lblUser = new Label("User:");
		lblName = new Label("Name:");
		btn3 = new Button(Gtk.Stock.Save);
		btn3.UseStock = true;
		btn4 = new Button(Gtk.Stock.Delete);
		btn4.UseStock = true;
		btn5 = new Button(Gtk.Stock.Close);
		btn5.UseStock = true;
		swin2 = new ScrolledWindow(new Adjustment(400, 400, 500, 1, 1, 1), new Adjustment(200, 200, 200, 1, 1, 1));
		
		lblTitleT.ModifyFont(newFont);
		
		btn3.Clicked += new EventHandler(btn3_Click);
		btn4.Clicked += new EventHandler(btn4_Click);
		btn5.Clicked += new EventHandler(btn5_Click);
		
		tvT.HeadersVisible = true;
		tvT.AppendColumn ("ID", new CellRendererText (), "text", 0);
		tvT.AppendColumn ("Username", new CellRendererText (), "text", 1);
		tvT.AppendColumn ("Name", new CellRendererText (), "text", 2);
		tvT.ColumnsAutosize();
		tvT.Reorderable = true;
		
		swin2.HscrollbarPolicy = PolicyType.Automatic;
		swin2.VscrollbarPolicy = PolicyType.Automatic;
		swin2.Add(tvT);
		
		vb4.Add(lblUser);
		vb4.Add(txtUser);
		vb4.Add(lblName);
		vb4.Add(txtName);
		
		hb3.PackStart(vb4, true, true, 1);
		hb3.PackStart(btn3, false, false, 1);
		hb3.PackStart(btn5, false, false, 1);
		
		vb3.PackStart(lblTitleT, false, false, 1);
		vb3.PackStart(swin2, true, true, 1);
		vb3.PackStart(btn4, false, false, 1);
		vb3.PackStart(hb3, false, false, 1);
		
		winT.Add(vb3);
		winT.ShowAll();	
	}
	
	private void btn5_Click(object sender, System.EventArgs e)
	{
		winT.Destroy();
	}
	
	private void btn4_Click(object sender, System.EventArgs e)
	{
		//if (this.lstTechs.SelectedIndices.Count > 0)
		//{
		//	SqlCommand sqlcommand = new SqlCommand("DELETE FROM TechPersonal WHERE ID = " + this.lstTechs.SelectedItems[0].SubItems[0].Text, Auth.sqlcon); 	
		//	sqlcommand.ExecuteNonQuery();
		//	PopulateTechs();
		//}
	}
	
	private void btn3_Click(object sender, System.EventArgs e)
	{
		if (txtUser.Text.Length > 1 && txtName.Text.Length > 1)
		{
			SqlCommand sqlcommand = new SqlCommand("INSERT INTO TechPersonal (Username, Name) values ('" + txtUser.Text +"', '" + txtName.Text +"')",  Auth.sqlConn); 	
			sqlcommand.ExecuteNonQuery();
			PopulateTechs();
		}
	}
}
}