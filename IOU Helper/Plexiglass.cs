using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public partial class Plexiglass : Form
{
    //Make it click through
    /// <summary>
    /// 0: the window is completely transparent ... 255: the window is opaque
    /// </summary>
    private byte _alpha;

    private enum GetWindowLong
    {
        /// <summary>
        /// Sets a new extended window style.
        /// </summary>
        GWL_EXSTYLE = -20
    }

    private enum ExtendedWindowStyles
    {
        /// <summary>
        /// Transparent window.
        /// </summary>
        WS_EX_TRANSPARENT = 0x20,
        /// <summary>
        /// Layered window. http://msdn.microsoft.com/en-us/library/windows/desktop/ms632599%28v=vs.85%29.aspx#layered
        /// </summary>
        WS_EX_LAYERED = 0x80000
    }

    private enum LayeredWindowAttributes
    {
        /// <summary>
        /// Use bAlpha to determine the opacity of the layered window.
        /// </summary>
        LWA_COLORKEY = 0x1,
        /// <summary>
        /// Use crKey as the transparency color.
        /// </summary>
        LWA_ALPHA = 0x20
    }

    [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
    private static extern int User32_GetWindowLong(IntPtr hWnd, GetWindowLong nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
    private static extern int User32_SetWindowLong(IntPtr hWnd, GetWindowLong nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
    private static extern bool User32_SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte bAlpha, LayeredWindowAttributes dwFlags);

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        //Click through
        int wl = User32_GetWindowLong(this.Handle, GetWindowLong.GWL_EXSTYLE);
        User32_SetWindowLong(this.Handle, GetWindowLong.GWL_EXSTYLE, wl | (int)ExtendedWindowStyles.WS_EX_LAYERED | (int)ExtendedWindowStyles.WS_EX_TRANSPARENT);
        //Change alpha
        User32_SetLayeredWindowAttributes(this.Handle, (TransparencyKey.B << 16) + (TransparencyKey.G << 8) + TransparencyKey.R, _alpha, LayeredWindowAttributes.LWA_COLORKEY | LayeredWindowAttributes.LWA_ALPHA);
    }

    public Plexiglass(Form tocover)
    {
        InitializeComponent();

        this.TransparencyKey = Color.Turquoise;
        this.BackColor = Color.Turquoise;
        this.Opacity = 0.9;      // Tweak as desired
        this.FormBorderStyle = FormBorderStyle.None;
        this.ControlBox = false;
        this.ShowInTaskbar = false;
        this.StartPosition = FormStartPosition.Manual;
        this.AutoScaleMode = AutoScaleMode.None;
        this.Location = tocover.PointToScreen(Point.Empty);
        this.ClientSize = tocover.ClientSize;
        tocover.LocationChanged += Cover_LocationChanged;
        tocover.ClientSizeChanged += Cover_ClientSizeChanged;
        this.Show(tocover);
        tocover.Focus();
        // Disable Aero transitions, the plexiglass gets too visible
        if (Environment.OSVersion.Version.Major >= 6)
        {
            int value = 1;
            DwmSetWindowAttribute(tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
        }
    }
    private void Cover_LocationChanged(object sender, EventArgs e)
    {
        // Ensure the plexiglass follows the owner
        this.Location = this.Owner.PointToScreen(Point.Empty);
    }
    private void Cover_ClientSizeChanged(object sender, EventArgs e)
    {
        // Ensure the plexiglass keeps the owner covered
        this.ClientSize = this.Owner.ClientSize;
    }
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        // Restore owner
        this.Owner.LocationChanged -= Cover_LocationChanged;
        this.Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
        if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
        {
            int value = 1;
            DwmSetWindowAttribute(this.Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
        }
        base.OnFormClosing(e);
    }
    protected override void OnActivated(EventArgs e)
    {
        // Always keep the owner activated instead
        this.BeginInvoke(new Action(() => this.Owner.Activate()));
    }

    private GroupBox groupBox1;
    private Label label2;
    private Label label1;
    private GroupBox groupBox2;
    private TextBox textBox2;
    private TextBox textBox1;
    private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);

    private void InitializeComponent()
    {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(80, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 333);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "blah";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Blah : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(508, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 333);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Console";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 48);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(391, 216);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 289);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(391, 38);
            this.textBox2.TabIndex = 1;
            // 
            // Plexiglass
            // 
            this.ClientSize = new System.Drawing.Size(1058, 877);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Plexiglass";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

    }
}