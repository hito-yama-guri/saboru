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
        DateTime date;

        public MainPage()
        {
            InitializeComponent();

            date = DateTime.Now;
            dateText.Text = date.ToString("yyyy/MM/dd");

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
            date = date.AddDays( diff );
            dateText.Text = date.ToString( "yyyy/MM/dd" );
        }
    }
}
