   M S B A M L   `   `   `  ����  csharphelper_WPF<    6csharphelper.Windows_Cs.howto_xaml_rotate_cube_Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  howto_xaml_rotate_cube��5      $	��300��6$   $	��330��61   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��25 �6   .+�5   
   �� -   5        $��vscroll��5      $��0��5      $��1��6    �� Orientation$ Vertical=�5       � Minimum$
 -180Q�5       � Maximum$	 180Q�6    � LargeChange$ 10Q�5       � SmallChange$ 1Q�6    � Value$ 0Q�6.   �� 5   
   -   5        $��hscroll��5      $��1��5      $��0��6   $ 
Horizontal=�5      $
 -180Q�5      $	 180Q�6   $ 10Q�5      $ 1Q�6   $ 0Q�6.   '� 5   
   $��4,4,4,4q�6   $��0��6&   $��0��63   .x�5      g� 	 g� Content	 5      h� 5      .��5       �� 
 �� Color$

 Gray��6'   t� 5!      $

 Gray��6+    t� 	Direction$ 1,-2,-35�68   t� 5"      $

 Gray��6+   $ -1,2,35�68   � 5$       � Geometry 5%      k� 5'   "    k� 	PositionsQ �    k� TriangleIndices. �$     	

50   %    � Material 5:      u� 5;   "    u� Brush
 ��  �62   5=      5>      5@       '� Camera 5B      =� 5C       � Position$ 	1.5, 2, 31�5D       � LookDirection$ -1.5, -2, -35�5E       � UpDirection$ 0, 1, 05�5F       =� FieldOfView$ 60Q�5G       �� 	Transform 5H      Y� 5I      .�5J      ��  �� Rotation 5K   "   �� 5L   &    �� Axis$ 0 1 05�5M   '    �� Angle 5N   '   ��  �� ElementName$ hscroll�� �� Path$ Value�5P      �� 5Q       5R   "   �� 5S   &   $ 1 0 05�5T   '    5U   '   �� $ vscroll��$ Value�5W      5X      5Z      5\      5]      5^      