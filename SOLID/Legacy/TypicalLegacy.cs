using System.Data.SqlClient;

namespace SOLID.Legacy
{
    public class TypicalLegacy
    {
        public void ProcessIncident(Account account, int incidentId, 
			SqlConnection connection, SqlTransaction transaction)
        {


            if (account.AccountType == "VIP")
            {

                var escalator = new AccountEscalator();
                escalator.Escalate(account);
	            return;
            }



            var dataAccess = new DataAccess();
            dataAccess.CreateIncident(account, incidentId, connection, transaction);


	        if (transaction != null)
	        {

		        transaction.Commit();

	        }

        }
    }
}
