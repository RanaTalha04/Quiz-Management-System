   M S B A M L   `   `   `  ����Q  MQuiz Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Quiz_Management_SystemQuiz_Management_System  5   	   "    Quiz_Management_System.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Quiz_Management_System     5   	     � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�6?    � AllowsTransparency$
 True��6R   
������  � Title$ 
MainWindow��5   	   $	��500��6   $	��800��6)   .��5	      � -   5         � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��1.5* �6   .+�5   
   ��  �� CornerRadius$ 	10 0 0 10��6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #4DA1A9��6#   	 � Offset$	 0Q�63   � 5      $ #4DA1A9��6#   $	 1Q�63   5      ._�5      �� $��Center=�6   .+�5      �� $��Sign Up��6   $��36(�6+   $
��Bold"�69   ���#ffffff
 �� TextAlignment$
 Center=�6`   �� 5      $2��,Enter your ID, Info and create a new account��6   $��18(�6P    �� 
LineHeight$ 30��6^   $
��Wrap=�6n   ���#ffffff$
 Center=�6�    J� Opacity$	 0.7Q�6�   $��12 20q�6�   �� 5      -   5        $��Sign_up_bttn��5      $��Sign Up��6-   $��15(�6?   $	��170��6M   
������ ���#ffffff���#ffffff$��1q�6�   $��15q�6�    � FocusVisualStyle 6�   Z� 6$  5      5      �� 5   
   ���#D7E8BA$��1��6&   $ 	0 10 10 0��66   ._�5      �� .+�5       �� -   5        $��
Close_bttn��5       $��20��6+   $��20��67   $��Right=�6B   .��5!      �� $��Images\X.jpeg��6   $��20��63   $��15��6?   $��Right=�6J   5"      �� 5#      $��Login to App��6   $��36(�60   $
��Bold"�6>   ���#4DA1A9$
 Center=�6e   �� 5$      $%��Enter your credentials to login��6   $��18(�6C   $ 30��6Q   $
��Wrap=�6a   
�������$
 Center=�6�   $ 1Q�6�   $��12 20q�6�   �� 5%      $��Center=�6   $��50q�68   .+�5&      � $��4q�6    5'      �� 5(      $
��auto �6/   �� 5)      $��* �6/    � RowDefinitions 5+      �� 5,      $
��auto �6,   �� 5-      $��* �6,   �� 5.      $��* �6,   �� 5/      $��* �6,   .+�52      �� -   5        $��id_lbl��52   $   $
��ID: ��62   $��0��6>   $��0��6K   $��15(�6[   $��SemiBold"�6i   
�������$��20q�6�   �� 53      -   5        $��
user_id_tb��53   "   $��0��64   $��1��6A   $��15(�6Q   $��SemiBold"�6_   
�������$��30��6�   ���#ffffff$y�Visible=�6�   $��20q�6�   �� 54      -   5        $��pass_lbl��54   $   $��
Password: ��64   $��1��6F   $��0��6S   $��15(�6c   $��SemiBold"�6q   
�������$��20q�6�   �� 55      -   5        $��pass_tb��55   "   $��1��61   $��1��6>   $��15(�6N   $��SemiBold"�6\   
�������$��30��6�   ���#ffffff$��20q�6�   $y�Visible=�6�   �� 56      -   5        $��forgotPass_bttn��56   !   $��Forgot Password��68   $��2��6R   $��2��6_   $��Center=�6s   $��15(�6�   $
��Bold"�6�   $	��170��6�   $��20q�6�   
������ ���#4DA1A9
�������$��1q�6	  $��15q�6  6p  �� 57      -	   5        $��
login_bttn��57   !   $��Login��63   $��3��6C   $��2��6P   $��Center=�6d   $��15(�6�   $
��Bold"�6�   $	��170��6�   $��10q�6�   
������ ���#4DA1A9
�������$��1q�6�   $��15q�6  6a  58      59      5:      5;      5<      5=      