   M S B A M L   `   `   `  ����U  QEducationQualityInfoSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:EducationQualityInfoSystemEducationQualityInfoSystem  5   	   +    %EducationQualityInfoSystem.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:EducationQualityInfoSystem     5   	     � Title$1  +Информационная система��5   	   $	��450��6(   $	��800��65    � 
ResizeMode$ NoResize=�6A   .��5	      � 
������ � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��lbMain��5   =   $��14(�6   $��0��6    $��0��6-   $��2��6K   $��2��6_   
�����f�
���   �$��2q�6�   $|�False��6�   �� 5   
   -   5        $��cmbSelectTable��5   �   $��0��6F   $��3��6S   $	��100��6c   $��25��6o   $��Right=�6{   $
��10,0q�6�   .@�5      �� -   5        $��cbiMain��5   .   $��Основная��6   6.   �� 5      -   5        $��
cbiStudent��5   .   $��Студенты��6   6.   �� 5      -   5        $��
cbiQuality��5   2   $��Успеваемость��6   62   �� 5      -   5        $��cbiDiscipline��5   0   $��Дисциплины��6   60   �� 5      -   5        $��cbiDayOfWeek��5   C   $��День недели��6    �� 
IsSelected$
 True��61   6C   5      �� 5   
   -   5        $��	txtSearch��5      $�� ��6   $��0��6+   $��3��68   $	��250��6H   $��50��6T   $	��Top=�6`   $��0,5,0,0q�6x    �� TextWrapping$
 Wrap=�6�   6�   �� 5   
   $����Информационная система оценки качества организации учебного процесса��6    �� TextAlignment$ Center=�6`   
�����f�$
��Wrap=�6�   $��Black"�6�   $��30(�6�   $��0��6�   $��3��6�   $��2��6�   $|�False��6�   �� 5   
   -	   5        $��btnIsPresent��5   �   $��2��6   $��2��6!   $A��;Присутствовал(а)/Отсутствовал(а)��6.   $	��Top=�6Y   $��50��6q   $��16(�6}   6�   �� 5   
   -
   5        $��btnIsEvaluated��5   �   $��2��6   $��2��6!   $��50��6.   $��Bottom=�6:   $
��0,10q�6U   $8��2Отработал(а)/Не отработал(а)��6c   $��16(�6�   6�   �� 5    
   -   5        $��	btnAddUpd��5    �   $��2��6   $��1��6!   $	��125��6.   $��25��6:   $'��!Добавить/Обновить��6F   $��Right=�6b   $��0,0,5,0q�6~   6�   �� 5!   
   -   5        $��btnDlt��5!   �   $��2��6   $��1��6!   $	��100��6.   $��25��6:   $��Удалить��6F   $
��Left=�6X   $��5,0,0,0q�6s   6�   5"      5#      