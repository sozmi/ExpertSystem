namespace WinFormsES
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            интерфейсToolStripMenuItem = new ToolStripMenuItem();
            пользовательToolStripMenuItem = new ToolStripMenuItem();
            видToolStripMenuItem = new ToolStripMenuItem();
            системаОбъясненийMenuItemUser = new ToolStripMenuItem();
            правилаMenuItemUser = new ToolStripMenuItem();
            экспертToolStripMenuItem = new ToolStripMenuItem();
            видToolStripMenuItem1 = new ToolStripMenuItem();
            правилаMenuItemExpert = new ToolStripMenuItem();
            переменныеMenuItemExpert = new ToolStripMenuItem();
            перечисленияMenuItemExpert = new ToolStripMenuItem();
            базаЗнанийToolStripMenuItem = new ToolStripMenuItem();
            логическаяToolStripMenuItem = new ToolStripMenuItem();
            продукционнаяToolStripMenuItem = new ToolStripMenuItem();
            семантическаяСетьToolStripMenuItem = new ToolStripMenuItem();
            фреймыToolStripMenuItem = new ToolStripMenuItem();
            panelUser = new Panel();
            splitContainerUser = new SplitContainer();
            groupBoxConsultation = new GroupBox();
            label1 = new Label();
            buttonStartConsultation = new Button();
            comboBoxGoal = new ComboBox();
            groupBoxExplanation = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBoxFiredRules = new GroupBox();
            treeViewFiredRules = new TreeView();
            groupBoxFacts = new GroupBox();
            listViewFacts = new ListView();
            groupBoxRules = new GroupBox();
            treeViewAllRules = new TreeView();
            panelExpert = new Panel();
            tableLayoutPanelExpert = new TableLayoutPanel();
            groupBoxEnums = new GroupBox();
            lbEnum = new ListBox();
            btnEditEnum = new Button();
            groupBoxRulesExp = new GroupBox();
            btnEditRules = new Button();
            tvRules = new TreeView();
            groupBoxVariables = new GroupBox();
            lbVariable = new ListBox();
            btnEditVariable = new Button();
            menuStrip1.SuspendLayout();
            panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerUser).BeginInit();
            splitContainerUser.Panel1.SuspendLayout();
            splitContainerUser.Panel2.SuspendLayout();
            splitContainerUser.SuspendLayout();
            groupBoxConsultation.SuspendLayout();
            groupBoxExplanation.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBoxFiredRules.SuspendLayout();
            groupBoxFacts.SuspendLayout();
            groupBoxRules.SuspendLayout();
            panelExpert.SuspendLayout();
            tableLayoutPanelExpert.SuspendLayout();
            groupBoxEnums.SuspendLayout();
            groupBoxRulesExp.SuspendLayout();
            groupBoxVariables.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(18, 18);
            menuStrip1.Items.AddRange(new ToolStripItem[] { интерфейсToolStripMenuItem, базаЗнанийToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(846, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // интерфейсToolStripMenuItem
            // 
            интерфейсToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { пользовательToolStripMenuItem, экспертToolStripMenuItem });
            интерфейсToolStripMenuItem.Name = "интерфейсToolStripMenuItem";
            интерфейсToolStripMenuItem.Size = new Size(93, 23);
            интерфейсToolStripMenuItem.Text = "Интерфейс";
            // 
            // пользовательToolStripMenuItem
            // 
            пользовательToolStripMenuItem.CheckOnClick = true;
            пользовательToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { видToolStripMenuItem });
            пользовательToolStripMenuItem.Name = "пользовательToolStripMenuItem";
            пользовательToolStripMenuItem.Size = new Size(206, 24);
            пользовательToolStripMenuItem.Text = "Пользователь";
            пользовательToolStripMenuItem.Click += пользовательToolStripMenuItem_Click;
            // 
            // видToolStripMenuItem
            // 
            видToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { системаОбъясненийMenuItemUser, правилаMenuItemUser });
            видToolStripMenuItem.Name = "видToolStripMenuItem";
            видToolStripMenuItem.Size = new Size(110, 24);
            видToolStripMenuItem.Text = "Вид";
            // 
            // системаОбъясненийMenuItemUser
            // 
            системаОбъясненийMenuItemUser.CheckOnClick = true;
            системаОбъясненийMenuItemUser.Name = "системаОбъясненийMenuItemUser";
            системаОбъясненийMenuItemUser.Size = new Size(219, 24);
            системаОбъясненийMenuItemUser.Text = "Система объяснений";
            системаОбъясненийMenuItemUser.Click += системаОбъясненийMenuItemUser_Click;
            // 
            // правилаMenuItemUser
            // 
            правилаMenuItemUser.CheckOnClick = true;
            правилаMenuItemUser.Name = "правилаMenuItemUser";
            правилаMenuItemUser.Size = new Size(219, 24);
            правилаMenuItemUser.Text = "Правила";
            правилаMenuItemUser.Click += правилаMenuItemUser_Click;
            // 
            // экспертToolStripMenuItem
            // 
            экспертToolStripMenuItem.CheckOnClick = true;
            экспертToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { видToolStripMenuItem1 });
            экспертToolStripMenuItem.Name = "экспертToolStripMenuItem";
            экспертToolStripMenuItem.Size = new Size(206, 24);
            экспертToolStripMenuItem.Text = "Эксперт";
            экспертToolStripMenuItem.Click += экспертToolStripMenuItem_Click;
            // 
            // видToolStripMenuItem1
            // 
            видToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { правилаMenuItemExpert, переменныеMenuItemExpert, перечисленияMenuItemExpert });
            видToolStripMenuItem1.Name = "видToolStripMenuItem1";
            видToolStripMenuItem1.Size = new Size(110, 24);
            видToolStripMenuItem1.Text = "Вид";
            // 
            // правилаMenuItemExpert
            // 
            правилаMenuItemExpert.CheckOnClick = true;
            правилаMenuItemExpert.Name = "правилаMenuItemExpert";
            правилаMenuItemExpert.Size = new Size(177, 24);
            правилаMenuItemExpert.Text = "Правила";
            правилаMenuItemExpert.Click += правилаMenuItemExpert_Click;
            // 
            // переменныеMenuItemExpert
            // 
            переменныеMenuItemExpert.CheckOnClick = true;
            переменныеMenuItemExpert.Name = "переменныеMenuItemExpert";
            переменныеMenuItemExpert.Size = new Size(177, 24);
            переменныеMenuItemExpert.Text = "Переменные";
            переменныеMenuItemExpert.Click += переменныеMenuItemExpert_Click;
            // 
            // перечисленияMenuItemExpert
            // 
            перечисленияMenuItemExpert.CheckOnClick = true;
            перечисленияMenuItemExpert.Name = "перечисленияMenuItemExpert";
            перечисленияMenuItemExpert.Size = new Size(177, 24);
            перечисленияMenuItemExpert.Text = "Перечисления";
            перечисленияMenuItemExpert.Click += перечисленияMenuItemExpert_Click;
            // 
            // базаЗнанийToolStripMenuItem
            // 
            базаЗнанийToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { логическаяToolStripMenuItem, продукционнаяToolStripMenuItem, семантическаяСетьToolStripMenuItem, фреймыToolStripMenuItem });
            базаЗнанийToolStripMenuItem.Name = "базаЗнанийToolStripMenuItem";
            базаЗнанийToolStripMenuItem.Size = new Size(100, 23);
            базаЗнанийToolStripMenuItem.Text = "База знаний";
            // 
            // логическаяToolStripMenuItem
            // 
            логическаяToolStripMenuItem.Name = "логическаяToolStripMenuItem";
            логическаяToolStripMenuItem.Size = new Size(213, 24);
            логическаяToolStripMenuItem.Text = "Логическая";
            // 
            // продукционнаяToolStripMenuItem
            // 
            продукционнаяToolStripMenuItem.Name = "продукционнаяToolStripMenuItem";
            продукционнаяToolStripMenuItem.Size = new Size(213, 24);
            продукционнаяToolStripMenuItem.Text = "Продукционная";
            // 
            // семантическаяСетьToolStripMenuItem
            // 
            семантическаяСетьToolStripMenuItem.Name = "семантическаяСетьToolStripMenuItem";
            семантическаяСетьToolStripMenuItem.Size = new Size(213, 24);
            семантическаяСетьToolStripMenuItem.Text = "Семантическая сеть";
            // 
            // фреймыToolStripMenuItem
            // 
            фреймыToolStripMenuItem.Name = "фреймыToolStripMenuItem";
            фреймыToolStripMenuItem.Size = new Size(213, 24);
            фреймыToolStripMenuItem.Text = "Фреймы";
            // 
            // panelUser
            // 
            panelUser.Controls.Add(splitContainerUser);
            panelUser.Dock = DockStyle.Fill;
            panelUser.Location = new Point(0, 27);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(846, 601);
            panelUser.TabIndex = 1;
            // 
            // splitContainerUser
            // 
            splitContainerUser.Dock = DockStyle.Fill;
            splitContainerUser.Location = new Point(0, 0);
            splitContainerUser.Name = "splitContainerUser";
            // 
            // splitContainerUser.Panel1
            // 
            splitContainerUser.Panel1.Controls.Add(groupBoxConsultation);
            // 
            // splitContainerUser.Panel2
            // 
            splitContainerUser.Panel2.Controls.Add(groupBoxExplanation);
            splitContainerUser.Panel2.Controls.Add(groupBoxRules);
            splitContainerUser.Size = new Size(846, 601);
            splitContainerUser.SplitterDistance = 282;
            splitContainerUser.TabIndex = 4;
            // 
            // groupBoxConsultation
            // 
            groupBoxConsultation.Controls.Add(label1);
            groupBoxConsultation.Controls.Add(buttonStartConsultation);
            groupBoxConsultation.Controls.Add(comboBoxGoal);
            groupBoxConsultation.Dock = DockStyle.Top;
            groupBoxConsultation.Location = new Point(0, 0);
            groupBoxConsultation.Name = "groupBoxConsultation";
            groupBoxConsultation.Size = new Size(282, 147);
            groupBoxConsultation.TabIndex = 0;
            groupBoxConsultation.TabStop = false;
            groupBoxConsultation.Text = "Консультация";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 22);
            label1.Name = "label1";
            label1.Size = new Size(132, 19);
            label1.TabIndex = 2;
            label1.Text = "Цели консультации";
            // 
            // buttonStartConsultation
            // 
            buttonStartConsultation.Anchor = AnchorStyles.Bottom;
            buttonStartConsultation.Location = new Point(27, 87);
            buttonStartConsultation.Name = "buttonStartConsultation";
            buttonStartConsultation.Size = new Size(222, 41);
            buttonStartConsultation.TabIndex = 1;
            buttonStartConsultation.Text = "Начать консультацию";
            buttonStartConsultation.UseVisualStyleBackColor = true;
            buttonStartConsultation.Click += buttonStartConsultation_Click;
            // 
            // comboBoxGoal
            // 
            comboBoxGoal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxGoal.FormattingEnabled = true;
            comboBoxGoal.Location = new Point(6, 54);
            comboBoxGoal.Name = "comboBoxGoal";
            comboBoxGoal.Size = new Size(270, 27);
            comboBoxGoal.TabIndex = 0;
            // 
            // groupBoxExplanation
            // 
            groupBoxExplanation.Controls.Add(tableLayoutPanel1);
            groupBoxExplanation.Dock = DockStyle.Fill;
            groupBoxExplanation.Location = new Point(0, 0);
            groupBoxExplanation.Name = "groupBoxExplanation";
            groupBoxExplanation.Size = new Size(560, 601);
            groupBoxExplanation.TabIndex = 1;
            groupBoxExplanation.TabStop = false;
            groupBoxExplanation.Text = "Система объяснений";
            groupBoxExplanation.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBoxFiredRules, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBoxFacts, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(554, 576);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBoxFiredRules
            // 
            groupBoxFiredRules.Controls.Add(treeViewFiredRules);
            groupBoxFiredRules.Dock = DockStyle.Fill;
            groupBoxFiredRules.Location = new Point(3, 3);
            groupBoxFiredRules.Name = "groupBoxFiredRules";
            groupBoxFiredRules.Size = new Size(548, 282);
            groupBoxFiredRules.TabIndex = 0;
            groupBoxFiredRules.TabStop = false;
            groupBoxFiredRules.Text = "Сработанные правила";
            // 
            // treeViewFiredRules
            // 
            treeViewFiredRules.Dock = DockStyle.Fill;
            treeViewFiredRules.Location = new Point(3, 22);
            treeViewFiredRules.Name = "treeViewFiredRules";
            treeViewFiredRules.Size = new Size(542, 257);
            treeViewFiredRules.TabIndex = 0;
            // 
            // groupBoxFacts
            // 
            groupBoxFacts.Controls.Add(listViewFacts);
            groupBoxFacts.Dock = DockStyle.Fill;
            groupBoxFacts.Location = new Point(3, 291);
            groupBoxFacts.Name = "groupBoxFacts";
            groupBoxFacts.Size = new Size(548, 282);
            groupBoxFacts.TabIndex = 1;
            groupBoxFacts.TabStop = false;
            groupBoxFacts.Text = "Установленные факты";
            // 
            // listViewFacts
            // 
            listViewFacts.Dock = DockStyle.Fill;
            listViewFacts.Location = new Point(3, 22);
            listViewFacts.Name = "listViewFacts";
            listViewFacts.Size = new Size(542, 257);
            listViewFacts.TabIndex = 1;
            listViewFacts.UseCompatibleStateImageBehavior = false;
            // 
            // groupBoxRules
            // 
            groupBoxRules.Controls.Add(treeViewAllRules);
            groupBoxRules.Dock = DockStyle.Fill;
            groupBoxRules.Location = new Point(0, 0);
            groupBoxRules.Name = "groupBoxRules";
            groupBoxRules.Size = new Size(560, 601);
            groupBoxRules.TabIndex = 4;
            groupBoxRules.TabStop = false;
            groupBoxRules.Text = "Все правила";
            groupBoxRules.Visible = false;
            // 
            // treeViewAllRules
            // 
            treeViewAllRules.Dock = DockStyle.Fill;
            treeViewAllRules.Location = new Point(3, 22);
            treeViewAllRules.Name = "treeViewAllRules";
            treeViewAllRules.Size = new Size(554, 576);
            treeViewAllRules.TabIndex = 0;
            // 
            // panelExpert
            // 
            panelExpert.Controls.Add(tableLayoutPanelExpert);
            panelExpert.Dock = DockStyle.Fill;
            panelExpert.Location = new Point(0, 27);
            panelExpert.Name = "panelExpert";
            panelExpert.Size = new Size(846, 601);
            panelExpert.TabIndex = 2;
            panelExpert.Visible = false;
            // 
            // tableLayoutPanelExpert
            // 
            tableLayoutPanelExpert.ColumnCount = 3;
            tableLayoutPanelExpert.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelExpert.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelExpert.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelExpert.Controls.Add(groupBoxEnums, 2, 0);
            tableLayoutPanelExpert.Controls.Add(groupBoxRulesExp, 1, 0);
            tableLayoutPanelExpert.Controls.Add(groupBoxVariables, 0, 0);
            tableLayoutPanelExpert.Dock = DockStyle.Fill;
            tableLayoutPanelExpert.Location = new Point(0, 0);
            tableLayoutPanelExpert.Name = "tableLayoutPanelExpert";
            tableLayoutPanelExpert.RowCount = 1;
            tableLayoutPanelExpert.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelExpert.Size = new Size(846, 601);
            tableLayoutPanelExpert.TabIndex = 1;
            // 
            // groupBoxEnums
            // 
            groupBoxEnums.Controls.Add(lbEnum);
            groupBoxEnums.Controls.Add(btnEditEnum);
            groupBoxEnums.Dock = DockStyle.Fill;
            groupBoxEnums.Location = new Point(565, 3);
            groupBoxEnums.Name = "groupBoxEnums";
            groupBoxEnums.Size = new Size(278, 595);
            groupBoxEnums.TabIndex = 0;
            groupBoxEnums.TabStop = false;
            groupBoxEnums.Text = "Перечисления";
            groupBoxEnums.Visible = false;
            // 
            // lbEnum
            // 
            lbEnum.Dock = DockStyle.Fill;
            lbEnum.FormattingEnabled = true;
            lbEnum.Location = new Point(3, 22);
            lbEnum.Name = "lbEnum";
            lbEnum.Size = new Size(272, 535);
            lbEnum.TabIndex = 2;
            // 
            // btnEditEnum
            // 
            btnEditEnum.Dock = DockStyle.Bottom;
            btnEditEnum.Location = new Point(3, 557);
            btnEditEnum.Name = "btnEditEnum";
            btnEditEnum.Size = new Size(272, 35);
            btnEditEnum.TabIndex = 1;
            btnEditEnum.Text = "Редактировать";
            btnEditEnum.UseVisualStyleBackColor = true;
            // 
            // groupBoxRulesExp
            // 
            groupBoxRulesExp.Controls.Add(btnEditRules);
            groupBoxRulesExp.Controls.Add(tvRules);
            groupBoxRulesExp.Dock = DockStyle.Fill;
            groupBoxRulesExp.Location = new Point(284, 3);
            groupBoxRulesExp.Name = "groupBoxRulesExp";
            groupBoxRulesExp.Size = new Size(275, 595);
            groupBoxRulesExp.TabIndex = 0;
            groupBoxRulesExp.TabStop = false;
            groupBoxRulesExp.Text = "Правила";
            groupBoxRulesExp.Visible = false;
            // 
            // btnEditRules
            // 
            btnEditRules.Dock = DockStyle.Bottom;
            btnEditRules.Location = new Point(3, 557);
            btnEditRules.Name = "btnEditRules";
            btnEditRules.Size = new Size(269, 35);
            btnEditRules.TabIndex = 1;
            btnEditRules.Text = "Редактировать";
            btnEditRules.UseVisualStyleBackColor = true;
            // 
            // tvRules
            // 
            tvRules.Dock = DockStyle.Fill;
            tvRules.Location = new Point(3, 22);
            tvRules.Name = "tvRules";
            tvRules.Size = new Size(269, 570);
            tvRules.TabIndex = 0;
            // 
            // groupBoxVariables
            // 
            groupBoxVariables.Controls.Add(lbVariable);
            groupBoxVariables.Controls.Add(btnEditVariable);
            groupBoxVariables.Dock = DockStyle.Fill;
            groupBoxVariables.Location = new Point(3, 3);
            groupBoxVariables.Name = "groupBoxVariables";
            groupBoxVariables.Size = new Size(275, 595);
            groupBoxVariables.TabIndex = 0;
            groupBoxVariables.TabStop = false;
            groupBoxVariables.Text = "Переменные";
            groupBoxVariables.Visible = false;
            // 
            // lbVariable
            // 
            lbVariable.BackColor = SystemColors.Window;
            lbVariable.Dock = DockStyle.Fill;
            lbVariable.FormattingEnabled = true;
            lbVariable.Location = new Point(3, 22);
            lbVariable.Name = "lbVariable";
            lbVariable.Size = new Size(269, 535);
            lbVariable.TabIndex = 2;
            // 
            // btnEditVariable
            // 
            btnEditVariable.Dock = DockStyle.Bottom;
            btnEditVariable.Location = new Point(3, 557);
            btnEditVariable.Name = "btnEditVariable";
            btnEditVariable.Size = new Size(269, 35);
            btnEditVariable.TabIndex = 1;
            btnEditVariable.Text = "Редактировать";
            btnEditVariable.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 628);
            Controls.Add(panelUser);
            Controls.Add(panelExpert);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "Экспертная система";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelUser.ResumeLayout(false);
            splitContainerUser.Panel1.ResumeLayout(false);
            splitContainerUser.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerUser).EndInit();
            splitContainerUser.ResumeLayout(false);
            groupBoxConsultation.ResumeLayout(false);
            groupBoxConsultation.PerformLayout();
            groupBoxExplanation.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBoxFiredRules.ResumeLayout(false);
            groupBoxFacts.ResumeLayout(false);
            groupBoxRules.ResumeLayout(false);
            panelExpert.ResumeLayout(false);
            tableLayoutPanelExpert.ResumeLayout(false);
            groupBoxEnums.ResumeLayout(false);
            groupBoxRulesExp.ResumeLayout(false);
            groupBoxVariables.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem интерфейсToolStripMenuItem;
        private ToolStripMenuItem пользовательToolStripMenuItem;
        private ToolStripMenuItem экспертToolStripMenuItem;
        private Panel panelUser;
        private Panel panelExpert;
        private GroupBox groupBoxConsultation;
        private Button buttonStartConsultation;
        private ComboBox comboBoxGoal;
        private Label label1;
        private GroupBox groupBoxExplanation;
        private ListView listViewFacts;
        private TreeView treeViewFiredRules;
        private GroupBox groupBoxRules;
        private TreeView treeViewAllRules;
        private ToolStripMenuItem видToolStripMenuItem;
        private ToolStripMenuItem системаОбъясненийMenuItemUser;
        private ToolStripMenuItem правилаMenuItemUser;
        private GroupBox groupBoxVariables;
        private Button btnEditVariable;
        private GroupBox groupBoxRulesExp;
        private Button btnEditRules;
        private TreeView tvRules;
        private GroupBox groupBoxEnums;
        private Button btnEditEnum;
        private ListBox lbVariable;
        private ListBox lbEnum;
        private ToolStripMenuItem видToolStripMenuItem1;
        private ToolStripMenuItem правилаMenuItemExpert;
        private ToolStripMenuItem переменныеMenuItemExpert;
        private ToolStripMenuItem перечисленияMenuItemExpert;
        private ToolStripMenuItem базаЗнанийToolStripMenuItem;
        private ToolStripMenuItem логическаяToolStripMenuItem;
        private ToolStripMenuItem продукционнаяToolStripMenuItem;
        private ToolStripMenuItem семантическаяСетьToolStripMenuItem;
        private ToolStripMenuItem фреймыToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanelExpert;
        private SplitContainer splitContainerUser;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBoxFiredRules;
        private GroupBox groupBoxFacts;
    }
}
