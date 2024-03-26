namespace ShahFileDissemination
{
    partial class StartupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ListenerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.workThreadLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ListenerCheckBox = new System.Windows.Forms.CheckBox();
            this.ListenerPortTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ListenerIPTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ConnectionsView = new ShahFileDissemination.SocketListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConnectionMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.requestShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.RemotePortTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RemoteIPTextBox = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.kThresholdTextBox = new System.Windows.Forms.TextBox();
            this.dPropagationTextBox = new System.Windows.Forms.TextBox();
            this.PrimeSizeLabel = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SecretTextBox = new System.Windows.Forms.TextBox();
            this.DisseminateBtn = new System.Windows.Forms.Button();
            this.ReceivedPolyListView = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RecPolyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewPolynomialBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.evaluateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sendScalarBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ReceivedScalarsListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RecScalarMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewScalarBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.reconstructPolynomialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.SharesListView = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RecSharesMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewShareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recoverSecretToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ConnectionMenuStrip.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.RecPolyMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.RecScalarMenuStrip.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.RecSharesMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListenerStatusLabel,
            this.workThreadLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(908, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ListenerStatusLabel
            // 
            this.ListenerStatusLabel.Name = "ListenerStatusLabel";
            this.ListenerStatusLabel.Size = new System.Drawing.Size(71, 17);
            this.ListenerStatusLabel.Text = "Listener: Off";
            // 
            // workThreadLabel
            // 
            this.workThreadLabel.Name = "workThreadLabel";
            this.workThreadLabel.Size = new System.Drawing.Size(121, 17);
            this.workThreadLabel.Text = "No background Work";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ListenerCheckBox);
            this.groupBox1.Controls.Add(this.ListenerPortTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ListenerIPTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 90);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listener";
            // 
            // ListenerCheckBox
            // 
            this.ListenerCheckBox.AutoSize = true;
            this.ListenerCheckBox.Location = new System.Drawing.Point(9, 68);
            this.ListenerCheckBox.Name = "ListenerCheckBox";
            this.ListenerCheckBox.Size = new System.Drawing.Size(86, 17);
            this.ListenerCheckBox.TabIndex = 4;
            this.ListenerCheckBox.Text = "Run Listener";
            this.ListenerCheckBox.UseVisualStyleBackColor = true;
            this.ListenerCheckBox.CheckedChanged += new System.EventHandler(this.ListenerCheckBox_CheckedChanged);
            // 
            // ListenerPortTextBox
            // 
            this.ListenerPortTextBox.Location = new System.Drawing.Point(78, 42);
            this.ListenerPortTextBox.MaxLength = 5;
            this.ListenerPortTextBox.Name = "ListenerPortTextBox";
            this.ListenerPortTextBox.Size = new System.Drawing.Size(37, 20);
            this.ListenerPortTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Listener Port:";
            // 
            // ListenerIPTextBox
            // 
            this.ListenerIPTextBox.Location = new System.Drawing.Point(78, 16);
            this.ListenerIPTextBox.MaxLength = 15;
            this.ListenerIPTextBox.Name = "ListenerIPTextBox";
            this.ListenerIPTextBox.Size = new System.Drawing.Size(91, 20);
            this.ListenerIPTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listener IP:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ConnectionsView);
            this.groupBox2.Controls.Add(this.ConnectBtn);
            this.groupBox2.Controls.Add(this.RemotePortTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.RemoteIPTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 375);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connections";
            // 
            // ConnectionsView
            // 
            this.ConnectionsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader12});
            this.ConnectionsView.ContextMenuStrip = this.ConnectionMenuStrip;
            this.ConnectionsView.FullRowSelect = true;
            this.ConnectionsView.HideSelection = false;
            this.ConnectionsView.Location = new System.Drawing.Point(9, 107);
            this.ConnectionsView.Name = "ConnectionsView";
            this.ConnectionsView.Size = new System.Drawing.Size(271, 262);
            this.ConnectionsView.TabIndex = 10;
            this.ConnectionsView.UseCompatibleStateImageBehavior = false;
            this.ConnectionsView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Node ID";
            this.columnHeader1.Width = 52;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Address";
            this.columnHeader2.Width = 126;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Role";
            this.columnHeader12.Width = 80;
            // 
            // ConnectionMenuStrip
            // 
            this.ConnectionMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestShareToolStripMenuItem,
            this.toolStripSeparator2,
            this.disconnectToolStripMenuItem});
            this.ConnectionMenuStrip.Name = "ConnectionMenuStrip";
            this.ConnectionMenuStrip.Size = new System.Drawing.Size(149, 54);
            // 
            // requestShareToolStripMenuItem
            // 
            this.requestShareToolStripMenuItem.Name = "requestShareToolStripMenuItem";
            this.requestShareToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.requestShareToolStripMenuItem.Text = "Request Share";
            this.requestShareToolStripMenuItem.Click += new System.EventHandler(this.requestShareToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectBtn.Location = new System.Drawing.Point(9, 78);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(271, 23);
            this.ConnectBtn.TabIndex = 9;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // RemotePortTextBox
            // 
            this.RemotePortTextBox.Location = new System.Drawing.Point(78, 52);
            this.RemotePortTextBox.MaxLength = 5;
            this.RemotePortTextBox.Name = "RemotePortTextBox";
            this.RemotePortTextBox.Size = new System.Drawing.Size(37, 20);
            this.RemotePortTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Remote Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Remote IP";
            // 
            // RemoteIPTextBox
            // 
            this.RemoteIPTextBox.Location = new System.Drawing.Point(78, 26);
            this.RemoteIPTextBox.MaxLength = 15;
            this.RemoteIPTextBox.Name = "RemoteIPTextBox";
            this.RemoteIPTextBox.Size = new System.Drawing.Size(91, 20);
            this.RemoteIPTextBox.TabIndex = 7;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.kThresholdTextBox);
            this.groupBox5.Controls.Add(this.dPropagationTextBox);
            this.groupBox5.Controls.Add(this.PrimeSizeLabel);
            this.groupBox5.Controls.Add(this.IDTextBox);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(289, 133);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Share Parameters";
            // 
            // kThresholdTextBox
            // 
            this.kThresholdTextBox.Location = new System.Drawing.Point(153, 75);
            this.kThresholdTextBox.Name = "kThresholdTextBox";
            this.kThresholdTextBox.Size = new System.Drawing.Size(44, 20);
            this.kThresholdTextBox.TabIndex = 7;
            this.kThresholdTextBox.Text = "0";
            this.kThresholdTextBox.TextChanged += new System.EventHandler(this.kThresholdTextBox_TextChanged);
            // 
            // dPropagationTextBox
            // 
            this.dPropagationTextBox.Location = new System.Drawing.Point(153, 49);
            this.dPropagationTextBox.Name = "dPropagationTextBox";
            this.dPropagationTextBox.Size = new System.Drawing.Size(44, 20);
            this.dPropagationTextBox.TabIndex = 6;
            this.dPropagationTextBox.Text = "0";
            this.dPropagationTextBox.TextChanged += new System.EventHandler(this.dPropagationTextBox_TextChanged);
            // 
            // PrimeSizeLabel
            // 
            this.PrimeSizeLabel.AutoSize = true;
            this.PrimeSizeLabel.Location = new System.Drawing.Point(153, 103);
            this.PrimeSizeLabel.Name = "PrimeSizeLabel";
            this.PrimeSizeLabel.Size = new System.Drawing.Size(13, 13);
            this.PrimeSizeLabel.TabIndex = 5;
            this.PrimeSizeLabel.Text = "0";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(153, 23);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(44, 20);
            this.IDTextBox.TabIndex = 4;
            this.IDTextBox.Text = "0";
            this.IDTextBox.TextChanged += new System.EventHandler(this.IDTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Node ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Size of Secret (bytes):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Secondary Threshold (k):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Propagation (d):";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.SecretTextBox);
            this.groupBox4.Controls.Add(this.DisseminateBtn);
            this.groupBox4.Location = new System.Drawing.Point(307, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(589, 314);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File (Dealer Secret)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SecretTextBox
            // 
            this.SecretTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SecretTextBox.Location = new System.Drawing.Point(9, 19);
            this.SecretTextBox.Multiline = true;
            this.SecretTextBox.Name = "SecretTextBox";
            this.SecretTextBox.Size = new System.Drawing.Size(567, 260);
            this.SecretTextBox.TabIndex = 3;
            // 
            // DisseminateBtn
            // 
            this.DisseminateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DisseminateBtn.Location = new System.Drawing.Point(501, 285);
            this.DisseminateBtn.Name = "DisseminateBtn";
            this.DisseminateBtn.Size = new System.Drawing.Size(75, 23);
            this.DisseminateBtn.TabIndex = 2;
            this.DisseminateBtn.Text = "Disseminate";
            this.DisseminateBtn.UseVisualStyleBackColor = true;
            this.DisseminateBtn.Click += new System.EventHandler(this.DisseminateBtn_Click);
            // 
            // ReceivedPolyListView
            // 
            this.ReceivedPolyListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceivedPolyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.ReceivedPolyListView.ContextMenuStrip = this.RecPolyMenuStrip;
            this.ReceivedPolyListView.FullRowSelect = true;
            this.ReceivedPolyListView.HideSelection = false;
            this.ReceivedPolyListView.Location = new System.Drawing.Point(6, 6);
            this.ReceivedPolyListView.MultiSelect = false;
            this.ReceivedPolyListView.Name = "ReceivedPolyListView";
            this.ReceivedPolyListView.Size = new System.Drawing.Size(566, 252);
            this.ReceivedPolyListView.TabIndex = 0;
            this.ReceivedPolyListView.UseCompatibleStateImageBehavior = false;
            this.ReceivedPolyListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Secret ID";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Node ID";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Parts";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "All Received";
            this.columnHeader10.Width = 80;
            // 
            // RecPolyMenuStrip
            // 
            this.RecPolyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewPolynomialBtn,
            this.evaluateToolStripMenuItem,
            this.toolStripSeparator1,
            this.sendScalarBtn});
            this.RecPolyMenuStrip.Name = "RecPolyMenuStrip";
            this.RecPolyMenuStrip.Size = new System.Drawing.Size(182, 76);
            // 
            // viewPolynomialBtn
            // 
            this.viewPolynomialBtn.Name = "viewPolynomialBtn";
            this.viewPolynomialBtn.Size = new System.Drawing.Size(181, 22);
            this.viewPolynomialBtn.Text = "View Polynomial";
            this.viewPolynomialBtn.Click += new System.EventHandler(this.viewPolynomialBtn_Click);
            // 
            // evaluateToolStripMenuItem
            // 
            this.evaluateToolStripMenuItem.Name = "evaluateToolStripMenuItem";
            this.evaluateToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.evaluateToolStripMenuItem.Text = "Evaluate Polynomial";
            this.evaluateToolStripMenuItem.Click += new System.EventHandler(this.evaluateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // sendScalarBtn
            // 
            this.sendScalarBtn.Name = "sendScalarBtn";
            this.sendScalarBtn.Size = new System.Drawing.Size(181, 22);
            this.sendScalarBtn.Text = "Send Scalar";
            this.sendScalarBtn.Click += new System.EventHandler(this.sendScalarBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(307, 332);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(589, 290);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ReceivedPolyListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(581, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Polynomials";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ReceivedScalarsListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(581, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scalars";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ReceivedScalarsListView
            // 
            this.ReceivedScalarsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceivedScalarsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader4});
            this.ReceivedScalarsListView.ContextMenuStrip = this.RecScalarMenuStrip;
            this.ReceivedScalarsListView.FullRowSelect = true;
            this.ReceivedScalarsListView.HideSelection = false;
            this.ReceivedScalarsListView.Location = new System.Drawing.Point(6, 6);
            this.ReceivedScalarsListView.Name = "ReceivedScalarsListView";
            this.ReceivedScalarsListView.Size = new System.Drawing.Size(569, 252);
            this.ReceivedScalarsListView.TabIndex = 1;
            this.ReceivedScalarsListView.UseCompatibleStateImageBehavior = false;
            this.ReceivedScalarsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Secret ID";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nodes Received From";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ready to Reconstruct";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Received Parts";
            this.columnHeader4.Width = 90;
            // 
            // RecScalarMenuStrip
            // 
            this.RecScalarMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewScalarBtn,
            this.reconstructPolynomialToolStripMenuItem});
            this.RecScalarMenuStrip.Name = "RecScalarMenuStrip";
            this.RecScalarMenuStrip.Size = new System.Drawing.Size(201, 48);
            // 
            // viewScalarBtn
            // 
            this.viewScalarBtn.Name = "viewScalarBtn";
            this.viewScalarBtn.Size = new System.Drawing.Size(200, 22);
            this.viewScalarBtn.Text = "View Scalars";
            this.viewScalarBtn.Click += new System.EventHandler(this.viewScalarBtn_Click);
            // 
            // reconstructPolynomialToolStripMenuItem
            // 
            this.reconstructPolynomialToolStripMenuItem.Name = "reconstructPolynomialToolStripMenuItem";
            this.reconstructPolynomialToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.reconstructPolynomialToolStripMenuItem.Text = "Reconstruct Polynomial";
            this.reconstructPolynomialToolStripMenuItem.Click += new System.EventHandler(this.reconstructPolynomialToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.SharesListView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(581, 264);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Shares";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // SharesListView
            // 
            this.SharesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SharesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.SharesListView.ContextMenuStrip = this.RecSharesMenuStrip;
            this.SharesListView.FullRowSelect = true;
            this.SharesListView.HideSelection = false;
            this.SharesListView.Location = new System.Drawing.Point(6, 3);
            this.SharesListView.MultiSelect = false;
            this.SharesListView.Name = "SharesListView";
            this.SharesListView.Size = new System.Drawing.Size(569, 258);
            this.SharesListView.TabIndex = 2;
            this.SharesListView.UseCompatibleStateImageBehavior = false;
            this.SharesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Secret ID";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Shares";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Ready to Recover";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Received Parts";
            this.columnHeader15.Width = 100;
            // 
            // RecSharesMenuStrip
            // 
            this.RecSharesMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewShareToolStripMenuItem,
            this.recoverSecretToolStripMenuItem});
            this.RecSharesMenuStrip.Name = "RecSharesMenuStrip";
            this.RecSharesMenuStrip.Size = new System.Drawing.Size(152, 48);
            // 
            // viewShareToolStripMenuItem
            // 
            this.viewShareToolStripMenuItem.Name = "viewShareToolStripMenuItem";
            this.viewShareToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.viewShareToolStripMenuItem.Text = "View Shares";
            this.viewShareToolStripMenuItem.Click += new System.EventHandler(this.viewShareToolStripMenuItem_Click);
            // 
            // recoverSecretToolStripMenuItem
            // 
            this.recoverSecretToolStripMenuItem.Name = "recoverSecretToolStripMenuItem";
            this.recoverSecretToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.recoverSecretToolStripMenuItem.Text = "Recover Secret";
            this.recoverSecretToolStripMenuItem.Click += new System.EventHandler(this.recoverSecretToolStripMenuItem_Click);
            // 
            // StartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 652);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartupForm";
            this.Text = "Share Dissemination";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartupForm_FormClosing);
            this.Load += new System.EventHandler(this.StartupForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ConnectionMenuStrip.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.RecPolyMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.RecScalarMenuStrip.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.RecSharesMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ListenerStatusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ListenerIPTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ListenerCheckBox;
        private System.Windows.Forms.TextBox ListenerPortTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox RemotePortTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RemoteIPTextBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button DisseminateBtn;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label8;
        protected internal SocketListView ConnectionsView;
        private System.Windows.Forms.Label PrimeSizeLabel;
        private System.Windows.Forms.TextBox SecretTextBox;
        private System.Windows.Forms.TextBox kThresholdTextBox;
        private System.Windows.Forms.TextBox dPropagationTextBox;
        protected internal System.Windows.Forms.ListView ReceivedPolyListView;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        protected internal System.Windows.Forms.ListView ReceivedScalarsListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ContextMenuStrip RecPolyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewPolynomialBtn;
        private System.Windows.Forms.ToolStripMenuItem sendScalarBtn;
        private System.Windows.Forms.ContextMenuStrip RecScalarMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewScalarBtn;
        private System.Windows.Forms.ToolStripMenuItem evaluateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem reconstructPolynomialToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ContextMenuStrip ConnectionMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem requestShareToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel workThreadLabel;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        public System.Windows.Forms.ListView SharesListView;
        private System.Windows.Forms.ContextMenuStrip RecSharesMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewShareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recoverSecretToolStripMenuItem;
    }
}

