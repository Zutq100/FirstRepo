   M S B A M L   `   `   `  ���� E  AStorageWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:StorageWPF.Client.ViewsStorageWPF.Client.Views  -    'StorageWPF.Client.Views.ItemDetailsView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:StorageWPF.Client.Views     .��� $��10q�  � RowDefinitions  �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $��16(�$
��Bold"����� *Title+�� $
��Edit��$��10,0,0,0q�$
��10,2q����� *EditItemCommand+� $��1��$
��0,10q� � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Article Number:��$��0,0,5,5q��� $��0��$��1��$��0,0,0,5q����� *Item.ArticleNumber+�� $��1��$��0��$��Current Quantity:��$��0,0,5,5q��� $��1��$��1��$��0,0,0,5q����� *Item.Quantity+�� $��2��$��0��$��Min Stock Level:��$��0,0,5,5q��� $��2��$��1��$��0,0,0,5q����� *Item.MinimumStockLevel+�� $��3��$��0��$��	Location:��$��0,0,5,0q��� $��3��$��1������ *Item.Location+�� $��0��$��2��$��Price:��$��10,0,5,5q��� $��0��$��3��$��0,0,0,5q����� *
Item.Price+ �� StringFormat$ C���� $��1��$��2��$��Unit:��$��10,0,5,5q��� $��1��$��3��$��0,0,0,5q����� *	Item.Unit+�� $��2��$��2��$��Max Stock Level:��$��10,0,5,5q��� $��2��$��3��$��0,0,0,5q����� *Item.MaximumStockLevel+�� $��3��$��2��$��	Category:��$��10,0,5,0q��� $��3��$��3������ *Item.Category+�� $��2��
�������$��1q�$
��0,10q� �� Padding$ 5q�._��� .���� $
��Wrap=����� *Item.Description+�� $��3��$��Movement History��$��0,10,0,0q�.��&   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��   
IsReadOnly$
 True������ *	Movements+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *MovementDate+$ {0:g}��  $
 Type��$
	 Auto 
 �� *Type+  $ Quantity��$
	 Auto 
 �� *
Quantity+  $ Source��$	 * 
 �� *Source+  $ Destination��$	 * 
 �� *Destination+  $ Comment��$	 * 
 �� *	Comment+�� $��4��$��Back to List��$��Right=�$��0,10,0,0q�$	��100������ *BackCommand+