   M S B A M L   `   `   `  ����E  AFarmingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FarmingApp
FarmingApp  5   	       FarmingApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:FarmingApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��91* �6   �� 5      $	��69* �6   .+�5   
   �� -   5         ��Name$ txtRequirement��5   �   $
��Left=�6   $��250,164,0,0q�6-   $��0��6B    �� TextWrapping$
 Wrap=�6K   $	��Top=�6_   $	��150��6w   $��40��6�   6�   �� 5   
   $�� Requirement (Kg/Week)��6   $
��Left=�61   $��
44,170,0,0q�6L   $	��Top=�6`   $	��170��6x   �� 5   
   -   5        $��	Calculate��5      $
��Left=�6%   $��270,216,0,0q�6@   $	��Top=�6U   $��40��6m   $��80��6y   4  .System.Windows.Automation.AutomationProperties   Name$  ��6�   6�   �� 5   
   -   5         ��Name$ txtArea��5   �   $!��0 feet square Area Required��6   $
��Left=�66   $��
50,246,0,0q�6Q   $	��Top=�6e   $	��190��6}    J� RenderTransformOrigin$ -1.233,4.521&�6�   $��1��6�   �� 5   
   -   5        $ 	txtPlants��5      $��0 Plants Required��6   $
��Left=�6,   $��
80,246,0,0q�6G   $	��Top=�6[   $	��150��6s   6   �� 5   
   -   5         ��Name$ btnDataEntry��5   �   $��
Data Entry��6   $
��Left=�6&   $��
245,16,0,0q�6A   $	��Top=�6U   $��40��6m   $��80��6y   ���	#FF60D55A$��1��6�   �� 5   
   $��Name Of Plant��6   $
��Left=�6(   $��425,170,0,0q�6C   $	��Top=�6X   $	��170��6p   $��2��6|   �� 5   
   -   5        $ txtNameOfPlant��5   �   $
��Left=�6   $��175,164,0,0q�6-   $��0��6B   $
 Wrap=�6K   $	��Top=�6_   $	��150��6w   $��40��6�   $��1��6�   �� 5   
   -   5        $ txtTotalLifeSpan��5      $��0 weeks life span��6   $
��Left=�6,   $��
50,301,0,0q�6G   $	��Top=�6[   $	��150��6s   $��1��6�   �� 5   
   -   5        $ txtAfterFirst��5   �   $4��.0 weeks put next plant from nursery into field��6   $
��Left=�6I   $��
80,301,0,0q�6d   $	��Top=�6x   $	��350��6�   6�   �� 5   
   -	   5        $ 	txtBrowse��5      $
��Left=�6%   $��
155,76,0,0q�6@   $��	file name��6T   $
 Wrap=�6e   $	��Top=�6y   $	��285��6�   $��50��6�   �� 5   
   -
   5        $ 	btnBrowse��5      $��Browse��6$   $
��Left=�65   $��5,78,0,0q�6P   $	��Top=�6b   $ 0.549,-0.204&�6z   $��26��6�   $	��100��6�   $��1��6�   5      5      