   M S B A M L   `   `   `  ����Q  MQuiz Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Quiz_Management_SystemQuiz_Management_System  5   	   -    'Quiz_Management_System.TeacherDashboard   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Quiz_Management_System     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � WindowState$ 	Maximized=�5
   	    � AllowsTransparency$
 True��5   	   
������  � Title$ TeacherDashboard��5   	   $	��510��6"   $	��800��6/   .��5      � .+�5   
   �� 
�������$��1��6$    �� CornerRadius$ 	0 10 10 0��64   ._�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $	��Top=�6R   $��30��6j   .+�5      �� -   5        $��min_bttn��5      $��20��6-   $��20��69   .��5      �� $��Images\Minus.jpeg��6    $��20��6;   $��15��6G   5      �� 5      -   5        $��max_bttn��5      $��20��6-   $��20��69   .��5      �� $��Images\square.jpeg��6    $��20��6<   $��15��6H   5      �� 5      -   5        $��
Close_bttn��5      $��20��6/   $��20��6;   .��5      �� $��Images\X.jpeg��6    $��20��67   $��15��6C   5      5      5      5      �� 5   
   ���#4DA1A9$	��190��6*   $
��Left=�66   .+�5       �� $��	Dashboard��6   $��Center=�6)   $��30(�6F   $
��Bold"�6T   $	��150��6f   $��0,50,0,0q�6r   
������ ���#ffffff6�   �� 5!      -   5        $��Create Quiz��5!      $��Center=�6+   $��15(�6H   $
��Bold"�6V   $	��150��6h   $��0,50,0,0q�6t   
������ ���#ffffff���#ffffff$��1q�6�   $��15q�6�   6%  �� 5"      -   5        $��View Quizzes��5"      $��Center=�6,   $��15(�6I   $
��Bold"�6W   $	��150��6i   $��0,50,0,0q�6u   
������ ���#ffffff���#ffffff$��1q�6�   $��15q�6�   6&  �� 5#      -   5        $��
View Marks��5#      $��Center=�6*   $��15(�6G   $
��Bold"�6U   $	��150��6g   $��0,50,0,0q�6s   
������ ���#ffffff���#ffffff$��1q�6�   $��15q�6�   6$  �� 5$      -   5        $��Log Out��5$      $��Center=�6'   $��15(�6D   $
��Bold"�6R   $	��150��6d   $��0,50,0,0q�6p   
������ ���#ffffff���#ffffff$��1q�6�   $��15q�6�   6!  5%       � 5&   
   -   5          �Name$ 	MainFrame��5&      $��
200,30,0,0q�6#     � NavigationUIVisibility$ Hidden=�67   5'      5(      