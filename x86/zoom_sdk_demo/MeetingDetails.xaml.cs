using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZOOM_SDK_DOTNET_WRAP;

namespace zoom_sdk_demo
{
    /// <summary>
    /// Interaction logic for MeetingDetails.xaml
    /// </summary>
    public partial class MeetingDetails : Window
    {
        public Dictionary<uint, string> list = new Dictionary<uint, string>();
        public MeetingDetails()
        {
            InitializeComponent();
            textBox_Nu_Pa.IsReadOnly = true;
            textBox_Pa_IDs.IsReadOnly = true;
            textBox_Pa_Names.IsReadOnly = true;
            textBox_UserID.IsReadOnly = true;
            textBox_UserName.IsReadOnly = true;
            list.Clear();
            Btn_Stop_Record.Visibility = Visibility.Hidden;
            //try
            //{
            //    clear();
            //    Display();
            //}catch(Exception ww)
            //{

            //}
            this.Grid.Visibility = Visibility.Hidden;
            Take();
            
        }

        bool M = false;

        private async void Take()
        {
            if (M == false)
            {
                Console.WriteLine(ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingStatus().ToString());
                if (ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingStatus().ToString() == "MEETING_STATUS_INMEETING")
                {
                    this.Grid.Visibility = Visibility.Visible;
                    clear();
                    Display();
                    M = true;
                }
                else
                {
                    await PutTaskDelay();
                    Take();
                }
            }
            
            }

        internal void button_auth_Click()
        {
            throw new NotImplementedException();
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(500);
        }

        void Wnd_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Calling()
        {
            try
            {
                clear();
                Display();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.InnerException.ToString());
            }
        }

        public void button_auth_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        public void Refresh()
        {
            try
            {
                clear();
                Display();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.InnerException.ToString());
            }
        }

        public void clear()
        {
            textBox_UserID.Text = "";
            textBox_Nu_Pa.Text = "";
            textBox_UserName.Text = "";
            textBox_Pa_Names.Text = "";
            textBox_Pa_IDs.Text = "";
            list.Clear();
        }

        public void Display()
        {
            try
            {
                var Ids = CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingParticipantsController().GetParticipantsList();
                Console.WriteLine("Before = " + Ids.Count() + string.Join(",", Ids));

                var userID = ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingParticipantsController().GetUserByUserID(0);

                textBox_UserID.Text = userID.GetUserID().ToString();
                textBox_Nu_Pa.Text = Ids.Count().ToString();
                textBox_UserName.Text = userID.GetUserNameW().ToString();

                User_ID = ((int)userID.GetUserID());

                //List<String> UserList = new List<String>();

                

                for (int i=0; i< Ids.Count(); i++)
                {
                    var me = ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingParticipantsController().GetUserByUserID(Ids[i]);
                    //UserList.Add(Ids[i].ToString());
                    textBox_Pa_Names.Text += me.GetUserNameW().ToString()+Environment.NewLine;
                    textBox_Pa_IDs.Text += Ids[i] + Environment.NewLine;


                    list.Add(Ids[i],me.GetUserNameW().ToString());
                }


                




                DropDown_Name.ItemsSource = list.Values;

                Console.WriteLine("//////////////////////////////////");
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("fdfgdfg");
            }
        }

        private String Hand = "Lower";
        private int User_ID=0;
        private void Raise_Hand_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Hand == "Raise")
            {
                ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingParticipantsController().LowerHand(((uint)User_ID));
                Raise_Hand_Btn.Content = "Raise Hand";
                Hand = "Lower";
            }
            else
            {
                ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingParticipantsController().RaiseHand();
                Raise_Hand_Btn.Content = "Lower Hand";
                Hand = "Raise";
            }

        }

        private void button_Chat_Click(object sender, RoutedEventArgs e)
        {
            IMeetingUIControllerDotNetWrap uictrl_service = CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetUIController();
            ShowChatDlgParam chat_dlg_param = new ShowChatDlgParam();
            HWNDDotNet chat_wnd_handle = new HWNDDotNet();
            chat_dlg_param.hChatWnd = chat_wnd_handle;
            ValueType va_1 = chat_dlg_param;
            uictrl_service.ShowChatDlg(ref va_1);

            ShowChatDlgParam chat_exposed = (ShowChatDlgParam)va_1;
            HWNDDotNet temp_wnd = (HWNDDotNet)chat_exposed.hChatWnd;
            UInt32 temp_wnd_int = (UInt32)temp_wnd.value;
            Console.WriteLine("Chat window handle ");
            Console.WriteLine(temp_wnd_int);

        }

        private void button_Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uint id = 0;
                List<String> Name = new List<String>();
                List<uint> ids = new List<uint>();
                foreach (KeyValuePair<uint, string> ele in list)
                {
                    Console.WriteLine("{0} and {1}",
                                ele.Key, ele.Value);
                    ids.Add(ele.Key);
                    Name.Add(ele.Value);
                }
                for (int i = 0; i < Name.Count(); i++)
                {
                    if (DropDown_Name.Text == Name[i])
                    {
                        id = ids[i];
                    }
                }
                ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingParticipantsController().ExpelUser(id);
                    MessageBox.Show(ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingParticipantsController().GetUserByUserID(((uint)id)).GetUserNameW().ToString() + " is Removed");
                     Refresh();
            }
            catch (Exception eee)
            {
                MessageBox.Show("You are not a Host");
            }
        }

        private void button_Host_Click(object sender, RoutedEventArgs e)
        {
            uint id = 0;
            List<String> Name = new List<String>();
            List<uint> ids = new List<uint>();
            foreach (KeyValuePair<uint, string> ele in list)
            {
                Console.WriteLine("{0} and {1}",
                            ele.Key, ele.Value);
                ids.Add(ele.Key);
                Name.Add(ele.Value);
            }
            for (int i = 0; i < Name.Count(); i++)
            {
                if (DropDown_Name.Text == Name[i])
                {
                    id = ids[i];
                }
            }

            if (ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingParticipantsController().MakeHost(id).ToString() == "SDKERR_SUCCESS")
            {
                MessageBox.Show(ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingParticipantsController().GetUserByUserID(id).GetUserNameW().ToString() + " is Host");
                DropDown_Name.Text = "";
            }
            else
            {
                MessageBox.Show("You are not a Host");
            }
        }

      
        private void Btn_Start_Record_Click(object sender, RoutedEventArgs e)
        {
            ValueType time = DateTime.Now;
            try
            {
                var err1 = ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingRecordingController().CanAllowDisAllowLocalRecording();
                if (err1.ToString() == "SDKERR_SUCCESS")
                {

                    var err = ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingRecordingController().StartRecording(ref time);
                    
                        Btn_Stop_Record.Visibility = Visibility.Visible;
                        Btn_Start_Record.Visibility = Visibility.Hidden;

                    Console.WriteLine(err);
                }
                else if (err1.ToString() == "SDKERR_NO_PERMISSION")
                {
                    MessageBox.Show("You are not a Host");
                }
            }
            catch (Exception eee)
            {
                
            }
        }

        private void Btn_Stop_Record_Click(object sender, RoutedEventArgs e)
        {
            ValueType time = DateTime.Now;
            try
            {
                Btn_Start_Record.Visibility = Visibility.Visible;
                Btn_Stop_Record.Visibility = Visibility.Hidden;
                var err = CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().GetMeetingRecordingController().StopRecording(ref time);

            }
            catch(Exception eee)
            {
            }
        }
    }
}
