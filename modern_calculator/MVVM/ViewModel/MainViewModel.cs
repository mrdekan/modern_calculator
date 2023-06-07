using modern_calculator.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace modern_calculator.MVVM.ViewModel
{
	internal class MainViewModel : ObservableObject
	{
		public RelayCommand CalculatorViewCommand { get; set; }
		public CalculatorViewModel CalculatorVM { get; set; }
		public RelayCommand NumSysViewCommand { get; set; }
		public NumSysViewModel NumSysVM { get; set; }
		public RelayCommand CurrTransViewCommand { get; set; }
		public CurrencyTranslatorViewModel CurrTransVM { get; set; }
        public RelayCommand SysMonitorViewCommand { get; set; }
        public SystemMonitorViewModel SysMonVM { get; set; }
        public RelayCommand NotesViewCommand { get; set; }
        public NotesViewModel NotesVM { get; set; }
		public RelayCommand SettingsViewCommand { get; set; }
		public SettingsViewModel SettingsVM { get; set; }
		private object _currentView;
		public object CurrentView
		{
			get { return _currentView; }
			set
			{
				_currentView = value;
				OnPropertyChanged();
			}
		}
		public MainViewModel()
		{
			CalculatorVM = new CalculatorViewModel();
			NumSysVM = new NumSysViewModel();
			CurrTransVM = new CurrencyTranslatorViewModel();
			SysMonVM = new SystemMonitorViewModel();
            NotesVM = new NotesViewModel();
			SettingsVM = new SettingsViewModel();
            CurrentView = CalculatorVM;
			CalculatorViewCommand = new RelayCommand(o =>
			{
				CurrentView = CalculatorVM;
			});
			NumSysViewCommand = new RelayCommand(o =>
			{
				CurrentView = NumSysVM;
			});
			CurrTransViewCommand = new RelayCommand(o =>
			{
				CurrentView = CurrTransVM;
			});
            SysMonitorViewCommand = new RelayCommand(o =>
            {
                CurrentView = SysMonVM;
            });
            NotesViewCommand = new RelayCommand(o =>
            {
                CurrentView = NotesVM;
            });
			SettingsViewCommand = new RelayCommand(o =>
			{
				CurrentView = SettingsVM;
			});
		}
	}
}
