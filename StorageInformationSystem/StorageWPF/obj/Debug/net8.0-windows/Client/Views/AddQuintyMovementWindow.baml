   M S B A M L   `   `   `  ����E  AStorageWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:StorageWPF.Client.ViewsStorageWPF.Client.Views  5   	   5    /StorageWPF.Client.Views.AddQuintyMovementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:StorageWPF.Client.Views     5   	     � Title$  AddQuintyMovementWindow��5   	   $	��450��6)   $	��800��66   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Товар:��6!   �� 5   
   $��0��6   $��1��6!   $
��Bold"�6K   ��61   �� *
ItemName+6K   �� 5   
   $��1��6   $$��Тип перемещения:��6!   �� 5   
   $��1��6   $��1��6     �� DisplayMemberPath$ Value��5       �� SelectedValuePath$	 Key��5       $��0,0,-222,17q�5!   >   $��2��6S   ��5      �� *MovementTypes+ �� SelectedValue 5!      �� *CurrentMovement.Type+6S   �� 5#   
   $��2��6   $��Количество:��6!   �� 5$   
   $��2��6   $��1��6   $��0,0,-222,17q�5%   ]   $��2��6r   ��6   �� *CurrentMovement.Quantity+ �� UpdateSourceTrigger$ PropertyChanged=�6r   �� 5'   
   $��3��6   $��Источник:��6!   �� 5(   
   $��3��6   $��1��6   $��0,0,-222,16q�5)   6   $��2��6K   ��6   �� *CurrentMovement.Source+6K   �� 5+   
   $��4��6   $��Назначение:��6!   �� 5,   
   $��4��6   $��1��6   $��0,0,-222,192q�5-   ;   $��2��6Q   ��6   �� *CurrentMovement.Destination+6Q   �� 5/   
   $��5��6   $��Комментарий:��6!   �� 50   
   $��5��6   $��1��6    �� AcceptsReturn$
 True��52      $��0,10,-222,10q�6#   ��51      �� *CurrentMovement.Comment+52   #   �� 55   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�56      �� $��Сохранить��6   $��80��6I   $��5q�6T   ��6)   �� *SaveCommand+6T   �� 57      -   5        $��Отмена��57      $��80��6;   $��5q�6F   �� 58      $��Удалить��6   $��80��6I   $��5q�6T   ��6'   �� *DeleteCommand+6T   59      5:      5;      