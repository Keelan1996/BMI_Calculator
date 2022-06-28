using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

//namespace BMICalculator1    // current solution - be careful of the namespace
namespace HealthUtilities
{
    // set up this to use data binding - implement the INotifyPropertyChange interface
    public class BodyMassIndex : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // the two properties that can change are Height and Weight
        // if either changes, then the BMI changes as a result

        // == private variables ==
        private float height;
        private float weight;

        // == public properties ==
        public float Height
        {
            get { return height; } // return the private variable.
            set 
            { 
                height = value; 
                if(PropertyChanged != null)     // it's changed and I care
                {
                    // PropertyChanged(object sender, EventArgs e)
                    PropertyChanged(this, new PropertyChangedEventArgs("BMIValue"));
                }
            } // set to the value passed in.
        }

        public float Weight
        {
            get { return weight; }
            set 
            { 
                weight = value; 
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BMIValue"));
                }
            }
        }

        public float BMIValue
        {
            get { return height > 0 ? weight / (height * height) : 0; }
        }



        //public float CalculateBMIValue(float height, float weight)
        //{
        //    float fBMI = 0;

        //    if( height > 0)
        //    {
        //        fBMI = weight / (height * height);
        //    }
        //    return fBMI;
        //}
    }

    
}
