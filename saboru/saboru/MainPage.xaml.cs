using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace saboru
{
    public partial class MainPage : ContentPage
    {
        DateTime currentDate;

        public MainPage()
        {
            InitializeComponent();

            currentDate = DateTime.Now.Date;
            dateText.Text = currentDate.ToString("yyyy/MM/dd");

            prevButton.Clicked += prevButton_Clicked;
            nextButton.Clicked += nextButton_Clicked;
        }

        private void prevButton_Clicked( object sender, EventArgs e )
        {
            applyDate( -1 );
        }

        private void nextButton_Clicked( object sender, EventArgs e )
        {
            applyDate( 1 );
        }

        private void applyDate( int diff )
        {
            currentDate = currentDate.AddDays( diff );
            dateText.Text = currentDate.ToString( "yyyy/MM/dd" );
        }
    }
}
