using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Form_Mbcif.Forms
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    /// 

    
    

    public partial class UserControl1 : UserControl
    {
        private generagrafo gg;

        public UserControl1()
        {
            this.gg = new generagrafo();
            this.DataContext = gg;
            InitializeComponent();
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (ElementoGrafo elem in gg.Graph.AllVertices)
            {
                
                if (elem.nombre.Equals("bencina"))
                {
                    gg.cambiarelemento(elem, 600);
                    gg.CreateElemento();
                    break;
                }   
            }
        }
    }
}
