   M S B A M L   `   `   `  ���� E  AKinect.Joy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Kinect.Joy
Kinect.Joy  C ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG1clr-namespace:FluidKit.Controls;assembly=FluidKitFluidKit.Controls     Kinect.Joy.FullView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   &localclr-namespace:Kinect.Joy   ?fluid1clr-namespace:FluidKit.Controls;assembly=FluidKit   .��� -   $��FullViewRoot��$��10,10,10,10q�����   �� 
StartPoint$	  0,0&� �� EndPoint$	 1,1&�.���  � Color$ Azure�� � Offset$	 0.0Q�� $ Lavender��$
 0.93Q� � RowDefinitions �� $��* ��� $	��150 �.+�� $��0��$��Stretch=� � ColumnDefinitions �� $��* ��� $	��200 �.+�� $��0��
�������.+�+  %FluidKit.Controls.TransitionPresenter  -     Name$ 	TransPres��   
Transition '  !FluidKit.Controls.GenieTransition     
EffectType$ IntoLamp=�.@��� -   $��
ImgCurrent��$��Uniform=�	 J� Opacity$	 1Q�
 � LayoutTransform
 V� .~��� -   ImgScale�� �� ScaleX$ 1Q� �� ScaleY$ 1Q��� -   
ImgRot�� �� Angle$ 0Q��� -   $��	WeiboTips��$��Bottom=�$��Right=�
�������$��Center=�$��Center=�$��36(�� $��1��$��10, 0, 0, 0q� �� $��* ��� $	��150 ��� $	��150 �.+�8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   $��1��$	��130��$
��Auto��$��Center=�$��Center=�����  �� ImageSource$  ../Resources/Icon/back.png�� j� Stretch$ UniformToFill=�  -   $��2��$	��130��$
��Auto��$��Center=�$��Center=����� $! ../Resources/Icon/weibo.png��$ UniformToFill=�� $��1��$��Stretch=�$��0, 10, 0, 10q� �� $��* ��� $��* ��� $	��200 �.+�  -	   $��0��$
��Auto��$
��Auto������ $ ../Resources/Icon/pre.png��$
 Fill=�  -
   $��1��$
��Auto��$
��Auto������ $  ../Resources/Icon/next.png��$
 Fill=�� $��2��
�������$��10,0,0,0q�.+�8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  -   $��
UserViewer��