   M S B A M L   `   `   `  ����C  ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FluidKit.ControlsFluidKit.Controls  5
      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   WindowBlueBorder �� 
StartPoint �� EndPoint � Color � Offset  WindowIconStyle �� 
TargetType �� Property �� Value  WindowTitleStyle  CloseButtonStyle#    FluidKit.Controls.ImageButton  MinimizeButtonStyle  MaximizeButtonStyle  GlassWindow_Template	 �� 
TargetType#   FluidKit.Controls.GlassWindow
 �� CornerRadius  Vista_Background_design � ColumnDefinitions � RowDefinitions �Name ��Name � Icon ��Name � Title J� BitmapEffect O� 	GlowColor O� Noise O� Opacity O� GlowSize �� Orientation   Name ��Name F�Name � Cursor �� Stretch ��Name �� Triggers P� Property  P� Value! �� 
TargetName" ]� 
Conditions# �� Property$ �� Value�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5	      ,Controlsclr-namespace:FluidKit.Controls  5
        5      �� 5      $ VistaBackground.xaml?�6   %�   &	        &	 �     &	 l    &	 C    &	 S    &	 ]    &	 g    7  7   7  7  7  7  7  '  R    7  �� 5      $ 0.5,0&�5      $ 0.5,1&�5      .��5      � $ 	#FFFFFFFF��6   $ 0Q�5   
   � 5      $- 'sc#1, 0.08701243, 0.9357051, 0.52502346��6   $ 1Q�5   
   5      �� 5#      " ��5$      .�5%      ��  � ��$
 Left=�5&      �� 5'       � ��$ 22��5(      �� 5)       � ��$ 22��5*      5+      �� 52      " ��53      .�54      ��  � ��$
 Left=�55      �� 56       � ��$ Center=�57      �� 58       � ��$ NoWrap=�59      �� 5:       � ��$ 3,0,0,0q�5;      5<      �� 5C      "   5D      .�5E      ��  �@  NormalImage$ images/vista_close.png��5F      �� 5G       �@  
HoverImage$$ images/vista_close_hovered.png��5H      �� 5I       �@  PressedImage$$ images/vista_close_pressed.png��5J      5K      �� 5R      "   5S      .�5T      ��  �@  NormalImage$ images/vista_min.png��5U      �� 5V       �@  
HoverImage$" images/vista_min_hovered.png��5W      �� 5X       �@  PressedImage$" images/vista_min_pressed.png��5Y      5Z      �� 5a      "   5b      .�5c      ��  �@  NormalImage$ images/vista_max.png��5d      �� 5e       �@  
HoverImage$" images/vista_max_hovered.png��5f      �� 5g       �@  PressedImage$" images/vista_max_pressed.png��5h      5i      �� 5p      "	  5q      .R�5r      �� 
�������$��1,1,1,1q�5s      $
 5,5,5,5��5t      8��  ._�5v      �� 8�� $��1,1,1,1q�5w      $
 5,5,5,5��5x      ._�5z      �  5{      �� 5|       5~      �� 5      .+�5�      � $ ContentGrid��5�   	   $��0,0,0,0q�5�       5�      �� 5�   	    5�      �� 5�   	   $��32 �6   �� 5�   	   $��* �6   .+�5�      � $ PART_TitleBar��5�   
   $��0,0,0,0q�5�      
������  5�   	   �� 5�   
   $��32 �6   �� 5�   
   $��* �6   �� 5�   
   $
��Auto �6   .+�5�   	   �� $ Image��6   $��0��5�      #��z 5�      8�� $��Center=�5�      �� 5�   	   $ 	TextBlock��5�      $��1��5�      8�� #��z 5�      #��Z��5�      #��Z��5�      #��Z��5�      
������� 5�   
   O� 5�      $ White��6!   $ 0Q�5�      $	 0.5Q�5�      $ 10Q�5�      5�   
   �� 5�   	   $ 
Horizontal=�6   $��2��5�      $��18��5�      $	��Top=�5�      $��Right=�5�      $��0,0,5,0q�5�      .+�5�   
      $ PART_MinimizeButton��6   8�� 5�         5�   
   $ PART_MaximizeButton��6   8�� 5�         5�   
   $ PART_CloseButton��6   8�� 5�      5�   
   5�   	   �� 5�      $��5,0,5,5q�6   $��1��5�      ._�5�   	   �� }�. .u�5�   
   �� $ ContentPresenter��6   #��z��5�      #��z��5�      $
��Auto��5�      $
��Auto��5�      5�   
   5�   	   5�      � 5�      $ ResizerGrid��5�   	   $��Stretch=�5�      $��0,0,0,0q�5�   	   $
��Auto��5�   	    5�      �� 5�   	    5�      �� 5�   	   .+�5�      F� $ PART_WResizer��5�   
   $��2��5�      
������ $
��Left=�5�   
   $��Stretch=�5�   
   $ SizeWE��5�   
   $
 Fill=�5�   
   ���� -1��/� -10k~	5�   
   F� 5�      $ PART_EResizer��5�   
   $��2��5�      
������ $��Right=�5�   
   $��Stretch=�5�   
   $ SizeWE��5�   
   $
 Fill=�5�   
   ���� -1��/� -10k~	5�   
   F� 5�      $ PART_SResizer��5�   
   $��2��5�      
������ $��Stretch=�5�   
   $��Bottom=�5�   
   $ SizeNS��5�   
   $
 Fill=�5�   
   ���ЀA  ��
�&r ��
	5�   
   F� 5�      $ PART_NResizer��5�   
   $��2��5�      
������ $��Stretch=�5�   
   $	��Top=�5�   
   $ SizeNS��5�   
   $
 Fill=�5�   
   ���ЀA  ��
�&r ��
	5�   
   �� 5�      $ PART_NWResizer��5�      
������ $
��Left=�5�      $	��Top=�5�      $��5��5�      $��5��5�      $ SizeNWSE��5�      �� 5�      $ PART_NEResizer��5�      
������ $��Right=�5�      $	��Top=�5�      $��5��5�      $��5��5�      $ SizeNESW��5�      �� 5�      $ PART_SEResizer��5     
������ $��Right=�5      $��Bottom=�5     $��5��5     $��5��5     $ SizeNWSE��5     �� 5     $ PART_SWResizer��5     
������ $
��Left=�5     $��Bottom=�5     $��5��5	     $��5��5
     $ SizeNESW��5     5     5     5     5      5     P� 5      �@�WindowState$  	Maximized=�5  	   . �5     �� $! PART_MaximizeButton��5  	    �@  NormalImage$ images/vista_restore.png��5  	   5  	   �� 5     $! PART_MaximizeButton��5  	    �@  
HoverImage$&  images/vista_restore_hovered.png��5  	   5  	   �� 5     $! PART_MaximizeButton��5  	    �@  PressedImage$&  images/vista_restore_pressed.png��5  	   5  	   �� 5      $! PART_NResizer��5"  	    � y�$ Hidden=�5!  	   5"  	   �� 5#     $! PART_SResizer��5%  	    � y�$ Hidden=�5$  	   5%  	   �� 5&     $! PART_EResizer��5(  	    � y�$ Hidden=�5'  	   5(  	   �� 5)     $! PART_WResizer��5+  	    � y�$ Hidden=�5*  	   5+  	   �� 5,     $! PART_NEResizer��5.  	    � y�$ Hidden=�5-  	   5.  	   �� 5/     $! PART_NWResizer��51  	    � y�$ Hidden=�50  	   51  	   �� 52     $! PART_SEResizer��54  	    � y�$ Hidden=�53  	   54  	   �� 55     $! PART_SWResizer��57  	    � y�$ Hidden=�56  	   57  	   58     P� 5;      �@�
ResizeMode$  NoResize=�5<  	   . �5=     �� $! PART_MinimizeButton��5?  	    � y�$ 	Collapsed=�5>  	   5?  	   �� 5@     $! PART_MaximizeButton��5B  	    � y�$ 	Collapsed=�5A  	   5B  	   �� 5D     $! PART_CloseButton��5F  	    �@  NormalImage$! images/vista_close_only.png��5E  	   5F  	   �� 5G     $! PART_CloseButton��5I  	    �@  
HoverImage$) #images/vista_close_only_hovered.png��5H  	   5I  	   �� 5J     $! PART_CloseButton��5L  	    �@  PressedImage$) #images/vista_close_only_pressed.png��5K  	   5L  	   �� 5N     $! PART_NResizer��5P  	    � y�$ Hidden=�5O  	   5P  	   �� 5Q     $! PART_SResizer��5S  	    � y�$ Hidden=�5R  	   5S  	   �� 5T     $! PART_EResizer��5V  	    � y�$ Hidden=�5U  	   5V  	   �� 5W     $! PART_WResizer��5Y  	    � y�$ Hidden=�5X  	   5Y  	   �� 5Z     $! PART_NEResizer��5\  	    � y�$ Hidden=�5[  	   5\  	   �� 5]     $! PART_NWResizer��5_  	    � y�$ Hidden=�5^  	   5_  	   �� 5`     $! PART_SEResizer��5b  	    � y�$ Hidden=�5a  	   5b  	   �� 5c     $! PART_SWResizer��5e  	    � y�$ Hidden=�5d  	   5e  	   5f     ]� 5i     " 5j     �� 5k     # �@�WindowState$$ Normal=�5l     �� 5m     # �@�
ResizeMode$$ 	CanResize=�5n     ./�5q     �� $! PART_MaximizeButton��5s  	    �@  NormalImage$ images/vista_max.png��5r  	   5s  	   �� 5t     $! PART_MaximizeButton��5v  	    �@  
HoverImage$" images/vista_max_hovered.png��5u  	   5v  	   �� 5w     $! PART_MaximizeButton��5y  	    �@  PressedImage$" images/vista_max_pressed.png��5x  	   5y  	   �� 5z     $! PART_NResizer��5|  	    � y�$ Visible=�5{  	   5|  	   �� 5}     $! PART_SResizer��5  	    � y�$ Visible=�5~  	   5  	   �� 5�     $! PART_EResizer��5�  	    � y�$ Visible=�5�  	   5�  	   �� 5�     $! PART_WResizer��5�  	    � y�$ Visible=�5�  	   5�  	   �� 5�     $! PART_NEResizer��5�  	    � y�$ Visible=�5�  	   5�  	   �� 5�     $! PART_NWResizer��5�  	    � y�$ Visible=�5�  	   5�  	   �� 5�     $! PART_SEResizer��5�  	    � y�$ Visible=�5�  	   5�  	   �� 5�     $! PART_SWResizer��5�  	    � y�$ Visible=�5�  	   5�  	   5�     5�     �� 5�     "  6	   .�5�     ��  �@�AllowsTransparency . 5�     �� 5�      �@�WindowStyle$
 None=�5�     �� 5�      �@�
ResizeMode$ 	CanResize=�5�     �� 5�      � ��8   5�     5�     5�     