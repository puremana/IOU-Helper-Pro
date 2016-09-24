using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public partial class Plexiglass : Form
{
    private Color gColor = Color.White;
    private IOU_Helper.TextConsole textConsole;
    //Make it click through
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

        //this.DoubleBuffered = true;
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

        int clientWidth = this.Width;
        int clientHeight = this.Height;

        //Statistics Panel
        int p1LocationWidth = Convert.ToInt32(clientWidth * 0.64);
        int p1LocationHeight = Convert.ToInt32(clientHeight * 0.60); //0.32
        int p1SizeWidth = Convert.ToInt32(clientWidth * 0.24);
        int p1SizeHeight = Convert.ToInt32(clientHeight * 0.19);

        panel1.Location = new System.Drawing.Point(p1LocationWidth, p1LocationHeight);
        panel1.Size = new System.Drawing.Size(p1SizeWidth, p1SizeHeight);

        //Console Panel
        int p2LocationHeight = Convert.ToInt32(clientHeight * 0.39);
        panelConsole.Location = new System.Drawing.Point(p1LocationWidth, p2LocationHeight);
        panelConsole.Size = new System.Drawing.Size(p1SizeWidth, p1SizeHeight);
        //textConsole.Location = new System.Drawing.Point(0, 20);
        //textConsole.Size = new System.Drawing.Size(p1SizeWidth, p1SizeHeight - 100);

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
    private Panel panel1;
    private Label label13;
    private Label label14;
    private Label label15;
    private Label label16;
    private Label label17;
    private Label label18;
    private Label label19;
    private Label label20;
    private Label label21;
    private Label label22;
    private Label label23;
    private Label label24;
    private Panel panelConsole;
    private Label labelConsole;
    private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);

    private void InitializeComponent()
    {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panelConsole = new System.Windows.Forms.Panel();
            this.labelConsole = new System.Windows.Forms.Label();
            this.textConsole = new IOU_Helper.TextConsole();
            this.panel1.SuspendLayout();
            this.panelConsole.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Location = new System.Drawing.Point(88, 462);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 325);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(100, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 38);
            this.label13.TabIndex = 23;
            this.label13.Text = "unknown";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(2, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(165, 38);
            this.label14.TabIndex = 22;
            this.label14.Text = "Best cards :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(100, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 38);
            this.label15.TabIndex = 21;
            this.label15.Text = "unknown";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(2, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 38);
            this.label16.TabIndex = 20;
            this.label16.Text = "Nets :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(100, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(131, 38);
            this.label17.TabIndex = 19;
            this.label17.Text = "unknown";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(2, 56);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(195, 38);
            this.label18.TabIndex = 18;
            this.label18.Text = "Mining NRG :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(100, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(131, 38);
            this.label19.TabIndex = 17;
            this.label19.Text = "unknown";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(2, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(179, 38);
            this.label20.TabIndex = 16;
            this.label20.Text = "Wood NRG :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(100, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(131, 38);
            this.label21.TabIndex = 15;
            this.label21.Text = "unknown";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(2, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(116, 38);
            this.label22.TabIndex = 14;
            this.label22.Text = "G/min :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(100, 2);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(131, 38);
            this.label23.TabIndex = 13;
            this.label23.Text = "unknown";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(2, 2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(131, 38);
            this.label24.TabIndex = 12;
            this.label24.Text = "XP/min :";
            // 
            // panelConsole
            // 
            this.panelConsole.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConsole.Controls.Add(this.textConsole);
            this.panelConsole.Controls.Add(this.labelConsole);
            this.panelConsole.Location = new System.Drawing.Point(88, 175);
            this.panelConsole.Name = "panelConsole";
            this.panelConsole.Size = new System.Drawing.Size(451, 233);
            this.panelConsole.TabIndex = 3;
            this.panelConsole.Paint += new System.Windows.Forms.PaintEventHandler(this.panelConsole_Paint);
            // 
            // labelConsole
            // 
            this.labelConsole.AutoSize = true;
            this.labelConsole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConsole.Location = new System.Drawing.Point(60, 2);
            this.labelConsole.Name = "labelConsole";
            this.labelConsole.Size = new System.Drawing.Size(129, 41);
            this.labelConsole.TabIndex = 1;
            this.labelConsole.Text = "Console";
            // 
            // textConsole
            // 
            this.textConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textConsole.Location = new System.Drawing.Point(3, 20);
            this.textConsole.Multiline = true;
            this.textConsole.Name = "textConsole";
            this.textConsole.Size = new System.Drawing.Size(443, 208);
            this.textConsole.TabIndex = 0;
            this.textConsole.TextChanged += new System.EventHandler(this.Plexiglass_Resize);
            // 
            // Plexiglass
            // 
            this.ClientSize = new System.Drawing.Size(1058, 877);
            this.Controls.Add(this.panelConsole);
            this.Controls.Add(this.panel1);
            this.Name = "Plexiglass";
            this.Load += new System.EventHandler(this.Plexiglass_Load);
            this.ResizeEnd += new System.EventHandler(this.Plexiglass_ResizeEnd);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelConsole.ResumeLayout(false);
            this.panelConsole.PerformLayout();
            this.ResumeLayout(false);

    }

    private void Plexiglass_Resize(object sender, EventArgs e)
    {

    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        if (panel1.BorderStyle == BorderStyle.FixedSingle)
        {
            int thickness = 2;
            int halfThickness = thickness / 2;
            using (Pen p = new Pen(Color.Black, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                          halfThickness,
                                                          panel1.ClientSize.Width - thickness,
                                                          panel1.ClientSize.Height - thickness));
            }
        }
    }

    private void Plexiglass_ResizeEnd(object sender, EventArgs e)
    {

    }

    private void panelConsole_Paint(object sender, PaintEventArgs e)
    {
        if (panelConsole.BorderStyle == BorderStyle.FixedSingle)
        {
            int thickness = 2;
            int halfThickness = thickness / 2;
            using (Pen p = new Pen(Color.Black, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                          halfThickness,
                                                          panelConsole.ClientSize.Width - thickness,
                                                          panelConsole.ClientSize.Height - thickness));
            }
        }
        
    }

    public Panel getConsole()
    {
        return panelConsole;
    }

    public void setColor (Color color) 
    {
        gColor = color;
        panel1.BackColor = color;
        panelConsole.BackColor = color;
    }

    private void Plexiglass_Load(object sender, EventArgs e)
    {
        textConsole.start(textConsole);
    }
}