   M S B A M L   `   `   `  ���� C  ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FluidKit.ControlsFluidKit.Controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   WindowBlueBorder �� 
StartPoint �� EndPoint � Color � Offset  WindowIconStyle �� 
TargetType �� Property �� Value  WindowTitleStyle  CloseButtonStyle#    FluidKit.Controls.ImageButton  MinimizeButtonStyle  MaximizeButtonStyle  GlassWindow_Template	 �� 
TargetType#   FluidKit.Controls.GlassWindow
 �� CornerRadius  Vista_Background_design � ColumnDefinitions � RowDefinitions �Name ��Name � Icon ��Name � Title J� BitmapEffect O� 	GlowColor O� Noise O� Opacity O� GlowSize �� Orientation   Name ��Name F�Name � Cursor �� Stretch ��Name �� Triggers P� Property  P� Value! �� 
TargetName" ]� 
Conditions# �� Property$ �� Value�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     ,Controlsclr-namespace:FluidKit.Controls    �� $ VistaBackground.xaml?�%�  &	        &	 x     &	 �     &	 =    &	 �    &	 �    &	 n    7  7   7  7  7  7  7  '  �    7  �� $ 0.5,0&�$ 0.5,1&�.��� $ 	#FFFFFFFF��$ 0Q�� $- 'sc#1, 0.08701243, 0.9357051, 0.52502346��$ 1Q��� " ��.���  � ��$
 Left=���  � ��$ 22����  � ��$ 22���� " ��.���  � ��$
 Left=���  � ��$ Center=���  � ��$ NoWrap=���  � ��$ 3,0,0,0q��� "   .���  �@  NormalImage$ images/vista_close.png����  �@  
HoverImage$$ images/vista_close_hovered.png����  �@  PressedImage$$ images/vista_close_pressed.png���� "   .���  �@  NormalImage$ images/vista_min.png����  �@  
HoverImage$" images/vista_min_hovered.png����  �@  PressedImage$" images/vista_min_pressed.png���� "   .���  �@  NormalImage$ images/vista_max.png����  �@  
HoverImage$" images/vista_max_hovered.png����  �@  PressedImage$" images/vista_max_pressed.png���� "	  .R��� 
�������$��1,1,1,1q�$
 5,5,5,5��8��  ._��� 8�� $��1,1,1,1q�$
 5,5,5,5��._��  ��  �� .+�� $ ContentGrid��$��0,0,0,0q� ��  �� $��32 ��� $��* �.+�� $ PART_TitleBar��$��0,0,0,0q�
������  �� $��32 ��� $��* ��� $
��Auto �.+��� $ Image��$��0��#��z 8�� $��Center=��� $ 	TextBlock��$��1��8�� #��z #��Z��#��Z��#��Z��
������� O� $ White��$ 0Q�$	 0.5Q�$ 10Q��� $ 
Horizontal=�$��2��$��18��$	��Top=�$��Right=�$��0,0,5,0q�.+�   $ PART_MinimizeButton��8��    $ PART_MaximizeButton��8��    $ PART_CloseButton��8�� �� $��5,0,5,5q�$��1��._��� }�. .u��� $ ContentPresenter��#��z��#��z��$
��Auto��$
��Auto��� $ ResizerGrid��$��Stretch=�$��0,0,0,0q�$
��Auto�� ��  �� .+�F� $ PART_WResizer��$��2��
������ $
��Left=�$��Stretch=�$ SizeWE��$
 Fill=����� -1��/� -10k~	F� $ PART_EResizer��$��2��
������ $��Right=�$��Stretch=�$ SizeWE��$
 Fill=����� -1��/� -10k~	F� $ PART_SResizer��$��2��
������ $��Stretch=�$��Bottom=�$ SizeNS��$
 Fill=����ЀA  ��
�&r ��
	F� $ PART_NResizer��$��2��
������ $��Stretch=�$	��Top=�$ SizeNS��$
 Fill=����ЀA  ��
�&r ��
	�� $ PART_NWResizer��
������ $
��Left=�$	��Top=�$��5��$��5��$ SizeNWSE���� $ PART_NEResizer��
������ $��Right=�$	��Top=�$��5��$��5��$ SizeNESW���� $ PART_SEResizer��
������ $��Right=�$��Bottom=�$��5��$��5��$ SizeNWSE���� $ PART_SWResizer��
������ $
��Left=�$��Bottom=�$��5��$��5��$ SizeNESW�� P�  �@�WindowState$  	Maximized=�. ��� $! PART_MaximizeButton�� �@  NormalImage$ images/vista_restore.png���� $! PART_MaximizeButton�� �@  
HoverImage$&  images/vista_restore_hovered.png���� $! PART_MaximizeButton�� �@  PressedImage$&  images/vista_restore_pressed.png���� $! PART_NResizer�� � y�$ Hidden=��� $! PART_SResizer�� � y�$ Hidden=��� $! PART_EResizer�� � y�$ Hidden=��� $! PART_WResizer�� � y�$ Hidden=��� $! PART_NEResizer�� � y�$ Hidden=��� $! PART_NWResizer�� � y�$ Hidden=��� $! PART_SEResizer�� � y�$ Hidden=��� $! PART_SWResizer�� � y�$ Hidden=�P�  �@�
ResizeMode$  NoResize=�. ��� $! PART_MinimizeButton�� � y�$ 	Collapsed=��� $! PART_MaximizeButton�� � y�$ 	Collapsed=��� $! PART_CloseButton�� �@  NormalImage$! images/vista_close_only.png���� $! PART_CloseButton�� �@  
HoverImage$) #images/vista_close_only_hovered.png���� $! PART_CloseButton�� �@  PressedImage$) #images/vista_close_only_pressed.png���� $! PART_NResizer�� � y�$ Hidden=��� $! PART_SResizer�� � y�$ Hidden=��� $! PART_EResizer�� � y�$ Hidden=��� $! PART_WResizer�� � y�$ Hidden=��� $! PART_NEResizer�� � y�$ Hidden=��� $! PART_NWResizer�� � y�$ Hidden=��� $! PART_SEResizer�� � y�$ Hidden=��� $! PART_SWResizer�� � y�$ Hidden=�]� " �� # �@�WindowState$$ Normal=��� # �@�
ResizeMode$$ 	CanResize=�./��� $! PART_MaximizeButton�� �@  NormalImage$ images/vista_max.png���� $! PART_MaximizeButton�� �@  
HoverImage$" images/vista_max_hovered.png���� $! PART_MaximizeButton�� �@  PressedImage$" images/vista_max_pressed.png���� $! PART_NResizer�� � y�$ Visible=��� $! PART_SResizer�� � y�$ Visible=��� $! PART_EResizer�� � y�$ Visible=��� $! PART_WResizer�� � y�$ Visible=��� $! PART_NEResizer�� � y�$ Visible=��� $! PART_NWResizer�� � y�$ Visible=��� $! PART_SEResizer�� � y�$ Visible=��� $! PART_SWResizer�� � y�$ Visible=��� "  .���  �@�AllowsTransparency . ��  �@�WindowStyle$
 None=���  �@�
ResizeMode$ 	CanResize=���  � ��8   