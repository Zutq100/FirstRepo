   M S B A M L   `   `   `  ���� E  AStorageWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:StorageWPF.Client.ViewsStorageWPF.Client.Views  *    $StorageWPF.Client.Views.ItemEditView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:StorageWPF.Client.Views     .��� $��10q�  � RowDefinitions  �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��16(�$
��Bold"�$��0,0,0,10q����� *Title+�� $��1��.���� .+��  � ColumnDefinitions �� $
��Auto ��� $��* �  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Name:��$��5q��� $��0��$��1��$��5q����� *	Item.Name+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��0��$��Article Number:��$��5q��� $��1��$��1��$��5q����� *Item.ArticleNumber+$ PropertyChanged=� �� 
IsReadOnly �� *	IsNewItem+�� $��2��$��0��$��Description:��$��5q��� $��2��$��1�� �� AcceptsReturn$
 True��$��60��$��5q����� *Item.Description+$ PropertyChanged=��� $��3��$��0��$��Price:��$��5q��� $��3��$��1��$��5q����� *
Item.Price+$ PropertyChanged=��� $��4��$��0��$��	Quantity:��$��5q��� $��4��$��1��$��5q����� *Item.Quantity+$ PropertyChanged=��� $��5��$��0��$��Unit:��$��5q��� $��5��$��1��$��5q����� *	Item.Unit+$ PropertyChanged=��� $��6��$��0��$��
Min Stock:��$��5q��� $��6��$��1��$��5q����� *Item.MinimumStockLevel+$ PropertyChanged=��� $��7��$��0��$��
Max Stock:��$��5q��� $��7��$��1��$��5q����� *Item.MaximumStockLevel+$ PropertyChanged=��� $��8��$��0��$��	Location:��$��5q��� $��8��$��1��$��5q����� *Item.Location+$ PropertyChanged=��� $��2�� �� Orientation$ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� $
��Save��$��80��$��5q����� *SaveCommand+�� $��Cancel��$��80��$��5q����� *CancelCommand+