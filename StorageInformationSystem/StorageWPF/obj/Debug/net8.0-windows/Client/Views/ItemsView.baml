   M S B A M L   `   `   `  ����E  AStorageWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:StorageWPF.Client.ViewsStorageWPF.Client.Views  5      '    !StorageWPF.Client.Views.ItemsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:StorageWPF.Client.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   .+�5      �� $	��200��6   $��5q�6"   ��6-   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��Обновить��6   $��5q�6(   ��63   �� *LoadItemsCommand+�� 5      $��Добавить��6   $��5q�6(   ��63   �� *AddItemCommand+5      &   System.Windows.Controls.DataGrid  5   
   $��1��6      AutoGenerateColumns$ False��6>      
IsReadOnly$
 True��6Z      SelectionMode$ Single=�5      $��5q�6*   ��5       �� *Items+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6H   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+6H     5      $ Название��6%   $ * 6P   	 67   �� *Name+6P     5      $ Артикль��6%   $
 Auto 6X   	 66   �� *ArticleNumber+6X     5      $ Количество��6%   $
 Auto 6V   	 69   �� *
Quantity+6V     5      $ Цена��6%   $
 Auto 6d   	 63   �� *Price+
 �� StringFormat$
 0.00 руб��6d   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Auto 6)      CellTemplate 5      �� 5      .R�5       �� $ 
Horizontal=�6)   .+�5!   "   �� $��Просмотреть��6)   $��2q�6?   ��5"      �� * DataContext.ViewDetailsCommand+ �� RelativeSource ��  �� AncestorType DataGrid��5#      �� �� 5$   "   $ ��Редактировать��6)   $��2q�6A   ��5%      �� *DataContext.EditItemCommand+ ��  DataGrid��5&      �� �� 5'   "   $��Удалить��6)   $��2q�6;   ��5(      �� *DataContext.DeleteItemCommand+ ��  DataGrid��5)      �� 5*      5+      5-      5/      50      51      