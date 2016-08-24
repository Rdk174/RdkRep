using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestIPAddressControl
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void ipAddressControl1_KeyDown( object sender, KeyEventArgs e )
      {
         Console.WriteLine( "KeyDown: {0}", e.KeyValue );
      }

      private void ipAddressControl1_KeyPress( object sender, KeyPressEventArgs e )
      {
         Console.WriteLine( "KeyPress: {0}", Convert.ToInt32( e.KeyChar ) );
      }

      private void ipAddressControl1_KeyUp( object sender, KeyEventArgs e )
      {
         Console.WriteLine( "KeyUp: {0}", e.KeyValue );
      }

      private void ipAddressControl1_PreviewKeyDown( object sender, PreviewKeyDownEventArgs e )
      {
         Console.WriteLine( "PreviewKeyDown: {0}", e.KeyValue );
      }
   }
}
