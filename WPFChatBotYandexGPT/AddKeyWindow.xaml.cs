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
using System.Windows.Shapes;

namespace ChatBotYandexGPT_WPF
{
    /// <summary>
    /// Логика взаимодействия для AddKeyWindow.xaml
    /// </summary>
    public partial class AddKeyWindow : Window
    {
        public AddKeyWindow()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            
                if(textboxInsertAPIKey.Text != string.Empty && textboxInsertCatalogIdentifier.Text != string.Empty)
                {
    
                    MessageBox.Show("Данные успешно сохранены!","Сообщение",MessageBoxButton.OK, MessageBoxImage.Information);
                }
            
            
   
        }
    }
}
