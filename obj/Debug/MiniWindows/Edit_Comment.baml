   M S B A M L   `   `   `  ����@  <Prog3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Prog3.MiniWindowsProg3.MiniWindows  5      $    Prog3.MiniWindows.Edit_Comment   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      +localclr-namespace:Prog3.MiniWindows  5        � Title$  Edit_Comment��5	   	   $	��191��6   $	��595��6+   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�67    � 
ResizeMode$ NoResize=�5
       � WindowStyle$
 None=�5      
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5      .��5      �� 
�������$��15,15,15,15q�6     �� CornerRadius$ 15��5       �� Padding$ 10q�5       J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 15Q�6   
   Color$
 	#FF76C803��6/      ShadowDepth$ 0Q�6A   6S   ._�5   
   � $��10q�6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��Auto �6    .+�5      �� -   5         ��Name$ 
ExitButton��5      $��×��6)   $��Right=�5       $	��Top=�6   $��30(�5!      $
��Bold"�6   
������ 
������ 
���  ��$��0,-14,-15,0q�5#      $��39��5$      $��50��6&   � 5'      $��1��6   $��
0,10,0,126q�6     5(      �� 5)      $
��Auto �6$   �� 5*      $
��Auto �6$   �� 5+      $
��Auto �6$   �� 5,      $
��Auto �6$   �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $��30 �6$   �� 51      $
��Auto �6$   �� 52      $
��Auto �6$   �� 53      $��30 �6$   �� 54      $
��Auto �6$    � ColumnDefinitions 56      �� 57      $	��120 �6'   �� 58      $	��100 �6'   �� 59      $	��150 �6'   �� 5:      $	��150 �6'   �� 5;      $��* �6'   .+�5@      �� $��Комментарий:��6   $��1��6/   $��1��6<   $��Center=�6P   $��5q�6k   $��15(�5A      $
��Bold"�6   $��Yu Gothic UI)�6!   $��Right=�6;   �� 5B      -   5         ��Name$ Comment��5B      $��1��6+   $��3��68   $��1��6L   $��5q�6\   $��30��6g   $��3q�6s    !  MaterialDesignOutlinedTextBox#��[  5C      �� 5E      -   5        $��Сохранить��5E      $��2��6-   $��4��6:   $��5q�6N   ���#4CAF50���	#FF85E600���	#DDFFFFFF6�   5H      5I      5J      5L      