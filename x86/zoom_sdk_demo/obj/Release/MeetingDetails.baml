   M S B A M L   `   `   `  ���� H  Dzoom_sdk_demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:zoom_sdk_demozoom_sdk_demo  "    zoom_sdk_demo.MeetingDetails   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:zoom_sdk_demo     -     � Title$  MeetingDetails��$��464.377��$	��800��.��� -    �Name$
 Grid�� � ColumnDefinitions �� .+��� -    ��Name$ button_auth��$��Refresh��$
��Left=�$��36��$��
256,30,0,0q�$	��Top=�$	��148���� -    ��Name$ textBox_UserID��$��25��$��350,128,297,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=��� -    ��Name$ 	App_Token��$��	User ID :��$
��Left=�$��278,125,0,0q�$	��Top=�$��56�� J� RenderTransformOrigin$ 0.484,1.222&��� -   $ textBox_Nu_Pa��$��25��$��235,86,258,0q�$
 Wrap=�$�� ��$	��Top=��� -   $ App_Token_Copy��$��Number of Participants :��$
��Left=�$��	88,86,0,0q�$	��Top=�$	��142��$ 0.484,1.222&��� -   $ textBox_UserName��$��25��$��350,168,297,0q�$
 Wrap=�$�� ��$	��Top=��� -	   $ App_Token_Copy1��$��User Name :��$
��Left=�$��256,167,0,0q�$	��Top=�$��78��$ 0.484,1.222&��� -
   $ textBox_Pa_Names��$��78��$��235,240,388,0q�$
 Wrap=�$�� ��$	��Top=��� -   $ App_Token_Copy2��$��Participants Names :��$
��Left=�$��256,209,0,0q�$	��Top=�$	��115��$ 0.484,1.222&��� -   $ textBox_Pa_IDs��$��78��$��442,240,172,0q�$
 Wrap=�$�� ��$	��Top=��� -   $ App_Token_Copy3��$��Participants IDs :��$
��Left=�$��467,214,0,0q�$	��Top=�$	��115��$ 0.484,1.222&��� -   $ Raise_Hand_Btn��$��
Raise Hand��$
��Left=�$��36��$��
472,30,0,0q�$	��Top=�$	��148���� -   $ button_Chat��$��	Open Chat��$
��Left=�$��36��$��588,121,0,0q�$	��Top=�$	��148���� -   $ button_Remove��$��Remove��$
��Left=�$��36��$��434,330,0,0q�$	��Top=�$	��148���� -    ��Name$ DropDown_Name��	 �� 
IsSelected	 .  $��256,346,0,0q�$��20��$	��Top=�$
��Left=�$	��136���� -   $ button_Host��$��	Make Host��$
��Left=�$��36��$��601,330,0,0q�$	��Top=�$	��148���� -   $ Btn_Stop_Record��$��Stop Recording��$
��Left=�$��36��$��656,191,0,0q�$	��Top=�$��93���� -   $ Btn_Start_Record��$��Start Recording��$
��Left=�$��36��$��656,191,0,0q�$	��Top=�$��93��