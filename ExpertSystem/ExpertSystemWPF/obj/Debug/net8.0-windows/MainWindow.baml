   M S B A M L   `   `   `  ����J  FExpertSystemWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ExpertSystemWPFExpertSystemWPF  5   	        ExpertSystemWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ExpertSystemWPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � 
�����f� � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��6* �6   �� 5      .+�5   
   �� -   5        $��btnQuest��5   u   $��0��6   $��1��6!   $��2��6.   $��50��6B   $	��100��6N   $��Center=�6Z   $��Вопрос��6�   $��20(�6�   
������6�   �� 5   
   -   5        $��
tbQuestion��5   i   $��0��6   $��0��6"   $��2��6/   
������$��20(�6[   $|�False��6{   �� 5   
   -   5        $��tbResultAndAnswer��5   ?   $��2��6   $��0��6$   $��24(�61   $|�False��6X   $��
ExtraBlack"�6j   $
��Wrap=�6�   �� 5   
   -   5        $��btnYes��5   �   $��2��6   $��1��6!   $
��Left=�6.   $��Center=�6I   $	��100��6d   $��50��6p   
������$
��Да��6�   $��20(�6�   6�   �� 5   
   -   5        $��btnNo��5   �   $��2��6   $��1��6!   $��Right=�6.   $��Center=�6J   $	��100��6e   $��50��6q   
������$��Нет��6�   $��20(�6�   6�   5      5      