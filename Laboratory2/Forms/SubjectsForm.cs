using System.ComponentModel;
using System.Windows.Forms;
using Laboratory2.Models;
using Laboratory2.Repositories;

namespace Laboratory2.Forms
{
    public partial class SubjectsForm : Form
    {

        private readonly ISubjectsRepository _subjectsRepository;

        public SubjectsForm(ISubjectsRepository subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
            InitializeComponent();
            
            _subjectsRepository.All().ForEach(subject =>
            {
                var index = subjectList.Rows.Add(subject.Name);
                subjectList.Rows[index].Cells[0].Tag = subject;
            });
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _subjectsRepository.DeleteAll();
            for (int i = 0; i < subjectList.Rows.Count - 1; i++)
            {
                DataGridViewRow row = subjectList.Rows[i];
                if (row.Cells[0].Tag is Subject subject)
                {
                    subject.Name = row.Cells[0].Value.ToString();
                    _subjectsRepository.AddOrUpdate(subject);
                }
                else
                {
                    _subjectsRepository.AddOrUpdate(new Subject(row.Cells[0].Value.ToString()));
                }
            }
            base.OnClosing(e);
        }

    }
}