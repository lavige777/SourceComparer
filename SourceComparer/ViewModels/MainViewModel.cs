using System;
using System.IO;
using SourceComparer.Abstract.Commands;
using SourceComparer.Commands;

namespace SourceComparer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string newSourceFolder;
        private string oldSourceFolder;

        public INamedCommand CompareCommand => new NamedCommand(CanExecuteCompareCommand, ExecuteCompareCommand);

        public string NewSourceFolder
        {
            get => newSourceFolder;
            set
            {
                if (newSourceFolder == value)
                {
                    return;
                }
                newSourceFolder = value;
                OnPropertyChanged();
            }
        }

        public string OldSourceFolder
        {
            get => oldSourceFolder;
            set
            {
                if (oldSourceFolder == value)
                {
                    return;
                }
                oldSourceFolder = value;
                OnPropertyChanged();
            }
        }

        private bool CanExecuteCompareCommand(object obj)
        {
            return Directory.Exists(OldSourceFolder) && Directory.Exists(NewSourceFolder);
        }

        private void ExecuteCompareCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
