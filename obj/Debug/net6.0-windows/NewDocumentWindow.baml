   M S B A M L   `   `   `  ����Q  MFamilyPaperworkManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FamilyPaperworkManagerFamilyPaperworkManager  5   	   .    (FamilyPaperworkManager.NewDocumentWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:FamilyPaperworkManager     5   	     � Title$  Add New Document��5   	   $	��600��6"   $	��400��6/   .��5	      � ���	#FFF7F8F9 � ColumnDefinitions 5
   
   �� 5      $
��200* �6   .+�5   
   �� -   5         ��Name$ DocumentName_label��5      $
��Name��6,   $
��Left=�6;   $��	10,71,0,0q�6V   $	��Top=�6i   $��27��6�   �� 5   
   $��Add New Document_label��6   $
��Left=�61   $��	10,11,0,0q�6L   $	��Top=�6_   $	��142��6w   $��14(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ DocumentName_text��5      $
��Left=�6-   $��	10,98,0,0q�6H    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��167��6�   $��18��6�   �� 5   
   -   5        $ DocumentType_label��5      $��Document type��6,   $
��Left=�6D   $��
10,128,0,0q�6_   $	��Top=�6s   $	��109��6�   $��26��6�   �� 5   
   -   5         ��Name$ AddDocument_button��5      $��Save document��6-   $
��Left=�6E   $��
14,469,0,0q�6`   $	��Top=�6t   $	��120��6�   6�   �� 5   
   -   5        $ Notes_label��5      $��Description��6%   $
��Left=�6;   $��
229,45,0,0q�6V   $	��Top=�6j    J� RenderTransformOrigin$ -1.095,0.502&�6�   �� 5   
   -   5        $ 
Notes_text��5      $
��Left=�6&   $��
229,71,0,0q�6A   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��145��6�   $��81��6�   �� 5   
   -   5        $ DocumentDate_label��5      $
��Date��6,   $
��Left=�6;   $��
14,276,0,0q�6V   $	��Top=�6j   $��27��6�   
������ 6�   �� 5   
   -   5         ��Name$ CurrentDate��5      $
��Left=�6)   $��
64,281,0,0q�6D   $
��Wrap=�6X   $	��Top=�6l   $	��170��6�   ���	#FF7B7676$��Italic$�6�   $��16��6�   ���	#FFF7F4F46�   �� 5   
   -	   5        $ DutyDate_label��5      $��Duty Date/Contract End��6(   $
��Left=�6I   $��
14,314,0,0q�6d   $	��Top=�6x   $	��138��6�   $��26��6�   �� 5   
   -
   5        $ DutyDate_text��5       �� 
IsReadOnly$
 True��6)   $
��Left=�6;   $��
14,345,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $��80��6�   $ 0.508,3.139&�6�   $��19��6�   &   System.Windows.Controls.Calendar  5   
   -   5        	  Name$	 DutyDateCalendar��5      $
��Left=�6-   $��
94,222,0,0q�6H   $	��Top=�6\   $	��150��6t   $	��180��6�   $y�Hidden=�6�   6�   �� 5   
   -   5        
 ��Name$
 DutyDate_checkbox��5      $
��Left=�6/   $��152,319,0,0q�6J   $	��Top=�6_   $ -0.793,0.356&�6�   $��16��6�   �� 5   
   -   5        $ UploadImage_button��5      $��Upload document image��6-   $
��Left=�6M   $��229,170,0,0q�6h   $	��Top=�6}   6�   �� 5   
   -   5         ��Name$ DocumentType_ListBox��5      $��14,159,223,342q�6[   $��11(�6s   6�   �� 5   
   -   5        $ Document_ID_label��5      $��ID��6+   $
��Left=�68   $��	12,44,0,0q�6S   $	��Top=�6f   $��27��6~   $��26��6�   �� 5   
   -   5        $ DocumentID_text��5      $
��Left=�6+   $��	43,49,0,0q�6F   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��134��6�   $��18��6�   �� 5   
   -   5        $ MoneyToPay_label��5      $��Money to pay��6*   $
��Left=�6A   $��
14,383,0,0q�6\   $	��Top=�6p   $��27��6�   
������ $��87��6�   �� 5   
   -   5        $ MoneyToPay_text��5      $
��Left=�6+   $��106,387,0,0q�6F   $
 Wrap=�6[   $	��Top=�6o   $��80��6�   $ 0.508,3.139&�6�   $��19��6�   5!      5"      