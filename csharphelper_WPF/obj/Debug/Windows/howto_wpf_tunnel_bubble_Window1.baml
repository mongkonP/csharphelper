   M S B A M L   `   `   `  ����  csharphelper_WPF=    7csharphelper.Windows_Cs.howto_wpf_tunnel_bubble_Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        � Title$  howto_wpf_tunnel_bubble��5      $	��300��5      $	��400��6   .��5      � -   5        $��grdMain��5       � RowDefinitions 5   
   �� 5      $��60 �6   �� 5	      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � -   5        $��
grdButtons��5      $��0��6!   $��0��6.   $��2��6>   
��� ���.+�5      �� -   5        $��	spButtons��5      $	��300��6*   $��40��66   
����ح� �� Orientation$ 
Horizontal=�5       � 	Resources 5       �� 
TargetType �� Property �� Value��%u   '��       �� 5      " ��6   .�5      ��  � ��$ 3q�63   �� 5       � ��$ 60��63   5      5      .+�5      �� -   5        $��Button1��5      $��Button 1��6(   5       �� 5!      -   5        $��Button2��5!      $��Button 2��6(   5#      �� 5$      -   5        $��Button3��5$      $��Button 3��6(   5&      5'      5(      �� 5)   
   $��1��6   $��0��6"   $ Vertical=�5*      
������ 5,      ��%w   '��       �� 5-      " ��6   .�5.      ��  � ��$ 3q�6/   �� 5/       � ��$
 Left=�6<   50      51      .+�52      �� -   5        $��chkHandleInGridPreview��52      $��Handle in Grid.Preview��65   �� 53      -   5        $"��chkHandleInStackPanelPreview��53      $"��Handle in StackPanel.Preview��6;   �� 54      -	   5        $��chkHandleInButtonPreview��54      $��Handle in Button.Preview��67   �� 55      -
   5        $��chkHandleInButtonClick��55      $��Handle in Button.Click��65   �� 56      -   5        $ ��chkHandleInStackPanelClick��56      $ ��Handle in StackPanel.Click��69   �� 57      -   5        $��chkHandleInGridClick��57      $��Handle in Grid.Click��63   58      �� 59   
   -   5        $��
txtResults��59      $��1��6$   $��1��61   5;      5<      