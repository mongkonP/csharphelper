   M S B A M L   `   `   `  ����  csharphelper_WPFD    >csharphelper.Windows_Cs.howto_wpf_3d_stellate_geodesic_Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          � Title$$  howto_wpf_3d_stellate_geodesic��5      $	��500��5      $	��500��6   .��5      �  � 	Resources 5   
    �� 
TargetType �� Property �� Value��%�   '��       '�� v     �� 5	      " ��6   .�5
      ��  � ��$ Center=�66   �� 5       � ��$ 4,0,10,0q�6+   5      �� 5      " ��6   .�5      ��  � ��$ Center=�66   �� 5       � ��$ 4,0,0,0q�6+   5      5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��20 �6   .+�5   
   '� -   5        $��MainViewport��5      $��1��5      $��0��6"   5      �� 5   
   $��0��6   $��0��6"    �� Orientation$ 
Horizontal=�62   .+�5      �� -   5        $��chkAxes��5!      $��0��5      $��0��6$   $
��Axes��5        d� 	IsChecked$
 TrueY�6   5!      �� 5"      -   5        $��chkEdges��5$      $��0��5"      $��1��6$   $��Edges��5#      $
 TrueY�6   5$      �� 5%      -   5        $��chkFaces��5'      $��0��5%      $��2��6$   $��Faces��5&      $
 TrueY�6   5'      �� 5(      $��3��6   $ 
Horizontal=�6)   .+�5)      �� $��Level:��6   �� 5*      -   5        $��lblLevel��5+      $��1��5*      $��20��6$   $��0q�6/   $��Right=�5+   %   �� 5,      $ Vertical=�6   .+�5-      �� -   5        $��btnUp��5-      ��.  .��5.      �� $��Up.png��6    5/      �� 50      -   5        $��btnDown��50      ��.  .��51      �� $��Down.png��6    52      53      54      �� 55      $��4��6   $ 
Horizontal=�6)   .+�56      �� $��Dist:��6   �� 57      -	   5        $��lblDistance��58      $	��3.0��57      $��35��6&   $��0q�61   $��Right=�58   (   �� 59      $ Vertical=�6   .+�5:      �� -
   5        $��	btnDistUp��5:      ��.  .��5;      �� $��Up.png��6    5<      �� 5=      -   5        $��btnDistDown��5=      ��.  .��5>      �� $��Down.png��6    5?      5@      5A      �� 5B      $��4��6   $ 
Horizontal=�6)   .+�5C      �� $��Radius:��6   �� 5D      -   5        $��	lblRadius��5E      $	��1.0��5D      $��35��6&   $��0q�61   $��Right=�5E   &   �� 5F      $ Vertical=�6   .+�5G      �� -   5        $��btnRadiusUp��5G      ��.  .��5H      �� $��Up.png��6    5I      �� 5J      -   5        $��btnRadiusDown��5J      ��.  .��5K      �� $��Down.png��6    5L      5M      5N      5O      �� 5Q   
   -   5        $��scrTheta��5T      $��2��5Q      $��0��6!   	 �� Orientation$	 
Horizontal=�5R      
 � Value$

 21.8Q�6&    � Minimum$ 0Q�5S       � Maximum$	 360Q�6   5T      �� 5U   
   -   5        $��scrPhi��5X      $��1��5U      $��1��6!   $	 Vertical=�5V      $

 44.5Q�6$   $	 -90Q�5W      $ 90Q�6   5X      5Y      5Z      