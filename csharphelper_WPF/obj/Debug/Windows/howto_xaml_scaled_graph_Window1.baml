   M S B A M L   `   `   `  ����  csharphelper_WPF=    7csharphelper.Windows_Cs.howto_xaml_scaled_graph_Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          � Title$  howto_xaml_scaled_graph��5      $	��300��5      $	��480��6   .��5      � 
������ � RowDefinitions 5   
   �� 5      $��30 �6   �� 5	      $��* �6    � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��Center=�5      $��Center=�5      ��5      ��  �� ElementName$ sliZoom�� �� Path$ Value� �� StringFormat$ {0:P0}��5      �� 5   
   -   5        $��sliZoom��5       �� Orientation$ Vertical=�6    $��Center=�5      $��0,0,0,5q�5      $��1��5      $��0��6    � Minimum$
 0.25Q�5       � Maximum$
 3.00Q�6   	 � Value$
	 1.00Q�6+   
 � SmallChange$

 0.25Q�5       � LargeChange$
 0.25Q�6     �� TickFrequency$
 0.25Q�5       �� TickPlacement$ BottomRight=�6"    �� IsSnapToTickEnabled . 5      �� 5   
   -   5        $��scvGraph��5      $��0��5      $��1��6   $��2��6*   $
��Auto=�5       $
��Auto=�5!      .��5"      �� -   5        $��canGraph��5"      
�������$	��400��5%      $	��250��6   $��Center=�5&      $��Center=�5'       � LayoutTransform 5(      �� 5)       �� ScaleX 5*      �� $ sliZoom��$ Value� �� ScaleY 5+      �� $ sliZoom��$ Value�5-      5.      5/      50      