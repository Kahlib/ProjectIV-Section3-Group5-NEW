using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Transaction
    {
        private int TransactionID;
        private double Amount;
        private int SenderID;
        private int ReceiverID;
        private DateTime Timestamp;
        private string TransactionMessage;

        public bool ValidateTransaction()
        {
            // check to make sure amount is more than $0, the ID of who is sending has to exist, the ID of who is receiving has to exist
            // SENDERID AND RECEIVERID NEED TO BE CHANGED TO MAKE IT VALIDATE THEY EXIST, RATHER THAN JUST BEING > 0
            return Amount > 0 && SenderID > 0 && ReceiverID > 0;
        }

        public void LogTransaction()
        {
            // logs the transaction details to the console, including the transaction ID, amount, sender, and receiver.
            Console.WriteLine($"Transaction: {TransactionID}, Amount: {Amount}, From: {SenderID} To: {ReceiverID}");
        }

        public int GenerateTransactionID()
        {
            // NEED DATABASE DONE TO COMPLETE, WITHOUT IT WE DONT KNOW HOW TO GENERATE A UNIQUE ID BECAUSE WE DONT KNOW WHICH ONES HAVE BEEN MADE ALREADY
            return 0;
        }
    }
}
