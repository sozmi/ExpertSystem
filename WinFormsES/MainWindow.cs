namespace WinFormsES;

public partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();

        // Установка начального режима: пользователь
        SetUserMode();

        // Инициализация начального состояния пунктов меню
        InitializeMenuVisibility();
    }

    /// <summary>
    /// Инициализация начального состояния меню и групп
    /// </summary>
    private void InitializeMenuVisibility()
    {
        // Устанавливаем начальное состояние флажков и видимость групп
        пользовательToolStripMenuItem.Checked = true;
        экспертToolStripMenuItem.Checked = false;

        правилаMenuItemUser.Checked = false;
        системаОбъясненийMenuItemUser.Checked = false;
        правилаMenuItemExpert.Checked = false;
        переменныеMenuItemExpert.Checked = false;
        перечисленияMenuItemExpert.Checked = false;

        groupBoxExplanation.Visible = false;
        groupBoxRules.Visible = false;
        groupBoxVariables.Visible = false;
        groupBoxEnums.Visible = false;
    }

    /// <summary>
    /// Установка режима пользователя
    /// </summary>
    private void SetUserMode()
    {
        пользовательToolStripMenuItem.Checked = true;
        экспертToolStripMenuItem.Checked = false;

        panelUser.Visible = true;
        panelExpert.Visible = false;
    }

    /// <summary>
    /// Установка режима эксперта
    /// </summary>
    private void SetExpertMode()
    {
        пользовательToolStripMenuItem.Checked = false;
        экспертToolStripMenuItem.Checked = true;

        panelUser.Visible = false;
        panelExpert.Visible = true;
    }

    /// <summary>
    /// Обработка нажатия на пункт "Пользователь"
    /// </summary>
    private void пользовательToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SetUserMode();
    }

    /// <summary>
    /// Обработка нажатия на пункт "Эксперт"
    /// </summary>
    private void экспертToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SetExpertMode();
    }

    /// <summary>
    /// Обработка нажатия на пункт "Система объяснений" в режиме пользователя
    /// </summary>
    private void системаОбъясненийMenuItemUser_Click(object sender, EventArgs e)
    {
        if (системаОбъясненийMenuItemUser.Checked)
        {
            правилаMenuItemUser.Checked = false;
            groupBoxExplanation.Visible = true;
            groupBoxRules.Visible = false;
        }
        else
        {
            groupBoxExplanation.Visible = false;
        }
    }

    /// <summary>
    /// Обработка нажатия на пункт "Правила" в режиме пользователя
    /// </summary>
    private void правилаMenuItemUser_Click(object sender, EventArgs e)
    {
        if (правилаMenuItemUser.Checked)
        {
            системаОбъясненийMenuItemUser.Checked = false;
            groupBoxRules.Visible = true;
            groupBoxExplanation.Visible = false;
        }
        else
        {
            groupBoxRules.Visible = false;
        }
    }

    /// <summary>
    /// Обработка нажатия на пункт "Правила" в режиме эксперта
    /// </summary>
    private void правилаMenuItemExpert_Click(object sender, EventArgs e)
    {
        if (правилаMenuItemExpert.Checked)
        {
            groupBoxRulesExp.Visible = true;
        }
        else
        {
            groupBoxRulesExp.Visible = false;
        }
    }

    /// <summary>
    /// Обработка нажатия на пункт "Переменные"
    /// </summary>
    private void переменныеMenuItemExpert_Click(object sender, EventArgs e)
    {
        if (переменныеMenuItemExpert.Checked)
        {
            groupBoxVariables.Visible = true;
        }
        else
        {
            groupBoxVariables.Visible = false;
        }
    }

    /// <summary>
    /// Обработка нажатия на пункт "Перечисления"
    /// </summary>
    private void перечисленияMenuItemExpert_Click(object sender, EventArgs e)
    {
        if (перечисленияMenuItemExpert.Checked)
        {
            groupBoxEnums.Visible = true;
        }
        else
        {
            groupBoxEnums.Visible = false;
        }
    }

    /// <summary>
    /// Обработка нажатия на кнопку "Начать консультацию"
    /// </summary>
    private void buttonStartConsultation_Click(object sender, EventArgs e)
    {
        string selectedGoal = comboBoxGoal.SelectedItem?.ToString() ?? "Цель не выбрана";
        MessageBox.Show($"Консультация начата для цели: {selectedGoal}");
    }
}
