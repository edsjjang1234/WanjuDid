   M S B A M L   `   `   `  ���� 	  DIDEx    DIDEx.Views.Videos   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  N JPrism.DryIoc.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=nullS OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . $
��1080��$
��2000��#  Prism.Services.Dialogs.Dialog   WindowStyle ��  �� 
TargetType" �.���  �� Property �@ WindowStartupLocation �� Value$ CenterScreen=���  �@�
ResizeMode$ NoResize=���  �@�ShowInTaskbar .  ��  �@�SizeToContent$ WidthAndHeight=�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ Loaded��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *LoadedCommand+.��� ���� 	 �� ImageSource$,	 &/DIDEx;component/Resources/main_bg.png��
 J� InputBindings
 d�  d� Gesture$ 	LeftClicka� �� Command �� *CloseDialogCommand+ � RowDefinitions �� $
��0.3* ��� $��1* ��� $
��0.5* �.+�� $��0�� � ColumnDefinitions �� $��0.03* ��� $��1* ��� $��0.05* � �� $��0.05* ��� $��1* ��� $��0.05* �.+�� $��1��$��1�� �� $
��0.7* ��� $��1* ��� $��1* � �� $
��0.3* ��� $
��0.5* ��� $��1* �.+�� $��1��$��0������ $)	 #/DIDEx;component/Resources/logo.gif��� $��1��.+�r� -   $��MediaElement�� r� Source �� *	UriSource+   $ 
MediaEnded��.    �� *MediaEndedCommand+   CommandParameter ��  �� ElementName$ MediaElement��� $��2��.+��  �� $��1* ��� $
��0.5* �.+�� $��0�� �� $
��0.5* ��� $��1* �.+�� $��0������ $/	 )/DIDEx;component/Resources/VidioTouch.png���� $��1��$!��화면을 터치하세요!!��$��Center=�$��Center=�$4��./DIDEx;component/Resources/#Gong Gothic Medium)�$��72(�