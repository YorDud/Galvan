   M S B A M L   `   `   `  ����	  Prog3    Prog3.Avtorize   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Авторизация��5   	   $	��316��6   $	��519��6*   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ PrimaryLight=�66    � 
ResizeMode$ NoResize=�6i    � WindowStyle$
 None=�5	      
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5      .��5      �� 
�������$��15,15,15,15q�6     �� CornerRadius$ 15��5       �� Padding$ 10q�5       J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 15Q�6   
   Color$
 	#FF673AB7��6/      ShadowDepth$ 0Q�6A   6S   ._�5   
   � $��10q�6   .+�5      �� -   5         ��Name$ 
ExitButton��5      $��×��6)   $��Right=�5      $	��Top=�6   $��30(�5      $
��Bold"�6   
������ 
������ 
���  ��$��0,-14,-15,0q�5      $��39��5      $��50��6&   �� 5      $��10,10,10,10q�6   .+�5      �� ���#4CAF50$��5q�6.   $ 15��5      $ 10q�5      ._�5      �� $��24(�6    $
��Bold"�6.   $��0,0,0,20q�6@   $��Yu Gothic UI)�6R    �� TextAlignment$ Center=�6l   �� 6�   $�Авторизация��6�   
�������6�   6�   5      � 5       �� 5#      -   5         ��Name$ log_txt��5#      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��6+    %  !MaterialDesignFloatingHintTextBox#��[  6Z   6�   G� 5$      -   5         G�Name$ pass_txt��5$      $! Введите пароль��60    ) %MaterialDesignFloatingHintPasswordBox#��[ 6`   6�   �� 5'      -   5        $��
Войти��5'      $��	0,25,0,30q�6)   $	��Top=�6<   ���#4CAF50���	#FF85E600���	#DDFFFFFF6�   5)      5-      5/      52      