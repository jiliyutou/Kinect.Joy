   M S B A M L   `   `   `  ����E  AKinect.Joy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Kinect.Joy
Kinect.Joy  5      C ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG1clr-namespace:FluidKit.Controls;assembly=FluidKitFluidKit.Controls 5          Kinect.Joy.FullView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5      &localclr-namespace:Kinect.Joy   5      ?fluid1clr-namespace:FluidKit.Controls;assembly=FluidKit   5      .��5      � -   5        $��FullViewRoot��5      $��10,10,10,10q�6    ��5   
   �� 5   
     �� 
StartPoint$	  0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ Azure��6    � Offset$	 0.0Q�6-   � 5      $ Lavender��6   $
 0.93Q�6,   5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��150 �6   .+�5   
   � $��0��6   $��Stretch=�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��200 �6#   .+�5      � $��0��6   
�������.+�5      +  %FluidKit.Controls.TransitionPresenter  -   5          Name$ 	TransPres��5   ,      
Transition 5       '  !FluidKit.Controls.GenieTransition  5!         
EffectType$ IntoLamp=�60   .@�5$      �� -   5        $��
ImgCurrent��5$      $��Uniform=�6.   	 J� Opacity$	 1Q�6@   
 � LayoutTransform
 5%      V� 5&      .~�5'   "   �� -   5        ImgScale�� �� ScaleX$ 1Q�5'   C    �� ScaleY$ 1Q�6N   �� 5(   "   -   5        
ImgRot�� �� Angle$ 0Q�5(   B   5)      5+      �� 5,      -   5        $��	WeiboTips��5,      $��Bottom=�6-   $��Right=�6H   
�������$��Center=�6w   $��Center=�6�   $��36(�6�   5-      5.      � 5/      $��1��6   $��10, 0, 0, 0q�6#    50      �� 51      $��* �6    �� 52      $	��150 �6    �� 53      $	��150 �6    �� 54      $	��150 �6    .+�56      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   5        $��1��56   %   $	��130��6H   $
��Auto��6U   $��Center=�6b   $��Center=�6�   ��57      �� 58       �� ImageSource$  ../Resources/Icon/back.png��6%    j� Stretch$ UniformToFill=�6N   5:        5;      -   5        $��2��5;   %   $	��130��6I   $
��Auto��6V   $��Center=�6c   $��Center=�6�   ��5<      �� 5=      $! ../Resources/Icon/weibo.png��6!   $ UniformToFill=�6K   5?        5@      -	   5        $��3��5@   %   $	��130��6J   $
��Auto��6W   $��Center=�6d   $��Center=�6�   ��5A      �� 5B      $" ../Resources/Icon/camera.png��6%   $ UniformToFill=�6P   5D      5E      5F      � 5H   
   $��1��6   $��Stretch=�6   $��0, 10, 0, 0q�6:    5I      �� 5J      $��* �6#   �� 5K      $��* �6#   �� 5L      $	��200 �6#   .+�5N        -
   5        $��0��5N   !   $
��Auto��6F   $
��Auto��6S   ��5O      �� 5P      $ ../Resources/Icon/pre.png��6!   $
 Fill=�6I   5R        5S      -   5        $��1��5S   !   $
��Auto��6G   $
��Auto��6T   ��5T      �� 5U      $  ../Resources/Icon/next.png��6!   $
 Fill=�6J   5W      � 5X      $��2��6   
�������$��10,0,0,0q�67   .+�5Y      8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  -   5        $��
UserViewer��5Y   %   5Z      5[      5\      5]      