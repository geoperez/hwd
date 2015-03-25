using System;
using Glade;
using Gtk;
using GtkSharp;
using System.Threading;
using System.Net;
using System.Net.Sockets;
public class CWD 
{
  static Gtk.Window meinWindow;
  static Gtk.Window newTicket;
  static Gtk.TreeView tickets;
  static System.Net.Sockets.TcpListener socket;
  static System.Threading.Thread th;
   ListStore store = new ListStore(typeof(string),typeof(string),typeof(string),typeof(string),typeof(string));
   
   
     void CreaConexion()
  {
   socket = new TcpListener(16000);
   socket.Start();
  // Console.WriteLine("d");
    th = new System.Threading.Thread(new ThreadStart(Listener));
    th.Start();
  }
    private void TryToFindServer()
  {
    System.Net.Sockets.Socket sockete = new System.Net.Sockets.Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp); 
    IPAddress ip = IPAddress.Parse("224.0.0.1");
    sockete.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip));
    sockete.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive,3);
    IPEndPoint ipep= new IPEndPoint(ip,5000);
    sockete.Connect(ipep);
    byte [] myname = System.Text.ASCIIEncoding.ASCII.GetBytes(System.Net.Dns.GetHostName());
    sockete.Send(myname,myname.Length,SocketFlags.None);
    sockete.Close();	
  }
  public static void  Listener()
  {
    // btnClose.Label="s";
    // Console.WriteLine("nsns");
    while(true)
    {
      System.Net.Sockets.Socket s = socket.AcceptSocket();
      
      byte [] data = new byte[256];      
      while(true)
      {
        int recived = s.Receive(data);
       // Console.WriteLine(System.Text.Encoding.ASCII.GetString(data));
      }
    }
  }
  CWD()
  {
     CreaConexion();
     TryToFindServer();
     Glade.XML xmlUI= new Glade.XML ("cwd.glade", "mein", null);
     Glade.XML xmlUI2= new Glade.XML ("cwd.glade", "newTicket", null);
     xmlUI.Autoconnect(this);
     xmlUI2.Autoconnect(this);    
     meinWindow = (Gtk.Window) xmlUI["mein"];
     newTicket = (Gtk.Window) xmlUI2["newTicket"];
     tickets  = (Gtk.TreeView) xmlUI["tickets"];   
     newTicket.Hide();  
     meinWindow.DeleteEvent+= new DeleteEventHandler(delete);
     
   tickets.AppendColumn("ID",new CellRendererText(),"text",0);
   tickets.AppendColumn("Kind",new CellRendererText(),"text",1);
   tickets.AppendColumn("Title",new CellRendererText(),"text",2);
   tickets.AppendColumn("Desc",new CellRendererText(),"text",3);
   tickets.AppendColumn("Status",new CellRendererText(),"text",4);
   tickets.ColumnsAutosize();  
   tickets.Model = store;
   meinWindow.ShowAll();
    
  }
  public void delete(object o , DeleteEventArgs args)
  {
    th.Abort();
    Application.Quit();
  }
  public void on_new_clicked(object o , EventArgs args)
  {
    newTicket.ShowAll();
    //Application.Quit();
  }
  public static void Main()
  {
    Application.Init();
    CWD t = new CWD();
    
    Application.Run();
  }
}