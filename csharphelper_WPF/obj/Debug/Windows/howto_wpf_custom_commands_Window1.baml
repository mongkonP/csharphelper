   M S B A M L   `   `   `  ����  csharphelper_WPF?    9csharphelper.Windows_Cs.howto_wpf_custom_commands_Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          � Title$  howto_wpf_custom_commands��5      $	��350��5       � SizeToContent$ Height=�5      
����ح�
����  � J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Open��5      5      .��5      ]� ��.  � 	Resources 5   
    �� 
TargetType �� Triggers P� Property P� Value	 �� Property
 �� Value��%+  'm�       '�� �     '�� �    �� 5      " m�6    5      P� 5       � {� .  . �5      �� 	 �@J�Opacity$	
 0.5Q�64   5      5      �� 5      " ��6   .�5      �� 	 � ��$	
 120��6*   �� 5      	 � ��$
 30��6+   �� 5      	 � ��$
 5q�6+   �� 5      	 � ��

 ��  �6/   �� 5      	 � ��

 ���� 6/    5      P� 5        � {� .  . �5!      �� 	 �@J�Opacity$	
 0.5Q�64   5"      5$      �� 5%      " ��6   .�5&      �� 	 � ��

 ��  �6/   5'      5(      .+�5)   
   o� $	��Top=�6   .@�5*      m� $��Document��6   .@�5+      m� $	��New��6    m� Command$ ApplicationCommands.New��6(   m� 5,      $
��Open��6   $ ApplicationCommands.Open��6)   m� 5/      -   5        $��mnuChangeForeground��5/   6   $��Change Foreground��6   66   m� 50      -   5        $��mnuChangeBackground��50   6   $��Change Background��6   66   51      52      � 53   
   -   5        $��grdMain��53      $��10q�6   
������  � RowDefinitions 54      �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6    �� 5:      $
��Auto �6     � ColumnDefinitions 5<      �� 5=      $��* �6#   �� 5>      $��* �6#   .+�5A      �� $��0��6   $��0��6"   $��New Document��5B      $��ApplicationCommands.New��6(   �� 5C      $��1��6   $��0��6"   $��Make New��5D      $��ApplicationCommands.New��6$   �� 5E      -   5        $��chkAllowNew��5F      $��2��5E      $��0��6$   $��	Allow New��5F   $   $��Center=�5G      �� 5I      $��0��6   $��1��6"   $��Open Document��5J      $��ApplicationCommands.Open��6)   �� 5K      $��1��6   $��1��6"   $
��Open��5L      $��ApplicationCommands.Open��6    �� 5M      -   5        $��chkAllowOpen��5N      $��2��5M      $��1��6$   $��
Allow Open��5N   %   $��Center=�5O      �� 5W      -   5        $��btnChangeForeground��5Y      $��3��5W      $��0��6"   $��0,40,0,0q�62   $��Change Foreground��5X      5Y      �� 5Z      -	   5        $��btnForeground��5\      $��4��5Z      $��0��6"   $��
Foreground��5[      5\      �� 5]      -
   5        $��chkAllowForeground��5^      $��5��5]      $��0��6$   $��Allow Foreground��5^   +   $��Center=�5_      �� 5g      -   5        $��btnChangeBackground��5i      $��3��5g      $��1��6"   $��0,40,0,0q�62   $��Change Background��5h      5i      �� 5j      -   5        $��btnBackground��5l      $��4��5j      $��1��6"   $��
Background��5k      5l      �� 5m      -   5        $��chkAllowBackground��5n      $��5��5m      $��1��6$   $��Allow Background��5n   +   $��Center=�5o      5p      5q      5r      