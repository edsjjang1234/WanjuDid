   M S B A M L   `   `   `  ����	  DIDEx    DIDEx.Views.Videos   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      N JPrism.DryIoc.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=nullS OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . $
��1080��5   >   $
��1920��6K   ��5      �� 5	   
    �� ImageSource$, &/DIDEx;component/Resources/main_bg.jpg��6   #  Prism.Services.Dialogs.Dialog   WindowStyle 5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@ WindowStartupLocation �� Value$ CenterScreen=�6C   �� 5       �@�
ResizeMode$ NoResize=�6+   �� 5       �@�ShowInTaskbar .  6.   �� 5       �@�SizeToContent$ WidthAndHeight=�6.   �� 5       �@�WindowState$ 	Maximized=�6-   5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *LoadedCommand+5      .��5      � 
 J� InputBindings
 5   
   d� 5       d� Gesture$ 	LeftClicka�6    �� Command 6/   �� *CloseDialogCommand+ � RowDefinitions 5!   
   �� 5"      $	��250 �6   �� 5#      $	��651 �6   �� 5$      $	��651 �6   �� 5%      $��2* �6   .+�5'   
   � $��1��6   ��5(      �� 5)      $/ )/DIDEx;component/Resources/VidioTouch.png��6   5,      � 5-   
   $��2��6   .+�52      r� -   5        $��MediaElement��52       r� Stretch$
 Fill=�6/   $
��1000��6[    r� Source 6>   �� *	UriSource+ 53        54      $ 
MediaEnded��6%   . 55        	 60   �� *MediaEndedCommand+   CommandParameter 6V   ��  �� ElementName$ MediaElement��56      58      5:      � 5;   
   $��3��6   $	��Top=�6   5=      5>      5?      