   M S B A M L   `   `   `  ����L  Hmodern_calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:modern_calculator.MVVM.Viewmodern_calculator.MVVM.View  5      8    2modern_calculator.MVVM.View.CurrencyTranslatorView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:modern_calculator.MVVM.View     5      .��5	      � .+�5
   
   �� .+�5      �� -   5          ��Name$  ErrorBorder_CurrTrans��5      
���  ��$
��Left=�6E    �� CornerRadius$ 10��6`   $��42��6r   $��10q�6~   $	��317��6�    �� Padding$ 1,0,0,0q�6�   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ CurrTrans_input��5      $	��250��67   $��40��5      $��Center=�5      $��1��5      $
��Left=�5         ModernTextBox#��[  5      .��6c    � 	Resources 5       �� 
TargetType �� Property �� Value��%f   '��       �� 5      " ��6$   .�5   "   ��  �@��CornerRadius$ 	10,0,0,10��6A   5      5      .��6-   5      �� 5      -   5        	 ��Name$	 From_CurrTrans��5      $��40��67   $��50��6C   $��0q�6N   ���#3d3d3d  theComboBox#���  6w     theComboBoxItem#���  6�   .@�5      �� .��6'   USD6,   �� 5      .��6'   EUR6,   �� 5      .��6'   JPY6,   �� 5      .��6'   UAH6,   5      5      5       �� 5!      -   5        
 ��Name$
 ErrorLabel_CurrTrans��5!      $��
10,-12,0,0q�66   
���  ��6]   �� 5"      $��	0,10,0,15q�6   $ 
Horizontal=�6,   .+�5#      �� -   5         ��Name$ Submit_CurrTrans��5#      $
��10,0q�63   ���#ff7929$��=��6V     ButtonTheme#��[ 6b   $��50��6�   $��80��6�   $��5��6�   $��3��6�   $
��Left=�6�   6�   �� 5$      -   5        $ Reverse_CurrTrans��5$      $
��10,0q�64   ���#242424$��↑↓��6W   #��[ 6d   $��50��6�   $��80��6�   $��5��6�   $��3��6�   $
��Left=�6�   6�   5%      �� 5&      $
��Left=�6   $ 10��60   $��42��6B   $��10q�6N   $	��317��6Z   $ 1,0,0,0q�6f   ._�5'      �� $ 
Horizontal=�6   .+�5(      �� -   5        $ CurrTrans_output��5(      $	��250��68   $��40��5)      $��Center=�5*      $��1��5+      $
��Left=�5,      #��[  5-      |�.  .��6S    5.      ��%f   '��       �� 5/      " ��6$   .�50   "   ��  �@��CornerRadius$ 	10,0,0,10��6A   51      52      .��6-   53      �� 54      -   5        $	 To_CurrTrans��54      $��40��65   $��60��6A   $��0q�6L   ���#3d3d3d#���  6u   #���  6�   |�.   J� 	AllowDrop . .@�55      �� .��6'   USD6,   �� 56      .��6'   EUR6,   �� 57      .��6'   JPY6,   �� 58      .��6'   UAH6,   59      5:      5;      5<      5=      5>      