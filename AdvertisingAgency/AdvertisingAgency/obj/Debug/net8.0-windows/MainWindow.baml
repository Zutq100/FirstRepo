   M S B A M L   `   `   `  ����L  HAdvertisingAgency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AdvertisingAgencyAdvertisingAgency  5   	   "    AdvertisingAgency.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AdvertisingAgency     5   	   -   5          � Title$+  %Рекламное агентство��5   	   $	��450��6%   $	��850��62    � 
ResizeMode$ NoResize=�6>   .��5	      � .+�5
   
   �� -   5        $��lbText��5
   S   
����� �
���   �$��1q�6?   $��0,32,0,0q�6a   $��Times New Roman)�6s   $��18(�6�   o� 5   
   $	��Top=�6   
�������$��32��6@   $��2��6L   .@�5      �� -   5        $��	btnCreate��5      $	��110��6&   $��25��62   $$��Cоздать/Изменить��6>   $��12(�6Y   
�������
���   �6�   �� 5      -   5        $��	btnDelete��5      $	��110��6&   $��25��62   $��Удалить��6>   $��12(�6P   
�������
���   �6�   �� 5      -   5         ��Name$ 	btnStatus��5      $	��110��6(   $��25��64   $��Открыт/Закрыт��6@   $��12(�6X   
�������
���   �6�   �� 5      -   5        $��	txtSearch��5   .   $	��185��6   $��25��6"   
���   �6S   �� 5      -   5        $��cmbBase��5   #   $	��100��6   .@�5      �� -   5        $��
cbiClients��5   1   $��Клиенты��6   61   �� 5      -	   5        $��	cbiOrders��5   0   $��Заказы��6   60   �� 5      -
   5        $��
cbiReviews��5   0   $��Отзывы��6   60   5      �� 5      -   5        $��	cmbFilter��5   #   $	��100��6   $y�	Collapsed=�6b   .@�5      �� $,��&Показать не принятые��6   �� 5      $'��!Показать открытые��6   �� 5      $'��!Показать закрытые��6   �� 5      $��Показать все��6   5      5      5      5      