   M S B A M L   `   `   `  ����  csharphelper_WPF<    6csharphelper.Windows_Cs.howto_wpf_font_samples_Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  howto_wpf_font_samples��5      $	��300��5      $	��320��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $��30 �6   .+�5   
   �� $��0��6   $��0��6   $��Text:��6-   $��5q�6=   �� 5   
   -   5        $��	txtSample��5      $��0��5      $��1��6   $��2��6/   $��5q�6C   $��Sample Text��5      �� 5   
   $��1��6   $��0��6   $��Size:��6-   $��5q�6=   �� 5   
   -   5        $��sliSize��5      $��1��5      $��1��6   $��5q�6.    � Minimum$ 5Q�5       � Maximum$	 100Q�6(    � Value$ 20Q�66    �� TickFrequency$ 5Q�5       �� TickPlacement$ BottomRight=�6    �� IsSnapToTickEnabled . 5      �� 5   
   $��1��6   $��2��6   $��Center=�5      	 �� ContentStringFormat$	 {0:#}��5       ��5      �� 
 �� ElementName$
 sliSize�� �� Path$ Value�5       �� 5"   
   -   5        $��btnShowSamples��5$   $   $��2��5"      $��3��6   $	��100��5#      $��30��6   $��5q�6%    �� 	IsDefault . $��Show Samples��5$      5%      �� 5'   
   -   5        $��
lstSamples��5(      $��3��5'      $��3��6   $��5q�5(      6*   �� 5*   
   -   5        $��lblFontName��5+      $��4��5*      $��3��6   $�� ��5+       $��5,0,5,0q�6,   5,      5-      