   M S B A M L   `   `   `  ����D  @kontrolki, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:kontrolki	kontrolki  5   	       kontrolki.KwadratWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:kontrolki     5   	   $��50q�5   	     � Title$  KwadratWindow��5	   	   $	��450��6   $	��800��6,   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   $��Center=�6-   $��40(�6H   .��6V   Bok6[   �� 5   
   $��Center=�6   $��Center=�6-   $��40(�6H   $��1��6V   .��6c   Pole6i   �� 5   
   $��Center=�6   $��Center=�6-   $��40(�6H   $��2��6V   .��6c   Obwód6j   �� 5   
   -   5         ��Name$ dejBok��5      $��1��6"   
������� �� TextAlignment$ Center=�6E   $��30(�6\   6�   �� 5   
   -   5         ��Name$
 pole��5       �� TextAlignment$ Center=�6"   $��40(�69   $��1��6G   $��1��6T   
�������6}   �� 5   
   -   5        $ obwod��5      $ Center=�6#   $��40(�6:   $��2��6H   $��1��6U   
�������6~   �� 5    
   -   5        $��1��5       $��5��6!   
����  �$��40(�6@   
�������$
��Bold"�6a   .��6�   Rysuj6�   �� 5"   
   -   5         ��Name$ 	komunikat��5"      $��Center=�6#   $��Center=�6@   $��22(�6[   $��2��6i   $
��Bold"�6y   .��6�   Wpisz długość boku6�   �� 5#   
   $��2��6   $��1��6!   $��5��6.   
�������.+�5$      �� -   5         ��Name$ kfadrad��5$      $��0��6)   $��0��63   	 �� Left$	 10��6>   

 �� Top$
 10��6O   
�������6_   5%      �� 5'   
   -   5         ��Name$ kombo��5'   Z   $��3��6   $��1��6    $	��150��60   $��30��6<    �� SelectedIndex$ 0��6H   .@�5(      �� $��Orange��6   �� 5)      $
��Blue��6   �� 5*      $��Green��6   5+      �� 5-   
   -   5         ��Name$ czekboks��5-   �   $��4��6   $��1��6    $��Center=�60   $��Center=�6K   $��Czy przezroczysty?��6h   $��22(�6�   6�   �� 5/   
   -	   5        $��5��5/      
���  ��$��40(�63   
��� ���$
��Bold"�6U   .��6u   Kasuj6|   50      51      