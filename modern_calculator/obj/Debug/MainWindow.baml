   M S B A M L   `   `   `  ����L  Hmodern_calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:modern_calculatormodern_calculator  5   	   E AFluentWPF, Version=0.10.2.0, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF 5   	   S.clr-namespace:modern_calculator.MVVM.ViewModel modern_calculator.MVVM.ViewModel  5   	   "    modern_calculator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:modern_calculator     5   	   Efw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF     5   	   D	viewModel.clr-namespace:modern_calculator.MVVM.ViewModel     5   	   $	��810��5
   	   $	��660��6   
������ )  #SourceChord.FluentWPF.AcrylicWindow    Enabled  .    AcrylicWindowStyle$
 None=�5   	   (  "SourceChord.FluentWPF.AcrylicPanel   NoiseOpacity$ 0.005Q�5   	      TintOpacity$	 0.9Q�5   	      	TintColor$ Black��5   	      AcrylicAccentState$ TransparentGradient=�5   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency . 	 � DataContext	 5      4  .modern_calculator.MVVM.ViewModel.MainViewModel  5   
   .��5      �� .+�5   
   �� -   5        
 ��Name$
 Title��5   *   
������ ._�5      �� $��Right=�6    �� Orientation$ 
Horizontal=�69   $��25��6R   .+�5      �� -   5         ��Name$
 Hide��5      $��45��6+      TitleButtonTheme#��[  6I   ���#cccccc$	��−��6�   6�   �� 5      -   5        $ Close��5      $��45��6,   #��[  6K   
���  ��$��×��6�   6�   5      5      �� 5       $ 
Horizontal=�6   .+�5!      �� -   5         ��Name$
 Menu��5!      $	��775��6+   $	��240��68   .+�5"      	� $��
Calculator��6"   $��50��5#      
�������$��14(�5%        MenuButtonTheme#��[ 5&       d� 	IsChecked$
 TrueY�5(      ��5'      �� *CalculatorViewCommand+5(      	� 5)      $��Number systems��6"   $��50��5*      
�������$��14(�5,      #��[ 5-      ��5.      �� *NumSysViewCommand+	� 5/      $��Currency translator��6"   $��50��50      
�������$��14(�52      #��[ 53      ��54      �� *CurrTransViewCommand+	� 55      $��System monitor��6   $��50��56      
�������$��14(�58      #��[ 59      ��5:      �� *SysMonitorViewCommand+	� 5;      $��Notes��6   $��50��5<      
�������$��14(�5>      #��[ 5?      ��5@      �� *NotesViewCommand+	� 5A      $��Settings��6   $��50��5B      
�������$��14(�5D      #��[ 5E      ��5F      �� *SettingsViewCommand+5G      �� 5H      -   5         ��Name$ Content��5H   !   $	��410��6R   $	��775��6^   ��62   �� *CurrentView+6^   5I      5J      5K      