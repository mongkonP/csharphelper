   M S B A M L   `   `   `  ����  csharphelper_WPFF    @csharphelper.Windows_Cs.howto_wpf_load_treeview_from_xml_Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$&   howto_wpf_load_treeview_from_xml��5      $	��300��5      $	��300��6    � 	Resources 5         food_provider � Source � XPath  NodeTemplate �� ItemsSource �� XPath ��Name �� Triggers �� Value	 �� Binding
 �� Path �� 
TargetName �� Value �� Property��%;  &	        &	 1     � 5   
   $ 	foods.xml?�60   $ /*��6C   �� 5	   
    5
      �� $	 ./*��.R�5      �� $ nodetext��6    5      �� 5      $ Element��6@   	 6   �� $
 NodeType�.a�5      �� $ nodetext��6    5      �� $

 Name� � ��5      5      5      .��5      �  � DataContext# [  6   $��4q�68    � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   R� -   5        $��trvItems��5      $��0��6#   #��[ 5      $��Stretch=�5      $��Stretch=�5       %� IsVirtualizing .   %� VirtualizationMode$ Standard=�5       ��5      �� 5       �� 5"   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   .+�5#      �� -   5        $��btnLoadFlowers��5#      $��1��6+   $��4q�68   $��Load Flowers��5$      $	��100��6(   64   �� 5%      -   5        $��btnLoadCars��5%      $��1��6(   $��4q�65   $��	Load Cars��5&      $	��100��6%   61   5'      5(      5)      