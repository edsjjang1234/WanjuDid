   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      	 DIDEx   DIDEx.Views.MenuFrame   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      N JPrism.DryIoc.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=nullS OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5	      6   0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+5
      .��5      � .+�5   
   � $y�	Collapsed=�6   .+�5   
   �� $��메인메뉴��6   �� 5   
   $��메뉴A��6   $��메뉴A��6?   $
��Left=�6V   $��
90,192,0,0q�6q   $	��Top=�6�   $��75��6�   ��6   �� *MenuCommand+6�   �� 5   
   $��메뉴B��6   $��메뉴B��6?   $
��Left=�6V   $��189,192,0,0q�6q   $	��Top=�6�   $��75��6�   ��6   �� *MenuCommand+6�   �� 5   
   $��메뉴C��6   $��메뉴C��6?   $
��Left=�6V   $��291,192,0,0q�6q   $	��Top=�6�   $��75��6�   ��6   �� *MenuCommand+6�   5      �� 5   
   !  Prism.Regions.RegionManager   
RegionName$ 
MenuRegion��6   5      5      5      