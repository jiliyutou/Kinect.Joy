   M S B A M L   `   `   `  ���� C  ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:FluidKit.ControlsFluidKit.Controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   BrushedMetalBackground  �� ImageSource j� TileMode j� ViewportUnits j� Viewport  WindowBackground �� 
StartPoint �� EndPoint �� Opacity � Color � Offset  CloseButtonStyle	 �� 
TargetType#    FluidKit.Controls.ImageButton
 �� Property �� Value  MinimizeButtonStyle  MaximizeButtonStyle  GlassWindow_Template �� 
TargetType#   FluidKit.Controls.GlassWindow �Name �� CornerRadius � ColumnDefinitions � RowDefinitions � Title ��Name �� Orientation   Name ��Name F�Name � Cursor �� Stretch ��Name  MacOSXWindowStyle�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     ,Controlsclr-namespace:FluidKit.Controls  %�
  &	        &	 F     &	 �     &	 �    &	 M    &	      7   7  7  7  7  &	 �	    7  �� $  images/metal.jpg��$
 Tile=�$ Absolute=�$ 	0,0,64,64��� $ 0,0.5&�$ 1,0.5&�$
 0.35Q�.��� $
 Gray��$ 0Q�� $ 	Gainsboro��$
 0.35Q�� $ 	Gainsboro��$
 0.75Q�� $
 Gray��$ 1Q��� "	   .��� 
 �@  NormalImage$ images/osx_close.png���� 
 �@  
HoverImage$" images/osx_close_hovered.png���� 
 �@  PressedImage$" images/osx_close_pressed.png���� "	   .��� 
 �@  NormalImage$ images/osx_min.png���� 
 �@  
HoverImage$  images/osx_min_hovered.png���� 
 �@  PressedImage$  images/osx_min_pressed.png���� "	   .��� 
 �@  NormalImage$ images/osx_max.png���� 
 �@  
HoverImage$  images/osx_max_hovered.png���� 
 �@  PressedImage$  images/osx_max_pressed.png���� "  .R�� $ PART_WindowContainer��.+��� $��0,0,0,0q�
�������$ 5,5,5,5��$��1,1,1,1q�8��  ._��� $��0,0,0,0q�$ 8,8,0,0��8�� ._�� $ ContentGrid��$��5,5,5,5q� ��  �� $��20 ��� $��* �.+�� $ PART_TitleBar��$
��Auto��$
��Auto��
������ $��0�� �� $
��Auto ��� $��* � �� .+��� $��Center=�$	��Top=�$
��Auto��$��0��$��2��#��z #��Z��#��Z��#��Z���� $ 
StackPanel��$
��Left=�$	��Top=�$��0,0,0,0q�$��16��$ 
Horizontal=�.+�   $ PART_CloseButton��8�� $��0,0,5,0q�   $ PART_MinimizeButton��8�� $��0,0,5,0q�   $ PART_MaximizeButton��8�� $��0,0,5,0q��� }�. $��1��$��0,0,0,0q�.u��� $ ContentPresenter��#��z��#��z��$
��Auto��$
��Auto��� $ ResizerGrid��$��Stretch=�$��0,0,0,0q�$
��Auto�� ��  �� .+�F� $ PART_WResizer��$��2��
������ $
��Left=�$��Stretch=�$ SizeWE��$
 Fill=����� -1��/� -10k~	F� $ PART_EResizer��$��2��
������ $��Right=�$��Stretch=�$ SizeWE��$
 Fill=����� -1��/� -10k~	F� $ PART_SResizer��$��2��
������ $��Stretch=�$��Bottom=�$ SizeNS��$
 Fill=����ЀA  ��
�&r ��
	F� $ PART_NResizer��$��2��
������ $��Stretch=�$	��Top=�$ SizeNS��$
 Fill=����ЀA  ��
�&r ��
	�� $ PART_NWResizer��
������ $
��Left=�$	��Top=�$��5��$��5��$ SizeNWSE���� $ PART_NEResizer��
������ $��Right=�$	��Top=�$��5��$��5��$ SizeNESW���� $ PART_SEResizer��
������ $��Right=�$��Bottom=�$��5��$��5��$ SizeNWSE���� $ PART_SWResizer��
������ $
��Left=�$��Bottom=�$��5��$��5��$ SizeNESW���� "	  .��� 
 �@�AllowsTransparency . �� 
 �@�WindowStyle$
 None=��� 
 �@�
ResizeMode$ 	CanResize=��� 
 � ��8   