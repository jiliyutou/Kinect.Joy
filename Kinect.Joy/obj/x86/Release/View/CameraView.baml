   M S B A M L   `   `   `  ���� E  AKinect.Joy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Kinect.Joy
Kinect.Joy  C ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG1clr-namespace:FluidKit.Controls;assembly=FluidKitFluidKit.Controls     Kinect.Joy.CameraView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     \ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullS OMicrosoft.Kinect.Toolkit, Version=1.7.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   &localclr-namespace:Kinect.Joy   ?fluid1clr-namespace:FluidKit.Controls;assembly=FluidKit   .��� -   $��CameraViewRoot��$��10,10,10,10q�����   �� 
StartPoint$	  0,0&� �� EndPoint$	 1,1&�.���  � Color$ Azure�� � Offset$	 0.0Q�� $ Lavender��$
 0.93Q� � ColumnDefinitions �� $��* ��� $	��200 �.+�� $��0��
�������$��0,0,10,0q�.+�(�  (� Stretch$ Uniform=�$��Center=�.��� .+��� -   $��
ImgCurrent��$��UniformToFill=� J� Opacity$ 1Q��� -   $��CountDownLable��$	��Top=�$��Right=�
�������$��Center=�$��Center=�$��72(�$��5���� -   $��OverviewImage��$	��160��$	��120��$	��Top=�$��Right=��� -   $��	WeiboTips��$��Bottom=�$��Right=�
�������$��Center=�$��Center=�$��36(��� -   $��Skel_Canvas��� $��1��$��10, 0, 0, 0q� � RowDefinitions �� $��* ��� $	��150 ��� $	��150 ��� $	��150 ��� $	��150 �.+�8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   $��WeiboBtn��$��1��$	��130��$
��Auto��$��Center=�$��Center=�$y�Hidden=�����  �� ImageSource$! ../Resources/Icon/weibo.png��	 j� Stretch$	 UniformToFill=�  -   $��2��$	��130��$
��Auto��$��Center=�$��Center=����� $  ../Resources/Icon/back.png��$	 UniformToFill=�  -	   $��3��$	��130��$
��Auto��$��Center=�$��Center=����� $" ../Resources/Icon/camera.png��$	 UniformToFill=�� $��4��$	��130��$
��Auto��
�������.+�8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  -
   $��
UserViewer��