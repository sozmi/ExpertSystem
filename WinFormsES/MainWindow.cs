namespace WinFormsES;

public partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();

        // ��������� ���������� ������: ������������
        SetUserMode();

        // ������������� ���������� ��������� ������� ����
        InitializeMenuVisibility();
    }

    /// <summary>
    /// ������������� ���������� ��������� ���� � �����
    /// </summary>
    private void InitializeMenuVisibility()
    {
        // ������������� ��������� ��������� ������� � ��������� �����
        ������������ToolStripMenuItem.Checked = true;
        �������ToolStripMenuItem.Checked = false;

        �������MenuItemUser.Checked = false;
        �����������������MenuItemUser.Checked = false;
        �������MenuItemExpert.Checked = false;
        ����������MenuItemExpert.Checked = false;
        ������������MenuItemExpert.Checked = false;

        groupBoxExplanation.Visible = false;
        groupBoxRules.Visible = false;
        groupBoxVariables.Visible = false;
        groupBoxEnums.Visible = false;
    }

    /// <summary>
    /// ��������� ������ ������������
    /// </summary>
    private void SetUserMode()
    {
        ������������ToolStripMenuItem.Checked = true;
        �������ToolStripMenuItem.Checked = false;

        panelUser.Visible = true;
        panelExpert.Visible = false;
    }

    /// <summary>
    /// ��������� ������ ��������
    /// </summary>
    private void SetExpertMode()
    {
        ������������ToolStripMenuItem.Checked = false;
        �������ToolStripMenuItem.Checked = true;

        panelUser.Visible = false;
        panelExpert.Visible = true;
    }

    /// <summary>
    /// ��������� ������� �� ����� "������������"
    /// </summary>
    private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SetUserMode();
    }

    /// <summary>
    /// ��������� ������� �� ����� "�������"
    /// </summary>
    private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SetExpertMode();
    }

    /// <summary>
    /// ��������� ������� �� ����� "������� ����������" � ������ ������������
    /// </summary>
    private void �����������������MenuItemUser_Click(object sender, EventArgs e)
    {
        if (�����������������MenuItemUser.Checked)
        {
            �������MenuItemUser.Checked = false;
            groupBoxExplanation.Visible = true;
            groupBoxRules.Visible = false;
        }
        else
        {
            groupBoxExplanation.Visible = false;
        }
    }

    /// <summary>
    /// ��������� ������� �� ����� "�������" � ������ ������������
    /// </summary>
    private void �������MenuItemUser_Click(object sender, EventArgs e)
    {
        if (�������MenuItemUser.Checked)
        {
            �����������������MenuItemUser.Checked = false;
            groupBoxRules.Visible = true;
            groupBoxExplanation.Visible = false;
        }
        else
        {
            groupBoxRules.Visible = false;
        }
    }

    /// <summary>
    /// ��������� ������� �� ����� "�������" � ������ ��������
    /// </summary>
    private void �������MenuItemExpert_Click(object sender, EventArgs e)
    {
        if (�������MenuItemExpert.Checked)
        {
            groupBoxRulesExp.Visible = true;
        }
        else
        {
            groupBoxRulesExp.Visible = false;
        }
    }

    /// <summary>
    /// ��������� ������� �� ����� "����������"
    /// </summary>
    private void ����������MenuItemExpert_Click(object sender, EventArgs e)
    {
        if (����������MenuItemExpert.Checked)
        {
            groupBoxVariables.Visible = true;
        }
        else
        {
            groupBoxVariables.Visible = false;
        }
    }

    /// <summary>
    /// ��������� ������� �� ����� "������������"
    /// </summary>
    private void ������������MenuItemExpert_Click(object sender, EventArgs e)
    {
        if (������������MenuItemExpert.Checked)
        {
            groupBoxEnums.Visible = true;
        }
        else
        {
            groupBoxEnums.Visible = false;
        }
    }

    /// <summary>
    /// ��������� ������� �� ������ "������ ������������"
    /// </summary>
    private void buttonStartConsultation_Click(object sender, EventArgs e)
    {
        string selectedGoal = comboBoxGoal.SelectedItem?.ToString() ?? "���� �� �������";
        MessageBox.Show($"������������ ������ ��� ����: {selectedGoal}");
    }
}
