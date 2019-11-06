// Author: H. Paul Keeler, 2019.
// github.com/hpaulkeeler
// hpaulkeeler.com/

using System;
namespace Poisson

{
    class Poisson {
        static void Main () {
            double lambda = 8.7; // lambda is the Poisson parameter (that is, it's mean)

            int numbSim = 100; //number of random variables

            //START Collect statistists on Poisson variables
            //initialize statistics
            int numbPoissonTemp;
            double sumPoisson = 0;
            double sumPoissonSquared = 0;

            RandomGenerator rand = new RandomGenerator ();

            //loop through for each random variable
            for (int i = 0; i < numbSim; i++) {

                //generate a single poisson variable
                numbPoissonTemp = rand.funPoissonSingle (lambda);

                //total sum of variables
                sumPoisson += numbPoissonTemp;
                //total sum of squared variables
                sumPoissonSquared += Math.Pow (numbPoissonTemp, 2);

                if (i < 5) {
                    //print the first 5 numbers
                    Console.WriteLine ("One of the Poisson variables has the value " + numbPoissonTemp + ".");
                }

            }

            //calculate statistics 
            double meanPoisson = sumPoisson / ((double) numbSim);
            double varPoisson = sumPoissonSquared / ((double) numbSim) - Math.Pow (meanPoisson, 2);
			
			///print statistics
            Console.WriteLine ("The average of the Poisson variables is " + meanPoisson);
            Console.WriteLine ("The variance of the Poisson variables is " + varPoisson);
            Console.WriteLine ("For Poisson random variables, the mean and variance will more agree as the number of simuations increases.");

            //END Collect statistists on Poisson variables

            // keep the console window open in debug mode.
            Console.WriteLine ("Press any key to exit.");
            Console.ReadKey ();

        }

    }

}

//class for generating random numbers    
public class RandomGenerator {
    //create randoom number generator
    Random random = new Random ();

    //START Function definitions
    //Poisson function -- returns a single Poisson random variable        
    public int funPoissonSingle (double lambda) {

        double randUni; //uniform variable
        double randExpTemp; //exponential variable		
        double sum_exp = 0; //sum of exponential variable

        //initialize variables
        int randPoisson = -1;
        do {
            randUni = funUniformSingle (); //generate uniform variable
            randExpTemp = -(1 / lambda) * Math.Log (randUni); //exponential random variable
            sum_exp = sum_exp + randExpTemp; // increase random sum
            randPoisson++; // increase Poisson variable

        } while (sum_exp < 1); //stop loop if sum exceeds one

        return randPoisson;
    }

    //Uniform function -- returns a standard uniform random variable
    public double funUniformSingle () {

        return random.NextDouble ();
    }
}