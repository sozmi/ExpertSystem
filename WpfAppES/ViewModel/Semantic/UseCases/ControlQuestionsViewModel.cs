using ClassLibraryES.semantic_es;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppES.Common;
using WpfAppES.Components.Semantic.UseCases;
using WpfAppES.ViewModel.BaseObjects;

namespace WpfAppES.ViewModel.Semantic.UseCases
{
    public class ControlQuestionsViewModel : BaseViewModel
    {
        public ControlQuestionsViewModel(List<Question> questions)
        {
            foreach (var ques in questions)
                _questions.Add(new(ques));

            SelectedItemChanged = new(PerformSelectedItemChanged);
            AddQuestion = new(PerformAddQuestion);
            RemoveQuestion = new(PerformRemoveQuestion);
            AddCase = new(PerformAddCase);
            RemoveCase = new(PerformRemoveCase);
        }

        public ObservableCollection<NodeQuestionViewModel> Questions { get => _questions; set => SetProperty(ref _questions, value); }
        private ObservableCollection<NodeQuestionViewModel> _questions = [];

        public RelayCommand SelectedItemChanged { get; private set; }
        private void PerformSelectedItemChanged(object? commandParameter)
        {
            if (commandParameter == null)
                return;

            if (commandParameter is CaseViewModel c)
            {
                SelectedCase = c;
                SelectedQuestion = null;
            }
            else if (commandParameter is NodeQuestionViewModel q)
            {
                SelectedCase = null;
                SelectedQuestion = q;
            }
            else
            {
                SelectedCase = null;
                SelectedQuestion = null;
            }
        }

        public CaseViewModel? SelectedCase { get => selectedCase; set => SetProperty(ref selectedCase, value); }
        private CaseViewModel? selectedCase;

        public NodeQuestionViewModel? SelectedQuestion { get => selectedQuestion; set => SetProperty(ref selectedQuestion, value); }
        private NodeQuestionViewModel? selectedQuestion;

        public RelayAction AddQuestion { get; private set; }

        private void PerformAddQuestion()
        {
            if (SelectedQuestion == null)
                Questions.Add(new(new("Не указан")));
            if (SelectedCase != null)
                SelectedCase.SubQuestions.Add(new(new("Не указан")));


        }

        public RelayCommand AddCase { get; private set; }
        private void PerformAddCase(object? commandParameter)
        {
            if (SelectedQuestion == null)
            {
                MessageBox.Show("Необходимо выбрать вопрос в который добавим ответ", "Ошибка");
                return;
            }

            string name = commandParameter == null ? "Новый ответ" : (string)commandParameter;
            Case c = new(name);
            CaseViewModel caseViewModel = new(c, SelectedQuestion);
            SelectedQuestion.Cases.Add(caseViewModel);
        }

        public RelayAction RemoveQuestion { get; private set; }

        private void PerformRemoveQuestion()
        {
            if (SelectedQuestion == null)
            {
                MessageBox.Show("Выберите вопрос для удаления", "Ошибка");
                return;
            }

            int index = Questions.IndexOf(SelectedQuestion);
            SelectedQuestion = null;
            Questions.RemoveAt(index);
        }

        public RelayAction RemoveCase { get; private set; }

        private void PerformRemoveCase()
        {
            if (SelectedCase == null)
            {
                MessageBox.Show("Выберите ответ для удаления", "Ошибка");
                return;
            }

            int indexQ = Questions.IndexOf(SelectedCase.Parent);
            int indexC = SelectedCase.Parent.Cases.IndexOf(SelectedCase);
            SelectedCase = null;
            Questions[indexQ].Cases.RemoveAt(indexC);
           
        }
    }
}
