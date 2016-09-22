using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public partial class Plexiglass : Form
{
    //Make it click through
    public enum GWL
    {
        ExStyle = -20
    }

    public enum WS_EX
    {
        Transparent = 0x20,
        Layered = 0x80000
    }

    public enum LWA
    {
        ColorKey = 0x1,
        Alpha = 0x2
    }

    [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
    public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

    [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
    public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
    public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LWA dwFlags);

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        int wl = GetWindowLong(this.Handle, GWL.ExStyle);
        wl = wl | 0x80000 | 0x20;
        SetWindowLong(this.Handle, GWL.ExStyle, wl);
        SetLayeredWindowAttributes(this.Handle, 0, 128, LWA.Alpha);
    }

    public Plexiglass(Form tocover)
    {
        InitializeComponent();

        this.BackColor = Color.Red;
        this.Opacity = 0.1;      // Tweak as desired
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
    private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);

    private void InitializeComponent()
    {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            // Plexiglass
            // 
            this.ClientSize = new System.Drawing.Size(637, 602);
            this.Controls.Add(this.groupBox1);
            this.Name = "Plexiglass";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

    }
}