   M S B A M L   `   `   `  ����C  ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG1clr-namespace:FluidKit.Controls;assembly=FluidKitFluidKit.Controls  5   	   E AKinect.Joy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Kinect.Joy
Kinect.Joy 5   	      Kinect.Joy.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5   	   <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5   	   ?fluid1clr-namespace:FluidKit.Controls;assembly=FluidKit   5   	   &localclr-namespace:Kinect.Joy   5   	   -   5        $��KinectJoyMainWindow��5
   	     � Title$  	KinectJoy��5	   	   $	��500��5   	   $	��700��5   	    � 	Resources 5         ChevronGeometry  	ChevronUp �� Stretch
 �� Top �� FallbackValue �� Path �� RelativeSource �� AncestorType" Kinect.Joy.KinectHoverButton J� RenderTransformOrigin	 �� Angle  ChevronRight  ChevronDown  ChevronLeft  KinectHoverButtonStyle
 �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value " KinectHoverButtonScrollUpStyle �� BasedOn % !KinectHoverButtonScrollRightStyle $  KinectHoverButtonScrollDownStyle $	  KinectHoverButtonScrollLeftStyle��%�  &	       &	 �    7   &	 Y   7   &	 .   7   &	    7   &	 �    &	 �    7  7  &	 ?    7  7  &	 �    7  7  &		 �    7  7  B�5   
   miF1M150.001,146.9932L126.565,169.3822L126.565,153.5962L150.001,130.6182L173.435,153.5962L173.435,169.3822z�5      F� 5   
   $��48��6!   $��48��6-   $ Uniform=�68   $ 0��6J   8��  ��5      �� $ Black��$ 
Foreground� �� "  $ 0.5,0.5&�5   M   z�5      �� 5      $	 0Q�6"   5      F� 5    
   $��48��6$   $��48��60   $ Uniform=�6;   $ 0��6M   8��  ��5"      �� $ Black��$ 
Foreground� �� "  $ 0.5,0.5&�5#   M   z�5$      �� 5%      $	 90Q�6"   5'      F� 5)   
   $��48��6#   $��48��6/   $ Uniform=�6:   $ 0��6L   8��  ��5+      �� $ Black��$ 
Foreground� �� "  $ 0.5,0.5&�5,   M   z�5-      �� 5.      $		 180Q�6"   50      F� 52   
   $��48��6#   $��48��6/   $ Uniform=�6:   $ 0��6L   8��  ��54      �� $ Black��$ 
Foreground� �� "  $ 0.5,0.5&�55   M   z�56      �� 57      $		 270Q�6"   59      �� 5;   
   "
  6/   .�5<      ��  � ��
 �����6+   �� 5=       � ��
 �����6,   �� 5>       � ��$ 0q�60   6<   �� 5?       � ��
 �����6;   �� 5@       � �� 5A      �� 5B      "  6&   .R�5C      � $��Stretch=�6   $��Stretch=�6=   #��z��6Y   #��z��6�   #��z��6�   .+�5D      �� #��z��6%   #��z��6Y   ._�5E   "   �� $��Stretch=�63   $��Stretch=�6Q   #��z��6m   6�   5F      5G      5H      5J       5K      P� 5L       � {� .  . �5M      ��  � ��
 �����63   �� 5N       � ��
 �����64   �� 5O       � ��
 ���� 6I   5P      P� 5Q       �@ IsHandPointerOver . . �5R      ��  � �� �#5A5B5B63   �� 5S       � ��
 �����63   5T      5V      �� 5X   
   "
  67   8   .�5Y      ��  � ��8  6(   5Z      �� 5\   
   "
  6:   8   .�5]      ��  � ��8  6(   5^      �� 5`   
   "
  69   8   .�5a      ��  � ��8  6(   5b      �� 5d   
   "
  69   8   .�5e      ��  � ��8  6(   5f      5g      .��5i      4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  -   5          Name$ kinectRegion��5i      .��5j   
   � -   5        $��
RootLayout��5j      ��5k      �� 5l       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5m      �  � Color$ Azure��6#    � Offset$	 0.0Q�61   � 5n      $ Lavender��6#   $
 0.93Q�64   5o      .+�5q      � -   5         �Name$ kinectRegionGrid��5q      $��10,10,10,10q�6.    � RowDefinitions 5r      �� 5s      $��* �6$   �� 5t      $	��150 �6$   .+�5v      � $��1��6   $��Stretch=�6$   $��0, 10, 0, 10q�6B    � ColumnDefinitions 5w      �� 5x      $��* �6+   �� 5y      $��* �6+   �� 5z      $	��200 �6+   .+�5|        "  Kinect.Joy.KinectHoverButton   Click$ PageLeftButtonClick��6x   $��0��6.   #��[	 6>   $��0,0,2,0q�6�   {�6�   ��  �� ElementName$ KinectJoyMainWindow��6�     5}      $ PageRightButtonClick��6y   $��1��6.   #��[ 6>   $��2,0,0,0q�6�   {�6�   �� $ KinectJoyMainWindow��6�   � 5~      $��2��6   
�������$��10,0,0,0q�6?   .+�5      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  -   5        $��
UserViewer��5   -      KinectRegion 6?   �� $ kinectRegion��4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  5�      -   5        $��sensorChooserUi��5�   g   $��Center=�62   $	��Top=�6O   6g   5�      5�      � 5�      $��0��6   $��Stretch=�6$    5�      �� 5�      $��* �6+   �� 5�      $	��200 �6+   .+�5�      � $��0��6   .+�5�      +   %FluidKit.Controls.TransitionPresenter  -   5          Name$ 	TransPres��5�   0      
Transition 5�      &    FluidKit.Controls.CubeTransition  5�      -   5        
TransRotat��   Rotation$ RightToLeft=�5�   G   .@�5�        Kinect.Joy.View3D  -	   5           Name$  VFlow��5�   '   5�      �� 5�      -
   5        $��	WeiboTips��5�      $��Bottom=�6-   $��Right=�6H   
�������$��Center=�6w   $��Center=�6�   $��36(�6�   5�      � 5�      $��1��6   $��10, 0, 0, 0q�6+    5�      �� 5�      $��* �6,   �� 5�      $	��150 �6,   �� 5�      $	��150 �6,   �� 5�      $	��150 �6,   .+�5�      � $��0��6   8	  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton	  5�      -   5        $��1��5�   -   $	��130��6V   $
��Auto��6c   $��Center=�6p   $��Center=�6�   ��5�      �� 5�   "   ! �� ImageSource$! ./Resources/Icon/full.png��6-   " j� Stretch$" UniformToFill=�6U   5�      	  5�      -   5        $��2��5�   -   $	��130��6Q   $
��Auto��6^   $��Center=�6k   $��Center=�6�   ��5�      �� 5�   "   $ ! ./Resources/Icon/weibo.png��6-   $" UniformToFill=�6V   5�      	  5�      -   5        $��3��5�   -   $	��130��6S   $
��Auto��6`   $��Center=�6m   $��Center=�6�   ��5�      �� 5�   "   $!! ./Resources/Icon/camera.png��6-   $" UniformToFill=�6W   5�      5�      5�      5�      5�      5�      5�      