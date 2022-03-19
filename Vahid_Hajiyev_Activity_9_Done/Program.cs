namespace CSharp.Activity.Delegates
{
    public class Program
    {
        public static void Show(LoanApplicant loanApplicant)
        {
            double score = loanApplicant.CreditScore;
            Console.WriteLine("Applicant's credit score is: " + score);
            CheckCreditStatus(score);
        }

        public static void CheckCreditStatus(double creditScore)
        {
            if (creditScore > 66)
            {
                Console.WriteLine("Credit amount is validated to the customer!");
            }

            else
            {
                Console.WriteLine("Credit amount is not validated to the customer!");
            }
        }

        public static void Main()
        {
            LoanSystem system = new LoanSystem();

            // Here, show method is considered
            // as a callback method
            system.ProcessLoanApplication(Show);
        }
    }
}