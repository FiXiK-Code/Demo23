   M S B A M L   `   `   `  ����G  CPojarov_DEMO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Pojarov_DEMOPojarov_DEMO  5   	       Pojarov_DEMO.Склад   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Pojarov_DEMO     5   	   -   5          � Title$  
Склад��5   	   $	��450��6   $	��693��6$   $��344.8��64   $��677.411��6F   $
��1150��6V   $��550.4��6f   .��5	      � .+�5
   
   �� -   5         ��Name$ Button_exit��5
      $
��Exit��6&   $��Right=�65   $��0,21,10.2,0q�6Q   $	��Top=�6f   $��75��6~   $��1��6�   6�   �� 5   
   $3��-Сортировка по стоимости:��6   $��Right=�63   $��0,65,63.2,0q�6O   $	��Top=�6d   �� 5   
   -   5         ��Name$ ComboBox_prise��5      $��Right=�6+   $��0,96,63.2,0q�6G   $	��Top=�6\   $	��154��6t   $��2��6�   .@�5      �� $!��Без сортировки��6   �� 5      $!��По возрастанию��6   �� 5      $��По убыванию��6   5      �� 5   
   $B��<Отфильтровать по размеру скидки:��6   $��Right=�6;   $��0,126,13.2,0q�6W   $	��Top=�6m   �� 5   
   -   5        $ ComboBox_discount��5      $��Right=�6.   $��0,157,63.2,0q�6J   $	��Top=�6`   $	��154��6x   $��3��6�   .@�5      �� $��Все диапазоны��6   �� 5      $��0-9,99%��6   �� 5      $��	10-14,99%��6   �� 5      $��15% и более��6   5      �� 5   
   -   5         ��Name$ Label_view_item_count��5      $��13��6/   $��	10,15,0,0q�6<   $	��Top=�6O   $
��Left=�6g   �� 5   
   $
��из��6   $��	33,15,0,0q�6   $	��Top=�60   $
��Left=�6H   $��24��6c   �� 5   
   -   5        $ Label_all_item_count��5      $��13��6.   $��	57,15,0,0q�6;   $	��Top=�6N   $
��Left=�6f   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGrid_products��5      $��10,46,242,20q�6.      CanUserResizeColumns .     SelectionMode$ Single=�6�      CanUserAddRows .     CanUserDeleteRows .  	   CanUserResizeRows	 .  
   SelectionUnit$

 Cell=�6�   $��Tahoma)�6.  5      5      