   M S B A M L   `   `   `  ����^  ZMicrosoft.Samples.Kinect.WpfViewers, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Microsoft.Samples.Kinect.WpfViewers#Microsoft.Samples.Kinect.WpfViewers  5      @    :Microsoft.Samples.Kinect.WpfViewers.KinectDiagnosticViewer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @kt1clr-namespace:Microsoft.Samples.Kinect.WpfViewers     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5	      �   � Orientation$  
Horizontal=�6   .+�5   
   �� .+�5      �� $��12(�6   $��Color Image��6&   $��Center=�69   ;   5Microsoft.Samples.Kinect.WpfViewers.KinectColorViewer  5      -   5          Name$ kinectColorViewer��5   <   $	��400��6#   $	��300��6/   $��
10 0 10 10q�5   <   5      �� 5   
   .+�5      �� $��12(�6   $��Depth Image��6&   $��Center=�69   ;   5Microsoft.Samples.Kinect.WpfViewers.KinectDepthViewer  5      -   5          Name$ kinectDepthViewer��5   <   $	��400��6#   $	��300��6/   $��
10 0 10 10q�5   <   5      �� 5   
   -   5        $��skeletonPanel��5      .+�5      �� $��12(�6   $��Detected Skeletons��6&   $��Center=�6@   �� 5      -   5        $��skeletonCanvas��5   .   $	��400��6   $	��300��6!   $��
10 0 10 10q�6D   
���   �}�. 5   (   5      �� 5!   
    �� Orientation$ 
Horizontal=�6   .+�5#      �� $
��Left=�6   $��10 10 10 10q�64   .+�5$      �� -   5        $��text1��5$      $��14(�6)   $
��Bold"�67   
���  ��Porneste invatarea!6p   �� 5%      -   5        $��b1��5%      $��10 10 10 10q�65   ��5&      �� 5'      .R�5(      �� $��Resources\skels2.bmp��6$   5)      5+      �� 5,      -   5        $��text2��5,      
���  ��6<   54      �� 57      -   5        $��Position��57      $��100 0 100 0q�6)   .+�59      �� $ Vertical=�6   $��10 10 10 10q�64   .+�5;      �� $ Vertical=�6!   $��5 5 5 5q�68   .+�5<      �� 
���� ��
�������$
��Left=�6V   $��Center=�6q   .+�5=      �� $��22(�6(   $
��Bold"�66   
Trunchi:6R   5>      �� 5?      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5@      �� -	   5        $��bodyPositionText��5@   (   $��18(�6@   5A      �� 5B      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5C      �� -
   5        $��bodyMotionText��5C   (   $��18(�6>   5D      5E      �� 5G      $ Vertical=�6!   $��5 5 5 5q�68   .+�5H      �� 
���� ��
�������$
��Left=�6V   $��Center=�6q   .+�5I      �� $��22(�6(   $
��Bold"�66   Membru superior stang:6`   5J      �� 5K      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5L      �� -   5        $��leftHandPositionText��5L   (   $��18(�6D   5M      �� 5N      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5O      �� -   5        $��leftHandMotionText��5O   (   $��18(�6B   5P      5Q      �� 5S      $ Vertical=�6!   $��5 5 5 5q�68   .+�5T      �� 
���� ��
�������$
��Left=�6V   $��Center=�6q   .+�5U      �� $��22(�6(   $
��Bold"�66   Membru superior drept:6`   5V      �� 5W      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5X      �� -   5        $��rightHandPositionText��5X   (   $��18(�6E   5Y      �� 5Z      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5[      �� -   5        $��rightHandMotionText��5[   (   $��18(�6C   5\      5]      �� 5_      $ Vertical=�6!   $��5 5 5 5q�68   .+�5`      �� 
���� ��
�������$
��Left=�6V   $��Center=�6q   .+�5a      �� $��22(�6(   $
��Bold"�66   Membru inferior stang:6`   5b      �� 5c      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5d      �� -   5        $��leftLegPositionText��5d   (   $��18(�6C   5e      �� 5f      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5g      �� -   5        $��leftLegMotionText��5g   (   $��18(�6A   5h      5i      �� 5k      $ Vertical=�6!   $��5 5 5 5q�68   .+�5l      �� 
���� ��
�������$
��Left=�6V   $��Center=�6q   .+�5m      �� $��22(�6(   $
��Bold"�66   Membru inferior drept:6`   5n      �� 5o      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5p      �� -   5        $��rightLegPositionText��5p   (   $��18(�6D   5q      �� 5r      
����=H�
�������$
��Left=�6]   $��Center=�6x   .+�5s      �� -   5        $��rightLegMotionText��5s   (   $��18(�6B   5t      5u      5w      5x      5y      5z      5{      