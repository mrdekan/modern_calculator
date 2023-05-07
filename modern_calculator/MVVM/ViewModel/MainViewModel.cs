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
			/*DiscoveryViewCommand = new RelayCommand(o =>
			{
				CurrentView = DiscoveryVM;
			});*/
			//CloseCommand = new RelayCommand(o => ((Window)o).Close());
			//HideCommand = new RelayCommand(o => ((Window)o).WindowState = WindowState.Minimized);
		}
	}
}
