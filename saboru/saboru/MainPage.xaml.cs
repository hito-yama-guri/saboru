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
        List<DateTime> primeDate = new List<DateTime>();

        public MainPage()
        {
            InitializeComponent();

            currentDate = DateTime.Now.Date;
            dateText.Text = currentDate.ToString("yyyy/MM/dd");

            prevButton.Clicked += prevButton_Clicked;
            nextButton.Clicked += nextButton_Clicked;

            primeDate.Add(DateTime.Now.Date);
            primeDate.Add( DateTime.Now.Date.AddDays( -2 ) );
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

            bool result = false;
            foreach( DateTime date in primeDate ) {
                if( date == currentDate ) {
                    result = true;
                    break;
                }
            }

            if( result == true ) {
                resultText.Text = "素数な日です！\nサボりましょう！";
            } else {
                resultText.Text = "素数な日ではありません...。\n社畜しましょう。";
            }
        }
    }
}
