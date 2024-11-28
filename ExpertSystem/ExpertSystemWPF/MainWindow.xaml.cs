using System.Windows;
using ESImplementer;

namespace ExpertSystemWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _selector;
        private ExpertSystemForCars _systemForCars;
        private int _numberGames;
        public MainWindow()
        {
            InitializeComponent();
            _systemForCars = new ExpertSystemForCars();
            _selector = 0;
            _numberGames = 0;
        }

        private void btnQuest_Click(object sender, RoutedEventArgs e)
        {
            if (_selector != 0)
                return;
            _selector = 1;
            tbResultAndAnswer.Text = string.Empty;
            tbQuestion.Text = string.Empty;
            tbQuestion.Text = $"{_systemForCars.GetQuestion(_selector)}\n";
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            BtnClickAnswer(false);
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        { 
            BtnClickAnswer(true);
        }

        private void BtnClickAnswer(bool answer)
        {
            if (_selector == 0)
                return;
            tbResultAndAnswer.Text += $"Вопрос {_selector} - {answer.ToString()}\n";
            _systemForCars.Answers[_selector - 1] = answer;
            TryGetResult();
            if (_selector == 0)
                return;
            _selector++;
            tbQuestion.Text += $"{_systemForCars.GetQuestion(_selector)}\n";
        }

        private void TryGetResult()
        {
            if (_selector != _systemForCars.CountQuestions)
                return;
            _numberGames++;
            tbResultAndAnswer.Text += $"Ответ: {_numberGames} - {_systemForCars.GetResult()}\n";
            _systemForCars = new ExpertSystemForCars();
            _selector = 0;
        }
    }
}