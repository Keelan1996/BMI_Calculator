using System;
using Xamarin.Forms;
// inform about the health libary 
using HealthUtilities;
using System.ComponentModel;

namespace BMICalculatorReal
{
    // set up to use data binding 

    //public v private
    //partial classes mainpage + app are added together when the app is built 
    //mainpage is type of contentpage

    // this file is called the code behind = MainPage.xaml.CS the user interface (Mainpage.XAML) which is C#

    /*
     * will do calculations here
     * create a method that does the work
     * take 2 parameters - height/weight
     * return float answer
     */
    public partial class MainPage : ContentPage
    {
        


        // class level variable for times your bmi for free
        // _ indicates its a class level variable 
        int _iFreeGo = 7;
        const int FREE_GO = 7;

        // create an instance of the BMI class

        BodyMassIndex bodyMassIndex; // declaration
        BodyFatCalculator bodyFatCalculator;



        // constructer 
        public MainPage()
        {
            InitializeComponent();
            lblFreeGo.Text = "You have " + _iFreeGo.ToString() + " turns left";
            // decrement _ifreego on each turn
            // may want to hold that value in another variable 

            bodyMassIndex = new BodyMassIndex();

        }

        // generated when I added the event handler to the button in the markup code (XAML)
        private void BtnBMICalcualtion_Clicked(object sender, EventArgs e)
        {
            // calculate the BMI value here from Height and Weight entered by the user.
            // get the values from UI, call a method by passing those value to it.
            // return the BMI.
            // update the UI from there.

            float fHeight, fWeight, fBMI;

            // need to check if the user entered data
            // make sure that the field is not empty
            // use a boolean to store the result
            // if the bool is true, then there is no value so don't do calculation 
            // string.IsNullOrEmpty(EntryHeight.Text)

            bool bIsHeightEmpty = true, bIsWeightEmpty = true;
            // test the strings
            bIsHeightEmpty = string.IsNullOrEmpty(EntryHeight.Text);
            bIsWeightEmpty = string.IsNullOrEmpty(EntryWeight.Text);

            // TEST BOOLEAN
            if (bIsWeightEmpty || bIsHeightEmpty)
            {
                return; // exists the method
            }
            // have proper data, then this is a turn
            if (_iFreeGo == 0)
            {
                LblBMIValue.Text = "game over";
                return;

            }
            else if (_iFreeGo < 0)
            {
                _iFreeGo = FREE_GO;
            }


            _iFreeGo--; // decrement by 1
            lblFreeGo.Text = "You have " + _iFreeGo.ToString() + " turns left";



            fHeight = (float)Convert.ToDouble(EntryHeight.Text);
            fWeight = (float)Convert.ToDouble(EntryWeight.Text);

            // everything above here stays in the event handler 

            // call method to calculate BMI
            // fBMI = DoBMICalculation(fHeight, fWeight);
            // fBMI = bodyMassIndex.CalculateBMIValue(fHeight, fWeight);
            bodyMassIndex.Height = fHeight;
            bodyMassIndex.Weight = fWeight;
            fBMI = bodyMassIndex.BMIValue;


            // below stays too
            // put value back on screen



            AddNewLabel(fBMI);

        }

        private void AddNewLabel(float BMI)
        {
            LblBMIValue.Text = "Your BMI value is: " + BMI.ToString("0.00");
        }



        // create a private method called DoBMICalculation (float Height, floaght weight)
        // return a float for bmi
       private float DoBMICalculation(float height, float weight)
       {
            float fBMI = 0;

            // make height is not zero
            if (height != 0)
            {
                fBMI = weight / (height * height);
            }

           return fBMI;
        }



       


    }

}

