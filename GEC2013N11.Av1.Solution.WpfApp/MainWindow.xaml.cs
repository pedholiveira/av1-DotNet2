using GEC2013N11.Av1.Solution.Domain.Contexto;
using GEC2013N11.Av1.Solution.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GEC2013N11.Aula05.Solution.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ContextoDB contexto;

        public MainWindow()
        {
            contexto = new ContextoDB();
            InicializarListaAlunos();
            InitializeComponent();

            CarregarGrid();
        }

        private void InicializarListaAlunos()
        {
            if(contexto.Aluno.Count() > 0)
            {
                return;
            }

            List<Aluno> alunos = new List<Aluno>()
            {
                new Aluno("Pedro", "da Silva", "Curso de Java", true),
                new Aluno("Renato", "Motta", "Curso de renatório", true),
                new Aluno("Luiz", "Marques", "Curso de .NET", true),
                new Aluno("Vaguinho", "Mello", "Curso de reinados", true),
            };

            foreach(Aluno aluno in alunos)
            {
                contexto.Aluno.Add(aluno);
                contexto.SaveChanges();
            }
        }

        private void salvar_btn_Click(object sender, RoutedEventArgs e)
        {
            resultado_label.Content = "Inserindo aluno...";
            Task.Run(() => resultado_label.Dispatcher.BeginInvoke(new Action(() => salvarAluno())));
        }

        private void salvarAluno()
        {
            Aluno aluno = new Aluno();
            aluno.Nome = nomeAluno_textBox.Text;
            aluno.Sobrenome = sobrenome_textBox.Text;
            aluno.NomeCurso = nomeCurso_textBox.Text;
            aluno.Ativo = ativo_check.IsChecked.Value;

            contexto.Aluno.Add(aluno);
            contexto.SaveChanges();
            CarregarGrid();

            resultado_label.Content = "Aluno inserido com sucesso!";
        }

        private void limpar_btn_Click(object sender, RoutedEventArgs e)
        {
            nomeAluno_textBox.Text = "";
            sobrenome_textBox.Text = "";
            nomeCurso_textBox.Text = "";
            ativo_check.IsChecked = true;
        }

        private async void CarregarGrid()
        {
            Task<List<Aluno>> task = Task.Run<List<Aluno>>(() => contexto.Aluno.ToList());
            alunosGrid.ItemsSource = await task;
        }

        private void alunosGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            contexto.SaveChanges();
        }
    }
}
