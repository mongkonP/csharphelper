   M S B A M L   `   `   `  ����  csharphelper_WPF=    7csharphelper.Windows_Cs.howto_wpf_control_video_Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5          � Title$  howto_wpf_control_video��5      $	��380��5      $	��525��6   .��5      �  � RowDefinitions 5   
   �� 5	      $��* �6   �� 5
      $
��Auto �6   �� 5      $��40 �6   .+�5   
   r� -   5         r�Name$ minionPlayer��5      $��5q�6-   $��0��5      $��0��6    r� ScrubbingEnabled .  r� LoadedBehavior$ Manual=�5       r� Source$ minions.mp4?�6%   �� 5   
   -   5        $��sbarPosition��5   :    �� Orientation$ 
Horizontal=�6   $��1��6-   $��Center=�5      $y�Hidden=�6(   �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��Center=�5      $��Center=�6*    � 	Resources 5      	 �� 
TargetType
 �� Property �� Value��%Q   '��       �� 5      "	 ��6   .�5      �� 
 � ��$ 2q�6/   5      5      .+�5       �� -   5         ��Name$ btnPlay��5       .��5!      �� $��play.png��6   5"      �� 5#      -   5        $ btnPause��5#      {�.   J� Opacity$	 0.5Q�6P   .��5$      �� $��	pause.png��6   5%      �� 5&      -   5        $ btnStop��5&      .��5'      �� $��stop.png��6   5(      �� 5)      -   5        $ 
btnRestart��5)      .��5*      �� $��restart.png��6   5+      �� 5,      -   5        $ btnNext��5,      .��5-      �� $��next.png��6   5.      �� 5/      -	   5        $��btnPrevious��5/      .��50      �� $��previous.png��6   51      �� 52      $��5��6   �� 53      -
   5        $ 	btnFaster��53      .��54      �� $��
faster.png��6   55      �� 56      -   5        $��	btnSlower��56      .��57      �� $��
slower.png��6   58      �� 5:      $��	Position:��6   $��5,0,0,0q�6(   $��Center=�69   �� 5;      -   5        $��txtPosition��5;      $��35��6)   $��24��64   $	��0.0��6@   $��Right=�5<      $��Center=�64   �� 5=      -   5        $��btnSetPosition��5>      $��5,0,0,0q�5=      $��Set Position��6&   $��30��6=   5>   '   5?      5@      5A      