   M S B A M L   `   `   `  ���� E  AStorageWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:StorageWPF.Client.ViewsStorageWPF.Client.Views  '    !StorageWPF.Client.Views.ItemsView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:StorageWPF.Client.Views     .���   � RowDefinitions  �� $
��Auto ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�$��5q�.+��� $	��200��$��5q����� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=��� $��Refresh��$��5q����� *LoadItemsCommand+�� $��Add New��$��5q����� *AddItemCommand+&   System.Windows.Controls.DataGrid  $��1��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   SelectionMode$ Single=�$��5q����� *Items+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *Id+  $
 Name��$ * 	 �� *Name+  $ Article��$
 Auto 	 �� *ArticleNumber+  $ Quantity��$
 Auto 	 �� *
Quantity+  $ Price��$
 Auto 	 �� *Price+
 �� StringFormat$
 C��4  .System.Windows.Controls.DataGridTemplateColumn  $
 Auto    CellTemplate �� .R��� $ 
Horizontal=�.+��� $
��View��$��2q����� * DataContext.ViewDetailsCommand+ �� RelativeSource ��  �� AncestorType DataGrid���� �� $
��Edit��$��2q����� *DataContext.EditItemCommand+ ��  DataGrid���� �� $��Delete��$��2q����� *DataContext.DeleteItemCommand+ ��  DataGrid���� 