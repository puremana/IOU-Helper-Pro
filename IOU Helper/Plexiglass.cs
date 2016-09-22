using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

class Plexiglass : Form
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
        this.BackColor = Color.DarkGray;
        this.Opacity = 0.30;      // Tweak as desired
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
    private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Plexiglass
            // 
            this.ClientSize = new System.Drawing.Size(308, 212);
            this.Name = "Plexiglass";
            this.ResumeLayout(false);
    }

}