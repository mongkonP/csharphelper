   M S B A M L   `   `   `  ����  csharphelper_WPF=    7csharphelper.Windows_Cs.howto_cube_tetrahedrons_Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  howto_cube_tetrahedrons��5      $	��350��5      $	��350��6    � 	Resources 5       
  Brush1 �� Color 
 Brush2  
SceneScale �� ScaleX �� ScaleY �� ScaleZ��%�   &	        &	 $     &	 G     �� 5   
   $ 
LightGreen��6)   �� 5	   
   $ 	LightBlue��6)   �� 5   
   $ 3Q�6.   $ 3Q�69   $ 3Q�6D   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��25 �6   .+�5   
   �� -   5        $��vscroll��5      $��0��5      $��1��6    �� Orientation$ Vertical=�5      	 � Minimum$
	 -180Q�5      
 � Maximum$	
 180Q�6    � LargeChange$ 10Q�5       � SmallChange$ 1Q�6    � Value$ 0Q�6.   �� 5   
   -   5        $��hscroll��5      $��1��5      $��0��6   $ 
Horizontal=�5       $
	 -180Q�5!      $	
 180Q�6   $ 10Q�5"      $ 1Q�6   $ 0Q�6.   '� 5$   
   $��4,4,4,4q�6   $��0��6&   $��0��63   .x�5%      g�  g� Content 5&      h� 5'      .��5)      ��  �� Color$
 Gray��6'   t� 5*      $
 Gray��6+    t� 	Direction$ 1,-2,-35�68   t� 5+      $
 Gray��6+   $ -1,2,35�68   � 5.       j� 	Transform# [ 6*    � Geometry 5/      k� 50   "    k� 	Positions- �    k� TriangleIndices �       57   %    � Material 5=      u� 5>   "    u� Brush# [  62   5@      � 5C      # [ 6*    5D      k� 5E   "   - �    �       5L   %    5R      u� 5S   "   # [ 62   5U      5W      5Y       '� Camera 5[      =� 5\       � Position$ 3, 5, 101�5]       � LookDirection$ -3, -5, -105�5^       � UpDirection$ 0, 1, 05�5_       =� FieldOfView$ 60Q�5`       �� 	Transform 5a      Y� 5b      .�5c      ��  �� Rotation 5d   "   �� 5e   &    �� Axis$ 0 1 05�5f   '    �� Angle 5g   '   ��   �� ElementName$  hscroll��! �� Path$! Value�5i      �� 5j       5k   "   �� 5l   &   $ 1 0 05�5m   '    5n   '   �� $  vscroll��$! Value�5p      5q      5s      5u      5v      5w      