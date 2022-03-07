using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel; // CancelEventArgs
using ZOOM_SDK_DOTNET_WRAP;

namespace zoom_sdk_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        start_join_meeting start_meeting_wnd = new start_join_meeting();
        public MainWindow()
        {
            InitializeComponent();
        }

        //callback
        public void onAuthenticationReturn(AuthResult ret)
        {
            if (ZOOM_SDK_DOTNET_WRAP.AuthResult.AUTHRET_SUCCESS == ret)
            {
                start_meeting_wnd.Show();
            }
            else//error handle.todo
            {
                MessageBox.Show("Please Check Your Toren/Secret !");
                Show();
            }
        }
        public void onLoginRet(LOGINSTATUS ret, IAccountInfo pAccountInfo, LOGINFAILREASON reason)
        {
            //todo
        }
        public void onLogout()
        {
            //todo
        }
        private void button_auth_Click(object sender, RoutedEventArgs e)
        {
            //register callback
            
                ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().Add_CB_onAuthenticationReturn(onAuthenticationReturn);
                ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().Add_CB_onLoginRet(onLoginRet);
                ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().Add_CB_onLogout(onLogout);
                //
                ZOOM_SDK_DOTNET_WRAP.AuthContext param = new ZOOM_SDK_DOTNET_WRAP.AuthContext();
                param.jwt_token = textBox_apptoken.Text;
                ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().SDKAuth(param);

                ///////////////////////

                ZOOM_SDK_DOTNET_WRAP.AuthParam authparam = new ZOOM_SDK_DOTNET_WRAP.AuthParam();
                authparam.appKey = textBox_apptoken.Text;
                authparam.appSecret = textBox_secret.Text;
                if (authparam.appKey == "" || authparam.appKey == "TextBox" || authparam.appSecret == "" || authparam.appSecret == "TextBox")
                {
                    MessageBox.Show("Please enter App Token and Secret !");
                }
                else
                {
                    ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().SDKAuth(authparam);

                    ///////////////////////

                    Hide();
                }
            
        }

        void Wnd_Closing(object sender, CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void TextBox_GotFocus1(object sender, RoutedEventArgs e)
        {
            if (textBox_apptoken.Text == "TextBox")
            {
                textBox_apptoken.Text = "";
            }
        }
        public void TextBox_GotFocus2(object sender, RoutedEventArgs e)
        {
            if (textBox_secret.Text == "TextBox")
            {
                textBox_secret.Text = "";
            }
        }
    }
}
