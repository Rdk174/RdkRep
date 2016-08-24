namespace TestIPAddressControl
{
   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && ( components != null ) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.label1 = new System.Windows.Forms.Label();
         this.ipAddressControl1 = new IPAddressControlLib.IPAddressControl();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point( 12, 15 );
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size( 61, 13 );
         this.label1.TabIndex = 0;
         this.label1.Text = "IP Address:";
         // 
         // ipAddressControl1
         // 
         this.ipAddressControl1.AllowInternalTab = false;
         this.ipAddressControl1.AutoHeight = true;
         this.ipAddressControl1.BackColor = System.Drawing.SystemColors.Window;
         this.ipAddressControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.ipAddressControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
         this.ipAddressControl1.Location = new System.Drawing.Point( 79, 12 );
         this.ipAddressControl1.MinimumSize = new System.Drawing.Size( 87, 20 );
         this.ipAddressControl1.Name = "ipAddressControl1";
         this.ipAddressControl1.ReadOnly = false;
         this.ipAddressControl1.Size = new System.Drawing.Size( 87, 20 );
         this.ipAddressControl1.TabIndex = 1;
         this.ipAddressControl1.Text = "...";
         this.ipAddressControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler( this.ipAddressControl1_PreviewKeyDown );
         this.ipAddressControl1.KeyUp += new System.Windows.Forms.KeyEventHandler( this.ipAddressControl1_KeyUp );
         this.ipAddressControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.ipAddressControl1_KeyPress );
         this.ipAddressControl1.KeyDown += new System.Windows.Forms.KeyEventHandler( this.ipAddressControl1_KeyDown );
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size( 189, 45 );
         this.Controls.Add( this.ipAddressControl1 );
         this.Controls.Add( this.label1 );
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout( false );
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private IPAddressControlLib.IPAddressControl ipAddressControl1;
   }
}

