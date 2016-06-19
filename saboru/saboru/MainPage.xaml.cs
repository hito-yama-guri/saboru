using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            applyDate( 0 );

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

            DateTime start = DateTime.Now;
            bool result = checkPrime(int.Parse(currentDate.ToString("yyyyMMdd")));
            Debug.WriteLine( "time : {0}, result : {1}", DateTime.Now.Subtract( start ).ToString(), result == true ? "true" : "false" );

            if( result == true ) {
                resultText.Text = "素数な日です！\nサボりましょう！";
            } else {
                resultText.Text = "素数な日ではありません...。\n社畜しましょう。";
            }
        }

        private bool checkPrime( int date )
        {
            if( date % 2 == 0 ) {
                return false;
            }

            for( int n = 3; n < (int)Math.Ceiling( Math.Sqrt( date ) ); n += 2 ) {
                if( date % n == 0 ) {
                    return false;
                }
            }

            return true;
        }
    }
}
