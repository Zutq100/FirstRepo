   M S B A M L   `   `   `  ����I  EFootballClubIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FootballClubIS.WindowsFootballClubIS.Windows  5   	   .    (FootballClubIS.Windows.AddOrUpdateWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:FootballClubIS.Windows     5   	   -   5          � Title$;  5Окно добавления и обновления��5   	   $	��300��6.   $	��400��6;   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF0C3644��6   � 5      $ 	#FF2FC5F9��6    � Offset$ 0.843Q�61   � 5      $ 	#FF185469��6   $ 0.291Q�61   � 5      $ 	#FF1F7FA0��6   $ 0.526Q�61   5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��	cmbSecond��5      $
��0,10q�6$   $��Bottom=�62   $��2��6M   $��50��6]   �� 5   
   -   5        $��cmbFirst��5      $��0��6#   $��2��63   $��0��6G   $��50��6T   $��Bottom=�6`   $
��0,10q�6{   $��10(�6�   �� 5   
   -   5         ��Name$ tbThird��5   )   ���	#FFD5F1FF$��1��6:   $��2��6G   $��35��6W   $��Bottom=�6c   �� 5   
   -   5        $ tbSecond��5   )   ���	#FFD5F1FF$��1��6;   $��1��6H   $��35��6X   $��Bottom=�6d   �� 5    
   -   5        $ tbFirst��5    )   ���	#FFD5F1FF$��1��6;   $��35��6H   $��Bottom=�6T   �� 5!   
   -   5        $��	lblPlayer��5!      $y�	Collapsed=�6!   $+��%Выберите футболиста��68   $��2��6V   $��Center=�6j   
�������6�   �� 5"   
   -   5        $��lblTeam��5"      $y�	Collapsed=�6   $#��Выберите состав��66   $��2��6P   $��Center=�6`   
�������6}   �� 5#   
   -	   5        $��lblFullName��5#      $y�	Collapsed=�6#   $��Введите ФИО��6:   $��1��6P   $��Center=�6]   $��Center=�6z   
�������6�   �� 5$   
   -
   5        $��	lblNumber��5$      $y�	Collapsed=�6!   $��Введите номер��68   $��1��6P   $��1��6]   $��Center=�6m   $��Center=�6�   
�������6�   �� 5%   
   -   5        $��lblPosition��5%      $y�	Collapsed=�6#   $#��Введите позицию��6:   $��1��6T   $��2��6a   $��Center=�6q   $��Center=�6�   
�������6�   �� 5&   
   -   5         ��Name$ btnCreateOrUpdate��5&      $��Принять��6L   $��20(�6^   $��Bookman Old Style)�6l   $��Italic$�6�   ���	#FFD5F1FF$��2��6�   $��40��6�   $	��Top=�6�   $	��0,5q�6�   �� 5'   
   -   5        $ 	btnCancel��5'      $��Отменить��6<   $��20(�6O   $��Bookman Old Style)�6]   $��Italic$�6|   ���	#FFD5F1FF$��2��6�   $��40��6�   $��Bottom=�6�   $	��0,5q�6�   5(      5)      