namespace CSharp.Activity.Delegates
{
    public class LoanSystem
    {
        public void ProcessLoanApplication(Action<LoanApplicant> showApplicant)
        {
            LoanApplicant loanApplicant = new LoanApplicant();
            Random random = new Random();
            var randomNumber = random.Next(0, 100);
            loanApplicant.CreditScore = randomNumber;
            showApplicant(loanApplicant);
        }
    }
}
