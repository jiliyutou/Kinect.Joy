   M S B A M L   `   `   `  ���� C  ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG1clr-namespace:FluidKit.Controls;assembly=FluidKitFluidKit.Controls  E AKinect.Joy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Kinect.Joy
Kinect.Joy    Kinect.Joy.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   <d2http://schemas.microsoft.com/expression/blend/2008   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   ?fluid1clr-namespace:FluidKit.Controls;assembly=FluidKit   &localclr-namespace:Kinect.Joy   -   $��KinectJoyMainWindow��  � Title$  	KinectJoy��$
��1400��$	��800�� � 	Resources    ChevronGeometry  	ChevronUp �� Stretch
 �� Top �� FallbackValue �� Path �� RelativeSource �� AncestorType" Kinect.Joy.KinectHoverButton J� RenderTransformOrigin	 �� Angle  ChevronRight  ChevronDown  ChevronLeft  KinectHoverButtonStyle
 �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value " KinectHoverButtonScrollUpStyle �� BasedOn % !KinectHoverButtonScrollRightStyle $  KinectHoverButtonScrollDownStyle $	  KinectHoverButtonScrollLeftStyle��%o  &	       &	 s    7   &	 �    7   &	 ~   7   &	    7   &	 �    &	 K    7  7  &	 o    7  7  &	 �    7  7  &		 �    7  7  B�miF1M150.001,146.9932L126.565,169.3822L126.565,153.5962L150.001,130.6182L173.435,153.5962L173.435,169.3822z�F� $��48��$��48��$ Uniform=�$ 0��8��  ���� $ Black��$ 
Foreground� �� "  $ 0.5,0.5&�z��� $	 0Q�F� $��48��$��48��$ Uniform=�$ 0��8��  ���� $ Black��$ 
Foreground� �� "  $ 0.5,0.5&�z��� $	 90Q�F� $��48��$��48��$ Uniform=�$ 0��8��  ���� $ Black��$ 
Foreground� �� "  $ 0.5,0.5&�z��� $		 180Q�F� $��48��$��48��$ Uniform=�$ 0��8��  ���� $ Black��$ 
Foreground� �� "  $ 0.5,0.5&�z��� $		 270Q��� "
  .���  � ��
 �������  � ��
 �������  � ��$ 0q���  � ��
 �������  � �� �� "  .R�� $��Stretch=�$��Stretch=�#��z��#��z��#��z��.+��� #��z��#��z��._��� $��Stretch=�$��Stretch=�#��z�� P�  � {� .  . ���  � ��
 �������  � ��
 �������  � ��
 ���� P�  �@ IsHandPointerOver . . ���  � �� �#5A5B5B��  � ��
 ������� "
  8   .���  � ��8  �� "
  8   .���  � ��8  �� "
  8   .���  � ��8  �� "
  8   .���  � ��8  .��4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  -     Name$ kinectRegion��.��� -   $��
RootLayout������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ Azure�� � Offset$	 0.0Q�� $ Lavender��$
 0.93Q�.+�� -    �Name$ kinectRegionGrid��$��10,10,10,10q� � RowDefinitions �� $��* ��� $	��150 �.+�� $��1��$��Stretch=�$��0, 10, 0, 10q� � ColumnDefinitions �� $��* ��� $��* ��� $	��200 �.+�  "  Kinect.Joy.KinectHoverButton   Click$ PageLeftButtonClick��$��0��#��[	 $��0,0,2,0q�{���  �� ElementName$ KinectJoyMainWindow��  $ PageRightButtonClick��$��1��#��[ $��2,0,0,0q�{��� $ KinectJoyMainWindow��� $��2��
�������$��10,0,0,0q�.+�8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  -   $��
UserViewer��   KinectRegion �� $ kinectRegion��4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  -   $��sensorChooserUi��$��Center=�$	��Top=�� $��0��$��Stretch=� �� $��* ��� $	��200 �.+�� $��0��.+�+   %FluidKit.Controls.TransitionPresenter  -     Name$ 	TransPres��   
Transition &    FluidKit.Controls.CubeTransition  -   
TransRotat��   Rotation$ RightToLeft=�.@�  Kinect.Joy.View3D  -	      Name$  VFlow���� -
   $��	WeiboTips��$��Bottom=�$��Right=�
�������$��Center=�$��Center=�$��36(�� $��1��$��10, 0, 0, 0q� �� $��* ��� $	��150 ��� $	��150 ��� $	��150 ��� $	��150 �.+�� $��0��8	  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton	  -   $��StyleBtn��$��1��$	��130��$
��Auto��$��Center=�$��Center=����� ! �� ImageSource$(! "./Resources/Icon/2_timemachine.png��" j� Stretch$" UniformToFill=�	  -   $��2��$	��130��$
��Auto��$��Center=�$��Center=����� $ ! ./Resources/Icon/weibo.png��$" UniformToFill=�	  -   $��3��$	��130��$
��Auto��$��Center=�$��Center=����� $! ./Resources/Icon/full.png��$" UniformToFill=�	  -   $��4��$	��130��$
��Auto��$��Center=�$��Center=����� $!! ./Resources/Icon/camera.png��$" UniformToFill=�